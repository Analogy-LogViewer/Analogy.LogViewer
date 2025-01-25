using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Controls;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.UserControls
{
    public partial class DateTimeSelectionUC : XtraUserControl
    {
        private List<DateTimeOffset> Times { get; set; }
        public event EventHandler<DateTime> SelectionChanged;
        public DateTimeSelectionUC()
        {
            InitializeComponent();
        }

        private void LookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            SelectionChanged?.Invoke(this, (DateTime)comboBoxEdit1.EditValue);
        }

        public void SetTimes(List<DateTimeOffset> times)
        {
            comboBoxEdit1.EditValueChanged -= LookUpEdit1_EditValueChanged;

            Times = times.Distinct().ToList();
            comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit1.Properties.Items.AddRange(times);
            if (times.Any())
            {
                comboBoxEdit1.EditValue = times.First();
            }
            comboBoxEdit1.EditValueChanged += LookUpEdit1_EditValueChanged;
        }

        private void sbtnOK_Click(object sender, EventArgs e)
        {
            PopupControlContainer control = this.Parent as PopupControlContainer;
            control?.HidePopup();
        }
    }
}