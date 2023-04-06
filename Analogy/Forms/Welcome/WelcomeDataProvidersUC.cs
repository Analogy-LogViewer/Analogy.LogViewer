
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

        private void hllcDataProviders_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            ((HyperlinkLabelControl)sender).LinkVisited = true;
            Utils.OpenLink(e.Link);
        }
    }
}
