using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
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
        public AnalogyPlottingInteractor Interactor { get; }
        private PlottingDataManager Manager { get; set; }
        public PlottingUC()
        {
            Manager = new PlottingDataManager();
            InitializeComponent();
        }

        public PlottingUC(IAnalogyPlotting plotter, AnalogyPlottingInteractor interactor) : this()
        {
            Plotter = plotter;
            Interactor = interactor;
            interactor.WindowSpinEdit = nudWindow;
        }

        private void PlottingUC_Load(object sender, System.EventArgs e)
        {
            if (DesignMode || Plotter == null)
            {
                return;
            }

            if (Interactor.WasSet)
            {
                nudWindow.Value = Interactor.WindowSize;
            }
            chartControl1.Titles.Add(new ChartTitle { Text = Plotter.Title });
            chartControl1.Legend.UseCheckBoxes = true;
            foreach (var (seriesName, viewType) in Plotter.GetChartSeries())
            {
                PlottingGraphData data = new PlottingGraphData((float)nudRefreshInterval.Value, (int)nudWindow.Value);
                Manager.AddGraphData(seriesName, data);
                Series series = new Series(seriesName, (ViewType)viewType)
                {
                    CheckableInLegend = true,
                    CheckedInLegend = true,
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
            diagram.EnableAxisXZooming = true;
            diagram.EnableAxisYZooming = true;
            diagram.ZoomingOptions.UseKeyboard = true;
            diagram.ZoomingOptions.UseKeyboardWithMouse = true;
            diagram.ZoomingOptions.UseMouseWheel = true;
            diagram.ZoomingOptions.UseTouchDevice = true;
            diagram.EnableAxisXScrolling = true;
            diagram.EnableAxisYScrolling = true;
            diagram.ScrollingOptions.UseKeyboard = true;
            diagram.ScrollingOptions.UseMouse = true;
            diagram.ScrollingOptions.UseScrollBars = true;
            diagram.ScrollingOptions.UseTouchDevice = true;

            SetChartType();

        }

        private void SetChartType()
        {
            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            if (rbChartType.SelectedIndex == 0)
            {
                diagram.Panes.Clear();
                for (int i = 1; i < chartControl1.Series.Count; i++)
                {

                    XYDiagramSeriesViewBase view = (XYDiagramSeriesViewBase)chartControl1.Series[i].View;
                    view.Pane = diagram.DefaultPane;
                    chartControl1.Series[i].CheckedInLegend = true;
                    chartControl1.Series[i].CheckableInLegend = true;

                }
            }
            if (rbChartType.SelectedIndex > 0 && chartControl1.Series.Count > 0)
            {

                diagram.Panes.Clear();
                for (int i = 1; i < chartControl1.Series.Count; i++)
                {
                    XYDiagramPane pane = new XYDiagramPane($@"Pane {i}");
                    diagram.Panes.Add(pane);

                    XYDiagramSeriesViewBase view = (XYDiagramSeriesViewBase)chartControl1.Series[i].View;
                    view.Pane = pane;
                    chartControl1.Series[i].CheckedInLegend = true;
                    chartControl1.Series[i].CheckableInLegend = true;

                }
            }

            if (rbChartType.SelectedIndex == 1)
            {
                diagram.PaneLayout.Direction = PaneLayoutDirection.Vertical;
                diagram.PaneLayout.AutoLayoutMode = PaneAutoLayoutMode.Linear;
            }
            else if (rbChartType.SelectedIndex == 2)
            {
                diagram.PaneLayout.Direction = PaneLayoutDirection.Horizontal;
                diagram.PaneLayout.AutoLayoutMode = PaneAutoLayoutMode.Linear;
            }
            else if (rbChartType.SelectedIndex == 3)
            {
                diagram.PaneLayout.AutoLayoutMode = PaneAutoLayoutMode.Grid;
            }

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

        private void rbChartType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SetChartType();
        }

        private void nudWindow_EditValueChanged(object sender, System.EventArgs e)
        {
            Manager.SetDataWindow((int)nudWindow.Value);

        }

        private void nudRefreshInterval_EditValueChanged(object sender, System.EventArgs e)
        {
            Manager.SetRefreshInterval((float)nudRefreshInterval.Value);

        }

        private void sbtnSaveChart_Click(object sender, System.EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog {Filter = "png file|*.png|jpeg file|*.jpeg"};

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                ImageFormat imgFormat=ImageFormat.Bmp;
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        imgFormat=ImageFormat.Png;
                        break;
                    case 2:
                        imgFormat=ImageFormat.Jpeg;
                        break;
                }

                SaveChartImageToFile(chartControl1, imgFormat, saveFileDialog.FileName);
            }
        }


        private void SaveChartImageToFile(ChartControl chart, ImageFormat format, String fileName)
        {
            // Create an image in the specified format from the chart 
            // and save it to the specified path. 
            chart.ExportToImage(fileName, format);
        }

        private void sbtnCopyChart_Click(object sender, EventArgs e)
        {
            Image image = GetChartImage(chartControl1, ImageFormat.Png);
            Clipboard.SetImage(image);
            XtraMessageBox.Show("Chart was copied to clipboard");
        }
        private Image GetChartImage(ChartControl chart, ImageFormat format)
        {
            // Create an image. 
            Image image = null;

            // Create an image of the chart. 
            using (MemoryStream s = new MemoryStream())
            {
                chart.ExportToImage(s, format);
                image = Image.FromStream(s);
            }

            // Return the image. 
            return image;
        }
    }
}
