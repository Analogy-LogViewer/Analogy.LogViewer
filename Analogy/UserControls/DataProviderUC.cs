using Analogy.Common.Interfaces;
using Analogy.CommonControls.Interfaces;
using Analogy.DataTypes;
using Analogy.Interfaces;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.UserControls
{
    public partial class DataProviderUC : XtraUserControl, IUserControlWithUCLogs
    {
        private IExtensionsManager ExtensionManager  => ServicesProvider.Instance.GetService<IExtensionsManager>();
        public DataProviderUC()
        {
            InitializeComponent();
        }

        private void DataProviderUC_Load(object sender, EventArgs e)
        {
        }
        public void ShowSecondaryWindow()
        {
            if (ucLogs1 != null)
                ucLogs1.ShowSecondaryWindow();
        }

        public void HideSecondaryWindow()
        {
            if (ucLogs1 != null)
                ucLogs1.HideSecondaryWindow();
        }
    }
}