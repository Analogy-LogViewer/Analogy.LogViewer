using Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy
{
    public class FileProcessor
    {
        public event EventHandler<EventArgs> OnFileReadingFinished;
        public DateTime lastNewestMessage;
        private UserSettingsManager Settings => UserSettingsManager.UserSettings;
        private string FileName { get; set; }
        public Stream DataStream { get; set; }
        private ILogMessageCreatedHandler DataWindow { get; set; }
        public UCLogs LogWindow { get; set; }

        public FileProcessor(ILogMessageCreatedHandler dataWindow)
        {
            DataWindow = dataWindow;
            if (dataWindow is UCLogs logs)
                LogWindow = logs;

        }

        public async Task<IEnumerable<AnalogyLogMessage>> Process(IAnalogyOfflineDataProvider fileDataProvider, string filename, CancellationToken token, bool isReload = false)
        {
            FileName = filename;
            if (string.IsNullOrEmpty(FileName)) return new List<AnalogyLogMessage>();
            if (!isReload && !DataWindow.ForceNoFileCaching && FileProcessingManager.Instance.AlreadyProcessed(FileName) && Settings.EnableFileCaching) //get it from the cache
            {
                var cachedMessages = FileProcessingManager.Instance.GetMessages(FileName);
                DataWindow.AppendMessages(cachedMessages, Utils.GetFileNameAsDataSource(FileName));
                if (LogWindow != null)
                    Interlocked.Decrement(ref LogWindow.fileLoadingCount);
                return cachedMessages;

            }

            if (FileProcessingManager.Instance.IsFileCurrentlyBeingProcessed(FileName))
            {
                while (FileProcessingManager.Instance.IsFileCurrentlyBeingProcessed(FileName))
                {
                    await Task.Delay(1000);
                }
                var cachedMessages = FileProcessingManager.Instance.GetMessages(FileName);
                DataWindow.AppendMessages(cachedMessages, Utils.GetFileNameAsDataSource(FileName));
                if (LogWindow != null)
                    Interlocked.Decrement(ref LogWindow.fileLoadingCount);
                return cachedMessages;

            }
            //otherwise read file:
            try
            {


                FileProcessingManager.Instance.AddProcessingFile(FileName);
                if (!DataWindow.DoNotAddToRecentHistory)
                    Settings.AddToRecentFiles(fileDataProvider.ID, FileName);
                var messages = (await fileDataProvider.Process(filename, token, DataWindow).ConfigureAwait(false)).ToList();
                FileProcessingManager.Instance.DoneProcessingFile(messages.ToList(), FileName);
                if (messages.Any())
                    lastNewestMessage = messages.Select(m => m.Date).Max();
                OnFileReadingFinished?.Invoke(this, EventArgs.Empty);
                if (LogWindow != null)
                    Interlocked.Decrement(ref LogWindow.fileLoadingCount);
                return messages;
            }
            catch (Exception e)
            {
                AnalogyLogger.Instance.LogCritical("Analogy", $"Error parsing file: {e}");
                AnalogyLogMessage error = new AnalogyLogMessage($"Error reading file {filename}: Error: {e.Message}", AnalogyLogLevel.Error, AnalogyLogClass.General, "Analogy", "None");
                error.Source = nameof(FileProcessor);
                error.Module = "Analogy";
                DataWindow.AppendMessage(error, fileDataProvider.GetType().FullName);
                return new List<AnalogyLogMessage> { error };
            }
        }


    }
}
