using Philips.Analogy.Interfaces.Factories;
using System.Collections.Generic;
using Philips.Analogy.Interfaces;

namespace Analogy.Implementation.Example
{
    public class AnalogyDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public string Title => "Analogy Online example";

        public IEnumerable<IAnalogyDataProvider> Items => new List<IAnalogyDataProvider> { new AnalogyOnlineExampleDataProvider() };
    }
}
