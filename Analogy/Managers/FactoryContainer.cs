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
        public List<ProviderContainer<IAnalogyCustomActionsFactory>> CustomActionsFactories { get; }
        public List<ProviderContainer<IAnalogyDataProvidersFactory>> DataProvidersFactories { get; }
        public List<ProviderContainer<IAnalogyDataProviderSettings>> DataProvidersSettings { get; }
        public List<ProviderContainer<IAnalogyShareableFactory>> ShareableFactories { get; }

        public List<FactorySettings> FactorySettings { get; }
       //public IEnumerable<IAnalogyDataProvidersFactory> EnabledDataProvidersFactories => DataProvidersFactories.Where(
        //    d => FactorySettings.Exists(f => f.FactoryId == d.FactoryId) &&
        //         FactorySettings.Single(f => f.FactoryId == d.FactoryId).Status !=
        //         Types.DataProviderFactoryStatus.Disabled);

        public FactoryContainer(Assembly assembly)
        {
            Assembly = assembly;
            DataProvidersFactories = new List<ProviderContainer<IAnalogyDataProvidersFactory>>();
            DataProvidersSettings = new List<ProviderContainer<IAnalogyDataProviderSettings>>();
            CustomActionsFactories = new List<ProviderContainer<IAnalogyCustomActionsFactory>>();
            ShareableFactories = new List<ProviderContainer<IAnalogyShareableFactory>>();
            Factories=new List<IAnalogyFactory>();
            FactorySettings=new List<FactorySettings>();
        }

        private IAnalogyFactory GetFactoryById(Guid id) => Factories.Single(f => f.FactoryId == id);
        private FactorySettings GetFactorySettingsById(Guid id) => FactorySettings.Single(f => f.FactoryId == id);
        public void AddFactory(IAnalogyFactory factory,FactorySettings settings)
        {
            Factories.Add(factory);
            FactorySettings.Add(settings);
        }

        public void AddDataProviderFactory(IAnalogyDataProvidersFactory dataProvidersFactory)
        {
            DataProvidersFactories.Add(new ProviderContainer<IAnalogyDataProvidersFactory>(Assembly,
                GetFactoryById(dataProvidersFactory.FactoryId), GetFactorySettingsById(dataProvidersFactory.FactoryId),
                dataProvidersFactory));
        }

        public void AddDataProvidersSettings(IAnalogyDataProviderSettings settings)
        {
            DataProvidersSettings.Add(new ProviderContainer<IAnalogyDataProviderSettings>(Assembly,
                GetFactoryById(settings.FactoryId), GetFactorySettingsById(settings.FactoryId),
                settings));
        }

        public void AddCustomActionFactory(IAnalogyCustomActionsFactory action)
        {
            CustomActionsFactories.Add(new ProviderContainer<IAnalogyCustomActionsFactory>(Assembly,
                GetFactoryById(action.FactoryId), GetFactorySettingsById(action.FactoryId),
                action));
        }

        public void AddShareableFactory(IAnalogyShareableFactory shareableFactory)
        {
            ShareableFactories.Add(new ProviderContainer<IAnalogyShareableFactory>(Assembly,
                GetFactoryById(shareableFactory.FactoryId), GetFactorySettingsById(shareableFactory.FactoryId),
                shareableFactory));
        }


        public bool FactoryDisabled(IAnalogyFactory factory) =>
            FactorySettings.Exists(item => item.FactoryId == factory.FactoryId) &&
            FactorySettings.Single(item => item.FactoryId == factory.FactoryId).Status ==
            Types.DataProviderFactoryStatus.Disabled;
    }
}
