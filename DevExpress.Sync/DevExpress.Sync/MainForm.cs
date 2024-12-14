using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevExpress.Sync
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            var targetFolder = txtbTarget.Text;
            var sourceFolder = txtbSource.Text;
            CopyFiles(Path.Combine(targetFolder, ".net core"), sourceFolder, true);
            CopyFiles(Path.Combine(targetFolder, ".net framework"), sourceFolder, false);
            MessageBox.Show("Done", "Done");
        }

        private void CopyFiles(string targetFolder, string sourceFolder, bool isNet)
        {
            var files = Directory.GetFiles(targetFolder);
            foreach (string fullPath in files)
            {
                var file = Path.GetFileName(fullPath);
                if (isNet)
                {
                    var sourceFile = Path.Combine(sourceFolder, "NetCore", file);
                    if (File.Exists(sourceFile))
                    {
                        File.Copy(sourceFile, fullPath, true);
                    }
                    else
                    {
                        sourceFile = Path.Combine(sourceFolder, "Standard", file);
                        if (File.Exists(sourceFile))
                        {
                            File.Copy(sourceFile, fullPath, true);
                        }
                        else
                        {
                            Console.WriteLine($"File {sourceFile} does not exist");
                        }
                    }
                }
                else
                {
                    var sourceFile = Path.Combine(sourceFolder, "Framework", file);
                    if (File.Exists(sourceFile))
                    {
                        File.Copy(sourceFile, fullPath, true);
                    }
                    else
                    {
                        sourceFile = Path.Combine(sourceFolder, "Standard", file);
                        if (File.Exists(sourceFile))
                        {
                            File.Copy(sourceFile, fullPath, true);
                        }
                        else
                        {
                            Console.WriteLine($"File {sourceFile} does not exist");
                        }
                    }
                }
            }
        }

        private void btnVersionUpgrade_Click(object sender, EventArgs e)
        {
            var targetFolder = txtbTarget.Text;
            var sourceFolder = txtbSource.Text;
            CopyFilesWithUpgrade(Path.Combine(targetFolder, ".net core"), sourceFolder, true);
            CopyFilesWithUpgrade(Path.Combine(targetFolder, ".net framework"), sourceFolder, false);
            MessageBox.Show("Done", "Done");
        }
        private void CopyFilesWithUpgrade(string targetFolder, string sourceFolder, bool isNet)
        {
            var files = Directory.GetFiles(targetFolder);
            foreach (string fullPath in files)
            {
                var file = Path.GetFileName(fullPath);
                file = file.Replace("v24.1", "v24.2");
                var targetFullPath = fullPath.Replace("v24.1", "v24.2");

                if (isNet)
                {
                    var sourceFile = Path.Combine(sourceFolder, "NetCore", file);
                    if (File.Exists(sourceFile))
                    {
                        File.Copy(sourceFile, targetFullPath, true);
                    }
                    else
                    {
                        sourceFile = Path.Combine(sourceFolder, "Standard", file);
                        if (File.Exists(sourceFile))
                        {
                            File.Copy(sourceFile, targetFullPath, true);
                        }
                        else
                        {
                            Console.WriteLine($"File {sourceFile} does not exist");
                        }
                    }
                }
                else
                {
                    var sourceFile = Path.Combine(sourceFolder, "Framework", file);
                    if (File.Exists(sourceFile))
                    {
                        File.Copy(sourceFile, targetFullPath, true);
                    }
                    else
                    {
                        sourceFile = Path.Combine(sourceFolder, "Standard", file);
                        if (File.Exists(sourceFile))
                        {
                            File.Copy(sourceFile, targetFullPath, true);
                        }
                        else
                        {
                            Console.WriteLine($"File {sourceFile} does not exist");
                        }
                    }
                }
            }
        }
    }
}