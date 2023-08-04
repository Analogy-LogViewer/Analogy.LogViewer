using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Common.Interfaces;
using Analogy.DataTypes;
using Analogy.Interfaces;

namespace Analogy.ApplicationSettings
{
    public partial class DebuggingSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; } 
        public DebuggingSettingsUC(IAnalogyUserSettings settings)
        {
            Settings = settings;
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
