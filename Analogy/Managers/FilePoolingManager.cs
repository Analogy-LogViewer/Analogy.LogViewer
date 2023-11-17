using Analogy.Common.DataTypes;
using Analogy.Common.Managers;
using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.UserControls;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Analogy.Managers;

internal class FilePoolingManager : ILogMessageCreatedHandler
{
    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly AnalogyLogMessageCustomEqualityComparer _customEqualityComparer;
    private readonly UCLogs _logUI;
    private readonly List<IAnalogyLogMessage> _messages;

    //Instantiate a Singleton of the Semaphore with a value of 1. This means that only 1 thread can be granted access at a time.
    private readonly SemaphoreSlim _watcherSemaphore = new(1, 1);

    private readonly object _sync;
    private DateTime _lastRead;
    private DateTime _lastWriteTime = DateTime.MinValue;
    private bool _readingInprogress;
    private FileSystemWatcher _watchFile;
    public EventHandler<(List<IAnalogyLogMessage> messages, string dataSource)> OnNewMessages;
    private IAnalogyUserSettings Settings { get; }

    public FilePoolingManager(IAnalogyUserSettings settings, string filter, string initialFilename, UCLogs logUI,
        IAnalogyOfflineDataProvider offlineDataProvider)
    {
        _sync = new object();
        Settings = settings;
        _logUI = logUI;
        _customEqualityComparer = new AnalogyLogMessageCustomEqualityComparer { CompareId = false };
        _cancellationTokenSource = new CancellationTokenSource();
        OfflineDataProvider = offlineDataProvider;
        _messages = new List<IAnalogyLogMessage>();
        FileName = initialFilename;
        FileFilter = filter;
        FileProcessor = new FileProcessor(Settings, this, ServicesProvider.Instance.GetService<FileProcessingManager>(), ServicesProvider.Instance.GetService<ILogger>());
    }

    private string FileName { get; }
    private FileProcessor FileProcessor { get; }
    private IAnalogyOfflineDataProvider OfflineDataProvider { get; }

    public string FileFilter { get; set; }

