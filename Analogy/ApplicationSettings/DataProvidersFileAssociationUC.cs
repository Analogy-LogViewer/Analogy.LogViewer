using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.CommonControls.DataTypes;
using Analogy.Interfaces;
using DevExpress.XtraRichEdit.Model;

namespace Analogy.ApplicationSettings
{
    public partial class DataProvidersFileAssociationUC : DevExpress.XtraEditors.XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; }
        private IFactoriesManager FactoriesManager { get; }

        public DataProvidersFileAssociationUC(IAnalogyUserSettings settings, IFactoriesManager factoriesManager)
        {
            Settings = settings;
            FactoriesManager = factoriesManager;
            InitializeComponent();
        }

        private void DataProvidersFileAssociationUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }

        private void SetupEventsHandlers()
        {
            cbDataProviderFactoryAssociation.EditValueChanged += (s, e) =>
            {
                if (cbDataProviderFactoryAssociation.EditValue is FactorySettings setting)
                {
                    LoadProviders(setting);
                }
            };
            cbFileProviderAssociation.EditValueChanged += (s, e) =>
            {
                if (cbFileProviderAssociation.EditValue is ProviderEntry dp)
                {
                    if (Settings.TryGetFileAssociations(dp.Id, out var associations))
                    {
                        txtbDataProviderAssociation.Text = string.Join(",", associations);
                    }
                    else
                    {
                        txtbDataProviderAssociation.Text = string.Empty;
                    }
                }
                else
                {
                    txtbDataProviderAssociation.Text = string.Empty;
                }

                btnSetFileAssociation.Click += (_, __) =>
                {
                    if (cbFileProviderAssociation.EditValue is ProviderEntry provider)
                    {
                        Settings.UpdateFileAssociations(provider.Id, txtbDataProviderAssociation.Text
                            .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList());
                    }
                };
            };
        }

        private void LoadSettings()
        {
            var valids = Settings.FactoriesSettings
                .Where(f => FactoriesManager.GetOfflineDataSources(f.FactoryId).Any()).ToList();
            FactorySettings defaultSelection = valids.First();
            //file associations:
            cbDataProviderFactoryAssociation.Properties.DataSource = valids;
            cbDataProviderFactoryAssociation.Properties.DisplayMember = nameof(FactorySettings.FactoryName);
            cbDataProviderFactoryAssociation.EditValue = defaultSelection;
            LoadProviders(defaultSelection);
        }

        private void LoadProviders(FactorySettings factorySelection)
        {
            IEnumerable<ProviderEntry> providers = FactoriesManager.GetOfflineDataSources(factorySelection.FactoryId).Select(d => new ProviderEntry(d.OptionalTitle, d.Id));
            cbFileProviderAssociation.Properties.DataSource = providers;
            cbFileProviderAssociation.Properties.DisplayMember = nameof(ProviderEntry.OptionalTitle);
            cbFileProviderAssociation.EditValue = providers.FirstOrDefault();

        }

        private record ProviderEntry(string? OptionalTitle, Guid Id);
    }
}
