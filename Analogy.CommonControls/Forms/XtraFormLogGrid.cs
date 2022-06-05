using System.Collections.Generic;
using System.Linq;
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
        public LogMessagesUC Window => _logMessagesUcLogs1;
        public XtraFormLogGrid(bool registerToAnalogyLogger)
        {
            InitializeComponent();
            _dataSource = "Analogy";
            _messages = new List<AnalogyLogMessage>();

        }
        public XtraFormLogGrid(IAnalogyOfflineDataProvider? fileDataProvider) : this(false)
        {
            FileDataProvider = fileDataProvider;
            _logMessagesUcLogs1.SetFileDataSource(FileDataProvider);
        }

        public XtraFormLogGrid(List<AnalogyLogMessage> messages, string dataSource, bool registerToAnalogyLogger) : this(registerToAnalogyLogger)
        {
            _messages = messages;
            _dataSource = dataSource;
        }


        public XtraFormLogGrid(List<AnalogyLogMessage> messages, string dataSource, IAnalogyOfflineDataProvider? fileProvider = null, string? processOrModule = null)
        {
            InitializeComponent();
            _messages = messages;
            _dataSource = dataSource;
            if (!string.IsNullOrEmpty(processOrModule))
            {
                _logMessagesUcLogs1.FilterResults(processOrModule!);
            }

            _logMessagesUcLogs1.SetFileDataSource(fileProvider);


        }

        private void Instance_OnNewMessage(object sender, (AnalogyLogMessage msg, string source) e)
        {
            _logMessagesUcLogs1.AppendMessage(e.msg, e.source);
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
                _logMessagesUcLogs1.AppendMessages(_messages, _dataSource);
            }
        }

        public void AppendMessage(AnalogyLogMessage message, string dataSource) =>
            _logMessagesUcLogs1.AppendMessage(message, dataSource);
        public void AppendMessages(List<AnalogyLogMessage> messages, string dataSource) =>
            _logMessagesUcLogs1.AppendMessages(messages, dataSource);

        private void XtraFormLogGrid_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
        }
    }
}