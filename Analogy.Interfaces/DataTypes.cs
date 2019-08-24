
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Philips.Analogy.Interfaces
{
    public class AnalogyProgressReport
    {
        public string Prefix { get; set; }
        public int Processed { get; set; }
        public int Total { get; set; }
        public string FinishedProcessing { get; set; }
        public AnalogyProgressReport(string prefix, int processed, int total, string finishedProcessing) => (Prefix, Processed, Total, FinishedProcessing) = (prefix, processed, total, finishedProcessing);
    }
    [Flags()]
    public enum AnalogyExtensionType
    {
        None = 0,
        InPlace = 1,
        UserControl = 2
    }

    public enum AnalogyDataSourceType
    {
        RealTimeDataSource,
        OfflineDataSource,

    }
    public class AnalogyColumnInfo
    {
        public string ColumnCaption { get; }
        public string ColumnName { get; }
        public Type ColumnType { get; }

        public AnalogyColumnInfo(string columnCaption, string columnName, Type columnType)
        {
            ColumnCaption = columnCaption;
            ColumnName = columnName;
            ColumnType = columnType;
        }
    }

    /// <summary>
    /// Class representing Log message
    /// </summary>
    [Serializable]
    [XmlRoot("AnalogyLogMessage")]

    public class AnalogyLogMessage
    {

        /// <summary>
        /// Gets/Sets date and time of arrival of log message
        /// Applicable only at server or pilot adapter
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets/Sets a unique identifier of the log message
        /// </summary>
        public Guid ID { get; set; }

        /// <summary>
        /// Gets/Sets the log message text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets/Sets the category of the log message
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets/Sets the source of the log message
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets/Sets the method name of message generator
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// Gets/Sets the filename of message generator
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets/Sets the line number of message generator
        /// </summary>
        public int LineNumber { get; set; }

        /// <summary>
        /// Gets/Sets the log class of the message
        /// </summary>
        public AnalogyLogClass Class { get; set; }

        /// <summary>
        /// Gets/Sets the log level of the message
        /// </summary>
        public AnalogyLogLevel Level { get; set; }

        /// <summary>
        /// Gets/Sets the module (process) name of message generator
        /// </summary>
        public string Module { get; set; }

        /// <summary>
        /// Gets/Sets the system process ID of message generator
        /// </summary>
        public int ProcessID { get; set; }

        public int Thread { get; set; }
        public string AuditLogType { get; set; }

        public string atnaMessage { get; set; }

        /// <summary>
        /// Gets or sets LogMessage parameter array that will be inserted into message text
        /// </summary>
        public string[] Parameters { get; set; }

        public string User { get; set; }

        public AnalogyLogMessage()
        {
            ID = Guid.NewGuid();
            Date = DateTime.Now;
            Parameters = new string[0];
            AuditLogType = string.Empty;
            atnaMessage = string.Empty;
            Source = string.Empty;
            MethodName = string.Empty;
            FileName = string.Empty;
            Parameters=new string[0];
            User = string.Empty;
        }
        public AnalogyLogMessage(string text, AnalogyLogLevel level, AnalogyLogClass logClass, string source, string category=null, string auditLogType = null, string moduleOrProcessName = null, int processId = 0, int threadID = 0, string[] parameters = null, string user = null, [CallerMemberName]string methodName = null, [CallerFilePath] string fileName = null, [CallerLineNumber] int lineNumber = 0) : this()
        {
            Text = text;
            Category = category ?? string.Empty;
            Source = source ?? string.Empty;
            MethodName = methodName ?? string.Empty;
            FileName = fileName ?? string.Empty;
            LineNumber = lineNumber;
            Class = logClass;
            Level = level;
            Module = moduleOrProcessName ?? Process.GetCurrentProcess().ProcessName;
            ProcessID = processId != 0 ? processId : Process.GetCurrentProcess().Id;
            Parameters = parameters ?? new string[0];
            User = user ?? string.Empty;
            AuditLogType = auditLogType ?? string.Empty;
            Thread = threadID!= 0 ? Thread: System.Threading.Thread.CurrentThread.ManagedThreadId;
        }
    }

    /// <summary>
    /// LogClass identifies the class of a log event.
    /// </summary>
    public enum AnalogyLogClass
    {
        /// <summary>
        /// Most log events
        /// </summary>
        General,

        /// <summary>
        /// Security logs (audit trails)
        /// </summary>
        Security,

        /// <summary>
        /// Hazard issues
        /// </summary>
        Hazard,
        //
        // Summary:
        //Protected Health Information
        PHI
    }
    /// <summary>
    /// LogLevel enumerates the possible logging levels.
    /// </summary>
    public enum AnalogyLogLevel
    {

        Critical,

        Error,

        Warning,

        Event,

        Verbose,

        Debug,

        Disabled,
        AnalogyInformation
    }

    public enum AnalogChangeLogType
    {
        None,
        Defect,
        Refactoring,
        Feature,
    }
}
