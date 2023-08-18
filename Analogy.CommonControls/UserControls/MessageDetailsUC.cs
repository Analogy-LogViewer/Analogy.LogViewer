using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Common;
using Analogy.Common.Interfaces;
using Analogy.CommonControls.Tools;
using Analogy.Interfaces;
using DevExpress.XtraEditors;
using Markdig;

namespace Analogy.CommonControls.UserControls
{
    public partial class MessageDetailsUC : XtraUserControl
    {
        private IAnalogyLogMessage? Message { get; set; }
        private List<IAnalogyLogMessage> Messages { get; }
        private string DataSource { get; }
        private MarkdownPipeline? Pipeline { get; set; }
        private JsonTreeUC _jsonTreeView;

        private MessageDetailsUC()
        {
            InitializeComponent();
            Messages = new List<IAnalogyLogMessage>(0);
        }

        public MessageDetailsUC(AnalogyLogMessage msg, List<IAnalogyLogMessage> messages, string dataSource) : this()
        {
            Message = msg;
            Messages = messages;
            DataSource = dataSource;
        }

        private async void UCMessageDetails_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;

            }
            Pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions()
                .Build();
            xtraTabControlMessageInfo.SelectedTabPage = xtraTabPageRenderedText;

            _jsonTreeView = new JsonTreeUC();
            splitContainerControl1.Panel2.Controls.Add(_jsonTreeView);
            _jsonTreeView.Dock = DockStyle.Fill;
            await LoadMessage();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                LoadPreviousMessage();
                return true;
            }

            if (keyData == Keys.Right)
            {
                LoadNextMessage();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        public async Task LoadMessage()
        {
            if (Message == null)
            {
                return;
            }

            xtraTabPageAdditionalInformation.PageVisible =
                Message.AdditionalProperties != null && Message.AdditionalProperties.Any();
            if (Message.AdditionalProperties != null)
            {
                memoAdditionalInformation.Text = string.Join(Environment.NewLine,
                    Message.AdditionalProperties.Select(kv => $"{kv.Key}:{kv.Value}"));
            }

            memoText.Text =Utils.ProcessLinuxMessage(Message.Text);
            txtbMachineName.Text = Message.MachineName;
            txtID.Text = Message.Id.ToString();
            txtbDataSource.Text = DataSource;
            txtbDateValue.Text = (Message.Date).ToString();
            txtbLevelValue.Text = Message.Level.ToString();
            txtbProcessModuleName.Text = Message.Module;
            txtbProcessId.Text = Message.ProcessId.ToString();
            txtbThreadId.Text = Message.ThreadId.ToString();
            txtSourceValue.Text = Message.Source;
            txtbMethod.Text = Message.MethodName;
            txtbFileName.Text = Message.FileName;
            txtbUser.Text = Message.User;
            txtbLineNumber.Text = Message.LineNumber.ToString();
            txtbIndex.Text = $@"{Messages.IndexOf(Message) + 1} of {Messages.Count}";
            recMessageDetails.HtmlText = Markdown.ToHtml(Message.Text, Pipeline);
            recMessageDetailsRawText.Text = Message.RawText;
            var jsonRawData = Message.RawTextType == AnalogyRowTextType.JSON;
            if (jsonRawData)
            {
                var json = Utils.ExtractJsonObject(jsonRawData ? Message.RawText : Message.Text);
                _jsonTreeView.ClearList();
                if (!string.IsNullOrEmpty(json))
                {
                  await  _jsonTreeView.ShowJson(json);
                }

                splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
            }
            else
            {
                splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            }
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            LoadNextMessage();
        }

        private async void LoadPreviousMessage()
        {
            if (Messages.First() == Message)
            {
                return;
            }

            Message = Messages[Messages.IndexOf(Message) - 1];
            await LoadMessage();
        }
        private async void LoadNextMessage()
        {
            if (Messages.Last() == Message)
            {
                return;
            }

            Message = Messages[Messages.IndexOf(Message) + 1];
            await LoadMessage();
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            LoadPreviousMessage();
        }
    }
}
