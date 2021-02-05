using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Analogy.Interfaces;

namespace Analogy.DataTypes
{
    public struct FactoryCheckItem
    {
        public string Name { get; }
        public Guid ID { get; }
        public string Description { get; }
        public Image? Image { get; }

        public FactoryCheckItem(string name, Guid id, string description, Image? image)
        {
            Name = name;
            ID = id;
            Description = description;
            Image = image;
        }

        public override string ToString() => $"{Name} ({ID})";
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

    [Serializable]
    public class FilterCriteriaUIOption
    {
        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }
        public bool CheckMember { get; set; }


        public FilterCriteriaUIOption(string displayMember, string valueMember, bool checkMember)
        {
            DisplayMember = displayMember;
            ValueMember = valueMember;
            CheckMember = checkMember;
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

        public void SetLogLevelExclusion(string level, bool exclude)=> ExcludeLogLevels[level] = exclude;
        
    }
}
