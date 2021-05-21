using Analogy.CommonUtilities.Web;
using Analogy.DataTypes;
using Analogy.Properties;
using Analogy.Updater;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.Managers
{
    public class UpdateManager
    {
        private static readonly Lazy<UpdateManager>
            _instance = new Lazy<UpdateManager>(() => new UpdateManager());

        private UserSettingsManager Settings => UserSettingsManager.UserSettings;
        public static readonly UpdateManager Instance = _instance.Value;
        private string repository = @"https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer";
        public bool EnableUpdate => UpdateMode != UpdateMode.Never;
        private string updaterRepository = @"https://api.github.com/repos/Analogy-LogViewer/Analogy.Updater";

        public List<DataProviderInformation> SupportedDataProviders { get; set; }
        public UpdateMode UpdateMode
        {
            get => Settings.UpdateMode;
            set => Settings.UpdateMode = value;
        }
        public GithubObjects.GithubReleaseEntry LastVersionChecked
        {
            get => Settings.LastVersionChecked;
            set => Settings.LastVersionChecked = value;
        }
        public DateTime LastUpdate
        {
            get => Settings.LastUpdate;
            set => Settings.LastUpdate = value;
        }
        public bool CheckedThisTun { get; set; }

        public DateTime NextUpdate
        {
            get
            {
                switch (UpdateMode)
                {
                    case UpdateMode.Never:
                        return DateTime.MaxValue;
                    case UpdateMode.EachStartup:
                        return CheckedThisTun ? DateTime.MaxValue : DateTime.Now;
                    case UpdateMode.OnceAWeek:
                        return LastUpdate.AddDays(7);
                    case UpdateMode.OnceAMonth:
                        return LastUpdate.AddMonths(1);
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }
        }

        public string CurrentVersionNumber { get; set; }
        public Version CurrentVersion => new Version(CurrentVersionNumber);
        public Version? NewestVersion => GetVersionFromTagName(Settings.LastVersionChecked?.TagName);
        public TargetFrameworkAttribute CurrentFrameworkAttribute => (TargetFrameworkAttribute)Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(TargetFrameworkAttribute));
        public string UpdaterExecutable
        {
            get
            {
                string targetFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Analogy.Updater", "Analogy.Updater.exe"); //Path.Combine(Utils.CurrentDirectory(), "Analogy.Updater", "Analogy.Updater.exe");
                return targetFileName;
            }
        }


        public bool NewVersionExist
        {
            get
            {
                if (Settings.LastVersionChecked != null && NewestVersion != null)
                {
                    return NewestVersion > CurrentVersion;
                }

                return false;
            }
        }

        public (string title, string DownloadURL) DownloadInformation
        {
            get
            {
                string downloadTag = "";
                if (!string.IsNullOrEmpty(Settings.LastVersionChecked?.TagName))
                {
                    downloadTag = $"https://github.com/Analogy-LogViewer/Analogy.LogViewer/releases/download/{Settings.LastVersionChecked?.TagName}";
                    var downloadAsset = GetDownloadAsset();
                    if (downloadAsset != null)
                    {
                        downloadTag = downloadAsset.BrowserDownloadUrl;
                    }

                }
                return ("Analogy Log viewer", downloadTag);
            }
        }

        public UpdateManager()
        {
            SupportedDataProviders = new List<DataProviderInformation>();
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.Serilog", "Analogy.LogViewer.Serilog.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.Serilog", Resources.serilog32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.RabbitMq", "Analogy.LogViewer.RabbitMq.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.RabbitMq", Resources.rabbitmq32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.RSSReader", "Analogy.LogViewer.RSSReader.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.RSSReader", Resources.rss));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.VisualStudioLogParser", "Analogy.LogViewer.VisualStudioLogParser.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.VisualStudioLogParser", Resources.VS32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.WhatsApp", "Analogy.LogViewer.WhatsApp.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.WhatsApp", Resources.whatsappicon32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.XMLParser", "Analogy.LogViewer.XMLParser.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.XMLParser", Resources.xml32x32));
            //SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.WCF", "Analogy.LogViewer.WCF.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.WCF", Resources.wcf32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.Philips.ICAP", "Analogy.LogViewer.Philips.ICAP.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.Philips.ICAP", Resources.philips_image_32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.Philips.CT", "Analogy.LogViewer.Philips.CT.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.Philips.CT", Resources.philips_image_32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.JsonParser", "Analogy.LogViewer.JsonParser.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.JsonParser", Resources.jsonfile32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.Log4jXml", "Analogy.LogViewer.Log4jXml.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.Log4jXml", Resources.Log4jXml32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.KafkaProvider ", "Analogy.LogViewer.KafkaProvider .dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.KafkaProvider", Resources.Single32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.IISLogsProvider", "Analogy.LogViewer.IISLogsProvider.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.IISLogsProvider", Resources.iis));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.Github", "Analogy.LogViewer.Github.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.Github", Resources.Git_icon_32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.GitHistory", "Analogy.LogViewer.GitHistory.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.GitHistory", Resources.Git_icon_32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.Affirmations", "Analogy.LogViewer.Affirmations.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.Affirmations", Resources.Affirmations32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.Log4Net", "Analogy.LogViewer.Log4Net.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.Log4Net", Resources.log4net32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.Nlog", "Analogy.LogViewer.NLogProvider.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.Nlog", Resources.nlog));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.PlainTextParser", "Analogy.LogViewer.PlainTextParser.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.PlainTextParser", Resources.Single32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.PowerToys", "Analogy.LogViewer.PowerToys.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.PowerToys", Resources.powertoys32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.RegexParser", "Analogy.LogViewer.RegexParser.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.RegexParser", Resources.Single32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.gRPC", "Analogy.LogViewer.gRPC.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.gRPC", Resources.gRPC32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.WindowsEventLogs", "Analogy.LogViewer.WindowsEventLogs.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.WindowsEventLogs", Resources.OperatingSystem_32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.Example", "Analogy.LogViewer.Example.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.Example", Resources.Analogy_image_32x32));
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.GitHubActionLogs", "Analogy.LogViewer.GitHubActionLogs.dll", "https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer.GitHubActionLogs", Resources.actions32x32));
#if !NETCOREAPP3_1 && !NET
            SupportedDataProviders.Add(new DataProviderInformation("Analogy.LogViewer.SerialPort", "Analogy.LogViewer.SerialPort.dll", "https://api.github.com/repos/oto313/Analogy.LogViewer.SerialPort", Resources.Analogy_image_32x32));
#endif
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            CurrentVersionNumber = fvi.FileVersion;
        }

        private Version? GetVersionFromTagName(string? tagName)
        {
            return tagName == null ? null : new Version(tagName.Replace("V", "").Replace("v", ""));
        }

        public async Task<(bool newData, GithubObjects.GithubReleaseEntry release)> CheckVersion(bool forceUpdate)
        {
            if (!forceUpdate && NextUpdate > DateTime.Now && UserSettingsManager.UserSettings.LastVersionChecked != null)
            {
                return (false, UserSettingsManager.UserSettings.LastVersionChecked);
            }

            var (newData, entries) = await Analogy.CommonUtilities.Web.Utils.GetAsync<GithubObjects.GithubReleaseEntry[]>(repository + "/releases", "Analogy Log Viewer", UserSettingsManager.UserSettings.GitHubToken, Instance.LastUpdate);
            LastUpdate = DateTime.Now;
            CheckedThisTun = true;
            if (!newData)
            {
                return (false, UserSettingsManager.UserSettings.LastVersionChecked);

            }
            var release = entries.OrderByDescending(r => r.Published).First();
            UserSettingsManager.UserSettings.LastVersionChecked = release;
            return (true, release);
        }

        public GithubObjects.GithubAsset? GetDownloadAsset()
        {
            GithubObjects.GithubAsset? asset = null;
            if (CurrentFrameworkAttribute.FrameworkName.EndsWith("4.7.1"))
            {
                asset = LastVersionChecked.Assets
                    .FirstOrDefault(a => a.Name.Contains("471") || a.Name.Contains("471"));
            }
            else if (CurrentFrameworkAttribute.FrameworkName.EndsWith("4.7.2"))
            {
                asset = LastVersionChecked.Assets
                    .FirstOrDefault(a => a.Name.Contains("472") || a.Name.Contains("472"));
            }
            else if (CurrentFrameworkAttribute.FrameworkName.EndsWith("4.8"))
            {
                asset = LastVersionChecked.Assets
                    .FirstOrDefault(a => a.Name.Contains("48") || a.Name.Contains("48"));
            }
            else if (CurrentFrameworkAttribute.FrameworkName.EndsWith("3.1"))
            {
                asset = LastVersionChecked.Assets
                    .FirstOrDefault(a => a.Name.Contains("3.1") || a.Name.Contains("netcoreapp3.1"));
            }
            else if (CurrentFrameworkAttribute.FrameworkName.EndsWith("5.0"))
            {
                asset = LastVersionChecked.Assets
                    .FirstOrDefault(a => a.Name.Contains("net5.0") || a.Name.Contains("net5.0-windows"));
            }
            return asset;
        }
        public async Task<(string TagName, GithubObjects.GithubAsset UpdaterAsset)?> GetLatestUpdater()
        {
            var (newData, entries) = await Analogy.CommonUtilities.Web.Utils.GetAsync<GithubObjects.GithubReleaseEntry[]>(updaterRepository + "/releases", "Analogy Log Viewer", UserSettingsManager.UserSettings.GitHubToken, DateTime.MinValue);
            if (entries == null)
            {
                return null;
            }
            var release = entries.OrderByDescending(r => r.Published)
                .FirstOrDefault(r => r.Assets.Any(a => a.Name.Contains("Analogy.Updater")));
            if (release != null)
            {
                return (release.TagName, release.Assets.First(a => a.Name.Contains("Analogy.Updater")));
            }
            return null;
        }
        public async Task DownloadUpdaterIfNeeded()
        {
            var update = await GetLatestUpdater();
            if (!update.HasValue)
            {
                AnalogyLogger.Instance.LogError("Updater was not found");
                return;
            }
            if (!File.Exists(UpdaterExecutable))
            {
                XtraMessageBox.Show("Updater Manager was not found." + Environment.NewLine + "It will be downloaded right now", @"Update Confirmation", MessageBoxButtons.OK);
                await DownloadUpdater(update.Value.UpdaterAsset);

            }
            else if (GetVersionFromTagName(update.Value.TagName) > UpdaterVersion())
            {
                XtraMessageBox.Show("Updater Manager is out of date." + Environment.NewLine + "Latest version will be downloaded right now", @"Update Confirmation", MessageBoxButtons.OK);
                await DownloadUpdater(update.Value.UpdaterAsset);
            }
            else
            {
                AnalogyLogger.Instance.LogInformation("No need to download Updater");
            }
        }

        private Version UpdaterVersion()
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(UpdaterExecutable);
            return new Version(fvi.FileVersion);


        }

        private async Task<bool> DownloadUpdater(GithubObjects.GithubAsset updaterAsset)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            var downloadDialog = new DownloadUpdateDialog(updaterAsset.BrowserDownloadUrl, Path.GetDirectoryName(UpdaterExecutable), CurrentFrameworkAttribute, tcs);
            downloadDialog.ShowDialog();
            return await tcs.Task;

        }

        public async Task InitiateUpdate(string title, string downloadURL, bool forceOverride)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(downloadURL))
            {
                return;
            }

            if (XtraMessageBox.Show(
                    "Updating the application will close the current instance." + Environment.NewLine +
                    "Do you want to update right Now?", @"Update Confirmation", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                await DownloadUpdaterIfNeeded();
                if (File.Exists(UpdaterExecutable))
                {
                    var processStartInfo = new ProcessStartInfo();
                    //string data = $"\"Title={title}\" DownloadURL:{downloadURL} \"TargetFolder:{Utils.CurrentDirectory()}\" OverrideFiles={forceOverride}";
                    string data = $"\"{title}\" {downloadURL} \"{Utils.CurrentDirectory()}\" {forceOverride}";
                    processStartInfo.Arguments = data;
                    processStartInfo.Verb = "runas";
                    processStartInfo.FileName = UpdaterExecutable;
                    try
                    {
                        Process.Start(processStartInfo);
                        Application.Exit();
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
