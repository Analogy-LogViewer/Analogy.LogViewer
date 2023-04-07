using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Analogy.Forms.Welcome
{
    public partial class WelcomeShareAndSupportUC : UserControl
    {
        public WelcomeShareAndSupportUC()
        {
            InitializeComponent();
        }

        private void OpenLink(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            ((HyperlinkLabelControl)sender).LinkVisited = true;
            Utils.OpenLink(e.Link);
        }
    }
}
