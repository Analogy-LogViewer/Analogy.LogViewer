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
        private AnalogyLogMessage? Message { get; }
        private string JsonData { get; set; }
        private readonly bool _useRawField;

        public JsonViewerForm()
        {
            InitializeComponent();
            JsonData = string.Empty;
        }

        public JsonViewerForm(AnalogyLogMessage message) : this()
        {
            Message = message;
            _useRawField = message.RawTextType == AnalogyRowTextType.JSON;
        }
        public JsonViewerForm(string json) : this()
        {
            JsonData = json;
            _useRawField = false;
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
            if (string.IsNullOrEmpty(JsonData) && Message != null)
            {
                memoEdit1.Text = _useRawField ? Message.RawText : Message.Text;
                JsonData =Utils.ExtractJsonObject(_useRawField ? Message.RawText : Message.Text);
                if (!string.IsNullOrEmpty(JsonData))
                {
                    _jsonTreeView.ShowJson(JsonData);
                }
                return;
            }
            if (!string.IsNullOrEmpty(JsonData))
            {
                memoEdit1.Text = JsonData;
                _jsonTreeView.ShowJson(JsonData);
            }


        }

        private void sbtnLoad_Click(object sender, EventArgs e)
        {
            _jsonTreeView.ShowJson(memoEdit1.Text);
        }
    }
}