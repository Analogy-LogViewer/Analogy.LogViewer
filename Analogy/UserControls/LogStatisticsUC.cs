using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Analogy;


namespace Philips.Analogy
{
    public partial class LogStatisticsUC : UserControl
    {
        private LogStatistics Statistics { get; set; }
        private static Color[] colors;

        public LogStatisticsUC()
        {
            InitializeComponent();
            colors = new Color[]
            {
                Color.Aqua, Color.Blue, Color.Green, Color.Red, Color.Goldenrod, Color.Purple, Color.MediumPurple,
                Color.OrangeRed, Color.Fuchsia
            };

        }

        public LogStatisticsUC(LogStatistics statistics) : this() => Statistics = statistics;


        private void CreatePieGlobal()
        {
            //GraphPane global = zedGraphGlobal.GraphPane;
            //global.Title = "Messages distribution";
            //CreatePie(global, Statistics.CalculateGlobalStatistics());
            //// optional depending on whether you want labels within the graph legend
            //global.Legend.IsVisible = true;
            //zedGraphGlobal.AxisChange();
            //zedGraphGlobal.Invalidate();
        }
        //private void CreatePie(GraphPane graph, ItemStatistics entry)
        //{

        //    AddPie(graph, entry.Events, Color.AliceBlue, $"Events: {entry.Events}");
        //    AddPie(graph, entry.Critical, Color.Red, $"Critical: {entry.Critical}");
        //    AddPie(graph, entry.Errors, Color.PaleVioletRed, $"Errors: {entry.Errors}");
        //    AddPie(graph, entry.Debug, Color.SpringGreen, $"Debug: {entry.Debug}");
        //    AddPie(graph, entry.Warnings, Color.Yellow, $"Warnings: {entry.Warnings}");
        //    AddPie(graph, entry.Verbose, Color.Black, $"Verbose: {entry.Verbose}");
        //}

        //private void AddPie(GraphPane graph, int value, Color color, string legend)
        //{
        //    if (value > 0)
        //    {
        //        PieItem pie = graph.AddPieSlice(value, color, 0.1F, legend);
        //        pie.LabelType = PieLabelType.Name;
        //    }
        //}

        private void LogStatisticsUC_Load(object sender, System.EventArgs e)
        {
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            if (Statistics == null) return;
            CreatePieGlobal();
            PopulateGlobalDataGridView();
            PopulateSource();
            PopulateModule();
        }

        private void PopulateModule()
        {
            var modules = Statistics.CalculateModulesStatistics().OrderByDescending(s => s.TotalMessages).ToList();
            dgvModules.SelectionChanged -= dgvModules_SelectionChanged;
            dgvModules.DataSource = modules;
            dgvModules.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvModules.SelectionChanged += dgvModules_SelectionChanged;
        }

        private void PopulateSource()
        {
            var sources = Statistics.CalculateSourcesStatistics().OrderByDescending(s => s.TotalMessages).ToList();
            dgvSource.SelectionChanged -= dgvSource_SelectionChanged;
            dgvSource.DataSource = sources;
            dgvSource.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSource.SelectionChanged += dgvSource_SelectionChanged;
        }

        public void RefreshStatistics(LogStatistics statistics)
        {
            Statistics = statistics;
            LoadStatistics();
        }

        private void PopulateGlobalDataGridView()
        {
            ItemStatistics item = Statistics.CalculateGlobalStatistics();
            dgvTop.Rows.Add("Total messages:", item.TotalMessages);
            dgvTop.Rows.Add("Events:", item.Events);
            dgvTop.Rows.Add("Errors:", item.Errors);
            dgvTop.Rows.Add("Warnings:", item.Warnings);
            dgvTop.Rows.Add("Criticals:", item.Critical);
            dgvTop.Rows.Add("Debug:", item.Debug);
            dgvTop.Rows.Add("Verbose:", item.Verbose);

        }

        private void dgvSource_SelectionChanged(object sender, System.EventArgs e)
        {
            //if (dgvSource.SelectedRows.Count == 0) return;
            //var entry = dgvSource.SelectedRows[0].DataBoundItem as ItemStatistics;
            //if (entry != null)
            //{
            //    zedGraphSource.GraphPane.GraphItemList.Clear();
            //    GraphPane graph = zedGraphSource.GraphPane;
            //    graph.CurveList.Clear();
            //    graph.Title = $"statistics for {entry.Name}";
            //    AddPie(graph, entry.Events, Color.AliceBlue, $"Events: {entry.Events}");
            //    AddPie(graph, entry.Critical, Color.Red, $"Critical: {entry.Critical}");
            //    AddPie(graph, entry.Errors, Color.PaleVioletRed, $"Errors: {entry.Errors}");
            //    AddPie(graph, entry.Debug, Color.SpringGreen, $"Debug: {entry.Debug}");
            //    AddPie(graph, entry.Warnings, Color.Yellow, $"Warnings: {entry.Warnings}");
            //    AddPie(graph, entry.Verbose, Color.Black, $"Verbose: {entry.Verbose}");
            //    zedGraphSource.AxisChange();
            //    zedGraphSource.Invalidate();
            //    Refresh();
            //}
        }

        private void dgvSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvModules_SelectionChanged(object sender, System.EventArgs e)
        {
            //    if (dgvModules.SelectedRows.Count == 0) return;
            //    var entry = dgvModules.SelectedRows[0].DataBoundItem as ItemStatistics;
            //    if (entry != null)
            //    {
            //        zedGraphModules.GraphPane.GraphItemList.Clear();
            //        GraphPane graph = zedGraphModules.GraphPane;
            //        graph.CurveList.Clear();
            //        graph.Title = $"statistics for {entry.Name}";
            //        AddPie(graph, entry.Events, Color.AliceBlue, $"Events: {entry.Events}");
            //        AddPie(graph, entry.Critical, Color.Red, $"Critical: {entry.Critical}");
            //        AddPie(graph, entry.Errors, Color.PaleVioletRed, $"Errors: {entry.Errors}");
            //        AddPie(graph, entry.Debug, Color.SpringGreen, $"Debug: {entry.Debug}");
            //        AddPie(graph, entry.Warnings, Color.Yellow, $"Warnings: {entry.Warnings}");
            //        AddPie(graph, entry.Verbose, Color.Black, $"Verbose: {entry.Verbose}");
            //        zedGraphModules.AxisChange();
            //        zedGraphModules.Invalidate();
            //        Refresh();
            //    }
        }
    }
}
