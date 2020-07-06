using Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Mvvm.Native;

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

        public async Task<IEnumerable<AnalogyLogMessage>> Process(IAnalogyOfflineDataProvider fileDataProvider,
            string filename, CancellationToken token, bool isReload = false)
        {
            //TODO in case of zip recursive call on all extracted files


            FileName = filename;
            if (string.IsNullOrEmpty(FileName)) return new List<AnalogyLogMessage>();
            if (!isReload && !DataWindow.ForceNoFileCaching &&
                FileProcessingManager.Instance.AlreadyProcessed(FileName) &&
                Settings.EnableFileCaching) //get it from the cache
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

                //extract files and call recursively
                if (Path.GetExtension(filename)?.ToLower() == ".zip")
                {
                    var files = Directory.GetFiles(UnzipFilesIntoTempFolder(filename, fileDataProvider));
                    files.ForEach(async file => await Process(fileDataProvider, file, token, isReload));
                }

                var messages = (await fileDataProvider.Process(filename, token, DataWindow).ConfigureAwait(false))
                    .ToList();
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
                AnalogyLogMessage error = new AnalogyLogMessage($"Error reading file {filename}: Error: {e.Message}",
                    AnalogyLogLevel.Error, AnalogyLogClass.General, "Analogy", "None");
                error.Source = nameof(FileProcessor);
                error.Module = "Analogy";
                DataWindow.AppendMessage(error, fileDataProvider.GetType().FullName);
                return new List<AnalogyLogMessage> { error };
            }
        }


        private string UnzipFilesIntoTempFolder(string zipPath, IAnalogyOfflineDataProvider fileDataProvider)
        {
            using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {

                    //build a list of files to be extracted
                    var entries = new List<ZipArchiveEntry>();
                    foreach (var supportFormat in fileDataProvider.SupportFormats)
                    {
                        var result = archive.Entries.Where(entry => entry.FullName.ToLower(CultureInfo.InvariantCulture).EndsWith(supportFormat.ToLower(CultureInfo.InvariantCulture)));
                        entries.AddRange(result.ToList());
                    }


                    //extract files to folder named after file in the app's directory ?
                    //todo decide where to unzip the files , by config?
                    string extractPath = Path.GetFileNameWithoutExtension(zipPath);
                    foreach (ZipArchiveEntry entry in entries)
                    {
                        entry.ExtractToFile(Path.Combine(extractPath, entry.Name));
                    }

                    if (Directory.GetFiles(extractPath).Any())
                    {
                        return extractPath;
                    }
                    throw new FileLoadException("Zip file does not contain any supported files");
                }

            }
        }
    }
}
