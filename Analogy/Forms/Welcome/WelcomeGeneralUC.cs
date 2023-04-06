using Analogy.DataTypes;
using DevExpress.XtraEditors;

namespace Analogy.Forms.Welcome
{
    public partial class WelcomeGeneralUC : XtraUserControl
    {
        public WelcomeGeneralUC()
        {
            InitializeComponent();
        }

        private void sbtnOpenSettings_Click(object sender, EventArgs e)
        {
            ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ApplicationGeneralSettings);
            user.ShowDialog(this);
        }
    }
}
