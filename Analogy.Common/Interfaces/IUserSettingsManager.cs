using System;
using System.Collections.Generic;
using System.Drawing;
using Analogy.Common.DataTypes;
using Analogy.CommonUtilities.Web;
using Analogy.Interfaces.Factories;

namespace Analogy.Common.Interfaces
{
    public interface IUserSettingsManager
    {
        event EventHandler OnFactoryOrderChanged;
        event EventHandler<bool> OnEnableFirstChanceExceptionChanged;
        event EventHandler<bool> OnInlineJsonViewerChanged;
        string DisplayRunningTime { get; }
        Guid InitialSelectedDataProvider { get; set; }
        string ApplicationSkinName { get; set; }
        bool SaveSearchFilters { get; set; }
        string IncludeText { get; set; }
        string ExcludeText { get; set; }
        string SourceText { get; set; }
        string ModuleText { get; set; }
        List<(Guid ID, string FileName)> RecentFiles { get; set; }
        List<(Guid ID, string Path)> RecentFolders { get; set; }
        bool ShowHistoryOfClearedMessages { get; set; }
        int RecentFilesCount { get; set; }
        int RecentFoldersCount { get; set; }
        bool EnableUserStatistics { get; set; }
        TimeSpan AnalogyRunningTime { get; set; }
        uint AnalogyLaunches { get; set; }
        uint AnalogyOpenedFiles { get; set; }
        bool EnableFileCaching { get; set; }
        List<Guid> StartupExtensions { get; set; }
        bool StartupRibbonMinimized { get; set; }
        bool StartupErrorLogLevel { get; set; }
        bool PagingEnabled { get; set; }
        int PagingSize { get; set; }
        bool ShowChangeLogAtStartUp { get; set; }
        bool SearchAlsoInSourceAndModule { get; set; }
        bool IdleMode { get; set; }
        int IdleTimeMinutes { get; set; }
        List<string> EventLogs { get; set; }
        List<Guid> AutoStartDataProviders { get; set; }
        bool AutoScrollToLastMessage { get; set; }
        bool DefaultDescendOrder { get; set; }
        ColorSettings ColorSettings { get; set; }
        List<Guid> FactoriesOrder { get; set; }
        List<FactorySettings> FactoriesSettings { get; set; }
        Guid LastOpenedDataProvider { get; set; }
        bool RememberLastOpenedDataProvider { get; set; }
        bool RememberLastSearches { get; set; }
        PreDefinedQueries PreDefinedQueries { get; set; }
        int NumberOfLastSearches { get; set; }
        List<string> LastSearchesInclude { get; set; }
        List<string> LastSearchesExclude { get; set; }
        int AnalogyInternalLogPeriod { get; set; }
        List<string> AdditionalProbingLocations { get; set; }
        bool SingleInstance { get; set; }
        string AnalogyIcon { get; set; }
        string LogGridFileName { get; }
        string DateTimePattern { get; set; }
        UpdateMode UpdateMode { get; set; }
        DateTime LastUpdate { get; set; }
        GithubObjects.GithubReleaseEntry? LastVersionChecked { get; set; }
        string GitHubToken { get; }
        bool MinimizedToTrayBar { get; set; }
        bool CheckAdditionalInformation { get; set; }
        AnalogyPositionState AnalogyPosition { get; set; }
        bool EnableCompressedArchives { get; set; }
        bool IsBuiltInSearchPanelVisible { get; set; }
        BuiltInSearchPanelMode BuiltInSearchPanelMode { get; set; }
        string ApplicationSvgPaletteName { get; set; }
        AnalogyLookAndFeelStyle ApplicationStyle { get; set; }
        bool ShowMessageDetails { get; set; }
        bool SimpleMode { get; set; }
        bool IsFirstRun { get; set; }
        LogLevelSelectionType LogLevelSelection { get; set; }
        bool ShowWhatIsNewAtStartup { get; set; }
        FontSettings FontSettings { get; set; }
        bool EnableFirstChanceException { get; set; }
        AnalogyCommandLayout RibbonStyle { get; set; }
        bool TrackActiveMessage { get; set; }
        float RealTimeRefreshInterval { get; set; }
        FilteringExclusion FilteringExclusion { get; set; }
        string LogsLayoutFileName { get; set; }
        bool UseCustomLogsLayout { get; set; }
        bool ViewDetailedMessageWithHTML { get; set; }
        SettingsMode SettingsMode { get; set; }
        string DefaultUserLogFolder { get; set; }
        TimeSpan TimeOffset { get; set; }
        TimeOffsetType TimeOffsetType { get; set; }

        /// <summary>
        /// delay in seconds
        /// </summary>
        int FilePoolingDelayInterval { get; set; }

        bool EnableFilePoolingDelay { get; set; }
        bool ShowProcessedCounter { get; set; }
        bool InlineJsonViewer { get; set; }
        void Save();
        void AddToRecentFiles(Guid iD, string file);
        void AddToRecentFolders(Guid iD, string path);
        void ClearStatistics();
        void UpdateRunningTime();
        void IncreaseNumberOfLaunches();
        FactorySettings GetFactorySetting(Guid factoryID);
        FactorySettings GetOrAddFactorySetting(IAnalogyFactory factory);
        void UpdateOrder(List<Guid> order);
        IEnumerable<FactorySettings> GetFactoriesThatHasFileAssociation(string[] files);
        bool AddNewSearchesEntryToLists(string text, bool include);
        Icon GetIcon();
        Image GetImage();
        IEnumerable<(Guid ID, string FileName)> GetRecentFiles(Guid offlineAnalogyId);
        IEnumerable<(Guid ID, string Path)> GetRecentFolders(Guid offlineAnalogyId);
        void ResetSettings();
    }
}