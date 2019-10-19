using System;
using System.Collections.Generic;
using System.Text;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;

namespace Analogy.Implementation.KafkaProvider
{
    public class AnalogyKafkaFactory : IAnalogyFactory
    {
        public Guid FactoryID { get; } = Guid.Parse("FC2115F6-058A-430B-8E41-385E7A3DF3A9");
        public string Title { get; } = "Analogy Kafka Provider";
        public IAnalogyDataProvidersFactory DataProviders { get; } = new AnalogyKafkaDataProviderFactory();
        public IAnalogyCustomActionsFactory Actions { get; } = null;
        public IEnumerable<string> Contributors { get; } = new List<string>() { "Lior Banai" };
        public string About { get; } = "Kafka Provider for Analogy";

        public IEnumerable<IAnalogyChangeLog> ChangeLog { get; } = new List<AnalogyChangeLog>
        {
            new AnalogyChangeLog("Create Initial implementation",AnalogChangeLogType.None, "Lior Banai",new DateTime(2019, 10, 19))
        };
    }
}
