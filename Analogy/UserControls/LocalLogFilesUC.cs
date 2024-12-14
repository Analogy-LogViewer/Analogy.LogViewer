using Analogy.DataTypes;
using Analogy.Interfaces;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.UserControls
{
    public partial class LocalLogFilesUC : XtraUserControl, IUserControlWithUCLogs
    {
        private List<string> extrenalFiles = new List<string>();
        public string SelectedPath { get; set; } = string.Empty;
        private IAnalogyOfflineDataProvider DataProvider { get; }
        public ILogMessageCreatedHandler Handler => ucLogs1;

        public LocalLogFilesUC()
        {
            InitializeComponent();
        }
        public LocalLogFilesUC(string initSelectedPath, string? title = null) : this()
        {
            SelectedPath = initSelectedPath ?? string.Empty;
            treeList1.Columns["colChanged"].SortOrder = SortOrder.Descending;
            treeList1.Appearance.HideSelectionRow.Assign(treeList1.ViewInfo.PaintAppearance.FocusedRow);
            ucLogs1.Title = title;
            ucLogs1.SetSaveButtonsVisibility(false);
        }

        public LocalLogFilesUC(IAnalogyOfflineDataProvider dataProvider, string[]? fileNames = null, string? initialSelectedPath = null, string? title = null) : this(initialSelectedPath ?? string.Empty, title: title)
        {
            DataProvider = dataProvider;
            if (fileNames != null)
            {
                extrenalFiles.AddRange(fileNames);
            }

            ucLogs1.SetFileDataSource(dataProvider, dataProvider);
        }

        public LocalLogFilesUC(IAnalogyDataProvider dataProvider, CancellationTokenSource cts) : this()
        {
            ucLogs1.SetFileDataSource(dataProvider, null);
            ucLogs1.CancellationTokenSource = cts;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ucLogs1.ProcessCmdKeyFromParent(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private async void LocalLogFilesUC_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            SetupEventHandlers();
            folderTreeViewUC1.FolderChanged += FolderTreeViewUC1_FolderChanged;
            ucLogs1.HideRefreshAndScrolling();
            if (extrenalFiles.Any())
            {
                if (File.Exists(extrenalFiles.First()))
                {
                    SelectedPath = Path.GetDirectoryName(extrenalFiles.First());
                }
            }

            folderTreeViewUC1.SetFolder(SelectedPath, DataProvider);
            PopulateFiles(SelectedPath);

            if (extrenalFiles.Any())
            {
                await LoadFilesAsync(extrenalFiles, false);
            }
            ucLogs1.OnFocusedRowChanged += UcLogs1_OnFocusedRowChanged;
        }
        private void SetupEventHandlers()
        {
            sbtnLoadCheckedFiles.Click += async (s, e) =>
            {
                var nodes = treeList1.GetAllCheckedNodes().Select(node => (string)node.GetValue(colFullPath)).ToList();
                await LoadFilesAsync(nodes, chkbSelectionMode.Checked);
            };
            ucLogs1.CollapseFileAndFolderPanel += (s, collapsed) =>
            {
                spltMain.CollapsePanel = collapsed ? SplitCollapsePanel.Panel1 : SplitCollapsePanel.None;
                spltMain.PanelVisibility = collapsed ? SplitPanelVisibility.Panel2 : SplitPanelVisibility.Both;
            };
            ucLogs1.ApplyCollapseFileAndFolderSettings();
        }
        private void UcLogs1_OnFocusedRowChanged(object sender, (string File, AnalogyLogMessage Arg) data)
        {
            if (data.File is null)
            {
                return;
            }
            var t = treeList1.Nodes.FirstOrDefault(n => data.File.Contains(n["Path"].ToString(), StringComparison.InvariantCultureIgnoreCase));
            if (t != null && treeList1.FocusedNode != t)
            {
                treeList1.SelectionChanged -= TreeList1_SelectionChanged;
                treeList1.Selection.Clear();
                treeList1.FocusedNode = null;
                t.Selected = true;
                treeList1.SetFocusedNode(t);
                treeList1.Selection.Add(t);
                treeList1.SelectionChanged += TreeList1_SelectionChanged;
            }
        }

        private void FolderTreeViewUC1_FolderChanged(object sender, FolderSelectionEventArgs e)
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
            if (DataProvider == null)
            {
                return;
            }

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            await LoadFilesAsync(files.ToList(), chkbSelectionMode.Checked);
        }

        private void PopulateFiles(string folder)
        {
            if (string.IsNullOrEmpty(folder) || !Directory.Exists(folder) || DataProvider == null)
            {
                return;
            }

            SelectedPath = folder;
            treeList1.SelectionChanged -= TreeList1_SelectionChanged;
            bool isRoot = Directory.GetLogicalDrives().Any(d => d.Equals(SelectedPath, StringComparison.OrdinalIgnoreCase));
            bool recursiveLoad = checkEditRecursiveLoad.Checked && !isRoot;
            DirectoryInfo dirInfo = new DirectoryInfo(folder);
            ServicesProvider.Instance.GetService<IAnalogyUserSettings>().AddToRecentFolders(DataProvider.Id, folder);
            List<FileInfo> fileInfos = DataProvider.GetSupportedFiles(dirInfo, recursiveLoad).Distinct(new FileInfoComparer()).ToList();
            treeList1.Nodes.Clear();

            // TreeListFileNodes.Clear();
            foreach (FileInfo fi in fileInfos)
            {
                treeList1.Nodes.Add(fi.Name, fi.LastWriteTime, fi.Length, fi.FullName);

                // TreeListFileNodes.Add(fi.FullName);
            }
            treeList1.ClearSelection();

            //treeList1.TopVisibleNodeIndex = 0;
            treeList1.BestFitColumns();
            if (treeList1.Nodes.Any())
            {
                treeList1.MakeNodeVisible(treeList1.Nodes.FirstNode);
            }
            treeList1.SelectionChanged += TreeList1_SelectionChanged;
        }

        private async Task LoadFilesAsync(List<string> fileNames, bool clearLog)
        {
            ucLogs1.OnFocusedRowChanged -= UcLogs1_OnFocusedRowChanged;
            await ucLogs1.LoadFilesAsync(fileNames, clearLog);
            ucLogs1.OnFocusedRowChanged += UcLogs1_OnFocusedRowChanged;
        }

        private void bBtnOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (treeList1.Selection.Any())
            {
                var filename = (string)treeList1.Selection.First().GetValue(colFullPath);
                if (filename == null || !File.Exists(filename))
                {
                    return;
                }

                Process.Start("explorer.exe", "/select, \"" + filename + "\"");
            }
        }

        private void bBtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (treeList1.Selection.Any())
            {
                var filename = (string)treeList1.Selection.First().GetValue(colFullPath);
                if (filename == null || !File.Exists(filename))
                {
                    return;
                }

                var result = MessageBox.Show($"Are you sure you want to delete {filename}?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (File.Exists(filename))
                    {
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
        }

        private void bBtnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            PopulateFiles(SelectedPath);
        }

        private void bBtnSelectAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            treeList1.SelectAll();
        }

        private async void TreeList1_SelectionChanged(object sender, EventArgs e)
        {
            List<string> files = treeList1.Selection.Select(node => (string)node.GetValue(colFullPath)).ToList();
            await LoadFilesAsync(files, chkbSelectionMode.Checked);
        }

        private void treeList1_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            async void OpenFileInSeparateWindow(string filename)
            {
                ucLogs1.OnFocusedRowChanged -= UcLogs1_OnFocusedRowChanged;
                await ucLogs1.LoadFileInSeparateWindow(filename);
                ucLogs1.OnFocusedRowChanged += UcLogs1_OnFocusedRowChanged;
            }

            TreeList treeList = sender as TreeList;
            TreeListHitInfo hitInfo = treeList.CalcHitInfo(e.Point);

            // removing the "Runtime columns customization" item of the column header menu
            if (hitInfo.HitInfoType == HitInfoType.Cell)
            {
                var file = hitInfo.Node.GetValue(colFullPath).ToString();

                DXMenuItem menuItem = new DXMenuItem($"Open file {Path.GetFileName(file)} in separate Window",
                    (_, __) => { OpenFileInSeparateWindow(file); })
                { Tag = hitInfo.Column };

                //menuItem.Image =Resources.
                e.Menu.Items.Add(menuItem);
            }
        }

        public void ShowSecondaryWindow()
        {
            if (ucLogs1 != null)
            {
                ucLogs1.ShowSecondaryWindow();
            }
        }

        public void HideSecondaryWindow()
        {
            if (ucLogs1 != null)
            {
                ucLogs1.HideSecondaryWindow();
            }
        }
    }
}