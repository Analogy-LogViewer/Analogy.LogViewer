using Analogy.DataTypes;
using Analogy.Interfaces.DataTypes;
using System.Collections.Generic;

namespace Analogy.Managers
{
    public class PlottingManager
    {
        private List<(string seriesName, PlottingGraphData data)> GraphsData { get; set; }

        public PlottingManager()
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

        public void Start()
        {
            foreach ((string _, PlottingGraphData data) in GraphsData)
            {
                data.Start();
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
    }
}
