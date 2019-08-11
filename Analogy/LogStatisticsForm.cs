using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Philips.Analogy
{
    public partial class LogStatisticsForm : XtraForm
    {
        public LogStatisticsForm()
        {
            InitializeComponent();
        }

        public LogStatisticsForm(LogStatistics statistics) : this()
        {
            LogStatisticsUC uc = new LogStatisticsUC(statistics);
            Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }
    }
}
