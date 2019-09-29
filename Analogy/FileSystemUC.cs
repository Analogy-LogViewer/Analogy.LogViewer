using Philips.Analogy.Interfaces.Interfaces;
using Philips.Analogy.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Philips.Analogy
{
    public partial class FileSystemUC : UserControl
    {
        private IAnalogyOfflineDataSource _dataSource;
        public event EventHandler<SelectionEventArgs> SelectionChanged;
        public bool ZipFilesOnly { get; set; }

        public IAnalogyOfflineDataSource DataSource
        {
            get => _dataSource;
            set
            {
                _dataSource = value;
                if (value != null)
                {
                    tvFolderUC.SetFolder(value.InitialFolderFullPath, _dataSource);
                }
            }
        }

        public FileSystemUC()
        {
            InitializeComponent();
            tvFolderUC.FolderChanged += TvFolderUC_FolderChanged;
        }

        private void TvFolderUC_FolderChanged(object sender, FolderSelectionEventArgs e)
        {
            lBoxFiles.SelectedIndexChanged -= lBoxFiles_SelectedIndexChanged;
            DirectoryInfo dirInfo = new DirectoryInfo(e.SelectedFolderPath);
            bool recursive = checkEditRecursiveLoad.Checked;
            List<FileInfo> fileInfos = (ZipFilesOnly ? dirInfo.GetFiles("*.zip").ToList() : DataSource.GetSupportedFiles(dirInfo, recursive)).OrderByDescending(f => f.LastWriteTime).ToList();
            lBoxFiles.DisplayMember = recursive ? "FullName" : "Name";
            lBoxFiles.DataSource = fileInfos;
            lBoxFiles.SelectedIndexChanged += lBoxFiles_SelectedIndexChanged;
            SelectionChangedNotify();

        }
        private void lBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectionChangedNotify();
        }

        private void SelectionChangedNotify()
        {
            SelectionChanged?.Invoke(this,
                new SelectionEventArgs(lBoxFiles.SelectedItems.Cast<FileInfo>().Select(f => f.FullName).ToList()));
        }
        public List<string> GetSelectedFileNames() =>
            lBoxFiles.SelectedItems.Cast<FileInfo>().Select(f => f.FullName).ToList();

        private void bBtnOpen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lBoxFiles.SelectedItem != null)
            {
                var filename = (lBoxFiles.SelectedItem as FileInfo)?.FullName;
                if (filename == null || !File.Exists(filename)) return;
                Process.Start("explorer.exe", "/select, \"" + filename + "\"");
            }
        }
    }

}
