using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Analogy.DataSources;
using Analogy.Interfaces;
using Analogy.Managers;
using Analogy.Types;
using DevExpress.Utils;

namespace Analogy
{

    public partial class UserSettingsForm : XtraForm
    {
        private struct FactoryCheckItem
        {
            public string Name;
            public Guid ID;

            public FactoryCheckItem(string name, Guid id)
            {
                Name = name;
                ID = id;
            }

            public override string ToString() => $"{Name} ({ID})";
        }

        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;
        private int InitialSelection = -1;

        public UserSettingsForm()
        {
            InitializeComponent();

        }

        public UserSettingsForm(int tabIndex) : this()
        {
            InitialSelection = tabIndex;
        }
        public UserSettingsForm(string tabName) : this()
        {
            var tab = tabControlMain.TabPages.SingleOrDefault(t => t.Name == tabName);
            if (tab != null)
                InitialSelection = tab.TabIndex;
        }
        private void LoadSettings()
        {
            tsHistory.IsOn = Settings.ShowHistoryOfClearedMessages;
            tsFilteringExclude.IsOn = Settings.SaveSearchFilters;
            nudRecent.Value = Settings.RecentFilesCount;
            tsUserStatistics.IsOn = Settings.EnableUserStatistics;
            //tsSimpleMode.IsOn = Settings.SimpleMode;
            tsFileCaching.IsOn = Settings.EnableFileCaching;
            tswitchExtensionsStartup.IsOn = Settings.LoadExtensionsOnStartup;
            tsStartupRibbonMinimized.IsOn = Settings.StartupRibbonMinimized;
            tsErrorLevelAsDefault.IsOn = Settings.StartupErrorLogLevel;
            chkEditPaging.Checked = Settings.PagingEnabled;
            if (Settings.PagingEnabled)
            {
                nudPageLength.Value = Settings.PagingSize;
            }
            else
            {
                nudPageLength.Enabled = false;
            }

            checkEditSearchAlsoInSourceAndModule.Checked = Settings.SearchAlsoInSourceAndModule;
            toggleSwitchIdleMode.IsOn = Settings.IdleMode;
            nudIdleTime.Value = Settings.IdleTimeMinutes;
            tsDataTimeAscendDescend.IsOn = Settings.DefaultDescendOrder;
            var manager = ExtensionsManager.Instance;
            var extensions = manager.GetExtensions().ToList();
            foreach (var extension in extensions)
            {

                chklItems.Items.Add(extension, Settings.StartupExtensions.Contains(extension.ExtensionID));
                chklItems.DisplayMember = "DisplayName";

            }

            var startup = Settings.AutoStartDataProviders;
            var loaded = FactoriesManager.Instance.GetRealTimeDataSourcesNamesAndIds();
            foreach (var realTime in loaded)
            {
                FactoryCheckItem itm = new FactoryCheckItem(realTime.Name, realTime.ID);
                chkLstItemRealTimeDataSources.Items.Add(itm, startup.Contains(itm.ID));
            }



            foreach (var setting in Settings.FactoriesOrder)
            {
                FactorySettings factory = Settings.GetFactorySetting(setting);
                if (factory == null) continue;
                FactoryCheckItem itm = new FactoryCheckItem(factory.FactoryName, factory.FactoryGuid);
                chkLstDataProviderStatus.Items.Add(itm, factory.Status == DataProviderFactoryStatus.Enabled);
            }
            //add missing:
            foreach (var factory in Settings.FactoriesSettings.Where(itm => !Settings.FactoriesOrder.Contains(itm.FactoryGuid)))
            {

                FactoryCheckItem itm = new FactoryCheckItem(factory.FactoryName, factory.FactoryGuid);
                chkLstDataProviderStatus.Items.Add(itm, factory.Status != DataProviderFactoryStatus.Disabled);
            }

            //file associations:
            cbDataProviderAssociation.DataSource = Settings.FactoriesSettings;
            cbDataProviderAssociation.DisplayMember = "FactoryName";
            tsRememberLastOpenedDataProvider.IsOn = Settings.RememberLastOpenedDataProvider;
            lboxHighlightItems.DataSource = Settings.PreDefinedQueries.Highlights;
            lboxAlerts.DataSource = Settings.PreDefinedQueries.Alerts;
            lboxFilters.DataSource = Settings.PreDefinedQueries.Filters;
            LoadColorSettings();
        }
        private void SaveSetting()
        {
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Unknown, cpeLogLevelUnknown.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Disabled, cpeLogLevelDisabled.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Trace, cpeLogLevelTrace.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Verbose, cpeLogLevelVerbose.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Debug, cpeLogLevelDebug.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Event, cpeLogLevelEvent.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Warning, cpeLogLevelWarning.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Error, cpeLogLevelError.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Critical, cpeLogLevelCritical.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.AnalogyInformation, cpeLogLevelAnalogyInformation.Color);
            Settings.ColorSettings.SetHighlightColor(cpeHighlightColor.Color);

