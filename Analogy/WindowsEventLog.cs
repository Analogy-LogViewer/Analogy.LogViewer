using DevExpress.XtraEditors;
using Philips.Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Philips.Analogy
{

    public partial class WindowsEventLog : UserControl
    {
        private List<EventLog> Custom = new List<EventLog>();
        public string SelectedPath { get; set; }
        private List<string> portalLogs { get; } = new List<string>() {};

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
            //lBoxSources.SelectedIndex = -1;
            //lBoxSources.SelectedValueChanged += lBoxSources_SelectedValueChanged;
            Counter alllogs = new Counter("All");
            lBoxSources.Items.Add(alllogs);
            SetUpLog(alllogs, "Application");
            SetUpLog(alllogs, "Security");
            SetUpLog(alllogs, "Setup");
            SetUpLog(alllogs, "System");
            try
            {
                var all = System.Diagnostics.Eventing.Reader.EventLogSession.GlobalSession.GetLogNames().ToList();
                foreach (string portalLog in portalLogs)
                {
                    var has = all.Any(log => log.Equals(portalLog));
                    if (has)
                        SetUpLog(alllogs, portalLog);
                }
            }
            catch (Exception ex)
            {
                AnalogyLogMessage m = new AnalogyLogMessage("Error adding log: " + ex.Message, AnalogyLogLevel.Error, AnalogyLogClass.General, "Analogy","None");
                ucLogs1.AppendMessage(m, Environment.MachineName);
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
                AnalogyLogMessage l = new AnalogyLogMessage( m, AnalogyLogLevel.Error,AnalogyLogClass.General, "Analogy","None");
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
            XtraFormClientServer f = new XtraFormClientServer();
            f.ShowDialog(this);
            lBoxSources.DataSource = ClientServerDataSourceManager.Instance.DataSources;
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


