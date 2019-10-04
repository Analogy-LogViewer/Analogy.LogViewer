using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Philips.Analogy.Interfaces.DataTypes;

namespace Philips.Analogy.Interfaces
{
    public interface IAnalogyDataProvider
    {
        Guid ID { get; }
        void InitDataProvider();

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
        Image OptionalDisconnectedImage { get; }
        Image OptionalConnectedImage { get; }
    }

    public interface IAnalogyOfflineDataProvider : IAnalogyDataProvider
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

}
