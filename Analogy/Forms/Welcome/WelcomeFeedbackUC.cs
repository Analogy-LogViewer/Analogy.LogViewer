using DevExpress.XtraEditors;

namespace Analogy.Forms.Welcome
{
    public partial class WelcomeFeedbackUC : XtraUserControl
    {
        public WelcomeFeedbackUC()
        {
            InitializeComponent();
        }

        private void WelcomeFeedbackUC_Load(object sender, EventArgs e)
        {
        }

        private void sbtnFeedbackGithubLink_Click(object sender, EventArgs e)
        {
            Utils.OpenLink("https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues/new/choose");
        }
    }
}