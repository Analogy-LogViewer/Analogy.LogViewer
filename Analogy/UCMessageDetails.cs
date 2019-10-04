using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Philips.Analogy.Interfaces.DataTypes;

namespace Philips.Analogy
{
    public partial class UCMessageDetails : UserControl
    {
        private AnalogyLogMessage Message { get; set; }
        private List<AnalogyLogMessage> Messages { get; }
        private string DataSource { get; }
        public UCMessageDetails()
        {
            InitializeComponent();
        }

        public UCMessageDetails(AnalogyLogMessage msg, List<AnalogyLogMessage> messages,string dataSource) : this()
        {
            Message = msg;
            Messages = messages;
            DataSource = dataSource;
        }

        private void UCMessageDetails_Load(object sender, EventArgs e)
        {
            LoadMessage();
        }

        private void LoadMessage()
        {
            rtxtbText.Text = Message.Text;
            rtxtbDataSource.Text = DataSource;
            txtbDateValue.Text = Message.Date.ToString("MM/dd/yyyy hh:mm:ss.fff tt", DateTimeFormatInfo.InvariantInfo);
            txtbLevelValue.Text = Message.Level.ToString();
            txtbProcessValue.Text = $"{Message.Module} (ID:{Message.ProcessID})";
            txtSourceValue.Text = Message.Source;
            txtbMethod.Text = Message.MethodName;
            txtbFileName.Text = Message.FileName;
            txtbUser.Text = Message.User;
            txtbLineNumber.Text = Message.LineNumber.ToString();
            rtxtbIndex.Text = $"{Messages.IndexOf(Message) + 1} of {Messages.Count}";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Messages.Last() == Message) return;
            Message = Messages[Messages.IndexOf(Message) + 1];
            LoadMessage();

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (Messages.First() == Message) return;
            Message = Messages[Messages.IndexOf(Message) - 1];
            LoadMessage();

        }

        private void rtxtbText_TextChanged(object sender, EventArgs e)
        {

        }

        private void sBtnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtxtbText.Text);
        }
    }
}
