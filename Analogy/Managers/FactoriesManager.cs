using Analogy.DataProviders.Extensions;
using Analogy.DataSources;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.Managers;
using Analogy.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Analogy
{
    public class FactoriesManager
    {

        private static readonly Lazy<FactoriesManager>
            _instance = new Lazy<FactoriesManager>(() => new FactoriesManager());

        private static object sync = new object();
        public static readonly FactoriesManager Instance = _instance.Value;
        private List<FactoryContainer> BuiltInFactories { get; }

        public List<FactoryContainer> Factories { get; private set; }

        public FactoriesManager()
        {
            Factories = new List<FactoryContainer>();
            BuiltInFactories = new List<FactoryContainer>();
            var analogyFactory = new AnalogyBuiltInFactory();
            var currentAssembly = Assembly.GetExecutingAssembly();
            var analogyFactorySetting = UserSettingsManager.UserSettings.GetOrAddFactorySetting(analogyFactory);
            analogyFactorySetting.FactoryName = analogyFactory.Title;
            FactoryContainer fc = new FactoryContainer(currentAssembly, analogyFactory, analogyFactorySetting);
            fc.AddDataProviderFactory(new AnalogyOfflineDataProviderFactory());
            fc.AddCustomActionFactory(new AnalogyCustomActionFactory());
            BuiltInFactories.Add(fc);
        }

        public async Task InitializeBuiltInFactories()
        {

            var dataProviders = BuiltInFactories
                .Where(f => f.FactorySetting.Status != DataProviderFactoryStatus.Disabled)
                .SelectMany(fc => fc.DataProvidersFactories.SelectMany(d => d.DataProviders)).ToList();
            var initTasks = dataProviders.Select(d => d.InitializeDataProviderAsync(AnalogyLogger.Instance))
                .ToList();
            var completion = Task.WhenAll(initTasks);
            try
            {
                await completion;
            }
            catch (AggregateException ex)
            {
                AnalogyLogger.Instance.LogException(ex, "InitializeBuiltInFactories",
                    "Error during Initialization");
            }

            foreach (var t in initTasks)
            {
                if (t.Status != TaskStatus.RanToCompletion)
                {
                    AnalogyLogger.Instance.LogException(t.Exception, "AddExternalDataSources",
                        "Error during Initialization");
                }
            }
        }

        public async Task AddExternalDataSources()
        {
            ExternalDataProviders result = await ExternalDataProviders.GetExternalDataProviders();
            var factoryContainers = result.Factories.Where(f => !Factories.Contains(f)).ToList();
            Factories.AddRange(factoryContainers);
            var dataProviders = factoryContainers.Where(f =>
                    f.FactorySetting.Status != DataProviderFactoryStatus.Disabled)
                .SelectMany(fc => fc.DataProvidersFactories.SelectMany(d => d.DataProviders)).ToList();
            var initTasks = dataProviders.Select(d => d.InitializeDataProviderAsync(AnalogyLogger.Instance)).ToList();
            var completion = Task.WhenAll(initTasks);
            try
            {
                await completion;
            }
            catch (AggregateException ex)
            {
                AnalogyLogger.Instance.LogException(ex, "AddExternalDataSources", "Error during Initialization");
            }

            foreach (var t in initTasks)
            {
                if (t.Status != TaskStatus.RanToCompletion)
                {
                    AnalogyLogger.Instance.LogException(t.Exception, "AddExternalDataSources",
                        "Error during Initialization");
                }
            }
        }

        public IEnumerable<(IAnalogyOfflineDataProvider DataProvider, Guid FactoryID)> GetSupportedOfflineDataSources(
            string[] fileNames)
        {
            foreach (var factory in Factories.Where(f => f.FactorySetting.Status != DataProviderFactoryStatus.Disabled))
            {
                foreach (var dataProvidersFactory in factory.DataProvidersFactories)
                {
                    var supported = dataProvidersFactory.DataProviders.Where(i =>
                        i is IAnalogyOfflineDataProvider offline && offline.CanOpenAllFiles(fileNames));
                    foreach (IAnalogyDataProvider dataSource in supported)
                    {
                        yield return (dataSource as IAnalogyOfflineDataProvider,
                            dataProvidersFactory.FactoryId);
                    }
                }
            }
        }

        public IEnumerable<IAnalogyOfflineDataProvider> GetSupportedOfflineDataSourcesFromFactory(Guid factoryId,
            string[] fileNames)
        {
            return GetSupportedOfflineDataSources(fileNames).Where(res => res.FactoryID == factoryId)
                .Select(res => res.DataProvider);
        }

        public IEnumerable<(string Name, Guid ID)> GetRealTimeDataSourcesNamesAndIds()
        {
            foreach (var fc in Factories)
            {
                foreach (var dpf in fc.DataProvidersFactories)
                {
                    IEnumerable<IAnalogyDataProvider> supported =
                        dpf.DataProviders.Where(d => d is IAnalogyRealTimeDataProvider);
                    foreach (var analogyDataSource in supported)
                    {
                        var dataSource = (IAnalogyRealTimeDataProvider) analogyDataSource;
                        yield return (dpf.Title, dataSource.ID);
                    }
                }
            }
        }

        public Assembly GetAssemblyOfFactory(IAnalogyFactory factory)
        {
            if (BuiltInFactories.Exists(f => f.Factory == factory))
                return BuiltInFactories.First(f => f.Factory == factory).Assembly;
            return Factories.Single(f => f.Factory == factory).Assembly;
        }

        public FactoryContainer GetBuiltInFactoryContainer(Guid id) => BuiltInFactories.Single(f => f.Factory.FactoryId == id);
        public bool IsBuiltInFactory(IAnalogyFactory factory) => IsBuiltInFactory(factory.FactoryId);

        public bool IsBuiltInFactory(Guid factoryId) =>
            BuiltInFactories.Exists(fc => fc.Factory.FactoryId == factoryId);

        public List<IAnalogyDataProviderSettings> GetProvidersSettings() => Factories
            .Where(f => f.FactorySetting.Status != DataProviderFactoryStatus.Disabled)
            .SelectMany(f => f.DataProvidersSettings)
            .ToList();

        public List<IAnalogyDataProviderSettings> GetSettings(Guid factoryId) => Factories
            .Single(fc =>
                fc.FactorySetting.Status != DataProviderFactoryStatus.Disabled && fc.Factory.FactoryId == factoryId)
            .DataProvidersSettings;


        public class ExternalDataProviders
        {
            private static readonly AsyncLazy<ExternalDataProviders> _instance =
                new AsyncLazy<ExternalDataProviders>(() => new ExternalDataProviders());

            public static async Task<ExternalDataProviders> GetExternalDataProviders() => await _instance.Start();
            public List<FactoryContainer> Factories { get; private set; }

            private ExternalDataProviders()
            {

                Factories = new List<FactoryContainer>();

                var analogyAssemblies = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory,
                    @"*Analogy.LogViewer.*.dll", SearchOption.TopDirectoryOnly).ToList();
                foreach (string aFile in analogyAssemblies)
                {
                    try
                    {
                        Assembly assembly = Assembly.LoadFrom(Path.GetFullPath(aFile));
                        var types = assembly.GetTypes().ToList();
                        foreach (var f in types.Where(aType => aType.GetInterface(nameof(IAnalogyFactory)) != null))
                        {
                            var factory = Activator.CreateInstance(f) as IAnalogyFactory;
                            var setting = UserSettingsManager.UserSettings.GetOrAddFactorySetting(factory);
                            setting.FactoryName = factory.Title;
                            FactoryContainer fc = new FactoryContainer(assembly, factory, setting);
                            Factories.Add(fc);
                        }

                        foreach (Type aType in types.Where(aType =>
                            aType.GetInterface(nameof(IAnalogyDataProvidersFactory)) != null))
                        {

                            var dataProviderFactory = Activator.CreateInstance(aType) as IAnalogyDataProvidersFactory;
                            var factory = Factories.First(f => f.Factory.FactoryId == dataProviderFactory.FactoryId);
                            factory.AddDataProviderFactory(dataProviderFactory);
                        }

                        foreach (Type aType in types.Where(aType =>
                            aType.GetInterface(nameof(IAnalogyDataProviderSettings)) != null))
                        {

                            var settings = Activator.CreateInstance(aType) as IAnalogyDataProviderSettings;
                            var factory = Factories.First(f => f.Factory.FactoryId == settings.FactoryId);
                            factory.AddDataProvidersSettings(settings);
                        }

                        foreach (Type aType in types.Where(aType =>
                            aType.GetInterface(nameof(IAnalogyCustomActionsFactory)) != null))
                        {

                            var custom = Activator.CreateInstance(aType) as IAnalogyCustomActionsFactory;
                            var factory = Factories.First(f => f.Factory.FactoryId == custom.FactoryId);
                            factory.AddCustomActionFactory(custom);
                        }

                        foreach (Type aType in types.Where(aType =>
                            aType.GetInterface(nameof(IAnalogyShareableFactory)) != null))
                        {

                            var share = Activator.CreateInstance(aType) as IAnalogyShareableFactory;
                            var factory = Factories.First(f => f.Factory.FactoryId == share.FactoryId);
                            factory.AddShareableFactory(share);
                        }
                    }
                    catch (ReflectionTypeLoadException ex)
                    {
                        AnalogyLogManager.Instance.LogError(
                            $"{aFile}: Error during data providers: {string.Join(",", ex.LoaderExceptions.ToList())}. {aFile})",
                            nameof(FactoriesManager));
                    }
                    catch (Exception e)
                    {
                        AnalogyLogManager.Instance.LogError(
                            $"{aFile}: Error during data providers: {e} ({e.InnerException}. {aFile})",
                            nameof(FactoriesManager));
                    }

                }

            }

        }
    }
}
