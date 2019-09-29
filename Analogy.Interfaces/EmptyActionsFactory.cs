using Philips.Analogy.Interfaces.Interfaces;
using System.Collections.Generic;

namespace Philips.Analogy.Interfaces
{
    public class EmptyActionsFactory : IAnalogyCustomActionFactory
    {
        public string Title => "Empty Actions";
        /// <summary>
        /// Empty list of Action
        /// </summary>
        public IEnumerable<IAnalogyCustomAction> Items => new List<IAnalogyCustomAction>(0);
    }
}
