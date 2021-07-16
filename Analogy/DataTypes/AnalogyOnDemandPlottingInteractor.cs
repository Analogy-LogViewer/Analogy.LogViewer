using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Analogy.Managers;

namespace Analogy.DataTypes
{
    public class AnalogyOnDemandPlottingInteractor: IAnalogyOnDemandPlottingInteractor
    {
        
        public void ShowPlot(Guid id, string plotTitle, AnalogyOnDemandPlottingStartupType startupType)
        {
            AnalogyOnDemandPlottingManager.Instance.ShowPlot(id, plotTitle, startupType);
        }

        public void ClosePlot(Guid id)
        {
            AnalogyOnDemandPlottingManager.Instance.ClosePlot(id);
        }

        public void RemoveSeriesFromPlot(Guid id, string seriesName)
        {
            AnalogyOnDemandPlottingManager.Instance.RemoveSeriesFromPlot(id,seriesName);
        }

        public void ClearSeriesData(Guid id, string seriesNameToClear)
        {
            AnalogyOnDemandPlottingManager.Instance.ClearSeriesData(id, seriesNameToClear);
        }

        public void ClearAllData(Guid id)
        {
            AnalogyOnDemandPlottingManager.Instance.ClearAllData(id);
           
        }

    }
}
