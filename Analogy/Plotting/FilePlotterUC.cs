using Analogy.CommonControls.DataTypes;
using Analogy.Plotting;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnalogyCustomXAxisPlot = Analogy.CommonControls.DataTypes.AnalogyCustomXAxisPlot;

namespace Analogy.UserControls
{
    public partial class FilePlotterUC : XtraUserControl
    {
        private CancellationTokenSource cts;
        private bool InFileProcess { get; set; }
        private Task processTask;

        public FilePlotterUC()
        {
            InitializeComponent();
        }

        private void GenericPlotterUC_Load(object sender, EventArgs e)
        {
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
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
                {
                    e.Panel.FloatSize = e.Panel.Size;
                }
            };
            sbtnBrowse.Click += (_, __) =>
            {
                using OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    Title = @"Open Files",
                    Multiselect = false,
                };
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    teFile.Text = openFileDialog1.FileName;
                }
            };

            sbtnLoad.Click += (_, __) =>
            {
                void Cancel()
                {
                    sbtnLoad.Text = "load";
                    InFileProcess = false;
                }
                if (!string.IsNullOrEmpty(teFile.Text) && File.Exists(teFile.Text))
                {
                    if (InFileProcess)
                    {
                        cts.Cancel(false);
                        return;
                    }

                    InFileProcess = true;
                    sbtnLoad.Text = "Cancel";
                    cts = new CancellationTokenSource();
                    var token = cts.Token;
                    token.Register(Cancel, true);
                    string fileName = teFile.Text;
                    bool firstRowIsTitle = ceFirstRowTitle.Checked;
                    bool customXAxis = ceFirstCulmnIsXAxis.Checked;
                    AnalogyCustomXAxisPlot xAxisType = AnalogyCustomXAxisPlot.Numerical;
                    if (customXAxis)
                    {
                        if (rgFirstColumnType.SelectedIndex == 0)
                        {
                            xAxisType = AnalogyCustomXAxisPlot.DateTimeUnixMillisecond;
                        }
                        else if (rgFirstColumnType.SelectedIndex == 1)
                        {
                            xAxisType = AnalogyCustomXAxisPlot.DateTimeUnixSecond;
                        }
                        else if (rgFirstColumnType.SelectedIndex == 2)
                        {
                            xAxisType = AnalogyCustomXAxisPlot.Numerical;
                        }
                    }
                    AnalogyFilePlotting afp = new AnalogyFilePlotting(fileName, firstRowIsTitle, customXAxis, xAxisType, token);
                    var interactor = new AnalogyPlottingInteractor();
                    DataPlotterUC uc = new DataPlotterUC(afp, interactor);

                    //add panel
                    var page = dockManager1.AddPanel(DockingStyle.Float);
                    page.DockedAsTabbedDocument = true;
                    page.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;
                    page.Text = fileName;
                    dockManager1.ActivePanel = page;
                    uc.Start();
                    processTask = afp.StartPlotting();
                }
            };
        }
    }
}