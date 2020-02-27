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
        private bool ExternalDataSourcesAdded { get; set; }
        public static FactoriesManager Instance = _instance.Value;
        private List<IAnalogyFactory> BuiltInFactories { get; }
        private List<IAnalogyDataProviderSettings> DataProvidersSettings { get; set; }

        public List<(IAnalogyFactory Factory, Assembly Assembly)> Assemblies { get; private set; }

        private List<IAnalogyFactory> Factories { get; }

        public FactoriesManager()
        {
            DataProvidersSettings = new List<IAnalogyDataProviderSettings>();
            Factories = new List<IAnalogyFactory>();
            Assemblies = new List<(IAnalogyFactory Factory, Assembly Assembly)>
            {
                (new AnalogyBuiltInFactory(), Assembly.GetExecutingAssembly()),
                (new EventLogDataFactory(), Assembly.GetAssembly(typeof(EventLogDataFactory)))
            };
            BuiltInFactories = new List<IAnalogyFactory>();
            try
            {
                foreach ((IAnalogyFactory factory, _) in Assemblies)
                {
                    FactorySettings setting = UserSettingsManager.UserSettings.GetOrAddFactorySetting(factory);
                    setting.FactoryName = factory.Title;
                    if (setting.Status == DataProviderFactoryStatus.Disabled) continue;
                    foreach (var provider in factory.DataProviders.Items)
                    {
                        provider.InitializeDataProviderAsync(AnalogyLogger.Intance);
                    }
                    //if no exception in init then add to list
                    Factories.Add(factory);
                    BuiltInFactories.Add(factory);

                }
            }
            catch (Exception e)
            {
                AnalogyLogManager.Instance.LogError("Error during data providers: " + e, nameof(FactoriesManager));
            }

        }

        public async Task AddExternalDataSources()
        {
            if (ExternalDataSourcesAdded)
                return;
            ExternalDataProviders result = await ExternalDataProviders.GetExternalDataProviders();
            if (ExternalDataSourcesAdded)
                return;
            lock (sync)
            {
                if (ExternalDataSourcesAdded)
                    return;
                var distinctFactory = result.Factories.Where(f => !Factories.Contains(f)).ToList();
                Factories.AddRange(distinctFactory);
                var distinctAssemblies = result.Assemblies.Where(a => !Assemblies.Contains(a)).ToList();
                Assemblies.AddRange(distinctAssemblies);
                ExternalDataSourcesAdded = true;
                DataProvidersSettings.AddRange(result.DataProviderSettings);
            }
        }
        public IEnumerable<(string Title, (string Title, IEnumerable<IAnalogyDataProvider> Items) DataSources)>
            GetDataSource()
        {
            foreach (var factory in Factories)
            {
                var title = factory.DataProviders != null ? factory.DataProviders.Title : "None";
                var items = factory.DataProviders?.Items ?? new List<IAnalogyDataProvider>();
                yield return (factory.Title, (title, items));
            }
        }

        public IEnumerable<(string Title, (string Title, IEnumerable<IAnalogyCustomAction> Items) Actions)>
            GetCustomActions()
        {
            foreach (var factory in Factories)
            {
                var title = factory.Actions != null ? factory.Actions.Title : "None";
                var items = factory.Actions?.Items ?? new List<IAnalogyCustomAction>();
                yield return (factory.Title, (title, items));
            }
        }

        public List<IAnalogyFactory> GetFactories() => Factories.ToList();

        public IEnumerable<(IAnalogyOfflineDataProvider DataProvider, Guid FactoryID)> GetSupportedOfflineDataSources(string[] fileNames)
        {
            foreach (var factory in Factories)
            {
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
            Assemblies.Single(f => f.Factory == factory).Assembly;

        public IAnalogyFactory Get(Guid id) => Assemblies.Single(a => a.Factory.FactoryID == id).Factory;

        public bool IsBuiltInFactory(IAnalogyFactory factory) => IsBuiltInFactory(factory.FactoryID);

        public bool IsBuiltInFactory(Guid factoryId) => BuiltInFactories.Exists(f => f.FactoryID.Equals(factoryId));
        public List<IAnalogyDataProviderSettings> GetProvidersSettings() => DataProvidersSettings.ToList();


    }

    public class ExternalDataProviders
    {
        private static readonly AsyncLazy<ExternalDataProviders> _instance = new AsyncLazy<ExternalDataProviders>(() => new ExternalDataProviders());

        public static async Task<ExternalDataProviders> GetExternalDataProviders() => await _instance.Start();


        public List<(IAnalogyFactory Factory, Assembly Assembly)> Assemblies { get; }

        public List<IAnalogyFactory> Factories { get; }
        public List<IAnalogyDataProviderSettings> DataProviderSettings { get; }

        public ExternalDataProviders()
        {

            Factories = new List<IAnalogyFactory>();
            Assemblies = new List<(IAnalogyFactory Factory, Assembly Assembly)>();
            DataProviderSettings = new List<IAnalogyDataProviderSettings>();

            string[] moduleIdFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory,
                @"*Analogy.Implementation.*.dll", SearchOption.TopDirectoryOnly).Union(
                Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory,
                    @"*Analogy.LogViewer.*.dll", SearchOption.TopDirectoryOnly)).ToArray();
            foreach (string aFile in moduleIdFiles)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFile(Path.GetFullPath(aFile));
                    Type[] types = assembly.GetTypes();
                    foreach (Type aType in types)
                    {
                        try
                        {
                            if (aType.GetInterface(nameof(IAnalogyFactory)) != null)
                            {
                                if (!(Activator.CreateInstance(aType) is IAnalogyFactory factory)) continue;
                                FactorySettings setting =
                                    UserSettingsManager.UserSettings.GetOrAddFactorySetting(factory);
                                setting.FactoryName = factory.Title;
                                if (setting.Status == DataProviderFactoryStatus.Disabled) continue;
                                foreach (var provider in factory.DataProviders.Items)
                                {
                                    provider.InitializeDataProviderAsync(AnalogyLogger.Intance);
                                }

                                //if no exception in init then add to list
                                Factories.Add(factory);
                                Assemblies.Add((factory, assembly));

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
