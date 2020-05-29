using Analogy.Forms;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogLoaders;
using Analogy.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.DataSources
{
    public class AnalogyBuiltInFactory : IAnalogyFactory
    {
        public static Guid AnalogyGuid { get; } = new Guid("D3047F5D-CFEB-4A69-8F10-AE5F4D3F2D04");
        public Guid FactoryId { get; } = AnalogyGuid;
        public string Title { get; } = "Analogy Logs Formats";
        public IEnumerable<IAnalogyChangeLog> ChangeLog => CommonChangeLog.GetChangeLog();
        public IEnumerable<string> Contributors { get; } = new List<string> { "Lior Banai" };
        public string About { get; } = "Analogy Built-in Data Source";

        public AnalogyBuiltInFactory()
        {
        }
    }

    public class AnalogyOfflineDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public Guid FactoryId { get; } = AnalogyBuiltInFactory.AnalogyGuid;
        public string Title { get; } = "Analogy Built-In Data Provider";
        public IEnumerable<IAnalogyDataProvider> DataProviders { get; }

        public AnalogyOfflineDataProviderFactory()
        {
            var builtInItems = new List<IAnalogyDataProvider>();
            var adp = new AnalogyOfflineDataProvider();
            builtInItems.Add(adp);
            adp.InitializeDataProviderAsync(AnalogyLogger.Instance);
            DataProviders = builtInItems;
        }
    }

    public class AnalogyOfflineDataProvider : IAnalogyOfflineDataProvider
    {
        public Guid ID { get; } = new Guid("A475EB76-2524-49D0-B931-E800CB358106");
        public bool CanSaveToLogFile { get; } = true;
        public string FileOpenDialogFilters { get; } = "All supported Analogy log file types|*.xml;*.json;*.bin|Plain Analogy XML log file (*.xml)|*.xml|Analogy JSON file (*.json)|*.json|Analogy MessagePack bin file (*.bin)|*.bin";
        public string FileSaveDialogFilters { get; } = "Plain Analogy XML log file (*.xml)|*.xml|Analogy JSON file (*.json)|*.json|Analogy MessagePack bin file (*.bin)|*.bin";
        public IEnumerable<string> SupportFormats { get; } = new[] { "*.xml", "*.json" };
        public string InitialFolderFullPath { get; } = Environment.CurrentDirectory;
        public string OptionalTitle { get; } = "Analogy Built-In Offline Readers";
        public bool UseCustomColors { get; set; } = false;
        public bool DisableFilePoolingOption { get; } = false;

        public Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            return Task.CompletedTask;
        }

        public void MessageOpened(AnalogyLogMessage message)
        {
            //nop
        }

        public async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
        {
            if (fileName.EndsWith(".xml", StringComparison.InvariantCultureIgnoreCase))
            {
                AnalogyXmlLogFile logFile = new AnalogyXmlLogFile();
                var messages = await logFile.ReadFromFile(fileName, token, messagesHandler);
                return messages;
            }
            if (fileName.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase))
            {
                AnalogyJsonLogFile logFile = new AnalogyJsonLogFile();
                var messages = await logFile.ReadFromFile(fileName, token, messagesHandler);
                return messages;
            }
            if (fileName.EndsWith(".bin", StringComparison.InvariantCultureIgnoreCase))
            {
                AnalogyMessagePackFormat logFile = new AnalogyMessagePackFormat();
                var messages = await logFile.ReadFromFile(fileName, token, messagesHandler);
                return messages;
            }
            else
            {
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
        }

        public IEnumerable<FileInfo> GetSupportedFiles(DirectoryInfo dirInfo, bool recursiveLoad)
        => GetSupportedFilesInternal(dirInfo, recursiveLoad);

        public Task SaveAsync(List<AnalogyLogMessage> messages, string fileName)

            => Task.Factory.StartNew(async () =>
            {

                if (fileName.EndsWith(".xml", StringComparison.InvariantCultureIgnoreCase))
                {
                    AnalogyXmlLogFile logFile = new AnalogyXmlLogFile();
                    await logFile.Save(messages, fileName);

                }
                else if (fileName.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase))
                {
                    AnalogyJsonLogFile logFile = new AnalogyJsonLogFile();
                    await logFile.Save(messages, fileName);
                }
                else if (fileName.EndsWith(".bin", StringComparison.InvariantCultureIgnoreCase))
                {
                    AnalogyMessagePackFormat logFile = new AnalogyMessagePackFormat();
                    await logFile.Save(messages, fileName);
                }
            });

        public bool CanOpenFile(string fileName)

            => fileName.EndsWith(".xml", StringComparison.InvariantCultureIgnoreCase) ||
                fileName.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase) ||
                fileName.EndsWith(".bin", StringComparison.InvariantCultureIgnoreCase);


        public bool CanOpenAllFiles(IEnumerable<string> fileNames) => fileNames.All(CanOpenFile);

        public IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);


        private static List<FileInfo> GetSupportedFilesInternal(DirectoryInfo dirInfo, bool recursive)
        {
            List<FileInfo> files = dirInfo.GetFiles("*.xml")
                .Concat(dirInfo.GetFiles("*.json"))
                .Concat(dirInfo.GetFiles("*.bin"))
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

    public class AnalogyCustomActionFactory : IAnalogyCustomActionsFactory
    {
        public Guid FactoryId { get; } = AnalogyBuiltInFactory.AnalogyGuid;
        public string Title { get; } = "Analogy Built-In tools";
        public IEnumerable<IAnalogyCustomAction> Actions { get; }

        public AnalogyCustomActionFactory()
        {
            Actions = new List<IAnalogyCustomAction> { new AnalogyCustomAction(), new AnalogyUnixTimeAction() };
        }
    }

    public class AnalogyCustomAction : IAnalogyCustomAction
    {
        public Action Action => () =>
        {
            var p = new ProcessNameAndID();
            p.Show();
        };
        public Guid ID { get; } = new Guid("8D24EC70-60C0-4823-BE9C-F4A59303FFB3");
        public Image Image { get; } = Resources.ChartsShowLegend_32x32;
        public string Title { get; } = "Process Identifier";

    }
    public class AnalogyUnixTimeAction : IAnalogyCustomAction
    {
        public Action Action => () =>
        {
            var p = new UnixTimeConverter();
            p.Show();
        };
        public Guid ID { get; } = new Guid("89173452-9C8E-4946-8C39-CAF2C8B6522D");
        public Image Image { get; } = Resources.ChartsShowLegend_32x32;
        public string Title { get; } = "Unix Time Converter";

    }
}

