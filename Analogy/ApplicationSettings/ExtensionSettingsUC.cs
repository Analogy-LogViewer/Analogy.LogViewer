using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Common.Interfaces;
using Analogy.DataTypes;
using Analogy.Interfaces;
using DevExpress.XtraEditors.Controls;

namespace Analogy.ApplicationSettings
{
    public partial class ExtensionSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; } = UserSettingsManager.UserSettings;

        public ExtensionSettingsUC()
        {
            InitializeComponent();
        }

        private void ExtensionSettingsUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }

        private void LoadSettings()
        {

            var extensions = FactoriesManager.Instance.GetAllExtensions();
            foreach (var ex in extensions)
            {
                FactoryCheckItem itm = new FactoryCheckItem(ex.Title, ex.Id, ex.Description, null);
                chkLstItemExtensions.Items.Add(itm, Settings.StartupExtensions.Contains(itm.ID));
            }
        }

        private void SetupEventsHandlers()
        {
            chkLstItemExtensions.ItemCheck += (s, e) =>
            {
                Settings.StartupExtensions = new List<Guid>();
                foreach (CheckedListBoxItem item in chkLstItemExtensions.Items)
                {
                    if (item.CheckState == CheckState.Checked)
                    {
                        FactoryCheckItem f = (FactoryCheckItem)item.Value;
                        Settings.StartupExtensions.Add(f.ID);
                    }
                }
            };
        }
    }
}
