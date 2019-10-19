using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Analogy.Interfaces;

namespace Analogy
{
    public class FileProcessor
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;
        private string FileName { get; set; }
        public Stream DataStream { get; set; }
        private ILogMessageCreatedHandler DataWindow { get; set; }
        public UCLogs LogWindow { get; set; }

        public FileProcessor(ILogMessageCreatedHandler dataWindow)
        {
            DataWindow = dataWindow;
        }
        public async Task<IEnumerable<AnalogyLogMessage>> Process(IAnalogyOfflineDataProvider fileDataProvider, string filename, CancellationToken token)
        {
            FileName = filename;
            if (string.IsNullOrEmpty(FileName)) return new List<AnalogyLogMessage>();
            if (FileProcessingManager.Instance.AlreadyProcessed(FileName) && Settings.EnableFileCaching) //get it from the cache
            {
                var msgs = FileProcessingManager.Instance.GetMessages(FileName);
                DataWindow.AppendMessages(msgs, Utils.GetFileNameAsDataSource(FileName));
                return msgs;

            }

            if (FileProcessingManager.Instance.IsFileCurrentlyBeingProcessed(FileName))
            {
                while (FileProcessingManager.Instance.IsFileCurrentlyBeingProcessed(FileName))
                {
                    await Task.Delay(1000);
                }
                var msgs = FileProcessingManager.Instance.GetMessages(FileName);
                DataWindow.AppendMessages(msgs, Utils.GetFileNameAsDataSource(FileName));
                return msgs;

            }
            //otherwise read file:
            FileProcessingManager.Instance.AddProcessingFile(FileName);
            Settings.AddToRecentFiles(fileDataProvider.ID, FileName);
            var messages = await fileDataProvider.Process(filename, token, DataWindow).ConfigureAwait(false);
            FileProcessingManager.Instance.DoneProcessingFile(messages.ToList(), FileName);
            return messages;

        }
        //public async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token)
        //{
        //    FileName = fileName;
        //    if (string.IsNullOrEmpty(FileName)) return new List<AnalogyLogMessage>();

        //    if (IsAuditLogFile())
        //    {
        //        LogWindow.SetAuditColumnVisibility(true);

        //        // This is to set the category column visibility to false since it remains same "AUDIT"
        //        LogWindow.SetCategoryColumnVisibility(false);
        //    }
        //    else
        //    {
        //        LogWindow.SetAuditColumnVisibility(false);
        //    }

        //    if (FileProcessingManager.Instance.AlreadyProcessed(FileName) && Settings.EnableFileCaching) //get it from the cache
        //    {
        //        var messagses = FileProcessingManager.Instance.GetMessages(FileName);
        //        DataWindow.AppendMessages(messagses, Utils.GetFileNameAsDataSource(FileName));
        //        return messagses;

        //    }

        //    if (FileProcessingManager.Instance.IsFileCurrentlyBeingProcessed(FileName))
        //    {
        //        while (FileProcessingManager.Instance.IsFileCurrentlyBeingProcessed(FileName))
        //        {
        //            await Task.Delay(1000);
        //        }
        //        var messagses = FileProcessingManager.Instance.GetMessages(FileName);
        //        DataWindow.AppendMessages(messagses, Utils.GetFileNameAsDataSource(FileName));
        //        return messagses;
        //    }
        //    //otherwise read file:
        //    FileProcessingManager.Instance.AddProcessingFile(FileName);
        //    Settings.AddToRecentFiles(Guid.Empty, FileName);
        //    try
        //    {
        //        if (FileName.EndsWith(".evtx", StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            EventViewerLogLoader logLoader = new EventViewerLogLoader(token);
        //            var messages = await logLoader.ReadFromFile(FileName, DataWindow).ConfigureAwait(false);
        //            FileProcessingManager.Instance.DoneProcessingFile(messages.ToList(), fileName);
        //            return messages;

