using Analogy.DataTypes;
using Analogy.Managers;
using Analogy.UserControls;
using DevExpress.XtraEditors;
using System.IO;
using System.Windows.Forms;
using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.Interfaces;

namespace Analogy.Forms
{
    public partial class ComponentDownloadsForm : XtraForm
    {
        private IFactoriesManager FactoriesManager { get; }

        public ComponentDownloadsForm(IFactoriesManager factoriesManager)
        {
            FactoriesManager = factoriesManager;
            InitializeComponent();
        }

        private void ComponentDownloadsForm_Load(object sender, EventArgs e)
        {
            Icon = ServicesProvider.Instance.GetService<IAnalogyUserSettings>().GetIcon();
            // UserControl first = null;
            foreach (FactoryContainer factory in FactoriesManager.Factories)
            {
                ComponentDownloadInformationUC uc = new ComponentDownloadInformationUC(factory);
                xtraTabPage1.Controls.Add(uc);
                uc.Dock = DockStyle.Top;
                //  first ??= uc;

            }

            var assemblies = FactoriesManager.Factories.Select(f => Path.GetFileName(f.AssemblyFullPath)).ToList();
            var supported = UpdateManager.Instance.SupportedDataProviders;
            var notInstalled = supported.Where(s => !assemblies.Contains(s.AssemblyFileName, StringComparison.InvariantCultureIgnoreCase)).ToList();

            foreach (var dp in notInstalled)
            {
                MissingDownloadInformation missing = new MissingDownloadInformation(dp.FactoryId, dp.Name, dp.RepositoryURL, dp.Image);
                ComponentDownloadInformationUC uc = new ComponentDownloadInformationUC(missing);
                uc.Enabled = dp.Enabled;
                xtraTabPage2.Controls.Add(uc);
                uc.Dock = DockStyle.Top;

            }
        }
    }
}
