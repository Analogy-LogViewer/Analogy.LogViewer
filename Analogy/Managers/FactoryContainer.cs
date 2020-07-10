using Analogy.DataProviders.Extensions;
using Analogy.Interfaces.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<IAnalogyComponentImages> DataProviderImages { get; private set; }

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
            DataProviderImages = new List<IAnalogyComponentImages>();

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

        public void AddImages(IAnalogyComponentImages images) => DataProviderImages.Add(images);
        public override string ToString() => $"{nameof(Factory)}: {Factory}, {nameof(Assembly)}: {Assembly}";

        public bool ContainsDataProviderOrDataFactory(Guid componentId)
        {
            var contains=
            DataProvidersFactories.Any(d =>
                d.FactoryId == componentId ||
                d.DataProviders.Any(dp => dp.ID == componentId));
            return contains;
        }
    }
}
