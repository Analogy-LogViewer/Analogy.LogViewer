using Analogy.CommonControls.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Analogy.CommonControls.Plotting
{
    public partial class PlottingUC : XtraUserControl
    {
        public event EventHandler<(string Name, bool IsChecked)> LegendItemChecked;
        public IAnalogyPlotting Plotter { get; }
        public AnalogyPlottingInteractor Interactor { get; }
        private PlottingDataManager Manager { get; set; }
        public PlotState PlotState { get; private set; }
        private Color SingleColor { get; set; }
        private bool UseSingleColor { get; set; }

        public PlottingUC()
        {
            PlotState = new PlotState() { ChartType = 0, ShowAll = true, ShowLegend = true, ShowChartControl = false };
            Manager = new PlottingDataManager();
            InitializeComponent();
            chartControl1.BeginInit();
            chartControl1.LegendItemChecked += OnLegendItemChecked;
            chartControl1.EndInit();
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

            SetState(PlotState, true);
            if (Interactor.WasSet)
            {
                nudWindow.Value = Interactor.WindowSize;
            }
            chartControl1.Titles.Add(new ChartTitle { Text = Plotter.Title });
            chartControl1.Legend.UseCheckBoxes = true;
            var type = Interactor.XAxisDataType;
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
                    ArgumentDataMember = type == AnalogyPlottingPointXAxisDataType.DateTime ? nameof(AnalogyPlottingPointData.DateTime) : nameof(AnalogyPlottingPointData.XAxisValue),
                };
                series.ValueDataMembers.AddRange(nameof(AnalogyPlottingPointData.Value));
                ((LineSeriesView)series.View).MarkerVisibility = DefaultBoolean.False;
                ((LineSeriesView)series.View).LineMarkerOptions.Kind = MarkerKind.Circle;
                ((LineSeriesView)series.View).LineStyle.DashStyle = DashStyle.Solid;
                if (UseSingleColor)
                {
                    ((LineSeriesView)series.View).Color = SingleColor;
                }
                chartControl1.Series.Add(series);
            }
            chartControl1.Legend.Visibility = DefaultBoolean.True;

            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            if (type == AnalogyPlottingPointXAxisDataType.DateTime)
            {
                diagram.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Automatic;
            }
            else
            {
                diagram.AxisX.NumericScaleOptions.ScaleMode = ScaleMode.Automatic;
            }

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

                //for (var i = 0; i < chartControl1.Series.Count; i++)
                //{
                //    Series s = chartControl1.Series[i];
                //    XYDiagramSeriesViewBase view = (XYDiagramSeriesViewBase)s.View;

                //    view.AxisX.Visibility = ((i + 1) < chartControl1.Series.Count) ? DefaultBoolean.False : DefaultBoolean.True;
                //}
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
            Plotter.OnNewPointsData += Plotter_OnNewPointsData;
            Manager.Start();
        }

        private void Plotter_OnNewPointsData(object sender, List<AnalogyPlottingPointData> pts)
        {
            Manager.AddPoints(pts);
        }

        private void Plotter_OnNewPointData(object sender, AnalogyPlottingPointData e)
        {
            Manager.AddPoint(e);
        }

        public void Stop()
        {
            Plotter.OnNewPointData -= Plotter_OnNewPointData;
            Plotter.OnNewPointsData -= Plotter_OnNewPointsData;
        }

        private void rbChartType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            PlotState.ChartType = rbChartType.SelectedIndex;
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
            using (SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "png file|*.png|jpeg file|*.jpeg" })
            {
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    ImageFormat imgFormat = ImageFormat.Bmp;
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 1:
                            imgFormat = ImageFormat.Png;
                            break;
                        case 2:
                            imgFormat = ImageFormat.Jpeg;
                            break;
                    }

                    SaveChartImageToFile(chartControl1, imgFormat, saveFileDialog.FileName);
                }
            }
        }

        private void OnLegendItemChecked(object sender, LegendItemCheckedEventArgs e)
        {
            if (e.CheckedElement is ConstantLine cl)
            {
                LegendItemChecked?.Invoke(this, (cl.Name, cl.CheckedInLegend));
            }
        }

        private void SaveChartImageToFile(ChartControl chart, ImageFormat format, string fileName)
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

        private void ceShowLegend_CheckedChanged(object sender, EventArgs e)
        {
            PlotState.ShowLegend = ceShowLegend.Checked;
            chartControl1.Legend.Visibility = ceShowLegend.Checked ? DefaultBoolean.True : DefaultBoolean.False;
        }

        private void ceShowHideAll_CheckedChanged(object sender, EventArgs e)
        {
            PlotState.ShowAll = ceShowHideAll.Checked;
            foreach (Series s in chartControl1.Series)
            {
                s.CheckedInLegend = ceShowHideAll.Checked;
            }
            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            if (diagram == null)
            {
                return;
            }

            foreach (ConstantLine line in diagram.AxisX.ConstantLines)
            {
                line.CheckedInLegend = ceShowHideAll.Checked;
            }
            foreach (ConstantLine line in diagram.AxisY.ConstantLines)
            {
                line.CheckedInLegend = ceShowHideAll.Checked;
            }
        }

        private void cePoints_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Series s in chartControl1.Series)
            {
                if (s.View is LineSeriesView line)
                {
                    line.MarkerVisibility = cePoints.Checked ? DevExpress.Utils.DefaultBoolean.True : DefaultBoolean.False;
                }
            }
        }

        public void SetState(PlotState newState, bool force)
        {
            if (PlotState.ChartType != newState.ChartType || force)
            {
                rbChartType.SelectedIndex = newState.ChartType;
            }

            if (PlotState.ShowLegend != newState.ShowLegend || force)
            {
                ceShowLegend.Checked = newState.ShowLegend;
            }

            if (PlotState.ShowAll != newState.ShowAll || force)
            {
                ceShowHideAll.Checked = newState.ShowAll;
            }

            if (PlotState.ShowChartControl != newState.ShowChartControl || force)
            {
                ShowHidePlotControls(newState.ShowChartControl);
            }
            PlotState = newState;
        }
        public void ResetData()
        {
            Manager.ClearAllData();
            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            if (diagram?.AxisX?.ConstantLines != null)
            {
                diagram.AxisX.ConstantLines.Clear();
            }

            chartControl1.Series.Clear();
            chartControl1.Legends.Clear();
        }

        public void ClearSeriesDataAndRemoveConstantLines()
        {
            Manager.ClearAllData();
            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            if (diagram?.AxisX?.ConstantLines != null)
            {
                diagram.AxisX.ConstantLines.Clear();
            }

            foreach (Series s in chartControl1.Series)
            {
                //    s.Points.Clear();
            }
        }
        public void AddConstantVerticalLine(string name, long timestamp, Color color, DashStyle dashLine, bool isChecked)
        {
            BeginInvoke(new MethodInvoker(() =>
             {
                 XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
                 ConstantLine line = new ConstantLine(name, timestamp);
                 line.Color = color;
                 line.LineStyle.Thickness = 4;
                 line.LineStyle.DashStyle = dashLine;
                 line.CheckedInLegend = isChecked;
                 diagram.AxisX.ConstantLines.Add(line);
             }));
        }
        public void AddConstantVerticalLine(string name, DateTime time, Color color, DashStyle dashLine, bool isChecked)
        {
            BeginInvoke(new MethodInvoker(() =>
            {
                XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
                ConstantLine line = new ConstantLine(name, time);
                line.Color = color;
                line.LineStyle.Thickness = 4;
                line.LineStyle.DashStyle = dashLine;
                line.CheckedInLegend = isChecked;
                diagram.AxisX.ConstantLines.Add(line);
            }));
        }
        public void ShowHidePlotControls(bool show)
        {
            PlotState.ShowChartControl = show;
            splitContainerControl1.PanelVisibility = show ? SplitPanelVisibility.Both : SplitPanelVisibility.Panel2;
        }

        public void ShowHideLegend(bool show)
        {
            ceShowLegend.Checked = show;
        }

        public void SetECGScaling()
        {
            var xyDiagram1 = (XYDiagram)chartControl1.Diagram;
            if (Interactor.XAxisDataType == AnalogyPlottingPointXAxisDataType.Numerical)
            {
                xyDiagram1.AxisX.NumericScaleOptions.ScaleMode = ScaleMode.Continuous;
                xyDiagram1.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Continuous;
                xyDiagram1.AxisX.NumericScaleOptions.AutoGrid = false;
                xyDiagram1.AxisX.NumericScaleOptions.GridAlignment = NumericGridAlignment.Ones;
                xyDiagram1.AxisX.NumericScaleOptions.GridSpacing = 200D;

                xyDiagram1.AxisX.DateTimeScaleOptions.AutoGrid = false;
                xyDiagram1.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Millisecond;
                xyDiagram1.AxisX.DateTimeScaleOptions.GridSpacing = 200D;
                xyDiagram1.AxisX.GridLines.LineStyle.Thickness = 3;
                xyDiagram1.AxisX.GridLines.MinorVisible = true;
                xyDiagram1.AxisX.GridLines.Visible = true;
                xyDiagram1.AxisX.WholeRange.AutoSideMargins = false;
                xyDiagram1.AxisX.WholeRange.EndSideMargin = 0D;
                xyDiagram1.AxisX.WholeRange.StartSideMargin = 0D;
            }
            else if (Interactor.XAxisDataType == AnalogyPlottingPointXAxisDataType.DateTime)
            {
                xyDiagram1.AxisX.DateTimeScaleOptions.ScaleMode = ScaleMode.Continuous;
                xyDiagram1.AxisX.DateTimeScaleOptions.AutoGrid = false;
                xyDiagram1.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Millisecond;
                xyDiagram1.AxisX.DateTimeScaleOptions.GridSpacing = 200D;
                xyDiagram1.AxisX.Label.TextPattern = "{A:HH:mm:ss.ff}";
                xyDiagram1.AxisX.GridLines.LineStyle.Thickness = 3;
                xyDiagram1.AxisX.GridLines.MinorVisible = true;
                xyDiagram1.AxisX.GridLines.Visible = true;

                xyDiagram1.AxisX.WholeRange.AutoSideMargins = false;
                xyDiagram1.AxisX.WholeRange.EndSideMargin = 0D;
                xyDiagram1.AxisX.WholeRange.StartSideMargin = 0D;
            }

            xyDiagram1.AxisX.MinorCount = 4;
            xyDiagram1.AxisY.MinorCount = 4;

            xyDiagram1.AxisY.NumericScaleOptions.AutoGrid = false;
            xyDiagram1.AxisY.NumericScaleOptions.GridAlignment = NumericGridAlignment.Custom;
            xyDiagram1.AxisY.NumericScaleOptions.CustomGridAlignment = 0.5D;

            xyDiagram1.AxisY.GridLines.LineStyle.Thickness = 3;
            xyDiagram1.AxisY.GridLines.MinorVisible = true;
            xyDiagram1.AxisY.Tickmarks.MinorVisible = false;

            xyDiagram1.AxisY.WholeRange.AlwaysShowZeroLevel = false;
            xyDiagram1.AxisY.WholeRange.AutoSideMargins = false;
            xyDiagram1.AxisY.WholeRange.EndSideMargin = 0D;
            xyDiagram1.AxisY.WholeRange.StartSideMargin = 0D;
        }

        public void SetDarkTheme(bool enable)
        {
            var skinName = enable ? "Office 2019 Black" : "DevExpress Style";
            chartControl1.LookAndFeel.SetSkinStyle(skinName);
        }

        public void SetDataColor(Color color)
        {
            UseSingleColor = true;
            SingleColor = color;
            for (int i = 0; i < chartControl1.Series.Count; i++)
            {
                if (chartControl1.Series[i].View is LineSeriesView ls)
                {
                    ls.Color = color;
                }
            }
        }
    }
}