    public bool HasFileFilter { get; set; }
    public bool ForceNoFileCaching { get; set; } = true;
    public bool DoNotAddToRecentHistory { get; set; } = true;

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
            List<IAnalogyLogMessage> newMessages = messagesFromFile.Except(_messages, _customEqualityComparer).ToList();
            if (newMessages.Any())
            {
                _messages.AddRange(newMessages);
                OnNewMessages?.Invoke(this, (newMessages, dataSource));
            }
        }
    }

    public void ReportFileReadProgress(AnalogyFileReadProgress progress)
    {
        //noop
    }

    public Task Init()
    {
        HasFileFilter = !FileFilter.Equals(FileName);
        _watchFile = new FileSystemWatcher
        {
            Path = Path.GetDirectoryName(FileName),
            Filter = Path.GetFileName(FileFilter),
        };
        _watchFile.Changed += WatchFile_Changed;
        if (!HasFileFilter)
        {
            _watchFile.Deleted += WatchFile_Deleted;
            _watchFile.Renamed += WatchFile_Renamed;
        }
        _watchFile.Error += WatchFile_Error;
        _watchFile.EnableRaisingEvents = true;
        AnalogyLogMessage m = new()
        {
            Text = $"Start monitoring file {FileFilter}.",
            FileName = FileFilter,
            Level = AnalogyLogLevel.Analogy,
            Source = "Analogy",
            Class = AnalogyLogClass.General,
            Date = DateTime.Now,
        };
        OnNewMessages?.Invoke(this, (new List<IAnalogyLogMessage> { m }, FileName));
        if (!HasFileFilter)
        {
            return FileProcessor.Process(OfflineDataProvider, FileName, _cancellationTokenSource.Token);
        }

        List<Task> tasks = new();
        if (_watchFile.Path != null)
            foreach (string? file in Directory.GetFiles(_watchFile.Path, _watchFile.Filter, SearchOption.TopDirectoryOnly))
            {
                tasks.Add(FileProcessor.Process(OfflineDataProvider, file, _cancellationTokenSource.Token));
            }

        return Task.WhenAll(tasks);
    }

    public void StopMonitoring()
    {
        _watchFile.EnableRaisingEvents = false;
        _watchFile.Changed -= WatchFile_Changed;
        if (!HasFileFilter)
        {
            _watchFile.Deleted -= WatchFile_Deleted;
            _watchFile.Renamed -= WatchFile_Renamed;
        }
        _watchFile.Error -= WatchFile_Error;
        _watchFile.Dispose();
    }

    private void WatchFile_Error(object sender, ErrorEventArgs e)
    {
        _watcherSemaphore.Wait();
        try
        {
            _watchFile.EnableRaisingEvents = false;
            _watchFile.Dispose();
            AnalogyLogMessage m = new()
            {
                Text = $"Error monitoring file {FileName}. Reason {e.GetException()}",
                FileName = FileName,
                Level = AnalogyLogLevel.Critical,
                Source = "Analogy",
                Class = AnalogyLogClass.General,
                Date = DateTime.Now,
            };
            OnNewMessages?.Invoke(this, (new List<IAnalogyLogMessage> { m }, FileName));
        }
        finally
        {
            _watcherSemaphore.Release();
        }
    }

    private async void WatchFile_Renamed(object sender, RenamedEventArgs e)
    {
        await _watcherSemaphore.WaitAsync();
        try
        {
            _watchFile.EnableRaisingEvents = false;
            AnalogyLogMessage m = new()
            {
                Text = $"{FileName} has changed to {e.FullPath} from {e.OldName}. restarting monitoring",
                FileName = FileName,
                Level = AnalogyLogLevel.Warning,
                Source = "Analogy",
                Class = AnalogyLogClass.General,
                Date = DateTime.Now,
            };
            _watchFile.Dispose();
            OnNewMessages?.Invoke(this, (new List<IAnalogyLogMessage> { m }, FileName));
            await Init();
        }
        finally
        {
            _watcherSemaphore.Release();
        }
    }

    private void WatchFile_Deleted(object sender, FileSystemEventArgs e)
    {
        _watcherSemaphore.Wait();
        try
        {
            _watchFile.EnableRaisingEvents = false;
            AnalogyLogMessage m = new()
            {
                Text = $"{FileName} has been deleted. Stopping monitoring",
                FileName = FileName,
                Level = AnalogyLogLevel.Warning,
                Class = AnalogyLogClass.General,
                Date = DateTime.Now,
            };
            _watchFile.Dispose();
            OnNewMessages?.Invoke(this, (new List<IAnalogyLogMessage> { m }, FileName));
        }
        finally
        {
            _watcherSemaphore.Release();
        }
    }

    private async void WatchFile_Changed(object sender, FileSystemEventArgs e)
    {
        await _watcherSemaphore.WaitAsync();
        try
        {
            if (_readingInprogress)
            {
                return;
            }

            FileInfo f = new(e.FullPath);
            if (_lastWriteTime == f.LastWriteTime)
            {
                return;
            }

            lock (_sync)
            {
                if (_readingInprogress || (Settings.EnableFilePoolingDelay && DateTime.Now.Subtract(_lastRead).TotalSeconds <= Settings.FilePoolingDelayInterval))
                {
                    return;
                }

                _lastWriteTime = f.LastWriteTime;
                _lastRead = DateTime.Now;
                _watchFile.EnableRaisingEvents = false;
                _readingInprogress = true;
            }
            try
            {
                if (e.ChangeType == WatcherChangeTypes.Changed)
                {
                    _logUI.SetReloadColorDate(FileProcessor.lastNewestMessage);
                    await FileProcessor.Process(OfflineDataProvider, e.FullPath, _cancellationTokenSource.Token);
                }
            }
            catch (Exception exception)
            {
                AnalogyLogMessage m = new()
                {
                    Text = $"Error monitoring file {e.FullPath}. Reason {exception}",
                    FileName = FileName,
                    Level = AnalogyLogLevel.Warning,
                    Class = AnalogyLogClass.General,
                    Date = DateTime.Now,
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
        finally
        {
            _watcherSemaphore.Release();
        }
    }
}