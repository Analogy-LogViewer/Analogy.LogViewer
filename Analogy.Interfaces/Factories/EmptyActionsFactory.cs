using System.Collections.Generic;

namespace Analogy.Interfaces.Factories
{
    public class EmptyActionsFactory : IAnalogyCustomActionsFactory
    {
        public string Title => "Empty Actions";
        /// <summary>
        /// Empty list of Action
        /// </summary>
        public IEnumerable<IAnalogyCustomAction> Items => new List<IAnalogyCustomAction>(0);
    }
}
