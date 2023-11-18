using Analogy.Common.Interfaces;
using Analogy.CommonControls.UserControls;
using Analogy.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Analogy.CommonControls.Forms
{
    public partial class DataVisualizerForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IUserSettingsManager _settingsManager;
        private readonly DataVisualizerUC dataVisualizerUC;

        public DataVisualizerForm()
        {
            InitializeComponent();
        }
        public DataVisualizerForm(IUserSettingsManager settingsManager, Func<List<IAnalogyLogMessage>> messages, ILogger analogyLogger) : this()
        {
            _settingsManager = settingsManager;
            dataVisualizerUC = new DataVisualizerUC(_settingsManager, messages, analogyLogger);
            Controls.Add(dataVisualizerUC);
            dataVisualizerUC.Dock = DockStyle.Fill;
        }

        private void DataVisualizerUCForm_Load(object sender, EventArgs e)
        {
            Icon = _settingsManager.GetIcon();
        }

        public void AppendMessage(IAnalogyLogMessage message, string dataSource)
        {
            dataVisualizerUC?.AppendMessage(message, dataSource);
        }

        public void AppendMessages(List<IAnalogyLogMessage> messages, string dataSource)
        {
            dataVisualizerUC?.AppendMessages(messages, dataSource);
        }
    }
}