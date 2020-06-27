using Analogy.Interfaces;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Analogy
{
    public partial class UCMessageDetails : XtraUserControl
    {
        private AnalogyLogMessage Message { get; set; }
        private List<AnalogyLogMessage> Messages { get; }
        private string DataSource { get; }
        public UCMessageDetails()
        {
            InitializeComponent();
        }

        public UCMessageDetails(AnalogyLogMessage msg, List<AnalogyLogMessage> messages, string dataSource) : this()
        {
            Message = msg;
            Messages = messages;
            DataSource = dataSource;
        }

        private void UCMessageDetails_Load(object sender, EventArgs e)
        {
            LoadMessage();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                LoadPreviousMessage();
                return true;
            }

            if (keyData == Keys.Right)
            {
                LoadNextMessage();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void LoadMessage()
        {
            memoText.Text = Message.Text;
            txtbMachineName.Text = Message.MachineName;
            txtID.Text = Message.Id.ToString();
            txtbDataSource.Text = DataSource;
            txtbDateValue.Text = Message.Date.ToString(UserSettingsManager.UserSettings.DateTimePattern);
            txtbLevelValue.Text = Message.Level.ToString();
            txtbProcessModuleName.Text =Message.Module;
            txtbProcessId.Text = Message.ProcessId.ToString();
            txtbThreadId.Text = Message.ThreadId.ToString();
            txtSourceValue.Text = Message.Source;
            txtbMethod.Text = Message.MethodName;
            txtbFileName.Text = Message.FileName;
            txtbUser.Text = Message.User;
            txtbLineNumber.Text = Message.LineNumber.ToString();
            txtbIndex.Text = $"{Messages.IndexOf(Message) + 1} of {Messages.Count}";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            LoadNextMessage();
        }

        private void LoadPreviousMessage()
        {
            if (Messages.First() == Message) return;
            Message = Messages[Messages.IndexOf(Message) - 1];
            LoadMessage();
        }
        private void LoadNextMessage()
        {
            if (Messages.Last() == Message) return;
            Message = Messages[Messages.IndexOf(Message) + 1];
            LoadMessage();
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            LoadPreviousMessage();
        }

        private void sBtnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(memoText.Text);
        }


    }
}
