using System;
using System.Collections.Generic;
using System.Drawing;
using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.Common.Properties;

namespace Analogy.Common.Managers
{
    public class DefaultUserSettingsManager : IUserSettingsManager
    {
        public event EventHandler<bool>? OnInlineJsonViewerChanged;
        public bool SaveSearchFilters { get; set; }
        public string IncludeText { get; set; }
        public string ExcludeText { get; set; }
        public string SourceText { get; set; }
        public string ModuleText { get; set; }
        public bool EnableFileCaching { get; set; }
        public bool StartupErrorLogLevel { get; set; }
        public bool PagingEnabled { get; set; }
        public int PagingSize { get; set; } = int.MaxValue;
        public bool IdleMode { get; set; }
        public int IdleTimeMinutes { get; set; }
        public bool AutoScrollToLastMessage { get; set; }
        public bool DefaultDescendOrder { get; set; }
        public ColorSettings ColorSettings { get; set; } = new ColorSettings();
        public bool RememberLastSearches { get; set; }
        public PreDefinedQueries PreDefinedQueries { get; set; } = new PreDefinedQueries();
        public List<string> LastSearchesInclude { get; set; } = new List<string>(0);
        public List<string> LastSearchesExclude { get; set; } = new List<string>(0);
        public string LogGridFileName { get; }
        public string DateTimePattern { get; set; } = "yyyy.MM.dd HH:mm:ss.ff";
        public bool CheckAdditionalInformation { get; set; } = true;
        public bool EnableCompressedArchives { get; set; }
        public bool IsBuiltInSearchPanelVisible { get; set; } = true;
        public BuiltInSearchPanelMode BuiltInSearchPanelMode { get; set; } = BuiltInSearchPanelMode.Search;
        public bool ShowMessageDetails { get; set; } = true;
        public bool AdvancedMode { get; set; }
        public bool AdvancedModeRawSQLFilterEnabled { get; set; }
        public bool AdvancedModeAdditionalFilteringColumnsEnabled { get; set; }
        public LogLevelSelectionType LogLevelSelection { get; set; } = LogLevelSelectionType.Single;
        public FontSettings FontSettings { get; set; } = new FontSettings();
        public bool TrackActiveMessage { get; set; }
        public float RealTimeRefreshInterval { get; set; } = 1;
        public FilteringExclusion FilteringExclusion { get; set; } = new FilteringExclusion();
        public string LogsLayoutFileName { get; }
        public bool UseCustomLogsLayout { get; set; }
        public bool ViewDetailedMessageWithHTML { get; set; }
        public TimeSpan TimeOffset { get; set; } = TimeSpan.Zero;
        public TimeOffsetType TimeOffsetType { get; set; } = TimeOffsetType.None;
        public bool ShowProcessedCounter { get; set; }
        public bool InlineJsonViewer { get; set; }

        public bool SupportLinuxFormatting { get; set; }

        public void Save(string version)
        {
        }

        public void AddToRecentFiles(Guid iD, string file)
        {
        }

        public void AddToRecentFolders(Guid iD, string path)
        {
        }

        public void ClearStatistics()
        {
        }

        public bool AddNewSearchesEntryToLists(string text, bool include)
        {
            return true;
        }

        public Icon GetIcon()
        {
            return Resources.Analogy_icon_small;
        }

        public IEnumerable<(Guid ID, string FileName)> GetRecentFiles(Guid offlineAnalogyId)
        {
            return new List<(Guid ID, string FileName)>(0);
        }

        public IEnumerable<(Guid ID, string Path)> GetRecentFolders(Guid offlineAnalogyId)
        {
            return new List<(Guid ID, string Path)>(0);
        }

        public void ResetSettings()
        {
        }

        public bool TryGetWindowPosition(Guid id, out AnalogyPositionState? position)
        {
            position = null;
            return false;
        }

        public void SetWindowPosition(Guid id, AnalogyPositionState position)
        {
        }

        public void SetLogsLayoutFileName(string filename)
        {

        }
    }
}
