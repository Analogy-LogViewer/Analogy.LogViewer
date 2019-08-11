using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Philips.Analogy.Interfaces;
using Philips.Analogy.Interfaces.Interfaces;

namespace Philips.Analogy.LogLoaders
{
 
    public class AnalogyJsonLogFile 
    {

        public async Task<IEnumerable<AnalogyLogMessage>> ReadFromFile(string fileName, CancellationToken token, ILogMessageCreatedHandler messageHandler)
        {
            
            if (string.IsNullOrEmpty(fileName))
            {
                AnalogyLogMessage empty = new AnalogyLogMessage($"File is null or empty. Aborting.", AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None");
                empty.Source = "Analogy";
                empty.Module = Process.GetCurrentProcess().ProcessName;
                messageHandler.AppendMessage(empty, Utils.GetFileNameAsDataSource(fileName));
                return new List<AnalogyLogMessage>() { empty };
            }

            return await Task<IEnumerable<AnalogyLogMessage>>.Factory.StartNew(() =>
            {
                try
                {
                    string data = File.ReadAllText(fileName);
                    List<AnalogyLogMessage> messages = JsonConvert.DeserializeObject<List<AnalogyLogMessage>>(data);
                    messageHandler.AppendMessages(messages, Utils.GetFileNameAsDataSource(fileName));
                    return messages;
                }
                catch (Exception ex)
                {

                    AnalogyLogMessage empty = new AnalogyLogMessage($"File {fileName} is empty or corrupted. Error: {ex.Message}", AnalogyLogLevel.Error, AnalogyLogClass.General, "Analogy", "None");
                    empty.Source = "Analogy";
                    empty.Module = Process.GetCurrentProcess().ProcessName;

                    messageHandler.AppendMessage(empty, Utils.GetFileNameAsDataSource(fileName));
                    return new List<AnalogyLogMessage>() { empty };
                }
            },token);

        }

        public Task Save(List<AnalogyLogMessage> messages, string fileName)
            => Task.Factory.StartNew(() =>
            {
                string json = JsonConvert.SerializeObject(messages);

                //write string to file
                File.WriteAllText(fileName, json);
               
            });


    }
}

