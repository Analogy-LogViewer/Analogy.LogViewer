using Philips.Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Philips.Analogy.Interfaces.Interfaces;
using Message = System.Windows.Forms.Message;

namespace Philips.Analogy
{

    public partial class OnlineUCLogs : UserControl
    {
        private bool showHistory = UserSettingsManager.UserSettings.ShowHistoryOfClearedMessages;
        private bool _sendLogs;
        private static int clearHistoryCounter;
        public bool Enable { get; set; } = true;
        public OnlineUCLogs(IAnalogyRealTimeDataSource realTime)
        {
            InitializeComponent();
            ucLogs1.OnlineMode = true;
            ucLogs1.SetFileDataSource(realTime.FileOperationsHandler);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ucLogs1.ProcessCmdKeyFromParent(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void OnlineUCLogs_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            ucLogs1.OnHistoryCleared += UcLogs1_OnHistoryCleared;
            spltMain.Panel1Collapsed = true;
        }

        private void UcLogs1_OnHistoryCleared(object sender, Interfaces.AnalogyClearedHistoryEventArgs e)
        {
            Interlocked.Increment(ref clearHistoryCounter);
            spltMain.Panel1Collapsed = !showHistory;
            string entry = $"History #{clearHistoryCounter} ({e.ClearedMessages.Count} messages)";
            FileProcessingManager.Instance.DoneProcessingFile(e.ClearedMessages, entry);
            listBoxClearHistory.Items.Add(entry);
        }

        private void AnalogyUCLogs_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        private async void AnalogyUCLogs_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            await LoadFilesAsync(files.ToList(), true);

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetAuditColumnVisibility(bool value)
        {
            ucLogs1.SetAuditColumnVisibility(value);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetCategoryColumnVisibility(bool value)
        {
            ucLogs1.SetAuditColumnVisibility(value);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendMessage(AnalogyLogMessage message, string dataSource)
        {
            if (Enable && !IsDisposed)
                ucLogs1.AppendMessage(message, dataSource);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendMessages(List<AnalogyLogMessage> messages, string dataSource)
        {
            if (Enable && !IsDisposed)
                ucLogs1.AppendMessages(messages, dataSource);
        }

        public async Task LoadFilesAsync(List<string> fileNames, bool clearLogBeforeLoading)
        {
            await ucLogs1.LoadFilesAsync(fileNames, clearLogBeforeLoading);
        }

        private void tsbtnHide_Click(object sender, EventArgs e)
        {
            if (IsDisposed) return;
            showHistory = false;
            spltMain.Panel1Collapsed = true;
        }

        private void listBoxClearHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxClearHistory.SelectedItem == null) return;
            var messages = FileProcessingManager.Instance.GetMessages((string)listBoxClearHistory.SelectedItem);
            XtraFormLogGrid grid = new XtraFormLogGrid(messages, Environment.MachineName);
            grid.ShowDialog(this);
        }

        private void tsBtnClearHistory_Click(object sender, EventArgs e)
        {
            listBoxClearHistory.Items.Clear();
        }
    }

}


