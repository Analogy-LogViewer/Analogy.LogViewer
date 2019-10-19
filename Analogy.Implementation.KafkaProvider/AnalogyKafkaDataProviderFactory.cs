using System;
using System.Collections.Generic;
using System.Text;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;

namespace Analogy.Implementation.KafkaProvider
{
    public class AnalogyKafkaDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public string Title { get; } = "Analogy Kafka Providers";
        public IEnumerable<IAnalogyDataProvider> Items { get; set; } = new List<IAnalogyDataProvider> { new AnalogyKafkaDataProvider() };
    }
}
