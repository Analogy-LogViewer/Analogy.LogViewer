using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Interfaces;

namespace Analogy.Managers
{
    internal class FilePoolingManager : ILogMessageCreatedHandler
    {
        private string FileName { get; }
        private FileProcessor FileProcessor { get; }
        private IAnalogyOfflineDataProvider OfflineDataProvider { get; }
        private readonly CancellationTokenSource cancellationTokenSource;
        private readonly List<AnalogyLogMessage> messages;
        public EventHandler<(List<AnalogyLogMessage> messages, string dataSource)> OnNewMessages;
        public bool ForceNoFileCaching { get; } = true;
        private readonly object sync;
        private FileSystemWatcher watchFile;
        private bool readingInprogress;
        private AnalogyLogMessageCustomEqualityComparer customEqualityComparer;
        public FilePoolingManager(string fileName, IAnalogyOfflineDataProvider offlineDataProvider)
        {
            sync = new object();
            customEqualityComparer=new AnalogyLogMessageCustomEqualityComparer();
            cancellationTokenSource = new CancellationTokenSource();
            OfflineDataProvider = offlineDataProvider;
            messages = new List<AnalogyLogMessage>();
            FileName = fileName;
            FileProcessor = new FileProcessor(this);
            watchFile = new FileSystemWatcher
            {
                Path = Path.GetDirectoryName(fileName), Filter = Path.GetFileName(fileName)
            };
            watchFile.Changed += WatchFile_Changed;
            watchFile.Deleted += WatchFile_Deleted;
            watchFile.Renamed += WatchFile_Renamed;
            watchFile.Error += WatchFile_Error;
        }


        public Task Init()
        {
            watchFile.EnableRaisingEvents = true;
            return FileProcessor.Process(OfflineDataProvider, FileName, cancellationTokenSource.Token);
        }

        public void AppendMessage(AnalogyLogMessage message, string dataSource)
        {
            lock (sync)
            {
                if (!messages.Contains(message))
                {
                    messages.Add(message);
                    OnNewMessages?.Invoke(this, (new List<AnalogyLogMessage> { message }, dataSource));
                }
            }
        }

        public void AppendMessages(List<AnalogyLogMessage> messagesFromFile, string dataSource)
        {

            lock (sync)
            {
                var newMessages = messagesFromFile.Except(messages, customEqualityComparer).ToList();
                if (newMessages.Any())
                {
                    messages.AddRange(newMessages);
                    OnNewMessages?.Invoke(this, (newMessages, dataSource));
                }
            }
        }

        private void WatchFile_Error(object sender, ErrorEventArgs e)
        {
            watchFile.EnableRaisingEvents = false;
            watchFile.Dispose();
            AnalogyLogMessage m = new AnalogyLogMessage()
            {
                Text = $"Error monitoring file {FileName}. Reason {e.GetException()}",
                FileName = FileName,
                Level = AnalogyLogLevel.Critical,
                Category = "",
                Class = AnalogyLogClass.General,
                Date = DateTime.Now
            };
            OnNewMessages?.Invoke(this, (new List<AnalogyLogMessage> { m }, FileName));
        }

        private void WatchFile_Renamed(object sender, RenamedEventArgs e)
        {
            watchFile.EnableRaisingEvents = false;
            AnalogyLogMessage m = new AnalogyLogMessage()
            {
                Text = $"{FileName} has changed to {e.OldName}. Stopping monitoring",
                FileName = FileName,
                Level = AnalogyLogLevel.Warning,
                Category = "",
                Class = AnalogyLogClass.General,
                Date = DateTime.Now
            };
            watchFile.Dispose();
            OnNewMessages?.Invoke(this, (new List<AnalogyLogMessage> { m }, FileName));
        }

        private void WatchFile_Deleted(object sender, FileSystemEventArgs e)
        {
            watchFile.EnableRaisingEvents = false;
            AnalogyLogMessage m = new AnalogyLogMessage()
            {
                Text = $"{FileName} has been deleted. Stopping monitoring",
                FileName = FileName,
                Level = AnalogyLogLevel.Warning,
                Category = "",
                Class = AnalogyLogClass.General,
                Date = DateTime.Now
            };
            watchFile.Dispose();
            OnNewMessages?.Invoke(this, (new List<AnalogyLogMessage> { m }, FileName));
        }

        private async void WatchFile_Changed(object sender, FileSystemEventArgs e)
        {
            if (readingInprogress) return;
            lock (sync)
            {
                if (readingInprogress) return;
                watchFile.EnableRaisingEvents = false;
                readingInprogress = true;
            }

            try
            {
                await FileProcessor.Process(OfflineDataProvider, FileName, cancellationTokenSource.Token);
            }
            catch (Exception exception)
            {
                AnalogyLogMessage m = new AnalogyLogMessage()
                {
                    Text = $"Error monitoring file {FileName}. Reason {exception}",
                    FileName = FileName,
                    Level = AnalogyLogLevel.Warning,
                    Category = "",
                    Class = AnalogyLogClass.General,
                    Date = DateTime.Now
                };
                OnNewMessages?.Invoke(this, (new List<AnalogyLogMessage> { m }, FileName));
            }
            
            readingInprogress = false;
            watchFile.EnableRaisingEvents = true;
        }
    
    }
}

