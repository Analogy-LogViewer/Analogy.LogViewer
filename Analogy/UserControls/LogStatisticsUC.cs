using Analogy;
using DevExpress.XtraEditors.Controls;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Analogy.DataTypes;


namespace Philips.Analogy
{
    public partial class LogStatisticsUC : UserControl
    {
        public LogStatistics? Statistics { get; set; }
        private PieChartUC? GlobalPie;
        private PieChartUC? SourcePie;
        private PieChartUC? ModulePie;
        private PieChartUC? FreeTextPie;
        public LogStatistics FreeTextStatistics { get; set; }

        public LogStatisticsUC()
        {
            InitializeComponent();
            SourcePie = new PieChartUC();
            spltcSources.Panel2.Controls.Add(SourcePie);
            SourcePie.Dock = DockStyle.Fill;
            GlobalPie = new PieChartUC();
            spltCTop.Panel2.Controls.Add(GlobalPie);
            GlobalPie.Dock = DockStyle.Fill;
            ModulePie = new PieChartUC();
            spltcModules.Panel2.Controls.Add(ModulePie);
            ModulePie.Dock = DockStyle.Fill;
            FreeTextPie = new PieChartUC();
            spltCFreeText.Panel2.Controls.Add(FreeTextPie);
            FreeTextPie.Dock = DockStyle.Fill;
        }



        private void LogStatisticsUC_Load(object sender, System.EventArgs e)
        {
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            if (Statistics == null)
            {
                return;
            }

            GlobalPie.SetDataSources(Statistics.CalculateGlobalStatistics());
            PopulateGlobalDataGridView();
            PopulateSource();
            PopulateModule();
            PopulateFreeText();
        }

        private void PopulateModule()
        {
            if (Statistics == null)
            {
                return;
            }
            var modules = Statistics.CalculateModulesStatistics().OrderByDescending(s => s.Messages).ToList();


            ModulePie.SetDataSources(modules.First());

            //dgvModules.SelectionChanged -= dgvModules_SelectionChanged;
            gridControlModules.DataSource = modules;
        }

        private void PopulateSource()
        {
            if (Statistics == null)
            {
                return;
            }
            var sources = Statistics.CalculateSourcesStatistics().OrderByDescending(s => s.Messages).ToList();


            if (!sources.Any())
            {
                return;
            }
            SourcePie.SetDataSources(sources.First());

            //            dgvSource.SelectionChanged -= dgvSource_SelectionChanged;
            GridControlSource.DataSource = sources;
            //  dgvSource.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dgvSource.SelectionChanged += dgvSource_SelectionChanged;

        }

        public void RefreshStatistics(LogStatistics statistics)
        {
            if (Statistics != null)
            {
                statistics.Texts = Statistics.Texts;
            }
            Statistics = statistics;
            LoadStatistics();
        }

        private void PopulateGlobalDataGridView()
        {
            if (Statistics == null)
            {
                return;
            }
            var items = Statistics.CalculateGlobalStatistics().AsList();
            gridControlGlobal.DataSource = items;


        }

        private void sBtnAdd_Click(object sender, System.EventArgs e)
        {
            if (Statistics == null)
            {
                return;
            }
            if (!string.IsNullOrEmpty(textEdit1.Text))
            {
                Statistics.AddText(textEdit1.Text);
                chklistItems.Items.Add(textEdit1.Text, true);

            }

            PopulateFreeText();
        }

        private void PopulateFreeText()
        {
            var items = Statistics.CalculateTextStatistics();
            gridControlFreeText.DataSource = items;
            FreeTextPie.SetDataSources("Free Text", Statistics.CalculateTextStatistics());
        }

        private void chklistItems_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (Statistics == null)
            {
                return;
            }
            var Items = chklistItems.CheckedItems.Cast<CheckedListBoxItem>().Select(i => i.Value.ToString()).ToList();
            Statistics.ClearTexts();
            foreach (string item in Items)
            {
                Statistics.AddText(item);
            }
            PopulateFreeText();
        }

        private void logGridSource_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0 && logGridSource.GetFocusedRow() is LogAnalyzerLogLevel logLevel)
            {
                SourcePie?.SetDataSources(logLevel);
            }
        }

        private void gridModules_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0 && gridModules.GetFocusedRow() is LogAnalyzerLogLevel logLevel)
            {
                ModulePie?.SetDataSources(logLevel);
            }
        }

        private void gridViewGlobal_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void gridViewFreeText_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }
    }
}

