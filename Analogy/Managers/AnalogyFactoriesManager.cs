using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Analogy.DataProviders;
using Analogy.DataProviders.Extensions;
using Analogy.DataSources;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.NLogProvider;
using Analogy.Types;

namespace Analogy
{
    public class AnalogyFactoriesManager
    {

        private static readonly Lazy<AnalogyFactoriesManager>
            _instance = new Lazy<AnalogyFactoriesManager>(() => new AnalogyFactoriesManager());
        private static object sync = new object();
        private bool ExternalDataSourcesAdded { get; set; }
        public static AnalogyFactoriesManager Instance = _instance.Value;
        private List<IAnalogyFactory> builtInFactories { get; }
        private List<(Guid FacyoryID, IAnalogyDataProviderSetting Settings)> Settings { get;  set; }
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
                var distinctFactory = result.Factories.Where(f => !Instance.Factories.Contains(f)).ToList();
                Instance.Factories.AddRange(distinctFactory);
                var distinctAssemblies = result.Assemblies.Where(a => !Instance.Assemblies.Contains(a)).ToList();
                Instance.Assemblies.AddRange(distinctAssemblies);
                ExternalDataSourcesAdded = true;
            }
        }


        public List<(IAnalogyFactory Factory, Assembly Assembly)> Assemblies { get; private set; }

        private List<IAnalogyFactory> Factories { get; }

        public AnalogyFactoriesManager()
        {
            Settings=new List<(Guid FacyoryID, IAnalogyDataProviderSetting Settings)>();
            Settings.Add((NLogBuiltInFactory.AnalogyNLogGuid,new AnalogyNLogSettings()));
            Factories = new List<IAnalogyFactory>();
            Assemblies = new List<(IAnalogyFactory Factory, Assembly Assembly)>
            {
                (new AnalogyBuiltInFactory(), Assembly.GetExecutingAssembly()),
                (new NLogBuiltInFactory(), Assembly.GetAssembly(typeof(NLogBuiltInFactory)))
            };
            builtInFactories=new List<IAnalogyFactory>();
            try
            {
                foreach ((IAnalogyFactory factory, _) in Assemblies)
                {
                    foreach (var provider in factory.DataProviders.Items)
                    {
                        provider.InitDataProvider();
                    }
                    //if no exception in init then add to list
                    Factories.Add(factory);
                    builtInFactories .Add(factory);

                }
            }
            catch (Exception e)
            {

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

        public IEnumerable<IAnalogyOfflineDataProvider> GetSupportedOfflineDataSources(string[] fileNames)
        {
            foreach (var factory in Factories)
            {
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

        public bool IsBuiltInFactory(IAnalogyFactory factory)
        {
            return builtInFactories.Exists(f => f.FactoryID.Equals(factory.FactoryID));
        }
    }

    public class ExternalDataProviders
    {
        private static readonly AsyncLazy<ExternalDataProviders> _instance = new AsyncLazy<ExternalDataProviders>(() => new ExternalDataProviders());

        public static async Task<ExternalDataProviders> GetExternalDataProviders() => await _instance.Start();


        public List<(IAnalogyFactory Factory, Assembly Assembly)> Assemblies { get; private set; }

        public List<IAnalogyFactory> Factories { get; }

        public ExternalDataProviders()
        {
            Factories = new List<IAnalogyFactory>();
            Assemblies = new List<(IAnalogyFactory Factory, Assembly Assembly)>();

            string[] moduleIdFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory,
                @"*Analogy.Implementation.*.dll", SearchOption.TopDirectoryOnly);
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

                                foreach (var provider in factory.DataProviders.Items)
                                {
                                    provider.InitDataProvider();
                                }

                                //if no exception in init then add to list
                                Factories.Add(factory);
                                Assemblies.Add((factory, assembly));

                            }
                        }
                        catch (Exception)
                        {
                            //nothing
                        }

                    }
                }
                catch (Exception)
                {
                    //nothing
                }
            }
        }

    }
}
