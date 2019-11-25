using System;
using System.Collections.Generic;
using System.Data;

namespace Analogy.Interfaces
{
    public class LogMessageArgs : EventArgs
    {
        public AnalogyLogMessage Message { get; private set; }
        public string HostName { get; private set; }
        public string DataSource { get; private set; }

        public LogMessageArgs(AnalogyLogMessage msg, string host, string dataSource)
        {
            Message = msg;
            HostName = host;
            DataSource = dataSource;
        }
    }

    public class AnalogyCellClickedEventArgs : EventArgs
    {
        public string ColumnName { get; }
        public object ColumnValue { get; }
        public  AnalogyLogMessage Message { get; }

        public AnalogyCellClickedEventArgs(string columnName, object columnValue,  AnalogyLogMessage message)
        {
            ColumnName = columnName;
            ColumnValue = columnValue;
            Message = message;
        }


    }


    public class AnalogyPageInformation
    {
        public DataTable Data { get; set; }
        public int PageNumber { get; set; }
        public int PageFirstRowIndex { get; set; }
        public int PageLastRowIndex => PageFirstRowIndex + Data.Rows.Count;

        public AnalogyPageInformation(DataTable data, int pageNumber, int pageFirstRowIndex)
        {
            Data = data;
            PageNumber = pageNumber;
            PageFirstRowIndex = pageFirstRowIndex;
        }
    }
    public class AnalogyPagingChanged : EventArgs
    {
        public AnalogyPageInformation AnalogyPage { get; set; }

        public AnalogyPagingChanged(AnalogyPageInformation analogyPage)
        {
            AnalogyPage = analogyPage;
        }
    }

    public class AnalogyDataSourceDisconnectedArgs : EventArgs
    {

        public string DisconnectedReason { get; private set; }
        public string HostName { get; private set; }
        public Guid DataSourceID { get; private set; }

        public AnalogyDataSourceDisconnectedArgs(string disconnectedReason, string hostName, Guid dataSourceID)
        {
            DisconnectedReason = disconnectedReason;
            HostName = hostName;
            DataSourceID = dataSourceID;
        }
    }
    public class AnalogyLogMessageArgs : EventArgs
    {
        public  AnalogyLogMessage Message { get; private set; }
        public string HostName { get; private set; }
        public string DataSource { get; private set; }
        public Guid DataSourceID { get; private set; }

        public AnalogyLogMessageArgs(AnalogyLogMessage msg, string host, string dataSource, Guid dataSourceID)
        {
            Message = msg;
            HostName = host;
            DataSource = dataSource;
            DataSourceID = dataSourceID;
        }
    }
    public class AnalogyLogFileProcessedArgs : EventArgs
    {
        public string LogFile { get; private set; }
        public IEnumerable< AnalogyLogMessage> ProcessedMessages { get; private set; }
        public Guid DataSourceID { get; private set; }

        public AnalogyLogFileProcessedArgs(IEnumerable< AnalogyLogMessage> messages, string logfile, Guid dataSourceID)
        {
            ProcessedMessages = messages;
            LogFile = logfile;
            DataSourceID = dataSourceID;

        }
    }
    public class AnalogyLogMessagesArgs : EventArgs
    {
        public List< AnalogyLogMessage> Messages { get; private set; }
        public string HostName { get; private set; }
        public string DataSource { get; private set; }

        public AnalogyLogMessagesArgs(List< AnalogyLogMessage> msgs, string host, string dataSource)
        {
            Messages = msgs;
            HostName = host;
            DataSource = dataSource;
        }
    }
}
