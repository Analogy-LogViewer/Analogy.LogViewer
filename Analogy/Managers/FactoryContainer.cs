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
       public List<IAnalogyCustomActionsFactory> CustomActionsFactories { get; }
       public List<IAnalogyDataProvidersFactory> DataProvidersFactories { get; }
       public List<IAnalogyDataProviderSettings> DataProvidersSettings { get;}
        public List<IAnalogyShareableFactory> ShareableFactories{ get; }
        public FactoryContainer(Assembly assembly)
        {
            Assembly = assembly;
            Factories=new List<IAnalogyFactory>();
            DataProvidersFactories=new List<IAnalogyDataProvidersFactory>();
            DataProvidersSettings=new List<IAnalogyDataProviderSettings>();
            CustomActionsFactories=new List<IAnalogyCustomActionsFactory>();
            ShareableFactories=new List<IAnalogyShareableFactory>();
        }

        public void AddFactory(IAnalogyFactory factory) => Factories.Add(factory);
        public void AddDataProviderFactory(IAnalogyDataProvidersFactory factory) => DataProvidersFactories.Add(factory);
        public void AddDataProvidersSettings(IAnalogyDataProviderSettings settings) => DataProvidersSettings.Add(settings);
        public void AddCustomActionFactory(IAnalogyCustomActionsFactory factory) => CustomActionsFactories.Add(factory);
        public void AddShareableFactory(IAnalogyShareableFactory factory) => ShareableFactories.Add(factory);

    }
}
