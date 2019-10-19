using System.Collections.Generic;

namespace Analogy.Interfaces.Factories
{
    public interface IAnalogyCustomActionsFactory
    {
        string Title { get; }
        IEnumerable<IAnalogyCustomAction> Items { get; }
    }
}
