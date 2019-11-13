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
                lstBAnalogyColumnsNlog.Items.Clear();
                for (int i = 0; i < 21; i++)
                {
                    if (nLogParserSettings.Maps.ContainsKey(i))
                        lstBAnalogyColumnsNlog.Items.Add(nLogParserSettings.Maps[i]);
                    else
                        lstBAnalogyColumnsNlog.Items.Add("__ignore__");
                }

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
                lstBoxItemsNlog.Items.Clear();
                lstBoxItemsNlog.Items.AddRange(items);
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Error parsing input: " + exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SBtnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstBAnalogyColumnsNlog.SelectedIndex <= 0) return;
            var selectedIndex = lstBAnalogyColumnsNlog.SelectedIndex;
            var currentValue = lstBAnalogyColumnsNlog.Items[selectedIndex];
            lstBAnalogyColumnsNlog.Items[selectedIndex] = lstBAnalogyColumnsNlog.Items[selectedIndex - 1];
            lstBAnalogyColumnsNlog.Items[selectedIndex - 1] = currentValue;
            lstBAnalogyColumnsNlog.SelectedIndex = lstBAnalogyColumnsNlog.SelectedIndex - 1;
        }

        private void SBtnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstBAnalogyColumnsNlog.SelectedIndex == lstBAnalogyColumnsNlog.ItemCount - 1) return;
            var selectedIndex = lstBAnalogyColumnsNlog.SelectedIndex;
            var currentValue = lstBAnalogyColumnsNlog.Items[selectedIndex + 1];
            lstBAnalogyColumnsNlog.Items[selectedIndex + 1] = lstBAnalogyColumnsNlog.Items[selectedIndex];
            lstBAnalogyColumnsNlog.Items[selectedIndex] = currentValue;
            lstBAnalogyColumnsNlog.SelectedIndex = lstBAnalogyColumnsNlog.SelectedIndex + 1;
        }

        private void SBtnSaveNlogMapping_Click(object sender, EventArgs e)
        {
            Dictionary<int, AnalogyLogMessagePropertyName> maps =
                new Dictionary<int, AnalogyLogMessagePropertyName>(lstBAnalogyColumnsNlog.ItemCount);
            for (int i = 0; i < lstBAnalogyColumnsNlog.ItemCount; i++)
            {
                if (lstBAnalogyColumnsNlog.Items[i].ToString()
                    .Contains("ignore", StringComparison.InvariantCultureIgnoreCase)) continue;
                maps.Add(i, (AnalogyLogMessagePropertyName)Enum.Parse(typeof(AnalogyLogMessagePropertyName),
                    lstBAnalogyColumnsNlog.Items[i].ToString()));
            }

            Settings.LogParsersSettings.NLogParserSettings.Configure(txtNLogLayout.Text, txtNLogSeperator.Text,
                new List<string> { textEditNLogExtension.Text }, maps);

        }

        private void LstBAnalogyColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBAnalogyColumnsNlog.SelectedIndex > lstBoxItemsNlog.ItemCount - 1) return;
            lstBoxItemsNlog.SelectedIndex = lstBAnalogyColumnsNlog.SelectedIndex;
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
