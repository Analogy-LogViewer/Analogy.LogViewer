using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philips.Analogy.Interfaces.Interfaces
{
    public interface IAnalogyFactories
    {
        Guid FactoryID { get; }
        string Title { get; }
        IAnalogyDataSourceFactory DataSources { get; }
        IAnalogyCustomActionFactory Actions { get; }
        IAnalogyUserControlFactory UserControls { get; }
        IEnumerable<IAnalogyChangeLog> ChangeLog { get; }
        IEnumerable<string> Contributors { get; }
        string About { get; }
    }

}
