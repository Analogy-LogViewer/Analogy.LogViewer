using Analogy.CommonControls.DataTypes;
using Analogy.CommonUtilities.Github;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using Octokit;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Analogy.UserControls
{
    public partial class DownloadStatisticsUC : XtraUserControl
    {
        private IReadOnlyList<Release> Releases { get; }
        private int TotalDownloadFramework;
        private int TotalDownloadNet;
        public DownloadStatisticsUC()
        {
            InitializeComponent();
        }
        public DownloadStatisticsUC(IReadOnlyList<Release> releases) : this()
        {
            Releases = releases;
            cbeReleases.Properties.BeginInit();
            cbeReleases.Properties.Items.AddRange(releases.Select(r => r.Name).ToArray());
            cbeReleases.Properties.EndInit();
        }

        private void DownloadStatisticsUC_Load(object sender, EventArgs e)
        {
            var net471 = Releases.Select(r => r.Assets.Where(a => a.Name.Contains("471", StringComparison.InvariantCultureIgnoreCase)));
            var net472 = Releases.Select(r => r.Assets.Where(a => a.Name.Contains("472", StringComparison.InvariantCultureIgnoreCase)));
            var net48 = Releases.Select(r => r.Assets.Where(a => a.Name.Contains("48", StringComparison.InvariantCultureIgnoreCase)));
            var net31 = Releases.Select(r => r.Assets.Where(a => a.Name.Contains("3.1", StringComparison.InvariantCultureIgnoreCase)));
            var net5 = Releases.Select(r => r.Assets.Where(a => a.Name.Contains("net5.0", StringComparison.InvariantCultureIgnoreCase)));
            var net6 = Releases.Select(r => r.Assets.Where(a => a.Name.Contains("net6.0", StringComparison.InvariantCultureIgnoreCase)));
            var net7 = Releases.Select(r => r.Assets.Where(a => a.Name.Contains("net7.0", StringComparison.InvariantCultureIgnoreCase)));
            var net8 = Releases.Select(r => r.Assets.Where(a => a.Name.Contains("net8.0", StringComparison.InvariantCultureIgnoreCase)));

            var net471Downloads = net471.Sum(r => r.Sum(a => a.DownloadCount));
            var net472Downloads = net472.Sum(r => r.Sum(a => a.DownloadCount));
            var net48Downloads = net48.Sum(r => r.Sum(a => a.DownloadCount));
            var net31Downloads = net31.Sum(r => r.Sum(a => a.DownloadCount));
            var net5Downloads = net5.Sum(r => r.Sum(a => a.DownloadCount));
            var net6Downloads = net6.Sum(r => r.Sum(a => a.DownloadCount));
            var net7Downloads = net7.Sum(r => r.Sum(a => a.DownloadCount));
            var net8Downloads = net8.Sum(r => r.Sum(a => a.DownloadCount));

            TotalDownloadFramework = net471Downloads + net472Downloads + net48Downloads;
            TotalDownloadNet = net31Downloads + net5Downloads + net6Downloads + net7Downloads + net8Downloads;
            var total = TotalDownloadFramework + TotalDownloadNet;
            lblTotal.Text = $"Total Downloads: {total}. Net Frameworks: {TotalDownloadFramework}. Net 3.1/5/6/7: {TotalDownloadNet}";
            var net471percentage = (double)net471Downloads / (total) * 100.0;
            var net472percentage = (double)net472Downloads / (total) * 100.0;
            var net48percentage = (double)net48Downloads / (total) * 100.0;
            var net31percentage = (double)net31Downloads / (total) * 100.0;
            var net5percentage = (double)net5Downloads / (total) * 100.0;
            var net6percentage = (double)net6Downloads / (total) * 100.0;
            var net7percentage = (double)net7Downloads / (total) * 100.0;
            var net8percentage = (double)net8Downloads / (total) * 100.0;
            List<PieChartSingleDataPoint> data = new()
            {
                new PieChartSingleDataPoint("NET Framework 471", net471Downloads),
                new PieChartSingleDataPoint("NET Framework 472", net472Downloads),
                new PieChartSingleDataPoint("NET Framework 48", net48Downloads),
                new PieChartSingleDataPoint("NETCORE 3.1", net31Downloads),
                new PieChartSingleDataPoint("NET 5", net5Downloads),
                new PieChartSingleDataPoint("NET 6", net6Downloads),
                new PieChartSingleDataPoint("NET 7", net7Downloads),
                new PieChartSingleDataPoint("NET 8", net8Downloads),
            };
            CreateChart(data);
        }

        private void CreateChart(List<PieChartSingleDataPoint> data)
        {
            var pieChart = new ChartControl();
            pieChart.AllowGesture = true;
            pieChart.Titles.Clear();
            pieChart.Titles.Add(new ChartTitle() { Text = "Download Statistics" });
            pieChart.Series.Clear();

            // Create a pie series. 
            Series series1 = new("Download Statistics", ViewType.Pie3D);

            // Bind the series to data. 
            series1.DataSource = data;
            series1.ArgumentDataMember = nameof(PieChartSingleDataPoint.Name);
            series1.ValueDataMembers.AddRange(nameof(PieChartSingleDataPoint.Value));

            // Add the series to the chart. 
            pieChart.Series.Add(series1);

            // Format the the series labels. 
            series1.Label.TextPattern = "{A}: {VP:p0} ({V})";

            // Format the series legend items. 
            series1.LegendTextPattern = "{A}";

            // Adjust the position of series labels.  
            ((PieSeriesLabel)series1.Label).Position = PieSeriesLabelPosition.TwoColumns;

            // Detect overlapping of series labels. 
            ((PieSeriesLabel)series1.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;

            // Access the view-type-specific options of the series. 
            Pie3DSeriesView myView = (Pie3DSeriesView)series1.View;

            // Specify a data filter to explode points. 
            //myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Value_1,
            //    DataFilterCondition.GreaterThanOrEqual, 9));
            //myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Argument,
            //    DataFilterCondition.NotEqual, "Others"));
            //myView.ExplodeMode = PieExplodeMode.UseFilters;
            myView.ExplodedDistancePercentage = 30;
            myView.ExplodeMode = PieExplodeMode.All;

            // Customize the legend. 
            pieChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

            // Add the chart to the form. 
            pieChart.Dock = DockStyle.Fill;
            panelChart.Controls.Clear();
            panelChart.Controls.Add(pieChart);
        }
        private void cbeReleases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbeReleases.SelectedIndex >= 0 && cbeReleases.SelectedIndex <= Releases.Count)
            {
                var release = Releases[cbeReleases.SelectedIndex];
                var net471 = release.Assets.Where(a => a.Name.Contains("471", StringComparison.InvariantCultureIgnoreCase));
                var net472 = release.Assets.Where(a => a.Name.Contains("472", StringComparison.InvariantCultureIgnoreCase));
                var net48 = release.Assets.Where(a => a.Name.Contains("48", StringComparison.InvariantCultureIgnoreCase));
                var net31 = release.Assets.Where(a => a.Name.Contains("3.1", StringComparison.InvariantCultureIgnoreCase));
                var net5 = release.Assets.Where(a => a.Name.Contains("net5.0", StringComparison.InvariantCultureIgnoreCase));
                var net6 = release.Assets.Where(a => a.Name.Contains("net6.0", StringComparison.InvariantCultureIgnoreCase));
                var net7 = release.Assets.Where(a => a.Name.Contains("net7.0", StringComparison.InvariantCultureIgnoreCase));

                var net471Downloads = net471.Sum(r => r.DownloadCount);
                var net472Downloads = net472.Sum(r => r.DownloadCount);
                var net48Downloads = net48.Sum(r => r.DownloadCount);
                var net31Downloads = net31.Sum(r => r.DownloadCount);
                var net5Downloads = net5.Sum(r => r.DownloadCount);
                var net6Downloads = net6.Sum(r => r.DownloadCount);
                var net7Downloads = net7.Sum(r => r.DownloadCount);

                var total = net471Downloads + net472Downloads + net48Downloads + net31Downloads + net5Downloads + net6Downloads + net7Downloads;
                lblTotal.Text = $"Total Downloads ({release.TagName}): {total}. Net Frameworks: {net471Downloads + net472Downloads + net48Downloads}. Net 3.1/5/6/7: {net31Downloads + net5Downloads + net6Downloads + net7Downloads}";
                List<PieChartSingleDataPoint> data = new()
            {
                new PieChartSingleDataPoint("NET Framework 471", net471Downloads),
                new PieChartSingleDataPoint("NET Framework 472", net472Downloads),
                new PieChartSingleDataPoint("NET Framework 48", net48Downloads),
                new PieChartSingleDataPoint("NETCORE 3.1", net31Downloads),
                new PieChartSingleDataPoint("NET 5", net5Downloads),
                new PieChartSingleDataPoint("NET 6", net6Downloads),
                new PieChartSingleDataPoint("NET 7", net7Downloads),
            };
                CreateChart(data);
            }
        }
    }
}