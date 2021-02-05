using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.ApplicationSettings
{
    public partial class PredefinedAlertsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

        public PredefinedAlertsUC()
        {
            InitializeComponent();
        }

        private void PredefinedAlertsUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }

        private void SetupEventsHandlers()
        {
            sbtnAddFilter.Click += (s, e) =>
            {
                Settings.PreDefinedQueries.AddAlert(txtbIncludeTextFilter.Text, txtbExcludeFilter.Text,
                    txtbSourcesFilter.Text, txtbModulesFilter.Text);
                lboxAlerts.DataSource = Settings.PreDefinedQueries.Alerts;
                lboxAlerts.Refresh();
            };

            sbtnDeleteFilter.Click += (s, e) =>
            {
                if (lboxAlerts.SelectedItem is PreDefineAlert alert)
                {
                    Settings.PreDefinedQueries.RemoveAlert(alert);
                    lboxAlerts.DataSource = Settings.PreDefinedQueries.Alerts;
                    lboxAlerts.Refresh();
                }
            };
        }

        private void LoadSettings()
        {
            lboxAlerts.DataSource = Settings.PreDefinedQueries.Alerts;

        }
    }
}
