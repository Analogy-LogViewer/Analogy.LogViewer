using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.CommonUtilities.Web;
using DevExpress.XtraEditors;

namespace Analogy.UserControls
{
    public partial class ReleaseEntryUC : XtraUserControl
    {
        public GithubObjects.GithubReleaseEntry Entry { get; }

        public ReleaseEntryUC()
        {
            InitializeComponent();
        }

        public ReleaseEntryUC(GithubObjects.GithubReleaseEntry entry) : this()
        {
            Entry = entry;
        }

        private void ReleaseEntryUC_Load(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                string html = client.DownloadString(Entry.HtmlUrl);
                richEditControl1.HtmlText = html;
            }
        }
    }
}
