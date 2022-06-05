using Analogy.Interfaces;
using Analogy.LogLoaders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.CommonControls.Interfaces;
using Analogy.Forms;

namespace Analogy.Managers
{
    public class AnalogyLogManager : IAnalogyLogger
    {
        public event EventHandler<(AnalogyLogMessage msg, string source)> OnNewMessage;
        private static Lazy<AnalogyLogManager> _instance = new Lazy<AnalogyLogManager>();
        public static AnalogyLogManager Instance => _instance.Value;

        public bool HasErrorMessages => messages.Any(m => m.Level == AnalogyLogLevel.Critical || m.Level == AnalogyLogLevel.Error);
        public bool HasWarningMessages => messages.Any(m => m.Level == AnalogyLogLevel.Warning);
        private bool ContentChanged;
        private List<AnalogyLogMessage> messages;
        public event EventHandler OnNewError;
        public List<string> ignoredMessages;
        public AnalogyLogManager()
        {
            messages = new List<AnalogyLogMessage>();
            ignoredMessages = new List<string>
            {
                "System.ArgumentException: Duplicate component name '_Container'.  Component names must be unique and case-insensitive",
                "System.IO.FileNotFoundException: Could not load file or assembly 'mscorlib.XmlSerializers"
            };

        }

        public async Task Init()
        {
            //if (File.Exists(FileName))
            //{
            //    try
            //    {
            //        AnalogyJsonLogFile read = new AnalogyJsonLogFile();
            //        var old = await read.ReadFromFile(FileName,new CancellationToken(), null);
            //        this.messages.AddRange(old.Where(m => !ignoredMessages.Any(m.Text.Contains)));
            //    }
            //    catch (Exception e)
            //    {
            //        LogError("Error loading file: " + e, nameof(AnalogyLogManager));
            //    }
            //}
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
            //if (!ContentChanged) return;
            //if (!messages.Any())
            //{
            //    if (File.Exists(FileName))
            //        try
            //        {
            //            File.Delete(FileName);
            //        }
            //        catch (Exception e)
            //        {
            //            LogError("Error deleting file: " + e, nameof(AnalogyLogManager));
            //        }
            //}
            //else
            //{

            //    try
            //    {
            //        AnalogyJsonLogFile save = new AnalogyJsonLogFile();
            //        save.Save(GetFilteredMessages(), FileName);
            //    }
            //    catch (Exception e)
            //    {
            //        LogError("Error saving file: " + e, nameof(AnalogyLogManager));
            //        if (postfix < 3)
            //        {
            //            postfix++;
            //            SaveFile();
            //        }

            //        //XtraMessageBox.Show(e.Message, @"Error Saving file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        public void ClearLog()
        {
            if (messages.Any())
            {
                messages.Clear();
                ContentChanged = true;
            }
        }

        public void LogError(string error, string source)
        {
            if (ignoredMessages.Any(error.Contains))
            {
                return;
            }

            ContentChanged = true;
            messages.Add(new AnalogyLogMessage(error, AnalogyLogLevel.Error, AnalogyLogClass.General, source));
            OnNewError?.Invoke(this, new EventArgs());
            AnalogyErrorMessage err = new AnalogyErrorMessage(error, source);
            OnNewMessage?.Invoke(this, (err, source));
        }
        public void LogInformation(string data, string source)
        {
            if (ignoredMessages.Any(data.Contains))
            {
                return;
            }

            ContentChanged = true;
            messages.Add(new AnalogyLogMessage(data, AnalogyLogLevel.Information, AnalogyLogClass.General, source));
            AnalogyInformationMessage err = new AnalogyInformationMessage(data, source);
            OnNewMessage?.Invoke(this, (err, source));
        }
        public void LogWarning(string data, string source)
        {
            if (ignoredMessages.Any(data.Contains))
            {
                return;
            }

            ContentChanged = true;
            messages.Add(new AnalogyLogMessage(data, AnalogyLogLevel.Warning, AnalogyLogClass.General, source));
            AnalogyInformationMessage err = new AnalogyInformationMessage(data, source);
            err.Level = AnalogyLogLevel.Warning;
            OnNewMessage?.Invoke(this, (err, source));
        }
        public void LogDebug(string data, string source)
        {
            if (ignoredMessages.Any(data.Contains))
            {
                return;
            }

            ContentChanged = true;
            messages.Add(new AnalogyLogMessage(data, AnalogyLogLevel.Debug, AnalogyLogClass.General, source));
            AnalogyInformationMessage err = new AnalogyInformationMessage(data, source);
            err.Level = AnalogyLogLevel.Debug;
            OnNewMessage?.Invoke(this, (err, source));
        }
        public void LogCritical(string data, string source)
        {
            if (ignoredMessages.Any(data.Contains))
            {
                return;
            }

            ContentChanged = true;
            messages.Add(new AnalogyLogMessage(data, AnalogyLogLevel.Critical, AnalogyLogClass.General, source));
            OnNewError?.Invoke(this, new EventArgs());
            AnalogyInformationMessage err = new AnalogyInformationMessage(data, source);
            err.Level = AnalogyLogLevel.Critical;
            OnNewMessage?.Invoke(this, (err, source));
        }
        public void Show(Form mainForm)
        {
            XtraFormLogGrid msg = new XtraFormLogGrid(messages, "Analogy", true);
            msg.Show(mainForm);
        }

        public void LogErrorMessage(AnalogyLogMessage error)
        {
            if (ignoredMessages.Any(error.Text.Contains))
            {
                return;
            }

            ContentChanged = true;
            messages.Add(error);
            OnNewError?.Invoke(this, new EventArgs());
            OnNewMessage?.Invoke(this, (error, error.Source));
        }

        public void LogInformation(string message, string source = "", string memberName = "", int lineNumber = 0,
            string filePath = "")
        {
            LogInformation(message, source);
        }

        public void LogWarning(string message, string source = "", string memberName = "", int lineNumber = 0, string filePath = "")
        {
            LogWarning(message, source);
        }

        public void LogDebug(string message, string source = "", string memberName = "", int lineNumber = 0, string filePath = "")
        {
            LogDebug(message, source);
        }

        public void LogError(string message, string source = "", string memberName = "", int lineNumber = 0, string filePath = "")
        {
            LogError(message, source);
        }

        public void LogCritical(string message, string source = "", string memberName = "", int lineNumber = 0, string filePath = "")
        {
            LogCritical(message, source);
        }

        public void LogException(string message, Exception ex, string source = "", string memberName = "", int lineNumber = 0,
            string filePath = "")
        {
            LogError(ex.Message, source);
        }
    }
}
