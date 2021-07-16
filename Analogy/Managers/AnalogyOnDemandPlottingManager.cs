using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.UserControls;
using System;
using System.Collections.Generic;

namespace Analogy.Managers
{
    public class AnalogyOnDemandPlottingManager
    {
        public event EventHandler<OnDemandPlottingUC> OnShowPlot;
        public event EventHandler<OnDemandPlottingUC> OnHidePlot;
        private static readonly Lazy<AnalogyOnDemandPlottingManager> _instance = new Lazy<AnalogyOnDemandPlottingManager>(() => new AnalogyOnDemandPlottingManager());
        public static AnalogyOnDemandPlottingManager Instance => _instance.Value;

        private IAnalogyOnDemandPlottingInteractor Interactor { get; }
        private Dictionary<Guid, OnDemandPlottingUC> Plots { get; }

        private AnalogyOnDemandPlottingManager()
        {
            Interactor = new AnalogyOnDemandPlottingInteractor();
            Plots = new Dictionary<Guid, OnDemandPlottingUC>();
        }


        public void Register()
        {
        }

        public void ShowPlot(Guid id, string plotTitle, AnalogyOnDemandPlottingStartupType startupType)
        {
            if (!Plots.ContainsKey(id))
            {
                Plots[id] = new OnDemandPlottingUC(plotTitle);
            }
            OnShowPlot.Invoke(this, Plots[id]);
        }

        public void ClosePlot(Guid id)
        {
            if (Plots.ContainsKey(id) && !Plots[id].IsDisposed && Plots[id].Visible)
            {
                OnHidePlot.Invoke(this, Plots[id]);
            }
        }

        public void RemoveSeriesFromPlot(Guid id, string seriesName)
        {
            if (Plots.ContainsKey(id) && !Plots[id].IsDisposed && Plots[id].Visible)
            {
                var plot = Plots[id];
                plot.RemoveSeriesFromPlot(seriesName);
            }
        }

        public void ClearSeriesData(Guid id, string seriesNameToClear)
        {
            if (Plots.ContainsKey(id) && !Plots[id].IsDisposed && Plots[id].Visible)
            {
                var plot = Plots[id];
                plot.ClearSeriesData(seriesNameToClear);
            }
        }

        public void ClearAllData(Guid id)
        {
            if (Plots.ContainsKey(id) && !Plots[id].IsDisposed && Plots[id].Visible)
            {
                var plot = Plots[id];
                plot.ClearAllData();
            }
        }
    }
}
