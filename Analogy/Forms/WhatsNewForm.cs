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
        }

        private void WhatsNewForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            Icon = UserSettingsManager.UserSettings.GetIcon();
            WhatIsNew4_2_9 uc = new WhatIsNew4_2_9();
            uc.Name = "V4.2.9";
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
                if (others.Name == control) continue;
                others.SendToBack();
            }

            fluentDesignFormContainer1.Controls[control].BringToFront();

        }
    }
}
