using System;
using System.Drawing;
using System.Windows.Forms;

namespace Philips.Analogy
{
    public partial class UtilityUC : UserControl
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
