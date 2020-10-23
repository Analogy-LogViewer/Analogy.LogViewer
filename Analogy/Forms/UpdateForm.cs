using Analogy.Managers;
using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;

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
            lblCurrentVersion.Text = $"Your current version is: V{UpdateManager.Instance.CurrentVersion}. (Target Framework:{UpdateManager.Instance.CurrentFrameworkAttribute.FrameworkName})";
            lblLatestVersion.Text =
                $"Latest version is: {(UpdateManager.Instance.LastVersionChecked == null || UpdateManager.Instance.LastVersionChecked.TagName == null ? "not checked" : UpdateManager.Instance.LastVersionChecked.TagName)}";

            if (UpdateManager.Instance.LastVersionChecked != null && UpdateManager.Instance.LastVersionChecked.TagName != null)
            {
                richTextBoxRelease.Text = UpdateManager.Instance.LastVersionChecked.ToString();
                hyperLinkEditLatest.Text = UpdateManager.Instance.LastVersionChecked.HtmlUrl;
                if (UpdateManager.Instance.NewVersionExist)
                {
                    sbtnUpdateNow.Visible = true;
                }
            }
        }

        private async void sbtnCheck_Click(object sender, EventArgs e)
        {
            var (_, release) = await UpdateManager.Instance.CheckVersion(true);
            UserSettingsManager.UserSettings.LastVersionChecked = release;
            lblLatestVersion.Text = $"Latest version is: {release.TagName}.";
            richTextBoxRelease.Text = release.ToString();
            hyperLinkEditLatest.Text = release.HtmlUrl;
            if (UpdateManager.Instance.NewVersionExist)
            {
                sbtnUpdateNow.Visible = true;
            }
        }

        private void sbtnUpdateNow_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(
                    "Updating the application will close the current instance." + Environment.NewLine +
                    "Do you want to update right Now?", @"Update Confirmation", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                if (File.Exists(UpdateManager.Instance.UpdateExecutable))
                {

                }
                else
                {
                    XtraMessageBox.Show(
                        "Updater was not found. Please submit this issue with the following information" +
                        Environment.NewLine +
                        $"Current Directory: {Environment.CurrentDirectory}", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }
        }
    }
}
