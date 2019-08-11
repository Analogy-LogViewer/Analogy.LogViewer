using Philips.Analogy.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Philips.Analogy
{

    public partial class OfflineUCLogs : UserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;
        private List<string> extrenalFiles = new List<string>();
        public string SelectedPath { get; set; }
        private IAnalogyOfflineDataSource DataSource { get; }
        public OfflineUCLogs(string initSelectedPath)
        {
            SelectedPath = initSelectedPath;
            InitializeComponent();
        }

        public OfflineUCLogs(IAnalogyOfflineDataSource dataSource, string[] fileNames=null, string initialSelectedPath = null) : this(initialSelectedPath)
        {
            DataSource = dataSource;
            if (fileNames != null)
                extrenalFiles.AddRange(fileNames);
            ucLogs1.SetFileDataSource(dataSource);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ucLogs1.ProcessCmdKeyFromParent(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private async void OfflineUCLogs_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            folderTreeViewUC1.FolderChanged += FolderTreeViewUC1_FolderChanged;
            spltMain.Panel1Collapsed = false;
            ucLogs1.btswitchRefreshLog.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            ucLogs1.btsAutoScrollToBottom.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (extrenalFiles.Any())
            {
                if (File.Exists(extrenalFiles.First()))
                    SelectedPath = Path.GetDirectoryName(extrenalFiles.First());
            }

            folderTreeViewUC1.SetFolder(SelectedPath);
            PopulateFiles(SelectedPath);

            if (extrenalFiles.Any())
            {
                await LoadFilesAsync(extrenalFiles, false);
            }
        }

        private async void FolderTreeViewUC1_FolderChanged(object sender, Types.FolderSelectionEventArgs e)
        {
            if (Directory.Exists(e.SelectedFolderPath))
            {
                PopulateFiles(e.SelectedFolderPath);
            }
        }

        private void AnalogyUCLogs_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        private async void AnalogyUCLogs_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            await LoadFilesAsync(files.ToList(), chkbSelectionMode.Checked);
        }

        private async void lBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadFilesAsync(lBoxFiles.SelectedItems.Cast<FileInfo>().Select(f => f.FullName).ToList(), chkbSelectionMode.Checked);


        }

        private void PopulateFiles(string folder)
        {
            if (string.IsNullOrEmpty(folder) || !Directory.Exists(folder)) return;
            SelectedPath = folder;
            lBoxFiles.SelectedIndexChanged -= lBoxFiles_SelectedIndexChanged;
            bool recursiveLoad = checkEditRecursiveLoad.Checked;
            DirectoryInfo dirInfo = new DirectoryInfo(folder);
            List<FileInfo> fileInfos = DataSource.GetSupportedFiles(dirInfo, recursiveLoad).ToList();
            //Utils.GetSupportedFiles(dirInfo, recursiveLoad);
            lBoxFiles.DisplayMember = recursiveLoad ? "FullName" : "Name";
            lBoxFiles.DataSource = fileInfos;
            lBoxFiles.SelectedIndexChanged += lBoxFiles_SelectedIndexChanged;

        }

        private async Task LoadFilesAsync(List<string> fileNames, bool clearLog)
        {
            await ucLogs1.LoadFilesAsync(fileNames, clearLog);

        }

        private void bBtnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lBoxFiles.SelectedItem != null)
            {
                var filename = (lBoxFiles.SelectedItem as FileInfo)?.FullName;
                if (filename == null || !File.Exists(filename)) return;
                Process.Start("explorer.exe", "/select, \"" + filename + "\"");
            }
        }

        private void bBtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lBoxFiles.SelectedItem != null)
            {
                var filename = (lBoxFiles.SelectedItem as FileInfo)?.FullName;
                if (filename == null || !File.Exists(filename)) return;
                var result = MessageBox.Show($"Are you sure you want to delete {filename}?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (File.Exists(filename))
                        try
                        {
                            File.Delete(filename);
                            PopulateFiles(SelectedPath);
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, @"Error deleting file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
            }

        }

        private void bBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PopulateFiles(SelectedPath);
        }

        private async void bBtnSelectAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lBoxFiles.DataSource is List<FileInfo> items)
                await LoadFilesAsync(items.Select(f => f.FullName).ToList(), chkbSelectionMode.Checked);
        }
    }

}


