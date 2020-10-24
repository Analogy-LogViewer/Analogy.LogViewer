using Analogy.DataProviders;
using Analogy.Types;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Cache;
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


        public UpdateMode UpdateMode
        {
            get => Settings.UpdateMode;
            set => Settings.UpdateMode = value;
        }
        public GithubReleaseEntry LastVersionChecked
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

        private string UpdaterDownloadFile { get; set; }
        public string UpdaterExecutable
        {
            get
            {
                string targetFileName = Path.Combine(Utils.CurrentDirectory(), "Analogy.Updater", "Analogy.Updater.exe");
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

        private MyWebClient webClient;
        public UpdateManager()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            CurrentVersionNumber = fvi.FileVersion;
        }

        private Version? GetVersionFromTagName(string? tagName)
        {
            return tagName == null ? null : new Version(tagName.Replace("V", "").Replace("v", ""));
        }

        public async Task<(bool newData, GithubReleaseEntry release)> CheckVersion(bool forceUpdate)
        {
            if (!forceUpdate && NextUpdate > DateTime.Now && UserSettingsManager.UserSettings.LastVersionChecked != null)
                return (false, UserSettingsManager.UserSettings.LastVersionChecked);
            var (newData, entries) = await Utils.GetAsync<GithubReleaseEntry[]>(repository + "/releases", UserSettingsManager.UserSettings.GitHubToken, Instance.LastUpdate);
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

        public GithubAsset? GetDownloadAsset()
        {
            GithubAsset? asset = null;
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

            return asset;
        }
        public async Task<(string TagName, GithubAsset UpdaterAsset)?> GetLatestUpdater()
        {
            var (newData, entries) = await Utils.GetAsync<GithubReleaseEntry[]>(updaterRepository + "/releases", UserSettingsManager.UserSettings.GitHubToken, DateTime.MinValue);
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
                await DownloadUpdater(update.Value.UpdaterAsset);

            }
            else if (GetVersionFromTagName(update.Value.TagName) > UpdaterVersion())
            {
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

        private async Task<bool> DownloadUpdater(GithubAsset updaterAsset)
        {
            var tcs = new TaskCompletionSource<bool>();

            webClient = new MyWebClient
            {
                CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore)
            };

            //if (AutoUpdater.Proxy != null)
            //{
            //    _webClient.Proxy = AutoUpdater.Proxy;
            //}

            var uri = new Uri(updaterAsset.BrowserDownloadUrl);

            //if (AutoUpdater.BasicAuthDownload != null)
            //{
            //    _webClient.Headers[HttpRequestHeader.Authorization] = AutoUpdater.BasicAuthDownload.ToString();
            //}

            var tempPath = Path.Combine(Path.GetTempPath(), "Analogy.Updater.zip");
            string directory = Path.GetDirectoryName(tempPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            UpdaterDownloadFile = tempPath;
            webClient.DownloadFileCompleted += WebClientOnDownloadFileCompleted;
            webClient.DownloadFileAsync(uri, tempPath);

            void WebClientOnDownloadFileCompleted(object sender, AsyncCompletedEventArgs asyncCompletedEventArgs)
            {
                if (asyncCompletedEventArgs.Cancelled)
                {
                    tcs.SetResult(false);
                    return;
                }

                UnzipZipFileIntoTempFolder(tempPath, Path.GetDirectoryName(UpdaterExecutable));
                if (asyncCompletedEventArgs.Error != null)
                {
                    XtraMessageBox.Show(asyncCompletedEventArgs.Error.Message,
                        asyncCompletedEventArgs.Error.GetType().ToString(), MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
                webClient.Dispose();
                tcs.SetResult(true);
            }

            return await tcs.Task;

        }

        private void UnzipZipFileIntoTempFolder(string zipPath, string extractPath)
        {
            string version = "net472";
            if (CurrentFrameworkAttribute.FrameworkName.EndsWith("4.7.1") ||
                CurrentFrameworkAttribute.FrameworkName.EndsWith("4.7.2"))
                version = "net472";
            else if (CurrentFrameworkAttribute.FrameworkName.EndsWith("3.1"))
                version = "netcoreapp3.1";
            using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
                {
                    //build a list of files to be extracted
                    var entries = archive.Entries.Where(entry =>
                        !entry.FullName.EndsWith("/") && entry.FullName.Contains(version));
                    foreach (ZipArchiveEntry entry in entries)
                    {
                        string target = Path.Combine(extractPath, entry.Name);
                        string directory = Path.GetDirectoryName(target);
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        try
                        {
                            entry.ExtractToFile(target, true);
                        }
                        catch (Exception e)
                        {
                            AnalogyLogger.Instance.LogException($"Error unpacking Updater: {e.Message}", e);
                        }

                    }
                }
            }
        }
    }
}
