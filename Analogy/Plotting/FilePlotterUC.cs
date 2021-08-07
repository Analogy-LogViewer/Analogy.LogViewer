using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.DataTypes;
using Analogy.Plotting;
using DevExpress.XtraBars.Docking;

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
            sbtnBrowse.Click += (_, __) =>
            {
                using OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    Title = @"Open Files",
                    Multiselect = false
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
                    bool dateTimeAxis = ceDateTimeColumn.Checked;
                    AnalogyFilePlotting afp = new AnalogyFilePlotting(fileName, firstRowIsTitle, dateTimeAxis, token);
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
