using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Philips.Analogy.DataSources;
using Philips.Analogy.Interfaces;
using Philips.Analogy.Interfaces.Factories;

namespace Philips.Analogy
{
    public class AnalogyFactoriesManager
    {
        private static Lazy<AnalogyFactoriesManager>
            _instance = new Lazy<AnalogyFactoriesManager>(() => new AnalogyFactoriesManager());
        public static AnalogyFactoriesManager AnalogyFactories { get; } = _instance.Value;
        public List<(IAnalogyFactory Factory, Assembly Assembly)> Assemblies { get; private set; }

        private List<IAnalogyFactory> Factories { get; }
        public AnalogyFactoriesManager()
        {
            Factories = new List<IAnalogyFactory>();
            Assemblies = new List<(IAnalogyFactory Factory, Assembly Assembly)>();
            Assemblies.Add((new AnalogyBuiltInFactory(),Assembly.GetExecutingAssembly()));
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
                                IAnalogyFactory factory = Activator.CreateInstance(aType) as IAnalogyFactory;
                                Factories.Add(factory);
                                Assemblies.Add((factory,assembly));
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

        public IEnumerable<(string Title, (string Title, IEnumerable<IAnalogyDataProvider> Items) DataSources)> GetDataSource()
        {
            foreach (var factory in Factories)
            {
                var title = factory.DataProviders != null ? factory.DataProviders.Title : "None";
                var items = factory.DataProviders?.Items ?? new List<IAnalogyDataProvider>();
                yield return (factory.Title, (title, items));
            }
        }
        public IEnumerable<(string Title, (string Title, IEnumerable<IAnalogyCustomAction> Items) Actions)> GetCustomActions()
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
                var supported = factory.DataProviders.Items.Where(i => i is IAnalogyOfflineDataProvider offline && offline.CanOpenAllFiles(fileNames));
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
                IEnumerable<IAnalogyDataProvider> supported = factory.DataProviders.Items.Where(i => i is IAnalogyRealTimeDataProvider);
                foreach (var analogyDataSource in supported)
                {
                    var dataSource = (IAnalogyRealTimeDataProvider) analogyDataSource;
                    yield return (factory.Title,dataSource.ID);
                }
            }
        }

        public Assembly GetAssemblyOfFactory(IAnalogyFactory factory) => Assemblies.Single(f => f.Factory == factory).Assembly;

        public IAnalogyFactory Get(Guid id) => Assemblies.Single(a => a.Factory.FactoryID == id).Factory;
    }
}
