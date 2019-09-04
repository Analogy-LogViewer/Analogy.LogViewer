using Philips.Analogy.Interfaces.Interfaces;
using System.Collections.Generic;

namespace Philips.Analogy.Interfaces
{
    public class EmptyUserControlsFactory : IAnalogyUserControlFactory
    {
        public string Title => "Empty User Controls";

        public IEnumerable<IAnalogyUserControl> Items => new List<IAnalogyUserControl>(0);
    }
}
