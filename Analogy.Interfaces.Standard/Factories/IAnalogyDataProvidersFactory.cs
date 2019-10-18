using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philips.Analogy.Interfaces.Factories
{
    public interface IAnalogyDataProvidersFactory
    {
        string Title { get; }
        IEnumerable<IAnalogyDataProvider> Items { get; }
    }
}
