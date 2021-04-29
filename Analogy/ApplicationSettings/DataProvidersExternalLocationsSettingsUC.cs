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
    public partial class DataProvidersExternalLocationsSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

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
#if NETCOREAPP3_1 || NET
            using (FolderBrowserDialog folderDlg = new FolderBrowserDialog
            {
                ShowNewFolderButton = false
            })
            {
                // Show the FolderBrowserDialog.  
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    teFoldersProbing.Text = folderDlg.SelectedPath;
                }
            }
#else
                using (var dialog = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog())
                {
                    dialog.IsFolderPicker = true;
                    if (dialog.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
                    {
                        teFoldersProbing.Text = dialog.FileName;
                    }
                }
#endif
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
                    Settings.AdditionalProbingLocations.Remove(teFoldersProbing.Text);
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
