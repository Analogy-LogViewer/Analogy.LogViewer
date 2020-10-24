using Analogy.Managers;
using Analogy.UserControls;
using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace Analogy.Forms
{
    public partial class ComponentDownloadsForm : XtraForm
    {
        public ComponentDownloadsForm()
        {
            InitializeComponent();
        }

        private void ComponentDownloadsForm_Load(object sender, EventArgs e)
        {
            Icon = UserSettingsManager.UserSettings.GetIcon();
            foreach (FactoryContainer factory in FactoriesManager.Instance.Factories)
            {
                ComponentDownloadInformationUC uc = new ComponentDownloadInformationUC(factory);
                panelComponents.Controls.Add(uc);
                uc.Dock = DockStyle.Top;
            }
        }
    }
}
