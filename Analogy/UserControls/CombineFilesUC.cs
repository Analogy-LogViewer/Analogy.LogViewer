using System;
using System.Windows.Forms;
using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy
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
            var files = fileSystemUC1.GetSelectedFileNames();
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
            this.fileSystemUC1.DataProvider = offlineAnalogy;
        }


    }
}
