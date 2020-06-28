using Analogy.DataProviders.Extensions;
using Analogy.DataSources;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.Managers;
using Analogy.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            var initTasks = new List<Task>();
            foreach (var provider in dataProviders)
            {
                try
                {
                    initTasks.Add(provider.InitializeDataProviderAsync(AnalogyLogger.Instance));

                }
                catch (Exception e)
                {
                    AnalogyLogger.Instance.LogException(e, "AddExternalDataSources", $"Error during Initialization of {provider.OptionalTitle}");

                }
            }
            try
            {
                await Task.WhenAll(initTasks);
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
                        var dataSource = (IAnalogyRealTimeDataProvider)analogyDataSource;
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

        public Image GetLargeImage(Guid componentId)
        {
            foreach (var factoryContainer in Factories.Where(f => f.ContainsDataProviderOrDataFactory(componentId)))
            {
                foreach (var componentImages in factoryContainer.DataProviderImages)
                {
                    var image = componentImages.GetLargeImage(componentId);
                    if (image != null) return image;
                }
            }

            return null;
        }

        public Image GetSmallImage(Guid componentId)
        {
            foreach (var factoryContainer in Factories.Where(f => f.ContainsDataProviderOrDataFactory(componentId)))
            {
                foreach (var componentImages in factoryContainer.DataProviderImages)
                {
                    var image = componentImages.GetSmallImage(componentId);
                    if (image != null) return image;
                }
            }

            return null;
        }

        public Image GetOnlineConnectedLargeImage(Guid componentId)
        {
            foreach (var factoryContainer in Factories.Where(f => f.ContainsDataProviderOrDataFactory(componentId)))
            {
                foreach (var componentImages in factoryContainer.DataProviderImages)
                {
                    var image = componentImages.GetOnlineConnectedLargeImage(componentId);
                    if (image != null) return image;
                }
            }

            return null;
        }
        public Image GetOnlineConnectedSmallImage(Guid componentId)
        {
            foreach (var factoryContainer in Factories.Where(f => f.ContainsDataProviderOrDataFactory(componentId)))
            {
                foreach (var componentImages in factoryContainer.DataProviderImages)
                {
                    var image = componentImages.GetOnlineConnectedSmallImage(componentId);
                    if (image != null) return image;
                }
            }

            return null;
        }

        public Image GetOnlineDisconnectedSmallImage(Guid componentId)
        {
            foreach (var factoryContainer in Factories.Where(f => f.ContainsDataProviderOrDataFactory(componentId)))
            {
                foreach (var componentImages in factoryContainer.DataProviderImages)
                {
                    var image = componentImages.GetOnlineDisconnectedSmallImage(componentId);
                    if (image != null) return image;
                }
            }

            return null;
        }
        public Image GetOnlineDisconnectedLargeImage(Guid componentId)
        {
            foreach (var factoryContainer in Factories.Where(f => f.ContainsDataProviderOrDataFactory(componentId)))
            {
                foreach (var componentImages in factoryContainer.DataProviderImages)
                {
                    var image = componentImages.GetOnlineConnectedLargeImage(componentId);
                    if (image != null) return image;
                }
            }

            return null;
        }
        public class ExternalDataProviders
        {
            private static readonly AsyncLazy<ExternalDataProviders> _instance =
                new AsyncLazy<ExternalDataProviders>(() => new ExternalDataProviders());

            public static async Task<ExternalDataProviders> GetExternalDataProviders() => await _instance.Start();
            public List<FactoryContainer> Factories { get; private set; }
            public List<(Guid id, IAnalogyComponentImages images)> DataProvidersImages { get; set; }

            private ExternalDataProviders()
            {
                DataProvidersImages = new List<(Guid id, IAnalogyComponentImages images)>();
                Factories = new List<FactoryContainer>();
                var analogyAssemblies = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory,
                    @"*Analogy.LogViewer.*.dll", SearchOption.TopDirectoryOnly).ToList();
                if (UserSettingsManager.UserSettings.AdditionalProbingLocations != null)
                {
                    foreach (string folder in UserSettingsManager.UserSettings.AdditionalProbingLocations)
                    {
                        try
                        {
                            if (Directory.Exists(folder))
                                analogyAssemblies.AddRange(Directory.EnumerateFiles(folder, @"*Analogy.LogViewer.*.dll",
                                    SearchOption.TopDirectoryOnly).ToList());
                        }
                        catch (Exception e)
                        {
                            AnalogyLogger.Instance.LogException(e, nameof(ExternalDataProviders),
                                $"Error probing folder {folder}. Error: {e.Message}");
                        }
                    }


                }
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
                            if (Factories.Exists(fa => fa.Factory.FactoryId == factory.FactoryId))
                            {
                                Factories.Remove(Factories.FirstOrDefault(fa =>
                                    fa.Factory.FactoryId == factory.FactoryId));
                            }
                            Factories.Add(fc);

                        }
                        foreach (var t in types.Where(aType => aType.GetInterface(nameof(IAnalogyComponentImages)) != null))
                        {
                            var images = Activator.CreateInstance(t) as IAnalogyComponentImages;
                            var factory = Factories.First(f => f.Assembly == assembly);
                            factory.AddImages(images);

                        }


                        foreach (Type aType in types.Where(aType =>
                            aType.GetInterface(nameof(IAnalogyDataProvidersFactory)) != null))
                        {

                            var dataProviderFactory = Activator.CreateInstance(aType) as IAnalogyDataProvidersFactory;
                            var factory = Factories.FirstOrDefault(f => f.Factory.FactoryId == dataProviderFactory?.FactoryId);
                            factory?.AddDataProviderFactory(dataProviderFactory);
                        }

                        foreach (Type aType in types.Where(aType =>
                            aType.GetInterface(nameof(IAnalogyDataProviderSettings)) != null))
                        {

                            var settings = Activator.CreateInstance(aType) as IAnalogyDataProviderSettings;
                            var factory = Factories.FirstOrDefault(f => f.Factory.FactoryId == settings?.FactoryId);
                            factory?.AddDataProvidersSettings(settings);
                        }

                        foreach (Type aType in types.Where(aType =>
                            aType.GetInterface(nameof(IAnalogyCustomActionsFactory)) != null))
                        {

                            var custom = Activator.CreateInstance(aType) as IAnalogyCustomActionsFactory;
                            var factory = Factories.FirstOrDefault(f => f.Factory.FactoryId == custom?.FactoryId);
                            factory?.AddCustomActionFactory(custom);
                        }

                        foreach (Type aType in types.Where(aType =>
                            aType.GetInterface(nameof(IAnalogyShareableFactory)) != null))
                        {

                            var share = Activator.CreateInstance(aType) as IAnalogyShareableFactory;
                            var factory = Factories.FirstOrDefault(f => f.Factory.FactoryId == share?.FactoryId);
                            factory?.AddShareableFactory(share);
                        }
                        foreach (Type aType in types.Where(aType =>
                            aType.GetInterface(nameof(IAnalogyExtensionsFactory)) != null))
                        {

                            var extension = Activator.CreateInstance(aType) as IAnalogyExtensionsFactory;
                            var factory = Factories.FirstOrDefault(f => f.Factory.FactoryId == extension?.FactoryId);
                            factory?.AddExtensionFactory(extension);
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

                Factories.RemoveAll(f => f.FactorySetting.Status == DataProviderFactoryStatus.Disabled);
            }

        }

        public IEnumerable<IAnalogyExtension> GetExtensions(IAnalogyDataProvider dataProvider)
            => GetAllExtensions().Where(e => e.TargetProviderId == dataProvider.ID);

        public IEnumerable<IAnalogyExtension> GetAllExtensions()
        {
            foreach (var factory in Factories)
            {
                if (factory.FactorySetting.Status == DataProviderFactoryStatus.Disabled) continue;
                foreach (var extensionFactory in factory.ExtensionsFactories)
                {
                    foreach (IAnalogyExtension extension in extensionFactory.Extensions)
                    {
                        yield return extension;
                    }
                }
            }
        }
    }
}
