using Analogy.Common.Interfaces;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.Factories;
using Analogy.Interfaces.Winforms;
using Analogy.Interfaces.Winforms.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Analogy.Common.DataTypes
{
    public class FactoryContainer : IFactoryContainer
    {
        public bool AssemblyExist => File.Exists(AssemblyFullPath);
        public string AssemblyFullPath { get; }
        public Assembly Assembly { get; }
        public IAnalogyFactoryWinforms Factory { get; }
        public FactorySettings FactorySetting { get; }
        public IAnalogyDownloadInformation? DownloadInformation { get; set; }
        public List<IAnalogyCustomActionsFactoryWinforms> CustomActionsFactories { get; }
        public List<IAnalogyDataProvidersFactoryWinforms> DataProvidersFactories { get; }
        public List<IAnalogyDataProviderSettingsWinforms> DataProvidersSettings { get; }
        public List<IAnalogyShareableFactory> ShareableFactories { get; }
        public List<IAnalogyExtensionsFactory> ExtensionsFactories { get; }
        public List<IAnalogyPlotting> GraphPlotter { get; }
        public List<IAnalogyCustomUserControlsFactoryWinforms> UserControlsFactories { get; }
        public List<IAnalogyImages> Images { get; private set; }
        public FactoryContainer(Assembly assembly, string assemblyFullPath, IAnalogyFactoryWinforms factory, FactorySettings factorySetting)
        {
            Assembly = assembly;
            AssemblyFullPath = assemblyFullPath;
            Factory = factory;
            FactorySetting = factorySetting;
            CustomActionsFactories = [];
            DataProvidersFactories = [];
            DataProvidersSettings = [];
            ShareableFactories = new List<IAnalogyShareableFactory>();
            ExtensionsFactories = new List<IAnalogyExtensionsFactory>();
            GraphPlotter = new List<IAnalogyPlotting>();
            UserControlsFactories = new List<IAnalogyCustomUserControlsFactoryWinforms>();
            Images = new List<IAnalogyImages>();
        }

        public void AddDataProviderFactory(IAnalogyDataProvidersFactoryWinforms dataProvidersFactory) =>
            DataProvidersFactories.Add(dataProvidersFactory);

        public void AddDataProvidersSettings(IAnalogyDataProviderSettingsWinforms settings) =>
            DataProvidersSettings.Add(settings);

        public void AddCustomActionFactory(IAnalogyCustomActionsFactoryWinforms action) => CustomActionsFactories.Add(action);

        public void AddShareableFactory(IAnalogyShareableFactory shareableFactory) =>
            ShareableFactories.Add(shareableFactory);

        public void AddExtensionFactory(IAnalogyExtensionsFactory extensionFactory) =>
            ExtensionsFactories.Add(extensionFactory);
        public void AddImages(IAnalogyImages images) => Images.Add(images);
        public void AddGraphPlotter(IAnalogyPlotting plotter) => GraphPlotter.Add(plotter);
        public void AddCustomUserControlFactory(IAnalogyCustomUserControlsFactoryWinforms uc) => UserControlsFactories.Add(uc);
        public void AddDownloadInformation(IAnalogyDownloadInformation downloadInformation)
            => DownloadInformation = downloadInformation;
        public override string ToString() => $"{nameof(Factory)}: {Factory}, {nameof(Assembly)}: {Assembly}";

        public bool ContainsDataProviderOrDataFactory(Guid componentId)
        {
            var contains =
            DataProvidersFactories.Any(d =>
                d.FactoryId == componentId ||
                d.DataProviders.Any(dp => dp.Id == componentId));
            return contains;
        }
    }
}