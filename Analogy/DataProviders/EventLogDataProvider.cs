using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Analogy.DataProviders;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogLoaders;
using Analogy.Properties;


namespace Analogy.DataSources
{

    public class EventLogDataFactory : IAnalogyFactory
    {
        public static Guid ID { get; } = new Guid("3949DB4C-0E22-4795-92C1-61B05EDB3F6C");

        public Guid FactoryID { get; } = ID;
        public string Title { get; } = "Windows Event logs";
        public IAnalogyDataProvidersFactory DataProviders { get; }=new EventLogDataProviders();
        public IAnalogyCustomActionsFactory Actions { get; } = new EmptyActionsFactory();
        public IEnumerable<IAnalogyChangeLog> ChangeLog { get; } = CommonChangeLog.GetChangeLog();
        public IEnumerable<string> Contributors { get; } = new List<string>() { "Lior Banai" };
        public string About { get; } = "Analogy Built-In Windows Event Log Data Provider";

        public class EventLogDataProviders : IAnalogyDataProvidersFactory
        {
            public string Title { get; } = "Analogy Built-In Windows Event Log Data Provider";
            public IEnumerable<IAnalogyDataProvider> Items { get; } = new List<IAnalogyDataProvider> { new EventLogDataProvider() };
        }
    }
    public class EventLogDataProvider : IAnalogyOfflineDataProvider
    {
        public string OptionalTitle { get; } = "Analogy Built-In Windows Event Log Data Provider";
        public UCLogs LogWindow { get; set; }
        public Guid ID { get; } = new Guid("465F4963-71F3-4E50-8253-FA286BF5692B");
        public Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            return Task.CompletedTask;
        }

        public void MessageOpened(AnalogyLogMessage message)
        {
            //nop
        }

        public bool CanSaveToLogFile { get; } = false;
        public string FileOpenDialogFilters { get; } = "Windows Event log files (*.evtx)|*.evtx";
        public string FileSaveDialogFilters { get; } = "";
        public IEnumerable<string> SupportFormats { get; } = new[] { "*.evtx" };

        public string InitialFolderFullPath { get; } =
            Path.Combine(Environment.ExpandEnvironmentVariables("%SystemRoot%"), "System32", "Winevt", "Logs");
        public Image OptionalOpenFolderImage { get; } = Resources.OperatingSystem_16x16;
        public Image OptionalOpenFilesImage { get; } = Resources.OperatingSystem_16x16;

        public async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
        {
            if (CanOpenFile(fileName))
            {
                EventViewerLogLoader logLoader = new EventViewerLogLoader(token);
                var messages = await logLoader.ReadFromFile(fileName, messagesHandler).ConfigureAwait(false);
                return messages;
            }

            AnalogyLogMessage m = new AnalogyLogMessage
            {
                Text = $"Unsupported file: {fileName}. Skipping file",
                Level = AnalogyLogLevel.Critical,
                Source = "Analogy",
                Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName,
                ProcessID = System.Diagnostics.Process.GetCurrentProcess().Id,
                Class = AnalogyLogClass.General,
                User = Environment.UserName,
                Date = DateTime.Now
            };
            messagesHandler.AppendMessage(m, Environment.MachineName);
            return new List<AnalogyLogMessage>() { m };
        }

        public IEnumerable<FileInfo> GetSupportedFiles(DirectoryInfo dirInfo, bool recursiveLoad)
        {
            return GetSupportedFilesInternal(dirInfo, recursiveLoad);
        }

        public Task SaveAsync(List<AnalogyLogMessage> messages, string fileName)
        {
            throw new NotSupportedException("Saving is not supported for evtx files");
        }

        public bool CanOpenFile(string fileName) => fileName.EndsWith(".evtx", StringComparison.InvariantCultureIgnoreCase);
        public bool CanOpenAllFiles(IEnumerable<string> fileNames) => fileNames.All(CanOpenFile);

        private static List<FileInfo> GetSupportedFilesInternal(DirectoryInfo dirInfo, bool recursive)
        {
            List<FileInfo> files = dirInfo.GetFiles("*.evtx").ToList();
            if (!recursive)
                return files;
            try
            {
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    files.AddRange(GetSupportedFilesInternal(dir, true));
                }
            }
            catch (Exception)
            {
                return files;
            }

            return files;
        }

    }
}
