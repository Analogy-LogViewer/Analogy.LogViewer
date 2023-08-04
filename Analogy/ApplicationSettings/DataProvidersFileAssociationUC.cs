using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.CommonControls.DataTypes;
using Analogy.Interfaces;

namespace Analogy.ApplicationSettings
{
    public partial class DataProvidersFileAssociationUC : DevExpress.XtraEditors.XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; } 
        public DataProvidersFileAssociationUC(IAnalogyUserSettings settings)
        {
            Settings = settings;
            InitializeComponent();
        }

        private void DataProvidersFileAssociationUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }

        private void SetupEventsHandlers()
        {
            cbDataProviderAssociation.EditValueChanged += (s, e) =>
            {
                if (cbDataProviderAssociation.EditValue is FactorySettings setting && setting.UserSettingFileAssociations.Any())
                {
                    txtbDataProviderAssociation.Text = string.Join(",", setting.UserSettingFileAssociations);
                }
                else
                {
                    txtbDataProviderAssociation.Text = string.Empty;
                }
            };
            btnSetFileAssociation.Click += (s, e) =>
            {
                if (cbDataProviderAssociation.EditValue is FactorySettings setting)
                {
                    setting.UserSettingFileAssociations = txtbDataProviderAssociation.Text
                        .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
            };
        }

        private void LoadSettings()
        {
            //file associations:
            cbDataProviderAssociation.Properties.DataSource = Settings.FactoriesSettings;
            cbDataProviderAssociation.Properties.DisplayMember = "FactoryName";
            cbDataProviderAssociation.EditValue = Settings.FactoriesSettings.First();
        }
    }
}
