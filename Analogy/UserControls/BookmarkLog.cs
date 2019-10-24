using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Analogy.Interfaces;
using DevExpress.XtraBars;

namespace Analogy
{

    public partial class BookmarkLog : UserControl
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
            if (DesignMode) return;
            ucLogs1.btswitchRefreshLog.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            ucLogs1.btsAutoScrollToBottom.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            ucLogs1.SetBookmarkMode();
            var messages = await BookmarkPersistManager.Instance.GetMessages();
            AppendMessages(messages, "Analogy bookmarks");
            BookmarkPersistManager.Instance.MessageReceived += (s, msg) => AppendMessage(msg.Message, msg.DataSource);
            BookmarkPersistManager.Instance.MessageRemoved += (s, msg) => RemoveMessage(msg.Message);
        }

        private void RemoveMessage(AnalogyLogMessage msgMessage)
        {
            ucLogs1.RemoveMessage(msgMessage);
        }


        public void AppendMessage(AnalogyLogMessage message, string dataSource)
        {
            ucLogs1.AppendMessage(message, dataSource);
        }

        public void AppendMessages(List<AnalogyLogMessage> messages, string dataSource)
        {
            ucLogs1.AppendMessages(messages, dataSource);
        }

    }

}


