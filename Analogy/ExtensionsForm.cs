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
            extensionsUC1.OnClick += (s, args) => { Close(); };

        }
    }
}
