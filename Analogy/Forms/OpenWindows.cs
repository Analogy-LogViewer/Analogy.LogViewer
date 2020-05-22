using Analogy.Interfaces;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Analogy.Forms
{
    public partial class OpenWindows : DevExpress.XtraEditors.XtraForm
    {
        private class LogItem
        {
            public string Header { get; set; }
            public ILogWindow Window { get; set; }

            public override string ToString()
            {
                return $"{nameof(Header)}: {Header}";
            }
        }
        private List<(string Text, ILogWindow window)> Logs { get; }
        private UserSettingsManager settings => UserSettingsManager.UserSettings;
        public OpenWindows()
        {
            InitializeComponent();
        }

        public OpenWindows(List<(string Text, ILogWindow window)> items) : this()
        {
            Logs = items;
        }

        private void OpenWindows_Load(object sender, EventArgs e)
        {
            Icon = settings.GetIcon();
            chklistLogs.Items.AddRange(Logs.Select(l => new LogItem { Window = l.window, Header = l.Text }).ToArray());
        }

        private void btnCombineSelected_Click(object sender, EventArgs e)
        {
            XtraFormLogGrid msg = new XtraFormLogGrid();

            foreach (CheckedListBoxItem item in chklistLogs.CheckedItems)
            {
                var log = item.Value as LogItem;
                msg.AppendMessages(log.Window.GetMessages(), log.Header);
            }
            msg.Show(this);
        }
    }
}