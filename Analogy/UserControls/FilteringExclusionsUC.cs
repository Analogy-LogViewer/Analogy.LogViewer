using DevExpress.XtraEditors;
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
using DevExpress.XtraEditors.Controls;

namespace Analogy.UserControls
{
    public partial class FilteringExclusionsUC : DevExpress.XtraEditors.XtraUserControl
    {
        public static List<string> LogLevels { get; } = Utils.LogLevels;
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

        public FilteringExclusionsUC()
        {
            InitializeComponent();

        }


        public void SetLogLevel(CheckedListBoxControl chkLstLogLevel)
        {
            chkLstLogLevel.Items.Clear();
            chkLstLogLevel.CheckMode = CheckMode.Multiple;
            chkLstLogLevel.CheckStyle = CheckStyles.Standard;
            chkLstLogLevel.Items.AddRange(LogLevels.Select(l => new CheckedListBoxItem(l, 
                Settings.FilteringExclusion.IsLogLevelExcluded(l))).ToArray());
        }

        private void FilteringExclusionsUC_Load(object sender, EventArgs e)
        {
            SetLogLevel(chkLstLogLevel);
        }
    }
}
