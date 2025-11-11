using Analogy.Common.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.Factories;
using Analogy.Interfaces.WinForms;
using Analogy.Interfaces.WinForms.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Common.Interfaces
{
    public interface IFactoryContainer
    {
        bool AssemblyExist { get; }
        string AssemblyFullPath { get; }
        Assembly Assembly { get; }
        IAnalogyFactoryWinForms Factory { get; }
        FactorySettings FactorySetting { get; }
        IAnalogyDownloadInformation? DownloadInformation { get; set; }
        List<IAnalogyCustomActionsFactoryWinForms> CustomActionsFactories { get; }
        List<IAnalogyDataProvidersFactoryWinForms> DataProvidersFactories { get; }
        List<IAnalogyDataProviderSettingsWinForms> DataProvidersSettings { get; }
        List<IAnalogyShareableFactory> ShareableFactories { get; }
        List<IAnalogyExtensionsFactory> ExtensionsFactories { get; }
        List<IAnalogyPlotting> GraphPlotter { get; }
        List<IAnalogyCustomUserControlsFactoryWinForms> UserControlsFactories { get; }
        List<IAnalogyImages> Images { get; }
        void AddDataProviderFactory(IAnalogyDataProvidersFactoryWinForms dataProvidersFactory);
        void AddDataProvidersSettings(IAnalogyDataProviderSettingsWinForms settings);
        void AddCustomActionFactory(IAnalogyCustomActionsFactoryWinForms action);
        void AddShareableFactory(IAnalogyShareableFactory shareableFactory);
        void AddExtensionFactory(IAnalogyExtensionsFactory extensionFactory);
        void AddImages(IAnalogyImages images);
        void AddGraphPlotter(IAnalogyPlotting plotter);
        void AddCustomUserControlFactory(IAnalogyCustomUserControlsFactoryWinForms uc);
        void AddDownloadInformation(IAnalogyDownloadInformation downloadInformation);
        string ToString();
        bool ContainsDataProviderOrDataFactory(Guid componentId);
    }
}