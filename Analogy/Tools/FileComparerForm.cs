using Philips.Analogy.Interfaces;

namespace Philips.Analogy.Tools
{
    public partial class FileComparerForm : DevExpress.XtraEditors.XtraForm
    {
        private IAnalogyOfflineDataProvider offlineAnalogy;

        private FileComparerForm()
        {
            InitializeComponent();
        }

        public FileComparerForm(IAnalogyOfflineDataProvider offlineAnalogy):this()
        {
            this.offlineAnalogy = offlineAnalogy;
            logsComparerUC1.SetDataSource(offlineAnalogy);
        }
    }
}