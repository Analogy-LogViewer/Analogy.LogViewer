using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Analogy
{
    public class Program
    {
        private static UserSettingsManager Settings => UserSettingsManager.UserSettings;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WindowsFormsSettings.LoadApplicationSettings();
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.EnableVisualStyles();
            Settings.IncreaseNumberOfLaunches();
            if (!string.IsNullOrEmpty(Settings.ApplicationSkinName))
            {
                UserLookAndFeel.Default.SkinName = Settings.ApplicationSkinName;
            }
            UserLookAndFeel.Default.StyleChanged += (s, e) =>
            {
                Settings.ApplicationSkinName = ((UserLookAndFeel)s).ActiveSkinName;
            };

            Application.ApplicationExit += (s, e) =>
            {
                Settings.UpdateRunningTime();
                Settings.Save();
                BookmarkPersistManager.Instance.SaveFile();
            };
            LoadStartupExtensions();
            Application.Run(new MainForm());

        }

        private static void LoadStartupExtensions()
        {
            if (Settings.LoadExtensionsOnStartup && Settings.StartupExtensions.Any())
            {
                var manager = ExtensionsManager.Instance;
                var extensions = manager.GetExtensions().ToList();
                foreach (Guid guid in Settings.StartupExtensions)
                {
                    manager.RegisterExtension(extensions.SingleOrDefault(m => m.ExtensionID == guid));
                }

            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Error: " + e.ExceptionObject, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Error: " + e.Exception, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
