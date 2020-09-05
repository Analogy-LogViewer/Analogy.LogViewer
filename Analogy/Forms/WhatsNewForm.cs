using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        }
    }
}
