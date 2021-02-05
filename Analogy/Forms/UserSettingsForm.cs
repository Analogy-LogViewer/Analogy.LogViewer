using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Managers;
using Analogy.Properties;
using DevExpress.Utils;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Analogy.Forms
{

    public partial class UserSettingsForm : XtraForm
    {


        private DataTable messageData;
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;
        private int InitialSelection = -1;

        public UserSettingsForm()
        {
            InitializeComponent();
            messageData = Utils.DataTableConstructor();
        }

        public UserSettingsForm(int tabIndex) : this()
        {
            InitialSelection = tabIndex;
        }

        private void UserSettingsForm_Load(object sender, EventArgs e)
        {
            ShowIcon = true;
            logGrid.MouseDown += logGrid_MouseDown;
            Icon = UserSettingsManager.UserSettings.GetIcon();
            LoadSettings();
            SetupEventsHandlers();
            if (File.Exists(Settings.LogGridFileName))
            {
                gridControl.MainView.RestoreLayoutFromXml(Settings.LogGridFileName);
            }

            gridControl.DataSource = messageData.DefaultView;
            SetupExampleMessage("Test 1");
            SetupExampleMessage("Test 2");
            if (InitialSelection >= 0)
            {
                tabControlMain.SelectedTabPageIndex = InitialSelection;
            }
        }
        void logGrid_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo info = logGrid.CalcHitInfo(e.Location);
            if (info.InColumnPanel)
            {
                teHeader.Tag = info.Column;
                teHeader.Text = info.Column.Caption;
            }
        }
        private void SetupEventsHandlers()
        {
            gridControl.MainView.Layout += MainView_Layout;
        }

        private void MainView_Layout(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTabPage == xtraTabPageFilter && xtraTabPageFilter.Visible)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Settings.LogGridFileName))
                    {
                        gridControl.MainView.SaveLayoutToXml(Settings.LogGridFileName);
                    }
                }
                catch (Exception ex)
                {
                    AnalogyLogManager.Instance.LogError(ex.Message, nameof(MainView_Layout));
                }
            }
        }

        private void LoadSettings()
        {
            logGrid.Columns["Date"].DisplayFormat.FormatType = FormatType.DateTime;
            logGrid.Columns["Date"].DisplayFormat.FormatString = Settings.DateTimePattern;
            teDateTimeFormat.Text = Settings.DateTimePattern;
            listBoxFoldersProbing.Items.AddRange(Settings.AdditionalProbingLocations.ToArray());
            nudRecentFiles.Value = Settings.RecentFilesCount;
            nudRecentFolders.Value = Settings.RecentFoldersCount;
            //tsSimpleMode.IsOn = Settings.SimpleMode;

            toggleSwitchIdleMode.IsOn = Settings.IdleMode;
            nudIdleTime.Value = Settings.IdleTimeMinutes;

            var startup = Settings.AutoStartDataProviders;
            var loaded = FactoriesManager.Instance.GetRealTimeDataSourcesNamesAndIds();
            foreach (var realTime in loaded)
            {
                FactoryCheckItem itm = new FactoryCheckItem(realTime.Name, realTime.ID, realTime.Description, realTime.Image);
                chkLstItemRealTimeDataSources.Items.Add(itm, startup.Contains(itm.ID));
            }

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

            //file associations:

            cbDataProviderAssociation.Properties.DataSource = Settings.FactoriesSettings;
            cbDataProviderAssociation.Properties.DisplayMember = "FactoryName";
            cbDataProviderAssociation.EditValue = Settings.FactoriesSettings.First();
            //cbDataProviderAssociation.Properties.ValueMember = "ID";
            tsRememberLastOpenedDataProvider.IsOn = Settings.RememberLastOpenedDataProvider;
            
            cbUpdates.Properties.Items.AddRange(typeof(UpdateMode).GetDisplayValues().Values);
            cbUpdates.SelectedItem = UpdateManager.Instance.UpdateMode.GetDisplay();
            if (AnalogyNonPersistSettings.Instance.DisableUpdatesByDataProvidersOverrides)
            {
                lblDisableUpdates.Visible = true;
                cbUpdates.Enabled = false;
            }
            
        
            tsEnableFirstChanceException.IsOn = Settings.EnableFirstChanceException;

            var extensions = FactoriesManager.Instance.GetAllExtensions();
            foreach (var ex in extensions)
            {
                FactoryCheckItem itm = new FactoryCheckItem(ex.Title, ex.Id, ex.Description, null);
                chkLstItemExtensions.Items.Add(itm, Settings.StartupExtensions.Contains(itm.ID));
            }
        }

        private void SaveSetting()
        {
            Settings.RecentFilesCount = (int)nudRecentFiles.Value;
            Settings.RecentFoldersCount = (int)nudRecentFolders.Value;
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

            Settings.AutoStartDataProviders = new List<Guid>();
            foreach (CheckedListBoxItem item in chkLstItemRealTimeDataSources.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    FactoryCheckItem f = (FactoryCheckItem)item.Value;
                    Settings.AutoStartDataProviders.Add(f.ID);
                }
            }

            Settings.StartupExtensions = new List<Guid>();
            foreach (CheckedListBoxItem item in chkLstItemExtensions.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    FactoryCheckItem f = (FactoryCheckItem)item.Value;
                    Settings.StartupExtensions.Add(f.ID);
                }
            }

            Settings.RememberLastOpenedDataProvider = tsRememberLastOpenedDataProvider.IsOn;
            Settings.UpdateOrder(order);
            Settings.AdditionalProbingLocations = listBoxFoldersProbing.Items.Cast<string>().ToList();

            var options = typeof(UpdateMode).GetDisplayValues();
            UpdateManager.Instance.UpdateMode = (UpdateMode)Enum.Parse(typeof(UpdateMode),
                options.Single(k => k.Value == cbUpdates.SelectedItem.ToString()).Key, true);
            Settings.EnableFirstChanceException = tsEnableFirstChanceException.IsOn;

            Settings.Save();
        }
        
        private void SetupExampleMessage(string text)
        {
            DataRow dtr = messageData.NewRow();
            dtr.BeginEdit();
            dtr["Date"] = DateTime.Now;
            dtr["Text"] = text;
            dtr["Source"] = "Analogy";
            dtr["Level"] = AnalogyLogLevel.Information.ToString();
            dtr["Class"] = AnalogyLogClass.General.ToString();
            dtr["Category"] = "None";
            dtr["User"] = "None";
            dtr["Module"] = "Analogy";
            dtr["ProcessID"] = Process.GetCurrentProcess().Id;
            dtr["ThreadID"] = Thread.CurrentThread.ManagedThreadId;
            dtr["DataProvider"] = string.Empty;
            dtr["MachineName"] = "None";
            dtr.EndEdit();
            messageData.Rows.Add(dtr);
            messageData.AcceptChanges();
        }
     
        private void ToggleSwitchIdleMode_Toggled(object sender, EventArgs e)
        {
            Settings.IdleMode = toggleSwitchIdleMode.IsOn;

        }

        private void NudIdleTime_ValueChanged(object sender, EventArgs e)
        {
            Settings.IdleTimeMinutes = (int)nudIdleTime.Value;

        }

        private void UserSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSetting();
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
                    AnalogyLogManager.Instance.LogError("Error during save to file: " + e, nameof(sBtnExportColors_Click));
                    XtraMessageBox.Show("Error Export: " + ex.Message, @"Error Saving file", MessageBoxButtons.OK,
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
            if (chkLstDataProviderStatus.SelectedIndex <= 0)
            {
                return;
            }

            var selectedIndex = chkLstDataProviderStatus.SelectedIndex;
            var currentValue = chkLstDataProviderStatus.Items[selectedIndex];
            chkLstDataProviderStatus.Items[selectedIndex] = chkLstDataProviderStatus.Items[selectedIndex - 1];
            chkLstDataProviderStatus.Items[selectedIndex - 1] = currentValue;
            chkLstDataProviderStatus.SelectedIndex = chkLstDataProviderStatus.SelectedIndex - 1;
        }

        private void sBtnMoveDown_Click(object sender, EventArgs e)
        {
            if (chkLstDataProviderStatus.SelectedIndex == chkLstDataProviderStatus.Items.Count - 1)
            {
                return;
            }

            var selectedIndex = chkLstDataProviderStatus.SelectedIndex;
            var currentValue = chkLstDataProviderStatus.Items[selectedIndex + 1];
            chkLstDataProviderStatus.Items[selectedIndex + 1] = chkLstDataProviderStatus.Items[selectedIndex];
            chkLstDataProviderStatus.Items[selectedIndex] = currentValue;
            chkLstDataProviderStatus.SelectedIndex = chkLstDataProviderStatus.SelectedIndex + 1;
        }

        private void cbDataProviderAssociation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDataProviderAssociation.EditValue is FactorySettings setting && setting.UserSettingFileAssociations.Any())
            {
                txtbDataProviderAssociation.Text = string.Join(",", setting.UserSettingFileAssociations);
            }
            else
            {
                txtbDataProviderAssociation.Text = string.Empty;
            }
        }

        private void btnSetFileAssociation_Click(object sender, EventArgs e)
        {
            if (cbDataProviderAssociation.EditValue is FactorySettings setting)
            {
                setting.UserSettingFileAssociations = txtbDataProviderAssociation.Text
                    .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }

        private void btnFolderProbingBrowse_Click(object sender, EventArgs e)
        {
#if NETCOREAPP3_1
            using (FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = false
            })
            {
                // Show the FolderBrowserDialog.  
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    teFoldersProbing.Text = folderDlg.SelectedPath;
                }
            }
