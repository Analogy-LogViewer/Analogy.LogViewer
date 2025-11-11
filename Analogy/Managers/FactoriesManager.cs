using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.DataProviders;
using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.Interfaces.Winforms;
using Analogy.Interfaces.Winforms.Factories;
using Analogy.Managers;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Analogy
{
    public class FactoriesManager : IFactoriesManager
    {
        public List<string> ProbingPaths { get; set; } = new List<string>();
        public List<FactoryContainer> BuiltInFactories { get; }
        public List<FactoryContainer> Factories { get; }
        private IAnalogyUserSettings Settings { get; }
        private IAnalogyFoldersAccess FoldersAccess { get; }
        private NotificationManager NotificationManager { get; }
        private AnalogyOnDemandPlottingManager PlottingManager { get; }
        private bool ExternalAdded { get; set; }
        private ILogger Logger { get; }
        private Dictionary<IAnalogyDataProvider, bool> Initialized { get; set; }
        public List<IRawSQLInteractor> RawSQLManipulators => Factories.SelectMany(f => f.UserControlsFactories)
            .SelectMany(u => u.UserControls).Where(u => u is IRawSQLInteractor).Cast<IRawSQLInteractor>().ToList();

        public FactoriesManager(AnalogyBuiltInFactory analogyFactory, IAnalogyUserSettings settings,
            IAnalogyFoldersAccess foldersAccess, NotificationManager notificationManager,
            AnalogyOnDemandPlottingManager plottingManager, ILogger logger)
        {
            Initialized = new Dictionary<IAnalogyDataProvider, bool>();
            Factories = new List<FactoryContainer>();
            BuiltInFactories = new List<FactoryContainer>();
            Settings = settings;
            FoldersAccess = foldersAccess;
            NotificationManager = notificationManager;
            PlottingManager = plottingManager;
            Logger = logger;
            analogyFactory.RegisterNotificationCallback(notificationManager);
            var currentAssembly = Assembly.GetExecutingAssembly();
            var analogyFactorySetting = ServicesProvider.Instance.GetService<IAnalogyUserSettings>()
                .GetOrAddFactorySetting(analogyFactory);
            analogyFactorySetting.FactoryName = analogyFactory.Title;
            FactoryContainer fc = new FactoryContainer(currentAssembly, Environment.CurrentDirectory, analogyFactory,
                analogyFactorySetting);
            fc.AddDataProviderFactory(new AnalogyOfflineDataProviderFactory());
            fc.AddCustomActionFactory(new AnalogyCustomActionFactory());
            BuiltInFactories.Add(fc);
        }

        public async Task InitializeBuiltInFactories()
        {
            var dataProviders = BuiltInFactories
                .Where(f => f.FactorySetting.Status != DataProviderFactoryStatus.Disabled)
                .SelectMany(fc => fc.DataProvidersFactories.SelectMany(d => d.DataProviders)).ToList();
            var initTasks = dataProviders.Select(d => d.InitializeDataProvider(ServicesProvider.Instance.GetService<ILogger>()))
                .ToList();
            var completion = Task.WhenAll(initTasks);
            try
            {
                await completion;
            }
            catch (AggregateException ex)
            {
                ServicesProvider.Instance.GetService<ILogger>().LogError(ex, "Error during Initialization");
            }

            foreach (var t in initTasks)
            {
                if (t.Status != TaskStatus.RanToCompletion)
                {
                    ServicesProvider.Instance.GetService<ILogger>().LogError(t.Exception, "Error during Initialization");
                }
            }
        }

        public IEnumerable<(IAnalogyOfflineDataProviderWinforms DataProvider, Guid FactoryID)> GetSupportedOfflineDataSources(
            string[] fileNames)
        {
            foreach (var factory in Factories.Where(f => f.FactorySetting.Status != DataProviderFactoryStatus.Disabled))
            {
                foreach (var dataProvidersFactory in factory.DataProvidersFactories)
                {
                    var supported = dataProvidersFactory.DataProviders.Where(i =>
                        i is IAnalogyOfflineDataProviderWinforms offline && offline.CanOpenAllFiles(fileNames));
                    foreach (IAnalogyDataProviderWinforms dataSource in supported)
                    {
                        yield return (dataSource as IAnalogyOfflineDataProviderWinforms, dataProvidersFactory.FactoryId);
                    }
                }
            }
        }
        public IEnumerable<IAnalogyOfflineDataProviderWinforms> GetOfflineDataSources(Guid factoryId)
        {
            var all = BuiltInFactories.ToList();
            all.AddRange(Factories.ToList());
            foreach (var factory in all.Where(f => f.FactorySetting.Status != DataProviderFactoryStatus.Disabled))
            {
                foreach (var dataProvidersFactory in factory.DataProvidersFactories)
                {
                    var supported = dataProvidersFactory.DataProviders.Where(i =>
                        dataProvidersFactory.FactoryId == factoryId && i is IAnalogyOfflineDataProviderWinforms).Cast<IAnalogyOfflineDataProviderWinforms>();
                    foreach (var dataSource in supported)
                    {
                        yield return dataSource;
                    }
                }
            }
        }
        public IEnumerable<IAnalogyOfflineDataProviderWinforms> GetSupportedOfflineDataSourcesFromFactory(Guid factoryId,
            string[] fileNames)
        {
            return GetSupportedOfflineDataSources(fileNames).Where(res => res.FactoryID == factoryId)
                .Select(res => res.DataProvider);
        }

        public IEnumerable<(string Name, Guid ID, Image Image, string Description, Assembly Assembly)> GetRealTimeDataSourcesNamesAndIds()
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
                        yield return (dpf.Title, dataSource.Id, GetLargeImage(dataSource.Id), dpf.Title, fc.Assembly);
                    }
                }
            }
        }

        public Assembly GetAssemblyOfFactory(IAnalogyFactory factory)
            => BuiltInFactories.Exists(f => f.Factory == factory)
                ? BuiltInFactories.First(f => f.Factory == factory).Assembly
                : Factories.Single(f => f.Factory == factory).Assembly;

        public FactoryContainer GetBuiltInFactoryContainer(Guid id) =>
            BuiltInFactories.Single(f => f.Factory.FactoryId == id);

        public bool IsBuiltInFactory(IAnalogyFactory factory) => IsBuiltInFactory(factory.FactoryId);

        public bool IsBuiltInFactory(Guid factoryId) =>
            BuiltInFactories.Exists(fc => fc.Factory.FactoryId == factoryId);

        public List<IAnalogyDataProviderSettingsWinforms> GetProvidersSettings() => Factories
            .Where(f => f.FactorySetting.Status != DataProviderFactoryStatus.Disabled)
            .SelectMany(f => f.DataProvidersSettings)
            .ToList();

        public Image? GetLargeImage(Guid componentId)
        {
            foreach (var factoryContainer in Factories.Where(f => f.ContainsDataProviderOrDataFactory(componentId)))
            {
                if (factoryContainer.Factory.FactoryId == componentId)
                {
                    return factoryContainer.Factory.SmallImage;
                }
                foreach (var df in factoryContainer.DataProvidersFactories)
                {
                    foreach (var dp in df.DataProviders)
                    {
                        switch (dp)
                        {
                            case IAnalogyOfflineDataProviderWinforms d when d.Id == componentId:
                                return d.LargeImage;
                            case IAnalogyProviderSidePagingProviderWinforms s when s.Id == componentId:
                                return s.LargeImage;
                            case IAnalogySingleDataProviderWinforms s when s.Id == componentId:
                                return s.LargeImage;
                            case IAnalogySingleFileDataProviderWinforms s when s.Id == componentId:
                                return s.LargeImage;
                        }
                    }
                }
            }
            return null;
        }
        public List<FactoryContainer> GetFactoryContainer(Guid componentId)
            => Factories.Where(f => f.ContainsDataProviderOrDataFactory(componentId)).ToList();

        public Image? GetSmallImage(Guid componentId)
        {
            foreach (var factoryContainer in Factories.Where(f => f.ContainsDataProviderOrDataFactory(componentId)))
            {
                if (factoryContainer.Factory.FactoryId == componentId)
                {
                    return factoryContainer.Factory.SmallImage;
                }
                foreach (var df in factoryContainer.DataProvidersFactories)
                {
                    foreach (var dp in df.DataProviders)
                    {
                        switch (dp)
                        {
                            case IAnalogyOfflineDataProviderWinforms d when d.Id == componentId:
                                return d.SmallImage;
                            case IAnalogyProviderSidePagingProviderWinforms s when s.Id == componentId:
                                return s.SmallImage;
                            case IAnalogySingleDataProviderWinforms s when s.Id == componentId:
                                return s.SmallImage;
                            case IAnalogySingleFileDataProviderWinforms s when s.Id == componentId:
                                return s.SmallImage;
                        }
                    }
                }
            }
            return null;
        }

        public IEnumerable<IAnalogyExtension> GetExtensions(IAnalogyDataProvider dataProvider)
            => GetAllExtensions().Where(e => e.TargetComponentId == dataProvider.Id);

        public IEnumerable<IAnalogyExtension> GetAllExtensions()
        {
            foreach (var factory in Factories)
            {
                if (factory.FactorySetting.Status == DataProviderFactoryStatus.Disabled)
                {
                    continue;
                }

                foreach (var extensionFactory in factory.ExtensionsFactories)
                {
                    foreach (IAnalogyExtension extension in extensionFactory.Extensions)
                    {
                        yield return extension;
                    }
                }
            }
        }
        public IEnumerable<(IAnalogyExtension Extension, Assembly Assembly)> GetAllExtensionsWithAssemblies()
        {
            foreach (var factory in Factories)
            {
                if (factory.FactorySetting.Status == DataProviderFactoryStatus.Disabled)
                {
                    continue;
                }

                foreach (var extensionFactory in factory.ExtensionsFactories)
                {
                    foreach (IAnalogyExtension extension in extensionFactory.Extensions)
                    {
                        yield return (extension, factory.Assembly);
                    }
                }
            }
        }
        public FactoryContainer FactoryContainer(Guid componentId)
            => IsBuiltInFactory(componentId)
                ? BuiltInFactories.FirstOrDefault(f => f.Factory.FactoryId == componentId ||
                                                       f.DataProvidersFactories.Any(dpf =>
                                                           dpf.DataProviders.Any(dp => dp.Id == componentId)))
                : Factories.FirstOrDefault(f => f.Factory.FactoryId == componentId ||
                                                f.DataProvidersFactories.Any(dpf =>
                                                    dpf.DataProviders.Any(dp => dp.Id == componentId)));

        public void ShutDownAllFactories()
        {
            foreach (FactoryContainer factory in Factories)
            {
                foreach (var provider in factory.DataProvidersFactories)
                {
                    var realTimes = provider.DataProviders.Where(f => f is IAnalogyRealTimeDataProvider)
                        .Cast<IAnalogyRealTimeDataProvider>().ToList();
                    foreach (var realTime in realTimes)
                    {
                        try
                        {
                            realTime.ShutDown().Wait(5000);
                        }
                        catch (Exception e)
                        {
                            ServicesProvider.Instance.GetService<ILogger>().LogError($"Error shutdown {realTime.OptionalTitle}", e, provider.Title);
                        }
                    }
                }
            }
        }

        public async Task InitializeIfNeeded(IAnalogyDataProvider dataProvider)
        {
            if (!Initialized.ContainsKey(dataProvider))
            {
                try
                {
                    await dataProvider.InitializeDataProvider(AnalogyLogManager.Instance);
                    Initialized[dataProvider] = true;
                }
                catch (Exception e)
                {
                    AnalogyLogManager.Instance.LogException($"Error Initialize Real time provider: {dataProvider.OptionalTitle}: {e.Message}", e);
                }
            }
        }

        public async Task AddExternalDataSources()
        {
            if (ExternalAdded)
            {
                return;
            }

            ExternalAdded = true;
            #region load assemblies
            var analogyAssemblies = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory,
                @"*Analogy.LogViewer.*.dll", SearchOption.AllDirectories).ToList();
            if (Settings.AdditionalProbingLocations != null)
            {
                foreach (string folder in Settings.AdditionalProbingLocations)
                {
                    try
                    {
                        if (Directory.Exists(folder))
                        {
                            analogyAssemblies.AddRange(Directory.EnumerateFiles(folder, @"*Analogy.LogViewer.*.dll",
                                SearchOption.TopDirectoryOnly).ToList());
                        }
                    }
                    catch (Exception e)
                    {
                        ServicesProvider.Instance.GetService<ILogger>().LogError($"Error probing folder {folder}. Error: {e.Message}", e,
                            nameof(FactoriesManager));
                    }
                }
            }
            #endregion
            #region load types
            var typesToLoad = new List<(Assembly Assembly, string FileName, List<Type> Types)>();
            foreach (string aFile in analogyAssemblies)
            {
                if (aFile.Contains("Analogy.LogViewer.Template"))
                {
                    continue;
                }

                try
                {
                    string fileName = Path.GetFullPath(aFile);
                    string path = Path.GetDirectoryName(aFile);
                    Assembly assembly = Assembly.LoadFrom(fileName);
                    if (!ProbingPaths.Contains(path))
                    {
                        ProbingPaths.Add(path);
                    }

                    var types = assembly.GetTypes().Where(t => !t.IsAbstract).ToList();
                    typesToLoad.Add((assembly, aFile, types));
                }
                catch (Exception e)
                {
                    AnalogyLogManager.Instance.LogError($"{aFile}: Error during data providers: {e} ({e.InnerException}. {aFile})", nameof(FactoriesManager));
                }
            }
            #endregion
            #region Load on demand plot factory
            foreach ((Assembly _, string fileName, List<Type> types) in typesToLoad)
            {
                foreach (var f in types.Where(aType => aType.GetInterface(nameof(IAnalogyOnDemandPlottingFactory)) != null))
                {
                    try
                    {
                        var factory = (Activator.CreateInstance(f) as IAnalogyOnDemandPlottingFactory)!;
                        if (factory.OnDemandPlottingGenerators != null)
                        {
                            foreach (var plotting in factory.OnDemandPlottingGenerators)
                            {
                                PlottingManager.Register(plotting);
                            }
                        }

                        factory.OnAddedOnDemandPlottingGenerator += (s, e) =>
                        {
                            PlottingManager.Register(e);
                        };
                        factory.OnRemovedOnDemandPlottingGenerator += (s, e) =>
                        {
                            PlottingManager.UnRegister(e);
                        };
                    }
                    catch (Exception e)
                    {
                        AnalogyLogManager.Instance.LogError($"{fileName}: Error during on demand plotting: {e} ({e.InnerException}. {fileName})", nameof(FactoriesManager));
                    }
                }
            }
            #endregion
            #region Load Factories
            foreach ((Assembly assembly, string fileName, List<Type> types) in typesToLoad)
            {
                foreach (var f in types.Where(aType => aType.GetInterface(nameof(IAnalogyFactory)) != null))
                {
                    try
                    {
                        var factory = (Activator.CreateInstance(f) as IAnalogyFactoryWinforms)!;
                        await factory.InitializeFactory(FoldersAccess, Logger);
                        var setting = Settings.GetOrAddFactorySetting(factory);
                        setting.FactoryName = factory.Title;
                        FactoryContainer fc = new FactoryContainer(assembly, fileName, factory, setting);
                        if (Factories.Exists(fa => fa.Factory.FactoryId == factory.FactoryId))
                        {
                            var toRemove = Factories.FirstOrDefault(fa => fa.Factory.FactoryId == factory.FactoryId);
                            if (toRemove != null)
                            {
                                Factories.Remove(toRemove);
                            }
                        }

                        if (factory.AdditionalProbingLocation != null)
                        {
                            foreach (var path in factory.AdditionalProbingLocation)
                            {
                                AnalogyNonPersistSettings.Instance.AddDependencyLocation(path);
                            }
                        }
                        factory.RegisterNotificationCallback(NotificationManager);
                        Factories.Add(fc);
                    }
                    catch (Exception e)
                    {
                        AnalogyLogManager.Instance.LogError($"{fileName}: Error during data providers: {e} ({e.InnerException}. {fileName})", nameof(FactoriesManager));
                    }
                }
            }
            #endregion
            foreach ((Assembly assembly, string fileName, List<Type> types) in typesToLoad)
            {
                foreach (Type img in types.Where(aType => aType.GetInterface(nameof(IAnalogyImages)) != null))
                {
                    try
                    {
                        var images = (Activator.CreateInstance(img) as IAnalogyImages)!;
                        var factory = Factories.FirstOrDefault(f => f.Assembly == assembly);
                        factory?.AddImages(images);
                    }
                    catch (Exception e)
                    {
                        AnalogyLogManager.Instance.LogError($"{fileName}: Error during data providers: {e} ({e.InnerException}. {fileName})", nameof(FactoriesManager));
                    }
                }

                foreach (Type dpf in types.Where(aType => aType.GetInterface(nameof(IAnalogyDataProvidersFactory)) != null))
                {
                    try
                    {
                        var dataProviderFactory = (Activator.CreateInstance(dpf) as IAnalogyDataProvidersFactoryWinforms)!;
                        var factory = Factories.First(f => f.Factory.FactoryId == dataProviderFactory?.FactoryId);
                        factory.AddDataProviderFactory(dataProviderFactory);
                    }
                    catch (Exception e)
                    {
                        AnalogyLogManager.Instance.LogError(
                            $"{fileName}: Error during data providers: {e} ({e.InnerException}. {fileName})",
                            nameof(FactoriesManager));
                    }
                }

                foreach (Type isettings in types.Where(aType => aType.GetInterface(nameof(IAnalogyDataProviderSettings)) != null))
                {
                    try
                    {
                        var settings = (Activator.CreateInstance(isettings) as IAnalogyDataProviderSettingsWinforms)!;
                        var factory = Factories.First(f => f.Factory.FactoryId == settings?.FactoryId);
                        factory.AddDataProvidersSettings(settings);
                    }
                    catch (Exception e)
                    {
                        AnalogyLogManager.Instance.LogError($"{fileName}: Error during data providers: {e} ({e.InnerException}. {fileName})", nameof(FactoriesManager));
                    }
                }

                foreach (Type iaction in types.Where(aType => aType.GetInterface(nameof(IAnalogyCustomActionsFactory)) != null))
                {
                    try
                    {
                        var custom = (Activator.CreateInstance(iaction) as IAnalogyCustomActionsFactoryWinforms)!;
                        var factory = Factories.First(f => f.Factory.FactoryId == custom?.FactoryId);
                        factory.AddCustomActionFactory(custom);
                    }
                    catch (Exception e)
                    {
                        AnalogyLogManager.Instance.LogError($"{fileName}: Error during data providers: {e} ({e.InnerException}. {fileName})", nameof(FactoriesManager));
                    }
                }

                foreach (Type ishare in types.Where(aType => aType.GetInterface(nameof(IAnalogyShareableFactory)) != null))
                {
                    try
                    {
                        var share = (Activator.CreateInstance(ishare) as IAnalogyShareableFactory)!;
                        var factory = Factories.First(f => f.Factory.FactoryId == share?.FactoryId);
                        factory.AddShareableFactory(share);
                    }
                    catch (Exception e)
                    {
                        AnalogyLogManager.Instance.LogError($"{fileName}: Error during data providers: {e} ({e.InnerException}. {fileName})", nameof(FactoriesManager));
                    }
                }

                foreach (Type aType in types.Where(aType => aType.GetInterface(nameof(IAnalogyExtensionsFactory)) != null))
                {
                    try
                    {
                        var extension = (Activator.CreateInstance(aType) as IAnalogyExtensionsFactory)!;
                        var factory = Factories.First(f => f.Factory.FactoryId == extension?.FactoryId);
                        factory.AddExtensionFactory(extension);
                    }
                    catch (Exception e)
                    {
                        AnalogyLogManager.Instance.LogError($"{fileName}: Error during data providers: {e} ({e.InnerException}. {fileName})", nameof(FactoriesManager));
                    }
                }

                foreach (Type aType in types.Where(aType => aType.GetInterface(nameof(IAnalogyDownloadInformation)) != null))
                {
                    try
                    {
                        var downloadInfo = (Activator.CreateInstance(aType) as IAnalogyDownloadInformation)!;
                        var factory = Factories.First(f => f.Factory.FactoryId == downloadInfo?.FactoryId);
                        factory.AddDownloadInformation(downloadInfo);
                    }
                    catch (Exception e)
                    {
                        AnalogyLogManager.Instance.LogError($"{fileName}: Error during data providers: {e} ({e.InnerException}. {fileName})", nameof(FactoriesManager));
                    }
                }

                foreach (Type plotter in types.Where(aType => aType.GetInterface(nameof(IAnalogyPlotting)) != null))
                {
                    try
                    {
                        var plot = (Activator.CreateInstance(plotter) as IAnalogyPlotting)!;
                        var factory = Factories.First(f => f.Factory.FactoryId == plot.FactoryId);
                        factory.AddGraphPlotter(plot);
                    }
                    catch (Exception e)
                    {
                        AnalogyLogManager.Instance.LogError($"{fileName}: Error during plotter loading: {e} ({e.InnerException}. {fileName})", nameof(FactoriesManager));
                    }
                }

                foreach (Type policyType in types.Where(aType => aType.GetInterface(nameof(IAnalogyPolicyEnforcer)) != null))
                {
                    try
                    {
                        var policy = (Activator.CreateInstance(policyType) as IAnalogyPolicyEnforcer)!;
                        if (policy.DisableUpdates)
                        {
                            ServicesProvider.Instance.GetService<ILogger>().LogWarning($"disable Update by: {policyType.FullName}");
                            AnalogyNonPersistSettings.Instance.DisableUpdatesByDataProvidersOverrides = true;
                        }
                    }
                    catch (Exception e)
                    {
                        AnalogyLogManager.Instance.LogError($"{fileName}: Error during plotter loading: {e} ({e.InnerException}. {fileName})", nameof(FactoriesManager));
                    }
                }

                foreach (Type uc in types.Where(aType => aType.GetInterface(nameof(IAnalogyCustomUserControlsFactoryWinforms)) != null))
                {
                    try
                    {
                        var auf = (Activator.CreateInstance(uc) as IAnalogyCustomUserControlsFactoryWinforms)!;
                        var factory = Factories.First(f => f.Factory.FactoryId == auf?.FactoryId);
                        factory.AddCustomUserControlFactory(auf);
                    }
                    catch (Exception e)
                    {
                        AnalogyLogManager.Instance.LogError($"{fileName}: Error during adding user control factory: {e} ({e.InnerException}. {fileName})", nameof(FactoriesManager));
                    }
                }
            }

            //Factories.RemoveAll(f => f.FactorySetting.Status == DataProviderFactoryStatus.Disabled);
        }
        public IEnumerable<IAnalogyOfflineDataProviderWinforms> GetAllOfflineDataSources(IEnumerable<Guid> dataProviders)
        {
            foreach (var fc in Factories)
            {
                if (fc.FactorySetting.Status == DataProviderFactoryStatus.Disabled)
                {
                    continue;
                }
                foreach (var dpf in fc.DataProvidersFactories)
                {
                    IEnumerable<IAnalogyOfflineDataProviderWinforms> supported =
                        dpf.DataProviders.Where(d => d is IAnalogyOfflineDataProviderWinforms).Cast<IAnalogyOfflineDataProviderWinforms>();
                    foreach (var analogyDataSource in supported)
                    {
                        if (dataProviders.Any(dp => dp == analogyDataSource.Id))
                        {
                            yield return analogyDataSource;
                        }
                    }
                }
            }
        }
    }
}