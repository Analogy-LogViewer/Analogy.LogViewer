using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        public string Title { get; } = "Analogy Built-in Logs";
        public IAnalogyDataProvidersFactory DataProviders { get; }
        public IAnalogyCustomActionsFactory Actions { get; }
        public IEnumerable<IAnalogyChangeLog> ChangeLog => GetChangeLog();
        public IEnumerable<string> Contributors { get; } = new List<string> { "Lior Banai" };
        public string About { get; } = "Analogy Built-in Data Source";
        public AnalogyBuiltInFactory()
        {
            DataProviders = new AnalogyOfflineDataProviderFactory();
            Actions = new AnalogyCustomActionFactory();

        }

        private IEnumerable<AnalogyChangeLog> GetChangeLog()
        {
            yield return new AnalogyChangeLog("adding .net Core 3.0 Target", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 10, 26));
            yield return new AnalogyChangeLog("Offline files: Add option for file pooling. (issue #36)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 10, 24));
            yield return new AnalogyChangeLog("cleanup old namespaces (issue #34)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 10, 18));
            yield return new AnalogyChangeLog("frameworks update: interface dll is not target .net standard 2.0 and Analogy UI is .net framework 4.7.2 (issues #32,#33)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 10, 18));
            yield return new AnalogyChangeLog("UI: not all UI elements support themes (issue #28)", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 10, 14));
            yield return new AnalogyChangeLog("UI: Add an option (user setting) to auto scroll to last message (Issue #26)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 10, 13));
            yield return new AnalogyChangeLog("Fix: DevExpress Control: Sometimes an error occurs and the grid displays a big red X (Issue #4)", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 10, 11));
            yield return new AnalogyChangeLog("UI: Add fast file caching switching (Issue #23)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 10, 11));
            yield return new AnalogyChangeLog("UI: Add more information about messages in the Message's detail window (Issue #22)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 10, 09));
            yield return new AnalogyChangeLog("Fix: Online Data Providers are not disposed during shutdown of Analogy (Issue #21)", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 10, 09));
            yield return new AnalogyChangeLog("Fix: Folder loading is ignoring data source supported files (Issue #18)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 09, 26));
            yield return new AnalogyChangeLog("Add an option to un-dock current view and keep receiving new messages (Issue #16)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 09, 25));
            yield return new AnalogyChangeLog("duplicate chrome tab behavior (close tab keyboard shortcut, close all other tabs, etc) (Issue #8)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 09, 24));
            yield return new AnalogyChangeLog("remove Auto Start value form the interface and make it UI option", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 09, 21));
            yield return new AnalogyChangeLog("Startup data sources: add a user setting to define list of startup data sources (Issue #10)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 09, 21));
            yield return new AnalogyChangeLog("Windows Event logs: add support for custom logs in addition to Windows logs (Issue #7)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 09, 20));
            yield return new AnalogyChangeLog("user settings are not saved between different versions (Issue #13)", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 09, 20));
            yield return new AnalogyChangeLog("Add resource usage indication and idle mode (Issue #6)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 09, 20));
            yield return new AnalogyChangeLog("Fix unable to save logs for real time Data sources", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 09, 09));
            yield return new AnalogyChangeLog("Add more information in the offline files listing.", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 08, 31));
            yield return new AnalogyChangeLog("Fix about Page loading.", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 08, 30));
            yield return new AnalogyChangeLog("First release as open source tool.", AnalogChangeLogType.Feature, "Lior Banai", new DateTime(2019, 08, 19));
        }
    }

    public class AnalogyOfflineDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public string Title { get; } = "Analogy Built-In Data Sources";
        public IEnumerable<IAnalogyDataProvider> Items { get; }

        public AnalogyOfflineDataProviderFactory()
        {
            Items = new List<IAnalogyDataProvider> { new AnalogyOfflineDataProvider() };
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
        public Image OptionalOpenFolderImage { get; }
        public Image OptionalOpenFilesImage { get; }
        public void InitDataProvider()
        {

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
            Items = new List<IAnalogyCustomAction>() { new AnalogyCustomAction() };
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
}

