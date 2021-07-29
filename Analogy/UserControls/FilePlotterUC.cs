using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Analogy.UserControls
{
    public partial class FilePlotterUC : XtraUserControl
    {
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
        }
    }
}
