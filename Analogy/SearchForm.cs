using DevExpress.XtraEditors;
using Philips.Analogy.Interfaces.Interfaces;

namespace Philips.Analogy
{
    public partial class SearchForm : XtraForm
    {
        private IAnalogyOfflineDataSource offlineAnalogy;

        private SearchForm()
        {
            InitializeComponent();
        }

        public SearchForm(IAnalogyOfflineDataSource offlineAnalogy):this()
        {
            this.offlineAnalogy = offlineAnalogy;
            searchInFilesUC1.SetDataSource(offlineAnalogy);
        }
    }
}
