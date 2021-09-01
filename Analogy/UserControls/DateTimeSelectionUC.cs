using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Analogy.UserControls
{
    public partial class DateTimeSelectionUC : XtraUserControl
    {
        private List<DateTime> Times { get; set; }
        public DateTimeSelectionUC()
        {
            InitializeComponent();
        }

        private void DateTimeSelectionUC_Load(object sender, EventArgs e)
        {

        }

        public void SetTimes(List<DateTime> times)
        {
            Times = times.Distinct().ToList();
            //comboBoxEdit1.ite
        }
    }
}
