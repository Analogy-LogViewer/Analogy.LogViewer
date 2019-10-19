using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Analogy.Interfaces;

namespace Analogy.Tools
{

    public class FileComparerProcessor : ILogMessageCreatedHandler
    {
        private List<AnalogyLogMessage> messages;
        public string FileName { get; }
        public FileComparerProcessor(string filename)
        {
            FileName = filename;
            messages = new List<AnalogyLogMessage>();
        }

        public bool IsLoaded { get; set; }
        public string ToText
        {
            get { return string.Join(Environment.NewLine, messages.Select(m => m.Text)); }
        }

        public void SetAuditColumnVisibility(bool value)
        {

        }

        public void SetCategoryColumnVisibility(bool value)
        {

        }

        public void AppendMessage(AnalogyLogMessage message, string dataSource)
        {
            messages.Add(message);
        }

        public void AppendMessages(List<AnalogyLogMessage> message, string dataSource)
        {
            messages.AddRange(message);
            IsLoaded = true;
        }

        public void AppendMessage(DataRow dtr, string dataSource)
        {
            AnalogyLogMessage message = (AnalogyLogMessage)dtr["Object"];
            AppendMessage(message, dataSource);
        }
    }
}
