using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy.Extensions
{
    public partial class LogsMessageGroupingExtensionUC : XtraUserControl
    {
        public LogsMessageGroupingExtensionUC()
        {
            InitializeComponent();
        }

        private void txtbGroupByChars_EditValueChanged(object sender, EventArgs e)
        {
            rbGroupByText.Checked = true;
        }

        private void sBtnLength_Click(object sender, EventArgs e)
        {
            ApplyGrouping();
        }

        private void nudGroupBychars_ValueChanged(object sender, EventArgs e)
        {
            rbGroupByTextLength.Checked = true;
        }

        private void sBtnGroup_Click(object sender, EventArgs e)
        {
            ApplyGrouping();
        }

        private void ApplyGrouping()
        {
            if (rbGroupByTextLength.Checked)
            {
                gCtrlGrouping.DataSource = null;
                List<IGrouping<string, AnalogyLogMessage>> grouped = Messages
                    .GroupBy(s => s.Text.Substring(0, Math.Min(s.Text.Length, (int)nudGroupBychars.Value)))
                    .OrderByDescending(i => i.Count()).ToList();
                groupingByChars = grouped.ToDictionary(g => g.Key, g => g.ToList());
                gCtrlGrouping.DataSource = groupingByChars.Keys;
            }
            else // group by text
            {
                gCtrlGrouping.DataSource = null;
                List<IGrouping<string, AnalogyLogMessage>> grouped = Messages.Where(m => m.Text.Contains(txtbGroupByChars.Text, StringComparison.CurrentCultureIgnoreCase))
                    .GroupBy(s => s.Text)
                    .OrderByDescending(i => i.Count()).ToList();
                groupingByChars = grouped.ToDictionary(g => g.Key, g => g.ToList());
                gCtrlGrouping.DataSource = groupingByChars.Keys;
            }
        }
    }
}
