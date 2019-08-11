using DevExpress.XtraBars;
using DevExpress.XtraTab;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Philips.Analogy
{
    public partial class SimpleFormMain : DevExpress.XtraEditors.XtraForm
    {
        private NamedPipeClientToLogService ServiceClient;
        private int offline;
        private int online;
        public SimpleFormMain()
        {
            InitializeComponent();
        }

        private async void bBtnServerLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            await OpenOnlineLog();
        }


        private void bBtnFileLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFile();
        }
        private void OpenFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter =
                "All supported log file types|*.log;*.etl;*.nlog;*.json|Plain XML log file (*.log)|*.log|JSON file (*.json)|*.json|NLOG file (*.nlog)|*.nlog|ETW log file (*.etl)|*.etl|All Files (*.*)|*.*";
            openFileDialog1.Title = @"Open Files";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenOfflineLogs(openFileDialog1.FileNames);
            }
        }
        private void OpenOfflineLogs(string[] filenames)
        {
            offline++;
            var offlineUC = (ILogMessagesHandler)new OfflineUCLogs(filenames);
            XtraTabPage page = new XtraTabPage();
            page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            page.Controls.Add((UserControl)offlineUC);
            ((UserControl)offlineUC).Dock = DockStyle.Fill;
            page.Text = $"Offline log #{offline}";
            xtcLogs.TabPages.Add(page);
            xtcLogs.SelectedTabPage = page;
        }

        private void bBtnSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm();
            user.ShowDialog(this);
        }

        private void BBtnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void SimpleFormMain_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            string[] arguments = Environment.GetCommandLineArgs();
            if (arguments.Length == 2)
            {
                string[] fileNames = { arguments[1] };
                OpenOfflineLogs(fileNames);
            }
        }

        private async void TmrAutoConnect_Tick(object sender, EventArgs e)
        {
            await OpenOnlineLog();
        }
        private async Task OpenOnlineLog()
        {
            TmrAutoConnect.Enabled = false;
            ServiceClient = new NamedPipeClientToLogService();
            ServiceClient.Disconnected += (s, e) =>
            {
                TmrAutoConnect.Enabled = true;
            };
            if (await ServiceClient.ConnectToLogProvider()) //connected
            {
                online++;
                var onlineUC = (ILogMessagesHandler)new OnlineUCLogs();
                XtraTabPage page = new XtraTabPage();
                page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                page.Controls.Add((UserControl)onlineUC);
                ((UserControl)onlineUC).Dock = DockStyle.Fill;
                page.Text = $"Online log #{online}";
                xtcLogs.TabPages.Add(page);
                ServiceClient.requester.RegisterWatcher();
                ServiceClient.Handler += (sender, e) => onlineUC.AppendMessage(e.Message, Environment.MachineName);
                xtcLogs.SelectedTabPage = page;
            }
            else
            {
                TmrAutoConnect.Enabled = true;
            }
        }

        private async void bBtnRealTime_ItemClick(object sender, ItemClickEventArgs e)
        {
            await OpenOnlineLog();
        }

        private void bBtnOpenFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFile();
        }
    }
}