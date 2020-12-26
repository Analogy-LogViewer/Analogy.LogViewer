using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy.UserControls
{
    public partial class DataProviderUC : XtraUserControl
    {
        private IExtensionsManager ExtensionManager { get; set; } = ExtensionsManager.Instance;
        public DataProviderUC()
        {
            InitializeComponent();
        }

        private void DataProviderUC_Load(object sender, EventArgs e)
        {
        }
    }
}