#else
            using (var dialog = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
                {
                    teFoldersProbing.Text = dialog.FileName;
                }
            }
#endif
        }

        private void btnFolderProbingAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(teFoldersProbing.Text))
            {
                return;
            }

            listBoxFoldersProbing.Items.Add(teFoldersProbing.Text);
        }

        private void btnDeleteFolderProbing_Click(object sender, EventArgs e)
        {
            if (listBoxFoldersProbing.SelectedItem != null)
            {
                listBoxFoldersProbing.Items.Remove(listBoxFoldersProbing.SelectedItem);
            }
        }
        
        private void btnHeaderSet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(teHeader.Text) && teHeader.Tag is DevExpress.XtraGrid.Columns.GridColumn column)
            {
                column.Caption = teHeader.Text;
                SaveGridLayout();
            }
        }
        private void SaveGridLayout()
        {
            try
            {
                gridControl.MainView.SaveLayoutToXml(Settings.LogGridFileName);
            }
            catch (Exception e)
            {
                AnalogyLogger.Instance.LogException($"Error saving setting: {e.Message}", e, "Analogy");
                XtraMessageBox.Show(e.Message, $"Error Saving layout file: {e.Message}", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDateTimeFormat_Click(object sender, EventArgs e)
        {

            logGrid.Columns["Date"].DisplayFormat.FormatType = FormatType.DateTime;
            logGrid.Columns["Date"].DisplayFormat.FormatString = teDateTimeFormat.Text;
            Settings.DateTimePattern = teDateTimeFormat.Text;
        }
        
    }
}

