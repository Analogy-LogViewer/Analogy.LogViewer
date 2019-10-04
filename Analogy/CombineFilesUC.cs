using System;
using System.Windows.Forms;
using Philips.Analogy.Interfaces;

namespace Philips.Analogy
{
    public partial class CombineFilesUC : UserControl
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

            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //if (SystemPaths.SystemType == SystemPaths.SysType.PortalServer)
            //{
            //    saveFileDialog.Filter = "Plain XML log file (*.log)|*.log|JSON file (*.json)|*.json|Zipped XML log file (*.zip)|*.zip|ETW log file (*.etl)|*.etl";
            //}
            //else
            //{
            //    saveFileDialog.Filter = "Plain XML log files (*.log)|*.log|JSON file (*.json)|*.json|Zipped XML log file (*.zip)|*.zip";
            //}

            //var messages = (processFilesUC1.GetMessages());
            //if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            //    if (saveFileDialog.FileName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
            //    {
            //        string tempFileName = Path.GetTempFileName();
            //        using (FileStream flStream = new FileStream(tempFileName, FileMode.Create, FileAccess.ReadWrite,
            //            FileShare.ReadWrite))
            //        {
            //            LogFormatter logFormatter = new 
            //                (flStream);
            //            Saver.SaveData(messages, logFormatter);
            //            logFormatter.Close();
            //        }

            //        using (FileStream flOrigStream = new FileStream(tempFileName, FileMode.Open, FileAccess.Read,
            //            FileShare.ReadWrite))
            //        {
            //            using (FileStream flStream = new FileStream(saveFileDialog.FileName, FileMode.Create,
            //                FileAccess.ReadWrite, FileShare.ReadWrite))
            //            {
            //                ZIPLib.ZIPObject zip =
            //                    new ZIPLib.ZIPObject(flStream, ZIPLib.ZIPObject.ZIPFileOperationEnum.ZIP);
            //                zip.AppendObject(flOrigStream, "file.log");
            //                zip.Finish();

            //                flStream.Flush();
            //            }
            //        }
            //    }
            //    else if (saveFileDialog.FileName.EndsWith(".etl", StringComparison.OrdinalIgnoreCase))
            //    {
            //        int index = saveFileDialog.FileName.LastIndexOf("\\", StringComparison.Ordinal);
            //        string filePath = saveFileDialog.FileName.Substring(0, index) + "\\" + "ETLTempFolder" +
            //                          DateTime.Now.ToString("yyyyMMddHHmmss");
            //        if (Saver.SaveETWData(messages, filePath))
            //        {
            //            string fileName = saveFileDialog.FileName.Substring(index + 1,
            //                saveFileDialog.FileName.Length - (index + 1));
            //            Saver.RenameDynamicalETLFile(filePath, fileName);
            //        }
            //    }
            //    else if (saveFileDialog.FileName.EndsWith(".log"))
            //    {
            //        using (FileStream flStream = new FileStream(saveFileDialog.FileName, FileMode.Create,
            //            FileAccess.ReadWrite, FileShare.ReadWrite))
            //        {
            //            LogFormatter logFormatter = new LogXmlFormatter(flStream);
            //            Saver.SaveData(messages, logFormatter);
            //            logFormatter.Close();
            //        }
            //    }
            //    else if (saveFileDialog.FileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
            //    {
            //        try
            //        {
            //            Saver.ExportToJson(messages, saveFileDialog.FileName);
            //        }
            //        catch (Exception exception)
            //        {
            //            MessageBox.Show(exception.Message, @"Error exporting to Json", MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);
            //        }



            //    }
        }
    

        public void SetDataSource(IAnalogyOfflineDataProvider analogyOfflineDataProvider)
        {
            offlineAnalogy = analogyOfflineDataProvider;
            this.fileSystemUC1.DataProvider = offlineAnalogy;
        }

        
    }
}
