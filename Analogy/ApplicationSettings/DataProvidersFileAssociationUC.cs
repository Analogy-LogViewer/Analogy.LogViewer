using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.ApplicationSettings
{
    public partial class DataProvidersFileAssociationUC : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

        public DataProvidersFileAssociationUC()
        {
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
