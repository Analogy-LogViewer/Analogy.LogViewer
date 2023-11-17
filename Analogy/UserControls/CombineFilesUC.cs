using Analogy.Interfaces;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Analogy.UserControls
{
    public partial class CombineFilesUC : XtraUserControl
    {
        private IAnalogyOfflineDataProvider offlineAnalogy;
        public CombineFilesUC()
        {
            InitializeComponent();
        }

        private async void sBtnCombined_Click(object sender, EventArgs e)
        {
            var files = _folderAndFileSystemUc1.GetSelectedFileNames();
            processFilesUC1.SetFilesToProcess(files);
            await processFilesUC1.ProcessFilesAndCombine(offlineAnalogy);
            sBtnSave.Visible = true;
        }

        private async void sBtnSave_Click(object sender, EventArgs e)
        {
            if (offlineAnalogy.CanSaveToLogFile)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = offlineAnalogy.FileOpenDialogFilters;
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    var messages = (processFilesUC1.GetMessages());
                    await offlineAnalogy.SaveAsync(messages, saveFileDialog.FileName);
                }
            }
        }

        public void SetDataSource(IAnalogyOfflineDataProvider analogyOfflineDataProvider)
        {
            offlineAnalogy = analogyOfflineDataProvider;
            this._folderAndFileSystemUc1.DataProvider = offlineAnalogy;
        }
    }
}