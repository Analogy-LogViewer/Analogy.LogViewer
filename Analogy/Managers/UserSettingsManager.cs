using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Analogy.DataProviders.Extensions;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.Managers;
using Analogy.Properties;
using Analogy.Types;
using Newtonsoft.Json;

namespace Analogy
{
    public class UserSettingsManager
    {
        public event EventHandler OnFactoryOrderChanged;


        private static readonly Lazy<UserSettingsManager> _instance =
            new Lazy<UserSettingsManager>(() => new UserSettingsManager());

        public string ApplicationSkinName { get; set; }
        public static UserSettingsManager UserSettings { get; set; } = _instance.Value;
        public bool SaveSearchFilters { get; set; }
        public string IncludeText { get; set; }
        public string ExcludedText { get; set; }

        public string SourceText { get; set; }
        public string ModuleText { get; set; }
        public List<(Guid ID, string FileName)> RecentFiles { get; set; }
        public bool ShowHistoryOfClearedMessages { get; set; }
        public int RecentFilesCount { get; set; }
        public bool EnableUserStatistics { get; set; }
        public TimeSpan AnalogyRunningTime { get; set; }
        public uint AnalogyLaunches { get; set; }
        public uint AnalogyOpenedFiles { get; set; }
        public bool EnableFileCaching { get; set; }
        public string DisplayRunningTime => $"{AnalogyRunningTime:dd\\.hh\\:mm\\:ss} days";
        public bool LoadExtensionsOnStartup { get; set; }
        public List<Guid> StartupExtensions { get; set; }
        public bool StartupRibbonMinimized { get; set; }
        public bool StartupErrorLogLevel { get; set; }
        public bool PagingEnabled { get; set; }
        public int PagingSize { get; set; }
        public bool ShowChangeLogAtStartUp { get; set; }
        public float FontSize { get; set; }
        public bool SearchAlsoInSourceAndModule { get; set; }
        public string InitialSelectedDataProvider { get; set; } = "D3047F5D-CFEB-4A69-8F10-AE5F4D3F2D04";
        public bool IdleMode { get; set; }
        public int IdleTimeMinutes { get; set; }

        public List<string> EventLogs { get; set; }

        public List<Guid> AutoStartDataProviders { get; set; }
        public bool AutoScrollToLastMessage { get; set; }
        public bool DefaultDescendOrder { get; set; }
        //public LogParserSettingsContainer LogParsersSettings { get; set; }
        public ColorSettings ColorSettings { get; set; }
        public List<Guid> FactoriesOrder { get; set; }
        public List<FactorySettings> FactoriesSettings { get; set; }
        public Guid LastOpenedDataProvider { get; set; }
        public bool RememberLastOpenedDataProvider { get; set; }
        public PreDefinedQueries PreDefinedQueries { get; set; }
        public UserSettingsManager()
        {
            Load();
        }

        public void Load()
        {
            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }

