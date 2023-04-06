using Analogy.DataTypes;
using DevExpress.XtraEditors;

namespace Analogy.Forms.Welcome
{
    public partial class WelcomeExtensionsUC : XtraUserControl
    {
        public WelcomeExtensionsUC()
        {
            InitializeComponent();
        }

        private void sbtnExtensionsSettings_Click(object sender, EventArgs e)
        {
            ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ExtensionsSettings);
            user.ShowDialog(this);
        }
    }
}
