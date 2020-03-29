using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Analogy.DataProviders.Extensions;
using Analogy.Interfaces.Factories;

namespace Analogy.Managers
{
    public class FactoryContainer
    {
        public Assembly Assembly { get; }
        public List<IAnalogyFactory> Factories { get; }

        public List<IAnalogyFactory> EnabledFactories =>
            Factories.Where(factory =>
                FactorySettings.Exists(item => item.FactoryGuid == factory.FactoryId) &&
                FactorySettings.Single(item => item.FactoryGuid == factory.FactoryId).Status !=
                Types.DataProviderFactoryStatus.Disabled).ToList();

        public List<IAnalogyCustomActionsFactory> CustomActionsFactories { get; }
       public List<IAnalogyDataProvidersFactory> DataProvidersFactories { get; }
       public List<IAnalogyDataProviderSettings> DataProvidersSettings { get;}
        public List<IAnalogyShareableFactory> ShareableFactories{ get; }
        public List<FactorySettings> FactorySettings { get; }

        public IEnumerable<IAnalogyDataProvidersFactory> EnabledDataProvidersFactories => DataProvidersFactories.Where(
            d => FactorySettings.Exists(f => f.FactoryGuid == d.FactoryId) &&
                 FactorySettings.Single(f => f.FactoryGuid == d.FactoryId).Status !=
                 Types.DataProviderFactoryStatus.Disabled);

        public FactoryContainer(Assembly assembly)
        {
            Assembly = assembly;
            Factories = new List<IAnalogyFactory>();
            DataProvidersFactories = new List<IAnalogyDataProvidersFactory>();
            DataProvidersSettings = new List<IAnalogyDataProviderSettings>();
            CustomActionsFactories = new List<IAnalogyCustomActionsFactory>();
            ShareableFactories = new List<IAnalogyShareableFactory>();
            FactorySettings = new List<FactorySettings>();
        }

        public void AddFactory(IAnalogyFactory factory) => Factories.Add(factory);
        public void AddDataProviderFactory(IAnalogyDataProvidersFactory factory) => DataProvidersFactories.Add(factory);
        public void AddDataProvidersSettings(IAnalogyDataProviderSettings settings) => DataProvidersSettings.Add(settings);
        public void AddCustomActionFactory(IAnalogyCustomActionsFactory factory) => CustomActionsFactories.Add(factory);
        public void AddShareableFactory(IAnalogyShareableFactory factory) => ShareableFactories.Add(factory);
        public void AddFactorySettings(FactorySettings factory) => FactorySettings.Add(factory);

        public bool FactoryDisabled(IAnalogyFactory factory) =>
            FactorySettings.Exists(item => item.FactoryGuid == factory.FactoryId) &&
            FactorySettings.Single(item => item.FactoryGuid == factory.FactoryId).Status ==
            Types.DataProviderFactoryStatus.Disabled;
    }
}
