using Analogy.Common.Interfaces;
using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Managers;
using DevExpress.XtraEditors;

namespace Analogy.Forms.Welcome
{
    public partial class WelcomeGeneralUC : XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; }
        private IFactoriesManager FactoriesManager { get; }
        private IAnalogyFoldersAccess FoldersAccess { get; }
        private UpdateManager UpdateManager { get; }

        public WelcomeGeneralUC(IAnalogyUserSettings settings, IFactoriesManager factoriesManager, IAnalogyFoldersAccess foldersAccess, UpdateManager updateManager)
        {
            Settings = settings;
            FactoriesManager = factoriesManager;
            FoldersAccess = foldersAccess;
            UpdateManager = updateManager;
            InitializeComponent();
        }

        private void sbtnOpenSettings_Click(object sender, EventArgs e)
        {
            ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ApplicationGeneralSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
            user.ShowDialog(this);
        }
    }
}
