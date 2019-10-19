using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Confluent.Kafka;

namespace Analogy.Implementation.KafkaProvider
{
    public class KafkaConsumer
    {
        private string KafkaServerURL { get; set; }
        private string Topic { get; set; }
        private ConsumerConfig Config { get; set; }
        public event EventHandler<AnalogyKafkaLogMessageArgs> OnMessageReady;
        public BlockingCollectionQueue<AnalogyLogMessage> Queue;
        private CancellationTokenSource cts;
        public KafkaConsumer(string kafkaServerURL, string topic)
        {
            cts = new CancellationTokenSource();
            Queue = new BlockingCollectionQueue<AnalogyLogMessage>();
            KafkaServerURL = kafkaServerURL;
            Topic = topic;
            Config = new ConsumerConfig
            {
                GroupId = "AnalogyKafkaLogin",
                BootstrapServers = KafkaServerURL,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };


        }

        public Task StartConsuming()
        {
            return Task.Factory.StartNew(() =>
             {
                 using (var c = new ConsumerBuilder<Ignore, AnalogyLogMessage>(Config).Build())
                 {
                     c.Subscribe(Topic);
                     try
                     {
                         while (true)
                         {
                             try
                             {
                                 var cr = c.Consume(cts.Token);
                                 Queue.Enqueue(cr.Value);
                             }
                             catch (TaskCanceledException ce)
                             {
                                 Queue.Enqueue(new AnalogyLogMessage($"Consuming Canceled", AnalogyLogLevel.AnalogyInformation, AnalogyLogClass.General, Environment.MachineName));
                                 Queue.CompleteAdding();
                                 return;
                             }
                             catch (ConsumeException e)
                             {
                                 Queue.Enqueue(new AnalogyLogMessage($"Error occurred: {e.Error.Reason}", AnalogyLogLevel.Critical, AnalogyLogClass.General, Environment.MachineName));
                             }
                         }
                     }
                     catch (OperationCanceledException)
                     {
                         // Ensure the consumer leaves the group cleanly and final offsets are committed.
                         c.Close();
                     }
                 }
             });

        }

        public void StopConsuming()
        {
            cts.Cancel();
        }

        public void ReadMessages()
        {
            foreach (var item in Queue.GetConsumingEnumerable(cts.Token))
            {
                OnMessageReady?.Invoke(this, new AnalogyKafkaLogMessageArgs(item));
            }
        }
    }
}
