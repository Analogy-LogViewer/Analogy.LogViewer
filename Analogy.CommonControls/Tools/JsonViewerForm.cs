using Analogy.Common;
using Analogy.Common.Interfaces;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Analogy.CommonControls.Tools
{
    public partial class JsonViewerForm : DevExpress.XtraEditors.XtraForm
    {
        private IUserSettingsManager Settings { get; }
        private JsonTreeUC _jsonTreeView;
        private AnalogyLogMessage? Message { get; }
        private string JsonData { get; set; }
        private readonly bool _useRawField;
        private static Guid WindowID { get; } = new Guid("1d611a7b-3b85-4df2-8d31-05e0b8a2679d");

        public JsonViewerForm(IUserSettingsManager settings)
        {
            Settings = settings;
            InitializeComponent();
            JsonData = string.Empty;
        }

        public JsonViewerForm(AnalogyLogMessage message, IUserSettingsManager settings) : this(settings)
        {
            Message = message;
            _useRawField = message.RawTextType == AnalogyRowTextType.JSON;
        }
        public JsonViewerForm(string json, IUserSettingsManager settings) : this(settings)
        {
            JsonData = json;
            _useRawField = false;
        }
        private async void JsonViewerForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            this.FormClosing += (_, _) =>
            {
                Settings.SetWindowPosition(WindowID, CommonUtils.CreatePosition(this));
            };

            CommonUtils.RepositionIfNeeded(this, WindowID, Settings);
            _jsonTreeView = new JsonTreeUC();
            splitContainerControl1.Panel2.Controls.Add(_jsonTreeView);
            _jsonTreeView.Dock = DockStyle.Fill;
            if (!string.IsNullOrEmpty(JsonData))
            {
                memoEdit1.Text = JsonData;
                await _jsonTreeView.ShowJson(JsonData);
            }
            else if (Message != null)
            {
                memoEdit1.Text = _useRawField ? Message.RawText : Message.Text;
                JsonData = Utils.ExtractJsonObject(_useRawField ? Message.RawText : Message.Text);
                if (!string.IsNullOrEmpty(JsonData))
                {
                    await _jsonTreeView.ShowJson(JsonData);
                }
            }
        }

        private async void sbtnLoad_Click(object sender, EventArgs e)
        {
            await _jsonTreeView.ShowJson(memoEdit1.Text);
        }
    }
}