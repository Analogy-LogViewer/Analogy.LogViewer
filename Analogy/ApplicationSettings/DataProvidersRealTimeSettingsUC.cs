using Analogy.Common.Interfaces;
using Analogy.DataTypes;
using Analogy.Interfaces;
using DevExpress.XtraEditors.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.ApplicationSettings
{
    public partial class DataProvidersRealTimeSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; }
        private IFactoriesManager FactoriesManager { get; }

        public DataProvidersRealTimeSettingsUC(IAnalogyUserSettings settings, IFactoriesManager factoriesManager)
        {
            Settings = settings;
            FactoriesManager = factoriesManager;
            InitializeComponent();
        }

        private void DataProvidersRealTimeSettingsUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }

        private void LoadSettings()
        {
            var loaded = FactoriesManager.GetRealTimeDataSourcesNamesAndIds();
            foreach (var realTime in loaded)
            {
                FactoryCheckItem itm = new FactoryCheckItem(realTime.Name, realTime.ID, realTime.Description,realTime.assembly.GetName(false).Name, realTime.Image);
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
