using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Analogy.Common.Interfaces;
using Analogy.CommonControls.Interfaces;
using Analogy.CommonControls.UserControls;
using Analogy.Interfaces;

namespace Analogy.CommonControls.Forms
{
    public partial class DataVisualizerForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IUserSettingsManager _settingsManager;

        public DataVisualizerForm()
        {
            InitializeComponent();
        }
        public DataVisualizerForm(IUserSettingsManager settingsManager, Func<List<IAnalogyLogMessage>> messages, IAnalogyLogger analogyLogger) : this()
        {
            _settingsManager = settingsManager;
            DataVisualizerUC uc = new DataVisualizerUC(_settingsManager, messages, analogyLogger);
            this.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
        public DataVisualizerForm(List<IAnalogyLogMessage> messages, IAnalogyLogger analogyLogger) : this()
        {
            DataVisualizerUC uc = new DataVisualizerUC(_settingsManager, messages, analogyLogger);
            this.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
        private void DataVisualizerUCForm_Load(object sender, EventArgs e)
        {
            Icon = _settingsManager.GetIcon();
        }
    }
}