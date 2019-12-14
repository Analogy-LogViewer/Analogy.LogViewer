using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Interfaces;

namespace Analogy.Managers
{
    public class AnalogyLogManager
    {
        private static Lazy<AnalogyLogManager> _instance = new Lazy<AnalogyLogManager>();
        public static AnalogyLogManager Instance => _instance.Value;
        public bool HasErrorMessages => messages.Any(m=>m.Level==AnalogyLogLevel.Critical || m.Level == AnalogyLogLevel.Error);
        public bool HasWarningMessages => messages.Any(m => m.Level == AnalogyLogLevel.Warning);
        private List<AnalogyLogMessage> messages;
        public event EventHandler OnNewError;

        public AnalogyLogManager()
        {
            messages = new List<AnalogyLogMessage>();
        }

        public void LogError(string error)
        {
            messages.Add(new AnalogyLogMessage(error, AnalogyLogLevel.Error, AnalogyLogClass.General, "Analogy"));
            OnNewError?.Invoke(this, new EventArgs());
        }
        public void LogEvent(string data,string source)
        {
            messages.Add(new AnalogyLogMessage(data, AnalogyLogLevel.Event, AnalogyLogClass.General, source));
        }
        public void LogWarning(string data, string source)
        {
            messages.Add(new AnalogyLogMessage(data, AnalogyLogLevel.Warning, AnalogyLogClass.General, source));
        }
        public void LogDebug(string data, string source)
        {
            messages.Add(new AnalogyLogMessage(data, AnalogyLogLevel.Debug, AnalogyLogClass.General, source));
        }
        public void LogCritical(string data, string source)
        {
            messages.Add(new AnalogyLogMessage(data, AnalogyLogLevel.Critical, AnalogyLogClass.General, source));
        }
        public void Show(MainForm mainForm)
        {
            XtraFormLogGrid msg = new XtraFormLogGrid(messages, "Analogy", "Analogy");
            msg.Show(mainForm);
        }

        public void LogErrorMessage(AnalogyLogMessage error)
        {
            messages.Add(error);
            OnNewError?.Invoke(this, new EventArgs());
        }
    }
}
