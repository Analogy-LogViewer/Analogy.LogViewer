using System.Collections.Generic;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Analogy.Managers;

namespace Analogy.DataTypes
{
    public class AnalogyOnDemandPlottingInteractor : IAnalogyOnDemandPlottingInteractor
    {
        private AnalogyOnDemandPlottingManager PlottingManager { get; }

        public AnalogyOnDemandPlottingInteractor(AnalogyOnDemandPlottingManager plottingManager)
        {
            PlottingManager = plottingManager;
        }
        public void ShowPlot(Guid id, string plotTitle, AnalogyOnDemandPlottingStartupType startupType)
        {
            PlottingManager.ShowPlot(id, plotTitle, startupType);
        }

        public void ClosePlot(Guid id)
        {
            PlottingManager.ClosePlot(id);
        }

        public void AddSeriesToPlot(Guid id, string seriesName)
        {
            PlottingManager.AddSeriesToPlot(id, seriesName);
        }

        public void RemoveSeriesFromPlot(Guid id, string seriesName)
        {
            PlottingManager.RemoveSeriesFromPlot(id, seriesName);
        }

        public void ClearSeriesData(Guid id, string seriesNameToClear)
        {
            PlottingManager.ClearSeriesData(id, seriesNameToClear);
        }

        public void ClearAllData(Guid id)
        {
            PlottingManager.ClearAllData(id);

        }

        public void SetDefaultWindow(Guid id, int numberOfPointsInWindow)
        {
            throw new NotImplementedException();
        }
    }
}
