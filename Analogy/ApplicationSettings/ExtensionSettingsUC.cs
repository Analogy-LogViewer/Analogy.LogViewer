using Analogy.Common.Interfaces;
using Analogy.DataTypes;
using Analogy.Interfaces;
using DevExpress.XtraEditors.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.ApplicationSettings
{
    public partial class ExtensionSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; }
        private IFactoriesManager FactoriesManager { get; }

        public ExtensionSettingsUC(IAnalogyUserSettings settings, IFactoriesManager factoriesManager)
        {
            this.Settings = settings;
            FactoriesManager = factoriesManager;
            InitializeComponent();
        }

        private void ExtensionSettingsUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }

        private void LoadSettings()
        {

            var extensions = FactoriesManager.GetAllExtensionsWithAssemblies();
            foreach (var (ex, assembly) in extensions)
            {

                FactoryCheckItem itm = new FactoryCheckItem(ex.Title, ex.Id, ex.Description,assembly.GetName(false).Name, null);
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