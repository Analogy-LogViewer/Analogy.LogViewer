using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DevExpress.XtraEditors;

namespace Analogy
{
    public partial class XtraUCWindowsEventLogs : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings => UserSettingsManager.UserSettings;
        public XtraUCWindowsEventLogs()
        {
            InitializeComponent();
        }

        private void XtraUCWindowsEventLogs_Load(object sender, EventArgs e)
        {
            lstSelected.Items.AddRange(Settings.EventLogs.ToArray());
            try
            {
                var all = System.Diagnostics.Eventing.Reader.EventLogSession.GlobalSession.GetLogNames().Where(EventLog.Exists).ToList().Except(Settings.EventLogs).ToArray();
                lstAvailable.Items.AddRange(all);
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Error loading all logs. Make sure you are running as administrator. Error:" + exception.Message, "Error",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }


        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            List<object> selected = lstAvailable.SelectedItems.ToList();
            lstSelected.Items.AddRange(selected.ToArray());
            foreach (var log in selected)
            {
                lstAvailable.Items.Remove(log);
            }
            UpdateUserSettingList();
        }


        private void BtnRemove_Click(object sender, EventArgs e)
        {
            List<object> selected = lstSelected.SelectedItems.ToList();
            lstAvailable.Items.AddRange(selected.ToArray());
            foreach (var log in selected)
            {
                lstSelected.Items.Remove(log);
            }
            UpdateUserSettingList();
        }


        private void UpdateUserSettingList()
        {
            Settings.EventLogs = lstSelected.Items.OfType<string>().ToList();
        }
    }
}
