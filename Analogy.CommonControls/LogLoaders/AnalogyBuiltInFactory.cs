using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Analogy.CommonControls.Properties;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.Template;
using Analogy.LogViewer.Template.IAnalogy;

namespace Analogy.CommonControls.LogLoaders
{
    public class AnalogyBuiltInFactory : PrimaryFactory
    {
        public static Guid AnalogyGuid { get; } = new Guid("D3047F5D-CFEB-4A69-8F10-AE5F4D3F2D04");
        public override Guid FactoryId { get; set; } = AnalogyGuid;
        public override string Title { get; set; } = "Analogy Logs Formats";
        public override IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = CommonControlChangeLog.GetChangeLog();
        public override Image? LargeImage { get; set; } = Resources.Analogy_image_32x32;
        public override Image? SmallImage { get; set; } = Resources.Analogy_image_16x16;
        public override IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public override string About { get; set; } = "Analogy Built-in Data Source";

    }

    public sealed class AnalogyOfflineDataProviderFactory : DataProvidersFactory
    {
        public override Guid FactoryId { get; set; } = AnalogyBuiltInFactory.AnalogyGuid;
        public override string Title { get; set; } = "Analogy Built-In Data Provider";
        public override IEnumerable<IAnalogyDataProvider> DataProviders { get; set; }

        public AnalogyOfflineDataProviderFactory()
        {
            var adp = new AnalogyOfflineDataProvider();
            DataProviders = new List<IAnalogyDataProvider> { adp };
        }
    }

    public class AnalogyOfflineDataProvider : OfflineDataProvider
    {
        public override Guid Id { get; set; } = new Guid("A475EB76-2524-49D0-B931-E800CB358106");
        public override bool CanSaveToLogFile { get; set; } = true;
        public override string FileOpenDialogFilters { get; set; } = "All supported Analogy log file types|*.axml;*.ajson;*.abin|Plain Analogy XML log file (*.axml)|*.axml|Analogy JSON file (*.ajson)|*.ajson|Analogy MessagePack bin file (*.abin)|*.abin";
        public override string FileSaveDialogFilters { get; set; } = "Analogy JSON file (*.ajson)|*.ajson|Analogy MessagePack bin file (*.abin)|*.abin";
        public override IEnumerable<string> SupportFormats { get; set; } = new[] { "*.axml", "*.ajson", "*.abin" };
        public override string? InitialFolderFullPath { get; set; } = Environment.CurrentDirectory;

        public override string? OptionalTitle { get; set; } = "Analogy Built-In Offline Readers";

        public override async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
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

        public override Task SaveAsync(List<AnalogyLogMessage> messages, string fileName)

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

        public override bool CanOpenFile(string fileName)

            => fileName.EndsWith(".axml", StringComparison.InvariantCultureIgnoreCase) ||
                fileName.EndsWith(".ajson", StringComparison.InvariantCultureIgnoreCase) ||
                fileName.EndsWith(".abin", StringComparison.InvariantCultureIgnoreCase);


        protected override List<FileInfo> GetSupportedFilesInternal(DirectoryInfo dirInfo, bool recursive)
        {
            List<FileInfo> files = dirInfo.GetFiles("*.axml")
                .Concat(dirInfo.GetFiles("*.ajson"))
                .Concat(dirInfo.GetFiles("*.abin"))
                .ToList();
            if (!recursive)
            {
                return files;
            }

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

