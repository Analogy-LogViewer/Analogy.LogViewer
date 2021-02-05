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
    public partial class ColorHighlightSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

        public ColorHighlightSettingsUC()
        {
            InitializeComponent();
        }

        private void ColorHighlightSettingsUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }

        private void SetupEventsHandlers()
        {
            sbtnAddHighlight.Click += (s, e) =>
            {

                if (ceHighlightContains.Checked)
                {
                    Settings.PreDefinedQueries.AddHighlight(teHighlightContains.Text, PreDefinedQueryType.Contains, cpeHighlightPreDefined.Color);
                    lboxHighlightItems.DataSource = Settings.PreDefinedQueries.Highlights;
                    lboxHighlightItems.Refresh();
                }

                if (ceHighlightEquals.Checked)
                {
                    Settings.PreDefinedQueries.AddHighlight(teHighlightEquals.Text, PreDefinedQueryType.Equals, cpeHighlightPreDefined.Color);
                    lboxHighlightItems.DataSource = Settings.PreDefinedQueries.Highlights;
                    lboxHighlightItems.Refresh();
                }

            };

            sbtnDeleteHighlight.Click += (s, e) =>
            {
                if (lboxHighlightItems.SelectedItem is PreDefineHighlight highlight)
                {
                    Settings.PreDefinedQueries.RemoveHighlight(highlight);
                    lboxHighlightItems.DataSource = Settings.PreDefinedQueries.Highlights;
                    lboxHighlightItems.Refresh();
                }
            };

            ceHighlightContains.CheckedChanged += (s, e) =>
            {
                teHighlightContains.Enabled = ceHighlightContains.Checked;
                teHighlightEquals.Enabled = ceHighlightEquals.Checked;
            };

            ceHighlightEquals.CheckedChanged += (s, e) =>
            {
                teHighlightContains.Enabled = ceHighlightContains.Checked;
                teHighlightEquals.Enabled = ceHighlightEquals.Checked;
            };
        }

        private void LoadSettings()
        {
            teHighlightContains.Enabled = ceHighlightContains.Checked;
            teHighlightEquals.Enabled = ceHighlightEquals.Checked;
            lboxHighlightItems.DataSource = Settings.PreDefinedQueries.Highlights;
        }
    }
}
