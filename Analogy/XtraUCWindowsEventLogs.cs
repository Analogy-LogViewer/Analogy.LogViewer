using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Philips.Analogy
{
    public partial class XtraUCWindowsEventLogs : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly UserSettingsManager _settings = UserSettingsManager.UserSettings;
        public XtraUCWindowsEventLogs()
        {
            InitializeComponent();
        }

        private void XtraUCWindowsEventLogs_Load(object sender, EventArgs e)
        {
            lstSelected.Items.AddRange(_settings.EventLogs.ToArray());
            var all = System.Diagnostics.Eventing.Reader.EventLogSession.GlobalSession.GetLogNames().Where(EventLog.Exists).ToList().Except(_settings.EventLogs).ToArray();
            lstAvailable.Items.AddRange(all);

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
            _settings.EventLogs = lstSelected.Items.OfType<string>().ToList();
        }
    }
}
