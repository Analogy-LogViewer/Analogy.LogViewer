using Philips.Analogy.Interfaces.Interfaces;
using System.Collections.Generic;

namespace Analogy.Implementation.Example
{
    public class AnalogyDataSourceFactory : IAnalogyDataSourceFactory
    {
        public string Title => "Analogy Online example";

        public IEnumerable<IAnalogyDataSource> Items => new List<IAnalogyDataSource> { new AnalogyOnlineExampleDataSource() };
    }
}
