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
        public XtraFormLogGrid(bool registerToAnalogyLogger)
        {
            this.ucLogs1 = new Analogy.CommonControls.UserControls.UCLogs();
            InitializeComponent();
            _dataSource = "Analogy";
            _messages = new List<AnalogyLogMessage>();
            FactoryContainer analogy = FactoriesManager.Instance.GetBuiltInFactoryContainer(AnalogyBuiltInFactory.AnalogyGuid);
            var analogyDataProvider = analogy.DataProvidersFactories.First().DataProviders.First();
            ucLogs1.SetFileDataSource(analogyDataProvider, null);

            if (registerToAnalogyLogger)
            {
                AnalogyLogManager.Instance.OnNewMessage += Instance_OnNewMessage;
            }
        }
        public XtraFormLogGrid(IAnalogyDataProvider? dataProvider, IAnalogyOfflineDataProvider? fileDataProvider) : this(false)
        {
            DataProvider = dataProvider;
            FileDataProvider = fileDataProvider;
            ucLogs1.SetFileDataSource(DataProvider, FileDataProvider);
        }

        public XtraFormLogGrid(List<AnalogyLogMessage> messages, string dataSource, bool registerToAnalogyLogger) : this(registerToAnalogyLogger)
        {
            _messages = messages;
            _dataSource = dataSource;
        }


        public XtraFormLogGrid(List<AnalogyLogMessage> messages, string dataSource, IAnalogyDataProvider dataProvider, IAnalogyOfflineDataProvider? fileProvider = null, string? processOrModule = null)
        {
            this.ucLogs1 = new Analogy.CommonControls.UserControls.UCLogs();
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
            Icon = UserSettingsManager.UserSettings.GetIcon();
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
            AnalogyLogManager.Instance.OnNewMessage -= Instance_OnNewMessage;
        }
    }
}