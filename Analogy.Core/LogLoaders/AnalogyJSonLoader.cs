using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Interfaces;

namespace Analogy.LogLoaders
{

    public class AnalogyJsonLogFile
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
                    string data = string.Empty;
                    using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var textReader = new StreamReader(fileStream))
                    {
                        data = textReader.ReadToEnd();
                    }
                    List<AnalogyLogMessage> messages = System.Text.Json.JsonSerializer.Deserialize<List<AnalogyLogMessage>>(data);
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

                    messageHandler.AppendMessage(empty, Utils.GetFileNameAsDataSource(fileName));
                    return new List<AnalogyLogMessage>() { empty };
                }
            }, token);

        }

        public Task Save(List<AnalogyLogMessage> messages, string fileName)
            => Task.Factory.StartNew(() =>
            {
                string json = System.Text.Json.JsonSerializer.Serialize(messages);

                //write string to file
                File.WriteAllText(fileName, json);

            });


    }
}

