using Analogy.DataProviders.Extensions;
using Analogy.Interfaces.Factories;
using System.Collections.Generic;
using System.Reflection;

namespace Analogy.Managers
{
    public class FactoryContainer
    {
        public Assembly Assembly { get; }
        public IAnalogyFactory Factory { get; }
        public FactorySettings FactorySetting { get; }
        public List<IAnalogyCustomActionsFactory> CustomActionsFactories { get; }
        public List<IAnalogyDataProvidersFactory> DataProvidersFactories { get; }
        public List<IAnalogyDataProviderSettings> DataProvidersSettings { get; }
        public List<IAnalogyShareableFactory> ShareableFactories { get; }
        public List<IAnalogyExtensionsFactory> ExtensionsFactories { get; }

        public FactoryContainer(Assembly assembly, IAnalogyFactory factory, FactorySettings factorySetting)
        {
            Assembly = assembly;
            Factory = factory;
            FactorySetting = factorySetting;
            CustomActionsFactories = new List<IAnalogyCustomActionsFactory>();
            DataProvidersFactories = new List<IAnalogyDataProvidersFactory>();
            DataProvidersSettings = new List<IAnalogyDataProviderSettings>();
            ShareableFactories = new List<IAnalogyShareableFactory>();
            ExtensionsFactories = new List<IAnalogyExtensionsFactory>();

        }


        public void AddDataProviderFactory(IAnalogyDataProvidersFactory dataProvidersFactory) =>
            DataProvidersFactories.Add(dataProvidersFactory);

        public void AddDataProvidersSettings(IAnalogyDataProviderSettings settings) =>
            DataProvidersSettings.Add(settings);

        public void AddCustomActionFactory(IAnalogyCustomActionsFactory action) => CustomActionsFactories.Add(action);

        public void AddShareableFactory(IAnalogyShareableFactory shareableFactory) =>
            ShareableFactories.Add(shareableFactory);
        public void AddExtensionFactory(IAnalogyExtensionsFactory extensionFactory) =>
            ExtensionsFactories.Add(extensionFactory);
        public override string ToString() => $"{nameof(Factory)}: {Factory}, {nameof(Assembly)}: {Assembly}";
    }
}
