using Analogy.CommonControls.Tools;
using Analogy.DataTypes;
using Analogy.Forms;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.WinForms;
using Analogy.Interfaces.WinForms.DataTypes;
using Analogy.LogLoaders;
using Analogy.LogViewer.Template;
using Analogy.LogViewer.Template.IAnalogy;
using Analogy.Properties;
using Analogy.Tools;
using Analogy.UserControls;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace Analogy.DataProviders
{
    public class AnalogyBuiltInFactory : PrimaryFactoryWinForms
    {
        public static Guid AnalogyGuid { get; } = new Guid("D3047F5D-CFEB-4A69-8F10-AE5F4D3F2D04");
        public override Guid FactoryId { get; set; } = AnalogyGuid;
        public override string Title { get; set; } = "Analogy Logs Formats";
        public override IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = CommonChangeLog.GetChangeLog();
        public override Image? LargeImage { get; set; } = Resources.Analogy_image_32x32;
        public override Image? SmallImage { get; set; } = Resources.Analogy_image_16x16;
        public override IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public override string About { get; set; } = "Analogy Built-in Data Source";

        public AnalogyBuiltInFactory()
        {
        }
    }

    public sealed class AnalogyOfflineDataProviderFactory : DataProvidersFactoryWinForms
    {
        public override Guid FactoryId { get; set; } = AnalogyBuiltInFactory.AnalogyGuid;
        public override string Title { get; set; } = "Analogy Built-In Data Provider";
        public override IEnumerable<IAnalogyDataProviderWinForms> DataProviders { get; set; }

        public AnalogyOfflineDataProviderFactory()
        {
            var adp = new AnalogyOfflineDataProvider();
            DataProviders = new List<IAnalogyDataProviderWinForms> { adp };
        }
    }

    public class AnalogyOfflineDataProvider : OfflineDataProviderWinForms
    {
        public override Guid Id { get; set; } = new Guid("A475EB76-2524-49D0-B931-E800CB358106");
        public override bool CanSaveToLogFile { get; set; } = true;
        public override string FileOpenDialogFilters { get; set; } = "All supported Analogy log file types|*.axml;*.ajson;*.abin|Plain Analogy XML log file (*.axml)|*.axml|Analogy JSON file (*.ajson)|*.ajson|Analogy MessagePack bin file (*.abin)|*.abin";
        public override string FileSaveDialogFilters { get; set; } = "Analogy JSON file (*.ajson)|*.ajson|Analogy MessagePack bin file (*.abin)|*.abin";
        public override IEnumerable<string> SupportFormats { get; set; } = new[] { "*.axml", "*.ajson", "*.abin" };
        public override string? InitialFolderFullPath { get; set; } = Environment.CurrentDirectory;

        public override string? OptionalTitle { get; set; } = "Analogy Built-In Offline Readers";

        public override async Task<IEnumerable<IAnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
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
                Date = DateTime.Now,
            };
            messagesHandler.AppendMessage(m, Environment.MachineName);
            return new List<AnalogyLogMessage>() { m };
        }

        public override Task SaveAsync(List<IAnalogyLogMessage> messages, string fileName)

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

    public class AnalogyCustomActionFactory : CustomActionsFactoryWinForms
    {
        public override Guid FactoryId { get; set; } = AnalogyBuiltInFactory.AnalogyGuid;
        public override string Title { get; set; } = "Analogy Built-In tools";
        public override IEnumerable<IAnalogyCustomActionWinForms> Actions { get; }

        public AnalogyCustomActionFactory()
        {
            Actions = new List<IAnalogyCustomActionWinForms>
            {
                new AnalogyCustomAction(),
                new AnalogyUnixTimeAction(),
                new AnalogyJsonViewerAction(),
                new AnalogyCompareTextAction(),
                new AnalogyGeoLocationAction(),
            };
        }
    }

    public class AnalogyCustomAction : IAnalogyCustomActionWinForms
    {
        public Action Action => () => new ProcessNameAndID().Show();

        public Guid Id { get; set; } = new Guid("8D24EC70-60C0-4823-BE9C-F4A59303FFB3");
        public Image? SmallImage { get; set; } = Resources.ChartsShowLegend_16x16;
        public Image? LargeImage { get; set; } = Resources.ChartsShowLegend_32x32;
        public string Title { get; set; } = "Process Identifier";
        public AnalogyCustomActionType Type { get; } = AnalogyCustomActionType.Global;
        AnalogyToolTip? IAnalogyCustomAction.ToolTip
        {
            get => ToolTip;
            set => ToolTip = value is AnalogyToolTipWinForms att ? att : null;
        }

        public AnalogyToolTipWinForms? ToolTip { get; set; }
    }
    public class AnalogyUnixTimeAction : IAnalogyCustomActionWinForms
    {
        private AnalogyToolTipWinForms? _toolTip;
        public Action Action => () => new UnixTimeConverter().Show();
        public Guid Id { get; set; } = new Guid("89173452-9C8E-4946-8C39-CAF2C8B6522D");
        public Image? SmallImage { get; set; } = Resources.ChartsShowLegend_16x16;
        public Image? LargeImage { get; set; } = Resources.ChartsShowLegend_32x32;

        public string Title { get; set; } = "Unix Time Converter";
        public AnalogyCustomActionType Type { get; } = AnalogyCustomActionType.Global;

        AnalogyToolTip? IAnalogyCustomAction.ToolTip
        {
            get => _toolTip;
            set => ToolTip = value is AnalogyToolTipWinForms att ? att : null;
        }

        public AnalogyToolTipWinForms? ToolTip { get; set; }
    }

    public class AnalogyJsonViewerAction : IAnalogyCustomActionWinForms
    {
        public Action Action => () => new JsonViewerForm(ServicesProvider.Instance.GetService<IAnalogyUserSettings>()).Show();
        public Guid Id { get; set; } = new Guid("330b8471-c763-4579-a7e5-9efed71a56a5");
        public Image? SmallImage { get; set; } = Resources.json16x16;
        public Image? LargeImage { get; set; } = Resources.json32x32;

        public string Title { get; set; } = "Json object Visualizer";
        public AnalogyCustomActionType Type { get; } = AnalogyCustomActionType.Global;
        AnalogyToolTip? IAnalogyCustomAction.ToolTip
        {
            get => ToolTip;
            set => ToolTip = value is AnalogyToolTipWinForms att ? att : null;
        }
        public AnalogyToolTipWinForms? ToolTip { get; set; }
    }

    public class AnalogyCompareTextAction : IAnalogyCustomActionWinForms
    {
        public Action Action => () => new CompareTextForm().Show();
        public Guid Id { get; set; } = new Guid("110b8471-c763-4579-a7e5-9efed71a56a5");
        public Image? SmallImage { get; set; } = Resources.Watermark_16x16;
        public Image? LargeImage { get; set; } = Resources.Watermark_32x32;

        public string Title { get; set; } = "Text Comparer";
        public AnalogyCustomActionType Type { get; } = AnalogyCustomActionType.Global;
        AnalogyToolTip? IAnalogyCustomAction.ToolTip
        {
            get => ToolTip;
            set => ToolTip = value is AnalogyToolTipWinForms att ? att : null;
        }
        public AnalogyToolTipWinForms? ToolTip { get; set; }
    }
    public class AnalogyBuiltInImages : AnalogyImages
    {
    }

    public class AnalogyGeoLocationAction : IAnalogyCustomActionWinForms
    {
        public Action Action => () => new GeoLocationForm().Show();
        public Guid Id { get; set; } = new Guid("10a0d408-d520-4471-8851-75e3bd0a8cc6");
        public Image? SmallImage { get; set; } = Resources.Watermark_16x16;
        public Image? LargeImage { get; set; } = Resources.Watermark_32x32;

        public string Title { get; set; } = "Geo Location Lookup";
        public AnalogyCustomActionType Type { get; } = AnalogyCustomActionType.Global;
        AnalogyToolTip? IAnalogyCustomAction.ToolTip
        {
            get => ToolTip;
            set => ToolTip = value is AnalogyToolTipWinForms att ? att : null;
        }

        public AnalogyToolTipWinForms? ToolTip { get; set; }
    }
}