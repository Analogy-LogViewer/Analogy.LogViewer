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
        private PlottingUC uc;
        public DataPlotterUC()
        {
            InitializeComponent();
        }

        public DataPlotterUC(IAnalogyPlotting plotter, AnalogyPlottingInteractor interactor) : this()
        {
            _plotter = plotter;
            _interactor = interactor;
        }
        private void DataPlotterUC_Load(object sender, EventArgs e)
        {
            uc = new PlottingUC(_plotter, _interactor);
            dockPanelPlot.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            dockManager1.StartDocking += (s, e) =>
            {
                if (e.Panel.DockedAsTabbedDocument)
                {
                    var sz = e.Panel.Size;
                    BeginInvoke(new Action(() =>
                    {
                        e.Panel.FloatSize = sz;
                        //adjust the new panel size taking the header height into account:
                        e.Panel.FloatSize = new Size(e.Panel.FloatSize.Width, 2 * e.Panel.FloatSize.Height - e.Panel.ControlContainer.Height);
                    }));
                }
                else
                    e.Panel.FloatSize = e.Panel.Size;
            };
        }

        public void Start() => uc.Start();
        public void Stop() => uc.Stop();
    }
}
