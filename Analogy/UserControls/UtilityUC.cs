using System.Drawing;
using DevExpress.XtraEditors;

namespace Analogy.UserControls
{
    public partial class UtilityUC : XtraUserControl
    {
        Action Action { get; }
        public UtilityUC()
        {
            InitializeComponent();
        }

        public UtilityUC(Image image, string text, Action action) : this()
        {
            Action = action;
            pictureBox1.Image = image;
            lblText.Text = text;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            Action?.Invoke();
        }
    }
}
