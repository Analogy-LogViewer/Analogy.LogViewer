using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Analogy.Interfaces;

namespace Analogy.Implementation.KafkaProvider
{
    public class TimerMessagesSimulator
    {
        private int messageCount = 0;
        private readonly Timer SimulateOnlineMessages;
        readonly Random random = new Random();
        readonly Array values = Enum.GetValues(typeof(AnalogyLogLevel));
        private Action<AnalogyLogMessage> ActionPerTick { get; }
        public TimerMessagesSimulator(Action<AnalogyLogMessage> action)
        {
            ActionPerTick = action;
            SimulateOnlineMessages = new Timer(100);
            SimulateOnlineMessages.Elapsed += (s, e) =>
            {
                unchecked
                {
                    AnalogyLogLevel randomLevel = (AnalogyLogLevel)values.GetValue(random.Next(values.Length));
                    AnalogyLogMessage m = new AnalogyLogMessage($"Generated message #{messageCount++}", randomLevel, AnalogyLogClass.General, "Example");
                    ActionPerTick(m);
                }
            };
        }

        public void Start() => SimulateOnlineMessages.Start();
    }
}
