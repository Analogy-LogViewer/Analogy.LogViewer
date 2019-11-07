using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Analogy.LogLoaders;

namespace Analogy.DataProviders
{
    public class NLogDataProvider : IAnalogyOfflineDataProvider
    {
        public Guid ID { get; } = new Guid("4C002803-607F-4385-9C19-949FF1F29877");

        public bool CanSaveToLogFile { get; } = false;
        public string FileOpenDialogFilters { get; } = "Nlog files|*.log;*.nlog|NLog file (*.log)|*.log|NLog File (*.nlog)|*.nlog";
        public string FileSaveDialogFilters { get; } = string.Empty;
        public IEnumerable<string> SupportFormats { get; } = new[] { "*.nlog", "*.log" };
        public string InitialFolderFullPath { get; } = Environment.CurrentDirectory;

        private LogParserSettings LogParserSettings { get; set; }
        private NLogFileLoader nLogFileParser { get; set; }

        public void InitDataProvider()
        {
            LogParserSettings = UserSettingsManager.UserSettings.NLogSettings;
            nLogFileParser = new NLogFileLoader(LogParserSettings);
        }

        public async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
        {
            if (CanOpenFile(fileName))
                return await nLogFileParser.Process(fileName, token, messagesHandler);
            return new List<AnalogyLogMessage>(0);

        }

        public IEnumerable<FileInfo> GetSupportedFiles(DirectoryInfo dirInfo, bool recursiveLoad)
            => GetSupportedFilesInternal(dirInfo, recursiveLoad);

        public Task SaveAsync(List<AnalogyLogMessage> messages, string fileName)
        {
            throw new NotSupportedException("Saving is not supported for nlog");
        }

        public bool CanOpenFile(string fileName) =>
            fileName.EndsWith(".nlog", StringComparison.InvariantCultureIgnoreCase) ||
            fileName.EndsWith(".log", StringComparison.InvariantCultureIgnoreCase);


        public bool CanOpenAllFiles(IEnumerable<string> fileNames) => fileNames.All(CanOpenFile);

        public static List<FileInfo> GetSupportedFilesInternal(DirectoryInfo dirInfo, bool recursive)
        {
            List<FileInfo> files = dirInfo.GetFiles("*.log")
                .Concat(dirInfo.GetFiles("*.nlog"))
                .ToList();
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
