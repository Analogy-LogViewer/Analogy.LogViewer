using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.UserControls;
using DevExpress.XtraEditors;

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
