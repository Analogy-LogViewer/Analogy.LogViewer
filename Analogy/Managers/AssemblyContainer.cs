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
    //public class AssemblyContainer
    //{
    //    public Assembly Assembly { get; }
    //    public List<FactoryContainer> Factories { get; }
    //    public AssemblyContainer(Assembly assembly)
    //    {
    //        Assembly = assembly;
    //        Providers = new List<IAnalogyFactory>();
    //       Factories=new List<FactoryContainer>();
    //    }

    //    private IAnalogyFactory GetFactoryById(Guid id) => Providers.Single(f => f.FactoryId == id);
    //    private FactorySettings GetFactorySettingsById(Guid id) => Factories.Single(f => f.FactorySetting.FactoryId == id).FactorySetting;
    //    public void AddFactory(IAnalogyFactory factory,FactorySettings settings)
    //    {
    //        Factories.Add(factory);
    //        FactorySettings.Add(settings);
    //    }

    //    public void AddDataProviderFactory(IAnalogyDataProvidersFactory dataProvidersFactory)
    //    {
    //        DataProvidersFactories.Add(new ProviderContainer<IAnalogyDataProvidersFactory>(Assembly,
    //            GetFactoryById(dataProvidersFactory.FactoryId), GetFactorySettingsById(dataProvidersFactory.FactoryId),
    //            dataProvidersFactory));
    //    }

    //    public void AddDataProvidersSettings(IAnalogyDataProviderSettings settings)
    //    {
    //        DataProvidersSettings.Add(new ProviderContainer<IAnalogyDataProviderSettings>(Assembly,
    //            GetFactoryById(settings.FactoryId), GetFactorySettingsById(settings.FactoryId),
    //            settings));
    //    }

    //    public void AddCustomActionFactory(IAnalogyCustomActionsFactory action)
    //    {
    //        CustomActionsFactories.Add(new ProviderContainer<IAnalogyCustomActionsFactory>(Assembly,
    //            GetFactoryById(action.FactoryId), GetFactorySettingsById(action.FactoryId),
    //            action));
    //    }

    //    public void AddShareableFactory(IAnalogyShareableFactory shareableFactory)
    //    {
    //        ShareableFactories.Add(new ProviderContainer<IAnalogyShareableFactory>(Assembly,
    //            GetFactoryById(shareableFactory.FactoryId), GetFactorySettingsById(shareableFactory.FactoryId),
    //            shareableFactory));
    //    }


    //    public bool FactoryDisabled(IAnalogyFactory factory) =>
    //        FactorySettings.Exists(item => item.FactoryId == factory.FactoryId) &&
    //        FactorySettings.Single(item => item.FactoryId == factory.FactoryId).Status ==
    //        Types.DataProviderFactoryStatus.Disabled;
    //}
}
