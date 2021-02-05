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
using Analogy.DataTypes;

namespace Analogy.ApplicationSettings
{
    public partial class ApplicationGeneralSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

        public ApplicationGeneralSettingsUC()
        {
            InitializeComponent();
        }

        private void ApplicationGeneralSettingsUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }

        private void SetupEventsHandlers()
        {
            tsFileCaching.Toggled += (s, e) => Settings.EnableFileCaching = tsFileCaching.IsOn;
            nudAutoCompleteCount.ValueChanged += (s, e) => Settings.NumberOfLastSearches = (int)nudAutoCompleteCount.Value;
            sbtnResetSettings.Click += (s, e) =>
            {
                var result = XtraMessageBox.Show("Are you sure you want to reset all settings to their defaults", @"Reset settings", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    //var owner = this.Owner;
                    //this.FormClosing -= UserSettingsForm_FormClosing;
                    //Hide();
                    //Close();
                    //Settings.ResetSettings();
                    //UserSettingsForm user = new UserSettingsForm();
                    //user.ShowDialog(owner);
                }
            };
            tsAutoComplete.IsOnChanged += (s, e) => { Settings.RememberLastSearches = tsAutoComplete.IsOn; };
            nudAutoCompleteCount.ValueChanged += (s, e) =>
            {
                Settings.NumberOfLastSearches = (int)nudAutoCompleteCount.Value;
            };
            ceSettingsLocationApplicationFolder.CheckedChanged += (s, e) =>
                Settings.SettingsMode = ceSettingsLocationApplicationFolder.Checked
                    ? SettingsMode.ApplicationFolder
                    : SettingsMode.PerUser;
            ceSettingsLocationPerUser.CheckedChanged += (s, e) =>
                Settings.SettingsMode = ceSettingsLocationPerUser.Checked
                    ? SettingsMode.PerUser
                    : SettingsMode.ApplicationFolder;
            nudRealTimeRefreshInterval.ValueChanged += (s, e) =>
                Settings.RealTimeRefreshInterval = (float)nudRealTimeRefreshInterval.Value;
            tsSingleInstance.IsOnChanged += (s, e) => Settings.SingleInstance = tsSingleInstance.IsOn;
            tsAutoComplete.IsOnChanged += (s, e) => Settings.RememberLastSearches = tsAutoComplete.IsOn;
            tsTraybar.IsOnChanged += (s, e) => Settings.MinimizedToTrayBar = tsTraybar.IsOn;
            tsCheckAdditionalInformation.IsOnChanged += (s, e) =>
              Settings.CheckAdditionalInformation = tsCheckAdditionalInformation.IsOn;
            tsFileCaching.IsOnChanged += (s, e) => Settings.EnableFileCaching = tsFileCaching.IsOn;
        }

        private void LoadSettings()
        {

            ceSettingsLocationApplicationFolder.Checked = Settings.SettingsMode == SettingsMode.ApplicationFolder;
            ceSettingsLocationPerUser.Checked = Settings.SettingsMode == SettingsMode.PerUser;
            nudRealTimeRefreshInterval.Value = (decimal)Settings.RealTimeRefreshInterval;
            tsAutoComplete.IsOn = Settings.RememberLastSearches;
            tsFileCaching.IsOn = Settings.EnableFileCaching;
            tsSingleInstance.IsOn = Settings.SingleInstance;
            nudAutoCompleteCount.Value = Settings.NumberOfLastSearches;
            tsTraybar.IsOn = Settings.MinimizedToTrayBar;
            tsCheckAdditionalInformation.IsOn = Settings.CheckAdditionalInformation;


        }
    }
}
