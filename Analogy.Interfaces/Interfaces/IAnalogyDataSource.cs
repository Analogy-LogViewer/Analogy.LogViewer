using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Philips.Analogy.Interfaces.Interfaces
{
    public interface IAnalogyFactories
    {
        Guid FactoryID { get; }
        string Title { get; }
        IAnalogyDataSourceFactory DataSources { get; }
        IAnalogyCustomActionFactory Actions { get; }
        IAnalogyUserControlFactory UserControls { get; }
    }
    public interface IAnalogyDataSourceFactory
    {
        string Title { get; }
        IEnumerable<IAnalogyDataSource> Items { get; }
    }
    public interface IAnalogyCustomActionFactory
    {
        string Title { get; }
        IEnumerable<IAnalogyCustomAction> Items { get; }
    }
    public interface IAnalogyUserControlFactory
    {
        string Title { get; }
        IEnumerable<IAnalogyUserControl> Items { get; }
    }
    public interface IAnalogyDataSource
    {
        Guid ID { get; }
        void InitDataSource();

    }

    public interface IAnalogyRealTimeDataSource : IAnalogyDataSource
    {
        event EventHandler<AnalogyDataSourceDisconnectedArgs> OnDisconnected;
        event EventHandler<AnalogyLogMessageArgs> OnMessageReady;
        event EventHandler<AnalogyLogMessagesArgs> OnManyMessagesReady;
        bool AutoStartAtLaunch { get; }
        Task<bool> CanStartReceiving();
        void StartReceiving();
        void StopReceiving();
        Image OptionalDisconnectedImage { get; }
        Image OptionalConnectedImage { get; }
    }

    public interface IAnalogyOfflineDataSource : IAnalogyDataSource
    {
        bool CanSaveToLogFile { get; }
        string FileOpenDialogFilters { get; }
        string FileSaveDialogFilters { get; }
        IEnumerable<string> SupportFormats { get; }
        string InitialFolderFullPath { get; }
        Image OptionalOpenFolderImage { get; }
        Image OptionalOpenFilesImage { get; }
        Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler);
        IEnumerable<FileInfo> GetSupportedFiles(DirectoryInfo dirInfo, bool recursiveLoad);
        Task SaveAsync(List<AnalogyLogMessage> messages, string fileName);
        bool CanOpenFile(string fileName);
        bool CanOpenAllFiles(IEnumerable<string> fileNames);
    }


    public interface IAnalogyDirectFileLoadingDataSource : IAnalogyDataSource
    {
        string FileNameToLaunch { get; }
        IEnumerable<string> SupportFormats { get; }
        Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler);
        IEnumerable<FileInfo> GetSupportedFiles(DirectoryInfo dirInfo, bool recursiveLoad);
    }
}
