using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.Common.Managers;
using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Tools;
using Microsoft.Extensions.Logging;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Analogy.UserControls
{
    public partial class LogsComparerUC : DevExpress.XtraEditors.XtraUserControl
    {
        private IUserSettingsManager Settings => ServicesProvider.Instance.GetService<IAnalogyUserSettings>();
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private FileComparerProcessor? LeftFile { get; set; }
        private FileComparerProcessor? RightFile { get; set; }
        private IAnalogyOfflineDataProvider OfflineAnalogy { get; set; }
        public LogsComparerUC()
        {
            InitializeComponent();
        }

        public void LoadFiles(string pathLeft, string pathRight)
        {
            rtboxLeft.Text = "";
            rtboxRight.Text = "";
            lblFileLeft.Text = string.Empty;
            lblFileRight.Text = string.Empty;
            ;
            if (File.Exists(pathLeft) && (pathLeft.EndsWith("txt") || pathLeft.EndsWith("cfg") || pathLeft.EndsWith("xml")))
            {
                lblFileLeft.Text = pathLeft;
                rtboxLeft.LoadFile(pathLeft);
            }
            if (File.Exists(pathRight) && (pathRight.EndsWith("txt") || pathRight.EndsWith("cfg") || pathRight.EndsWith("xml")))
            {
                lblFileRight.Text = pathRight;
                rtboxRight.LoadFile(pathRight);
            }

            int leftCount = rtboxLeft.Text.Count();
            int rightCount = rtboxRight.Lines.Count();
            int i = 0;
            int upto = Math.Min(leftCount, rightCount);
            while (i < upto)
            {
                if (!rtboxLeft.Lines[i].Equals(rtboxRight.Lines[i]))
                {
                    rtboxLeft.Find(rtboxLeft.Lines[i]);
                    rtboxLeft.SelectionColor = Color.Red;
                    rtboxRight.Find(rtboxRight.Lines[i]);
                    rtboxRight.SelectionColor = Color.Red;
                }
                i++;
            }
            for (int j = i; j < leftCount; j++)
            {
                rtboxLeft.Find(rtboxLeft.Lines[i]);
                rtboxLeft.SelectionColor = Color.Red;
            }
            for (int j = i; j < rightCount; j++)
            {
                rtboxRight.Find(rtboxRight.Lines[i]);
                rtboxRight.SelectionColor = Color.Red;
            }
        }
        public void Compare()
        {
            rtboxLeft.Clear();
            rtboxRight.Clear();
            lblFileLeft.Text = string.Empty;
            lblFileRight.Text = string.Empty;

            lblFileLeft.Text = LeftFile.FileName;
            rtboxLeft.Text = LeftFile.ToText;

            lblFileRight.Text = RightFile.FileName;
            rtboxRight.Text = RightFile.ToText;

            int leftCount = rtboxLeft.Lines.Count();
            int rightCount = rtboxRight.Lines.Count();
            int i = 0;
            int upto = Math.Min(leftCount, rightCount);
            while (i < upto)
            {
                if (!rtboxLeft.Lines[i].Equals(rtboxRight.Lines[i]))
                {
                    rtboxLeft.Find(rtboxLeft.Lines[i]);
                    rtboxLeft.SelectionColor = Color.Red;
                    rtboxRight.Find(rtboxRight.Lines[i]);
                    rtboxRight.SelectionColor = Color.Red;
                }
                i++;
            }
            for (int j = i; j < leftCount; j++)
            {
                rtboxLeft.Find(rtboxLeft.Lines[i]);
                rtboxLeft.SelectionColor = Color.Red;
            }
            for (int j = i; j < rightCount; j++)
            {
                rtboxRight.Find(rtboxRight.Lines[i]);
                rtboxRight.SelectionColor = Color.Red;
            }
        }
        private async void sBtnLeft_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = OfflineAnalogy.FileOpenDialogFilters;
            openFileDialog1.Title = @"Open Files";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LeftFile = new FileComparerProcessor(openFileDialog1.FileName);
                FileProcessor fp = new FileProcessor(Settings, LeftFile, ServicesProvider.Instance.GetService<FileProcessingManager>(), ServicesProvider.Instance.GetService<ILogger>());
                await fp.Process(OfflineAnalogy, openFileDialog1.FileName, cancellationTokenSource.Token);
                CompareIfBothSideAreLoaded();
            }
        }

        private async void simpleButtonRight_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = OfflineAnalogy.FileOpenDialogFilters;
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                RightFile = new FileComparerProcessor(openFileDialog1.FileName);
                FileProcessor fp = new FileProcessor(Settings, RightFile, ServicesProvider.Instance.GetService<FileProcessingManager>(), ServicesProvider.Instance.GetService<ILogger>());
                await fp.Process(OfflineAnalogy, openFileDialog1.FileName, cancellationTokenSource.Token);
                CompareIfBothSideAreLoaded();
            }
        }

        private void CompareIfBothSideAreLoaded()
        {
            if (LeftFile == null || RightFile == null)
            {
                return;
            }

            if (LeftFile.IsLoaded && RightFile.IsLoaded)
            {
                Compare();
            }
        }

        public void SetDataSource(IAnalogyOfflineDataProvider offlineAnalogy)
        {
            OfflineAnalogy = offlineAnalogy;
        }
    }
}