using Analogy.Extensions;
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

namespace Analogy.Forms
{
    public partial class GeoLocationForm : XtraForm
    {
        public GeoLocationForm()
        {
            InitializeComponent();
        }

        private void GeoLocationForm_Load(object sender, EventArgs e)
        {
            GeolocationServiceUC uc = new();
            this.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
    }
}