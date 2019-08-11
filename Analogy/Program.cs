using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using Philips.Analogy.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Philips.Analogy
{
    public class Program
    {

        private const string EventlogSourceName = "Analogy Log Viewer";
        private static EmbeddedAssembly Loader;
        private static UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WindowsFormsSettings.LoadApplicationSettings();
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
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
            
            Loader = new EmbeddedAssembly();
            Loader.Load();
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

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var res = Loader.Get(args.Name);
            if (res != null)
                return res;

            string name = args.Name.Split(',')[0];
            //Use the AssemblyName class to get the name
            name = new AssemblyName(args.Name).Name + ".dll";
            string path = Path.Combine(@"c:\pms\system", name);
            if (File.Exists(path))
                return Assembly.LoadFrom(path);
            return null;
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
