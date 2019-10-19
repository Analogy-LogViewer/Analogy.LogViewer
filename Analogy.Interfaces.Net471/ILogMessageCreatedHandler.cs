using System.Collections.Generic;
using Philips.Analogy.Interfaces.DataTypes;

namespace Philips.Analogy.Interfaces
{
    public interface ILogMessageCreatedHandler
    {

        void AppendMessage(AnalogyLogMessage message, string dataSource);
        void AppendMessages(List<AnalogyLogMessage> messages, string dataSource);

    }
}
