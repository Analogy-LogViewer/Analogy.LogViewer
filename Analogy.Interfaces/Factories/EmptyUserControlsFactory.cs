using System.Collections.Generic;

namespace Philips.Analogy.Interfaces.Factories
{
    public class EmptyUserControlsFactory : IAnalogyUserControlsFactory
    {
        public string Title => "Empty User Controls";

        public IEnumerable<IAnalogyUserControl> Items => new List<IAnalogyUserControl>(0);
    }
}
