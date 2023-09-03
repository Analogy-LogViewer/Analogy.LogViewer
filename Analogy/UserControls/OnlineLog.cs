using Analogy.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;
using Analogy.CommonControls.DataTypes;
using Analogy.CommonControls.Forms;
using Analogy.DataTypes;
using DevExpress.XtraEditors;
using Microsoft.Extensions.Logging;
using Analogy.Common.Managers;

namespace Analogy.UserControls
{

    public partial class OnlineUCLogs : XtraUserControl, IUserControlWithUCLogs
    {
        private FileProcessingManager FileProcessingManager { get; }
        private bool _showHistory = ServicesProvider.Instance.GetService<IAnalogyUserSettings>().ShowHistoryOfClearedMessages;
        private static int _clearHistoryCounter;
        public bool Enable { get; set; } = true;
        public OnlineUCLogs(IAnalogyRealTimeDataProvider realTime, FileProcessingManager fileProcessingManager)
        {
            FileProcessingManager = fileProcessingManager;
            InitializeComponent();
            ucLogs1.SetFileDataSource(realTime, realTime.FileOperationsHandler);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ucLogs1.ProcessCmdKeyFromParent(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void OnlineUCLogs_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            ucLogs1.OnHistoryCleared += UcLogs1_OnHistoryCleared;
            spltMain.Panel1Collapsed = true;
        }

        private void UcLogs1_OnHistoryCleared(object sender, AnalogyClearedHistoryEventArgs e)
        {
            Interlocked.Increment(ref _clearHistoryCounter);
            listBoxClearHistory.SelectedIndexChanged -= ListBoxClearHistoryIndexChanged;
            spltMain.Panel1Collapsed = !_showHistory;
            string entry = $"History #{_clearHistoryCounter} ({e.ClearedMessages.Count} messages)";
            FileProcessingManager.DoneProcessingFile(e.ClearedMessages, entry);
            listBoxClearHistory.Items.Add(entry);
            listBoxClearHistory.SelectedItem = null;
            listBoxClearHistory.SelectedIndex = -1;
            listBoxClearHistory.SelectedIndexChanged += ListBoxClearHistoryIndexChanged;
        }

        public void AppendMessage(IAnalogyLogMessage message, string dataSource)
        {
            if (Enable && !IsDisposed)
            {
                string interned = string.Intern(dataSource);
                ucLogs1.AppendMessage(message, interned);
            }
        }

        public void AppendMessages(List<IAnalogyLogMessage> messages, string dataSource)
        {
            if (Enable && !IsDisposed)
            {
                string interned = string.Intern(dataSource);
                ucLogs1.AppendMessages(messages, interned);
            }
        }

        private void bbtnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listBoxClearHistory.Items.Clear();
        }

        private void bbtnHide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsDisposed)
            {
                return;
            }

            _showHistory = false;
            spltMain.Panel1Collapsed = true;
        }

        private void ListBoxClearHistoryIndexChanged(object sender, EventArgs e)
        {
            if (listBoxClearHistory.SelectedItem == null)
            {
                return;
            }

            var messages = FileProcessingManager.GetMessages((string)listBoxClearHistory.SelectedItem);
            XtraFormLogGrid grid = new XtraFormLogGrid(ServicesProvider.Instance.GetService<IAnalogyUserSettings>(),
                messages, Environment.MachineName, ucLogs1.DataProvider, ucLogs1.FileDataProvider);
            grid.Show(this);
        }
        public void ShowSecondaryWindow()
        {
            if (ucLogs1 != null)
                ucLogs1.ShowSecondaryWindow();
        }

        public void HideSecondaryWindow()
        {
            if (ucLogs1 != null)
                ucLogs1.HideSecondaryWindow();
        }
    }

}


