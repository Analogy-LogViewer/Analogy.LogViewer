using DevExpress.LookAndFeel;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Analogy
{
    public class Program
    {
        public const int WM_COPYDATA = 0x004A;

        [DllImport("user32", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr Hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

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

                if (Environment.GetCommandLineArgs().Length == 2)
                {
                    var otherAnalogy = GetAlreadyRunningInstance();
                    if (otherAnalogy != null)
                    {
                        SendDataMessage(otherAnalogy, Environment.GetCommandLineArgs()[1]);
                    }
                }
                else
                    XtraMessageBox.Show("Single instance is on. Exiting this instance", "Analogy");
                return;
            }
            Application.Run(new MainForm());

        }
        public static void SendDataMessage(Process targetProcess, string msg)
        {
            //Copy the string message to a global memory area in unicode format
            IntPtr _stringMessageBuffer = Marshal.StringToHGlobalUni(msg);

            //Prepare copy data structure
            NativeMethods.COPYDATASTRUCT _copyData = new NativeMethods.COPYDATASTRUCT();
            _copyData.dwData = IntPtr.Zero;
            _copyData.lpData = _stringMessageBuffer;
            _copyData.cbData = msg.Length * 2;//Number of bytes required for marshalling this string as a series of unicode characters
            IntPtr _copyDataBuff = IntPtrAlloc(_copyData);

            //Send message to the other process
            SendMessage(targetProcess.MainWindowHandle, WM_COPYDATA, IntPtr.Zero, _copyDataBuff);

            Marshal.FreeHGlobal(_copyDataBuff);
            Marshal.FreeHGlobal(_stringMessageBuffer);
        }

        // Allocate a pointer to an arbitrary structure on the global heap.
        private static IntPtr IntPtrAlloc<T>(T param)
        {
            IntPtr retval = Marshal.AllocHGlobal(Marshal.SizeOf(param));
            Marshal.StructureToPtr(param, retval, false);
            return retval;
        }
        public static Process GetAlreadyRunningInstance()
        {
            var current = Process.GetCurrentProcess();
            return Process.GetProcessesByName(current.ProcessName).FirstOrDefault(p => p.Id != current.Id);
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
