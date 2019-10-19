using System;

namespace Analogy.Interfaces
{
    public interface IAnalogyCustomAction
    {
        Action Action { get; }
        Guid ID { get; }
        string Title { get; }
    }
}
