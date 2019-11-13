using System;
using System.ServiceModel;
using System.Windows.Forms;

namespace Analogy
{
    public partial class OTALogs : UserControl
    {
        private ServiceHost _mSvcHost;
        // private AnalogyReceiverServer receiver;
        private UCLogs Logs;
        private bool EnableOTA { get; } = false;
        private bool ReceiveingInProgress;

        public OTALogs()
        {
            InitializeComponent();
        }

        private void StartStopHost(object singletonInstance, params Uri[] baseAddresses)
        {
            if (ReceiveingInProgress)
            {
                btnStartServer.Text = @"Start Receiving Messages";
                ReceiveingInProgress = false;
                try
                {
                    _mSvcHost.Close();
                    label1.Visible = false;
                }
                catch (Exception)
                {
                    _mSvcHost?.Abort();
                }
            }
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (!EnableOTA)
            {
                MessageBox.Show(Properties.Resources.FeatureDisable, Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            //if (!ReceiveingInProgress)
            //{
            //    receiver = new AnalogyReceiverServer();
            //    receiver.Subscription += (s, message) =>
            //    {
            //        message.Message.Text = $"{message.Message.Text }. Received from Analogy hostname: {message.HostName}";
            //        Logs.AppendMessage(message.Message, message.DataProvider);
            //    };
            //}
            //StartStopHost(receiver);

        }

        private void OTALogs_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            Logs = new UCLogs();
            groupBox2.Controls.Add(Logs);
            Logs.Dock = DockStyle.Fill;
            Logs.RefreshUI();
        }
    }
}
