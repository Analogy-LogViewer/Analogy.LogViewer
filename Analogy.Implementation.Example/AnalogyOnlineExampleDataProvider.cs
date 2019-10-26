using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Analogy.Interfaces;

namespace Analogy.Implementation.Example
{
    class AnalogyOnlineExampleDataProvider : IAnalogyRealTimeDataProvider
    {
        public Guid ID => new Guid("6642B160-F992-4120-B688-B02DE2E83256");

        public bool AutoStartAtLaunch => true;
        public bool IsConnected => true;
        public event EventHandler<AnalogyDataSourceDisconnectedArgs> OnDisconnected;
        public event EventHandler<AnalogyLogMessageArgs> OnMessageReady;
        public event EventHandler<AnalogyLogMessagesArgs> OnManyMessagesReady;

        public async Task<bool> CanStartReceiving() => await Task.FromResult(true);

        public IAnalogyOfflineDataProvider FileOperationsHandler { get; }
        private Timer SimulateOnlineMessages;
        private int messageCount = 0;
        readonly Random random = new Random();
        readonly Array values = Enum.GetValues(typeof(AnalogyLogLevel));
        private readonly List<string> processes = Process.GetProcesses().Select(p => p.ProcessName).ToList();
        public void InitDataProvider()
        {
            SimulateOnlineMessages = new Timer(100);

            SimulateOnlineMessages.Elapsed += (s, e) =>
            {
                if (OnMessageReady == null)
                    return;
                unchecked
                {

                    AnalogyLogLevel randomLevel = (AnalogyLogLevel)values.GetValue(random.Next(values.Length));
                    string randomProcess = processes[random.Next(processes.Count)];
                    AnalogyLogMessage m = new AnalogyLogMessage
                    {
                        Text = $"Generated message #{messageCount++}",
                        Level = randomLevel,
                        Class = AnalogyLogClass.General,
                        Source = "Example",
                        Module = randomProcess
                    };

                    OnMessageReady(this, new AnalogyLogMessageArgs(m, Environment.MachineName, "Example", ID));
                }
            };
        }

        public void StartReceiving()
        {
            InitDataProvider();
            SimulateOnlineMessages?.Start();
        }

        public void StopReceiving()
        {
            SimulateOnlineMessages?.Stop();
            OnDisconnected?.Invoke(this, new AnalogyDataSourceDisconnectedArgs("user disconnected", Environment.MachineName, ID));
        }
    }
}
