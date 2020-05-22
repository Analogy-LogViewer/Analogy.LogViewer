using Analogy.Managers;
using System;

namespace Analogy.Forms
{
    public partial class UpdateForm : DevExpress.XtraEditors.XtraForm
    {

        public UpdateForm()
        {
            InitializeComponent();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            Icon = UserSettingsManager.UserSettings.GetIcon();
            lblCurrentVersion.Text = $"Your current version is: V{UpdateManager.Instance.CurrentVersion}";
            lblLatestVersion.Text =
                $"Latest version is: {(UpdateManager.Instance.LastVersionChecked == null || UpdateManager.Instance.LastVersionChecked.TagName == null ? "not checked" : UpdateManager.Instance.LastVersionChecked.TagName)}";

            if (UpdateManager.Instance.LastVersionChecked != null && UpdateManager.Instance.LastVersionChecked.TagName != null)
            {
                richTextBoxRelease.Text = UpdateManager.Instance.LastVersionChecked.ToString();
                hyperLinkEditLatest.Text = UpdateManager.Instance.LastVersionChecked.HtmlUrl;
            }
        }

        private async void sbtnCheck_Click(object sender, EventArgs e)
        {
            var (_, release) = await UpdateManager.Instance.CheckVersion(true);
            UserSettingsManager.UserSettings.LastVersionChecked = release;
            lblLatestVersion.Text = "Latest version is: " + release.TagName;
            richTextBoxRelease.Text = release.ToString();
            hyperLinkEditLatest.Text = release.HtmlUrl;

        }
    }
}