        //        }
        //        if (FileName.EndsWith("XD.log", StringComparison.InvariantCultureIgnoreCase) ||
        //            FileName.EndsWith("XDDebug.log", StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            MiradaXDLogLoader logLoader = new MiradaXDLogLoader();
        //            var messages = await logLoader.ReadFromFile(FileName, DataWindow).ConfigureAwait(false);
        //            FileProcessingManager.Instance.DoneProcessingFile(messages.ToList(), fileName);
        //            return messages;
        //        }
        //        if (FileName.EndsWith(".xml", StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            CTXmlLoader logLoader = new CTXmlLoader(token);
        //            var messages = await logLoader.ReadFromFile(FileName, DataWindow).ConfigureAwait(false);
        //            FileProcessingManager.Instance.DoneProcessingFile(messages.ToList(), fileName);
        //            return messages;

        //        }
        //        if (FileName.EndsWith(".etl", StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            ICAPLogLoader logLoader = new ICAPLogLoader();
        //            var messages = await logLoader.ReadFromFile(FileName, DataWindow).ConfigureAwait(false);
        //            FileProcessingManager.Instance.DoneProcessingFile(messages.ToList(), fileName);
        //            return messages;

        //        }

        //        if (FileName.EndsWith(".log", StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            LogLoader logLoader = new LogXmlLoader();
        //            var messages = await logLoader.ReadFromFile(FileName, DataWindow).ConfigureAwait(false);
        //            FileProcessingManager.Instance.DoneProcessingFile(messages.ToList(), fileName);
        //            return messages;
        //        }
        //        if (FileName.EndsWith(".nlog", StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            LogLoader logLoader = new NLogLoader();
        //            var messages = await logLoader.ReadFromFile(FileName, DataWindow).ConfigureAwait(false);
        //            FileProcessingManager.Instance.DoneProcessingFile(messages.ToList(), fileName);
        //            return messages;

        //        }
        //        if (FileName.EndsWith(".json", StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            LogLoader logLoader = new JSonLoader();
        //            var messages = await logLoader.ReadFromFile(FileName, DataWindow).ConfigureAwait(false);
        //            FileProcessingManager.Instance.DoneProcessingFile(messages.ToList(), fileName);
        //            return messages;
        //        }
        //        else
        //        {
        //            AnalogyLogMessage m = new AnalogyLogMessage();
        //            m.Text = $"Incorrect file: {FileName}. Skipping file";
        //            m.Level = LogLevel.Critical;
        //            m.Source = "Analogy";
        //            m.Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
        //            m.ProcessID = System.Diagnostics.Process.GetCurrentProcess().Id;
        //            m.Class = LogClass.General;
        //            m.User = Environment.UserName;
        //            m.Date = DateTime.Now;
        //            FileProcessingManager.Instance.DoneProcessingFile(new List<AnalogyLogMessage>(0), FileName);
        //            DataWindow.AppendMessage(m, Environment.MachineName);
        //            return new List<AnalogyLogMessage>();
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error occured:" + ex);
        //    }
        //    return new List<AnalogyLogMessage>();
        //}

        private bool IsAuditLogFile()
        {
            bool isAuditLogFile = false;
            try
            {
                if (DataStream == null)
                {
                    return false;
                }
                //audit log file is of the format .log. Hence return false if the file in question is an etl file
                if (FileName.EndsWith(".etl"))
                {
                    return false;
                }

                XmlNodeType ndType = XmlNodeType.Element;
                XmlParserContext xp = new XmlParserContext(null, null, null, XmlSpace.Default);
                XmlTextReader xr = new XmlTextReader(DataStream, ndType, xp);

                if (xr.Read())
                {
                    if (xr.IsStartElement("Message"))
                    {
                        while (xr.Read())
                        {
                            if (xr.IsStartElement("Category"))
                            {
                                if (xr.ReadElementString() == "AUDIT")
                                {
                                    isAuditLogFile = true;
                                }
                                break;
                            }
                        }
                    }
                }

                DataStream.Position = 0;
                //or
                //dataStream.Seek(0, SeekOrigin.Begin);
            }
            catch (Exception)
            {
                //
            }
            finally
            {
                if (DataStream != null)
                {
                    DataStream.Position = 0;
                }
            }
            return isAuditLogFile;
        }

    }
}
