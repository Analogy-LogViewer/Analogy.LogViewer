using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Interfaces;
using Newtonsoft.Json;

namespace Analogy.CommonControls.DataTypes
{
    public enum DataProviderFactoryStatus
    {
        NotSet,
        Enabled,
        Disabled
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

    [Serializable]
    public class ColorSettings
    {
        public bool EnableMessagesColors { get; set; }
        public Dictionary<AnalogyLogLevel, (Color BackgroundColor, Color TextColor)> LogLevelColors { get; set; }

        public (Color BackgroundColor, Color TextColor) HighlightColor { get; set; }
        public (Color BackgroundColor, Color TextColor) NewMessagesColor { get; set; }
        public bool EnableNewMessagesColor { get; set; }
        public bool OverrideLogLevelColor { get; set; }

        public ColorSettings()
        {
            EnableMessagesColors = true;
            HighlightColor = (Color.Aqua, Color.Black);
            NewMessagesColor = (Color.PaleTurquoise, Color.Black);
            var logLevelValues = Enum.GetValues(typeof(AnalogyLogLevel));
            LogLevelColors = new Dictionary<AnalogyLogLevel, (Color BackgroundColor, Color TextColor)>(logLevelValues.Length);

            foreach (AnalogyLogLevel level in logLevelValues)

            {
                switch (level)
                {
                    case AnalogyLogLevel.Unknown:
                        LogLevelColors.Add(level, (Color.White, Color.Black));
                        break;
                    case AnalogyLogLevel.None:
                        LogLevelColors.Add(level, (Color.LightGray, Color.Black));
                        break;
                    case AnalogyLogLevel.Trace:
                        LogLevelColors.Add(level, (Color.White, Color.Black));
                        break;
                    case AnalogyLogLevel.Verbose:
                        LogLevelColors.Add(level, (Color.White, Color.Black));
                        break;
                    case AnalogyLogLevel.Debug:
                        LogLevelColors.Add(level, (Color.White, Color.Black));
                        break;
                    case AnalogyLogLevel.Information:
                        LogLevelColors.Add(level, (Color.White, Color.Black));
                        break;
                    case AnalogyLogLevel.Warning:
                        LogLevelColors.Add(level, (Color.Yellow, Color.Black));
                        break;
                    case AnalogyLogLevel.Error:
                        LogLevelColors.Add(level, (Color.Pink, Color.Black));
                        break;
                    case AnalogyLogLevel.Critical:
                        LogLevelColors.Add(level, (Color.Red, Color.Black));
                        break;
                    case AnalogyLogLevel.Analogy:
                        LogLevelColors.Add(level, (Color.White, Color.Black));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (Color BackgroundColor, Color TextColor) GetColorForLogLevel(AnalogyLogLevel level) => LogLevelColors[level];

        public (Color BackgroundColor, Color TextColor) GetHighlightColor() => HighlightColor;
        public (Color BackgroundColor, Color TextColor) GetNewMessagesColor() => NewMessagesColor;

        public void SetColorForLogLevel(AnalogyLogLevel level, Color backgroundColor, Color textColor) => LogLevelColors[level] = (backgroundColor, textColor);
        public void SetHighlightColor(Color backgroundColor, Color textColor) => HighlightColor = (backgroundColor, textColor);
        public void SetNewMessagesColor(Color backgroundColor, Color textColor) => NewMessagesColor = (backgroundColor, textColor);
        public string AsJson() => JsonConvert.SerializeObject(this);
        public static ColorSettings FromJson(string fileName) => JsonConvert.DeserializeObject<ColorSettings>(fileName);
    }

    [Serializable]
    public class FactorySettings
    {
        public string FactoryName { get; set; }
        public Guid FactoryId { get; set; }
        public List<string> UserSettingFileAssociations { get; set; }
        public DataProviderFactoryStatus Status { get; set; }

        public FactorySettings()
        {
            UserSettingFileAssociations = new List<string>();
        }
        public override string ToString() => $"{nameof(FactoryName)}: {FactoryName}, {nameof(FactoryId)}: {FactoryId}, {nameof(Status)}: {Status}";

    }
    [Serializable]
    public class OnDemandPlottingFactorySettings
    {
        public Guid FactoryId { get; set; }
        public DataProviderFactoryStatus Status { get; set; }

        public OnDemandPlottingFactorySettings()
        {
        }
        public override string ToString() => $"{nameof(FactoryId)}: {FactoryId}, {nameof(Status)}: {Status}";

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
        public void AddFilter(string name, string includeText, string excludeText, string sources, string modules) => Filters.Add(new PreDefineFilter(name, includeText, excludeText, sources, modules));
        public void AddAlert(string includeText, string excludeText, string sources, string modules) => Alerts.Add(new PreDefineAlert(includeText, excludeText, sources, modules));

        public void RemoveHighlight(PreDefineHighlight highlight)
        {
            if (Highlights.Contains(highlight))
            {
                Highlights.Remove(highlight);
            }
        }

        public void RemoveFilter(PreDefineFilter filter)
        {
            if (Filters.Contains(filter))
            {
                Filters.Remove(filter);
            }
        }
        public void RemoveAlert(PreDefineAlert alert)
        {
            if (Alerts.Contains(alert))
            {
                Alerts.Remove(alert);
            }
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
        public string Name { get; set; }
        public string IncludeText { get; }
        public string ExcludeText { get; }
        public string Sources { get; }
        public string Modules { get; }


        public PreDefineFilter(string name, string includeText, string excludeText, string sources, string modules)
        {
            Name = name ?? string.Empty;
            IncludeText = includeText ?? string.Empty;
            ExcludeText = excludeText ?? string.Empty;
            Sources = sources ?? string.Empty;
            Modules = modules ?? string.Empty;
        }
        public override string ToString()
        {
            return $"Filter: Message Text:{IncludeText}. Exclude:{ExcludeText}. Sources:{Sources}. Modules:{Modules}";
        }

        public string NiceText() =>
            $"Message Text: {IncludeText}{Environment.NewLine}Exclude Text: {ExcludeText}{Environment.NewLine}Sources: {Sources}{Environment.NewLine}Module: {Modules}";

    }

    [Serializable]
    public class FontSettings
    {
        public FontSelectionType FontSelectionType { get; set; }
        public FontSelectionType MenuFontSelectionType { get; set; }
        public float GridFontSize { get; set; }
        public string FontName { get; set; }
        public float FontSize { get; set; }
        [JsonIgnore] public Font UIFont => new Font(FontName, FontSize, FontStyle.Regular, GraphicsUnit.Point);
        public string MenuFontName { get; set; }
        public float MenuFontSize { get; set; }

        [JsonIgnore]
        public Font MenuFont => new Font(MenuFontName, MenuFontSize, FontStyle.Regular, GraphicsUnit.Point);

        public FontSettings()
        {
            GridFontSize = 8.5f;
            SetFontSelectionType(FontSelectionType.Default);
            SetMenuFontSelectionType(FontSelectionType.Normal);
        }

        public void SetFontSelectionType(FontSelectionType mode)
        {
            FontSelectionType = mode;
            FontName = "Tahoma";
            switch (mode)
            {
                case FontSelectionType.Default:
                    FontSize = 8.25f;
                    break;
                case FontSelectionType.Normal:
                    FontSize = 10f;
                    break;
                case FontSelectionType.Large:
                    FontSize = 12f;
                    break;
                case FontSelectionType.VeryLarge:
                    FontSize = 14f;
                    break;
                default:
                    FontSize = 8.25f;
                    break;
            }
        }

        public Font GetFontType(FontSelectionType mode)
        {
            var fontName = "Tahoma";
            float fontSize;
            switch (mode)
            {
                case FontSelectionType.Default:
                    fontSize = 8.25f;
                    break;
                case FontSelectionType.Normal:
                    fontSize = 10f;
                    break;
                case FontSelectionType.Large:
                    fontSize = 12f;
                    break;
                case FontSelectionType.VeryLarge:
                    fontSize = 14f;
                    break;
                default:
                    fontSize = 8.25f;
                    break;
            }
            return new Font(fontName, fontSize, FontStyle.Regular, GraphicsUnit.Point);

        }
        public void SetMenuFontSelectionType(FontSelectionType mode)
        {
            MenuFontSelectionType = mode;
            MenuFontName = "Segoe UI";
            switch (mode)
            {
                case FontSelectionType.Default:
                    MenuFontSize = 12f;
                    break;
                case FontSelectionType.Normal:
                    MenuFontSize = 10f;
                    break;
                case FontSelectionType.Large:
                    MenuFontSize = 14f;
                    break;
                case FontSelectionType.VeryLarge:
                    MenuFontSize = 16f;
                    break;
                default:
                    MenuFontSize = 12f;
                    break;
            }
        }

        public Font GetMenuFont(FontSelectionType mode)
        {
            var menuFontName = "Segoe UI";
            float menuFontSize;
            switch (mode)
            {
                case FontSelectionType.Default:
                    menuFontSize = 12f;
                    break;
                case FontSelectionType.Normal:
                    menuFontSize = 10f;
                    break;
                case FontSelectionType.Large:
                    menuFontSize = 14f;
                    break;
                case FontSelectionType.VeryLarge:
                    menuFontSize = 16f;
                    break;
                default:
                    menuFontSize = 12f;
                    break;
            }
            return new Font(menuFontName, menuFontSize, FontStyle.Regular, GraphicsUnit.Point);
        }
    }

    [Serializable]
    public class FilteringExclusion
    {
        public List<string> ExcludeTexts { get; set; }
        public List<string> ExcludeSources { get; set; }
        public List<string> ExcludeModules { get; set; }
        public Dictionary<string, bool> ExcludeLogLevels { get; set; }


        public FilteringExclusion()
        {
            ExcludeTexts = new List<string>();
            ExcludeModules = new List<string>();
            ExcludeSources = new List<string>();
            ExcludeLogLevels = new Dictionary<string, bool>();
            foreach (string value in Utils.LogLevels)
            {
                ExcludeLogLevels.Add(value, false);
            }
        }

        public bool IsLogLevelExcluded(AnalogyLogLevel level) => IsLogLevelExcluded(level.ToString());
        public bool IsLogLevelExcluded(string level) => ExcludeLogLevels.ContainsKey(level) && ExcludeLogLevels[level];

        public void SetLogLevelExclusion(string level, bool exclude) => ExcludeLogLevels[level] = exclude;
    }
    [Serializable]
    public class AnalogyPositionState
    {
        public FormWindowState WindowState { get; set; }
        public Point Location { get; set; }
        public Size Size { get; set; }
        public bool RememberLastPosition { get; set; }

        public AnalogyPositionState()
        {
            WindowState = FormWindowState.Maximized;
            RememberLastPosition = true;
        }

        public AnalogyPositionState(FormWindowState formWindowState, Point location, Size size)
        {
            WindowState = formWindowState;
            Location = location;
            Size = size;
        }

    }
    
    public enum DataSourceType
    {
        Client,
        Server,
        NetworkPath,
        LocalPath
    }

    [Serializable]
    public class DataSource
    {
        public string HostNameOrIP { get; set; }
        public string Path { get; set; }
        public DataSourceType Type { get; set; }
        public string DisplayName { get; set; }

        public DataSource(string hostNameOrIp, string path, string displayName, DataSourceType type)
        {
            HostNameOrIP = hostNameOrIp ?? throw new ArgumentNullException(nameof(hostNameOrIp));
            Path = path ?? throw new ArgumentNullException(nameof(path));
            Type = type;
            DisplayName = !string.IsNullOrEmpty(displayName) ? displayName : hostNameOrIp;
        }

        public override string ToString()
        {
            return $"{DisplayName} ({Type})";
        }
    }
}