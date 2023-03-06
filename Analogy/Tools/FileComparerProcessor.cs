using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Analogy.Common.Interfaces;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;

namespace Analogy.Tools
{

    public class FileComparerProcessor : ILogMessageCreatedHandler,ILogWindow
    {
        public bool DoNotAddToRecentHistory { get; set; } = false;
        public bool ForceNoFileCaching { get; set; } = false;
        private List<IAnalogyLogMessage> messages;
        public string FileName { get; }
        public FileComparerProcessor(string filename)
        {
            FileName = filename;
            messages = new List<IAnalogyLogMessage>();
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

        public void AppendMessage(IAnalogyLogMessage message, string dataSource)
        {
            messages.Add(message);
        }

        public void AppendMessages(List<IAnalogyLogMessage> message, string dataSource)
        {
            messages.AddRange(message);
            IsLoaded = true;
        }

        public void AppendMessage(DataRow dtr, string dataSource)
        {
            AnalogyLogMessage message = (AnalogyLogMessage)dtr[Common.CommonUtils.AnalogyMessageColumn];
            AppendMessage(message, dataSource);
        }
        public void ReportFileReadProgress(AnalogyFileReadProgress progress)
        {
            //noop
        }

        public List<IAnalogyLogMessage> GetMessages()
        {
            return messages;
        }
    }
}
