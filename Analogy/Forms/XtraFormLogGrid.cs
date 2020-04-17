using System.Collections.Generic;
using System.Linq;
using Analogy.DataSources;
using Analogy.Interfaces;
using Analogy.Managers;

namespace Analogy
{
    public partial class XtraFormLogGrid : DevExpress.XtraEditors.XtraForm
    {
        private readonly List<AnalogyLogMessage> _messages;
        private readonly string _dataSource;
        public XtraFormLogGrid()
        {
            InitializeComponent();
        }

        public XtraFormLogGrid(List<AnalogyLogMessage> messages, string dataSource,string processOrModule=null) : this()
        {
            _messages = messages;
            _dataSource = dataSource;
            if (!string.IsNullOrEmpty(processOrModule))
                ucLogs1.FilterResults(processOrModule);
            FactoryContainer analogy = FactoriesManager.Instance.GetBuiltInFactoryContainer(AnalogyBuiltInFactory.AnalogyGuid);
            var analogyDataProvider = analogy.DataProvidersFactories.First().DataProviders.First();
            ucLogs1.SetFileDataSource(analogyDataProvider, null);
        }

        private void XtraFormLogGrid_Load(object sender, System.EventArgs e)
        {
            if (DesignMode) return;

            ucLogs1.AppendMessages(_messages, _dataSource);
        }

        public void AppendMessage(AnalogyLogMessage message, string dataSource) =>
            ucLogs1.AppendMessage(message, dataSource);
        public void AppendMessages(List<AnalogyLogMessage> messages, string dataSource) =>
            ucLogs1.AppendMessages(messages, dataSource);

    }
}