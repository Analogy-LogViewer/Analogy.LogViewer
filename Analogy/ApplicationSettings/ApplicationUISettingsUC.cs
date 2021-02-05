using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace Analogy.ApplicationSettings
{
    public partial class ApplicationUISettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

        public ApplicationUISettingsUC()
        {
            InitializeComponent();
        }

        private void ApplicationUISettingsUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }

        private void SetupEventsHandlers()
        {
            tsStartupRibbonMinimized.Toggled +=
                (s, e) => Settings.StartupRibbonMinimized = tsStartupRibbonMinimized.IsOn;
            tsRibbonCompactStyle.IsOnChanged += (s, e) =>
            {
                Settings.RibbonStyle = tsRibbonCompactStyle.IsOn
                    ? CommandLayout.Simplified
                    : CommandLayout.Classic;
            };
            tsRememberLastPositionAndState.IsOnChanged += (s, e) =>
              Settings.AnalogyPosition.RememberLastPosition = tsRememberLastPositionAndState.IsOn;

        }

        private void LoadSettings()
        {
            tsRememberLastPositionAndState.IsOn = Settings.AnalogyPosition.RememberLastPosition;
            tsStartupRibbonMinimized.IsOn = Settings.StartupRibbonMinimized;
            tsRibbonCompactStyle.IsOn = Settings.RibbonStyle == CommandLayout.Simplified;

        }
    }
}
