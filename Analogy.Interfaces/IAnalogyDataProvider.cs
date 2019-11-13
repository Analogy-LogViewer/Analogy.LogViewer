using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.Interfaces
{
    public interface IAnalogyDataProvider
    {
        Guid ID { get; }
        void InitDataProvider();

        string OptionalTitle { get; }

    }
    
    public interface IAnalogyRealTimeDataProvider : IAnalogyDataProvider
    {
        event EventHandler<AnalogyDataSourceDisconnectedArgs> OnDisconnected;
        event EventHandler<AnalogyLogMessageArgs> OnMessageReady;
        event EventHandler<AnalogyLogMessagesArgs> OnManyMessagesReady;
        /// <summary>
        /// Handler for save/read logs for the online source.
        /// </summary>
        IAnalogyOfflineDataProvider FileOperationsHandler { get; }
        Task<bool> CanStartReceiving();
        void StartReceiving();
        void StopReceiving();
        bool IsConnected { get; }
    }

    public interface IAnalogyOfflineDataProvider : IAnalogyDataProvider
    {
        bool CanSaveToLogFile { get; }
        string FileOpenDialogFilters { get; }
        string FileSaveDialogFilters { get; }
        IEnumerable<string> SupportFormats { get; }
        string InitialFolderFullPath { get; }

        Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler);
        IEnumerable<FileInfo> GetSupportedFiles(DirectoryInfo dirInfo, bool recursiveLoad);
        Task SaveAsync(List<AnalogyLogMessage> messages, string fileName);
        bool CanOpenFile(string fileName);
        bool CanOpenAllFiles(IEnumerable<string> fileNames);
    }

}
