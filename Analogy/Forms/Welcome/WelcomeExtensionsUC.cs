using Analogy.DataTypes;
using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy.Forms.Welcome
{
    public partial class WelcomeExtensionsUC : XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; }
        private FactoriesManager FactoriesManager { get; }
        public WelcomeExtensionsUC(IAnalogyUserSettings settings, FactoriesManager factoriesManager)
        {
            Settings = settings;
            FactoriesManager = factoriesManager;
            InitializeComponent();
        }

        private void sbtnExtensionsSettings_Click(object sender, EventArgs e)
        {
            ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ExtensionsSettings, Settings, FactoriesManager);
            user.ShowDialog(this);
        }
    }
}
