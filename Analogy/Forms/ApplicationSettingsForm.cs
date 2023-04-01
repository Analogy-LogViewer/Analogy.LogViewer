using Analogy.ApplicationSettings;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Analogy.Common.Interfaces;
using Analogy.DataTypes;

namespace Analogy.Forms
{
    public partial class ApplicationSettingsForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private IUserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;
        private ApplicationSettingsSelectionType SelectedSettingType { get; }
        public ApplicationSettingsForm()
        {
            InitializeComponent();
            EnableAcrylicAccent = false;
            SelectedSettingType = ApplicationSettingsSelectionType.ApplicationGeneralSettings;
        }

        public ApplicationSettingsForm(ApplicationSettingsSelectionType selectedSettingType) : this()
        {
            SelectedSettingType = selectedSettingType;
        }

        private void ApplicationSettingsForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            ShowIcon = true;
            Icon = UserSettingsManager.UserSettings.GetIcon();
            AddOrBringToFrontUserControl(SelectedSettingType);
        }

        private UserControl GetUserControlByType(ApplicationSettingsSelectionType settingType)
        {
            switch (settingType)
            {
                case ApplicationSettingsSelectionType.ApplicationGeneralSettings:
                    return new ApplicationGeneralSettingsUC();
                case ApplicationSettingsSelectionType.ApplicationUISettings:
                    return new ApplicationUISettingsUC();
                case ApplicationSettingsSelectionType.MessagesFilteringSettings:
                    return new FilteringSettingsUC();
                case ApplicationSettingsSelectionType.MessagesLayoutSettings:
                    return new MessagesLayoutSettingsUC();
                case ApplicationSettingsSelectionType.ColorSettings:
                    return new ColorSettingsUC();
                case ApplicationSettingsSelectionType.ColorHighlighting:
                    return new ColorHighlightSettingsUC();
                case ApplicationSettingsSelectionType.PredefinedQueriesSettings:
                    return new PredefinedFiltersUC();
                case ApplicationSettingsSelectionType.ShortcutsSettings:
                    return new ShortcutSettingsUC();
                case ApplicationSettingsSelectionType.ExtensionsSettings:
                    return new ExtensionSettingsUC();
                case ApplicationSettingsSelectionType.UpdatesSettings:
                    return new UpdateSettingsUC();
                case ApplicationSettingsSelectionType.DebuggingSettings:
                    return new DebuggingSettingsUC();
                case ApplicationSettingsSelectionType.DataProvidersSettings:
                    return new DataProvidersSettingsUC();
                case ApplicationSettingsSelectionType.RealTimeDataProvidersSettings:
                    return new DataProvidersRealTimeSettingsUC();
                case ApplicationSettingsSelectionType.FilesAssociationSettings:
                    return new DataProvidersFileAssociationUC();
                case ApplicationSettingsSelectionType.ExternalLocationsSettings:
                    return new DataProvidersExternalLocationsSettingsUC();
                case ApplicationSettingsSelectionType.DonationsSettings:
                    return new SupportSettingsUC();
                case ApplicationSettingsSelectionType.AdvancedModeSettings:
                    return new AdvancedSettingsUC();
                default:
                    {
                        AnalogyLogger.Instance.LogError($"User Setting with {settingType} was not found");
                        throw new Exception($"User Setting with {settingType} was not found");
                    }
            }
        }

        private void AddOrBringToFrontUserControl(ApplicationSettingsSelectionType type)
        {
            string name = type.ToString();
            if (!fluentDesignFormContainer1.Controls.ContainsKey(name))
            {
                var uc = GetUserControlByType(type);
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
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.ApplicationGeneralSettings);
        }

        private void applicationUISettings_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.ApplicationUISettings);
        }

        private void messagesFiltering_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.MessagesFilteringSettings);
        }

        private void MessagesLayout_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.MessagesLayoutSettings);
        }

        private void colorSettings_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.ColorSettings);
        }

        private void MessagesColorHighlighting_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.ColorHighlighting);
        }

        private void predefinedQueries_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.PredefinedQueriesSettings);
        }

        private void shortcuts_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.ShortcutsSettings);
        }

        private void Extensions_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.ExtensionsSettings);
        }

        private void updates_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.UpdatesSettings);
        }

        private void debugging_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.DebuggingSettings);
        }

        private void DataProviderList_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.DataProvidersSettings);
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.RealTimeDataProvidersSettings);
        }

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.FilesAssociationSettings);
        }

        private void DataProviderExternal_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.ExternalLocationsSettings);
        }

        private void bbtnReset_ItemClick(object sender, ItemClickEventArgs e)
        {
            var result = XtraMessageBox.Show("Are you sure you want to reset all settings to their defaults (also columns' layout)?", @"Reset settings", MessageBoxButtons.YesNo,
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
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.DonationsSettings);

        }

        private void aceAdvancedMode_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationSettingsSelectionType.AdvancedModeSettings);
        }
    }
}
