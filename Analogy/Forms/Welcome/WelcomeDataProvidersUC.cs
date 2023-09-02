
using Analogy.Common.Interfaces;
using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Managers;
using DevExpress.XtraEditors;

namespace Analogy.Forms.Welcome
{
    public partial class WelcomeDataProvidersUC : XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; }
        private IFactoriesManager FactoriesManager { get; }
        private UpdateManager UpdateManager { get; }

        public WelcomeDataProvidersUC(IAnalogyUserSettings settings, IFactoriesManager factoriesManager, UpdateManager updateManager)
        {
            Settings = settings;
            FactoriesManager = factoriesManager;
            UpdateManager = updateManager;
            InitializeComponent();
        }

        private void sbtnDataProvidersSettings_Click(object sender, EventArgs e)
        {
            ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.DataProvidersSettings, Settings, FactoriesManager, UpdateManager);
            user.ShowDialog(this);
        }

        private void hllcDataProviders_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            ((HyperlinkLabelControl)sender).LinkVisited = true;
            Utils.OpenLink(e.Link);
        }
    }
}
