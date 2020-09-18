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
using System.Windows.Forms;
using Analogy.LogViewer.Template.IAnalogy;
using Analogy.Tools;

namespace Analogy.DataSources
{
    public class AnalogyBuiltInFactory : IAnalogyFactory
    {
        public static Guid AnalogyGuid { get; } = new Guid("D3047F5D-CFEB-4A69-8F10-AE5F4D3F2D04");
        public Guid FactoryId { get; set; } = AnalogyGuid;
        public string Title { get; set; } = "Analogy Logs Formats";
        public IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = CommonChangeLog.GetChangeLog();
        public Image LargeImage { get; set; } = Resources.Analogy_image_32x32;
        public Image SmallImage { get; set; } = Resources.Analogy_image_32x32;
        public IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public string About { get; set; } = "Analogy Built-in Data Source";

        public AnalogyBuiltInFactory()
        {
        }
    }

    public class AnalogyOfflineDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public Guid FactoryId { get; set; } = AnalogyBuiltInFactory.AnalogyGuid;
        public string Title { get; set; } = "Analogy Built-In Data Provider";
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
        public Guid Id { get; set; } = new Guid("A475EB76-2524-49D0-B931-E800CB358106");
        public bool CanSaveToLogFile { get; } = true;
        public string FileOpenDialogFilters { get; } = "All supported Analogy log file types|*.axml;*.ajson;*.abin|Plain Analogy XML log file (*.axml)|*.axml|Analogy JSON file (*.ajson)|*.ajson|Analogy MessagePack bin file (*.abin)|*.abin";
        public string FileSaveDialogFilters { get; } = "Analogy JSON file (*.ajson)|*.ajson|Analogy MessagePack bin file (*.abin)|*.abin";
        public IEnumerable<string> SupportFormats { get; } = new[] { "*.axml", "*.ajson", "*.abin" };
        public string InitialFolderFullPath { get; } = Environment.CurrentDirectory;
        public Image LargeImage { get; set; } = null;
        public Image SmallImage { get; set; } = null;
        public string OptionalTitle { get; set; } = "Analogy Built-In Offline Readers";
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
            if (fileName.EndsWith(".axml", StringComparison.InvariantCultureIgnoreCase))
            {
                AnalogyXmlLogFile logFile = new AnalogyXmlLogFile();
                var messages = await logFile.ReadFromFile(fileName, token, messagesHandler);
                return messages;
            }
            if (fileName.EndsWith(".ajson", StringComparison.InvariantCultureIgnoreCase))
            {
                AnalogyJsonLogFile logFile = new AnalogyJsonLogFile();
                var messages = await logFile.ReadFromFile(fileName, token, messagesHandler);
                return messages;
            }
            if (fileName.EndsWith(".abin", StringComparison.InvariantCultureIgnoreCase))
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
                    ProcessId = System.Diagnostics.Process.GetCurrentProcess().Id,
                    MachineName = Environment.MachineName,
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
                if (fileName.EndsWith(".ajson", StringComparison.InvariantCultureIgnoreCase))
                {
                    AnalogyJsonLogFile logFile = new AnalogyJsonLogFile();
                    await logFile.Save(messages, fileName);
                }
                else if (fileName.EndsWith(".abin", StringComparison.InvariantCultureIgnoreCase))
                {
                    AnalogyMessagePackFormat logFile = new AnalogyMessagePackFormat();
                    await logFile.Save(messages, fileName);
                }
            });

        public bool CanOpenFile(string fileName)

            => fileName.EndsWith(".axml", StringComparison.InvariantCultureIgnoreCase) ||
                fileName.EndsWith(".ajson", StringComparison.InvariantCultureIgnoreCase) ||
                fileName.EndsWith(".abin", StringComparison.InvariantCultureIgnoreCase);


        public bool CanOpenAllFiles(IEnumerable<string> fileNames) => fileNames.All(CanOpenFile);

        public IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);


        private static List<FileInfo> GetSupportedFilesInternal(DirectoryInfo dirInfo, bool recursive)
        {
            List<FileInfo> files = dirInfo.GetFiles("*.axml")
                .Concat(dirInfo.GetFiles("*.ajson"))
                .Concat(dirInfo.GetFiles("*.abin"))
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
        public Guid FactoryId { get; set; } = AnalogyBuiltInFactory.AnalogyGuid;
        public string Title { get; set; } = "Analogy Built-In tools";
        public IEnumerable<IAnalogyCustomAction> Actions { get; }

        public AnalogyCustomActionFactory()
        {
            Actions = new List<IAnalogyCustomAction> { new AnalogyCustomAction(), new AnalogyUnixTimeAction(), new AnalogyJsonViewerAction() };
        }
    }

    public class AnalogyCustomAction : IAnalogyCustomAction
    {
        public Action Action => () =>
        {
            var p = new ProcessNameAndID();
            p.Show();
        };
        public Guid Id { get; set; } = new Guid("8D24EC70-60C0-4823-BE9C-F4A59303FFB3");
        public Image SmallImage { get; set; } = Resources.ChartsShowLegend_16x16;
        public Image LargeImage { get; set; } = Resources.ChartsShowLegend_32x32;
        public string Title { get; set; } = "Process Identifier";
        public AnalogyCustomActionType Type { get; } = AnalogyCustomActionType.Global;
    }
    public class AnalogyUnixTimeAction : IAnalogyCustomAction
    {
        public Action Action => () =>
        {
            var p = new UnixTimeConverter();
            p.Show();
        };
        public Guid Id { get; set; } = new Guid("89173452-9C8E-4946-8C39-CAF2C8B6522D");
        public Image SmallImage { get; set; } = Resources.ChartsShowLegend_16x16;
        public Image LargeImage { get; set; } = Resources.ChartsShowLegend_32x32;

        public string Title { get; set; } = "Unix Time Converter";
        public AnalogyCustomActionType Type { get; } = AnalogyCustomActionType.Global;

    }

    public class AnalogyJsonViewerAction : IAnalogyCustomAction
    {
        public Action Action => () =>
        {
            var p = new JsonViewerForm();
            p.Show();
        };
        public Guid Id { get; set; } = new Guid("330b8471-c763-4579-a7e5-9efed71a56a5");
        public Image SmallImage { get; set; } = Resources.json16x16;
        public Image LargeImage { get; set; } = Resources.json32x32;

        public string Title { get; set; } = "Json object Visualizer";
        public AnalogyCustomActionType Type { get; } = AnalogyCustomActionType.Global;

    }


    public class AnalogyBuiltInImages : AnalogyImages
    {
    }
}

