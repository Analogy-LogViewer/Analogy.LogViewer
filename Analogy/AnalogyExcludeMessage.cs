using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using Philips.Analogy.Interfaces.DataTypes;

namespace Philips.Analogy
{
    public partial class AnalogyExcludeMessage : XtraForm
    {
        public string Exclude { get; set; }
        public AnalogyExcludeMessage()
        {
            InitializeComponent();
        }

        public AnalogyExcludeMessage(AnalogyLogMessage m) : this()
        {
            txtbMessage.Text = m.Text;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Exclude = FilterCriteriaObject.EscapeLikeValue(txtbMessage.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();

        }

        private void sBtnOk_Click(object sender, EventArgs e)
        {
            Exclude = FilterCriteriaObject.EscapeLikeValue(txtbMessage.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void sBtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
