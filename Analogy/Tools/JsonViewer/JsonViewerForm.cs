using Analogy.Interfaces;
using Analogy.Tools.JsonViewer;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace Analogy.Tools
{
    public partial class JsonViewerForm : DevExpress.XtraEditors.XtraForm
    {
        private UserSettingsManager settings => UserSettingsManager.UserSettings;
        private JsonTreeView _jsonTreeView;
        private AnalogyLogMessage message;
        private readonly bool _useRawField;

        public JsonViewerForm()
        {
            InitializeComponent();
        }

        public JsonViewerForm(AnalogyLogMessage message) : this()
        {
            this.message = message;
            _useRawField = message.RawTextType == AnalogyRowTextType.JSON;
        }

        private void JsonViewerForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            Icon = settings.GetIcon();
            _jsonTreeView = new JsonTreeView(); 
            _jsonTreeView.OnNodeChanged += (s, e) => meSelected.Text = e;
            splitContainerControl2.Panel1.Controls.Add(_jsonTreeView);
            _jsonTreeView.Dock = DockStyle.Fill;
            if (message != null)
            {
                memoEdit1.Text = _useRawField ? message.RawText : message.Text;
                var json =Utils.ExtractJsonObject(_useRawField ? message.RawText : message.Text);
                if (!string.IsNullOrEmpty(json))
                {
                    _jsonTreeView.ShowJson(json);
                }
            }



        }
        
        private void sbtnLoad_Click(object sender, EventArgs e)
        {
            _jsonTreeView.ShowJson(memoEdit1.Text);
        }
    }
}