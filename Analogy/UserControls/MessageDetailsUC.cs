using Analogy.Interfaces;
using Analogy.Tools.JsonViewer;
using DevExpress.XtraEditors;
using Markdig;
using Markdig.SyntaxHighlighting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Analogy
{
    public partial class MessageDetailsUC : XtraUserControl
    {
        private AnalogyLogMessage? Message { get; set; }
        private List<AnalogyLogMessage> Messages { get; }
        private string DataSource { get; }
        private MarkdownPipeline? Pipeline { get; set; }
        private JsonTreeView _jsonTreeView;

        public MessageDetailsUC()
        {
            InitializeComponent();
            Messages = new List<AnalogyLogMessage>(0);
        }

        public MessageDetailsUC(AnalogyLogMessage msg, List<AnalogyLogMessage> messages, string dataSource) : this()
        {
            Message = msg;
            Messages = messages;
            DataSource = dataSource;

        }

        private void UCMessageDetails_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;

            }

            Pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions()
                .UseSyntaxHighlighting()
                .Build();
            xtraTabControlMessageInfo.SelectedTabPage = xtraTabPageRenderedText;

            _jsonTreeView = new JsonTreeView();
            _jsonTreeView.OnNodeChanged += (s, e) => meSelected.Text = e;
            splitContainerControl2.Panel1.Controls.Add(_jsonTreeView);
            _jsonTreeView.Dock = DockStyle.Fill;
            LoadMessage();
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

        public void LoadMessage()
        {
            if (Message == null)
            {
                return;
            }

            xtraTabPageAdditionalInformation.PageVisible =
                Message.AdditionalInformation != null && Message.AdditionalInformation.Any();
            if (Message.AdditionalInformation != null)
            {
                memoAdditionalInformation.Text = string.Join(Environment.NewLine,
                    Message.AdditionalInformation.Select(kv => $"{kv.Key}:{kv.Value}"));
            }

            memoText.Text = Message.Text;
            txtbMachineName.Text = Message.MachineName;
            txtID.Text = Message.Id.ToString();
            txtbDataSource.Text = DataSource;
            txtbDateValue.Text = Utils.GetOffsetTime(Message.Date).ToString(UserSettingsManager.UserSettings.DateTimePattern);
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
            var jsonRawData = Message.RawTextType == AnalogyRowTextType.JSON;
            if (jsonRawData)
            {
                var json = Utils.ExtractJsonObject(jsonRawData ? Message.RawText : Message.Text);
                _jsonTreeView.ClearList();
                if (!string.IsNullOrEmpty(json))
                {
                    _jsonTreeView.ShowJson(json);
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

        private void LoadPreviousMessage()
        {
            if (Messages.First() == Message)
            {
                return;
            }

            Message = Messages[Messages.IndexOf(Message) - 1];
            LoadMessage();
        }
        private void LoadNextMessage()
        {
            if (Messages.Last() == Message)
            {
                return;
            }

            Message = Messages[Messages.IndexOf(Message) + 1];
            LoadMessage();
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            LoadPreviousMessage();
        }

        private void sBtnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(memoText.Text);
        }


    }
}
