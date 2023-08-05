using Analogy.Common.Interfaces;
using Analogy.DataTypes;
using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy.Forms.Welcome
{
    public partial class WelcomeGeneralUC : XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; }
        private IFactoriesManager FactoriesManager { get; }
        public WelcomeGeneralUC(IAnalogyUserSettings settings, IFactoriesManager factoriesManager)
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
