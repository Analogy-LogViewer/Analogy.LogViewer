using System.Collections.Generic;
using System.Linq;
using Analogy.CommonControls.Interfaces;
using Analogy.CommonControls.LogLoaders;
using Analogy.CommonControls.UserControls;
using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy.CommonControls.Forms
{
    public partial class XtraFormLogGrid : XtraForm
    {
        public IAnalogyDataProvider? DataProvider { get; set; }
        public IAnalogyOfflineDataProvider? FileDataProvider { get; set; }
        private readonly List<AnalogyLogMessage> _messages;
        private readonly string _dataSource;
        public UCLogs LogWindow => ucLogs1;
        public XtraFormLogGrid(IUserSettingsManager userSettingsManager, IExtensionsManager extensionManager, IAnalogyLogger logger)
        {
            ucLogs1 = new UCLogs(userSettingsManager, extensionManager, logger);
            InitializeComponent();
            Icon = userSettingsManager.GetIcon();
            _dataSource = "Analogy";
            _messages = new List<AnalogyLogMessage>();
        }
        public XtraFormLogGrid(IUserSettingsManager userSettingsManager, IExtensionsManager extensionManager, IAnalogyLogger logger, IAnalogyDataProvider? dataProvider, IAnalogyOfflineDataProvider? fileDataProvider) : this(userSettingsManager, extensionManager, logger)
        {
            DataProvider = dataProvider;
            FileDataProvider = fileDataProvider;
            ucLogs1.SetFileDataSource(DataProvider, FileDataProvider);
        }

        public XtraFormLogGrid(IUserSettingsManager userSettingsManager, IExtensionsManager extensionManager, IAnalogyLogger logger, List<AnalogyLogMessage> messages, string dataSource) : this(userSettingsManager, extensionManager, logger)
        {
            _messages = messages;
            _dataSource = dataSource;
        }


        public XtraFormLogGrid(IUserSettingsManager userSettingsManager, IExtensionsManager extensionManager, IAnalogyLogger logger, List<AnalogyLogMessage> messages, string dataSource, IAnalogyDataProvider dataProvider, IAnalogyOfflineDataProvider? fileProvider = null, string? processOrModule = null) : this(userSettingsManager, extensionManager, logger)
        {
            this.ucLogs1 = new UCLogs(userSettingsManager, extensionManager, logger);
            InitializeComponent();
            _messages = messages;
            _dataSource = dataSource;
            if (!string.IsNullOrEmpty(processOrModule))
            {
                ucLogs1.FilterResults(processOrModule!);
            }

            ucLogs1.SetFileDataSource(dataProvider, fileProvider);


        }

        private void Instance_OnNewMessage(object sender, (AnalogyLogMessage msg, string source) e)
        {
            ucLogs1.AppendMessage(e.msg, e.source);
        }
        private void XtraFormLogGrid_Load(object sender, System.EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            if (!_messages.Any())
            {
                return;
            }

            {
                ucLogs1.AppendMessages(_messages, _dataSource);
            }
        }

        public void AppendMessage(AnalogyLogMessage message, string dataSource) =>
            ucLogs1.AppendMessage(message, dataSource);
        public void AppendMessages(List<AnalogyLogMessage> messages, string dataSource) =>
            ucLogs1.AppendMessages(messages, dataSource);

        private void XtraFormLogGrid_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
        }
    }
}