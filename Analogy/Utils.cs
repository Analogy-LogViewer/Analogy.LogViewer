using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Ribbon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Analogy.Interfaces;

namespace Analogy
{
    public static class Utils
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct LASTINPUTINFO
        {
            public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)]
            public UInt32 cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dwTime;
        }
        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        /// <summary>
        /// No filter. All allowed
        /// </summary>
        internal const string DateFilterNone = "All";
        /// <summary>
        /// From Today 
        /// </summary>
        internal const string DateFilterToday = "Today";
        /// <summary>
        /// From last 2 days 
        /// </summary>
        internal const string DateFilterLast2Days = "Last 2 days";
        /// <summary>
        /// From last 3 days
        /// </summary>
        internal const string DateFilterLast3Days = "Last 3 days";
        /// <summary>
        /// From last week
        /// </summary>
        internal const string DateFilterLastWeek = "Last one week";
        /// <summary>
        /// From last 2 weeks
        /// </summary>
        internal const string DateFilterLast2Weeks = "Last 2 weeks";
        /// <summary>
        /// From last month
        /// </summary>
        internal const string DateFilterLastMonth = "Last one month";

        private static Regex HasQuestionMarkRegEx = new Regex(@"\?", RegexOptions.Compiled);
        private static Regex IllegalCharactersRegex = new Regex("[" + @"\/:<>|" + "\"]", RegexOptions.Compiled);
        private static Regex CatchExtentionRegex = new Regex(@"^\s*.+\.([^\.]+)\s*$", RegexOptions.Compiled);
        private static string NonDotCharacters = @"[^.]*";
        //
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="filename"></param>
        public static void SerializeToBinaryFile<T>(T item, string filename)
        {
            var formatter = new BinaryFormatter();
            var directoryName = Path.GetDirectoryName(filename);
            try
            {
                if (!string.IsNullOrEmpty(directoryName) && !(Directory.Exists(directoryName)))
                    Directory.CreateDirectory(directoryName);
                using (Stream myWriter = File.Open(filename, FileMode.Create, FileAccess.ReadWrite))
                {
                    formatter.Serialize(myWriter, item);
                }
            }
            catch (SerializationException ex)
            {
                throw new Exception("GeneralDataUtils: Error in SerializeToBinaryFile", ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static T DeSerializeBinaryFile<T>(string filename) where T : class, new()
        {
            var formatter = new BinaryFormatter();
            if (File.Exists(filename))
                try
                {
                    using (Stream myReader = File.Open(filename, FileMode.Open, FileAccess.Read))
                    {
                        return (T)formatter.Deserialize(myReader);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("GeneralDataUtils: Error in DeSerializeBinaryFile", ex);
                }

            throw new FileNotFoundException("GeneralDataUtils: File does not exist: " + filename, filename);
        }

        public static DataTable DataTableConstructor()
        {

            DataTable dtb = new DataTable();

            var dtc = new DataColumn("Date", typeof(DateTime));
            dtb.Columns.Add(dtc);
            dtc = new DataColumn("TimeDiff", typeof(string));
            dtb.Columns.Add(dtc);

            dtc = new DataColumn("Text", typeof(string));
            dtb.Columns.Add(dtc);

            dtc = new DataColumn("Source", typeof(string));
            dtb.Columns.Add(dtc);

            dtc = new DataColumn("Level", typeof(string));
            dtb.Columns.Add(dtc);

            dtc = new DataColumn("Class", typeof(string));
            dtb.Columns.Add(dtc);

            dtc = new DataColumn("Category", typeof(string));
            dtb.Columns.Add(dtc);
            dtc = new DataColumn("User", typeof(string));
            dtb.Columns.Add(dtc);

            dtc = new DataColumn("Module", typeof(string));
            dtb.Columns.Add(dtc);

            dtc = new DataColumn("Object", typeof(object));
            dtb.Columns.Add(dtc);

            dtc = new DataColumn("ProcessID", typeof(int));
            dtb.Columns.Add(dtc);
            dtc = new DataColumn("ThreadID", typeof(int));
            dtb.Columns.Add(dtc);
            dtc = new DataColumn("DataProvider", typeof(string));
            dtb.Columns.Add(dtc);
            var manager = ExtensionsManager.Instance;
            foreach (IAnalogyExtension extension in manager.InPlaceRegisteredExtensions)
            {
                var columns = extension.GetColumnsInfo();
                foreach (AnalogyColumnInfo column in columns)
                {
                    dtc = new DataColumn(column.ColumnName, column.ColumnType);
                    dtb.Columns.Add(dtc);
                }
            }
            dtb.DefaultView.AllowNew = false;
            dtb.DefaultView.RowStateFilter = DataViewRowState.Unchanged;
            dtb.DefaultView.Sort =UserSettingsManager.UserSettings.DefaultDescendOrder ?
                "Date DESC" : "Date ASC";

            return dtb;
        }

        public static void SetSkin(Control control, string skinName)
        {
            if (control is RibbonControl ribbonControl)
            {
                SetLookAndFellSkin(ribbonControl.GetController().LookAndFeel, skinName);
                return;
            }
            if (control is ISupportLookAndFeel feel)
            {
                SetLookAndFellSkin(feel.LookAndFeel, skinName);
            }
            foreach (Control c in control.Controls)
                SetSkin(c, skinName);
        }
        private static void SetLookAndFellSkin(UserLookAndFeel lookAndFeel, string skinName)
        {
            lookAndFeel.UseDefaultLookAndFeel = false;
            lookAndFeel.SkinName = skinName;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AnalogyLogMessage CreateMessageFromEvent(EventLogEntry eEntry)
        {
            AnalogyLogMessage m = new AnalogyLogMessage();
            switch (eEntry.EntryType)
            {
                case EventLogEntryType.Error:
                    m.Level = AnalogyLogLevel.Error;
                    break;
                case EventLogEntryType.Warning:
                    m.Level = AnalogyLogLevel.Warning;
                    break;
                case EventLogEntryType.Information:
                    m.Level = AnalogyLogLevel.Event;
                    break;
                case EventLogEntryType.SuccessAudit:
                    m.Level = AnalogyLogLevel.Event;
                    break;
                case EventLogEntryType.FailureAudit:
                    m.Level = AnalogyLogLevel.Error;
                    break;
                default:
                    m.Level = AnalogyLogLevel.Event;
                    break;
            }

            m.Category = eEntry.Category;
            m.Date = eEntry.TimeGenerated;
            m.ID = Guid.NewGuid();
            m.Source = eEntry.Source;
            m.Text = eEntry.Message;
            m.User = eEntry.UserName;
            m.Module = eEntry.Source;
            return m;
        }

        public static string GetFileNameAsDataSource(string fileName)
        {
            string file = Path.GetFileName(fileName);
            return fileName.Equals(file) ? fileName : $"{file} ({fileName})";

        }

        static long GetLastInputTime()
        {
            uint idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            uint envTicks = (uint)Environment.TickCount;

            if (GetLastInputInfo(ref lastInputInfo))
            {
                uint lastInputTick = lastInputInfo.dwTime;

                idleTime = envTicks - lastInputTick;
            }

            return ((idleTime > 0) ? (idleTime / 1000) : 0);
        }
        public static TimeSpan IdleTime() => TimeSpan.FromSeconds(GetLastInputTime());

        
         

            public static bool MatchedAll(string pattern, IEnumerable<string> files)
            {
                Regex reg = Convert(pattern);
                return files.All(f => reg.IsMatch(f));
            }
            public static Regex Convert(string pattern)
            {
                if (pattern == null)
                {
                    throw new ArgumentNullException();
                }
                pattern = pattern.Trim();
                if (pattern.Length == 0)
                {
                    throw new ArgumentException("Pattern is empty.");
                }
                if (IllegalCharactersRegex.IsMatch(pattern))
                {
                    throw new ArgumentException("Pattern contains illegal characters.");
                }
                bool hasExtension = CatchExtentionRegex.IsMatch(pattern);
                bool matchExact = false;
                if (HasQuestionMarkRegEx.IsMatch(pattern))
                {
                    matchExact = true;
                }
                else if (hasExtension)
                {
                    matchExact = CatchExtentionRegex.Match(pattern).Groups[1].Length != 3;
                }
                string regexString = Regex.Escape(pattern);
                regexString = "^" + Regex.Replace(regexString, @"\\\*", ".*");
                regexString = Regex.Replace(regexString, @"\\\?", ".");
                if (!matchExact && hasExtension)
                {
                    regexString += NonDotCharacters;
                }
                regexString += "$";
                Regex regex = new Regex(regexString, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                return regex;
            }
        
    }
    
    public abstract class Saver
    {
        public static void ExportToJson(DataTable data, string filename)
        {
            List<AnalogyLogMessage> messages = new List<AnalogyLogMessage>();
            foreach (DataRow dtr in data.Rows)
            {

                AnalogyLogMessage log = (AnalogyLogMessage)dtr["Object"];
                messages.Add(log);
            }

            string json = System.Text.Json.JsonSerializer.Serialize(messages);
            File.WriteAllText(filename, json);
        }
        public static void ExportToJson(List<AnalogyLogMessage> messages, string filename)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(messages);
            File.WriteAllText(filename, json);
        }

        public static void ExportToCSV(List<AnalogyLogMessage> messages, string fileName)
        {
            string text = string.Join(Environment.NewLine, messages.Select(GetCsvFromMessage).ToArray());
            File.WriteAllText(fileName, text);
        }

        private static string GetCsvFromMessage(AnalogyLogMessage m) =>
        $"ID:{m.ID};Text:{m.Text};Category:{m.Category};Source:{m.Source};Level:{m.Level};Class:{m.Class};Module:{m.Module};Method:{m.MethodName};FileName:{m.FileName};LineNumber:{m.LineNumber};ProcessID:{m.ProcessID};User:{m.User};Parameters:{(m.Parameters == null ? string.Empty : string.Join(",", m.Parameters))}";
    }

    /// <summary>
    /// Represents custom filter item types.
    /// </summary>
    public enum DateRangeFilter
    {
        /// <summary>
        /// No filter
        /// </summary>
        None,
        /// <summary>
        /// Current date
        /// </summary>
        Today,
        /// <summary>
        /// Current date and yesterday
        /// </summary>
        Last2Days,
        /// <summary>
        /// Today, yesterday and the day before yesterday
        /// </summary>
        Last3Days,
        /// <summary>
        /// Last 7 days
        /// </summary>
        LastWeek,
        /// <summary>
        /// Last 2 weeks
        /// </summary>
        Last2Weeks,
        /// <summary>
        /// Last one month
        /// </summary>
        LastMonth
    }
}