using System.Collections.Generic;

namespace Philips.Analogy.Interfaces.Interfaces
{
    public interface ILogMessageCreatedHandler
    {

        void AppendMessage(AnalogyLogMessage message, string dataSource);
        void AppendMessages(List<AnalogyLogMessage> messages, string dataSource);

    }
}
