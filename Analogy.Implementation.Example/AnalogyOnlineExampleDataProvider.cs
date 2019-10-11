using Philips.Analogy.Interfaces;
using System;
using System.Threading.Tasks;
using System.Timers;
using Philips.Analogy.Interfaces.DataTypes;

namespace Analogy.Implementation.Example
{
    class AnalogyOnlineExampleDataProvider : IAnalogyRealTimeDataProvider
    {
        public Guid ID => new Guid("6642B160-F992-4120-B688-B02DE2E83256");

        public bool AutoStartAtLaunch => true;

        public System.Drawing.Image OptionalDisconnectedImage => null;//throw new NotImplementedException();

        public System.Drawing.Image OptionalConnectedImage => null;//throw new NotImplementedException();

        public event EventHandler<AnalogyDataSourceDisconnectedArgs> OnDisconnected;
        public event EventHandler<AnalogyLogMessageArgs> OnMessageReady;
        public event EventHandler<AnalogyLogMessagesArgs> OnManyMessagesReady;

        public async Task<bool> CanStartReceiving() => await Task.FromResult(true);

        public IAnalogyOfflineDataProvider FileOperationsHandler { get; }
        private Timer SimulateOnlineMessages;
        private int messageCount = 0;
        public void InitDataProvider()
        {
            SimulateOnlineMessages = new Timer(100);
            SimulateOnlineMessages.Elapsed += (s, e) =>
            {
                if (OnMessageReady == null)
                    return;
                unchecked
                {
                    AnalogyLogMessage m = new AnalogyLogMessage($"Generated message #{messageCount++}", AnalogyLogLevel.Event, AnalogyLogClass.General, "Example");
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
