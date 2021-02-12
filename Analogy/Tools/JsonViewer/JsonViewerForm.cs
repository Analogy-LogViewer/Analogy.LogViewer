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
            splitContainerControl1.Panel2.Controls.Add(_jsonTreeView);
            _jsonTreeView.Dock = DockStyle.Fill;
            if (message != null)
            {
                memoEdit1.Text = _useRawField ? message.RawText : message.Text;
                var json = ExtractJsonObject(_useRawField ? message.RawText : message.Text);
                if (!string.IsNullOrEmpty(json))
                {
                    _jsonTreeView.ShowJson(json);
                }
            }



        }

        public string ExtractJsonObject(string mixedString)
        {
            for (var i = mixedString.IndexOf('{'); i > -1; i = mixedString.IndexOf('{', i + 1))
            {
                for (var j = mixedString.LastIndexOf('}'); j > -1; j = mixedString.LastIndexOf("}", j - 1))
                {
                    var jsonProbe = mixedString.Substring(i, j - i + 1);
                    try
                    {
                        var valid = JsonConvert.DeserializeObject(jsonProbe);
                        return jsonProbe;
                    }
                    catch
                    {
                    }
                }
            }

            return null;
        }

        private void sbtnLoad_Click(object sender, EventArgs e)
        {
            _jsonTreeView.ShowJson(memoEdit1.Text);
        }
    }
}