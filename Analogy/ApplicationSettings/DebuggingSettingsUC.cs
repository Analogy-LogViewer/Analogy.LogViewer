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
    public partial class DebuggingSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

        public DebuggingSettingsUC()
        {
            InitializeComponent();
        }

        private void DebuggingSettingsUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }

        private void LoadSettings()
        {
            Settings.EnableFirstChanceException = tsEnableFirstChanceException.IsOn;
        }

        private void SetupEventsHandlers()
        {
            tsEnableFirstChanceException.IsOnChanged += (s, e) =>
              Settings.EnableFirstChanceException = tsEnableFirstChanceException.IsOn;
        }
    }
}
