using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.DataTypes;
using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy.UserControls
{
    public partial class DataPlotterUC : XtraUserControl
    {
        private readonly IAnalogyPlotting _plotter;
        private readonly AnalogyPlottingInteractor _interactor;

        public DataPlotterUC()
        {
            InitializeComponent();
        }

        public DataPlotterUC(IAnalogyPlotting plotter, AnalogyPlottingInteractor interactor):this()
        {
            _plotter = plotter;
            _interactor = interactor;
        }
        private void DataPlotterUC_Load(object sender, EventArgs e)
        {
            PlottingUC uc = new PlottingUC(_plotter, _interactor);
            dockPanelPlot.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        
    }
}
