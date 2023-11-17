using Analogy.Common.Interfaces;
using Analogy.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.UserControls
{
    public partial class FilteringExclusionsUC : XtraUserControl
    {
        public static List<string> LogLevels { get; } = Utils.LogLevels;
        private IUserSettingsManager Settings { get; }
        public FilteringExclusionsUC(IUserSettingsManager settings)
        {
            Settings = settings;
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
