using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Analogy.Common;
using Analogy.Common.Interfaces;
using Analogy.CommonControls.UserControls;
using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy.CommonControls.Forms
{
    public partial class FormMessageDetails : XtraForm
    {
        private IUserSettingsManager Settings { get; }
        private static Guid WindowID { get; } = new Guid("12DB3C13-5BB8-4724-ADBA-A83F98539278");
        public FormMessageDetails()
        {
            InitializeComponent();
        }

        public FormMessageDetails(AnalogyLogMessage msg, List<IAnalogyLogMessage> messages, string dataSource, IUserSettingsManager settings) : this()
        {
            Settings = settings;
            MessageDetailsUC uc = new MessageDetailsUC(msg, messages, dataSource, settings);
            spltCMain.Panel1.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMessageDetails_Load(object sender, EventArgs e)
        {
            CommonUtils.RepositionIfNeeded(this, WindowID, Settings);
        }

        private void FormMessageDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.SetWindowPosition(WindowID, CommonUtils.CreatePosition(this));
        }
    }
}
