using System.Net;
using Analogy.CommonUtilities.Github;
using DevExpress.XtraEditors;
using Markdig;

namespace Analogy.UserControls
{
    public partial class ReleaseEntryUC : XtraUserControl
    {
        public GithubReleaseEntry Entry { get; }

        public ReleaseEntryUC()
        {
            InitializeComponent();
        }

        public ReleaseEntryUC(GithubReleaseEntry entry) : this()
        {
            Entry = entry;
        }

        private void ReleaseEntryUC_Load(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions()
                    .Build();
                string html =Markdown.ToHtml(Entry.Content,pipeline);
                richEditControl1.HtmlText = html;
            }
        }
    }
}
