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
        private List<(string SeriesName, PlottingGraphData Data)> GraphsData { get; set; }

        public PlottingDataManager()
        {
            GraphsData = new List<(string SeriesName, PlottingGraphData Data)>();
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
        public void Start(string seriesName)
        {
            foreach ((string name, PlottingGraphData data) in GraphsData)
            {
                if (name == seriesName)
                {
                    data.Start();
                }
            }
        }
        public void SetRefreshInterval(float seconds)
        {
            GraphsData.ForEach(((string SeriesName, PlottingGraphData Data) entry) =>
            {
                entry.Data.SetIntervalValue(seconds);
            });
        }

        public void SetDataWindow(int windowValue)
        {
            GraphsData.ForEach(((string SeriesName, PlottingGraphData Data) entry) =>
            {
                entry.Data.SetWindowValue(windowValue);
            });
        }

        public void ClearSeriesData(string seriesNameToClear)
        {
            var exist = GraphsData.Exists(s => s.SeriesName.Equals(seriesNameToClear));
            if (exist)
            {
                var series = GraphsData.First(s => s.SeriesName.Equals(seriesNameToClear));
                series.Data.Clear();
            }
        }

        public void ClearAllData()
        {
            GraphsData.ForEach(((string SeriesName, PlottingGraphData Data) entry) =>
            {
                entry.Data.Clear();
            });
        }
    }
}