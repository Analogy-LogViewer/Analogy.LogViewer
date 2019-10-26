using System.Collections.Generic;
using Analogy.Interfaces;

namespace Analogy
{
    public partial class XtraFormLogGrid : DevExpress.XtraEditors.XtraForm
    {
        private readonly List<AnalogyLogMessage> _messages;
        private readonly string _dataSource;
        private readonly string _processOrModule;
        public XtraFormLogGrid()
        {
            InitializeComponent();
        }

        public XtraFormLogGrid(List<AnalogyLogMessage> messages, string dataSource,string processOrModule=null) : this()
        {
            _processOrModule = processOrModule ??string.Empty;
            ucLogs1.SetProcessOrModuleFilter(_processOrModule);
            _messages = messages;
            _dataSource = dataSource;
        }

        private void XtraFormLogGrid_Load(object sender, System.EventArgs e)
        {
            ucLogs1.AppendMessages(_messages, _dataSource);
        }

        public void AppendMessage(AnalogyLogMessage message, string dataSource) =>
            ucLogs1.AppendMessage(message, dataSource);
        public void AppendMessages(List<AnalogyLogMessage> messages, string dataSource) =>
            ucLogs1.AppendMessages(messages, dataSource);

    }
}