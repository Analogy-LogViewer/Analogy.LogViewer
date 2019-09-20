using Philips.Analogy.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Philips.Analogy.DataSources;

namespace Philips.Analogy
{
    public class AnalogyFactoriesManager
    {
        private static Lazy<AnalogyFactoriesManager>
            _instance = new Lazy<AnalogyFactoriesManager>(() => new AnalogyFactoriesManager());
        public static AnalogyFactoriesManager AnalogyFactories { get; } = _instance.Value;
        public List<(IAnalogyFactories Factory, Assembly Assembly)> Assemblies { get; private set; }

        private List<IAnalogyFactories> Factories { get; }
        public AnalogyFactoriesManager()
        {
            Factories = new List<IAnalogyFactories>();
            Assemblies = new List<(IAnalogyFactories Factory, Assembly Assembly)>();
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
                            if (aType.GetInterface(nameof(IAnalogyFactories)) != null)
                            {
                                IAnalogyFactories factory = Activator.CreateInstance(aType) as IAnalogyFactories;
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

        public IEnumerable<(string Title, (string Title, IEnumerable<IAnalogyDataSource> Items) DataSources)> GetDataSource()
        {
            foreach (var factory in Factories)
            {
                var title = factory.DataSources != null ? factory.DataSources.Title : "None";
                var items = factory.DataSources?.Items ?? new List<IAnalogyDataSource>();
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
        public IEnumerable<(string Title, (string Title, IEnumerable<IAnalogyUserControl> Items) UserControls)> GetUserControls()
        {
            foreach (var factory in Factories)
            {
                var title = factory.UserControls != null ? factory.UserControls.Title : "None";
                var items = factory.UserControls?.Items ?? new List<IAnalogyUserControl>();
                yield return (factory.Title, (title, items));
            }
        }

        public List<IAnalogyFactories> GetFactories() => Factories.ToList();

        public IEnumerable<IAnalogyOfflineDataSource> GetSupportedOfflineDataSources(string[] fileNames)
        {
            foreach (var factory in Factories)
            {
                var supported = factory.DataSources.Items.Where(i => i is IAnalogyOfflineDataSource offline && offline.CanOpenAllFiles(fileNames));
                foreach (IAnalogyDataSource dataSource in supported)
                {
                    yield return dataSource as IAnalogyOfflineDataSource;
                }
            }
        }

        public Assembly GetAssemblyOfFactory(IAnalogyFactories factory) => Assemblies.Single(f => f.Factory == factory).Assembly;

        public IAnalogyFactories Get(Guid Id) => Assemblies.Single(a => a.Factory.FactoryID == Id).Factory;
    }
}
