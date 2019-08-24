using Philips.Analogy.Interfaces;
using Philips.Analogy.Interfaces.Interfaces;
using System;
using System.Collections.Generic;

namespace Analogy.Implementation.Example
{
    public class AnalogyExampleFactory : IAnalogyFactories
    {
        public Guid FactoryID => new Guid("4B1EBC0F-64DD-44A1-BC27-79DBFC6384CC");

        public string Title => "Analogy Examples";

        public IAnalogyDataSourceFactory DataSources { get; } = new AnalogyDataSourceFactory();

        public IAnalogyCustomActionFactory Actions => null;

        public IAnalogyUserControlFactory UserControls => null;

        public IEnumerable<IAnalogyChangeLog> ChangeLog { get; } = new List<AnalogyChangeLog>
        {
            new AnalogyChangeLog("Create example implementation",AnalogChangeLogType.None, "Lior Banai",new DateTime(2019, 08, 15)),
            new AnalogyChangeLog("Add Thread ID",AnalogChangeLogType.None, "Lior Banai",new DateTime(2019, 08, 20))
        };
        public IEnumerable<string> Contributors { get; } = new List<string> { "Lior Banai" };
        public string About { get; } = "Analogy Example Data Source";
    }
}
