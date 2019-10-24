using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Interfaces;

namespace Analogy.Managers
{
    internal class FilePoolingManager : ILogMessageCreatedHandler
    {
        private string FileName { get; }
        private FileProcessor FileProcessor { get; }
        private IAnalogyOfflineDataProvider OfflineDataProvider { get; }
        private readonly CancellationTokenSource cancellationTokenSource;
        private readonly List<AnalogyLogMessage> messages;
        public EventHandler<(List<AnalogyLogMessage> messages, string dataSource)> OnNewMessages;
        private readonly object sync;
        public FilePoolingManager(string fileName, IAnalogyOfflineDataProvider offlineDataProvider)
        {
            sync = new object();
            cancellationTokenSource = new CancellationTokenSource();
            OfflineDataProvider = offlineDataProvider;
            messages = new List<AnalogyLogMessage>();
            FileName = fileName;
            FileProcessor = new FileProcessor(this);
        }


        public Task Init()
        {
            return FileProcessor.Process(OfflineDataProvider, FileName, cancellationTokenSource.Token);
        }

        public void AppendMessage(AnalogyLogMessage message, string dataSource)
        {
            lock (sync)
            {
                if (!messages.Contains(message))
                {
                    messages.Add(message);
                    OnNewMessages?.Invoke(this, (new List<AnalogyLogMessage> { message }, dataSource));
                }
            }
        }

        public void AppendMessages(List<AnalogyLogMessage> messagesFromFile, string dataSource)
        {

            lock (sync)
            {
                var newMessages = messagesFromFile.Except(messages).ToList();
                if (newMessages.Any())
                {
                    messages.AddRange(newMessages);
                    OnNewMessages?.Invoke(this, (newMessages, dataSource));
                }
            }
        }
    }
}

