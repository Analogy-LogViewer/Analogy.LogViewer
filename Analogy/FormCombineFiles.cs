using DevExpress.XtraEditors;
using Philips.Analogy.Interfaces.Interfaces;

namespace Philips.Analogy
{
    public partial class FormCombineFiles : XtraForm
    {
        private IAnalogyOfflineDataSource offlineAnalogy;

        private FormCombineFiles()
        {
            InitializeComponent();
        }

        public FormCombineFiles(IAnalogyOfflineDataSource offlineAnalogy):this()
        {
            this.offlineAnalogy = offlineAnalogy;
            combineFilesUC1.SetDataSource(offlineAnalogy);
        }
    }
}
