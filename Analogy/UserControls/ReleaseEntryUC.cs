using System.Net;
using Analogy.CommonUtilities.Github;
using DevExpress.XtraEditors;
using Markdig;
using static Grpc.Core.Metadata;

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

            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions()
                .Build();
            string data = $"# {Entry.Title}{Environment.NewLine}{Environment.NewLine}{Entry.Content}{Environment.NewLine}{Environment.NewLine}Created: {Entry.Created}";
            string html = Markdown.ToHtml(data , pipeline);
            richEditControl1.HtmlText = html;

        }
    }
}
