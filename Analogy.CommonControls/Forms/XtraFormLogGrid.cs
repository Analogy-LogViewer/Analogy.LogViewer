using System.Collections.Generic;
using System.Linq;
using Analogy.Common.Interfaces;
using Analogy.CommonControls.Interfaces;
using Analogy.CommonControls.LogLoaders;
using Analogy.CommonControls.UserControls;
using Analogy.Interfaces;
using DevExpress.XtraEditors;
using Microsoft.Extensions.Logging;

namespace Analogy.CommonControls.Forms
{
    public partial class XtraFormLogGrid : XtraForm
    {
        public IAnalogyDataProvider? DataProvider { get; set; }
        public IAnalogyOfflineDataProvider? FileDataProvider { get; set; }
        private readonly List<IAnalogyLogMessage> _messages;
        private readonly string _dataSource;
        public LogMessagesUC LogWindow => ucLogs1;
        public XtraFormLogGrid(IUserSettingsManager userSettingsManager, IExtensionsManager extensionManager, IFactoriesManager factoriesManager, ILogger logger)
        {
            ucLogs1 = new LogMessagesUC(userSettingsManager, extensionManager,factoriesManager, logger);
            InitializeComponent();
            Icon = userSettingsManager.GetIcon();
            _dataSource = "Analogy";
            _messages = new List<IAnalogyLogMessage>();
        }
        public XtraFormLogGrid(IUserSettingsManager userSettingsManager, IExtensionsManager extensionManager, IFactoriesManager factoriesManager,ILogger logger, IAnalogyDataProvider? dataProvider, IAnalogyOfflineDataProvider? fileDataProvider) : this(userSettingsManager, extensionManager,factoriesManager, logger)
        {
            DataProvider = dataProvider;
            FileDataProvider = fileDataProvider;
            ucLogs1.SetFileDataSource(DataProvider, FileDataProvider);
        }

        public XtraFormLogGrid(IUserSettingsManager userSettingsManager, IExtensionsManager extensionManager, IFactoriesManager factoriesManager, ILogger logger, List<IAnalogyLogMessage> messages, string dataSource) : this(userSettingsManager, extensionManager, factoriesManager,logger)
        {
            _messages = messages;
            _dataSource = dataSource;
        }


        public XtraFormLogGrid(IUserSettingsManager userSettingsManager, IExtensionsManager extensionManager, IFactoriesManager factoriesManager, ILogger logger, List<IAnalogyLogMessage> messages, string dataSource, IAnalogyDataProvider dataProvider, IAnalogyOfflineDataProvider? fileProvider = null, string? processOrModule = null) : this(userSettingsManager, extensionManager,factoriesManager, logger)
        {
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

        public void AppendMessage(IAnalogyLogMessage message, string dataSource) =>
            ucLogs1.AppendMessage(message, dataSource);
        public void AppendMessages(List<IAnalogyLogMessage> messages, string dataSource) =>
            ucLogs1.AppendMessages(messages, dataSource);

        private void XtraFormLogGrid_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
        }
    }
}