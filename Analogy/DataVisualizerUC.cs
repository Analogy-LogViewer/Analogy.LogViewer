using DevExpress.XtraCharts;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Philips.Analogy.Interfaces.DataTypes;

namespace Philips.Analogy
{
    public partial class DataVisualizerUC : DevExpress.XtraEditors.XtraUserControl
    {
        double XRange = 0;
        double YRange = 0;
        double CellSize = 0.5;
        private List<AnalogyLogMessage> Messages { get; set; }

        private List<string> Items { get; set; }
        private List<string> MessagesText { get; set; }

        public DataVisualizerUC()
        {
            Items = new List<string>();
            InitializeComponent();
        }

        public DataVisualizerUC(List<AnalogyLogMessage> messages) : this()
        {
            Messages = messages;
            MessagesText = Messages.Select(r => r.Text).ToList();
        }

        private void DataVisualizerUC_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                UpdateDataSource();
            }
        }

        private void Plot()
        {
            Dictionary<string, Dictionary<TimeSpan, int>> frequency = new Dictionary<string, Dictionary<TimeSpan, int>>();
            Dictionary<string, Dictionary<TimeSpan, int>> frequencyCount = new Dictionary<string, Dictionary<TimeSpan, int>>();
            foreach (var item in Items)
            {
                frequency.Add(item, new Dictionary<TimeSpan, int>());
                frequencyCount.Add(item, new Dictionary<TimeSpan, int>());
            }
            foreach (var m in Messages)
            {

                foreach (var item in Items)
                {
                    if (m.Text.Contains(item))
                    {
                        if (!frequency[item].ContainsKey(m.Date.TimeOfDay))
                        {
                            frequency[item].Add(m.Date.TimeOfDay, 1);
                        }

                        if (!frequencyCount[item].ContainsKey(m.Date.TimeOfDay))
                        {
                            frequencyCount[item].Add(m.Date.TimeOfDay, 1);
                        }
                        else
                        {
                            frequencyCount[item][m.Date.TimeOfDay] += 1;
                        }
                    }
                    else
                    {
                        if (!frequency[item].ContainsKey(m.Date.TimeOfDay))
                        {
                            frequency[item].Add(m.Date.TimeOfDay, 0);
                        }
                        if (!frequencyCount[item].ContainsKey(m.Date.TimeOfDay))
                        {
                            frequencyCount[item].Add(m.Date.TimeOfDay, 0);
                        }
                    }
                }
            }

            chartControlOnOff.Series.Clear();
            chartControlOnOff.DataSource = CreateTable(frequency);
            chartControlOnOff.SeriesDataMember = "Name";
            chartControlOnOff.SeriesTemplate.ArgumentDataMember = "Date";
            chartControlOnOff.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "ValueX" });

            chartControlOnOff.SeriesTemplate.ArgumentScaleType = ScaleType.DateTime;
            chartControlOnOff.SeriesTemplate.ChangeView(ViewType.Line);

            XYDiagram diagram = (XYDiagram)chartControlOnOff.Diagram;
            diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Millisecond;
            diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Hour;
            diagram.AxisX.Label.DateTimeOptions.Format = DateTimeFormat.ShortTime;

            chartControlFrequency.Series.Clear();
            chartControlFrequency.DataSource = CreateTable(frequencyCount);
            chartControlFrequency.SeriesDataMember = "Name";
            chartControlFrequency.SeriesTemplate.ArgumentDataMember = "Date";
            chartControlFrequency.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "ValueX" });

            chartControlFrequency.SeriesTemplate.ArgumentScaleType = ScaleType.DateTime;
            chartControlFrequency.SeriesTemplate.ChangeView(ViewType.Bar);

            XYDiagram diagram2 = (XYDiagram)chartControlFrequency.Diagram;
            diagram2.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Millisecond;
            diagram2.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Hour;
            diagram2.AxisX.Label.DateTimeOptions.Format = DateTimeFormat.ShortTime;
        }

        private DataTable CreateTable(Dictionary<string, Dictionary<TimeSpan, int>> data)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("Date", typeof(DateTime));
            tbl.Columns.Add("ValueX", typeof(int));
            tbl.Columns.Add("ValueY", typeof(int));

            foreach (KeyValuePair<string, Dictionary<TimeSpan, int>> freq in data)
            {
                string item = freq.Key;
                foreach (KeyValuePair<TimeSpan, int> val in freq.Value)
                {
                    tbl.Rows.Add(item, new DateTime(val.Key.Ticks), val.Value, val.Value);
                }

            }

            return tbl;
        }

        private void chklistItems_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            Items = chklistItems.CheckedItems.Cast<CheckedListBoxItem>().Select(i => i.Value.ToString()).ToList();
            Plot();

        }

        private void listBoxControl1_DoubleClick(object sender, EventArgs e)
        {
            textEdit1.Text = listBoxControl1.SelectedItem?.ToString();
        }

        private void sBtnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textEdit1.Text))
            {
                Items.Add(textEdit1.Text.Substring(textEdit1.Text.IndexOf(':') + 1));
                chklistItems.Items.Add(textEdit1.Text, true);
                Plot();
            }
        }

        private void nudTextLength_ValueChanged(object sender, EventArgs e)
        {
            UpdateDataSource();
        }

        private void UpdateDataSource()
        {
            listBoxControl1.DataSource = MessagesText
                .Select(t => t.Substring(0, Math.Min(t.Length, (int)nudTextLength.Value)))
                .GroupBy(i => i).OrderByDescending(i => i.Count()).Select(i => i.Count() + ":" + i.Key).ToList();
        }

        //private void PlotDensityZedGraph()
        //{
        //    GraphPane myPane = zedGraphPlot.GraphPane;
        //    myPane.XAxis.Type = AxisType.Date;
        //    myPane.XAxis.Scale.ScaleFormat = "mm:ss:fff";
        //    myPane.XAxis.ScaleFontSpec.Angle = 90;
        //    myPane.XAxis.ScaleFontSpec.Size = 12;
        //    myPane.XAxis.Scale.MajorUnit = DateUnit.Second;
        //    myPane.XAxis.Scale.MajorUnit = DateUnit.Hour;
        //    myPane.XAxis.Scale.MinorUnit = DateUnit.Second;
        //    myPane.XAxis.Scale.MinorStep = 250;
        //    int i = 0;
        //    foreach (KeyValuePair<string, Dictionary<TimeSpan, int>> freq in frequency)
        //    {
        //        var points = new PointPairList();
        //        string key = freq.Key;
        //        foreach (KeyValuePair<TimeSpan, int> val in freq.Value)
        //        {
        //            points.Add(new XDate(new DateTime(val.Key.Ticks)), val.Value);
        //        }

        //        CreatePlot(myPane, key, points, i++);
        //    }

        //}


        //private void PlotDensity()
        //{
        //    XRange = Messages.Count;
        //    var g = Messages.GroupBy(m => TimeSpan.FromTicks(m.Date.Ticks).TotalMilliseconds);

        //    YRange = g.Select(m => m.Count()).Max();
        //    foreach (var item in Items)
        //    {
        //        //Series series = new Series(item, ViewType.Line);
        //        //chartControl2.Series.Add(series);
        //        //List<SeriesPoint> points = new List<SeriesPoint>();
        //        //foreach (IGrouping<double, LogMessage> data in g)
        //        //{
        //        //    data.Key;
        //        //    for (var index = 0; index < data.Count(); index++)
        //        //    {
        //        //        LogMessage message = 
        //        //        int x = index;
        //        //        int y = message.Text.Contains(item) ? 100 : 0;
        //        //        points[index] = new SeriesPoint(message.Date, y);
        //        //    }
        //        //    series.Points.AddRange(points);
        //        //}
        //        SetUpAxis(Diagram.AxisX, XRange);
        //        SetUpAxis(Diagram.AxisY, YRange);
        //    }

        //    void SetUpAxis(Axis axis, double range)
        //    {
        //        axis.GridLines.Visible = true;
        //        axis.GridLines.MinorVisible = false;
        //        axis.Tickmarks.Visible = true;
        //        axis.Tickmarks.MinorVisible = false;
        //        axis.NumericScaleOptions.GridSpacing = CellSize;
        //        axis.WholeRange.SetMinMaxValues(0, range);
        //        axis.WholeRange.SideMarginsValue = 0;
        //    }

        //    void UpdateAnnotations(Series Series)
        //    {
        //        int xLength = (int) (XRange / CellSize);
        //        int yLength = (int) (YRange / CellSize);

        //        int[,] table = new int[xLength, yLength];
        //        for (int i = 0; i < Series.Points.Count; i++)
        //        {
        //            SeriesPoint point = Series.Points[i];
        //            int pointX = (int) (point.NumericalArgument / CellSize);
        //            int pointY = (int) (point.Values[0] / CellSize);
        //            table[pointX, pointY]++;
        //        }

        //        Diagram.DefaultPane.Annotations.Clear();

        //        for (int x = 0; x < xLength; x++)
        //        {
        //            for (int y = 0; y < yLength; y++)
        //            {
        //                if (table[x, y] > 0)
        //                    AddAnnotation(x, y, table[x, y]);
        //            }
        //        }
        //    }

        //    void AddAnnotation(int x, int y, int value)
        //    {
        //        TextAnnotation annotation = Diagram.DefaultPane.Annotations.AddTextAnnotation();
        //        annotation.Text = value.ToString();
        //        annotation.Border.Visibility = DefaultBoolean.False;
        //        annotation.BackColor = Color.FromArgb(100, Color.White);
        //        annotation.ShapeKind = ShapeKind.Rectangle;
        //        annotation.ConnectorStyle = AnnotationConnectorStyle.None;
        //        PaneAnchorPoint anchorPoint = new PaneAnchorPoint();
        //        anchorPoint.Pane = Diagram.DefaultPane;
        //        anchorPoint.AxisXCoordinate.AxisValue = x * CellSize;
        //        anchorPoint.AxisYCoordinate.AxisValue = (y + 1) * CellSize;
        //        annotation.AnchorPoint = anchorPoint;
        //        RelativePosition position = new RelativePosition();
        //        position.Angle = 315;
        //        position.ConnectorLength = 20;
        //        annotation.ShapePosition = position;
        //    }
        //}
    }
}
