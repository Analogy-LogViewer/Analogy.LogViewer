
using Analogy.DataTypes;
using DevExpress.XtraEditors;

namespace Analogy.Forms.Welcome
{
    public partial class WelcomeDataProvidersUC : XtraUserControl
    {
        public WelcomeDataProvidersUC()
        {
            InitializeComponent();
        }

        private void sbtnDataProvidersSettings_Click(object sender, EventArgs e)
        {
            ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.DataProvidersSettings);
            user.ShowDialog(this);
        }
    }
}
