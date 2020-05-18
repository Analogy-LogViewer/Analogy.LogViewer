using Analogy.DataProviders;
using Analogy.Managers;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Analogy.Forms
{
    public partial class UpdateForm : DevExpress.XtraEditors.XtraForm
    {
        private string repository = @"https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer";
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            Icon = UserSettingsManager.UserSettings.GetIcon();
            lblCurrentVersion.Text = $"Your current version is: V{UpdateManager.Instance.CurrentVersion}";
        }

        private async void sbtnCheck_Click(object sender, EventArgs e)
        {
            string releases = await Utils.GetAsync(repository + "/releases");
            var release = JsonConvert.DeserializeObject<GithubReleaseEntry[]>(releases).OrderByDescending(r => r.Published).First();
            lblLatestVersion.Text = "Latest version is: " + release.TagName;
            richTextBoxRelease.Text = release.ToString();
            hyperLinkEditLatest.Text = release.HtmlUrl;

        }
    }
}