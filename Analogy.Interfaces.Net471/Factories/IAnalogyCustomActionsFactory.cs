using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philips.Analogy.Interfaces.Factories
{
    public interface IAnalogyCustomActionsFactory
    {
        string Title { get; }
        IEnumerable<IAnalogyCustomAction> Items { get; }
    }
}
