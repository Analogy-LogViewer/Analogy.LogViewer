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
    public class AnalogyBuiltInFactory : IAnalogyFactory
    {
        public static Guid AnalogyGuid { get; } = new Guid("D3047F5D-CFEB-4A69-8F10-AE5F4D3F2D04");
        public Guid FactoryID { get; } = AnalogyGuid;
        public string Title { get; } = "Analogy Logs Formats";
        public IAnalogyDataProvidersFactory DataProviders { get; }
        public IAnalogyCustomActionsFactory Actions { get; }
        public IEnumerable<IAnalogyChangeLog> ChangeLog => CommonChangeLog.GetChangeLog();
        public IEnumerable<string> Contributors { get; } = new List<string> { "Lior Banai" };
        public string About { get; } = "Analogy Built-in Data Source";
        public AnalogyBuiltInFactory()
        {
            DataProviders = new AnalogyOfflineDataProviderFactory();
            Actions = new AnalogyCustomActionFactory();

        }

    }

    public class AnalogyOfflineDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public string Title { get; } = "Analogy Built-In Data Provider";
        public IEnumerable<IAnalogyDataProvider> Items { get; }

        public AnalogyOfflineDataProviderFactory()
        {
            var builtInItems = new List<IAnalogyDataProvider>();
            var adp = new AnalogyOfflineDataProvider();
            builtInItems.Add(adp);
            adp.InitializeDataProviderAsync(AnalogyLogger.Intance);
            Items = builtInItems;
        }
    }

    public class AnalogyOfflineDataProvider : IAnalogyOfflineDataProvider
    {
        public Guid ID { get; } = new Guid("A475EB76-2524-49D0-B931-E800CB358106");

        public bool CanSaveToLogFile { get; } = true;
        public string FileOpenDialogFilters { get; } = "All supported Analogy log file types|*.log;*.json|Plain Analogy XML log file (*.log)|*.log|Analogy JSON file (*.json)|*.json";
        public string FileSaveDialogFilters { get; } = "Plain Analogy XML log file (*.log)|*.log|Analogy JSON file (*.json)|*.json";
        public IEnumerable<string> SupportFormats { get; } = new[] { "*.log", "*.json" };
        public string InitialFolderFullPath { get; } = Environment.CurrentDirectory;
        public string OptionalTitle { get; } = "Analogy Built-In Offline Readers";
        public Image OptionalOpenFolderImage { get; }
        public Image OptionalOpenFilesImage { get; }

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
            if (fileName.EndsWith(".log", StringComparison.InvariantCultureIgnoreCase))
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

                if (fileName.EndsWith(".log", StringComparison.InvariantCultureIgnoreCase))
                {
                    AnalogyXmlLogFile logFile = new AnalogyXmlLogFile();
                    await logFile.Save(messages, fileName);

                }
                if (fileName.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase))
                {
                    AnalogyJsonLogFile logFile = new AnalogyJsonLogFile();
                    await logFile.Save(messages, fileName);

                }
            });

        public bool CanOpenFile(string fileName)

            => fileName.EndsWith(".log", StringComparison.InvariantCultureIgnoreCase) ||
                fileName.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase);


        public bool CanOpenAllFiles(IEnumerable<string> fileNames) => fileNames.All(CanOpenFile);

        public static List<FileInfo> GetSupportedFilesInternal(DirectoryInfo dirInfo, bool recursive)
        {
            List<FileInfo> files = dirInfo.GetFiles("*.log")
                .Concat(dirInfo.GetFiles("*.json"))
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
        public string Title { get; } = "Analogy Built-In tools";
        public IEnumerable<IAnalogyCustomAction> Items { get; }

        public AnalogyCustomActionFactory()
        {
            Items = new List<IAnalogyCustomAction>() { new AnalogyCustomAction()/*,new AnalogyDataProvidersCustomAction()*/ };
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
    public class AnalogyDataProvidersCustomAction : IAnalogyCustomAction
    {
        public Action Action => () =>
        {
            var p = new UserSettingsDataProvidersForm();
            p.Show();
        };
        public Guid ID { get; } = new Guid("8398FD33-78D0-4F07-B50C-13B922DC64B4");
        public Image Image { get; } = Resources.ChartsShowLegend_32x32;
        public string Title { get; } = "data providers settings";

    }
}

