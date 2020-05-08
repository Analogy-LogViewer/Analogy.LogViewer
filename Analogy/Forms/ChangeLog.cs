using DevExpress.XtraEditors;
using System;

namespace Analogy
{
    public partial class ChangeLog : XtraForm
    {
        public ChangeLog()
        {
            InitializeComponent();
        }

        private void sBtnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChangeLog_Load(object sender, EventArgs e)
        {
            Icon = UserSettingsManager.UserSettings.GetIcon();
        }
    }
}
