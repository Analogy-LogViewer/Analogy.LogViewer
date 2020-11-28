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
                }
            }
        }
    }
}
