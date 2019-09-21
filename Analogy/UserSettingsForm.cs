using DevExpress.XtraEditors;
using Philips.Analogy.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;
using Philips.Analogy.Interfaces.Interfaces;

namespace Philips.Analogy
{
   
    public partial class UserSettingsForm : XtraForm
    {
        private struct RealTimeCheckItem
        {
            public string Name;
            public Guid ID;

            public RealTimeCheckItem(string name, Guid id)
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

        private void LoadSettings()
        {
            tsHistory.IsOn = Settings.ShowHistoryOfClearedMessages;
            tsFilteringExclude.IsOn = Settings.SaveExcludeTexts;
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
        }
        

        private void tsFilteringExclude_Toggled(object sender, EventArgs e)
        {
            Settings.SaveExcludeTexts = tsFilteringExclude.IsOn;

        }

        private void tsHistory_Toggled(object sender, EventArgs e)
        {
            Settings.ShowHistoryOfClearedMessages = tsHistory.IsOn;
        }

        private void UserSettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
            if (InitialSelection >= 0)
                tabControlMain.SelectedTabPageIndex = InitialSelection;

            var manager = ExtensionsManager.Instance;
            var extensions = manager.GetExtensions().ToList();
            foreach (var extension in extensions)
            {

                chklItems.Items.Add(extension, Settings.StartupExtensions.Contains(extension.ExtensionID));
                chklItems.DisplayMember = "DisplayName";

            }

            var startup = Settings.AutoStartDataSources;
            var loaded = AnalogyFactoriesManager.AnalogyFactories.GetRealTimeDataSourcesNamesAndIds();
            foreach (var realTime in loaded)
            {
                RealTimeCheckItem itm = new RealTimeCheckItem(realTime.Name, realTime.ID);
                chkLstItemRealTimeDataSources.Items.Add(itm, startup.Contains(itm.ID));
            }
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
            Settings.IdleTimeMinutes=(int)nudIdleTime.Value;

        }

        private void ChkLstItemRealTimeDataSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.AutoStartDataSources =
                chkLstItemRealTimeDataSources.CheckedItems.Cast<RealTimeCheckItem>().Select(r => r.ID).ToList();
        }
    }
}
