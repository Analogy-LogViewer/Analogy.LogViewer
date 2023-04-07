using Analogy.Properties;
using DevExpress.XtraEditors;

namespace Analogy.Forms.Welcome
{
    public partial class WelcomeWhatIsNewUC : XtraUserControl
    {
        public WelcomeWhatIsNewUC()
        {
            InitializeComponent();
        }

        private void WelcomeWhatIsNewUC_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            richEditControl1.HtmlText = Resources.ReleaseInformation;
        }
    }
}
