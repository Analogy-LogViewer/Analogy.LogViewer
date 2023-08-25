using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.DataTypes;
using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy.ApplicationSettings
{
    public partial class AdvancedSettingsUC : XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; }
        public AdvancedSettingsUC(IAnalogyUserSettings settings)
        {
            Settings = settings;
            InitializeComponent();
        }

        private void AdvancedSettingsUC_Load(object sender, EventArgs arg)
        {
            tsEnabledAdvancedSettings.IsOn = Settings.AdvancedMode;
            tsAdvancedModeAdditionalColumns.IsOn = Settings.AdvancedModeAdditionalFilteringColumnsEnabled;
            tsAdvancedModeRawSQLFiltering.IsOn = Settings.AdvancedModeRawSQLFilterEnabled;
            tsLinux.IsOn = Settings.SupportLinuxFormatting;

            tsEnabledAdvancedSettings.IsOnChanged += (s, e) => Settings.AdvancedMode = tsEnabledAdvancedSettings.IsOn;
            tsAdvancedModeAdditionalColumns.IsOnChanged += (s, e) => Settings.AdvancedModeAdditionalFilteringColumnsEnabled = tsAdvancedModeAdditionalColumns.IsOn;
            tsAdvancedModeRawSQLFiltering.IsOnChanged += (s, e) => Settings.AdvancedModeRawSQLFilterEnabled = tsAdvancedModeRawSQLFiltering.IsOn;
            tsLinux.IsOnChanged += (s, e) => Settings.SupportLinuxFormatting = tsLinux.IsOn;

        }
    }
}
