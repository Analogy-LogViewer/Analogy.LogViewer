using Analogy.CommonUtilities.Web;
using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.Managers;
using Analogy.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using Analogy.Common.DataTypes;

namespace Analogy
{


    public class UserSettingsManager : IAnalogyUserSettings
    {
        public event EventHandler OnFactoryOrderChanged;
        public event EventHandler OnApplicationSkinNameChanged;

        private static UserSettingsManager? _userSettings;

        private AnalogyCommandLayout _ribbonStyle;
        private bool _enableFirstChanceException;
        private bool _inlineJsonViewer;
        private string _applicationSkinName;
        public event EventHandler<bool> OnEnableFirstChanceExceptionChanged;
        public event EventHandler<bool> OnInlineJsonViewerChanged;
        public event EventHandler<AnalogyCommandLayout> OnRibbonControlStyleChanged;
        private string LocalSettingFileName { get; } = "AnalogyLocalSettings.json";
        public string DisplayRunningTime => $"{AnalogyRunningTime:dd\\.hh\\:mm\\:ss} days";
        public Guid InitialSelectedDataProvider { get; set; } = new Guid("D3047F5D-CFEB-4A69-8F10-AE5F4D3F2D04");

        public string ApplicationSkinName
        {
            get => _applicationSkinName;
            set
            {
                if (_applicationSkinName != value)
                {
                    _applicationSkinName = value;
                    OnApplicationSkinNameChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <remarks>
        /// Manually implemented lazy pattern to enable setting while keeping the ctor in the getter lazy.
        /// </remarks>
        public static UserSettingsManager UserSettings
        {
            get => _userSettings ??= new UserSettingsManager();
            set => _userSettings = value;
        }

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

        public List<string> EventLogs { get; set; }

        public List<Guid> AutoStartDataProviders { get; set; }
        public bool AutoScrollToLastMessage { get; set; }
        public bool DefaultDescendOrder { get; set; }
        public ColorSettings ColorSettings { get; set; }
        public List<Guid> FactoriesOrder { get; set; }
        public List<FactorySettings> FactoriesSettings { get; set; }

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
        public string LogGridFileName => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "AnalogyGridlayout.xml");
        public string DateTimePattern { get; set; }
        public UpdateMode UpdateMode { get; set; }
        public DateTime LastUpdate { get; set; }
        public GithubObjects.GithubReleaseEntry? LastVersionChecked { get; set; }
        public string GitHubToken { get; } = Environment.GetEnvironmentVariable("AnalogyGitHub_Token") ?? string.Empty;
        public bool MinimizedToTrayBar { get; set; }
        public bool CheckAdditionalInformation { get; set; }

        public AnalogyPositionState AnalogyPosition { get; set; }
        public bool EnableCompressedArchives { get; set; }
        public bool IsBuiltInSearchPanelVisible { get; set; }
        public BuiltInSearchPanelMode BuiltInSearchPanelMode { get; set; }
        public string ApplicationSvgPaletteName { get; set; }
        public AnalogyLookAndFeelStyle ApplicationStyle { get; set; } = AnalogyLookAndFeelStyle.Skin;
        public bool ShowMessageDetails { get; set; }
        public bool AdvancedMode { get; set; } = false;
        public bool AdvancedModeRawSQLFilterEnabled { get; set; }
        public bool AdvancedModeAdditionalFilteringColumnsEnabled { get; set; }
        public bool IsFirstRun { get; set; }
        public LogLevelSelectionType LogLevelSelection { get; set; }
        public bool ShowWhatIsNewAtStartup { get; set; }
        public FontSettings FontSettings { get; set; }

        public bool EnableFirstChanceException
        {
            get => _enableFirstChanceException;
            set
            {
                if (_enableFirstChanceException != value)
                {
                    _enableFirstChanceException = value;
                    OnEnableFirstChanceExceptionChanged?.Invoke(this, value);
                }
            }
        }
        public AnalogyCommandLayout RibbonStyle
        {
            get => _ribbonStyle;
            set
            {
                if (_ribbonStyle != value)
                {
                    _ribbonStyle = value;
                    OnRibbonControlStyleChanged?.Invoke(this, value);

                }
            }
        }
        public bool TrackActiveMessage { get; set; }
        public float RealTimeRefreshInterval { get; set; }
        public FilteringExclusion FilteringExclusion { get; set; }
        public string LogsLayoutFileName { get; set; }
        public bool UseCustomLogsLayout { get; set; }
        public bool ViewDetailedMessageWithHTML { get; set; }

        public SettingsMode SettingsMode { get; set; }
        public MainFormType MainFormType { get; set; }
        public string DefaultUserLogFolder { get; set; }
        public TimeSpan TimeOffset { get; set; }
        public TimeOffsetType TimeOffsetType { get; set; }
        /// <summary>
        /// delay in seconds
        /// </summary>
        public int FilePoolingDelayInterval { get; set; }
        public bool EnableFilePoolingDelay { get; set; }
        public bool ShowProcessedCounter { get; set; }
        public bool InlineJsonViewer
        {
            get => _inlineJsonViewer;
            set
            {
                _inlineJsonViewer = value;
                OnInlineJsonViewerChanged?.Invoke(this, value);
            }
        }

        public bool WarnNET5 { get; set; }
        public bool WarnNET3 { get; set; }
        public UserSettingsManager()
        {
            if (File.Exists(LocalSettingFileName))
            {
                try
                {
                    string data = File.ReadAllText(LocalSettingFileName);
                    var settings = JsonConvert.DeserializeObject<UserSettings>(data);
                    ApplyLocalSettings(settings);
                }
                catch (Exception e)
                {
                    AnalogyLogManager.Instance.LogInformation($"Unable to read settings from {LocalSettingFileName}. Error: {e.Message}. Loading per user settings", nameof(UserSettingsManager));
                    LoadPerUserSettings();
                }
            }
            else
            {
                AnalogyLogManager.Instance.LogInformation($"File {LocalSettingFileName} does not exist. Loading per user settings", nameof(UserSettingsManager));
                LoadPerUserSettings();
            }
        }


        private void LoadPerUserSettings()
        {
            SettingsMode = SettingsMode.PerUser;
            FilteringExclusion = ParseSettings<FilteringExclusion>(Settings.Default.FilteringExclusion);
            EnableCompressedArchives = true;
            AnalogyInternalLogPeriod = 5;
            bool upgradeRequired = false;
            if (Settings.Default.UpgradeRequired)
            {
                upgradeRequired = true;
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }

            DateTimePattern = !string.IsNullOrEmpty(Settings.Default.DateTimePattern)
                ? Settings.Default.DateTimePattern
                : "yyyy.MM.dd HH:mm:ss.ff";
            IsFirstRun = Settings.Default.FirstRun;
            AnalogyIcon = Settings.Default.AnalogyIcon;
            ApplicationSkinName = Settings.Default.ApplicationSkinName;
            EnableUserStatistics = Settings.Default.EnableUserStatistics;
            AnalogyRunningTime = Settings.Default.AnalogyRunningTime;
            AnalogyLaunches = Settings.Default.AnalogyLaunchesCount;
            AnalogyOpenedFiles = Settings.Default.OpenFilesCount;
            ExcludeText = Settings.Default.ExcludeText;
            IncludeText = Settings.Default.IncludeText;
            SourceText = Settings.Default.SourceText;
            ModuleText = Settings.Default.ModuleText;
            ShowHistoryOfClearedMessages = Settings.Default.ShowHistoryClearedMessages;
            SaveSearchFilters = Settings.Default.SaveSearchFilters;
            RecentFiles = ParseSettings<List<(Guid ID, string FileName)>>(Settings.Default.RecentFiles);
            RecentFilesCount = Settings.Default.RecentFilesCount;
            RecentFoldersCount = Settings.Default.RecentFoldersCount;
            RecentFolders = ParseSettings<List<(Guid ID, string Path)>>(Settings.Default.RecentFolders);
            EnableFileCaching = Settings.Default.EnableFileCaching;
            StartupExtensions = ParseSettings<List<Guid>>(Settings.Default.StartupExtensions);
            StartupRibbonMinimized = Settings.Default.StartupRibbonMinimized;
            StartupErrorLogLevel = Settings.Default.StartupErrorLogLevel;
            PagingEnabled = Settings.Default.PagingEnabled;
            PagingSize = Settings.Default.PagingSize;
            ShowChangeLogAtStartUp = Settings.Default.ShowChangeLogAtStartUp;
            IncludeText = Settings.Default.IncludeText;
            SearchAlsoInSourceAndModule = Settings.Default.SearchAlsoInSourceAndModule;
            IdleMode = Settings.Default.IdleMode;
            IdleTimeMinutes = Settings.Default.IdleTimeMinutes;
            EventLogs = ParseSettings<List<string>>(Settings.Default.WindowsEventLogs);
            AutoStartDataProviders = ParseSettings<List<Guid>>(Settings.Default.AutoStartDataProviders);
            AutoScrollToLastMessage = Settings.Default.AutoScrollToLastMessage;
            ColorSettings = ParseSettings<ColorSettings>(Settings.Default.ColorSettings);
            DefaultDescendOrder = Settings.Default.DefaultDescendOrder;
            FactoriesOrder = ParseSettings<List<Guid>>(Settings.Default.FactoriesOrder);
            FactoriesSettings = ParseSettings<List<FactorySettings>>(Settings.Default.FactoriesSettings)
                .Where(f => f.FactoryId != Guid.Empty).ToList();
            LastOpenedDataProvider = Settings.Default.LastOpenedDataProvider;
            PreDefinedQueries = ParseSettings<PreDefinedQueries>(Settings.Default.PreDefinedQueries);
            RememberLastOpenedDataProvider = Settings.Default.RememberLastOpenedDataProvider;
            RememberLastSearches = Settings.Default.RememberLastSearches;
            LastSearchesInclude = ParseSettings<List<string>>(Settings.Default.LastSearchesInclude);
            LastSearchesExclude = ParseSettings<List<string>>(Settings.Default.LastSearchesExclude);
            AdvancedMode = Settings.Default.AdvancedMode;
            AdvancedModeRawSQLFilterEnabled = Settings.Default.AdvancedModeRawSQLFilterEnabled;
            AdvancedModeAdditionalFilteringColumnsEnabled = Settings.Default.AdvancedModeAdditionalFilteringColumnsEnabled;
            NumberOfLastSearches = Settings.Default.NumberOfLastSearches;
            AdditionalProbingLocations = ParseSettings<List<string>>(Settings.Default.AdditionalProbingLocations);
            SingleInstance = Settings.Default.SingleInstance;
            LastUpdate = Settings.Default.LastUpdate;
            LastVersionChecked = ParseSettings<GithubObjects.GithubReleaseEntry>(Settings.Default.LastVersionChecked);
            UpdateMode = Settings.Default.UpdateMode switch
            {
                0 => UpdateMode.Never,
                1 => UpdateMode.EachStartup,
                2 => UpdateMode.OnceAWeek,
                3 => UpdateMode.OnceAMonth,
                _ => UpdateMode
            };

            if (Enum.TryParse(Settings.Default.ApplicationStyle, out AnalogyLookAndFeelStyle style))
            {
                ApplicationStyle = style;
            }
            if (Enum.TryParse(Settings.Default.LogLevelSelection, out LogLevelSelectionType type))
            {
                LogLevelSelection = type;
            }
            ApplicationSvgPaletteName = Settings.Default.ApplicationSvgPaletteName;
            MinimizedToTrayBar = Settings.Default.MinimizedToTrayBar;
            CheckAdditionalInformation = Settings.Default.CheckAdditionalInformation;
            AnalogyPosition = ParseSettings<AnalogyPositionState>(Settings.Default.AnalogyPosition) ??
                              new AnalogyPositionState();
            EnableCompressedArchives = Settings.Default.EnableCompressedArchives;
            IsBuiltInSearchPanelVisible = Settings.Default.IsBuiltInSearchPanelVisible;
            if (Enum.TryParse(Settings.Default.BuiltInSearchPanelMode, out BuiltInSearchPanelMode result))
            {
                BuiltInSearchPanelMode = result;
            }

            ShowMessageDetails = Settings.Default.ShowMessageDetails;
            ShowWhatIsNewAtStartup = upgradeRequired || Settings.Default.ShowWhatIsNewAtStartup;
            FontSettings = ParseSettings<FontSettings>(Settings.Default.FontSettings);
            RibbonStyle = (AnalogyCommandLayout)Settings.Default.RibbonStyle;
            EnableFirstChanceException = Settings.Default.EnableFirstChanceException;
            TrackActiveMessage = Settings.Default.TrackActiveMessage;
            RealTimeRefreshInterval = Settings.Default.RealTimeRefreshInterval;
            UseCustomLogsLayout = Settings.Default.UseCustomLogsLayout;
            LogsLayoutFileName = Settings.Default.LogsLayoutFileName;
            ViewDetailedMessageWithHTML = Settings.Default.ViewDetailedMessageWithHTML;
            if (Enum.TryParse<MainFormType>(Settings.Default.MainFormType, out var layoutVersion))
            {
                MainFormType = layoutVersion;
            }

            if (Enum.TryParse<TimeOffsetType>(Settings.Default.TimeOffsetType, out var timeOffsetTypeValue))
            {
                TimeOffsetType = timeOffsetTypeValue;
            }
            DefaultUserLogFolder = Settings.Default.DefaultUserLogFolder;
            TimeOffset = TimeSpan.FromMilliseconds(Settings.Default.TimeOffset);
            FilePoolingDelayInterval = Settings.Default.FilePoolingDelayInterval;
            EnableFilePoolingDelay = Settings.Default.FilePoolingDelayEnable;
            InlineJsonViewer = Settings.Default.InlineJsonViewer;
            ShowProcessedCounter = Settings.Default.ShowProcessedCounter;
            WarnNET3 = Settings.Default.WarnNET3;
            WarnNET5 = Settings.Default.WarnNET5;
        }

        private void ApplyLocalSettings(UserSettings settings)
        {
            SettingsMode = SettingsMode.ApplicationFolder;
            ApplicationSkinName = settings.ApplicationSkinName;
            SaveSearchFilters = settings.SaveSearchFilters;
            IncludeText = settings.IncludeText;
            ExcludeText = settings.ExcludeText;
            SourceText = settings.SourceText;
            ModuleText = settings.ModuleText;
            RecentFiles = settings.RecentFiles;
            RecentFolders = settings.RecentFolders;
            ShowHistoryOfClearedMessages = settings.ShowHistoryOfClearedMessages;
            RecentFilesCount = settings.RecentFilesCount;
            RecentFoldersCount = settings.RecentFoldersCount;
            EnableUserStatistics = settings.EnableUserStatistics;
            AnalogyRunningTime = settings.AnalogyRunningTime;
            AnalogyLaunches = settings.AnalogyLaunches;
            AnalogyOpenedFiles = settings.AnalogyOpenedFiles;
            EnableFileCaching = settings.EnableFileCaching;
            StartupExtensions = settings.StartupExtensions;
            StartupRibbonMinimized = settings.StartupRibbonMinimized;
            StartupErrorLogLevel = settings.StartupErrorLogLevel;
            PagingEnabled = settings.PagingEnabled;
            PagingSize = settings.PagingSize;
            ShowChangeLogAtStartUp = settings.ShowChangeLogAtStartUp;
            SearchAlsoInSourceAndModule = settings.SearchAlsoInSourceAndModule;
            IdleMode = settings.IdleMode;
            IdleTimeMinutes = settings.IdleTimeMinutes;
            EventLogs = settings.EventLogs;
            AutoStartDataProviders = settings.AutoStartDataProviders;
            AutoScrollToLastMessage = settings.AutoScrollToLastMessage;
            DefaultDescendOrder = settings.DefaultDescendOrder;
            ColorSettings = settings.ColorSettings;
            FactoriesOrder = settings.FactoriesOrder;
            FactoriesSettings = settings.FactoriesSettings;
            LastOpenedDataProvider = settings.LastOpenedDataProvider;
            RememberLastOpenedDataProvider = settings.RememberLastOpenedDataProvider;
            RememberLastSearches = settings.RememberLastSearches;
            PreDefinedQueries = settings.PreDefinedQueries;
            NumberOfLastSearches = settings.NumberOfLastSearches;
            LastSearchesInclude = settings.LastSearchesInclude;
            LastSearchesExclude = settings.LastSearchesExclude;
            AnalogyInternalLogPeriod = settings.AnalogyInternalLogPeriod;
            AdditionalProbingLocations = settings.AdditionalProbingLocations;
            SingleInstance = settings.SingleInstance;
            AnalogyIcon = settings.AnalogyIcon;
            DateTimePattern = settings.DateTimePattern;
            UpdateMode = settings.UpdateMode;
            LastUpdate = settings.LastUpdate;
            LastVersionChecked = settings.LastVersionChecked;
            MinimizedToTrayBar = settings.MinimizedToTrayBar;
            CheckAdditionalInformation = settings.CheckAdditionalInformation;
            AnalogyPosition = settings.AnalogyPosition;
            EnableCompressedArchives = settings.EnableCompressedArchives;
            IsBuiltInSearchPanelVisible = settings.IsBuiltInSearchPanelVisible;
            BuiltInSearchPanelMode = settings.BuiltInSearchPanelMode;
            ApplicationSvgPaletteName = settings.ApplicationSvgPaletteName;
            ApplicationStyle = settings.ApplicationStyle;
            ShowMessageDetails = settings.ShowMessageDetails;
            AdvancedMode = settings.AdvancedMode;
            AdvancedModeAdditionalFilteringColumnsEnabled = settings.AdvancedModeAdditionalFilteringColumnsEnabled;
            AdvancedModeRawSQLFilterEnabled = settings.AdvancedModeRawSQLFilterEnabled;
            IsFirstRun = settings.IsFirstRun;
            LogLevelSelection = settings.LogLevelSelection;
            FontSettings = settings.FontSettings;
            EnableFirstChanceException = settings.EnableFirstChanceException;
            RibbonStyle = settings.RibbonStyle;
            TrackActiveMessage = settings.TrackActiveMessage;
            RealTimeRefreshInterval = settings.RealTimeRefreshInterval;
            FilteringExclusion = settings.FilteringExclusion;
            LogsLayoutFileName = settings.LogsLayoutFileName;
            UseCustomLogsLayout = settings.UseCustomLogsLayout;
            ViewDetailedMessageWithHTML = settings.ViewDetailedMessageWithHTML;
            ShowWhatIsNewAtStartup = settings.ShowWhatIsNewAtStartup ||
                                     UpdateManager.Instance.CurrentVersion.ToString(4) != settings.Version;
            MainFormType = settings.MainFormType;
            TimeOffsetType = settings.TimeOffsetType;
            DefaultUserLogFolder = settings.DefaultUserLogFolder;
            TimeOffset = settings.TimeOffset;
            FilePoolingDelayInterval = settings.FilePoolingDelayInterval;
            EnableFilePoolingDelay = settings.EnableFilePoolingDelay;
            InlineJsonViewer = settings.InlineJsonViewer;
            ShowProcessedCounter = settings.ShowProcessedCounter;
            WarnNET3 = settings.WarnNET3;
            WarnNET5 = settings.WarnNET5;
        }

        private UserSettings CreateUserSettings()
        {
            var userSettings = new UserSettings()
            {
                ApplicationSkinName = ApplicationSkinName,
                SaveSearchFilters = SaveSearchFilters,
                IncludeText = IncludeText,
                ExcludeText = ExcludeText,
                SourceText = SourceText,
                ModuleText = ModuleText,
                RecentFiles = RecentFiles,
                RecentFolders = RecentFolders,
                ShowHistoryOfClearedMessages = ShowHistoryOfClearedMessages,
                RecentFilesCount = RecentFilesCount,
                RecentFoldersCount = RecentFoldersCount,
                EnableUserStatistics = EnableUserStatistics,
                AnalogyRunningTime = AnalogyRunningTime,
                AnalogyLaunches = AnalogyLaunches,
                AnalogyOpenedFiles = AnalogyOpenedFiles,
                EnableFileCaching = EnableFileCaching,
                StartupExtensions = StartupExtensions,
                StartupRibbonMinimized = StartupRibbonMinimized,
                StartupErrorLogLevel = StartupErrorLogLevel,
                PagingEnabled = PagingEnabled,
                PagingSize = PagingSize,
                ShowChangeLogAtStartUp = ShowChangeLogAtStartUp,
                SearchAlsoInSourceAndModule = SearchAlsoInSourceAndModule,
                IdleMode = IdleMode,
                IdleTimeMinutes = IdleTimeMinutes,
                EventLogs = EventLogs,
                AutoStartDataProviders = AutoStartDataProviders,
                AutoScrollToLastMessage = AutoScrollToLastMessage,
                DefaultDescendOrder = DefaultDescendOrder,
                ColorSettings = ColorSettings,
                FactoriesOrder = FactoriesOrder,
                FactoriesSettings = FactoriesSettings,
                LastOpenedDataProvider = LastOpenedDataProvider,
                RememberLastOpenedDataProvider = RememberLastOpenedDataProvider,
                RememberLastSearches = RememberLastSearches,
                PreDefinedQueries = PreDefinedQueries,
                NumberOfLastSearches = NumberOfLastSearches,
                LastSearchesInclude = LastSearchesInclude,
                LastSearchesExclude = LastSearchesExclude,
                AnalogyInternalLogPeriod = AnalogyInternalLogPeriod,
                AdditionalProbingLocations = AdditionalProbingLocations,
                SingleInstance = SingleInstance,
                AnalogyIcon = AnalogyIcon,
                DateTimePattern = DateTimePattern,
                UpdateMode = UpdateMode,
                LastUpdate = LastUpdate,
                LastVersionChecked = LastVersionChecked,
                MinimizedToTrayBar = MinimizedToTrayBar,
                CheckAdditionalInformation = CheckAdditionalInformation,
                AnalogyPosition = AnalogyPosition,
                EnableCompressedArchives = EnableCompressedArchives,
                IsBuiltInSearchPanelVisible = IsBuiltInSearchPanelVisible,
                BuiltInSearchPanelMode = BuiltInSearchPanelMode,
                ApplicationSvgPaletteName = ApplicationSvgPaletteName,
                ApplicationStyle = ApplicationStyle,
                ShowMessageDetails = ShowMessageDetails,
                AdvancedMode = AdvancedMode,
                AdvancedModeAdditionalFilteringColumnsEnabled = AdvancedModeAdditionalFilteringColumnsEnabled,
                AdvancedModeRawSQLFilterEnabled = AdvancedModeRawSQLFilterEnabled,
                IsFirstRun = IsFirstRun,
                LogLevelSelection = LogLevelSelection,
                ShowWhatIsNewAtStartup = ShowWhatIsNewAtStartup,
                FontSettings = FontSettings,
                EnableFirstChanceException = EnableFirstChanceException,
                RibbonStyle = RibbonStyle,
                TrackActiveMessage = TrackActiveMessage,
                RealTimeRefreshInterval = RealTimeRefreshInterval,
                FilteringExclusion = FilteringExclusion,
                LogsLayoutFileName = LogsLayoutFileName,
                UseCustomLogsLayout = UseCustomLogsLayout,
                ViewDetailedMessageWithHTML = ViewDetailedMessageWithHTML,
                MainFormType = MainFormType,
                TimeOffsetType = TimeOffsetType,
                DefaultUserLogFolder = DefaultUserLogFolder,
                TimeOffset = TimeOffset,
                FilePoolingDelayInterval = FilePoolingDelayInterval,
                EnableFilePoolingDelay = EnableFilePoolingDelay,
                InlineJsonViewer = InlineJsonViewer,
                ShowProcessedCounter = ShowProcessedCounter,
                WarnNET3 = WarnNET3,
                WarnNET5 = WarnNET5

            };
            return userSettings;
        }

        private T ParseSettings<T>(string data) where T : new()
        {
            try
            {
                return string.IsNullOrEmpty(data) ?
                    new T() :
                    JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception e)
            {
                AnalogyLogManager.Instance.LogError("Error during parsing: " + e, nameof(UserSettingsManager));
                return new T();
            }


        }
        public void Save()
        {
            switch (SettingsMode)
            {
                case SettingsMode.PerUser:
                    SavePerUserSettings();
                    DeletePortableSettings();
                    break;
                case SettingsMode.ApplicationFolder:
                    SavePortableSettings();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            //SaveSettingModeToRegistry();
        }

        private void DeletePortableSettings()
        {
            if (File.Exists(LocalSettingFileName))
            {
                try
                {
                    File.Delete(LocalSettingFileName);
                }
                catch (Exception e)
                {
                    AnalogyLogManager.Instance.LogError($"Unable to remove local settings. Error: {e.Message}.", nameof(UserSettingsManager));
                }
            }
        }

        //private void SaveSettingModeToRegistry()
        //{
        //    try
        //    {
        //        using RegistryKey key = Registry.LocalMachine.CreateSubKey(AnalogyRegistryKey);
        //        key?.SetValue("SettingsMode", SettingsMode.ToString());
        //    }
        //    catch (Exception e)
        //    {
        //        AnalogyLogger.Instance.LogError($"Unable to create registry key: {e.Message}");
        //    }
        //}

        private void SavePortableSettings()
        {
            try
            {
                UserSettings settings = CreateUserSettings();
                settings.Version = UpdateManager.Instance.CurrentVersion.ToString(4);
                string data = JsonConvert.SerializeObject(settings);
                File.WriteAllText(LocalSettingFileName, data);
            }
            catch (Exception e)
            {
                AnalogyLogManager.Instance.LogError($"Unable to save setting to {LocalSettingFileName}. Error: {e.Message}. Saving Per user", nameof(UserSettingsManager));
                SettingsMode = SettingsMode.PerUser;
                SavePerUserSettings();
            }
        }

        private void SavePerUserSettings()
        {
            Settings.Default.FirstRun = false;
            Settings.Default.DateTimePattern = !string.IsNullOrEmpty(DateTimePattern)
                ? DateTimePattern
                : "yyyy.MM.dd HH:mm:ss.ff";
            Settings.Default.AnalogyIcon = AnalogyIcon;
            Settings.Default.ApplicationSkinName = ApplicationSkinName;
            Settings.Default.EnableUserStatistics = EnableUserStatistics;
            Settings.Default.AnalogyRunningTime = AnalogyRunningTime;
            Settings.Default.AnalogyLaunchesCount = AnalogyLaunches;
            Settings.Default.OpenFilesCount = AnalogyOpenedFiles;
            Settings.Default.ModuleText = ModuleText;
            Settings.Default.SourceText = SourceText;
            Settings.Default.ExcludeText = ExcludeText;
            Settings.Default.IncludeText = IncludeText;
            Settings.Default.ShowHistoryClearedMessages = ShowHistoryOfClearedMessages;
            Settings.Default.SaveSearchFilters = SaveSearchFilters;
            Settings.Default.RecentFilesCount = RecentFilesCount;
            Settings.Default.RecentFiles = JsonConvert.SerializeObject(RecentFiles.Take(RecentFilesCount).ToList());
            Settings.Default.RecentFoldersCount = RecentFoldersCount;
            Settings.Default.RecentFolders = JsonConvert.SerializeObject(RecentFolders.Take(RecentFoldersCount).ToList());
            Settings.Default.EnableFileCaching = EnableFileCaching;
            Settings.Default.StartupExtensions = JsonConvert.SerializeObject(StartupExtensions);
            Settings.Default.StartupRibbonMinimized = StartupRibbonMinimized;
            Settings.Default.StartupErrorLogLevel = StartupErrorLogLevel;
            Settings.Default.PagingEnabled = PagingEnabled;
            Settings.Default.PagingSize = PagingSize;
            Settings.Default.ShowChangeLogAtStartUp = false;
            Settings.Default.IncludeText = IncludeText;
            Settings.Default.SearchAlsoInSourceAndModule = SearchAlsoInSourceAndModule;
            Settings.Default.IdleMode = IdleMode;
            Settings.Default.IdleTimeMinutes = IdleTimeMinutes;
            Settings.Default.WindowsEventLogs = JsonConvert.SerializeObject(EventLogs);
            Settings.Default.AutoStartDataProviders = JsonConvert.SerializeObject(AutoStartDataProviders);
            Settings.Default.AutoScrollToLastMessage = AutoScrollToLastMessage;
            Settings.Default.ColorSettings = JsonConvert.SerializeObject(ColorSettings);
            Settings.Default.DefaultDescendOrder = DefaultDescendOrder;
            Settings.Default.FactoriesOrder = JsonConvert.SerializeObject(FactoriesOrder);
            Settings.Default.FactoriesSettings = JsonConvert.SerializeObject(FactoriesSettings);
            Settings.Default.LastOpenedDataProvider = LastOpenedDataProvider;
            Settings.Default.RememberLastOpenedDataProvider = RememberLastOpenedDataProvider;
            Settings.Default.PreDefinedQueries = JsonConvert.SerializeObject(PreDefinedQueries);
            Settings.Default.RememberLastSearches = RememberLastSearches;
            Settings.Default.NumberOfLastSearches = NumberOfLastSearches;
            Settings.Default.LastSearchesInclude = JsonConvert.SerializeObject(LastSearchesInclude.Take(NumberOfLastSearches).ToList());
            Settings.Default.LastSearchesExclude = JsonConvert.SerializeObject(LastSearchesExclude.Take(NumberOfLastSearches).ToList());
            Settings.Default.AdditionalProbingLocations = JsonConvert.SerializeObject(AdditionalProbingLocations);
            Settings.Default.SingleInstance = SingleInstance;
            Settings.Default.LastUpdate = LastUpdate;
            Settings.Default.UpdateMode = (int)UpdateMode;
            Settings.Default.LastVersionChecked = JsonConvert.SerializeObject(LastVersionChecked);
            Settings.Default.MinimizedToTrayBar = MinimizedToTrayBar;
            Settings.Default.CheckAdditionalInformation = CheckAdditionalInformation;
            Settings.Default.AnalogyPosition = JsonConvert.SerializeObject(AnalogyPosition);
            Settings.Default.EnableCompressedArchives = EnableCompressedArchives;
            Settings.Default.IsBuiltInSearchPanelVisible = IsBuiltInSearchPanelVisible;
            Settings.Default.BuiltInSearchPanelMode = BuiltInSearchPanelMode.ToString();
            Settings.Default.ApplicationStyle = ApplicationStyle.ToString();
            Settings.Default.ApplicationSvgPaletteName = ApplicationSvgPaletteName;
            Settings.Default.ShowMessageDetails = ShowMessageDetails;
            Settings.Default.AdvancedMode = AdvancedMode;
            Settings.Default.AdvancedModeRawSQLFilterEnabled=AdvancedModeRawSQLFilterEnabled;
            Settings.Default.AdvancedModeAdditionalFilteringColumnsEnabled=AdvancedModeAdditionalFilteringColumnsEnabled;
            Settings.Default.LogLevelSelection = LogLevelSelection.ToString();
            Settings.Default.ShowWhatIsNewAtStartup = ShowWhatIsNewAtStartup;
            Settings.Default.FontSettings = JsonConvert.SerializeObject(FontSettings);
            Settings.Default.RibbonStyle = (int)RibbonStyle;
            Settings.Default.EnableFirstChanceException = EnableFirstChanceException;
            Settings.Default.TrackActiveMessage = TrackActiveMessage;
            Settings.Default.RealTimeRefreshInterval = RealTimeRefreshInterval;
            Settings.Default.FilteringExclusion = JsonConvert.SerializeObject(FilteringExclusion);
            Settings.Default.UseCustomLogsLayout = UseCustomLogsLayout;
            Settings.Default.LogsLayoutFileName = LogsLayoutFileName;
            Settings.Default.ViewDetailedMessageWithHTML = ViewDetailedMessageWithHTML;
            Settings.Default.MainFormType = MainFormType.ToString();
            Settings.Default.TimeOffsetType = TimeOffsetType.None.ToString();
            Settings.Default.DefaultUserLogFolder = DefaultUserLogFolder;
            Settings.Default.TimeOffset = TimeOffset.TotalMilliseconds;
            Settings.Default.FilePoolingDelayInterval = FilePoolingDelayInterval;
            Settings.Default.FilePoolingDelayEnable = EnableFilePoolingDelay;
            Settings.Default.InlineJsonViewer = InlineJsonViewer;
            Settings.Default.ShowProcessedCounter = ShowProcessedCounter;
            Settings.Default.WarnNET3 = WarnNET3;
            Settings.Default.WarnNET5 = WarnNET5;
            Settings.Default.Save();
        }

        public void AddToRecentFiles(Guid iD, string file)
        {
            AnalogyOpenedFiles += 1;
            if (!RecentFiles.Contains((iD, file)))
            {
                RecentFiles.Insert(0, (iD, file));
            }
        }
        public void AddToRecentFolders(Guid iD, string path)
        {
            if (!RecentFolders.Contains((iD, path)))
            {
                RecentFolders.Insert(0, (iD, path));
            }
        }
        public void ClearStatistics()
        {
            AnalogyRunningTime = TimeSpan.FromSeconds(0);
            AnalogyLaunches = 0;
            AnalogyOpenedFiles = 0;
        }

        public void UpdateRunningTime() => AnalogyRunningTime =
            AnalogyRunningTime.Add(DateTime.Now.Subtract(Process.GetCurrentProcess().StartTime));

        public void IncreaseNumberOfLaunches() => AnalogyLaunches++;

        public FactorySettings GetFactorySetting(Guid factoryID)
        {
            bool Exists(Guid guid) => guid == factoryID;
            if (FactoriesSettings.Exists(f => Exists(f.FactoryId)))
            {
                return FactoriesSettings.Single(f => Exists(f.FactoryId));
            }

            return null;
        }
        public FactorySettings GetOrAddFactorySetting(IAnalogyFactory factory)
        {
            bool Exists(Guid guid) => guid == factory.FactoryId;
            if (FactoriesSettings.Exists(f => Exists(f.FactoryId)))
            {
                return FactoriesSettings.Single(f => Exists(f.FactoryId));
            }

            var createNew = new FactorySettings
            {
                FactoryId = factory.FactoryId,
                Status = DataProviderFactoryStatus.NotSet,
                UserSettingFileAssociations = new List<string>()
            };
            FactoriesSettings.Add(createNew);
            return createNew;

        }

        public void UpdateOrder(List<Guid> order)
        {
            if (FactoriesOrder.SequenceEqual(order))
            {
                return;
            }

            FactoriesOrder = order;
            OnFactoryOrderChanged?.Invoke(this, new EventArgs());
        }

        public IEnumerable<FactorySettings> GetFactoriesThatHasFileAssociation(string[] files) =>
            FactoriesSettings.Where(factory => factory.Status != DataProviderFactoryStatus.Disabled &&
                                               factory.UserSettingFileAssociations != null &&
                                               factory.UserSettingFileAssociations.Any(i =>
                                                   Utils.MatchedAll(i, files)));
        public bool AddNewSearchesEntryToLists(string text, bool include)
        {
            if (include)
            {
                if (LastSearchesInclude.Contains(text, StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }

                LastSearchesInclude.Add(text);
                return true;
            }
            else
            {
                if (LastSearchesExclude.Contains(text, StringComparison.InvariantCultureIgnoreCase))
                {
                    return false;
                }

                LastSearchesExclude.Add(text);
                return true;
            }
        }

        public Icon GetIcon()
        {
            return AnalogyIcon == "Dark" ? Resources.AnalogyIconDark : Resources.AnalogyIconLight;
        }
        public Image GetImage()
        {
            return AnalogyIcon == "Dark" ? Resources.AnalogyDark : Resources.AnalogyLight;
        }

        public IEnumerable<(Guid ID, string FileName)> GetRecentFiles(Guid offlineAnalogyId) =>
            RecentFiles.Where(itm => itm.ID == offlineAnalogyId);

        public IEnumerable<(Guid ID, string Path)> GetRecentFolders(Guid offlineAnalogyId) =>
            RecentFolders.Where(itm => itm.ID == offlineAnalogyId);

        public void ResetSettings()
        {
            Settings.Default.Reset();
            Settings.Default.UpgradeRequired = false;
            Settings.Default.Save();
            ShowWhatIsNewAtStartup = true;
            SettingsMode = SettingsMode.PerUser;
            MainFormType = MainFormType.RibbonForm;
            TimeOffsetType = TimeOffsetType.None;
            LoadPerUserSettings();
        }
    }
}

