using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using Analogy.Interfaces.DataTypes;

namespace Analogy.Managers
{
    public class AnalogyOnDemandPlottingManager
    {
        public event EventHandler<(OnDemandPlottingUC userControl, AnalogyOnDemandPlottingStartupType startupType)> OnShowPlot;
        public event EventHandler<OnDemandPlottingUC> OnHidePlot;
        event EventHandler<(Guid Id, IEnumerable<AnalogyPlottingPointData> PointsData)> OnNewPointsData;

        private static readonly Lazy<AnalogyOnDemandPlottingManager> _instance = new Lazy<AnalogyOnDemandPlottingManager>(() => new AnalogyOnDemandPlottingManager());
        public static AnalogyOnDemandPlottingManager Instance => _instance.Value;

        private IAnalogyOnDemandPlottingInteractor Interactor { get; }
        private Dictionary<Guid, OnDemandPlottingUC> Plots { get; }
        private List<IAnalogyOnDemandPlotting> Plotters { get; }
        private Dictionary<Guid, List<AnalogyPlottingPointData>> Data { get; }
        private AnalogyOnDemandPlottingManager()
        {
            Interactor = new AnalogyOnDemandPlottingInteractor();
            Plots = new Dictionary<Guid, OnDemandPlottingUC>();
            Plotters = new List<IAnalogyOnDemandPlotting>();
            Data = new Dictionary<Guid, List<AnalogyPlottingPointData>>();
        }


        public void Register(IAnalogyOnDemandPlotting plotter)
        {
            plotter.OnNewPointsData += Plotter_OnNewPointsData;
            Plotters.Add(plotter);
        }

        private void Plotter_OnNewPointsData(object sender, (Guid Id, IEnumerable<AnalogyPlottingPointData> PointsData) e)
        {
            if (!Data.ContainsKey(e.Id))
            {
                Data[e.Id] = new List<AnalogyPlottingPointData>();
            }
            Data[e.Id].AddRange(e.PointsData);
            OnNewPointsData?.Invoke(sender, e);
        }

        public void ShowPlot(Guid id, string plotTitle, AnalogyOnDemandPlottingStartupType startupType)
        {
            if (!Plots.ContainsKey(id))
            {
                List<string> alreadyExistedSeries = new List<string>();
                if (Data.TryGetValue(id, out var data))
                {
                    alreadyExistedSeries.AddRange(data.Select(d=>d.Name).Distinct());
                }
                Plots[id] = new OnDemandPlottingUC(id,plotTitle,alreadyExistedSeries);
            }
            OnShowPlot.Invoke(this, (Plots[id], startupType));
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
                if (Data.TryGetValue(id, out var pts))
                {
                    var filtered = pts.Where(p => p.Name != seriesNameToClear).ToList();
                    Data[id] = filtered;
                }
            }
        }

        public void ClearAllData(Guid id)
        {
            if (Plots.ContainsKey(id) && !Plots[id].IsDisposed && Plots[id].Visible)
            {
                var plot = Plots[id];
                plot.ClearAllData();
                Data.Remove(id);
            }
        }
    }
}
