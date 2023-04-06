using Analogy.DataTypes;
using Analogy.Interfaces;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;

namespace Analogy.Forms.Welcome
{
    public partial class WelcomeThemeSelectionUC : XtraUserControl
    {

        public WelcomeThemeSelectionUC()
        {
            InitializeComponent();
        }

        private void WelcomeThemeSelectionUC_Load(object sender, EventArgs e)
        {
  

        }

        private void sbtnSettingsTheme_Click(object sender, EventArgs e)
        {
            ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ApplicationUISettings);
            user.ShowDialog(this);
        }
    }
}
