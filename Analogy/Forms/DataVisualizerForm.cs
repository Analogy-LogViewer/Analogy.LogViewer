using Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Analogy
{
    public partial class DataVisualizerForm : DevExpress.XtraEditors.XtraForm
    {
        public DataVisualizerForm()
        {
            InitializeComponent();
        }
        public DataVisualizerForm(List<AnalogyLogMessage> messages) : this()
        {
            DataVisualizerUC uc = new DataVisualizerUC(messages);
            this.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
        private void DataVisualizerUCForm_Load(object sender, EventArgs e)
        {
            Icon = UserSettingsManager.UserSettings.GetIcon();
        }
    }
}