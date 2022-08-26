using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Controls;
using DevExpress.XtraEditors;

namespace Analogy.UserControls
{
    public partial class DateTimeSelectionUC : XtraUserControl
    {
        private List<DateTime> Times { get; set; }
        public event EventHandler<DateTime> SelectionChanged;
        public DateTimeSelectionUC()
        {
            InitializeComponent();
        }

        private void LookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            SelectionChanged?.Invoke(this, (DateTime)lookUpEdit1.EditValue);
        }

        public void SetTimes(List<DateTime> times)
        {
            lookUpEdit1.EditValueChanged -= LookUpEdit1_EditValueChanged;

            Times = times.Distinct().ToList();
            lookUpEdit1.Properties.DataSource = Times;
            if (times.Any())
            {
                lookUpEdit1.EditValue = times.First();
            }
            lookUpEdit1.EditValueChanged += LookUpEdit1_EditValueChanged;

        }

        private void sbtnOK_Click(object sender, EventArgs e)
        {
            PopupControlContainer control = this.Parent as PopupControlContainer;
            control?.HidePopup();
        }

        private void lookUpEdit1_Properties_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = "";
            if (e.Value != null)
            {
                e.DisplayText = e.Value.ToString();
            }
        }
    }
}
