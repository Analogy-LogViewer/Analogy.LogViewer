using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;
namespace Analogy.DataTypes
{
    public class AnalogyOnDemandPlottingInteractor: IAnalogyOnDemandPlottingInteractor
    {

        public void ShowPlot(Guid id, AnalogyOnDemandPlottingStartupType startupType)
        {
            throw new NotImplementedException();
        }

        public void ClosePlot(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveSeriesFromPlot(Guid id, string seriesName)
        {
            throw new NotImplementedException();
        }

        public void ClearAllData(Guid id, string seriesToClear)
        {
            throw new NotImplementedException();
        }
    }
}
