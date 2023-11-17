using Analogy.CommonUtilities.Github;
using DevExpress.XtraEditors;
using Markdig;
using Octokit;
using System.Net;
using static Grpc.Core.Metadata;

namespace Analogy.UserControls
{
    public partial class ReleaseEntryUC : XtraUserControl
    {
        public Release Entry { get; }

        public ReleaseEntryUC()
        {
            InitializeComponent();
        }

        public ReleaseEntryUC(Release entry) : this()
        {
            Entry = entry;
        }

        private void ReleaseEntryUC_Load(object sender, EventArgs e)
        {

            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions()
                .Build();
            string data = $"# {Entry.Name}{Environment.NewLine}{Environment.NewLine}{Entry.Body}{Environment.NewLine}{Environment.NewLine}Created: {Entry.CreatedAt.DateTime}";
            string html = Markdown.ToHtml(data , pipeline);
            richEditControl1.HtmlText = html;

        }
    }
}
