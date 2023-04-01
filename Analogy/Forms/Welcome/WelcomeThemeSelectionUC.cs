using Analogy.Interfaces;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;

namespace Analogy.Forms.Welcome
{
    public partial class WelcomeThemeSelectionUC : XtraUserControl
    {
        private IAnalogyUserSettings Settings => UserSettingsManager.UserSettings;

        public WelcomeThemeSelectionUC()
        {
            InitializeComponent();
        }

        private void WelcomeThemeSelectionUC_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

           
            lblSkinName.Text = "Skin name: " + Settings.ApplicationSkinName;
            lblApplicationStyle.Text = "Application style: " + Settings.ApplicationStyle;
            lblSvgPalette.Text = "Active Svg Palette: " + Settings.ApplicationSvgPaletteName;

            UserLookAndFeel.Default.StyleChanged += (s, e) =>
            {
                UserLookAndFeel laf = (UserLookAndFeel)s;
                lblSkinName.Text = "Skin name: " + laf.ActiveSkinName;
                lblApplicationStyle.Text = "Application style: " + laf.Style;
                lblSvgPalette.Text = "Active Svg Palette: " + laf.ActiveSvgPaletteName;

            };
        }
    }
}
