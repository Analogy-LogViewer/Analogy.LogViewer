using Analogy.Interfaces.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.CommonControls.DataTypes
{
    public class PlottingDataManager
    {
        private List<(string seriesName, PlottingGraphData data)> GraphsData { get; set; }

        public PlottingDataManager()
        {
            GraphsData = new List<(string seriesName, PlottingGraphData data)>();
        }

        public void AddGraphData(string seriesName, PlottingGraphData data) => GraphsData.Add((seriesName, data));

        public void AddPoint(AnalogyPlottingPointData pt)
        {
            foreach ((string seriesName, PlottingGraphData data) in GraphsData)
            {
                if (seriesName.Equals(pt.Name))
                {
                    data.AddDataPoint(pt);
                    return;
                }
            }
        }
        public void AddPoints(List<AnalogyPlottingPointData> pt)
        {
            var grouped = pt.GroupBy(p => p.Name);
            foreach (var byNames in grouped)
            {
                foreach ((string seriesName, PlottingGraphData data) in GraphsData)
                {
                    if (seriesName.Equals(byNames.Key))
                    {
                        data.AddDataPoints(byNames.ToList());
                        return;
                    }
                }
            }

        }
        public void Start()
        {
            foreach ((string _, PlottingGraphData data) in GraphsData)
            {
                data.Start();
            }
        }
        public void Start(string SeriesName)
        {
            foreach ((string name, PlottingGraphData data) in GraphsData)
            {
                if (name == SeriesName)
                {
                    data.Start();
                }
            }
        }
        public void SetRefreshInterval(float seconds)
        {
            GraphsData.ForEach(((string series, PlottingGraphData data) entry) =>
            {
                entry.data.SetIntervalValue(seconds);
            });
        }

        public void SetDataWindow(int windowValue)
        {
            GraphsData.ForEach(((string series, PlottingGraphData data) entry) =>
            {
                entry.data.SetWindowValue(windowValue);
            });
        }

        public void ClearSeriesData(string seriesNameToClear)
        {
            var exist = GraphsData.Exists(s => s.seriesName.Equals(seriesNameToClear));
            if (exist)
            {
                var series = GraphsData.First(s => s.seriesName.Equals(seriesNameToClear));
                series.data.Clear();
            }
        }

        public void ClearAllData()
        {
            GraphsData.ForEach(((string series, PlottingGraphData data) entry) =>
            {
                entry.data.Clear();
            });
        }
    }
}
