using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.UserControls
{
    public partial class FilePlotterUC : XtraUserControl
    {
        private CancellationTokenSource cts;
        private bool InFileProcess { get; set; }
        private Task processTask;
        private long processed;
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
                    processed = 0;
                }
                if (!string.IsNullOrEmpty(teFile.Text) && File.Exists(teFile.Text))
                {
                    if (InFileProcess)
                    {
                        cts.Cancel(false);
                        return;
                    }

                    processed = 0;
                    InFileProcess = true;
                    sbtnLoad.Text = "Cancel";
                    cts = new CancellationTokenSource();
                    var token = cts.Token;
                    token.Register(Cancel, true);
                    bool firstRowIsTitle = ceFirstRowTitle.Checked;
                    bool dateTimeAxis = ceDateTimeColumn.Checked;
                    DataPlotterUC uc = new DataPlotterUC();
                   // dockManager1.AddPanel()
                    string fileName = teFile.Text;
                    string line;
                    processTask = Task.Run(async () =>
                        {
                            using StreamReader file = new StreamReader(fileName);
                            line = await file.ReadLineAsync();
                            if (string.IsNullOrEmpty(line))
                            {

                            }

                            while ((line = await file.ReadLineAsync()) != null)
                            {
                                processed++;
                            }

                        }
                    );
                }
            };
        }



    }
}
