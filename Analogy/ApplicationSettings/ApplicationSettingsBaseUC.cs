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
    public abstract partial class ApplicationSettingsBaseUC : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;
        protected abstract void LoadSettings();
        protected abstract void SetupEventsHandlers();
        public ApplicationSettingsBaseUC()
        {
            InitializeComponent();
        }

        private void ApplicationSettingsBaseUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }
    }
}
