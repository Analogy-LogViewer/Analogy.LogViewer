using Analogy.DataTypes;
using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy.Forms.Welcome
{
    public partial class WelcomeGeneralUC : XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; }
        private FactoriesManager FactoriesManager { get; }
        public WelcomeGeneralUC(IAnalogyUserSettings settings, FactoriesManager factoriesManager)
        {
            Settings = settings;
            FactoriesManager = factoriesManager;
            InitializeComponent();
        }

        private void sbtnOpenSettings_Click(object sender, EventArgs e)
        {
            ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ApplicationGeneralSettings, Settings, FactoriesManager);
            user.ShowDialog(this);
        }
    }
}
