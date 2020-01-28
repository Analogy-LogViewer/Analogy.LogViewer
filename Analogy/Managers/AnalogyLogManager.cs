using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Interfaces;
using Analogy.LogLoaders;
using DevExpress.XtraEditors;

namespace Analogy.Managers
{
    public class AnalogyLogManager
    {
        private static Lazy<AnalogyLogManager> _instance = new Lazy<AnalogyLogManager>();
        public static AnalogyLogManager Instance => _instance.Value;
        public bool HasErrorMessages => messages.Any(m=>m.Level==AnalogyLogLevel.Critical || m.Level == AnalogyLogLevel.Error);
        public bool HasWarningMessages => messages.Any(m => m.Level == AnalogyLogLevel.Warning);
        private string FileName { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AnalogyInternalLog.log");
        private bool ContentChanged;
        private List<AnalogyLogMessage> messages;
        public event EventHandler OnNewError;

        public AnalogyLogManager()
        {
            messages = new List<AnalogyLogMessage>();
         
        }

        public async Task Init()
        {
            if (File.Exists(FileName))
            {
                try
                {
                    AnalogyXmlLogFile read = new AnalogyXmlLogFile();
                   var messages = await read.ReadFromFile(FileName);
                   this.messages.AddRange(this.messages);
                }
                catch (Exception e)
                {
                    LogError("Error Saving file: " + e, nameof(AnalogyLogManager));
                    XtraMessageBox.Show(e.Message, @"Error Saving file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private List<AnalogyLogMessage> GetFilteredMessages()
        {
            return messages.Where(m =>
                    DateTime.Now.Subtract(m.Date).TotalDays <=
                    UserSettingsManager.UserSettings.AnalogyInternalLogPeriod)
                .ToList();
        }
        public void SaveFile()
        {
            if (!ContentChanged) return;
            if (!messages.Any())
            {
                if (File.Exists(FileName))
                    try
                    {
                        File.Delete(FileName);
                    }
                    catch (Exception e)
                    {
                        LogError("Error deleting file: " + e, nameof(BookmarkPersistManager));
                    }
            }
            else
            {

                try
                {
                    AnalogyXmlLogFile save = new AnalogyXmlLogFile();
                    save.Save(GetFilteredMessages(), FileName);
                }
                catch (Exception e)
                {
                    LogError("Error saving file: " + e, nameof(BookmarkPersistManager));
                    XtraMessageBox.Show(e.Message, @"Error Saving file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ClearLog()
        {
            if (messages.Any())
            {
                messages.Clear();
                ContentChanged = true;
            }
        }

        public void LogError(string error,string source)
        {
            ContentChanged = true;
            messages.Add(new AnalogyLogMessage(error, AnalogyLogLevel.Error, AnalogyLogClass.General, source));
            OnNewError?.Invoke(this, new EventArgs());
        }
        public void LogEvent(string data,string source)
        {
            ContentChanged = true;
            messages.Add(new AnalogyLogMessage(data, AnalogyLogLevel.Event, AnalogyLogClass.General, source));
        }
        public void LogWarning(string data, string source)
        {
            ContentChanged = true;
            messages.Add(new AnalogyLogMessage(data, AnalogyLogLevel.Warning, AnalogyLogClass.General, source));
        }
        public void LogDebug(string data, string source)
        {
            ContentChanged = true;
            messages.Add(new AnalogyLogMessage(data, AnalogyLogLevel.Debug, AnalogyLogClass.General, source));
        }
        public void LogCritical(string data, string source)
        {
            ContentChanged = true;
            messages.Add(new AnalogyLogMessage(data, AnalogyLogLevel.Critical, AnalogyLogClass.General, source));
        }
        public void Show(MainForm mainForm)
        {
            XtraFormLogGrid msg = new XtraFormLogGrid(messages, "Analogy", "Analogy");
            msg.Show(mainForm);
        }

        public void LogErrorMessage(AnalogyLogMessage error)
        {
            ContentChanged = true;
            messages.Add(error);
            OnNewError?.Invoke(this, new EventArgs());
        }
    }
}
