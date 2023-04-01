using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Analogy.UserControls
{
    public partial class CompareTextUC : XtraUserControl
    {
        private string? LeftFile { get; set; }
        private string? RightFile { get; set; }
        public CompareTextUC()
        {
            InitializeComponent();
        }

        private void sBtnLeft_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = @"Open Files";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LeftFile =openFileDialog1.FileName;
                CompareIfBothSideAreLoaded();
            }
        }

        private void simpleButtonRight_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = @"Open Files";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                RightFile = openFileDialog1.FileName;
                CompareIfBothSideAreLoaded();
            }
        }

        private void CompareIfBothSideAreLoaded()
        {
            if (LeftFile == null || RightFile == null)
            {
                return;
            }
            Compare();
            
        }

        public void Compare()
        {
            rtboxLeft.Clear();
            rtboxRight.Clear();
            lblFileLeft.Text = string.Empty;
            lblFileRight.Text = string.Empty;

            lblFileLeft.Text = LeftFile;
            rtboxLeft.Text = File.ReadAllText(LeftFile!);


            lblFileRight.Text = RightFile;
            rtboxRight.Text = File.ReadAllText(RightFile!); 


            int leftCount = rtboxLeft.Lines.Length;
            int rightCount = rtboxRight.Lines.Length;
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
    }
}
