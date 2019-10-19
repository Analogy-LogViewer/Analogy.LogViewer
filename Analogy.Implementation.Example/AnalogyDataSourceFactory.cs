using System.Collections.Generic;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;

namespace Analogy.Implementation.Example
{
    public class AnalogyDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public string Title => "Analogy Online example";

        public IEnumerable<IAnalogyDataProvider> Items => new List<IAnalogyDataProvider> { new AnalogyOnlineExampleDataProvider() };
    }
}
