﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.CommonControls.DataTypes;
using Analogy.CommonUtilities.Web;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;

namespace Analogy.UserControls
{
    public partial class DownloadStatisticsUC : XtraUserControl
    {
        private GithubObjects.GithubReleaseEntry[] Releases { get; }

        public DownloadStatisticsUC()
        {
            InitializeComponent();
        }
        public DownloadStatisticsUC(GithubObjects.GithubReleaseEntry[] releases) : this()
        {
            Releases = releases;
        }

        private void DownloadStatisticsUC_Load(object sender, EventArgs e)
        {
            var net471 = Releases.Select(r => r.Assets.Where(a => a.Name.Contains("471", StringComparison.InvariantCultureIgnoreCase)));
            var net472 = Releases.Select(r => r.Assets.Where(a => a.Name.Contains("472", StringComparison.InvariantCultureIgnoreCase)));
            var net48 = Releases.Select(r => r.Assets.Where(a => a.Name.Contains("48", StringComparison.InvariantCultureIgnoreCase)));
            var net31 = Releases.Select(r => r.Assets.Where(a => a.Name.Contains("3.1", StringComparison.InvariantCultureIgnoreCase)));
            var net5 = Releases.Select(r => r.Assets.Where(a => a.Name.Contains("net5.0", StringComparison.InvariantCultureIgnoreCase)));
            var net6 = Releases.Select(r => r.Assets.Where(a => a.Name.Contains("net6.0", StringComparison.InvariantCultureIgnoreCase)));

            var net471Downloads = net471.Sum(r => r.Sum(a => a.Downloads));
            var net472Downloads = net472.Sum(r => r.Sum(a => a.Downloads));
            var net48Downloads = net48.Sum(r => r.Sum(a => a.Downloads));
            var net31Downloads = net31.Sum(r => r.Sum(a => a.Downloads));
            var net5Downloads = net5.Sum(r => r.Sum(a => a.Downloads));
            var net6Downloads = net6.Sum(r => r.Sum(a => a.Downloads));
            var total = net471Downloads + net472Downloads + net48Downloads + net31Downloads + net5Downloads + net6Downloads;
            lblTotal.Text = $"Total Downloads: {total}. Net Frameworks: {net471Downloads + net472Downloads + net48Downloads}. Net 3.1/5/6: {net31Downloads + net5Downloads + net6Downloads}";
            var net471percentage = (double)net471Downloads / (net471Downloads + net472Downloads + net48Downloads + net31Downloads + net5Downloads + net6Downloads) * 100.0;
            var net472percentage = (double)net472Downloads / (net471Downloads + net472Downloads + net48Downloads + net31Downloads + net5Downloads + net6Downloads) * 100.0;
            var net48percentage = (double)net48Downloads / (net471Downloads + net472Downloads + net48Downloads + net31Downloads + net5Downloads + net6Downloads) * 100.0;
            var net31percentage = (double)net31Downloads / (net471Downloads + net472Downloads + net48Downloads + net31Downloads + net5Downloads + net6Downloads) * 100.0;
            var net5percentage = (double)net5Downloads / (net471Downloads + net472Downloads + net48Downloads + net31Downloads + net5Downloads + net6Downloads) * 100.0;
            var net6percentage = (double)net6Downloads / (net471Downloads + net472Downloads + net48Downloads + net31Downloads + net5Downloads + net6Downloads) * 100.0;

            List<PieChartSingleDataPoint> data = new List<PieChartSingleDataPoint>()
            {
                new PieChartSingleDataPoint("NET Framework 471", net471Downloads),
                new PieChartSingleDataPoint("NET Framework 472", net472Downloads),
                new PieChartSingleDataPoint("NET Framework 48", net48Downloads),
                new PieChartSingleDataPoint("NETCORE 3.1", net31Downloads),
                new PieChartSingleDataPoint("NET 5", net5Downloads),
                new PieChartSingleDataPoint("NET 6", net6Downloads),
            };

            var pieChart = new ChartControl();
            pieChart.AllowGesture = true;
            pieChart.Titles.Clear();
            pieChart.Titles.Add(new ChartTitle() { Text = "Download Statistics" });
            pieChart.Series.Clear();
            // Create a pie series. 
            Series series1 = new Series("Download Statistics", ViewType.Pie3D);
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
            panelChart.Controls.Add(pieChart);
        }
    }
}