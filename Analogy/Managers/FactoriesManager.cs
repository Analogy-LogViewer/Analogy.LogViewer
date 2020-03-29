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
            FactoryContainer fc = new FactoryContainer(Assembly.GetExecutingAssembly());
            fc.AddFactory(new AnalogyBuiltInFactory());
            fc.AddFactory(new EventLogDataFactory());
            fc.AddDataProviderFactory(new AnalogyOfflineDataProviderFactory());
            fc.AddCustomActionFactory(new AnalogyCustomActionFactory());
            BuiltInFactories.Add(fc);
        }

        public async Task InitializeBuiltInFactories()
        {
            try
            {
                foreach (FactoryContainer factoryContainer in BuiltInFactories)
                {
                    foreach (var factory in factoryContainer.Factories)
                    {
                        FactorySettings setting = UserSettingsManager.UserSettings.GetOrAddFactorySetting(factory);
                        factoryContainer.AddFactorySettings(setting);
                        setting.FactoryName = factory.Title;
                        if (setting.Status == DataProviderFactoryStatus.Disabled) continue;
                        foreach (var providerFactory in factoryContainer.DataProvidersFactories.Where(f =>
                            f.FactoryId == factory.FactoryId))
                        {
                            foreach (var provider in providerFactory.DataProviders)
                            {
                                await provider.InitializeDataProviderAsync(AnalogyLogger.Instance);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                AnalogyLogManager.Instance.LogError("Error during data providers: " + e, nameof(FactoriesManager));
            }

        }

        public async Task AddExternalDataSources()
        {
            ExternalDataProviders result = await ExternalDataProviders.GetExternalDataProviders();
            var distinctFactory = result.Factories.Where(f => !Factories.Contains(f)).ToList();
            Factories.AddRange(distinctFactory);
            var dataProviders = distinctFactory.SelectMany(f => f.EnabledDataProvidersFactories)
                .SelectMany(d => d.DataProviders);
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
                    AnalogyLogger.Instance.LogException(t.Exception,"AddExternalDataSources", "Error during Initialization");
                }
            }
        }

        public IEnumerable<(IAnalogyOfflineDataProvider DataProvider, Guid FactoryID)> GetSupportedOfflineDataSources(string[] fileNames)
        {
            foreach (var factory in Factories)
            {
                for
                var supported = factory.DataProviders.Items.Where(i =>
                    i is IAnalogyOfflineDataProvider offline && offline.CanOpenAllFiles(fileNames));
                foreach (IAnalogyDataProvider dataSource in supported)
                {
                    yield return (dataSource as IAnalogyOfflineDataProvider, factory.FactoryID);
                }
            }
        }

        public IEnumerable<IAnalogyOfflineDataProvider> GetSupportedOfflineDataSourcesFromFactory(Guid factoryID,
            string[] fileNames)
        {
            if (Factories.Exists(f => f.FactoryID == factoryID))
            {
                var factory = Factories.First(f => f.FactoryID == factoryID);
                var supported = factory.DataProviders.Items.Where(i =>
                    i is IAnalogyOfflineDataProvider offline && offline.CanOpenAllFiles(fileNames));


                foreach (IAnalogyDataProvider dataSource in supported)
                {
                    yield return dataSource as IAnalogyOfflineDataProvider;
                }
            }

        }

        public IEnumerable<(string Name, Guid ID)> GetRealTimeDataSourcesNamesAndIds()
        {
            foreach (var factory in Factories)
            {
                IEnumerable<IAnalogyDataProvider> supported =
                    factory.DataProviders.Items.Where(i => i is IAnalogyRealTimeDataProvider);
                foreach (var analogyDataSource in supported)
                {
                    var dataSource = (IAnalogyRealTimeDataProvider)analogyDataSource;
                    yield return (factory.Title, dataSource.ID);
                }
            }
        }

        public Assembly GetAssemblyOfFactory(IAnalogyFactory factory) =>
            Factories.Single(f => f.Factories.Contains(factory)).Assembly;

        public IAnalogyFactory Get(Guid id) =>
            Factories.Single(a => a.Factories.Exists(f => f.FactoryId == id))
                     .Factories.Single(f => f.FactoryId == id);

        public bool IsBuiltInFactory(IAnalogyFactory factory) => IsBuiltInFactory(factory.FactoryId);

        public bool IsBuiltInFactory(Guid factoryId) =>
            BuiltInFactories.Exists(fc => fc.Factories.Exists(f => f.FactoryId == factoryId));
        public List<IAnalogyDataProviderSettings> GetProvidersSettings() => Factories.SelectMany(f=>f.FactorySettings).Where(f=>f.)

        public IAnalogyDataProviderSettings GetSettings(Guid factoryId) =>
            DataProvidersSettings.FirstOrDefault(p => p.FactoryId == factoryId);
    }

    public class ExternalDataProviders
    {
        private static readonly AsyncLazy<ExternalDataProviders> _instance = new AsyncLazy<ExternalDataProviders>(() => new ExternalDataProviders());

        public static async Task<ExternalDataProviders> GetExternalDataProviders() => await _instance.Start();
        public List<FactoryContainer> Factories { get; private set; }

        private ExternalDataProviders()
        {

            Factories = new List<FactoryContainer>();

            var analogyAssemblies = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory,
                @"*Analogy.LogViewer.*.dll", SearchOption.TopDirectoryOnly);
            foreach (string aFile in analogyAssemblies)
            {
                try
                {
                   
                    Assembly assembly = Assembly.LoadFrom(Path.GetFullPath(aFile));
                    FactoryContainer factoryContainer = new FactoryContainer(assembly);
                    Type[] types = assembly.GetTypes();
                    foreach (Type aType in types)
                    {
                        try
                        {
                            if (aType.GetInterface(nameof(IAnalogyFactory)) != null && Activator.CreateInstance(aType) is IAnalogyFactory factory)
                            {
                                factoryContainer.AddFactory(factory);
                                FactorySettings setting = UserSettingsManager.UserSettings.GetOrAddFactorySetting(factory);
                                setting.FactoryName = factory.Title;
                                factoryContainer.AddFactorySettings(setting);
                                if (setting.Status == DataProviderFactoryStatus.Disabled) continue;
                                foreach (var provider in factory.DataProviders.Items)
                                {
                                    provider.InitializeDataProviderAsync(AnalogyLogger.Instance);
                                }
                            }

                            if (aType.GetInterface(nameof(IAnalogyDataProviderSettings)) != null)
                            {
                                if (!(Activator.CreateInstance(aType) is IAnalogyDataProviderSettings setting))
                                    continue;
                                DataProviderSettings.Add(setting);
                            }
                        }
                        catch (ReflectionTypeLoadException ex)
                        {
                            AnalogyLogManager.Instance.LogError($"{aType}: Error during data providers: {string.Join(",", ex.LoaderExceptions.ToList())}. {aFile})", nameof(FactoriesManager));
                        }
                        catch (Exception e)
                        {
                            AnalogyLogManager.Instance.LogError($"{aType}: Error during data providers: {e} ({e.InnerException}. {aFile})", nameof(FactoriesManager));
                        }

                    }
                }
                catch (ReflectionTypeLoadException ex)
                {
                    AnalogyLogManager.Instance.LogError($"{aFile}: Error during data providers: {string.Join(",", ex.LoaderExceptions.ToList())}. {aFile})", nameof(FactoriesManager));
                }
                catch (Exception e)
                {
                    AnalogyLogManager.Instance.LogError($"{aFile}: Error during data providers: {e} ({e.InnerException})", nameof(FactoriesManager));
                }
            }
        }

    }
}
