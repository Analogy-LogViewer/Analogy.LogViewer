using Analogy.UserControls;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Analogy.Forms
{
    public partial class CompareTextForm : XtraForm
    {
        public CompareTextForm()
        {
            InitializeComponent();
        }

        private void CompareTextForm_Load(object sender, EventArgs e)
        {
            CompareTextUC uc = new CompareTextUC();
            Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
    }
}
