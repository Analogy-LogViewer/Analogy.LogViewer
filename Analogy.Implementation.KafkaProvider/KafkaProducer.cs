using System;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Confluent.Kafka;

namespace Analogy.Implementation.KafkaProvider
{
    public class KafkaProducer
    {
        private string KafkaServerURL { get; set; }
        private string Topic { get; set; }
        private ProducerConfig Config { get; set; }
        public Action<DeliveryReport<Null, AnalogyLogMessage>> ReportHandler;
        public KafkaProducer(string kafkaServerURL, string topic)
        {
            KafkaServerURL = kafkaServerURL;
            Topic = topic;
            Config = new ProducerConfig
            {
                BootstrapServers = KafkaServerURL,
            };
            ReportHandler = r =>
                Console.WriteLine(!r.Error.IsError
                    ? $"Delivered message to {r.TopicPartitionOffset}"
                    : $"Delivery Error: {r.Error.Reason}");
        }

        public async Task<DeliveryResult<Null, AnalogyLogMessage>> PublishAsync(AnalogyLogMessage message)
        {
            using (var p = new ProducerBuilder<Null, AnalogyLogMessage>(Config).Build())
            {
                DeliveryResult<Null, AnalogyLogMessage> dr = await p.ProduceAsync(Topic, new Message<Null, AnalogyLogMessage> { Value = message });
                return dr;
            }
        }

        public void Publish(AnalogyLogMessage message)
        {
            using (var p = new ProducerBuilder<Null, AnalogyLogMessage>(Config).Build())
            {
                p.Produce(Topic, new Message<Null, AnalogyLogMessage> { Value = message }, ReportHandler);
            }
        }

    }
}
