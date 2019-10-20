using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Interfaces;
using DevExpress.XtraBars;
using Message = System.Windows.Forms.Message;

namespace Analogy
{

    public partial class OnlineUCLogs : UserControl
    {
        private bool showHistory = UserSettingsManager.UserSettings.ShowHistoryOfClearedMessages;
        private bool _sendLogs;
        private static int clearHistoryCounter;
        public bool Enable { get; set; } = true;
        public OnlineUCLogs(IAnalogyRealTimeDataProvider realTime)
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
            ucLogs1.btsFilePooling.Visibility = BarItemVisibility.Never;
            spltMain.Panel1Collapsed = true;
        }

        private void UcLogs1_OnHistoryCleared(object sender, AnalogyClearedHistoryEventArgs e)
        {
            Interlocked.Increment(ref clearHistoryCounter);
            listBoxClearHistory.SelectedIndexChanged -= ListBoxClearHistoryIndexChanged;
            spltMain.Panel1Collapsed = !showHistory;
            string entry = $"History #{clearHistoryCounter} ({e.ClearedMessages.Count} messages)";
            FileProcessingManager.Instance.DoneProcessingFile(e.ClearedMessages, entry);
            listBoxClearHistory.Items.Add(entry);
            listBoxClearHistory.SelectedItem = null;
            listBoxClearHistory.SelectedIndex = -1;
            listBoxClearHistory.SelectedIndexChanged += ListBoxClearHistoryIndexChanged;
        }

        private void AnalogyUCLogs_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        private async void AnalogyUCLogs_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            await LoadFilesAsync(files.ToList(), true);

        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendMessage(AnalogyLogMessage message, string dataSource)
        {
            if (Enable && !IsDisposed)
            {
                string interned = string.Intern(dataSource);
                ucLogs1.AppendMessage(message, interned);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendMessages(List<AnalogyLogMessage> messages, string dataSource)
        {
            if (Enable && !IsDisposed)
            {
                string interned = string.Intern(dataSource);
                ucLogs1.AppendMessages(messages, interned);
            }
        }

        public async Task LoadFilesAsync(List<string> fileNames, bool clearLogBeforeLoading)
        {
            await ucLogs1.LoadFilesAsync(fileNames, clearLogBeforeLoading);
        }

        private void bbtnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listBoxClearHistory.Items.Clear();
        }

        private void bbtnHide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsDisposed) return;
            showHistory = false;
            spltMain.Panel1Collapsed = true;
        }

        private void ListBoxClearHistoryIndexChanged(object sender, EventArgs e)
        {
            if (listBoxClearHistory.SelectedItem == null) return;
            var messages = FileProcessingManager.Instance.GetMessages((string)listBoxClearHistory.SelectedItem);
            XtraFormLogGrid grid = new XtraFormLogGrid(messages, Environment.MachineName);
            grid.Show(this);
        }
    }

}


