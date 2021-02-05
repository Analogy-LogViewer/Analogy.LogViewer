using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.DataTypes;
using Analogy.Properties;
using DevExpress.XtraBars.Ribbon;

namespace Analogy.ApplicationSettings
{
    public partial class ApplicationUISettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

        public ApplicationUISettingsUC()
        {
            InitializeComponent();
            ceFontsDefault.Font = Settings.FontSettings.GetFontType(FontSelectionType.Default);
            ceFontsNormal.Font = Settings.FontSettings.GetFontType(FontSelectionType.Normal);
            ceFontsLarge.Font = Settings.FontSettings.GetFontType(FontSelectionType.Large);
            ceFontsVeryLarge.Font = Settings.FontSettings.GetFontType(FontSelectionType.VeryLarge);
            ceContextMenuFontsDefault.Font = Settings.FontSettings.GetMenuFont(FontSelectionType.Default);
            ceContextMenuFontsNormal.Font = Settings.FontSettings.GetMenuFont(FontSelectionType.Normal);
            ceContextMenuFontsLarge.Font = Settings.FontSettings.GetMenuFont(FontSelectionType.Large);
            ceContextMenuFontsVeryLarge.Font = Settings.FontSettings.GetMenuFont(FontSelectionType.VeryLarge);
        }

        private void ApplicationUISettingsUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }

        private void SetupEventsHandlers()
        {
            tsStartupRibbonMinimized.Toggled +=
                (s, e) => Settings.StartupRibbonMinimized = tsStartupRibbonMinimized.IsOn;
            tsRibbonCompactStyle.IsOnChanged += (s, e) =>
            {
                Settings.RibbonStyle = tsRibbonCompactStyle.IsOn
                    ? CommandLayout.Simplified
                    : CommandLayout.Classic;
            };
            tsRememberLastPositionAndState.IsOnChanged += (s, e) =>
              Settings.AnalogyPosition.RememberLastPosition = tsRememberLastPositionAndState.IsOn;

            ceFontsDefault.CheckedChanged += (s, e) => SetFonts();
            ceFontsNormal.CheckedChanged += (s, e) => SetFonts();
            ceFontsLarge.CheckedChanged += (s, e) => SetFonts();
            ceFontsVeryLarge.CheckedChanged += (s, e) => SetFonts();
            ceContextMenuFontsDefault.CheckedChanged += (s, e) => SetFonts();
            ceContextMenuFontsNormal.CheckedChanged += (s, e) => SetFonts();
            ceContextMenuFontsLarge.CheckedChanged += (s, e) => SetFonts();
            ceContextMenuFontsVeryLarge.CheckedChanged += (s, e) => SetFonts();
            ceIconDark.CheckedChanged += (s, e) =>
            {
                Settings.AnalogyIcon = ceIconLight.Checked ? "Light" : "Dark";
                peAnalogy.Image = ceIconLight.Checked ? Resources.AnalogyLight : Resources.AnalogyDark;

            };
            ceIconLight.CheckedChanged += (s, e) =>
            {
                Settings.AnalogyIcon = ceIconLight.Checked ? "Light" : "Dark";
                peAnalogy.Image = ceIconLight.Checked ? Resources.AnalogyLight : Resources.AnalogyDark;
            };

        }

        private void LoadSettings()
        {
            tsRememberLastPositionAndState.IsOn = Settings.AnalogyPosition.RememberLastPosition;
            tsStartupRibbonMinimized.IsOn = Settings.StartupRibbonMinimized;
            tsRibbonCompactStyle.IsOn = Settings.RibbonStyle == CommandLayout.Simplified;
            switch (Settings.FontSettings.FontSelectionType)
            {
                case FontSelectionType.Default:
                    ceFontsDefault.Checked = true;
                    break;
                case FontSelectionType.Normal:
                    ceFontsNormal.Checked = true;
                    break;
                case FontSelectionType.Large:
                    ceFontsLarge.Checked = true;
                    break;
                case FontSelectionType.VeryLarge:
                    ceFontsVeryLarge.Checked = true;
                    break;
                case FontSelectionType.Manual:
                default:
                    ceFontsDefault.Checked = true;
                    break;
            }
            switch (Settings.FontSettings.MenuFontSelectionType)
            {
                case FontSelectionType.Default:
                    ceContextMenuFontsDefault.Checked = true;
                    break;
                case FontSelectionType.Normal:
                    ceContextMenuFontsNormal.Checked = true;
                    break;
                case FontSelectionType.Large:
                    ceContextMenuFontsLarge.Checked = true;
                    break;
                case FontSelectionType.VeryLarge:
                    ceContextMenuFontsVeryLarge.Checked = true;
                    break;
                case FontSelectionType.Manual:
                default:
                    ceContextMenuFontsDefault.Checked = true;
                    break;

            }
            if (Settings.AnalogyIcon == "Light")
            {
                ceIconLight.Checked = true;
                peAnalogy.Image = Resources.AnalogyLight;
            }
            else
            {
                ceIconDark.Checked = true;
                peAnalogy.Image = Resources.AnalogyDark;
            }
            
        }

        private void SetFonts()
        {
            if (ceFontsDefault.Checked)
            {
                Settings.FontSettings.SetFontSelectionType(FontSelectionType.Default);
            }
            else if (ceFontsNormal.Checked)
            {
                Settings.FontSettings.SetFontSelectionType(FontSelectionType.Normal);
            }

            else if (ceFontsLarge.Checked)
            {
                Settings.FontSettings.SetFontSelectionType(FontSelectionType.Large);
            }

            else if (ceFontsVeryLarge.Checked)
            {
                Settings.FontSettings.SetFontSelectionType(FontSelectionType.VeryLarge);
            }

            if (ceContextMenuFontsDefault.Checked)
            {
                Settings.FontSettings.SetMenuFontSelectionType(FontSelectionType.Default);
            }
            else if (ceContextMenuFontsNormal.Checked)
            {
                Settings.FontSettings.SetMenuFontSelectionType(FontSelectionType.Normal);
            }

            else if (ceContextMenuFontsLarge.Checked)
            {
                Settings.FontSettings.SetMenuFontSelectionType(FontSelectionType.Large);
            }

            else if (ceContextMenuFontsVeryLarge.Checked)
            {
                Settings.FontSettings.SetMenuFontSelectionType(FontSelectionType.VeryLarge);
            }

        }
    }
}
