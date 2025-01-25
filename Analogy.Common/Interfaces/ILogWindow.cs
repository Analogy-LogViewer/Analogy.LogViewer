using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using System;
using System.Collections.Generic;

namespace Analogy.Common.Interfaces
{
    public interface ILogWindow
    {
        List<IAnalogyLogMessage> GetMessages();
        Guid Id { get; }
    }
}