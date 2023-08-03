using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Common.Interfaces;
using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy.ApplicationSettings
{
    public partial class DataProvidersExternalLocationsSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; } = ServicesProvider.Instance.GetService<IAnalogyUserSettings>();

        public DataProvidersExternalLocationsSettingsUC()
        {
            InitializeComponent();
        }

        private void DataProvidersExternalLocations_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }

        private void SetupEventsHandlers()
        {
            sbtnFolderProbingBrowse.Click += (s, e) =>
            {
                using XtraFolderBrowserDialog folderDlg = new XtraFolderBrowserDialog
                {
                    ShowNewFolderButton = false
                };
                // Show the FolderBrowserDialog.  
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    teFoldersProbing.Text = folderDlg.SelectedPath;
                }
            };

            sbtnFolderProbingAdd.Click += (s, e) =>
            {
                if (string.IsNullOrEmpty(teFoldersProbing.Text))
                {
                    return;
                }

                listBoxFoldersProbing.Items.Add(teFoldersProbing.Text);
                Settings.AdditionalProbingLocations.Add(teFoldersProbing.Text);
            };

            sbtnDeleteFolderProbing.Click += (s, e) =>
            {
                if (listBoxFoldersProbing.SelectedItem != null)
                {
                    Settings.AdditionalProbingLocations.Remove(listBoxFoldersProbing.SelectedItem.ToString());
                    listBoxFoldersProbing.Items.Remove(listBoxFoldersProbing.SelectedItem);
                }
            };
        }

        private void LoadSettings()
        {
            listBoxFoldersProbing.Items.AddRange(Settings.AdditionalProbingLocations.ToArray());
        }
    }
}
