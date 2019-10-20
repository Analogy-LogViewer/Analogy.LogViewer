using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;

namespace Analogy.Implementation.KafkaProvider
{
    public class AnalogyKafkaExampleDataProvider : IAnalogyRealTimeDataProvider
    {
        public Guid ID { get; } = Guid.Parse("F1283D38-01B9-4753-996B-3CEF4312D7E2");

        public event EventHandler<AnalogyDataSourceDisconnectedArgs> OnDisconnected;
        public event EventHandler<AnalogyLogMessageArgs> OnMessageReady;
        public event EventHandler<AnalogyLogMessagesArgs> OnManyMessagesReady;
        public IAnalogyOfflineDataProvider FileOperationsHandler { get; }
        public bool IsConnected { get; private set; }
        public KafkaConsumer Consumer { get; set; }
        public KafkaProducer Producer { get; set; }
        public string topic = "KafkaLog";
        public string kafkaUrl = "localhost:9092";
        public Task<bool> CanStartReceiving() => Task.FromResult(IsConnected);
        private TimerMessagesSimulator sim;
        private Task Consuming;
        private Task Reading;
        public AnalogyKafkaExampleDataProvider()
        {

        }
        public void StartReceiving()
        {
            sim.Start();
            Consuming = Consumer.StartConsuming();
            Reading = Consumer.ReadMessages();

        }

        public void StopReceiving()
        {
            Consumer.StopConsuming();
        }

        public void InitDataProvider()
        {

            Producer = new KafkaProducer(kafkaUrl, topic);
            Consumer = new KafkaConsumer(kafkaUrl, topic);
            Consumer.OnMessageReady += Consumer_OnMessageReady;
            sim = new TimerMessagesSimulator(async m => { await Producer.PublishAsync(m); });
            IsConnected = true;

        }

        private void Consumer_OnMessageReady(object sender, AnalogyKafkaLogMessageArgs e)
        {
            OnMessageReady?.Invoke(sender, new AnalogyLogMessageArgs(e.Message, Environment.MachineName, Environment.MachineName, ID));
        }

    }
}
