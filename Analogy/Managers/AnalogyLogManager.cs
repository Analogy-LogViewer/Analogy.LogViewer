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
        public bool HasMessages => messages.Any();
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
        public void LogEvent(string data)
        {
            messages.Add(new AnalogyLogMessage(data, AnalogyLogLevel.Event, AnalogyLogClass.General, "Analogy"));
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
