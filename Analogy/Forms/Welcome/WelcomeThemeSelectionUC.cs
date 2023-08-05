using Analogy.Common.Interfaces;
using Analogy.DataTypes;
using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy.Forms.Welcome
{
    public partial class WelcomeThemeSelectionUC : XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; }
        private IFactoriesManager FactoriesManager { get; }
        public WelcomeThemeSelectionUC(IAnalogyUserSettings settings, IFactoriesManager factoriesManager)
        {
            Settings = settings;
            FactoriesManager = factoriesManager;
            InitializeComponent();
        }

        private void WelcomeThemeSelectionUC_Load(object sender, EventArgs e)
        {
  

        }

        private void sbtnSettingsTheme_Click(object sender, EventArgs e)
        {
            ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ApplicationUISettings, Settings, FactoriesManager);
            user.ShowDialog(this);
        }
    }
}
