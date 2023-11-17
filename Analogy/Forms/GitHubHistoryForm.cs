using Analogy.CommonUtilities.Github;
using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Managers;
using Analogy.UserControls;
using DevExpress.XtraBars.Navigation;
using Markdig;
using Microsoft.Extensions.Logging;
using Octokit;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.Forms
{
    public partial class GitHubHistoryForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private IAnalogyUserSettings Settings => ServicesProvider.Instance.GetService<IAnalogyUserSettings>();
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
                IReadOnlyList<Release>? releases = await Utils.GetReleases();
                if (releases == null)
                {
                    return;
                }
                
                CreatePieChart(releases);
                foreach (Release entry in releases)
                {
                    CreateReleaseEntry(entry);
                }
               
            }
            catch (Exception e)
            {
                ServicesProvider.Instance.GetService<ILogger>().LogError($"Error fetching history from github: {e.Message}", e);
            }

        }

        private void CreateReleaseEntry(Release entry)
        {

            var downloads = new AccordionControlElement(ElementStyle.Item);
            downloads.Text = $"{entry.TagName} ({entry.CreatedAt.DateTime})";
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

        private void CreatePieChart(IReadOnlyList<Release> releases)
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