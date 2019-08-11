using Newtonsoft.Json;
using Philips.Analogy.Interfaces;
using System;
using System.IO;

namespace Philips.Analogy.Tools
{
    internal class JsonFormatter
    {
        private readonly string _fileName;

        public JsonFormatter(string fileName)
        {
            this._fileName = fileName;
        }

        //public void WriteMessage(byte[] data)
        //{
        //    this.WriteMessage(AnalogyLogMessage.Deserialize(data));
        //}

        public void WriteMessage(AnalogyLogMessage message)
        {
            string jsonMessage;
            this.WriteMessage(message, out jsonMessage);
        }

        public void WriteMessage(AnalogyLogMessage message, out string jsonMessage)
        {
            JsonDataContract jsonDataContract = new JsonDataContract(message);
            jsonMessage = JsonConvert.SerializeObject(jsonDataContract);
            File.AppendAllText(this._fileName, jsonMessage + "\r\n");
        }
    }

    internal class JsonDataContract
    {
        public string category;
        public DateTime dateTime;
        public string fileName;
        public string host;
        public string id;
        public string level;
        public string lineNumber;
        public string logClass;
        public string method;
        public string module;
        public string processId;
        public string source;
        public string text;
        public string user;

        public JsonDataContract(AnalogyLogMessage message)
        {
            this.id = message.ID.ToString();
            this.dateTime = message.Date;
            this.text = message.Text;
            this.category = message.Category;
            this.source = message.Source;
            this.level = message.Level.ToString();
            this.logClass = message.Class.ToString();
            this.module = message.Module;
            this.method = message.MethodName;
            this.fileName = message.FileName;
            this.lineNumber = message.LineNumber.ToString();
            this.processId = message.ProcessID.ToString();
            this.user = message.User;
            this.host = Environment.MachineName;
        }
    }
}

