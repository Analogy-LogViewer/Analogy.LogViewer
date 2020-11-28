using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace Analogy.Forms
{
    public partial class UserStatisticsForm : XtraForm
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

        public UserStatisticsForm()
        {
            InitializeComponent();
        }

        private void UserStatisticsForm_Load(object sender, System.EventArgs e)
        {
            ShowIcon = true;
            Icon = UserSettingsManager.UserSettings.GetIcon();
            LoadSettings();

        }

        private void LoadSettings()
        {
            tsUserStatistics.IsOn = Settings.EnableUserStatistics;
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
                lblLaunchCount.Text = $"Number of Analogy Launches: 0";
                lblRunningTime.Text = $"Running Time: 0";
                lblOpenedFiles.Text = $"Number Of Opened Files: N/A";
            }

        }
    }
}
