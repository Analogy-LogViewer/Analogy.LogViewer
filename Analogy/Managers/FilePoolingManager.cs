using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;

namespace Analogy.Managers
{
    internal class FilePoolingManager : ILogMessageCreatedHandler
    {
        private IAnalogyUserSettings Settings => UserSettingsManager.UserSettings;

        private string FileName { get; }
        private FileProcessor FileProcessor { get; }
        private IAnalogyOfflineDataProvider OfflineDataProvider { get; }
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly List<IAnalogyLogMessage> _messages;
        public EventHandler<(List<IAnalogyLogMessage> messages, string dataSource)> OnNewMessages;
        public bool ForceNoFileCaching { get; set; } = true;

        public bool DoNotAddToRecentHistory { get; set; } = true;
        private readonly object _sync;
        private FileSystemWatcher _watchFile;
        private bool _readingInprogress;
        private DateTime lastWriteTime = DateTime.MinValue;
        private DateTime lastRead;
        private UCLogs LogUI;
        private readonly AnalogyLogMessageCustomEqualityComparer _customEqualityComparer;
        public FilePoolingManager(string filter,  string  initialFilename, UCLogs logUI, IAnalogyOfflineDataProvider offlineDataProvider)
        {
            _sync = new object();
            LogUI = logUI;
            _customEqualityComparer = new AnalogyLogMessageCustomEqualityComparer { CompareId = false };
            _cancellationTokenSource = new CancellationTokenSource();
            OfflineDataProvider = offlineDataProvider;
            _messages = new List<IAnalogyLogMessage>();
            FileName = initialFilename;
            FileFilter = filter;
            FileProcessor = new FileProcessor(Settings, this,AnalogyLogger.Instance);

        }

        public string FileFilter { get; set; }

        public Task Init()
        {
            HasFiltFilter = !FileFilter.Equals(FileName);
            _watchFile = new FileSystemWatcher
            {
                Path = Path.GetDirectoryName(FileName),
                Filter = Path.GetFileName(FileFilter)
            };
            _watchFile.Changed += WatchFile_Changed;
            if (HasFiltFilter)
            {
                _watchFile.Deleted += WatchFile_Deleted;
                _watchFile.Renamed += WatchFile_Renamed;
            }
            _watchFile.Error += WatchFile_Error;
            _watchFile.EnableRaisingEvents = true;
            AnalogyLogMessage m = new AnalogyLogMessage
            {
                Text = $"Start monitoring file {FileFilter}.",
                FileName = FileFilter,
                Level = AnalogyLogLevel.Analogy,
                Source = "Analogy",
                Class = AnalogyLogClass.General,
                Date = DateTime.Now
            };
            
            OnNewMessages?.Invoke(this, (new List<IAnalogyLogMessage> { m }, FileName));
            return FileProcessor.Process(OfflineDataProvider, FileName, _cancellationTokenSource.Token);
        }

        public bool HasFiltFilter { get; set; }

        public void StopMonitoring()
        {

            _watchFile.EnableRaisingEvents = false;
            _watchFile.Changed -= WatchFile_Changed;
            if (HasFiltFilter)
            {
                _watchFile.Deleted -= WatchFile_Deleted;
                _watchFile.Renamed -= WatchFile_Renamed;
            }
            _watchFile.Error -= WatchFile_Error;
            _watchFile.Dispose();
        }
        public void AppendMessage(IAnalogyLogMessage message, string dataSource)
        {
            lock (_sync)
            {
                if (!_messages.Contains(message))
                {
                    _messages.Add(message);
                    OnNewMessages?.Invoke(this, (new List<IAnalogyLogMessage> { message }, dataSource));
                }
            }
        }

        public void AppendMessages(List<IAnalogyLogMessage> messagesFromFile, string dataSource)
        {

            lock (_sync)
            {
                var newMessages = messagesFromFile.Except(_messages, _customEqualityComparer).ToList();
                if (newMessages.Any())
                {
                    _messages.AddRange(newMessages);
                    OnNewMessages?.Invoke(this, (newMessages, dataSource));
                }
            }
        }

        private void WatchFile_Error(object sender, ErrorEventArgs e)
        {
            _watchFile.EnableRaisingEvents = false;
            _watchFile.Dispose();
            AnalogyLogMessage m = new AnalogyLogMessage
            {
                Text = $"Error monitoring file {FileName}. Reason {e.GetException()}",
                FileName = FileName,
                Level = AnalogyLogLevel.Critical,
                Source = "Analogy",
                Class = AnalogyLogClass.General,
                Date = DateTime.Now
            };
            OnNewMessages?.Invoke(this, (new List<IAnalogyLogMessage> { m }, FileName));
        }

        private async void WatchFile_Renamed(object sender, RenamedEventArgs e)
        {
            _watchFile.EnableRaisingEvents = false;
            AnalogyLogMessage m = new AnalogyLogMessage
            {
                Text = $"{FileName} has changed to {e.FullPath} from {e.OldName}. restarting monitoring",
                FileName = FileName,
                Level = AnalogyLogLevel.Warning,
                Source = "Analogy",
                Class = AnalogyLogClass.General,
                Date = DateTime.Now
            };
            _watchFile.Dispose();
            OnNewMessages?.Invoke(this, (new List<IAnalogyLogMessage> { m }, FileName));
            await Init();

        }

        private void WatchFile_Deleted(object sender, FileSystemEventArgs e)
        {
            _watchFile.EnableRaisingEvents = false;
            AnalogyLogMessage m = new AnalogyLogMessage
            {
                Text = $"{FileName} has been deleted. Stopping monitoring",
                FileName = FileName,
                Level = AnalogyLogLevel.Warning,
                Class = AnalogyLogClass.General,
                Date = DateTime.Now
            };
            _watchFile.Dispose();
            OnNewMessages?.Invoke(this, (new List<IAnalogyLogMessage> { m }, FileName));
        }

        private async void WatchFile_Changed(object sender, FileSystemEventArgs e)
        {
            if (_readingInprogress)
            {
                return;
            }

            FileInfo f = new FileInfo(e.FullPath);
            if (lastWriteTime == f.LastWriteTime)
            {
                return;
            }



            lock (_sync)
            {
                if (_readingInprogress || (Settings.EnableFilePoolingDelay && DateTime.Now.Subtract(lastRead).TotalSeconds <= Settings.FilePoolingDelayInterval))
                {
                    return;
                }
                lastWriteTime = f.LastWriteTime;
                lastRead = DateTime.Now;
                _watchFile.EnableRaisingEvents = false;
                _readingInprogress = true;

            }

            try
            {
                if (e.ChangeType == WatcherChangeTypes.Changed)
                {
                    LogUI.SetReloadColorDate(FileProcessor.lastNewestMessage);
                    await FileProcessor.Process(OfflineDataProvider, e.FullPath, _cancellationTokenSource.Token);
                }
            }
            catch (Exception exception)
            {
                AnalogyLogMessage m = new AnalogyLogMessage
                {
                    Text = $"Error monitoring file {e.FullPath}. Reason {exception}",
                    FileName = FileName,
                    Level = AnalogyLogLevel.Warning,
                    Class = AnalogyLogClass.General,
                    Date = DateTime.Now
                };
                OnNewMessages?.Invoke(this, (new List<IAnalogyLogMessage> { m }, e.FullPath));
                AnalogyLogManager.Instance.LogErrorMessage(m);
            }
            finally
            {
                _readingInprogress = false;
                _watchFile.EnableRaisingEvents = true;
            }
        }
        public void ReportFileReadProgress(AnalogyFileReadProgress progress)
        {
            //noop
        }
    }
}

