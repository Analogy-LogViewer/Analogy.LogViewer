using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Analogy.Interfaces
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

    public class AnalogyLogMessage : IEquatable<AnalogyLogMessage>
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
            Source = string.Empty;
            MethodName = string.Empty;
            FileName = string.Empty;
            Parameters = new string[0];
            User = string.Empty;
        }
        public AnalogyLogMessage(string text, AnalogyLogLevel level, AnalogyLogClass logClass, string source, string category = null, string moduleOrProcessName = null, int processId = 0, int threadID = 0, string[] parameters = null, string user = null, [CallerMemberName]string methodName = null, [CallerFilePath] string fileName = null, [CallerLineNumber] int lineNumber = 0) : this()
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
            Thread = threadID != 0 ? Thread : System.Threading.Thread.CurrentThread.ManagedThreadId;
        }

        public bool Equals(AnalogyLogMessage other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            bool areEqual = Date.Equals(other.Date) && ID.Equals(other.ID) && Text == other.Text && Category == other.Category &&
                   Source == other.Source && MethodName == other.MethodName && FileName == other.FileName &&
                   LineNumber == other.LineNumber && Class == other.Class && Level == other.Level &&
                   Module == other.Module && ProcessID == other.ProcessID && Thread == other.Thread &&
                   User == other.User;
            if ((!areEqual) ||
                (Parameters is null && other.Parameters != null) ||
                (Parameters != null && other.Parameters is null))
                return false;
            return (Parameters is null && other.Parameters is null) ||
                Parameters.SequenceEqual(other.Parameters);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AnalogyLogMessage)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Date.GetHashCode();
                hashCode = (hashCode * 397) ^ ID.GetHashCode();
                hashCode = (hashCode * 397) ^ (Text != null ? Text.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Category != null ? Category.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Source != null ? Source.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (MethodName != null ? MethodName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FileName != null ? FileName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ LineNumber;
                hashCode = (hashCode * 397) ^ (int)Class;
                hashCode = (hashCode * 397) ^ (int)Level;
                hashCode = (hashCode * 397) ^ (Module != null ? Module.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ProcessID;
                hashCode = (hashCode * 397) ^ Thread;
                if (Parameters != null && Parameters.Any())
                {
                    foreach (string parameter in Parameters)
                    {
                        if (!string.IsNullOrEmpty(parameter))
                            hashCode = (hashCode * 397) ^ parameter.GetHashCode();
                    }
                }
                hashCode = (hashCode * 397) ^ (User != null ? User.GetHashCode() : 0);
                return hashCode;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AnalogyLogMessage Parse(IEnumerable<(AnalogyLogMessagePropertyName PropertyName, string propertyValue)> data)
        {
            AnalogyLogMessage m = new AnalogyLogMessage();
            foreach (var (propertyName, propertyValue) in data)
            {
                switch (propertyName)
                {
                    case AnalogyLogMessagePropertyName.Date:
                        {
                            if (DateTime.TryParse(propertyValue, out DateTime time))
                                m.Date = time;
                        }
                        continue;
                    case AnalogyLogMessagePropertyName.ID:
                        {
                            if (Guid.TryParse(propertyValue, out Guid id))
                                m.ID = id;
                        }
                        continue;
                    case AnalogyLogMessagePropertyName.Text:
                        m.Text = propertyValue;
                        continue;
                    case AnalogyLogMessagePropertyName.Category:
                        m.Category = propertyValue;
                        continue;
                    case AnalogyLogMessagePropertyName.Source:
                        m.Source = propertyValue;
                        continue;
                    case AnalogyLogMessagePropertyName.MethodName:
                        m.MethodName = propertyValue;
                        continue;
                    case AnalogyLogMessagePropertyName.FileName:
                        m.FileName = propertyValue;
                        continue;
                    case AnalogyLogMessagePropertyName.Module:
                        m.Module = propertyValue;
                        continue;
                    case AnalogyLogMessagePropertyName.User:
                        m.User = propertyValue;
                        continue;
                    case AnalogyLogMessagePropertyName.LineNumber:
                        {
                            if (int.TryParse(propertyValue, out int num))
                                m.LineNumber = num;
                        }
                        continue;
                    case AnalogyLogMessagePropertyName.ProcessID:
                        {
                            if (int.TryParse(propertyValue, out int num))
                                m.ProcessID = num;
                        }
                        continue;
                    case AnalogyLogMessagePropertyName.Thread:
                        {
                            if (int.TryParse(propertyValue, out int num))
                                m.Thread = num;
                        }
                        continue;
                    case AnalogyLogMessagePropertyName.Level:
                    {
                        if (Enum.TryParse(propertyValue, true, out AnalogyLogLevel level))
                        {
                            m.Level = level;
                        }
                        else
                        {
                            switch (propertyValue)
                            {
                                case "TRACE":
                                    m.Level = AnalogyLogLevel.Debug;
                                    break;
                                case "DEBUG":
                                    m.Level = AnalogyLogLevel.Debug;
                                    break;
                                case "INFO":
                                    m.Level = AnalogyLogLevel.Event;
                                    break;
                                case "WARN":
                                    m.Level = AnalogyLogLevel.Warning;
                                    break;
                                case "ERROR":
                                    m.Level = AnalogyLogLevel.Error;
                                    break;
                                case "FATAL":
                                    m.Level = AnalogyLogLevel.Critical;
                                    break;
                                default:
                                    m.Level = AnalogyLogLevel.Unknown;
                                    break;
                            }

                        }

                        continue;
                    }
                    case AnalogyLogMessagePropertyName.Class:
                        {
                            m.Class = Enum.TryParse(propertyValue, true, out AnalogyLogClass cls)
                                ? cls
                                : AnalogyLogClass.General;
                        }
                        continue;
                    default: continue;
                }
            }

            return m;
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
        Unknown,
        Disabled,
        Trace,
        Verbose,
        Debug,
        Event,
        Warning,
        Error,
        Critical,
        AnalogyInformation
    }

    public enum AnalogChangeLogType
    {
        None,
        Defect,
        Refactoring,
        Feature,
        Improvement
    }

    public enum AnalogyLogMessagePropertyName
    {
        Date,
        ID,
        Text,
        Category,
        Source,
        Module,
        MethodName,
        FileName,
        User,
        LineNumber,
        ProcessID,
        Thread,
        Level,
        Class
    }
}
