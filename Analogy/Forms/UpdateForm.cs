using Analogy.Managers;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Newtonsoft.Json;

namespace Analogy.Forms
{
    public partial class UpdateForm : DevExpress.XtraEditors.XtraForm
    {
        private UpdateManager Updater => UpdateManager.Instance;
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            Icon = UserSettingsManager.UserSettings.GetIcon();
            lblCurrentVersion.Text = $"Your current version is: V{Updater.CurrentVersion}. (Target Framework:{Updater.CurrentFrameworkAttribute.FrameworkName})";
            lblLatestVersion.Text =
                $"Latest version is: {(Updater.LastVersionChecked?.TagName == null ? "not checked" : Updater.LastVersionChecked.TagName)}";

            if (Updater.LastVersionChecked != null && Updater.LastVersionChecked.TagName != null)
            {
                richTextBoxRelease.Text = Updater.LastVersionChecked.ToString();
                hyperLinkEditLatest.Text = Updater.LastVersionChecked.HtmlUrl;
                if (Updater.NewVersionExist)
                {
                    sbtnUpdateNow.Visible = true;
                }
            }
        }

        private async void sbtnCheck_Click(object sender, EventArgs e)
        {
            var (_, release) = await Updater.CheckVersion(true);
            UserSettingsManager.UserSettings.LastVersionChecked = release;
            lblLatestVersion.Text = $"Latest version is: {release.TagName}.";
            richTextBoxRelease.Text = release.ToString();
            hyperLinkEditLatest.Text = release.HtmlUrl;
            if (Updater.NewVersionExist)
            {
                sbtnUpdateNow.Visible = true;
            }
        }

        private async  void sbtnUpdateNow_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(
                    "Updating the application will close the current instance." + Environment.NewLine +
                    "Do you want to update right Now?", @"Update Confirmation", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                await Updater.DownloadUpdaterIfNeeded();
                if (File.Exists(Updater.UpdaterExecutable))
                {
                    var processStartInfo = new ProcessStartInfo();
                    var info = Updater.UpdateInformation;
                    string data = $"\"{info.Title}\" {info.DownloadURL}";
                    processStartInfo.Arguments = data;
                    processStartInfo.Verb = "runas";
                    processStartInfo.FileName = Updater.UpdaterExecutable;
                    try
                    {
                        Process.Start(processStartInfo);
                        //Application.Exit();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Error during Updater: {ex.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
