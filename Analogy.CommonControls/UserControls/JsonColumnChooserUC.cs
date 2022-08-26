using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Pdf.Native.BouncyCastle.Utilities;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace Analogy.CommonControls.UserControls
{
    public partial class JsonColumnChooserUC : XtraUserControl
    {
        public event EventHandler<string> SelectionChanged;
        private string selection = "";
        public JsonColumnChooserUC()
        {
            InitializeComponent();
        }


        private void LookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            selection = (string)comboBoxEdit1.EditValue;
        }

        public void SetNames(List<string> names)
        {
            comboBoxEdit1.EditValueChanged -= LookUpEdit1_EditValueChanged;

            comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit1.Properties.Items.AddRange(names);
            if (names.Any())
            {
                comboBoxEdit1.EditValue = names.First();
            }
            comboBoxEdit1.EditValueChanged += LookUpEdit1_EditValueChanged;

        }

        private void sbtnOK_Click(object sender, EventArgs e)
        {
            SelectionChanged?.Invoke(this, selection);
            PopupControlContainer control = this.Parent as PopupControlContainer;
            control?.HidePopup();
        }

        private void sbtnCancel_Click(object sender, EventArgs e)
        {
            SelectionChanged?.Invoke(this, "");
            PopupControlContainer control = this.Parent as PopupControlContainer;
            control?.HidePopup();
        }
    }
}
