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
    public partial class ShortcutSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

        public ShortcutSettingsUC()
        {
            InitializeComponent();
        }

        private void ShortcutSettingsUC_Load(object sender, EventArgs e)
        {

        }
    }
}
