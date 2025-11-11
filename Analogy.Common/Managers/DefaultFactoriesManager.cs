using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.Common.Properties;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.Interfaces.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Common.Managers
{
    public class DefaultFactoriesManager : IFactoriesManager
    {
        public List<string> ProbingPaths { get; set; } = new List<string>(0);
        public List<FactoryContainer> BuiltInFactories { get; } = new List<FactoryContainer>(0);
        public List<FactoryContainer> Factories { get; } = new List<FactoryContainer>(0);
        public List<IRawSQLInteractor> RawSQLManipulators { get; } = new List<IRawSQLInteractor>(0);
        public Task InitializeBuiltInFactories() => Task.CompletedTask;

        public Task AddExternalDataSources() => Task.CompletedTask;

        public IEnumerable<(IAnalogyOfflineDataProviderWinForms DataProvider, Guid FactoryID)> GetSupportedOfflineDataSources(string[] fileNames)
        {
            return new List<(IAnalogyOfflineDataProviderWinForms DataProvider, Guid FactoryID)>(0);
        }

        public IEnumerable<IAnalogyOfflineDataProviderWinForms> GetSupportedOfflineDataSourcesFromFactory(Guid factoryId, string[] fileNames)
        {
            return new List<IAnalogyOfflineDataProviderWinForms>(0);
        }

        public IEnumerable<IAnalogyOfflineDataProviderWinForms> GetOfflineDataSources(Guid factoryId)
        {
            return new List<IAnalogyOfflineDataProviderWinForms>(0);
        }

        public IEnumerable<(string Name, Guid ID, Image Image, string Description, Assembly Assembly)> GetRealTimeDataSourcesNamesAndIds()
        {
            return new List<(string Name, Guid ID, Image Image, string Description, Assembly Assembly)>(0);
        }

        public Assembly GetAssemblyOfFactory(IAnalogyFactory factory)
        {
            return null;
        }

        public FactoryContainer GetBuiltInFactoryContainer(Guid id)
        {
            return null;
        }

        public bool IsBuiltInFactory(IAnalogyFactory factory)
        {
            return false;
        }

        public bool IsBuiltInFactory(Guid factoryId)
        {
            return false;
        }

        public List<IAnalogyDataProviderSettingsWinForms> GetProvidersSettings()
        {
            return [];
        }

        public Image GetLargeImage(Guid componentId)
        {
            return Resources.Analogy_image_32x32;
        }

        public List<FactoryContainer> GetFactoryContainer(Guid componentId)
        {
            return new List<FactoryContainer>();
        }

        public Image? GetSmallImage(Guid componentId)
        {
            return Resources.Analogy_image_16x16;
        }

        public IEnumerable<IAnalogyExtension> GetExtensions(IAnalogyDataProvider dataProvider)
        {
            return new List<IAnalogyExtension>(0);
        }

        public IEnumerable<IAnalogyExtension> GetAllExtensions()
        {
            return new List<IAnalogyExtension>(0);
        }

        public FactoryContainer FactoryContainer(Guid componentId)
        {
            return null;
        }

        public IEnumerable<(IAnalogyExtension Extension, Assembly Assembly)> GetAllExtensionsWithAssemblies()
        {
            return Enumerable.Empty<(IAnalogyExtension Extension, Assembly Assembly)>();
        }

        public void ShutDownAllFactories()
        {
        }

        public Task InitializeIfNeeded(IAnalogyDataProvider dataProvider)
        {
            return Task.CompletedTask;
        }

        public IEnumerable<IAnalogyOfflineDataProviderWinForms> GetAllOfflineDataSources(IEnumerable<Guid> dataProviders)
        {
            return [];
        }
    }
}