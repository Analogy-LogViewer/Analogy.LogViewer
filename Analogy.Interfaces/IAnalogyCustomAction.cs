using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Philips.Analogy.Interfaces
{
    public interface IAnalogyCustomAction
    {
        Action Action { get; }
        Guid ID { get; }
        System.Drawing.Image Image { get; } 
        string Title { get; }
    }
}
