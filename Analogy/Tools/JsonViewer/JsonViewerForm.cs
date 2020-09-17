using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Tools.JsonViewer;
using DevExpress.XtraEditors;

namespace Analogy.Tools
{
    public partial class JsonViewerForm : DevExpress.XtraEditors.XtraForm
    {
        private UserSettingsManager settings => UserSettingsManager.UserSettings;
        private JsonTreeView _jsonTreeView;
        public JsonViewerForm()
        {
            InitializeComponent();
        }

        private void JsonViewerForm_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            Icon = settings.GetIcon();
            _jsonTreeView = new JsonTreeView();
            splitContainerControl1.Panel2.Controls.Add(_jsonTreeView);
            _jsonTreeView.Dock = DockStyle.Fill;

        }

        private void sbtnLoad_Click(object sender, EventArgs e)
        {
            _jsonTreeView.ShowJson(memoEdit1.Text);
        }
    }
}