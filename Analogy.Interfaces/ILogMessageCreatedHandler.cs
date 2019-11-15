using System.Collections.Generic;

namespace Analogy.Interfaces
{
    public interface ILogMessageCreatedHandler
    {
        bool ForceNoFileCaching { get; set; }
        bool DoNotAddToRecentHistory { get; set; }
        void AppendMessage(AnalogyLogMessage message, string dataSource);
        void AppendMessages(List<AnalogyLogMessage> messages, string dataSource);

    }
}
