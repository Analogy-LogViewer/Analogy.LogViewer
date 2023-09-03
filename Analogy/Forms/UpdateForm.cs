using Analogy.Managers;
using System.Windows.Forms;
using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy.Forms
{
    public partial class UpdateForm : DevExpress.XtraEditors.XtraForm
    {
        private UpdateManager Updater { get; }
        private IAnalogyUserSettings Settings { get; }
        public UpdateForm(IAnalogyUserSettings settings, UpdateManager updateManager)
        {
            Settings = settings;
            Updater = updateManager;
            InitializeComponent();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            Icon = Settings.GetIcon();
            lblCurrentVersion.Text =
                $"Your current version is: V{Updater.CurrentVersion}. (Target Framework:{Updater.CurrentFrameworkAttribute.FrameworkName})";
            lblLatestVersion.Text =
                $"Latest version is: {(Updater.LastVersionChecked?.TagName == null ? "not checked" : Updater.LastVersionChecked.TagName)}";

            if (AnalogyNonPersistSettings.Instance.UpdateAreDisabled)
            {
                AnalogyLogManager.Instance.LogWarning("Update is disabled", nameof(UpdateForm));
                sbtnUpdateNow.Visible = false;
                sbtnCheck.Visible = false;
                lblDisableUpdates.Visible = true;
                return;
            }

            if (Updater.LastVersionChecked?.TagName != null)
            {
                richTextBoxRelease.Text = Updater.LastVersionChecked.Body;
                hyperLinkEditLatest.Text = Updater.LastVersionChecked.HtmlUrl;
                cePreRelease.Checked = Updater.LastVersionChecked.Prerelease;
                if (Updater.NewVersionExist)
                {
                    sbtnUpdateNow.Visible = true;
                }
            }
        }

        private async void sbtnCheckUpdate_Click(object sender, EventArgs e)
        {
            var (_, release) = await Updater.CheckVersion(true);
            Settings.LastVersionChecked = release;
            string preRelease = release.Prerelease ? " (This is pre-release version)" : string.Empty;
            lblLatestVersion.Text = $"Latest version is: {release.TagName}{preRelease}.";
            richTextBoxRelease.Text = release.Body;
            hyperLinkEditLatest.Text = release.HtmlUrl;
            cePreRelease.Checked = release.Prerelease;
            if (Updater.NewVersionExist)
            {
                sbtnUpdateNow.Visible = true;
            }
        }

        private async void sbtnUpdateNow_Click(object sender, EventArgs e)
        {
            var downloadInfo = Updater.DownloadInformation;
            if (string.IsNullOrEmpty(downloadInfo.DownloadURL))
            {
                XtraMessageBox.Show("Error", "Missing download information.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            sbtnUpdateNow.Enabled = false;
            await Updater.InitiateUpdate(downloadInfo.title, downloadInfo.DownloadURL, true);
            sbtnUpdateNow.Enabled = true;
        }
    }
}
