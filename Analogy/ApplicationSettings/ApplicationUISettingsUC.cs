using Analogy.DataTypes;
using Analogy.Properties;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Drawing;
using System.Windows.Forms;
using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.CommonControls.DataTypes;
using Analogy.CommonControls.Interfaces;
using Analogy.Interfaces;
using DevExpress.XtraEditors;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Analogy.ApplicationSettings
{
    public partial class ApplicationUISettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; } = UserSettingsManager.UserSettings;

        public ApplicationUISettingsUC()
        {
            InitializeComponent();
        }

        private void ApplicationUISettingsUC_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;

            }

            LoadSettings();
            UpdateUI();
            SetupEventsHandlers();
        }

        private void SetupEventsHandlers()
        {
            UserLookAndFeel.Default.StyleChanged += (s, e) =>
            {
                UserLookAndFeel laf = (UserLookAndFeel)s;
                lblSkinName.Text = "Skin name: " + laf.ActiveSkinName;
                lblApplicationStyle.Text = "Application style: " + laf.Style;
                lblSvgPalette.Text = "Active Svg Palette: " + laf.ActiveSvgPaletteName;

            };
            tsStartupRibbonMinimized.Toggled +=
                (s, e) => Settings.StartupRibbonMinimized = tsStartupRibbonMinimized.IsOn;
            tsRibbonCompactStyle.IsOnChanged += (s, e) =>
            {
                Settings.RibbonStyle = tsRibbonCompactStyle.IsOn
                    ? AnalogyCommandLayout.Simplified
                    : AnalogyCommandLayout.Classic;
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
            ceFluentForm.CheckStateChanged += (s, e) =>
            {
                if (ceFluentForm.CheckState == CheckState.Checked)
                {
                    Settings.MainFormType = MainFormType.FluentForm;
                }
            };
            ceRibbonForm.CheckStateChanged += (s, e) =>
            {
                if (ceRibbonForm.CheckState == CheckState.Checked)
                {
                    Settings.MainFormType = MainFormType.RibbonForm;
                }
            };
            fontEditControl.EditValueChanged += (s, e) => SetFonts();
            fontEditMenus.EditValueChanged += (s, e) => SetFonts();
            
        }



        private void LoadSettings()
        {
            ceRibbonForm.CheckState = Settings.MainFormType == MainFormType.RibbonForm
                ? CheckState.Checked
                : CheckState.Unchecked;
            ceFluentForm.CheckState = Settings.MainFormType == MainFormType.FluentForm
                ? CheckState.Checked
                : CheckState.Unchecked;
            lblSkinName.Text = "Skin name: " + Settings.ApplicationSkinName;
            lblApplicationStyle.Text = "Application style: " + Settings.ApplicationStyle;
            lblSvgPalette.Text = "Active Svg Palette: " + Settings.ApplicationSvgPaletteName;
            tsRememberLastPositionAndState.IsOn = Settings.AnalogyPosition.RememberLastPosition;
            tsStartupRibbonMinimized.IsOn = Settings.StartupRibbonMinimized;
            tsRibbonCompactStyle.IsOn = Settings.RibbonStyle == AnalogyCommandLayout.Simplified;
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
            ceFontsDefault.Font = Settings.FontSettings.GetFontType(FontSelectionType.Default);
            ceFontsNormal.Font = Settings.FontSettings.GetFontType(FontSelectionType.Normal);
            ceFontsLarge.Font = Settings.FontSettings.GetFontType(FontSelectionType.Large);
            ceFontsVeryLarge.Font = Settings.FontSettings.GetFontType(FontSelectionType.VeryLarge);
            ceContextMenuFontsDefault.Font = Settings.FontSettings.GetMenuFont(FontSelectionType.Default);
            ceContextMenuFontsNormal.Font = Settings.FontSettings.GetMenuFont(FontSelectionType.Normal);
            ceContextMenuFontsLarge.Font = Settings.FontSettings.GetMenuFont(FontSelectionType.Large);
            ceContextMenuFontsVeryLarge.Font = Settings.FontSettings.GetMenuFont(FontSelectionType.VeryLarge);

            fontEditControl.Font = WindowsFormsSettings.DefaultFont;
            fontEditControl.EditValue = WindowsFormsSettings.DefaultFont.Name;
            fontEditMenus.Font = WindowsFormsSettings.DefaultMenuFont;
            fontEditMenus.EditValue = WindowsFormsSettings.DefaultMenuFont.Name;
        }

        private void SetFonts()
        {
            string controlFont = fontEditControl.EditValue as string;
            string menuFont = fontEditMenus.EditValue as string;


            if (ceFontsDefault.Checked)
            {
                Settings.FontSettings.SetFontSelectionType(FontSelectionType.Default, controlFont);
            }
            else if (ceFontsNormal.Checked)
            {
                Settings.FontSettings.SetFontSelectionType(FontSelectionType.Normal, controlFont);
            }

            else if (ceFontsLarge.Checked)
            {
                Settings.FontSettings.SetFontSelectionType(FontSelectionType.Large, controlFont);
            }

            else if (ceFontsVeryLarge.Checked)
            {
                Settings.FontSettings.SetFontSelectionType(FontSelectionType.VeryLarge, menuFont);
            }

            if (ceContextMenuFontsDefault.Checked)
            {
                Settings.FontSettings.SetMenuFontSelectionType(FontSelectionType.Default, menuFont);
            }
            else if (ceContextMenuFontsNormal.Checked)
            {
                Settings.FontSettings.SetMenuFontSelectionType(FontSelectionType.Normal, menuFont);
            }

            else if (ceContextMenuFontsLarge.Checked)
            {
                Settings.FontSettings.SetMenuFontSelectionType(FontSelectionType.Large, menuFont);
            }

            else if (ceContextMenuFontsVeryLarge.Checked)
            {
                Settings.FontSettings.SetMenuFontSelectionType(FontSelectionType.VeryLarge, WindowsFormsSettings.DefaultMenuFont.Name);
            }

            WindowsFormsSettings.DefaultFont = new Font(controlFont, Settings.FontSettings.FontSize);
            WindowsFormsSettings.DefaultMenuFont = new Font(menuFont, Settings.FontSettings.MenuFontSize);
            UpdateUI();

        }

        private void UpdateUI()
        {
            ceFontsDefault.Font = WindowsFormsSettings.DefaultFont;
            ceFontsNormal.Font = WindowsFormsSettings.DefaultFont;
            ceFontsLarge.Font = WindowsFormsSettings.DefaultFont;
            ceFontsVeryLarge.Font = WindowsFormsSettings.DefaultFont;

            ceContextMenuFontsDefault.Font = WindowsFormsSettings.DefaultMenuFont;
            ceContextMenuFontsDefault.Font = WindowsFormsSettings.DefaultMenuFont;
            ceContextMenuFontsLarge.Font = WindowsFormsSettings.DefaultMenuFont;
            ceContextMenuFontsVeryLarge.Font = WindowsFormsSettings.DefaultMenuFont;
        }
    }
}
