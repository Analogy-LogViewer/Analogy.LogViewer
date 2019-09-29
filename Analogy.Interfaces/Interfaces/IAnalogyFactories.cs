using System;
using System.Collections.Generic;

namespace Philips.Analogy.Interfaces.Interfaces
{
    public interface IAnalogyFactories
    {
        /// <summary>
        /// Fixed Unique Guid that will be used as The Id of the Factory 
        /// </summary>
        Guid FactoryID { get; }
        string Title { get; }
        /// <summary>
        /// Factory to Generate offline and real time data sources
        /// </summary>
        IAnalogyDataSourceFactory DataSources { get; }
        /// <summary>
        /// Actions factory (non UI). Use EmptyActionsFactory if not needed 
        /// </summary>
        IAnalogyCustomActionFactory Actions { get; }
        /// <summary>
        /// Actions factory (user controls).  
        /// </summary>
        IAnalogyUserControlFactory UserControls { get; }
        IEnumerable<IAnalogyChangeLog> ChangeLog { get; }
        IEnumerable<string> Contributors { get; }
        string About { get; }
    }

}
