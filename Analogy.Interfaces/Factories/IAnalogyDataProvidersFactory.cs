using System.Collections.Generic;

namespace Analogy.Interfaces.Factories
{
    public interface IAnalogyDataProvidersFactory
    {
        string Title { get; }
        IEnumerable<IAnalogyDataProvider> Items { get; }
    }
}
