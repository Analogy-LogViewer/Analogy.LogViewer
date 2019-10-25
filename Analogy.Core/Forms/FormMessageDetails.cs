﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Analogy.Interfaces;

namespace Analogy
{
    public partial class FormMessageDetails : XtraForm
    {
        public FormMessageDetails()
        {
            InitializeComponent();
        }

        public FormMessageDetails(AnalogyLogMessage msg, List<AnalogyLogMessage> messages, string dataSource) : this()
        {
            UCMessageDetails uc = new UCMessageDetails(msg, messages, dataSource);
            spltCMain.Panel1.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
