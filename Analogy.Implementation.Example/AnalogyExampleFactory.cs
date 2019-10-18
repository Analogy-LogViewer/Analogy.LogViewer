using System;
using System.Collections.Generic;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;

namespace Analogy.Implementation.Example
{
    public class AnalogyExampleFactory : IAnalogyFactory
    {
        public Guid FactoryID => new Guid("4B1EBC0F-64DD-44A1-BC27-79DBFC6384CC");

        public string Title => "Analogy Examples";

        public IAnalogyDataProvidersFactory DataProviders { get; } = new AnalogyDataProviderFactory();

        public IAnalogyCustomActionsFactory Actions => null;

        public IEnumerable<IAnalogyChangeLog> ChangeLog { get; } = new List<AnalogyChangeLog>
        {
            new AnalogyChangeLog("Create example implementation",AnalogChangeLogType.None, "Lior Banai",new DateTime(2019, 08, 15)),
            new AnalogyChangeLog("Add Thread ID",AnalogChangeLogType.None, "Lior Banai",new DateTime(2019, 08, 20)),
            new AnalogyChangeLog("Add File handler for online data source (aligned with new interface)",AnalogChangeLogType.None, "Lior Banai",new DateTime(2019, 09, 09))
        };
        public IEnumerable<string> Contributors { get; } = new List<string> { "Lior Banai" };
        public string About { get; } = "Analogy Example Data Source";
    }
}
