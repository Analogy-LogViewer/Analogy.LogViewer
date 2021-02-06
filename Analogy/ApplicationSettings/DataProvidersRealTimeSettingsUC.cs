using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.DataTypes;
using DevExpress.XtraEditors.Controls;

namespace Analogy.ApplicationSettings
{
    public partial class DataProvidersRealTimeSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

        public DataProvidersRealTimeSettingsUC()
        {
            InitializeComponent();
        }

        private void DataProvidersRealTimeSettingsUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }

        private void LoadSettings()
        {
            var loaded = FactoriesManager.Instance.GetRealTimeDataSourcesNamesAndIds();
            foreach (var realTime in loaded)
            {
                FactoryCheckItem itm = new FactoryCheckItem(realTime.Name, realTime.ID, realTime.Description, realTime.Image);
                chkLstItemRealTimeDataSources.Items.Add(itm, Settings.AutoStartDataProviders.Contains(itm.ID));
            }
        }

        private void SetupEventsHandlers()
        {
            chkLstItemRealTimeDataSources.ItemCheck += (s, e) =>
            {
                Settings.AutoStartDataProviders = new List<Guid>();
                foreach (CheckedListBoxItem item in chkLstItemRealTimeDataSources.Items)
                {
                    if (item.CheckState == CheckState.Checked)
                    {
                        FactoryCheckItem f = (FactoryCheckItem)item.Value;
                        Settings.AutoStartDataProviders.Add(f.ID);
                    }
                }
            };
        }
    }
}
