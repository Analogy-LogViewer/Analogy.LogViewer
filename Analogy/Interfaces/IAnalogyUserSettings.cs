using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.CommonUtilities.Web;
using Analogy.DataTypes;
using Analogy.Interfaces.Factories;

namespace Analogy.Interfaces
{
    public interface IAnalogyUserSettings: IUserSettingsManager
    {
        event EventHandler OnFactoryOrderChanged;
        event EventHandler<bool> OnEnableFirstChanceExceptionChanged;
        event EventHandler<AnalogyCommandLayout> OnRibbonControlStyleChanged;
        event EventHandler OnApplicationSkinNameChanged;
        int AnalogyInternalLogPeriod { get; set; }
        string DisplayRunningTime { get; }
        Guid InitialSelectedDataProvider { get; set; }
        string ApplicationSkinName { get; set; }
        List<(Guid ID, string FileName)> RecentFiles { get; set; }
        List<(Guid ID, string Path)> RecentFolders { get; set; }
        bool ShowHistoryOfClearedMessages { get; set; }
        int RecentFilesCount { get; set; }
        int RecentFoldersCount { get; set; }
        bool EnableUserStatistics { get; set; }
        uint AnalogyLaunches { get; set; }
        uint AnalogyOpenedFiles { get; set; }
        List<Guid> StartupExtensions { get; set; }
        bool StartupRibbonMinimized { get; set; }
        MainFormType MainFormType { get; set; }
        bool ShowChangeLogAtStartUp { get; set; }
        bool SearchAlsoInSourceAndModule { get; set; }
        List<Guid> AutoStartDataProviders { get; set; }
        List<Guid> FactoriesOrder { get; set; }
        List<FactorySettings> FactoriesSettings { get; set; }
        Guid LastOpenedDataProvider { get; set; }
        bool RememberLastOpenedDataProvider { get; set; }
        int NumberOfLastSearches { get; set; }
        List<string> AdditionalProbingLocations { get; set; }
        bool SingleInstance { get; set; }
        string AnalogyIcon { get; set; }
        UpdateMode UpdateMode { get; set; }
        DateTime LastUpdate { get; set; }
        GithubObjects.GithubReleaseEntry? LastVersionChecked { get; set; }
        string GitHubToken { get; }
        bool MinimizedToTrayBar { get; set; }
        AnalogyPositionState AnalogyPosition { get; set; }
        string ApplicationSvgPaletteName { get; set; }
        AnalogyLookAndFeelStyle ApplicationStyle { get; set; }
        bool IsFirstRun { get; set; }
        bool ShowWhatIsNewAtStartup { get; set; }
        bool EnableFirstChanceException { get; set; }
        AnalogyCommandLayout RibbonStyle { get; set; }
        SettingsMode SettingsMode { get; set; }
        bool WarnNET5 { get; set; }
        bool WarnNET3 { get; set; }
        bool ShowAdvancedSettingsRawSQLPopup { get; set; }
        string DefaultUserLogFolder { get; set; }
        /// <summary>
        /// delay in seconds
        /// </summary>
        int FilePoolingDelayInterval { get; set; }
        bool EnableFilePoolingDelay { get; set; }
        void IncreaseNumberOfLaunches();
        FactorySettings GetFactorySetting(Guid factoryID);
        FactorySettings GetOrAddFactorySetting(IAnalogyFactory factory);
        void UpdateOrder(List<Guid> order);
        IEnumerable<FactorySettings> GetFactoriesThatHasFileAssociation(string[] files);
        Image GetImage();
        void UpdateRunningTime();


    }
}
