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
    public partial class ApplicationSettingsForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public ApplicationSettingsForm()
        {
            InitializeComponent();
        }

        private void ApplicationSettingsForm_Load(object sender, EventArgs e)
        {
            ShowIcon = true;
            Icon = UserSettingsManager.UserSettings.GetIcon();
        }
    }
}
