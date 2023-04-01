using System;
using System.Collections.Generic;
using Analogy.Interfaces;

namespace Analogy.Common.Interfaces
{
    public interface ILogWindow
    {
        List<IAnalogyLogMessage> GetMessages();
        Guid Id { get; }
    }
}
