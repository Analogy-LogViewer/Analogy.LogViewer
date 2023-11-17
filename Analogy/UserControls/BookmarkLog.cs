using Analogy.CommonControls.Managers;
using Analogy.DataTypes;
using Analogy.Interfaces;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Analogy.UserControls
{

    public partial class BookmarkLog : XtraUserControl, IUserControlWithUCLogs
    {
        private BookmarkPersistManager BookmarkPersistManager { get; } = ServicesProvider.Instance.GetService<BookmarkPersistManager>();

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
            var messages = await BookmarkPersistManager.GetMessages();
            ucLogs1.AppendMessages(messages, "Analogy bookmarks");
            BookmarkPersistManager.MessageReceived += (s, msg) => ucLogs1.AppendMessage(msg.Message, msg.DataSource);
            BookmarkPersistManager.MessageRemoved += (s, msg) => ucLogs1.RemoveMessage(msg.Message);
        }
        public void ShowSecondaryWindow()
        {
            if (ucLogs1 != null)
                ucLogs1.ShowSecondaryWindow();
        }

        public void HideSecondaryWindow()
        {
            if (ucLogs1 != null)
                ucLogs1.HideSecondaryWindow();
        }
    }

}


