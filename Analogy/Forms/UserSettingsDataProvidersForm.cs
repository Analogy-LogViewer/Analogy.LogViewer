using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
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

        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;
        private int InitialSelection = -1;

        public UserSettingsDataProvidersForm()
        {
            InitializeComponent();

        }

        public UserSettingsDataProvidersForm(int tabIndex) : this()
        {
            InitialSelection = tabIndex;
        }
        public UserSettingsDataProvidersForm(string tabName) : this()
        {
            var tab = tabControlMain.TabPages.SingleOrDefault(t => t.Name == tabName);
            if (tab != null)
                InitialSelection = tab.TabIndex;
        }
        private void LoadSettings()
        {
            
            if (Settings.NLogSettings.IsConfigured)
            {
                txtNLogSeperator.Text = Settings.NLogSettings.Splitter;
                txtNLogLayout.Text = Settings.NLogSettings.Layout;
                textEditNLogExtension.Text = string.Join(";", Settings.NLogSettings.SupportedFilesExtensions);
                lstBAnalogyColumnsNlog.Items.Clear();
                lstBAnalogyColumnsNlog.Items.AddRange(Settings.NLogSettings.Maps.Values.Select(i => i.ToString()).ToArray());
            }
        }

        
        private async void UserSettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
            if (InitialSelection >= 0)
                tabControlMain.SelectedTabPageIndex = InitialSelection;
     
            
        }

       
        private void sbtnCheckLayout_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNLogSeperator.Text)) return;
                var items = txtNLogLayout.Text.Split(txtNLogSeperator.Text.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
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

        private void sBtnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstBAnalogyColumnsNlog.SelectedIndex <= 0) return;
            var selectedIndex = lstBAnalogyColumnsNlog.SelectedIndex;
            var currentValue = lstBAnalogyColumnsNlog.Items[selectedIndex];
            lstBAnalogyColumnsNlog.Items[selectedIndex] = lstBAnalogyColumnsNlog.Items[selectedIndex - 1];
            lstBAnalogyColumnsNlog.Items[selectedIndex - 1] = currentValue;
            lstBAnalogyColumnsNlog.SelectedIndex = lstBAnalogyColumnsNlog.SelectedIndex - 1;
        }

        private void sBtnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstBAnalogyColumnsNlog.SelectedIndex == lstBAnalogyColumnsNlog.ItemCount - 1) return;
            var selectedIndex = lstBAnalogyColumnsNlog.SelectedIndex;
            var currentValue = lstBAnalogyColumnsNlog.Items[selectedIndex + 1];
            lstBAnalogyColumnsNlog.Items[selectedIndex + 1] = lstBAnalogyColumnsNlog.Items[selectedIndex];
            lstBAnalogyColumnsNlog.Items[selectedIndex] = currentValue;
            lstBAnalogyColumnsNlog.SelectedIndex = lstBAnalogyColumnsNlog.SelectedIndex + 1;
        }

        private void sBtnSaveNlogMapping_Click(object sender, EventArgs e)
        {
            Dictionary<int, AnalogyLogMessagePropertyName> maps=new Dictionary<int, AnalogyLogMessagePropertyName>(lstBAnalogyColumnsNlog.ItemCount);
            for (int i = 0; i < lstBAnalogyColumnsNlog.ItemCount; i++)
            {
                maps.Add(i,
                    (AnalogyLogMessagePropertyName)Enum.Parse(typeof(AnalogyLogMessagePropertyName),
                        lstBAnalogyColumnsNlog.Items[i].ToString()));
            }

            Settings.NLogSettings.IsConfigured = true;
            Settings.NLogSettings.Maps = maps;
            Settings.NLogSettings.Layout = txtNLogLayout.Text;
            Settings.NLogSettings.Splitter = txtNLogSeperator.Text;
            Settings.NLogSettings.SupportedFilesExtensions = new List<string> {textEditNLogExtension.Text};
        }

        private void lstBAnalogyColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBAnalogyColumnsNlog.SelectedIndex > lstBoxItemsNlog.ItemCount) return;
            lstBoxItemsNlog.SelectedIndex = lstBAnalogyColumnsNlog.SelectedIndex;
        }

        private void sBtnLoadXMLFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Json File (*.json)|*.json";
            openFileDialog1.Title = @"Load File";
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textEditJsonFile.Text = openFileDialog1.FileName;
                ParseJsonFile(openFileDialog1.FileName);
            }
        }

        private void ParseJsonFile(string fileName)
        {
            string json = File.ReadAllText(fileName);
            var items = JsonConvert.DeserializeObject(json);
        }
    }
}
