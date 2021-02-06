using Analogy.DataTypes;
using Analogy.Managers;
using Analogy.UserControls;
using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Linq;
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

            var assemblies = FactoriesManager.Instance.Factories.Select(f => Path.GetFileName(f.AssemblyFullPath)).ToList();
            var supported = UpdateManager.Instance.SupportedDataProviders;
            var notInstalled = supported.Where(s => !assemblies.Contains(s.AssemblyFileName, StringComparison.InvariantCultureIgnoreCase)).ToList();

            foreach (var dp in notInstalled)
            {
                MissingDownloadInformation missing = new MissingDownloadInformation(dp.FactoryId, dp.Name, dp.RepositoryURL,dp.Image);
                ComponentDownloadInformationUC uc = new ComponentDownloadInformationUC(missing);
                xtraTabPage2.Controls.Add(uc);
                uc.Dock = DockStyle.Top;

            }
        }
    }
}