            ApplicationSkinName = Settings.Default.ApplicationSkinName;
            EnableUserStatistics = Settings.Default.EnableUserStatistics;
            AnalogyRunningTime = Settings.Default.AnalogyRunningTime;
            AnalogyLaunches = Settings.Default.AnalogyLaunchesCount;
            AnalogyOpenedFiles = Settings.Default.OpenFilesCount;
            ExcludedText = Settings.Default.ModuleText;
            SourceText = Settings.Default.SourceText;
            ModuleText = Settings.Default.ModuleText;
            ShowHistoryOfClearedMessages = Settings.Default.ShowHistoryClearedMessages;
            SaveSearchFilters = Settings.Default.SaveSearchFilters;
            RecentFiles = ParseSettings<List<(Guid ID, string FileName)>>(Settings.Default.RecentFiles);
            RecentFilesCount = Settings.Default.RecentFilesCount;
            EnableFileCaching = Settings.Default.EnableFileCaching;
            LoadExtensionsOnStartup = Settings.Default.LoadExtensionsOnStartup;
            StartupExtensions = ParseSettings<List<Guid>>(Settings.Default.StartupExtensions);
            StartupRibbonMinimized = Settings.Default.StartupRibbonMinimized;
            StartupErrorLogLevel = Settings.Default.StartupErrorLogLevel;
            PagingEnabled = Settings.Default.PagingEnabled;
            PagingSize = Settings.Default.PagingSize;
            ShowChangeLogAtStartUp = Settings.Default.ShowChangeLogAtStartUp;
            FontSize = Settings.Default.FontSize;
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
            FactoriesSettings = ParseSettings<List<FactorySettings>>(Settings.Default.FactoriesSettings);
            LastOpenedDataProvider = Settings.Default.LastOpenedDataProvider;
            RememberLastOpenedDataProvider = Settings.Default.RememberLastOpenedDataProvider;
            PreDefinedQueries = ParseSettings<PreDefinedQueries>(Settings.Default.PreDefinedQueries);
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
                AnalogyLogManager.Instance.LogError("Error during parsing: " + e);
                return new T();
            }


        }
        public void Save()
        {
            Settings.Default.ApplicationSkinName = ApplicationSkinName;
            Settings.Default.EnableUserStatistics = EnableUserStatistics;
            Settings.Default.AnalogyRunningTime = AnalogyRunningTime;
            Settings.Default.AnalogyLaunchesCount = AnalogyLaunches;
            Settings.Default.OpenFilesCount = AnalogyOpenedFiles;
            Settings.Default.ModuleText = ModuleText;
            Settings.Default.SourceText = SourceText;
            Settings.Default.ShowHistoryClearedMessages = ShowHistoryOfClearedMessages;
            Settings.Default.SaveSearchFilters = SaveSearchFilters;
            Settings.Default.RecentFilesCount = RecentFilesCount;
            Settings.Default.RecentFiles = JsonConvert.SerializeObject(RecentFiles.Take(RecentFilesCount).ToList());
            Settings.Default.EnableFileCaching = EnableFileCaching;
            Settings.Default.LoadExtensionsOnStartup = LoadExtensionsOnStartup;
            Settings.Default.StartupExtensions = JsonConvert.SerializeObject(StartupExtensions);
            Settings.Default.StartupRibbonMinimized = StartupRibbonMinimized;
            Settings.Default.StartupErrorLogLevel = StartupErrorLogLevel;
            Settings.Default.PagingEnabled = PagingEnabled;
            Settings.Default.PagingSize = PagingSize;
            Settings.Default.ShowChangeLogAtStartUp = false;
            Settings.Default.FontSize = FontSize;
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
            Settings.Default.Save();

        }

        public void AddToRecentFiles(Guid iD, string file)
        {
            AnalogyOpenedFiles += 1;
            if (!RecentFiles.Contains((iD, file)))
                RecentFiles.Insert(0, (iD, file));
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
            if (FactoriesSettings.Exists(f => Exists(f.FactoryGuid)))
            {
                return FactoriesSettings.Single(f => Exists(f.FactoryGuid));
            }

            return null;
        }
        public FactorySettings GetOrAddFactorySetting(IAnalogyFactory factory)
        {
            bool Exists(Guid guid) => guid == factory.FactoryID;
            if (FactoriesSettings.Exists(f => Exists(f.FactoryGuid)))
            {
                return FactoriesSettings.Single(f => Exists(f.FactoryGuid));
            }

            var createNew = new FactorySettings
            {
                FactoryGuid = factory.FactoryID,
                Status = DataProviderFactoryStatus.NotSet,
                UserSettingFileAssociations = new List<string>()
                //factory.DataProviders.Items
                //.Where(itm => itm is IAnalogyOfflineDataProvider)
                //.SelectMany(itm => ((IAnalogyOfflineDataProvider)itm).SupportFormats).ToList()
            };
            FactoriesSettings.Add(createNew);
            return createNew;

        }

        public void UpdateOrder(List<Guid> order)
        {
            if (FactoriesOrder.SequenceEqual(order))
                return;
            FactoriesOrder = order;
            OnFactoryOrderChanged?.Invoke(this, new EventArgs());
        }

        public IEnumerable<FactorySettings> GetFactoriesThatHasFileAssociation(string[] files) =>
            FactoriesSettings.Where(factory => factory.Status != DataProviderFactoryStatus.Disabled &&
                                               factory.UserSettingFileAssociations != null &&
                                               factory.UserSettingFileAssociations.Any(i =>
                                                   Utils.MatchedAll(i, files)));

    }
    [Serializable]
    public class LogParserSettingsContainer
    {
        public ILogParserSettings NLogParserSettings { get; set; }

        public LogParserSettingsContainer()
        {
            NLogParserSettings = new LogParserSettings();
            NLogParserSettings.Splitter = "|";

        }

    }
    [Serializable]
    public class ColorSettings
    {
        public Dictionary<AnalogyLogLevel, Color> LogLevelColors { get; set; }

        public Color HighlightColor { get; set; }
        public ColorSettings()
        {
            HighlightColor = Color.Aqua;
            var logLevelValues = Enum.GetValues(typeof(AnalogyLogLevel));
            LogLevelColors = new Dictionary<AnalogyLogLevel, Color>(logLevelValues.Length);

            foreach (AnalogyLogLevel level in logLevelValues)

            {
                switch (level)
                {
                    case AnalogyLogLevel.Unknown:
                        LogLevelColors.Add(level, Color.White);
                        break;
                    case AnalogyLogLevel.Disabled:
                        LogLevelColors.Add(level, Color.LightGray);
                        break;
                    case AnalogyLogLevel.Trace:
                        LogLevelColors.Add(level, Color.White);
                        break;
                    case AnalogyLogLevel.Verbose:
                        LogLevelColors.Add(level, Color.White);
                        break;
                    case AnalogyLogLevel.Debug:
                        LogLevelColors.Add(level, Color.White);
                        break;
                    case AnalogyLogLevel.Event:
                        LogLevelColors.Add(level, Color.White);
                        break;
                    case AnalogyLogLevel.Warning:
                        LogLevelColors.Add(level, Color.Yellow);
                        break;
                    case AnalogyLogLevel.Error:
                        LogLevelColors.Add(level, Color.Pink);
                        break;
                    case AnalogyLogLevel.Critical:
                        LogLevelColors.Add(level, Color.Red);
                        break;
                    case AnalogyLogLevel.AnalogyInformation:
                        LogLevelColors.Add(level, Color.White);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Color GetColorForLogLevel(AnalogyLogLevel level) => LogLevelColors[level];

        public Color GetHighlightColor() => HighlightColor;

        public void SetColorForLogLevel(AnalogyLogLevel level, Color value) => LogLevelColors[level] = value;
        public void SetHighlightColor(Color value) => HighlightColor = value;
        public string AsJson() => JsonConvert.SerializeObject(this);
        public static ColorSettings FromJson(string fileName) => JsonConvert.DeserializeObject<ColorSettings>(fileName);
    }

    [Serializable]
    public class FactorySettings
    {
        public string FactoryName { get; set; }
        public Guid FactoryGuid { get; set; }
        public List<string> UserSettingFileAssociations { get; set; }
        public DataProviderFactoryStatus Status { get; set; }

        public FactorySettings()
        {
            UserSettingFileAssociations = new List<string>();
        }
    }

    public enum PreDefinedQueryType
    {
        Contains,
        Equals
    }
    [Serializable]
    public class PreDefinedQueries
    {
        public List<PreDefineHighlight> Highlights { get; set; }

        public List<PreDefineFilter> Filters { get; set; }

        public List<PreDefineAlert> Alerts { get; set; }

        public PreDefinedQueries()
        {
            Highlights = new List<PreDefineHighlight>();
            Filters = new List<PreDefineFilter>();
            Alerts = new List<PreDefineAlert>();
        }

        public void AddHighlight(string text, PreDefinedQueryType type, Color color) => Highlights.Add(new PreDefineHighlight(type, text, color));
        public void AddFilter(string includeText, string excludeText, string sources, string modules) => Filters.Add(new PreDefineFilter(includeText,excludeText,sources,modules));
        public void AddAlert(string includeText, string excludeText, string sources, string modules) => Alerts.Add(new PreDefineAlert(includeText, excludeText, sources, modules));

        public void RemoveHighlight(PreDefineHighlight highlight)
        {
            if (Highlights.Contains(highlight))
                Highlights.Remove(highlight);
        }

        public void RemoveFilter(PreDefineFilter filter)
        {
            if (Filters.Contains(filter))
                Filters.Remove(filter);
        }
        public void RemoveAlert(PreDefineAlert alert)
        {
            if (Alerts.Contains(alert))
                Alerts.Remove(alert);
        }
    }
    [Serializable]
    public class PreDefineHighlight
    {
        public PreDefinedQueryType PreDefinedQueryType { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }

        public PreDefineHighlight(PreDefinedQueryType preDefinedQueryType, string text, Color color)
        {
            PreDefinedQueryType = preDefinedQueryType;
            Text = text ?? string.Empty;
            Color = color;
        }
        public override string ToString()
        {
            return $"Highlight: {Text}. Type:{PreDefinedQueryType}. Color:{Color}";
        }
    }

    [Serializable]
    public class PreDefineFilter
    {
        public string IncludeText { get; }
        public string ExcludeText { get; }
        public string Sources { get; }
        public string Modules { get; }


        public PreDefineFilter(string includeText, string excludeText, string sources, string modules)
        {
            IncludeText = includeText ?? string.Empty;
            ExcludeText = excludeText ?? string.Empty;
            Sources = sources ?? string.Empty;
            Modules = modules ?? string.Empty;
        }
        public override string ToString()
        {
            return $"Filter: Message Text:{IncludeText}. Exclude:{ExcludeText}. Sources:{Sources}. Modules:{Modules}";
        }
    }

    [Serializable]
    public class PreDefineAlert
    {
        public string IncludeText { get; }
        public string ExcludeText { get; }
        public string Sources { get; }
        public string Modules { get; }


        public PreDefineAlert(string includeText, string excludeText, string sources, string modules)
        {
            IncludeText = includeText ?? string.Empty;
            ExcludeText = excludeText ?? string.Empty;
            Sources = sources ?? string.Empty;
            Modules = modules ?? string.Empty;
        }
        public override string ToString()
        {
            return $"Alert: Message Text:{IncludeText}. Exclude:{ExcludeText}. Sources:{Sources}. Modules:{Modules}";
        }
    }
}

