using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Analogy.DataProviders.Extensions;
using Analogy.Interfaces;
using DevExpress.Utils;
using Newtonsoft.Json;

namespace Analogy
{

    public partial class UserSettingsDataProvidersForm : XtraForm
    {
        private struct RealTimeCheckItem
        {
            public string Name;
            public Guid ID;

            public RealTimeCheckItem(string name, Guid id)
            {
                Name = name;
                ID = id;
            }

            public override string ToString() => $"{Name} ({ID})";
        }

        private UserSettingsManager Settings => UserSettingsManager.UserSettings;
        private readonly int _initialSelection = -1;

        public UserSettingsDataProvidersForm()
        {
            InitializeComponent();

        }

        public UserSettingsDataProvidersForm(int tabIndex) : this()
        {
            _initialSelection = tabIndex;
        }

        public UserSettingsDataProvidersForm(string tabName) : this()
        {
            var tab = tabControlMain.TabPages.SingleOrDefault(t => t.Name == tabName);
            if (tab != null)
                _initialSelection = tab.TabIndex;
        }

        private void LoadSettings()
        {
            LoadNLogSettings(Settings.LogParsersSettings.NLogParserSettings);
           
        }

        private void LoadNLogSettings(ILogParserSettings nLogParserSettings)
        {
            if (nLogParserSettings.IsConfigured)
            {
                txtNLogSeperator.Text = nLogParserSettings.Splitter;
                txtNLogLayout.Text = nLogParserSettings.Layout;
                textEditNLogExtension.Text = string.Join(";",nLogParserSettings.SupportedFilesExtensions);
                
                analogyColumnsMatcherUC1.LoadMapping(nLogParserSettings);
                CheckNLogLayout();
            }
        }


        private async void UserSettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
            if (_initialSelection >= 0)
                tabControlMain.SelectedTabPageIndex = _initialSelection;


        }


        private void btnNlogCheckLayout_Click(object sender, EventArgs e)
        {
            CheckNLogLayout();
        }

        private void CheckNLogLayout()
        {
            try
            {
                if (string.IsNullOrEmpty(txtNLogSeperator.Text)) return;
                var items = txtNLogLayout.Text
                    .Split(txtNLogSeperator.Text.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                analogyColumnsMatcherUC1.SetColumns(items);
             }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Error parsing input: " + exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    
        private void SBtnSaveNlogMapping_Click(object sender, EventArgs e)
        {

            SaveMapping();

        }

        private void SaveMapping()
        {
            Settings.LogParsersSettings.NLogParserSettings.Configure(txtNLogLayout.Text, txtNLogSeperator.Text,
                new List<string> { textEditNLogExtension.Text }, analogyColumnsMatcherUC1.Mapping);
        }
        private void SBtnLoadXMLFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Json File (*.json)|*.json";
                openFileDialog1.Title = @"Load File";
                openFileDialog1.Multiselect = false;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textEditJsonFile.Text = openFileDialog1.FileName;
                    ParseJsonFile(openFileDialog1.FileName);
                }
            }
        }

        private void ParseJsonFile(string fileName)
        {
            // string json = File.ReadAllText(fileName);
            // var items = JsonConvert.DeserializeObject(json);
        }

        private void btnImportNLogSettings_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Analogy NLog Settings (*.nlogsettings)|*.nlogsettings";
            openFileDialog1.Title = @"Import NLog settings";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var json = File.ReadAllText(openFileDialog1.FileName);
                    LogParserSettings nlog = LogParserSettings.FromJson(json);
                    LoadNLogSettings(nlog);
                    XtraMessageBox.Show("File Imported. Save settings if desired", @"Import settings", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Error Import: " + ex.Message, @"Error Import file", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportNLogSettings_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Analogy NLog Settings (*.nlogsettings)|*.nlogsettings";
            saveFileDialog.Title = @"Export NLog settings";

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                SaveMapping();
                try
                {
                    File.WriteAllText(Settings.LogParsersSettings.NLogParserSettings.AsJson(), saveFileDialog.FileName);
                    XtraMessageBox.Show("File Saved", @"Export settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Error Export: " + ex.Message, @"Error Saving file", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            }
        }
    }
}
