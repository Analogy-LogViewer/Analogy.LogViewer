using Analogy.CommonControls.UserControls;
using Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.CommonControls.Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LogMessagesUC log = new LogMessagesUC();
            this.Controls.Add(log);
            log.Dock = DockStyle.Fill;

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    var m = new AnalogyLogMessage($"Test: {i}", AnalogyLogLevel.Information, AnalogyLogClass.General, "");
                    log.AppendMessage(m,"Example");
                    Thread.Sleep(1000);
                }

            });
        }
    }
}