using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.CommonControls.DataTypes;
using Analogy.CommonUtilities.Github;
using Analogy.CommonUtilities.Web;
using Analogy.Interfaces;
using Analogy.Managers;
using Analogy.UserControls;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraCharts;

namespace Analogy.Forms
{
    public partial class GitHubHistoryForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private IAnalogyUserSettings Settings => UserSettingsManager.UserSettings;
        public GitHubHistoryForm()
        {
            InitializeComponent(); 
            EnableAcrylicAccent = false;
            Icon = Settings.GetIcon();
        }

        private async void GitHubHistoryForm_Load(object sender, EventArgs e)
        {
            await Fetch();
        }

        private async Task Fetch()
        {
            try
            {
                var (_, releases) = await Utils.GetAsync<GithubReleaseEntry[]>(AnalogyNonPersistSettings.Instance.AnalogyReleasesUrl, UserSettingsManager.UserSettings.GitHubToken, DateTime.MinValue).ConfigureAwait(true);
                if (releases == null)
                {
                    return;
                }

                CreatePieChart(releases);
                foreach (GithubReleaseEntry entry in releases)
                {
                    CreateReleaseEntry(entry);
                }
                int total = releases.SelectMany(e => e.Assets).Sum(a => a.Downloads);

            }
            catch (Exception e)
            {
                AnalogyLogger.Instance.LogException($"Error fetaching history from github: {e.Message}",e);
            }

        }

        private void CreateReleaseEntry(GithubReleaseEntry entry)
        {

            var downloads = new AccordionControlElement(ElementStyle.Item);
            downloads.Text = $"{entry.TagName} ({entry.Created.ToShortDateString()})";
            accordionControl1.Elements.Add(downloads);
            downloads.Click += (s, e) =>
            {

                if (!fluentDesignFormContainer1.Controls.ContainsKey(entry.TagName))
                {
                    ReleaseEntryUC uc = new ReleaseEntryUC(entry);
                    uc.Name = entry.TagName;
                    fluentDesignFormContainer1.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                    uc.BringToFront();
                }

                SetActive(entry.TagName);
            };
        }

        private void CreatePieChart(GithubReleaseEntry[] releases)
        {

            DownloadStatisticsUC uc = new DownloadStatisticsUC(releases);
            uc.Name = "Download Statistics";

            fluentDesignFormContainer1.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            var downloads = new AccordionControlElement(ElementStyle.Item);
            downloads.Text = "Download Statistics";

            accordionControl1.Elements.Add(downloads);
            downloads.Click += (s, e) =>
            {
                SetActive(uc.Name);
            };
            accordionControl1.SelectedElement = accordionControl1.Elements.First();
        }

        private void SetActive(string control)
        {
            foreach (UserControl others in fluentDesignFormContainer1.Controls)
            {
                if (others.Name == control)
                {
                    continue;
                }

                others.SendToBack();
            }

            fluentDesignFormContainer1.Controls[control].BringToFront();

        }
    }
}
