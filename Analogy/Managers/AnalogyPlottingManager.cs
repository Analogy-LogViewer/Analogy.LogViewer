using Analogy.CommonControls.DataTypes;
using Analogy.DataTypes;
using Analogy.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Analogy.Managers
{
    public class AnalogyPlottingManager
    {
        private static readonly Lazy<AnalogyPlottingManager> _instance =
            new Lazy<AnalogyPlottingManager>(() => new AnalogyPlottingManager());

        public static AnalogyPlottingManager Instance => _instance.Value;

        private Dictionary<IAnalogyPlotting, AnalogyPlottingInteractor> Interactors { get; }

        private AnalogyPlottingManager()
        {
            Interactors = new Dictionary<IAnalogyPlotting, AnalogyPlottingInteractor>();
        }

        public AnalogyPlottingInteractor GetOrCreateInteractor(IAnalogyPlotting plotter)
        {
            if (!Interactors.ContainsKey(plotter))
            {
                Interactors.Add(plotter, new AnalogyPlottingInteractor());
            }
            return Interactors[plotter];
        }

    }
}