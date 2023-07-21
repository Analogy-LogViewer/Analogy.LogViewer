using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Interfaces;
using DevExpress.Data.ExpressionEditor;
using DevExpress.XtraEditors;

namespace Analogy.CommonControls.Tools
{
    public partial class JsonTreeUC : XtraUserControl
    {
        private JsonTreeView _jsonTreeView;
        private AnalogyLogMessage? Message { get; }
        private string JsonData { get; set; }
        private readonly bool _useRawField;
        public JsonTreeUC()
        {
            InitializeComponent();
        }

        public JsonTreeUC(AnalogyLogMessage message):this()
        {
            Message = message;
            _useRawField = message.RawTextType == AnalogyRowTextType.JSON;
        }

        public JsonTreeUC(string json):this()
        {
            JsonData = json;
            _useRawField = false;
        }
        private async void JsonTreeUC_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            _jsonTreeView = new JsonTreeView();
            _jsonTreeView.OnNodeChanged += (s, e) => meSelected.Text = e;
            splitContainerControl2.Panel1.Controls.Add(_jsonTreeView);
            _jsonTreeView.Dock = DockStyle.Fill;
            if (string.IsNullOrEmpty(JsonData) && Message != null)
            {
                JsonData = Utils.ExtractJsonObject(_useRawField ? Message.RawText : Message.Text);
                if (!string.IsNullOrEmpty(JsonData))
                {
                   await _jsonTreeView.ShowJson(JsonData);
                }
                return;
            }
            if (!string.IsNullOrEmpty(JsonData))
            {
               await _jsonTreeView.ShowJson(JsonData);
            }

            bbiCopyMessage.ItemClick += (_, _) =>
            {
                Clipboard.SetText(_jsonTreeView.Message);
            };
        }

        public async Task ShowJson(string json)
        {
            JsonData = json;
            if (!string.IsNullOrEmpty(JsonData))
            {
              await  _jsonTreeView.ShowJson(JsonData);
            }
        }

        public void ClearList()
        {
            _jsonTreeView.ClearList();
        }
    }
}
