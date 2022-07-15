using Analogy.DataTypes;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.CommonControls.DataTypes;
using Analogy.Interfaces;
using DevExpress.LookAndFeel;
using DevExpress.Utils;

namespace Analogy.Forms
{
    public partial class FirstTimeRunForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IAnalogyUserSettings _settings = UserSettingsManager.UserSettings;
        private int _selectedStep = 0;

        private IAnalogyUserSettings Settings => _settings;

        private int SelectedStep
        {
            get => _selectedStep;
            set
            {
                _selectedStep = value;
                stepProgressBar1.SelectedItemIndex = value;
                xtraTabControl1.SelectedTabPageIndex = value;
            }
        }

        public FirstTimeRunForm()
        {
            InitializeComponent();
            UserLookAndFeel.Default.StyleChanged += (s, e) =>
            {
                UserLookAndFeel laf = (UserLookAndFeel)s;
                lblSkinName.Text = "Skin name: " + laf.ActiveSkinName;
                lblApplicationStyle.Text = "Application style: " + laf.Style;
                lblSvgPalette.Text = "Active Svg Palette: " + laf.ActiveSvgPaletteName;

            };
        }

        private async void FirstTimeRunForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            lblSkinName.Text = "Skin name: " + Settings.ApplicationSkinName;
            lblApplicationStyle.Text = "Application style: " + Settings.ApplicationStyle;
            lblSvgPalette.Text = "Active Svg Palette: " + Settings.ApplicationSvgPaletteName;
            xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
            Icon = UserSettingsManager.UserSettings.GetIcon();
            await FactoriesManager.Instance.InitializeBuiltInFactories();
            await FactoriesManager.Instance.AddExternalDataSources();
            chkLstDataProviderStatus.CustomizeItem += (s, e) =>
            {
                FactoryCheckItem bind = (FactoryCheckItem)e.Value;
                e.TemplatedItem.Elements[0].ImageOptions.Image = bind.Image;
                e.TemplatedItem.Elements[1].Text = $"{bind.Name} (id:{bind.ID})";
                e.TemplatedItem.Elements[2].Text = bind.Description;
            };
            chkLstDataProviderStatus.ItemCheck += (s, e) => SaveSettings();

            foreach (var setting in Settings.FactoriesOrder)
            {
                FactorySettings factory = Settings.GetFactorySetting(setting);
                if (factory == null)
                {
                    continue;
                }

                var factoryContainer = FactoriesManager.Instance.FactoryContainer(factory.FactoryId);
                string about = (factoryContainer?.Factory != null) ? factoryContainer.Factory.About : "Disabled";
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

        private void AcceptAndClose(object sender, EventArgs e)
        {
            Settings.IsFirstRun = false;
            Close();
        }

        private void SaveSettings()
        {
            foreach (CheckedListBoxItem item in chkLstDataProviderStatus.Items)
            {
                FactoryCheckItem fci = (FactoryCheckItem)item.Value;
                var guid = fci.ID;
                var factory = Settings.FactoriesSettings.SingleOrDefault(f => f.FactoryId == guid);
                if (factory != null)
                {
                    factory.Status = item.CheckState == CheckState.Checked
                        ? DataProviderFactoryStatus.Enabled
                        : DataProviderFactoryStatus.Disabled;
                }
            }
        }

    }
}