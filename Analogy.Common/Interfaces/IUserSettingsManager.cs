using Analogy.Common.DataTypes;
using Analogy.CommonUtilities.Web;
using Analogy.Interfaces.Factories;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Analogy.Common.Interfaces
{
    public interface IUserSettingsManager
    {
        event EventHandler<bool> OnInlineJsonViewerChanged;

        bool SaveSearchFilters { get; set; }
        string IncludeText { get; set; }
        string ExcludeText { get; set; }
        string SourceText { get; set; }
        string ModuleText { get; set; }
        bool EnableFileCaching { get; set; }

        bool StartupErrorLogLevel { get; set; }
        bool PagingEnabled { get; set; }
        int PagingSize { get; set; }
        bool IdleMode { get; set; }
        int IdleTimeMinutes { get; set; }
        bool AutoScrollToLastMessage { get; set; }
        bool DefaultDescendOrder { get; set; }
        ColorSettings ColorSettings { get; set; }
        bool RememberLastSearches { get; set; }
        PreDefinedQueries PreDefinedQueries { get; set; }
        List<string> LastSearchesInclude { get; set; }
        List<string> LastSearchesExclude { get; set; }
        string LogGridFileName { get; }
        string DateTimePattern { get; set; }
        bool CheckAdditionalInformation { get; set; }
        bool EnableCompressedArchives { get; set; }
        bool IsBuiltInSearchPanelVisible { get; set; }
        BuiltInSearchPanelMode BuiltInSearchPanelMode { get; set; }
        bool ShowMessageDetails { get; set; }
        bool AdvancedMode { get; set; }
        bool AdvancedModeRawSQLFilterEnabled { get; set; }
        bool AdvancedModeAdditionalFilteringColumnsEnabled { get; set; }
        LogLevelSelectionType LogLevelSelection { get; set; }
        FontSettings FontSettings { get; set; }
        bool TrackActiveMessage { get; set; }
        float RealTimeRefreshInterval { get; set; }
        FilteringExclusion FilteringExclusion { get; set; }
        string LogsLayoutFileName { get; }
        bool UseCustomLogsLayout { get; set; }
        bool ViewDetailedMessageWithHTML { get; set; }
        TimeSpan TimeOffset { get; set; }
        TimeOffsetType TimeOffsetType { get; set; }

        bool ShowProcessedCounter { get; set; }
        bool InlineJsonViewer { get; set; }
        bool SupportLinuxFormatting { get; set; }
        void Save(string version);
        void AddToRecentFiles(Guid iD, string file);
        void AddToRecentFolders(Guid iD, string path);
        void ClearStatistics();
        bool AddNewSearchesEntryToLists(string text, bool include);
        Icon GetIcon();
        IEnumerable<(Guid ID, string FileName)> GetRecentFiles(Guid offlineAnalogyId);
        IEnumerable<(Guid ID, string Path)> GetRecentFolders(Guid offlineAnalogyId);
        void ResetSettings();
        bool TryGetWindowPosition(Guid id, out AnalogyPositionState? position);
        void SetWindowPosition(Guid id, AnalogyPositionState position);
        void SetLogsLayoutFileName(string filename);
    }
}