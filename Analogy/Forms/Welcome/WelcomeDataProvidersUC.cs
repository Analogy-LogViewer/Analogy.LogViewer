
using Analogy.Common.Interfaces;
using Analogy.DataTypes;
using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy.Forms.Welcome
{
    public partial class WelcomeDataProvidersUC : XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; }
        private IFactoriesManager FactoriesManager { get; }

        public WelcomeDataProvidersUC(IAnalogyUserSettings settings, IFactoriesManager factoriesManager)
        {
            Settings = settings;
            FactoriesManager = factoriesManager;
            InitializeComponent();
        }

        private void sbtnDataProvidersSettings_Click(object sender, EventArgs e)
        {
            ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.DataProvidersSettings, Settings, FactoriesManager);
            user.ShowDialog(this);
        }

        private void hllcDataProviders_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            ((HyperlinkLabelControl)sender).LinkVisited = true;
            Utils.OpenLink(e.Link);
        }
    }
}
