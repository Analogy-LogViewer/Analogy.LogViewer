using Analogy.WhatIsNew;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Analogy.Forms
{
    public partial class WhatsNewForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public WhatsNewForm()
        {
            InitializeComponent();
            EnableAcrylicAccent = false;
        }

        private void WhatsNewForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            Icon = UserSettingsManager.UserSettings.GetIcon();
            WhatIsNew4_7_0 uc = new WhatIsNew4_7_0 { Name = "V4.7.0" };
            fluentDesignFormContainer1.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            accordionControl1.SelectedElement = accordionControl1.Elements.First();
        }

        private void e428_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.2.8"))
            {
                WhatIsNew4_2_8 uc = new WhatIsNew4_2_8();
                uc.Name = "V4.2.8";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.2.8");

        }
        private void e429_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.2.9"))
            {
                WhatIsNew4_2_9 uc = new WhatIsNew4_2_9();
                uc.Name = "V4.2.9";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.2.9");

        }

        private void SetActive(string control)
        {
            foreach (UserControl others in fluentDesignFormContainer1.Controls)
            {
                if (others.Name == control)
                {
                    continue;
                }

                others.SendToBack();
            }

            fluentDesignFormContainer1.Controls[control].BringToFront();

        }

        private void e4210_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.2.10"))
            {
                WhatIsNew4_2_10 uc = new WhatIsNew4_2_10();
                uc.Name = "V4.2.10";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.2.10");

        }

        private void e430_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.3.0"))
            {
                WhatIsNew4_3_0 uc = new WhatIsNew4_3_0();
                uc.Name = "V4.3.0";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.3.0");
        }

        private void e431_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.3.1"))
            {
                WhatIsNew4_3_1 uc = new WhatIsNew4_3_1();
                uc.Name = "V4.3.1";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.3.1");
        }

        private void e432_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.3.2"))
            {
                WhatIsNew4_3_2 uc = new WhatIsNew4_3_2();
                uc.Name = "V4.3.2";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.3.2");
        }

        private void e440_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.4.0"))
            {
                WhatIsNew4_4_0 uc = new WhatIsNew4_4_0();
                uc.Name = "V4.4.0";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.4.0");
        }

        private void e441_Click(object sender, EventArgs e)
        {

            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.4.1"))
            {
                WhatIsNew4_4_1 uc = new WhatIsNew4_4_1();
                uc.Name = "V4.4.1";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.4.1");
        }

        private void e450_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.5.0"))
            {
                WhatIsNew4_5_0 uc = new WhatIsNew4_5_0();
                uc.Name = "V4.5.0";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.5.0");
        }

        private void e460_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.6.0"))
            {
                WhatIsNew4_6_0 uc = new WhatIsNew4_6_0();
                uc.Name = "V4.6.0";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.6.0");
        }

        private void e470_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.7.0"))
            {
                WhatIsNew4_7_0 uc = new WhatIsNew4_7_0();
                uc.Name = "V4.7.0";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.7.0");
        }
    }
}
