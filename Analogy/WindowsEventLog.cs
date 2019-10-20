using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Analogy.Interfaces;
using DevExpress.XtraBars;

namespace Analogy
{

    public partial class WindowsEventLog : UserControl
    {
        private List<EventLog> Custom = new List<EventLog>();
        public string SelectedPath { get; set; }

        public WindowsEventLog()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ucLogs1.ProcessCmdKeyFromParent(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void WindowsEventLog_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            ucLogs1.btswitchRefreshLog.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            ucLogs1.btsAutoScrollToBottom.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            ucLogs1.btsFilePooling.Visibility = BarItemVisibility.Always;
            SetupLogs();
        }

        private void SetupLogs()
        {
            foreach (EventLog eventLog in Custom)
            {
                eventLog.EnableRaisingEvents = false;
                eventLog.Dispose();
            }
            Custom.Clear();
            lBoxSources.Items.Clear();
            Counter alllogs = new Counter("All");
            lBoxSources.Items.Add(alllogs);
            foreach (string eventLog in UserSettingsManager.UserSettings.EventLogs)
            {
                SetUpLog(alllogs, eventLog);
            }
        }

        private void SetUpLog(Counter all, string logName)
        {
            try
            {
                if (EventLog.Exists(logName))
                {
                    var eventLog = new EventLog(logName);
                    Custom.Add(eventLog);
                    Counter c = new Counter(logName);
                    lBoxSources.Items.Add(c);
                    // set event handler
                    eventLog.EntryWritten += (apps, arg) =>
                    {
                        all.Increment();
                        c.Increment();
                        BeginInvoke(new MethodInvoker(() => lBoxSources.Refresh()));
                        AnalogyLogMessage m = Utils.CreateMessageFromEvent(arg.Entry);
                        m.Module = logName;
                        ucLogs1.AppendMessage(m, arg.Entry.MachineName);
                    };

                    eventLog.EnableRaisingEvents = true;
                }
            }
            catch (Exception e)
            {
                string m = "Error Opening log. Please make sure you are running as Administrator." + Environment.NewLine + "Error:" + e.Message;
                XtraMessageBox.Show(m, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AnalogyLogMessage l = new AnalogyLogMessage(m, AnalogyLogLevel.Error, AnalogyLogClass.General, "Analogy", "None");
                ucLogs1.AppendMessage(l, Environment.MachineName);
            }
        }


        private void lBoxSources_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lBoxSources.SelectedItem is DataSource data)
            {
                SelectedPath = data.Path;

            }
        }



        private void bBtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraFormWindowsEventlogsManager f = new XtraFormWindowsEventlogsManager();
            f.ShowDialog(this);
            SetupLogs();
        }

        private void bBtnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lBoxSources.SelectedItem is DataSource data)
            {
                if (XtraMessageBox.Show($"Are you sure you want to delete {data}?", "Confirmation Required",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ClientServerDataSourceManager.Instance.Remove(data);
                    lBoxSources.Items.Remove(data);

                }
            }
        }

        private class Counter
        {
            public string Name { get; }
            private int Count { get; set; }

            public Counter(string name)
            {
                Name = name;
                Count = 0;
            }

            public void Increment() => Count++;
            public override string ToString()
            {
                return $"Log: {Name}. Messages: {Count}";
            }
        }

        private void lBoxSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            Counter item = lBoxSources.SelectedItem as Counter;
            if (item == null) return;
            string module = item.Name == "All" ? string.Empty : item.Name;
            ucLogs1.FilterResults(module);
        }
    }
}


