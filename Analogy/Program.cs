using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.IO;
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
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            WindowsFormsSettings.LoadApplicationSettings();
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
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
            if (UserSettingsManager.UserSettings.SingleInstance && Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                XtraMessageBox.Show("Single instance is on. Exiting this instance", "Analogy");
                return;
            }
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
                    manager.RegisterExtension(extensions.SingleOrDefault(m => m.ID == guid));
                }

            }
        }
        private static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            AnalogyLogger.Instance.LogWarning(nameof(CurrentDomain_FirstChanceException), e.Exception.ToString());
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            AnalogyLogger.Instance.LogException(e.ExceptionObject as Exception, nameof(CurrentDomain_UnhandledException), "Error: " + e.ExceptionObject);
            MessageBox.Show("Error: " + e.ExceptionObject, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            AnalogyLogger.Instance.LogException(e.Exception, nameof(Application_ThreadException), "Error: " + e.Exception);
            MessageBox.Show("Error: " + e.Exception, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
