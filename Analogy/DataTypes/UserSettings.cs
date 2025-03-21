﻿using Analogy.Common.DataTypes;
using Analogy.CommonControls.DataTypes;
using Analogy.CommonUtilities.Github;
using Analogy.CommonUtilities.Web;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Ribbon;
using Octokit;
using System.Collections.Generic;

namespace Analogy.DataTypes
{
    [Serializable]
    public class UserSettings
    {
        public string ApplicationSkinName { get; set; }
        public bool SaveSearchFilters { get; set; }
        public string IncludeText { get; set; }
        public string ExcludeText { get; set; }
        public string SourceText { get; set; }
        public string ModuleText { get; set; }
        public List<(Guid ID, string FileName)> RecentFiles { get; set; }
        public List<(Guid ID, string Path)> RecentFolders { get; set; }
        public bool ShowHistoryOfClearedMessages { get; set; }
        public int RecentFilesCount { get; set; }
        public int RecentFoldersCount { get; set; }
        public bool EnableUserStatistics { get; set; }
        public TimeSpan AnalogyRunningTime { get; set; }
        public uint AnalogyLaunches { get; set; }
        public uint AnalogyOpenedFiles { get; set; }
        public bool EnableFileCaching { get; set; }
        public List<Guid> StartupExtensions { get; set; }
        public bool StartupRibbonMinimized { get; set; }
        public bool StartupErrorLogLevel { get; set; }
        public bool PagingEnabled { get; set; }
        public int PagingSize { get; set; }
        public bool ShowChangeLogAtStartUp { get; set; }
        public bool SearchAlsoInSourceAndModule { get; set; }
        public bool IdleMode { get; set; }
        public int IdleTimeMinutes { get; set; }
        public List<Guid> AutoStartDataProviders { get; set; }
        public bool AutoScrollToLastMessage { get; set; }
        public bool DefaultDescendOrder { get; set; }
        public ColorSettings ColorSettings { get; set; }
        public List<Guid> FactoriesOrder { get; set; }
        public List<FactorySettings> FactoriesSettings { get; set; }
        public List<FileAssociations> FileAssociations { get; set; }
        public Guid LastOpenedDataProvider { get; set; }
        public bool RememberLastOpenedDataProvider { get; set; }
        public bool RememberLastSearches { get; set; }
        public PreDefinedQueries PreDefinedQueries { get; set; }
        public int NumberOfLastSearches { get; set; }
        public List<string> LastSearchesInclude { get; set; }
        public List<string> LastSearchesExclude { get; set; }
        public int AnalogyInternalLogPeriod { get; set; }
        public List<string> AdditionalProbingLocations { get; set; }
        public bool SingleInstance { get; set; }
        public string AnalogyIcon { get; set; }
        public string DateTimePattern { get; set; }
        public UpdateMode UpdateMode { get; set; }
        public DateTime LastUpdate { get; set; }
        public Release? LastVersionChecked { get; set; }
        public bool MinimizedToTrayBar { get; set; }
        public bool CheckAdditionalInformation { get; set; }
        public AnalogyPositionState AnalogyPosition { get; set; }
        public bool EnableCompressedArchives { get; set; }
        public bool IsBuiltInSearchPanelVisible { get; set; }
        public BuiltInSearchPanelMode BuiltInSearchPanelMode { get; set; }
        public string ApplicationSvgPaletteName { get; set; }
        public AnalogyLookAndFeelStyle ApplicationStyle { get; set; } = AnalogyLookAndFeelStyle.Skin;
        public bool ShowMessageDetails { get; set; }
        public bool AdvancedMode { get; set; }
        public bool AdvancedModeRawSQLFilterEnabled { get; set; }
        public bool AdvancedModeAdditionalFilteringColumnsEnabled { get; set; }
        public bool IsFirstRun { get; set; }
        public LogLevelSelectionType LogLevelSelection { get; set; }
        public bool ShowWhatIsNewAtStartup { get; set; }
        public FontSettings FontSettings { get; set; }
        public bool EnableFirstChanceException { get; set; }
        public AnalogyCommandLayout RibbonStyle { get; set; }
        public bool TrackActiveMessage { get; set; }
        public float RealTimeRefreshInterval { get; set; }
        public FilteringExclusion FilteringExclusion { get; set; }
        public string LogsLayoutFileName { get; set; }
        public bool UseCustomLogsLayout { get; set; }
        public bool ViewDetailedMessageWithHTML { get; set; }
        public SettingsMode SettingsMode { get; set; }
        public string Version { get; set; }
        public MainFormType MainFormType { get; set; }
        public string DefaultUserLogFolder { get; set; }
        public TimeSpan TimeOffset { get; set; }
        public TimeOffsetType TimeOffsetType { get; set; }

        /// <summary>
        /// delay in seconds
        /// </summary>
        public int FilePoolingDelayInterval { get; set; }
        public bool EnableFilePoolingDelay { get; set; }
        public bool InlineJsonViewer { get; set; }
        public bool SupportLinuxFormatting { get; set; }
        public bool HideUnknownLogLevel { get; set; }
        public bool ShowProcessedCounter { get; set; }
        public bool ShowAdvancedSettingsRawSQLPopup { get; set; }
        public bool CombineOfflineProviders { get; set; }
        public bool CombineOnlineProviders { get; set; }
        public Dictionary<Guid, AnalogyPositionState> WindowPositions { get; set; }
        public bool CollapseFolderAndFilesPanel { get; set; }

        public UserSettings()
        {
            FileAssociations = new List<FileAssociations>();
            WindowPositions = new Dictionary<Guid, AnalogyPositionState>();
        }
    }
}