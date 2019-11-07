using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using Analogy.Interfaces;
using DevExpress.Utils;

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
                txtSeperator.Text = Settings.NLogSettings.Splitter;
                txtLayout.Text = Settings.NLogSettings.Layout;
                lstBAnalogyColumns.Items.Clear();
                lstBAnalogyColumns.Items.AddRange(Settings.NLogSettings.Maps.Values.Select(i => i.ToString()).ToArray());
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
                if (string.IsNullOrEmpty(txtSeperator.Text)) return;
                var items = txtLayout.Text.Split(txtSeperator.Text.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                lstBoxItems.Items.Clear();
                lstBoxItems.Items.AddRange(items);
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("Error parsing input: " + exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void sBtnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstBAnalogyColumns.SelectedIndex <= 0) return;
            var selectedIndex = lstBAnalogyColumns.SelectedIndex;
            var currentValue = lstBAnalogyColumns.Items[selectedIndex];
            lstBAnalogyColumns.Items[selectedIndex] = lstBAnalogyColumns.Items[selectedIndex - 1];
            lstBAnalogyColumns.Items[selectedIndex - 1] = currentValue;
            lstBAnalogyColumns.SelectedIndex = lstBAnalogyColumns.SelectedIndex - 1;
        }

        private void sBtnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstBAnalogyColumns.SelectedIndex == lstBAnalogyColumns.ItemCount - 1) return;
            var selectedIndex = lstBAnalogyColumns.SelectedIndex;
            var currentValue = lstBAnalogyColumns.Items[selectedIndex + 1];
            lstBAnalogyColumns.Items[selectedIndex + 1] = lstBAnalogyColumns.Items[selectedIndex];
            lstBAnalogyColumns.Items[selectedIndex] = currentValue;
            lstBAnalogyColumns.SelectedIndex = lstBAnalogyColumns.SelectedIndex + 1;
        }

        private void sBtnSaveNlogMapping_Click(object sender, EventArgs e)
        {
            LogParserSettings parser = new LogParserSettings {Layout = txtLayout.Text, Splitter = txtSeperator.Text};
            for (int i = 0; i < lstBAnalogyColumns.ItemCount; i++)
            {
                parser.AddMap(i,
                    (AnalogyLogMessagePropertyName)Enum.Parse(typeof(AnalogyLogMessagePropertyName),
                        lstBAnalogyColumns.Items[i].ToString()));
            }

            parser.IsConfigured = true;
            Settings.NLogSettings = parser;
        }

        private void lstBAnalogyColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBAnalogyColumns.SelectedIndex > lstBoxItems.ItemCount) return;
            lstBoxItems.SelectedIndex = lstBAnalogyColumns.SelectedIndex;
        }
    }
}
