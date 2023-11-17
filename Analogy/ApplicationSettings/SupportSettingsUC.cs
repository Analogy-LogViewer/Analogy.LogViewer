using DevExpress.XtraEditors;

namespace Analogy.ApplicationSettings
{
    public partial class SupportSettingsUC : XtraUserControl
    {
        public SupportSettingsUC()
        {
            InitializeComponent();
        }

        private void SupportSettings_Load(object sender, EventArgs e)
        {
        }

        private void OpenLink(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            ((HyperlinkLabelControl)sender).LinkVisited = true;
            Utils.OpenLink(e.Link);
        }
    }
}