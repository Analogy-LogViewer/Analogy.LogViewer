using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.CommonControls.DataTypes;
using Analogy.CommonControls.Interfaces;
using Analogy.DataTypes;
using Analogy.Interfaces;

namespace Analogy.ApplicationSettings
{
    public partial class ApplicationGeneralSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; } = ServicesProvider.Instance.GetService<IAnalogyUserSettings>();

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
            tsFileCaching.IsOnChanged += (s, e) => Settings.EnableFileCaching = tsFileCaching.IsOn;
            tsEnableCompressedArchive.IsOnChanged += (s, e) => Settings.EnableCompressedArchives = tsEnableCompressedArchive.IsOn;

            nudRecentFiles.ValueChanged += (s, e) =>
            {
                Settings.RecentFilesCount = (int)nudRecentFiles.Value;
            };
            nudRecentFolders.ValueChanged += (s, e) =>
            {
                Settings.RecentFoldersCount = (int)nudRecentFolders.Value;
            };
            nudIdleTime.ValueChanged += (s, e) =>
            {
                Settings.IdleTimeMinutes = (int)nudIdleTime.Value;
            };
            toggleSwitchIdleMode.IsOnChanged += (s, e) => { Settings.IdleMode = toggleSwitchIdleMode.IsOn; };
        }

        private void LoadSettings()
        {
            toggleSwitchIdleMode.IsOn = Settings.IdleMode;
            nudIdleTime.Value = Settings.IdleTimeMinutes;
            nudRecentFiles.Value = Settings.RecentFilesCount;
            nudRecentFolders.Value = Settings.RecentFoldersCount;
            ceSettingsLocationApplicationFolder.Checked = Settings.SettingsMode == SettingsMode.ApplicationFolder;
            ceSettingsLocationPerUser.Checked = Settings.SettingsMode == SettingsMode.PerUser;
            nudRealTimeRefreshInterval.Value = (decimal)Settings.RealTimeRefreshInterval;
            tsAutoComplete.IsOn = Settings.RememberLastSearches;
            tsFileCaching.IsOn = Settings.EnableFileCaching;
            tsSingleInstance.IsOn = Settings.SingleInstance;
            nudAutoCompleteCount.Value = Settings.NumberOfLastSearches;
            tsTraybar.IsOn = Settings.MinimizedToTrayBar;
            tsEnableCompressedArchive.IsOn = Settings.EnableCompressedArchives;


        }

    }
}
