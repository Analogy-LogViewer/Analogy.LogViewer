using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;

namespace Analogy.CommonControls.Interfaces
{
    public interface ILogWindow
    {
        List<AnalogyLogMessage> GetMessages();
    }
}
