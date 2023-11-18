using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.CommonControls.Plotting
{
    public class PlotState
    {
        public int ChartType { get; set; }
        public bool ShowLegend { get; set; }
        public bool ShowAll { get; set; }
        public bool ShowChartControl { get; set; }
        public bool ShowTimeInXAxis { get; set; }
        [JsonIgnore] public Dictionary<string, bool> CheckedLegendState { get; set; }

        public PlotState()
        {
            CheckedLegendState = new Dictionary<string, bool>();
        }

        public void AddCheckedState(string name, bool isChecked)
        {
            CheckedLegendState[name] = isChecked;
        }

        public bool GetChecked(string legendName)
        {
            if (!CheckedLegendState.ContainsKey(legendName))
            {
                return true;
            }
            return CheckedLegendState[legendName];
        }
    }
}