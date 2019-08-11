using Philips.Analogy.Interfaces;
using System.Collections.Generic;

namespace Philips.Analogy
{
    public partial class XtraFormLogGrid : DevExpress.XtraEditors.XtraForm
    {
        private readonly List<AnalogyLogMessage> _messages;
        private readonly string _dataSource;

        public XtraFormLogGrid()
        {
            InitializeComponent();
        }

        public XtraFormLogGrid(List<AnalogyLogMessage> messages, string dataSource) : this()
        {
            _messages = messages;
            _dataSource = dataSource;
        }

        private void XtraFormLogGrid_Load(object sender, System.EventArgs e)
        {
            ucLogs1.AppendMessages(_messages, _dataSource);
        }
    }
}