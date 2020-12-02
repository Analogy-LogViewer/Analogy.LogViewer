using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Managers;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;

namespace Analogy.UserControls
{
    public partial class PlottingUC : XtraUserControl
    {
        public IAnalogyPlotting? Plotter { get; }
        private PlottingManager Manager { get; set; }
        public PlottingUC()
        {
            Manager = new PlottingManager();
            InitializeComponent();
        }

        public PlottingUC(IAnalogyPlotting plotter) : this()
        {
            Plotter = plotter;
        }

        private void PlottingUC_Load(object sender, System.EventArgs e)
        {
            if (DesignMode || Plotter == null)
            {
                return;
            }
            chartControl1.Titles.Add(new ChartTitle { Text = Plotter.Title });

            foreach (var (seriesName, viewType) in Plotter.GetChartSeries())
            {
                PlottingGraphData data = new PlottingGraphData((float)nudRefreshInterval.Value, (int)nudWindow.Value);
                Manager.AddGraphData(seriesName, data);
                Series series = new Series(seriesName, (ViewType)viewType)
                {
                    DataSource = data.ViewportData,
                    DataSourceSorted = true,
                    ArgumentDataMember = nameof(AnalogyPlottingPointData.DateTime)
                };
                series.ValueDataMembers.AddRange(nameof(AnalogyPlottingPointData.Value));
                chartControl1.Series.Add(series);
            }
            chartControl1.Legend.Visibility = DefaultBoolean.True;

            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            diagram.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Continuous;
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
            diagram.AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
            // diagram.AxisX.VisualRange.EndSideMargin = 200;
            diagram.DependentAxesYRange = DefaultBoolean.True;
            diagram.AxisY.WholeRange.AlwaysShowZeroLevel = false;

        }

        public void Start()
        {
            Plotter.OnNewPointData += Plotter_OnNewPointData;
            Manager.Start();
        }

        private void Plotter_OnNewPointData(object sender, AnalogyPlottingPointData e)
        {
            Manager.AddPoint(e);
        }

        public void Stop()
        {
            Plotter.OnNewPointData -= Plotter_OnNewPointData;
        }

        private void nudRefreshInterval_ValueChanged(object sender, System.EventArgs e)
        {
            Manager.SetRefreshInterval((float) nudRefreshInterval.Value);
        }

        private void nudWindow_ValueChanged(object sender, System.EventArgs e)
        {
            Manager.SetDataWindow((int)nudWindow.Value);
        }
    }
}
