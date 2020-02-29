using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Analogy.Managers;
using MessagePack;
using Newtonsoft.Json;

namespace Analogy.LogLoaders
{
    public class AnalogyMessagePackFormat
    {

        public async Task<IEnumerable<AnalogyLogMessage>> ReadFromFile(string fileName, CancellationToken token, ILogMessageCreatedHandler messageHandler)
        {

            if (string.IsNullOrEmpty(fileName))
            {
                AnalogyLogMessage empty = new AnalogyLogMessage($"File is null or empty. Aborting.",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                {
                    Source = "Analogy",
                    Module = Process.GetCurrentProcess().ProcessName
                };
                messageHandler.AppendMessage(empty, Utils.GetFileNameAsDataSource(fileName));
                return new List<AnalogyLogMessage>() { empty };
            }

            return await Task<IEnumerable<AnalogyLogMessage>>.Factory.StartNew(() =>
            {
                try
                {
                    byte[] data = File.ReadAllBytes(fileName);
                    var messages = MessagePackSerializer.Deserialize < List<AnalogyLogMessage>>(data, MessagePack.Resolvers.ContractlessStandardResolver.Options);
                    messageHandler.AppendMessages(messages, Utils.GetFileNameAsDataSource(fileName));
                    return messages;
                }
                catch (Exception ex)
                {

                    AnalogyLogMessage empty =
                        new AnalogyLogMessage($"File {fileName} is empty or corrupted. Error: {ex.Message}",
                            AnalogyLogLevel.Error, AnalogyLogClass.General, "Analogy", "None")
                        {
                            Source = "Analogy",
                            Module = Process.GetCurrentProcess().ProcessName
                        };
                    AnalogyLogManager.Instance.LogErrorMessage(empty);
                    messageHandler.AppendMessage(empty, Utils.GetFileNameAsDataSource(fileName));
                    return new List<AnalogyLogMessage>() { empty };
                }
            }, token);

        }

        public Task Save(List<AnalogyLogMessage> messages, string fileName)
            => Task.Factory.StartNew(() =>
            {
           
                var data = MessagePackSerializer.Serialize(messages, MessagePack.Resolvers.ContractlessStandardResolver.Options);
                //write string to file
                File.WriteAllBytes(fileName, data);
            });
    }
}
