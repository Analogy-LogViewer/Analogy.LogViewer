using System.Collections.Generic;

namespace Analogy.Interfaces
{
    public interface ILogMessageCreatedHandler
    {

        void AppendMessage(AnalogyLogMessage message, string dataSource);
        void AppendMessages(List<AnalogyLogMessage> messages, string dataSource);

    }
}
