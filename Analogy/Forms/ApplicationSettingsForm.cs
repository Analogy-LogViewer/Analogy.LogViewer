using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Analogy.ApplicationSettings;

namespace Analogy.Forms
{
    public partial class ApplicationSettingsForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public ApplicationSettingsForm()
        {
            InitializeComponent();
        }

        private void ApplicationSettingsForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            ShowIcon = true;
            Icon = UserSettingsManager.UserSettings.GetIcon();


            Icon = UserSettingsManager.UserSettings.GetIcon();
            ApplicationGeneralSettingsUC uc = new ApplicationGeneralSettingsUC { Name = "Application Settings" };
            fluentDesignFormContainer1.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            accordionControl1.SelectedElement = accordionControl1.Elements.First();
        }
        private void AddOrBringToFrontUserControl(string name, UserControl uc)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey(name))
            {

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
            AddOrBringToFrontUserControl("Application Settings", new ApplicationGeneralSettingsUC());
        }
        
        private void applicationUISettings_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Application UI Settings", new ApplicationUISettingsUC());
        }

        private void messagesFiltering_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Messages Filtering", new FilteringSettingsUC());
        }

        private void MessagesLayout_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Messages Layout", new MessagesLayoutSettingsUC());

        }

        private void colorSettings_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Color Settings", new ColorSettingsUC());
        }

        private void MessagesColorHighlighting_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Color Highlighting", new ColorHighlightSettingsUC());
        }

        private void predefinedQueries_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Predefined queries", new PredefinedFiltersUC());
        }

        private void shortcuts_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Shortcuts", new ShortcutSettingsUC());
        }

        private void Extensions_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Extensions", new ExtensionSettingsUC());
        }

        private void updates_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Updates", new UpdateSettingsUC());
        }

        private void debugging_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl("Debugging", new DebuggingSettingsUC());
        }
    }
}
