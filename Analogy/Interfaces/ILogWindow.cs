using System.Collections.Generic;

namespace Analogy.Interfaces
{
    public interface ILogWindow
    {

        List<AnalogyLogMessage> GetMessages();
    }
}
