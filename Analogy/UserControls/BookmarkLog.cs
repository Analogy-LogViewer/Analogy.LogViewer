using System.Windows.Forms;
using Analogy.CommonControls.Managers;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace Analogy
{

    public partial class BookmarkLog : XtraUserControl
    {
        public BookmarkLog()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            ucLogs1.ProcessCmdKeyFromParent(keyData);
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private async void BookmarkLog_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            ucLogs1.HideRefreshAndScrolling();
            ucLogs1.SetBookmarkMode();
            var messages = await BookmarkPersistManager.Instance.GetMessages();
            ucLogs1.AppendMessages(messages, "Analogy bookmarks");
            BookmarkPersistManager.Instance.MessageReceived += (s, msg) => ucLogs1.AppendMessage(msg.Message, msg.DataSource);
            BookmarkPersistManager.Instance.MessageRemoved += (s, msg) => ucLogs1.RemoveMessage(msg.Message);
        }
    }

}


