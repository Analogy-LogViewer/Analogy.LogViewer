using DevExpress.XtraEditors;
using System;

namespace Analogy
{
    public partial class ExtensionsForm : XtraForm
    {
        public ExtensionsForm()
        {
            InitializeComponent();
        }

        private void ExtensionsForm_Load(object sender, EventArgs e)
        {
            Icon = UserSettingsManager.UserSettings.GetIcon();
            extensionsUC1.OnClicked += (s, args) => { Close(); };

        }
    }
}
