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

namespace Analogy.ApplicationSettings
{
    public partial class SupportSettingsUC : XtraUserControl
    {
        public SupportSettingsUC()
        {
            InitializeComponent();
        }

        private void SupportSettings_Load(object sender, EventArgs e)
        {

        }

        private void OpenLink(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            ((HyperlinkLabelControl)sender).LinkVisited = true;
            Utils.OpenLink(e.Link);
        }
    }
}
