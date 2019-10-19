using System;
using System.Collections.Generic;

namespace Analogy.Interfaces.Factories
{
    public interface IAnalogyFactory
    {
        /// <summary>
        /// Fixed Unique Guid that will be used as The Id of the Factory 
        /// </summary>
        Guid FactoryID { get; }
        string Title { get; }
        /// <summary>
        /// Factory to Generate offline and real time data sources
        /// </summary>
        IAnalogyDataProvidersFactory DataProviders { get; }
        /// <summary>
        /// Actions factory. Use EmptyActionsFactory if not needed 
        /// </summary>
        IAnalogyCustomActionsFactory Actions { get; }
        IEnumerable<IAnalogyChangeLog> ChangeLog { get; }
        IEnumerable<string> Contributors { get; }
        string About { get; }
    }

}
