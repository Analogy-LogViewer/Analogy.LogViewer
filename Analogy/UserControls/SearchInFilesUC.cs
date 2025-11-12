using Analogy.Interfaces;
using Analogy.Interfaces.WinForms;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Analogy.UserControls
{
    public partial class SearchInFilesUC : XtraUserControl
    {
        private IAnalogyOfflineDataProviderWinForms offlineAnalogy;

        public SearchInFilesUC()
        {
            InitializeComponent();
        }

        private async void sBtnSearch_Click(object sender, EventArgs e)
        {
            sBtnSearch.Enabled = false;
            var files = _folderAndFileSystemUc1.GetSelectedFileNames();
            processFilesUC1.SetFilesToProcess(files);
            await processFilesUC1.ProcessFilesAndSearch(offlineAnalogy, txtbSearch.Text);
            sBtnSearch.Enabled = true;
        }

        public void SetDataSource(IAnalogyOfflineDataProviderWinForms offlineAnalogy)
        {
            this.offlineAnalogy = offlineAnalogy;
            _folderAndFileSystemUc1.DataProvider = offlineAnalogy;
        }
    }
}