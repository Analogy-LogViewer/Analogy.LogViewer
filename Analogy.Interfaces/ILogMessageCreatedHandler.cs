using System.Collections.Generic;

namespace Analogy.Interfaces
{
    public interface ILogMessageCreatedHandler
    {
        bool ForceNoFileCaching { get; }

        void AppendMessage(AnalogyLogMessage message, string dataSource);
        void AppendMessages(List<AnalogyLogMessage> messages, string dataSource);

    }
}
