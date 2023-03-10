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
            WhatIsNew4_11_0 uc = new WhatIsNew4_11_0 { Name = "V4.11.0" };
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

        private void e474_Click(object sender, EventArgs e)
        {

            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.7.4"))
            {
                WhatIsNew4_7_4 uc = new WhatIsNew4_7_4();
                uc.Name = "V4.7.4";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.7.4");

        }

        private void e475_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.7.5"))
            {
                WhatIsNew4_7_5 uc = new WhatIsNew4_7_5();
                uc.Name = "V4.7.5";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.7.5");
        }

        private void e480_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.8.0"))
            {
                WhatIsNew4_8_0 uc = new WhatIsNew4_8_0();
                uc.Name = "V4.8.0";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.8.0");
        }

        private void e484_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.8.4"))
            {
                WhatIsNew4_8_4 uc = new WhatIsNew4_8_4();
                uc.Name = "V4.8.4";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.8.4");
        }

        private void e486_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.8.6"))
            {
                WhatIsNew4_8_6 uc = new WhatIsNew4_8_6();
                uc.Name = "V4.8.6";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.8.6");
        }

        private void e487_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.8.7"))
            {
                WhatIsNew4_8_7 uc = new WhatIsNew4_8_7();
                uc.Name = "V4.8.7";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.8.7");
        }

        private void e490_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.9.0"))
            {
                WhatIsNew4_9_0 uc = new WhatIsNew4_9_0();
                uc.Name = "V4.9.0";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.9.0");
        }

        private void e4100_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.10.0"))
            {
                WhatIsNew4_10_0 uc = new WhatIsNew4_10_0();
                uc.Name = "V4.10.0";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.10.0");
        }

        private void e4102_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.10.2"))
            {
                WhatIsNew4_10_2 uc = new WhatIsNew4_10_2();
                uc.Name = "V4.10.2";
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.10.2");
        }

        private void e4110_Click(object sender, EventArgs e)
        {
            if (!fluentDesignFormContainer1.Controls.ContainsKey("V4.11.0"))
            {
                WhatIsNew4_11_0 uc = new WhatIsNew4_11_0 { Name = "V4.11.0" };
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }
            SetActive("V4.11.0");
        }
    }
}
