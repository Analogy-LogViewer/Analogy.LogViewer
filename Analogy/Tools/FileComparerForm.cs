using Philips.Analogy.Interfaces.Interfaces;

namespace Philips.Analogy.Tools
{
    public partial class FileComparerForm : DevExpress.XtraEditors.XtraForm
    {
        private IAnalogyOfflineDataSource offlineAnalogy;

        private FileComparerForm()
        {
            InitializeComponent();
        }

        public FileComparerForm(IAnalogyOfflineDataSource offlineAnalogy):this()
        {
            this.offlineAnalogy = offlineAnalogy;
            logsComparerUC1.SetDataSource(offlineAnalogy);
        }
    }
}