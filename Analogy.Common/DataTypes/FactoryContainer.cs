using Analogy.Common.Interfaces;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.Factories;
using Analogy.Interfaces.WinForms;
using Analogy.Interfaces.WinForms.Factories;
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
        public IAnalogyFactoryWinForms Factory { get; }
        public FactorySettings FactorySetting { get; }
        public IAnalogyDownloadInformation? DownloadInformation { get; set; }
        public List<IAnalogyCustomActionsFactoryWinForms> CustomActionsFactories { get; }
        public List<IAnalogyDataProvidersFactoryWinForms> DataProvidersFactories { get; }
        public List<IAnalogyDataProviderSettingsWinForms> DataProvidersSettings { get; }
        public List<IAnalogyShareableFactory> ShareableFactories { get; }
        public List<IAnalogyExtensionsFactory> ExtensionsFactories { get; }
        public List<IAnalogyPlotting> GraphPlotter { get; }
        public List<IAnalogyCustomUserControlsFactoryWinForms> UserControlsFactories { get; }
        public List<IAnalogyImages> Images { get; private set; }
        public FactoryContainer(Assembly assembly, string assemblyFullPath, IAnalogyFactoryWinForms factory, FactorySettings factorySetting)
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
            UserControlsFactories = new List<IAnalogyCustomUserControlsFactoryWinForms>();
            Images = new List<IAnalogyImages>();
        }

        public void AddDataProviderFactory(IAnalogyDataProvidersFactoryWinForms dataProvidersFactory) =>
            DataProvidersFactories.Add(dataProvidersFactory);

        public void AddDataProvidersSettings(IAnalogyDataProviderSettingsWinForms settings) =>
            DataProvidersSettings.Add(settings);

        public void AddCustomActionFactory(IAnalogyCustomActionsFactoryWinForms action) => CustomActionsFactories.Add(action);

        public void AddShareableFactory(IAnalogyShareableFactory shareableFactory) =>
            ShareableFactories.Add(shareableFactory);

        public void AddExtensionFactory(IAnalogyExtensionsFactory extensionFactory) =>
            ExtensionsFactories.Add(extensionFactory);
        public void AddImages(IAnalogyImages images) => Images.Add(images);
        public void AddGraphPlotter(IAnalogyPlotting plotter) => GraphPlotter.Add(plotter);
        public void AddCustomUserControlFactory(IAnalogyCustomUserControlsFactoryWinForms uc) => UserControlsFactories.Add(uc);
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