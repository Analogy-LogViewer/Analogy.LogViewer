using Analogy.ApplicationSettings;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Analogy.Forms
{
    public partial class ApplicationSettingsForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;
        private string SelectedSettingName { get; }
        public ApplicationSettingsForm()
        {
            InitializeComponent();
            EnableAcrylicAccent = false;
            SelectedSettingName = string.Empty;
        }

        public ApplicationSettingsForm(string selectedSettingName) : this()
        {
            SelectedSettingName = selectedSettingName;
        }

        private void ApplicationSettingsForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            ShowIcon = true;
            Icon = UserSettingsManager.UserSettings.GetIcon();
            if (string.IsNullOrEmpty(SelectedSettingName))
            {
                ApplicationGeneralSettingsUC uc = new ApplicationGeneralSettingsUC { Name = "Application Settings" };
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
                accordionControl1.SelectedElement = accordionControl1.Elements.First();
            }
            else
            {

                AddOrBringToFrontUserControl(SelectedSettingName);
            }
        }

        private UserControl GetUserControlByName(string name)
        {
            switch (name)
            {
                case "Application Settings":
                    return new ApplicationGeneralSettingsUC();
                case "Application UI Settings":
                    return new ApplicationUISettingsUC();
                case "Messages Filtering":
                    return new FilteringSettingsUC();
                case "Messages Layout":
                    return new MessagesLayoutSettingsUC();
                case "Color Settings":
                    return new ColorSettingsUC();
                case "Color Highlighting":
                    return new ColorHighlightSettingsUC();
                case "Predefined queries":
                    return new PredefinedFiltersUC();
                case "Shortcuts":
                    return new ShortcutSettingsUC();
                case "Extensions":
                    return new ExtensionSettingsUC();
                case "Updates":
                    return new UpdateSettingsUC();
                case "Debugging":
                    return new DebuggingSettingsUC();
                case "Data Provider Settings":
                    return new DataProvidersSettingsUC();
                case "Real Time Data Provider Settings":
                    return new DataProvidersRealTimeSettingsUC();
                case "Data Provider File Associations Settings":
                    return new DataProvidersFileAssociationUC();
                case "Data Provider external locations Settings":
                    return new DataProvidersExternalLocationsSettingsUC();
                case "Donations":
                    return new SupportSettingsUC();
                default:
                    {
                        AnalogyLogger.Instance.LogError($"User Setting with {name} was not found");
                        throw new Exception($"User Setting with {name} was not found");
                    }
            }
        }

        private void AddOrBringToFrontUserControl(string name)
        {

            if (!fluentDesignFormContainer1.Controls.ContainsKey(name))
            {
                var uc = GetUserControlByName(name);
                uc.Name = name;
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            foreach (UserControl others in fluentDesignFormContainer1.Controls)
            {
                if (others.Name == name)
                {
                    continue;
                }

                others.SendToBack();
            }

            fluentDesignFormContainer1.Controls[name].BringToFront();
        }

        private void applicationSettings_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Application Settings");
        }

        private void applicationUISettings_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Application UI Settings");
        }

        private void messagesFiltering_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Messages Filtering");
        }

        private void MessagesLayout_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Messages Layout");
        }

        private void colorSettings_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Color Settings");
        }

        private void MessagesColorHighlighting_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Color Highlighting");
        }

        private void predefinedQueries_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Predefined queries");
        }

        private void shortcuts_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Shortcuts");
        }

        private void Extensions_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Extensions");
        }

        private void updates_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Updates");
        }

        private void debugging_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Debugging");
        }

        private void DataProviderList_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Data Provider Settings");
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Real Time Data Provider Settings");
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Data Provider File Associations Settings");
        }

        private void DataProviderExternal_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Data Provider external locations Settings");
        }

        private void bbtnReset_ItemClick(object sender, ItemClickEventArgs e)
        {
            var result = XtraMessageBox.Show("Are you sure you want to reset all settings to their defaults", @"Reset settings", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                var owner = this.Owner;
                this.FormClosing -= ApplicationSettingsForm_FormClosing;
                Hide();
                Close();
                Settings.ResetSettings();
                ApplicationSettingsForm us = new ApplicationSettingsForm();
                us.ShowDialog(owner);
            }
        }

        private void ApplicationSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Save();
        }

        private void Donations_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Donations");

        }

      
    }
}
