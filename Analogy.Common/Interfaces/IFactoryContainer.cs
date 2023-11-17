using Analogy.Common.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.Factories;
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
        IAnalogyFactory Factory { get; }
        FactorySettings FactorySetting { get; }
        IAnalogyDownloadInformation? DownloadInformation { get; set; }
        List<IAnalogyCustomActionsFactory> CustomActionsFactories { get; }
        List<IAnalogyDataProvidersFactory> DataProvidersFactories { get; }
        List<IAnalogyDataProviderSettings> DataProvidersSettings { get; }
        List<IAnalogyShareableFactory> ShareableFactories { get; }
        List<IAnalogyExtensionsFactory> ExtensionsFactories { get; }
        List<IAnalogyPlotting> GraphPlotter { get; }
        List<IAnalogyCustomUserControlsFactory> UserControlsFactories { get; }
        List<IAnalogyImages> Images { get; }
        void AddDataProviderFactory(IAnalogyDataProvidersFactory dataProvidersFactory);
        void AddDataProvidersSettings(IAnalogyDataProviderSettings settings);
        void AddCustomActionFactory(IAnalogyCustomActionsFactory action);
        void AddShareableFactory(IAnalogyShareableFactory shareableFactory);
        void AddExtensionFactory(IAnalogyExtensionsFactory extensionFactory);
        void AddImages(IAnalogyImages images);
        void AddGraphPlotter(IAnalogyPlotting plotter);
        void AddCustomUserControlFactory(IAnalogyCustomUserControlsFactory uc);
        void AddDownloadInformation(IAnalogyDownloadInformation downloadInformation);
        string ToString();
        bool ContainsDataProviderOrDataFactory(Guid componentId);
    }
}