            List<Guid> order = (from FactoryCheckItem itm in chkLstDataProviderStatus.Items select (itm.ID)).ToList();
            var checkedItem = chkLstDataProviderStatus.CheckedItems.Cast<FactoryCheckItem>().ToList();
            foreach (Guid guid in order)
            {
                var factory = Settings.FactoriesSettings.SingleOrDefault(f => f.FactoryGuid == guid);
                if (factory != null)
                {
                    factory.Status = checkedItem.Exists(f => f.ID == guid)
                        ? DataProviderFactoryStatus.Enabled
                        : DataProviderFactoryStatus.Disabled;
                }
            }
            Settings.RememberLastOpenedDataProvider = tsRememberLastOpenedDataProvider.IsOn;
            Settings.UpdateOrder(order);
            Settings.Save();
        }

        private void LoadColorSettings()
        {
            cpeLogLevelUnknown.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Unknown);
            cpeLogLevelDisabled.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Disabled);
            cpeLogLevelTrace.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Trace);
            cpeLogLevelVerbose.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Verbose);
            cpeLogLevelDebug.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Debug);
            cpeLogLevelEvent.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Event);
            cpeLogLevelWarning.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Warning);
            cpeLogLevelError.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Error);
            cpeLogLevelCritical.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Critical);
            cpeLogLevelAnalogyInformation.Color =
                Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.AnalogyInformation);
            cpeHighlightColor.Color = Settings.ColorSettings.GetHighlightColor();
        }


        private void tsFilteringExclude_Toggled(object sender, EventArgs e)
        {
            Settings.SaveSearchFilters = tsFilteringExclude.IsOn;

        }

        private void tsHistory_Toggled(object sender, EventArgs e)
        {
            Settings.ShowHistoryOfClearedMessages = tsHistory.IsOn;
        }

        private async void UserSettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
            if (InitialSelection >= 0)
                tabControlMain.SelectedTabPageIndex = InitialSelection;

        }

        private void nudRecent_ValueChanged(object sender, EventArgs e)
        {
            Settings.RecentFilesCount = (int)nudRecent.Value;
        }

        private void tsUserStatistics_Toggled(object sender, EventArgs e)
        {
            EnableDisableUserStatistics(tsUserStatistics.IsOn);
            Settings.EnableUserStatistics = tsUserStatistics.IsOn;

        }

        private void EnableDisableUserStatistics(bool isOn)
        {
            if (isOn)
            {
                lblLaunchCount.Text = $"Number of Analogy Launches: {Settings.AnalogyLaunches}";
                lblRunningTime.Text = $"Running Time: {Settings.DisplayRunningTime}";
                lblOpenedFiles.Text = $"Number Of Opened Files: {Settings.AnalogyOpenedFiles}";
            }
            else
            {
                lblLaunchCount.Text = $"Number of Analogy Launches: 0";
                lblRunningTime.Text = $"Running Time: 0";
                lblOpenedFiles.Text = $"Number Of Opened Files: N/A";
            }
        }

        private void btnClearStatistics_Click(object sender, EventArgs e)
        {
            XtraMessageBox.AllowCustomLookAndFeel = true;
            var result = XtraMessageBox.Show("Clear statistics?", "Confirmation Required", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Settings.ClearStatistics();
            }

        }

        private void tsSimpleMode_Toggled(object sender, EventArgs e)
        {
            //Settings.SimpleMode = tsSimpleMode.IsOn;
        }

        private void tsFileCaching_Toggled(object sender, EventArgs e)
        {
            Settings.EnableFileCaching = tsFileCaching.IsOn;
        }

        private void tswitchExtensionsStartup_Toggled(object sender, EventArgs e)
        {
            Settings.LoadExtensionsOnStartup = tswitchExtensionsStartup.IsOn;
            chklItems.Enabled = tswitchExtensionsStartup.IsOn;
        }

        private void chklItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.StartupExtensions =
                chklItems.CheckedItems.Cast<IAnalogyExtension>().Select(ex => ex.ExtensionID).ToList();


        }

        private void tsStartupRibbonMinimized_Toggled(object sender, EventArgs e)
        {
            Settings.StartupRibbonMinimized = tsStartupRibbonMinimized.IsOn;
        }

        private void tsErrorLevelAsDefault_Toggled(object sender, EventArgs e)
        {
            Settings.StartupErrorLogLevel = tsErrorLevelAsDefault.IsOn;
        }

        private void chkEditPaging_CheckedChanged(object sender, EventArgs e)
        {
            Settings.PagingEnabled = chkEditPaging.Checked;
            nudPageLength.Enabled = Settings.PagingEnabled;
        }

        private void nudPageLength_ValueChanged(object sender, EventArgs e)
        {
            Settings.PagingSize = (int)nudPageLength.Value;
        }

        private void checkEditSearchAlsoInSourceAndModule_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SearchAlsoInSourceAndModule = checkEditSearchAlsoInSourceAndModule.Checked;
        }

        private void ToggleSwitchIdleMode_Toggled(object sender, EventArgs e)
        {
            Settings.IdleMode = toggleSwitchIdleMode.IsOn;

        }

        private void NudIdleTime_ValueChanged(object sender, EventArgs e)
        {
            Settings.IdleTimeMinutes = (int)nudIdleTime.Value;

        }

        private void ChkLstItemRealTimeDataSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.AutoStartDataProviders =
                chkLstItemRealTimeDataSources.CheckedItems.Cast<FactoryCheckItem>().Select(r => r.ID).ToList();
        }

        private void UserSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSetting();
        }



        private void tsDataTimeAscendDescend_Toggled(object sender, EventArgs e)
        {
            Settings.DefaultDescendOrder = tsDataTimeAscendDescend.IsOn;

        }

        private void sBtnExportColors_Click(object sender, EventArgs e)
        {
            SaveSetting();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Analogy Color Settings (*.json)|*.json";
            saveFileDialog.Title = @"Export Analogy Color settings";

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {

                try
                {
                    File.WriteAllText(saveFileDialog.FileName, Settings.ColorSettings.AsJson());
                    XtraMessageBox.Show("File Saved", @"Export settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    AnalogyLogManager.Instance.LogError("Error during save to file: " + e);
                    XtraMessageBox.Show("Error Export: " + ex.Message, @"Error Saving file", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            }
        }

        private void sBtnImportColors_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Analogy Color Settings (*.json)|*.json";
            openFileDialog1.Title = @"Import NLog settings";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var json = File.ReadAllText(openFileDialog1.FileName);
                    ColorSettings color = ColorSettings.FromJson(json);
                    Settings.ColorSettings = color;
                    LoadColorSettings();
                    XtraMessageBox.Show("File Imported. Save settings if desired", @"Import settings",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    AnalogyLogManager.Instance.LogError("Error during import data: " + e);
                    XtraMessageBox.Show("Error Import: " + ex.Message, @"Error Import file", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnDataProviderCustomSettings_Click(object sender, EventArgs e)
        {
            UserSettingsDataProvidersForm user = new UserSettingsDataProvidersForm();
            user.ShowDialog(this);
        }

        private void sBtnMoveUp_Click(object sender, EventArgs e)
        {
            if (chkLstDataProviderStatus.SelectedIndex <= 0) return;
            var selectedIndex = chkLstDataProviderStatus.SelectedIndex;
            var currentValue = chkLstDataProviderStatus.Items[selectedIndex];
            chkLstDataProviderStatus.Items[selectedIndex] = chkLstDataProviderStatus.Items[selectedIndex - 1];
            chkLstDataProviderStatus.Items[selectedIndex - 1] = currentValue;
            chkLstDataProviderStatus.SelectedIndex = chkLstDataProviderStatus.SelectedIndex - 1;
        }

        private void sBtnMoveDown_Click(object sender, EventArgs e)
        {
            if (chkLstDataProviderStatus.SelectedIndex == chkLstDataProviderStatus.Items.Count - 1) return;
            var selectedIndex = chkLstDataProviderStatus.SelectedIndex;
            var currentValue = chkLstDataProviderStatus.Items[selectedIndex + 1];
            chkLstDataProviderStatus.Items[selectedIndex + 1] = chkLstDataProviderStatus.Items[selectedIndex];
            chkLstDataProviderStatus.Items[selectedIndex] = currentValue;
            chkLstDataProviderStatus.SelectedIndex = chkLstDataProviderStatus.SelectedIndex + 1;
        }

        private void cbDataProviderAssociation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDataProviderAssociation.SelectedItem is FactorySettings setting && setting.UserSettingFileAssociations.Any())
                txtbDataProviderAssociation.Text = string.Join(",", setting.UserSettingFileAssociations);
            else
                txtbDataProviderAssociation.Text = string.Empty;

        }

        private void btnSetFileAssociation_Click(object sender, EventArgs e)
        {
            if (cbDataProviderAssociation.SelectedItem is FactorySettings setting)
                setting.UserSettingFileAssociations = txtbDataProviderAssociation.Text
                    .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private void rbtnHighlightContains_CheckedChanged(object sender, EventArgs e)
        {
            teHighlightContains.Enabled = rbtnHighlightContains.Checked;
            teHighlightEquals.Enabled = rbtnHighlightEquals.Checked;
        }

        private void rbtnHighlightEquals_CheckedChanged(object sender, EventArgs e)
        {
            teHighlightContains.Enabled = rbtnHighlightContains.Checked;
            teHighlightEquals.Enabled = rbtnHighlightEquals.Checked;
        }

        private void sbtnAddHighlight_Click(object sender, EventArgs e)
        {
            if (rbtnHighlightContains.Checked)
            {
                Settings.PreDefinedQueries.AddHighlight(teHighlightContains.Text,PreDefinedQueryType.Contains,cpeHighlightPreDefined.Color);
                lboxHighlightItems.DataSource = Settings.PreDefinedQueries.Highlights;
                lboxHighlightItems.Refresh();
            }

            if (rbtnHighlightEquals.Checked)
            {
                Settings.PreDefinedQueries.AddHighlight(teHighlightEquals.Text, PreDefinedQueryType.Equals, cpeHighlightPreDefined.Color);
                lboxHighlightItems.DataSource = Settings.PreDefinedQueries.Highlights;
                lboxHighlightItems.Refresh();
            }
        }

        private void sbtnDeleteHighlight_Click(object sender, EventArgs e)
        {
            if (lboxHighlightItems.SelectedItem is PreDefineHighlight highlight)
            {
                Settings.PreDefinedQueries.RemoveHighlight(highlight);
                lboxHighlightItems.DataSource = Settings.PreDefinedQueries.Highlights;
                lboxHighlightItems.Refresh();
            }
        }

        private void sbtnAddFilter_Click(object sender, EventArgs e)
        {
            Settings.PreDefinedQueries.AddFilter(txtbIncludeTextFilter.Text, txtbExcludeFilter.Text, txtbSourcesFilter.Text, txtbModulesFilter.Text);
            lboxFilters.DataSource = Settings.PreDefinedQueries.Filters;
            lboxFilters.Refresh();
        }

        private void sbtnDeleteFilter_Click(object sender, EventArgs e)
        {
            if (lboxFilters.SelectedItem is PreDefineFilter filter)
            {
                Settings.PreDefinedQueries.RemoveFilter(filter);
                lboxFilters.DataSource = Settings.PreDefinedQueries.Filters;
                lboxFilters.Refresh();
            }
        }

        private void sbtnAddAlerts_Click(object sender, EventArgs e)
        {
            Settings.PreDefinedQueries.AddAlert(txtbIncludeTextAlert.Text, txtbExcludeAlert.Text, txtbSourcesAlert.Text, txtbModulesAlert.Text);
            lboxAlerts.DataSource = Settings.PreDefinedQueries.Alerts;
            lboxAlerts.Refresh();
        }

        private void sbtnDeleteAlerts_Click(object sender, EventArgs e)
        {
            if (lboxAlerts.SelectedItem is PreDefineAlert alert)
            {
                Settings.PreDefinedQueries.RemoveAlert(alert);
                lboxAlerts.DataSource = Settings.PreDefinedQueries.Alerts;
                lboxAlerts.Refresh();
            }
        }
    }
}
