using System.Collections.Generic;

namespace Analogy.Interfaces
{
    internal interface ILogWindow
    {

        List<AnalogyLogMessage> GetMessages();
    }
}
