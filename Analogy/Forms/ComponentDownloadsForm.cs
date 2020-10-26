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
           // UserControl first = null;
            foreach (FactoryContainer factory in FactoriesManager.Instance.Factories)
            {
                ComponentDownloadInformationUC uc = new ComponentDownloadInformationUC(factory);
                xtraTabPage1.Controls.Add(uc);
                uc.Dock = DockStyle.Top;
              //  first ??= uc;

            }
           // panel1.ScrollControlIntoView(first);
        }
    }
}
