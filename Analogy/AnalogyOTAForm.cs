using DevExpress.XtraEditors;

using System;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;

namespace Philips.Analogy
{
    public partial class AnalogyOTAForm : XtraForm
    {
        private ServiceHost _mSvcHost;
       // private AnalogyReceiverServer receiver;
        private UCLogs Logs;
        private bool EnableOTA { get; } = false;
        private bool ReceiveingInProgress;
        public AnalogyOTAForm()
        {
            InitializeComponent();
        }

        public AnalogyOTAForm(Form mainForm) : this()
        {
            MdiParent = mainForm;
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
                catch (Exception ex)
                {
                    _mSvcHost?.Abort();
                    MessageBox.Show(@"Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {

                try
                {
                    _mSvcHost = new ServiceHost(singletonInstance, baseAddresses);
                    _mSvcHost.Open();
                    ReceiveingInProgress = true;
                    btnStartServer.Text = "Stop";
                    label1.Text = "Server is running and listening to incoming messages";
                    label1.BackColor = Color.GreenYellow;
                    label1.Visible = true;
                }
                catch (Exception ex)
                {
                    _mSvcHost?.Abort();
                    MessageBox.Show(@"Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!ReceiveingInProgress)
            {
                //receiver = new AnalogyReceiverServer();
                //receiver.Subscription += (s, message) =>
                //{
                //    message.Message.Text = $"{message.Message.Text }. Received from Analogy hostname: {message.HostName}";
                //    Logs.AppendMessage(message.Message, message.DataSource);
                //};
            }
            //StartStopHost(receiver);

        }

        private void AnalogyOTAForm_Load(object sender, EventArgs e)
        {
            Logs = new UCLogs();
            groupBox2.Controls.Add(Logs);
            Logs.Dock = DockStyle.Fill;
            Logs.RefreshUI();
            ;
        }

        private void AnalogyOTAForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _mSvcHost?.Close();
                label1.Visible = false;
            }
            catch (Exception ex)
            {
                _mSvcHost?.Abort();
                MessageBox.Show(@"Error: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
