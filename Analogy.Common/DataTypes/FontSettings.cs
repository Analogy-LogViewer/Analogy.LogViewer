using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Common.DataTypes
{
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
            SetFontSelectionType(FontSelectionType.Default, "Tahoma");
            SetMenuFontSelectionType(FontSelectionType.Normal, "Segoe UI");
        }

        public void SetFontSelectionType(FontSelectionType mode,string fontName)
        {
            FontSelectionType = mode;
            FontName = fontName;
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
            return new Font(FontName, fontSize, FontStyle.Regular, GraphicsUnit.Point);

        }
        public void SetMenuFontSelectionType(FontSelectionType mode,string fontName)
        {
            MenuFontSelectionType = mode;
            MenuFontName = fontName;
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
            return new Font(MenuFontName, menuFontSize, FontStyle.Regular, GraphicsUnit.Point);
        }
    }
}