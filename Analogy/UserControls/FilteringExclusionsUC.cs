using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Common.Interfaces;
using Analogy.Interfaces;
using DevExpress.XtraEditors.Controls;

namespace Analogy.UserControls
{
    public partial class FilteringExclusionsUC : XtraUserControl
    {
        public static List<string> LogLevels { get; } = Utils.LogLevels;
        private IUserSettingsManager Settings { get; } = ServicesProvider.Instance.GetService<IAnalogyUserSettings>();

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
