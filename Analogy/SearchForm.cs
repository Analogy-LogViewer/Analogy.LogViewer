using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy
{
    public partial class SearchForm : XtraForm
    {
        private IAnalogyOfflineDataProvider offlineAnalogy;

        private SearchForm()
        {
            InitializeComponent();
        }

        public SearchForm(IAnalogyOfflineDataProvider offlineAnalogy) : this()
        {
            this.offlineAnalogy = offlineAnalogy;
            searchInFilesUC1.SetDataSource(offlineAnalogy);
        }
    }
}
