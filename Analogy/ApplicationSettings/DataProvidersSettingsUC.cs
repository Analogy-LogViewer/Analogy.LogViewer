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
    public partial class DataProvidersSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

        public DataProvidersSettingsUC()
        {
            InitializeComponent();
        }

        private void DataProvidersSettingsUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }

        private void LoadSettings()
        {         
            tsRememberLastOpenedDataProvider.IsOn = Settings.RememberLastOpenedDataProvider;
            foreach (var setting in Settings.FactoriesOrder)
            {
                FactorySettings factory = Settings.GetFactorySetting(setting);
                if (factory == null)
                {
                    continue;
                }

                var factoryContainer = FactoriesManager.Instance.FactoryContainer(factory.FactoryId);
                string about = (factoryContainer?.Factory != null) ? factoryContainer.Factory.About : "Not found";
                var image = FactoriesManager.Instance.GetLargeImage(factory.FactoryId);
                FactoryCheckItem itm = new FactoryCheckItem(factory.FactoryName, factory.FactoryId, about, image);
                chkLstDataProviderStatus.Items.Add(itm, factory.Status == DataProviderFactoryStatus.Enabled);
            }
            //add missing:
            foreach (var factory in Settings.FactoriesSettings.Where(itm => !Settings.FactoriesOrder.Contains(itm.FactoryId)))
            {
                var factoryContainer = FactoriesManager.Instance.FactoryContainer(factory.FactoryId);
                string about = (factoryContainer?.Factory != null) ? factoryContainer.Factory.About : "Disabled";
                var image = FactoriesManager.Instance.GetLargeImage(factory.FactoryId);
                FactoryCheckItem itm = new FactoryCheckItem(factory.FactoryName, factory.FactoryId, about, image);
                chkLstDataProviderStatus.Items.Add(itm, factory.Status != DataProviderFactoryStatus.Disabled);
            }
        }

        private void SetupEventsHandlers()
        {
            chkLstDataProviderStatus.ItemCheck += (s, e) => SaveSettings();
            tsRememberLastOpenedDataProvider.IsOnChanged += (s, e) =>
                Settings.RememberLastOpenedDataProvider = tsRememberLastOpenedDataProvider.IsOn;
            chkLstDataProviderStatus.CustomizeItem += (s, e) =>
            {
                FactoryCheckItem bind = (FactoryCheckItem) e.Value;
                e.TemplatedItem.Elements[0].ImageOptions.Image = bind.Image;
                e.TemplatedItem.Elements[1].Text = $"{bind.Name} (id:{bind.ID})";
                e.TemplatedItem.Elements[2].Text = bind.Description;
            };
        }

        private void SaveSettings()
        {
            List<Guid> order = new List<Guid>(chkLstDataProviderStatus.Items.Count);
            foreach (CheckedListBoxItem item in chkLstDataProviderStatus.Items)
            {
                FactoryCheckItem fci = (FactoryCheckItem)item.Value;
                order.Add(fci.ID);
                var guid = fci.ID;
                var factory = Settings.FactoriesSettings.SingleOrDefault(f => f.FactoryId == guid);
                if (factory != null)
                {
                    factory.Status = item.CheckState == CheckState.Checked
                        ? DataProviderFactoryStatus.Enabled
                        : DataProviderFactoryStatus.Disabled;
                }
            }

            Settings.UpdateOrder(order);

        }
    }
}
