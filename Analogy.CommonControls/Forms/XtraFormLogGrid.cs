using Analogy.Common.Interfaces;
using Analogy.CommonControls.Interfaces;
using Analogy.CommonControls.LogLoaders;
using Analogy.CommonControls.UserControls;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.WinForms;
using Analogy.Interfaces.WinForms;
using DevExpress.XtraEditors;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Analogy.CommonControls.Forms
{
    public partial class XtraFormLogGrid : XtraForm
    {
        public IAnalogyDataProviderWinForms? DataProvider { get; set; }
        public IAnalogyOfflineDataProviderWinForms? FileDataProvider { get; set; }
        private readonly List<IAnalogyLogMessage> _messages;
        private readonly string _dataSource;
        public LogMessagesUC LogWindow => ucLogs1;
        public XtraFormLogGrid(IUserSettingsManager userSettingsManager)
        {
            ucLogs1 = new LogMessagesUC();
            InitializeComponent();
            Icon = userSettingsManager.GetIcon();
            _dataSource = "Analogy";
            _messages = new List<IAnalogyLogMessage>();
        }
        public XtraFormLogGrid(IUserSettingsManager userSettingsManager, IAnalogyDataProviderWinForms? dataProvider, IAnalogyOfflineDataProviderWinForms? fileDataProvider) : this(userSettingsManager)
        {
            DataProvider = dataProvider;
            FileDataProvider = fileDataProvider;
            ucLogs1.SetFileDataSource(DataProvider, FileDataProvider);
        }

        public XtraFormLogGrid(IUserSettingsManager userSettingsManager, List<IAnalogyLogMessage> messages, string dataSource) : this(userSettingsManager)
        {
            _messages = messages;
            _dataSource = dataSource;
        }

        public XtraFormLogGrid(IUserSettingsManager userSettingsManager, List<IAnalogyLogMessage> messages, string dataSource, IAnalogyDataProviderWinForms dataProvider, IAnalogyOfflineDataProviderWinForms? fileProvider = null, string? processOrModule = null) : this(userSettingsManager)
        {
            _messages = messages;
            _dataSource = dataSource;
            if (!string.IsNullOrEmpty(processOrModule))
            {
                ucLogs1.FilterResults(processOrModule!);
            }

            ucLogs1.SetFileDataSource(dataProvider, fileProvider);
        }

        private void Instance_OnNewMessage(object sender, (AnalogyLogMessage Message, string Source) e)
        {
            ucLogs1.AppendMessage(e.Message, e.Source);
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