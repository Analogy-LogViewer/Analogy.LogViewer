using Analogy.DataProviders;
using Analogy.Types;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Analogy.Managers
{
    public class UpdateManager
    {
        private static readonly Lazy<UpdateManager>
            _instance = new Lazy<UpdateManager>(() => new UpdateManager());

        public static readonly UpdateManager Instance = _instance.Value;
        private string repository = @"https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer";
        public bool EnableUpdate => UpdateMode != UpdateMode.Never;

        public UpdateMode UpdateMode
        {
            get => UserSettingsManager.UserSettings.UpdateMode;
            set => UserSettingsManager.UserSettings.UpdateMode = value;
        }
        public GithubReleaseEntry LastVersionChecked
        {
            get => UserSettingsManager.UserSettings.LastVersionChecked;
            set => UserSettingsManager.UserSettings.LastVersionChecked = value;
        }
        public DateTime LastUpdate
        {
            get => UserSettingsManager.UserSettings.LastUpdate;
            set => UserSettingsManager.UserSettings.LastUpdate = value;
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

        public string CurrentVersion { get; }


        public UpdateManager()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            CurrentVersion = fvi.FileVersion;
        }

        public async Task<(bool newData, GithubReleaseEntry release)> CheckVersion(bool forceUpdate)
        {
            if (!forceUpdate && NextUpdate > DateTime.Now)
                return (false, UserSettingsManager.UserSettings.LastVersionChecked);
            var (newData, entries) = await Utils.GetAsync<GithubReleaseEntry[]>(repository + "/releases", UserSettingsManager.UserSettings.GitHubToken, UpdateManager.Instance.LastUpdate);
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
    }
}
