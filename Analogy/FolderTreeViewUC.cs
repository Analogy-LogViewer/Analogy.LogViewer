using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Philips.Analogy.Interfaces;
using Philips.Analogy.Types;

namespace Philips.Analogy
{
    public partial class FolderTreeViewUC : UserControl
    {
        public event EventHandler<FolderSelectionEventArgs> FolderChanged;
        private string SelectedPath { get; set; } = string.Empty;
        private IAnalogyOfflineDataProvider DataProvider { get; set; }
        public FolderTreeViewUC()
        {
            InitializeComponent();
            xtraUCFileSystem1.SetListing(true, false);
            xtraUCFileSystem1.FolderChanged += (s, e) => FolderChanged?.Invoke(this, new FolderSelectionEventArgs(e.SelectedFolderPath));
        }

        private async void txtbFolder_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Directory.Exists(txtbFolder.Text))
                {
                    await PopulateFolders(txtbFolder.Text, DataProvider);
                }

            }
        }
        private async Task PopulateFolders(string folderText, IAnalogyOfflineDataProvider dataProvider)
        {
            if (Directory.Exists(folderText))
            {
                xtraUCFileSystem1.SetPath(folderText, dataProvider);
                txtbFolder.Text = folderText;
                FolderChanged?.Invoke(this, new FolderSelectionEventArgs(folderText));
            }
            else
            {
                await Task.CompletedTask;
            }
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var node = new TreeNode(directoryInfo.Name);
            node.Tag = directoryInfo.FullName;
            DirectoryInfo[] dirs = new DirectoryInfo[0];
            try
            {
                dirs = directoryInfo.GetDirectories();
            }
            catch (Exception)
            {
                //nothing
            }

            foreach (var directory in dirs)
                node.Nodes.Add(CreateDirectoryNode(directory));
            //foreach (var file in directoryInfo.GetFiles())
            //    directoryNode.Nodes.Add(new TreeNode(file.Name));
            return node;
        }
        private async void FolderTreeViewUC_Load(object sender, EventArgs e)
        {
            txtbFolder.Text = SelectedPath;
            if (Directory.Exists(txtbFolder.Text))
            {
                await PopulateFolders(txtbFolder.Text, DataProvider);
            }
        }

        private async void btnOpenFile_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = SelectedPath;
            if (DialogResult.OK == folderBrowserDialog1.ShowDialog(this))
            {
                SelectedPath = folderBrowserDialog1.SelectedPath;
                await PopulateFolders(SelectedPath, DataProvider);
            }

        }

        public void SetFolder(string folder, IAnalogyOfflineDataProvider dataProvider)
        {
            this.DataProvider = dataProvider;
            if (string.IsNullOrEmpty(folder) || !Directory.Exists(folder)) return;
            SelectedPath = folder;
            txtbFolder.Text = folder;
            xtraUCFileSystem1.SetPath(folder, dataProvider);
        }
    }


}
