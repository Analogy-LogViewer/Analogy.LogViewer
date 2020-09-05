using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Analogy.WhatIsNew;

namespace Analogy.Forms
{
    public partial class WhatsNewForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public WhatsNewForm()
        {
            InitializeComponent();
        }

        private void WhatsNewForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            Icon = UserSettingsManager.UserSettings.GetIcon();
            WhatIsNew4_2_8 uc = new WhatIsNew4_2_8();
            uc.Name = "V4.2.8";
            fluentDesignFormContainer1.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            accordionControl1.SelectedElement = accordionControl1.Elements.First();
        }

        private void e428_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.2.8"))
            {
                WhatIsNew4_2_8 uc= new WhatIsNew4_2_8();
                uc.Name = "V4.2.8";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            else
            {
                fluentDesignFormContainer1.Controls["V4.2.8"].BringToFront();
            }

        }
    }
}
