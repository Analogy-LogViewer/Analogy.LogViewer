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

        }

        private void sbtnGithubHistory_Click(object sender, EventArgs e)
        {
            GitHubHistoryForm g = new GitHubHistoryForm();
            g.ShowDialog(this);
        }
    }
}