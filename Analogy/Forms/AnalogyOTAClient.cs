using Analogy.Interfaces;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy
{
    public partial class AnalogyOTAClient : XtraForm
    {
        private class CheckListItemForSending
        {
            internal AnalogyLogMessage Message { get; }
            internal string SourceData { get; }

            public CheckListItemForSending(AnalogyLogMessage message, string sourceData)
            {
                Message = message;
                SourceData = sourceData;
            }

            public override string ToString()
            {
                return Message.Text;
            }
        }

        private DataTable Data;

        public AnalogyOTAClient()
        {
            InitializeComponent();
        }

        public AnalogyOTAClient(DataTable data) : this()
        {
            Data = data;
        }

        private void AnalogyOTAClient_Load(object sender, System.EventArgs e)
        {
            Icon = UserSettingsManager.UserSettings.GetIcon();
            foreach (DataRow dataRow in Data.Rows)
            {
                checkedListBox1.Items.Add(new CheckListItemForSending(dataRow[9] as AnalogyLogMessage, dataRow[11].ToString()),
                    true);
            }
        }

        private void btnStartServer_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbIP.Text)) return;
            if (Uri.CheckHostName(txtbIP.Text) != UriHostNameType.Unknown)
            {

                Task.Factory.StartNew(() =>
                {
                    try
                    {

                        SendLogs(txtbIP.Text);
                        MessageBox.Show(@"Finished", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exception)
                    {

                        string err = $"Error creating client. Reason: {exception.Message}";
                        MessageBox.Show(err, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                });
            }
        }

        private void SendLogs(string ip)
        {
            var items = checkedListBox1.CheckedItems.Cast<CheckListItemForSending>().ToList();
            foreach (var checkListItemForSending in items)
            {
                //var clientSender = new AnalogyClientSender(txtbIP.Text);
                //clientSender.SendMessage(checkListItemForSending.Message, Environment.MachineName, checkListItemForSending.SourceData);
            }
        }

        private void BtnDeselect_Click(object sender, EventArgs e)
        {
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
    }
}

