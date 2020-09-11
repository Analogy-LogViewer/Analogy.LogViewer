using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Analogy.Interfaces;
using Analogy.Managers;

namespace Analogy.LogLoaders
{
    public class AnalogyXmlLogFile
    {
        public AnalogyXmlLogFile()
        {
            
        }
        public Task Save(List<AnalogyLogMessage> messages, string filename)
            => Task.Factory.StartNew(() =>
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<AnalogyLogMessage>));
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    ser.Serialize(fs, messages);
                }
            });

        public Task<List<AnalogyLogMessage>> ReadFromFile(string filename) =>
            Task.Factory.StartNew(() =>
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<AnalogyLogMessage>));
                using (FileStream fs = new FileStream(@filename, FileMode.Open,FileAccess.ReadWrite))
                {
                    try
                    {
                        return (List<AnalogyLogMessage>)ser.Deserialize(fs);
                    }
                    catch (Exception e)
                    {
                        AnalogyLogMessage errMessage = new AnalogyLogMessage(
                            $"Error reading file {filename}: {e.Message}", AnalogyLogLevel.Critical,
                            AnalogyLogClass.General, "Analogy", "None")
                        {
                            Source = "Analogy",
                            Module = Process.GetCurrentProcess().ProcessName
                        };
                        AnalogyLogManager.Instance.LogErrorMessage(errMessage);
                        return new List<AnalogyLogMessage>() { errMessage };
                    }

                }
            });
        internal Task<List<AnalogyLogMessage>> ReadFromFile(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
        {
            return Task.Factory.StartNew(() =>
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<AnalogyLogMessage>));
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    try
                    {
                        var messages = (List<AnalogyLogMessage>)ser.Deserialize(fs);
                        messagesHandler.AppendMessages(messages, fileName);
                        return messages;
                    }
                    catch (Exception e)
                    {
                        AnalogyLogMessage errMessage = new AnalogyLogMessage(
                            $"Error reading file {fileName}: {e.Message}", AnalogyLogLevel.Critical,
                            AnalogyLogClass.General, "Analogy", "None")
                        {
                            Source = "Analogy",
                            Module = Process.GetCurrentProcess().ProcessName
                        };
                        AnalogyLogManager.Instance.LogErrorMessage(errMessage);
                        messagesHandler.AppendMessage(errMessage, fileName);
                        return new List<AnalogyLogMessage>() { errMessage };
                    }
                }
            }, token);
        }
    }
}
