using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Ribbon;
using Newtonsoft.Json;
using Philips.Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using Philips.Analogy.Interfaces.Interfaces;

namespace Philips.Analogy
{
    public class Utils
    {
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
        static string[] spliter = { Environment.NewLine };
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="filename"></param>
        public static void SerializeToBinaryFile<T>(T item, string filename)
        {
            var myformatter = new BinaryFormatter();
            var dirpath = Path.GetDirectoryName(filename);
            try
            {
                if (!string.IsNullOrEmpty(dirpath) && !(Directory.Exists(dirpath)))
                    Directory.CreateDirectory(dirpath);
                using (Stream myWriter = File.Open(filename, FileMode.Create, FileAccess.ReadWrite))
                {
                    myformatter.Serialize(myWriter, item);
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
            var myformatter = new BinaryFormatter();
            if (File.Exists(filename))
                try
                {
                    using (Stream myReader = File.Open(filename, FileMode.Open, FileAccess.Read))
                    {
                        return (T)myformatter.Deserialize(myReader, null);
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

            DataColumn dtc;

            dtc = new DataColumn("Date", typeof(DateTime));
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

            dtc = new DataColumn("Audit", typeof(string));
            dtb.Columns.Add(dtc);

            dtc = new DataColumn("Object", typeof(object));
            dtb.Columns.Add(dtc);

            dtc = new DataColumn("ProcessID", typeof(int));
            dtb.Columns.Add(dtc);

            dtc = new DataColumn("DataSource", typeof(string));
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
            dtb.DefaultView.Sort = "Date ASC";

            return dtb;
        }

        public static void SetSkin(Control control, string skinName)
        {
            if (control is RibbonControl)
            {
                SetLookAndFellSkin((control as RibbonControl).GetController().LookAndFeel, skinName);
                return;
            }
            if (control is ISupportLookAndFeel)
            {
                SetLookAndFellSkin(((ISupportLookAndFeel)control).LookAndFeel, skinName);
            }
            foreach (Control c in control.Controls)
                SetSkin(c, skinName);
        }
        private static void SetLookAndFellSkin(UserLookAndFeel lookAndFeel, string skinName)
        {
            lookAndFeel.UseDefaultLookAndFeel = false;
            lookAndFeel.SkinName = skinName;
        }
        
        public static List<FileInfo> GetSupportedFiles(DirectoryInfo dirInfo, bool recursive)
        {
            List<FileInfo> files = dirInfo.GetFiles("*.etl").Concat(dirInfo.GetFiles("*.log"))
                .Concat(dirInfo.GetFiles("*.nlog")).Concat(dirInfo.GetFiles("*.json"))
                .Concat(dirInfo.GetFiles("defaultFile_*.xml")).Concat(dirInfo.GetFiles("*.evtx")).ToList();
            if (!recursive)
                return files;
            try
            {
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    files.AddRange(GetSupportedFiles(dir, true));
                }
            }
            catch (Exception)
            {
                return files;
            }

            return files;
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
    }

    public class FilterCriteriaObject
    {
        private string[] allLevels = Enum.GetNames(typeof(AnalogyLogLevel));
        public string[] ExcludedSources;
        public string[] Modules;
        public string[] ExcludedModules;

        public string TextInclude { get; set; }

        public string TextExclude { get; set; }
        private string[] arrLevels;
        public string[] Levels
        {
            get => arrLevels ?? allLevels;
            set => arrLevels = value;
        }

        //private string Category = "";


        public static string EscapeLikeValue(string value)
        {
            StringBuilder sb = new StringBuilder(value.Length);
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                switch (c)
                {


                    case ']':
                    case '[':
                    case '%':
                    case '*':
                        sb.Append("[").Append(c).Append("]");
                        break;
                    case '\'':
                        sb.Append("''");
                        break;
                    case '@':
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }

            return sb.ToString();
        }
        public string GetSQLExpression()
        {
            StringBuilder sqlString = new StringBuilder();
            List<string> includeTexts = new List<string> { EscapeLikeValue(TextInclude.Trim()) };

            bool orOperationInInclude = false;
            bool orOperationInexclude = false;
            var text = EscapeLikeValue(TextInclude.Trim());
            if (text.Contains('|'))
            {
                orOperationInInclude = true;
                var split = text.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                includeTexts = split.Select(itm => itm.Trim()).ToList();
            }

            if (text.Contains("&") || text.Contains('+'))
            {
                var split = text.Split(new[] { '&', '+' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                includeTexts = split.Select(itm => itm.Trim()).ToList();
            }
            List<string> excludedTexts = new List<string>(0);
            if (!string.IsNullOrEmpty(TextExclude))
                excludedTexts.Add(EscapeLikeValue(TextExclude.Trim()));
            text = EscapeLikeValue(TextExclude.Trim());
            if (text.Contains("|"))
            {
                orOperationInexclude = true;
                var split = text.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                excludedTexts = split.Select(itm => itm.Trim()).Where(w => !string.IsNullOrEmpty(w)).ToList();
            }
            if (text.Contains("&") || text.Contains("+"))
            {
                var split = text.Split(new[] { '&', '+' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                excludedTexts = split.Select(itm => itm.Trim()).ToList();
            }
            if (UserSettingsManager.UserSettings.SearchAlsoInSourceAndModule)
                sqlString.Append("((");
            else
                sqlString.Append("(");

            if (orOperationInInclude)
                sqlString.Append(string.Join(" Or ", includeTexts.Select(t => $" Text like '%{t}%'")));
            else
                sqlString.Append(string.Join(" and ", includeTexts.Select(t => $" Text like '%{t}%'")));
            sqlString.Append(")");

            if (UserSettingsManager.UserSettings.SearchAlsoInSourceAndModule)
            {
                //also in source
                sqlString.Append(" or (");
                if (orOperationInInclude)
                    sqlString.Append(string.Join(" Or ", includeTexts.Select(t => $" Source like '%{t}%'")));
                else
                    sqlString.Append(string.Join(" And ", includeTexts.Select(t => $" Source like '%{t}%'")));
                sqlString.Append(")");
                //also in module
                sqlString.Append(" or (");
                if (orOperationInInclude)
                    sqlString.Append(string.Join(" Or ", includeTexts.Select(t => $" Module like '%{t}%'")));
                else
                    sqlString.Append(string.Join(" And ", includeTexts.Select(t => $" Module like '%{t}%'")));
                sqlString.Append("))");
            }

            if (excludedTexts.Any())
            {
                sqlString.Append(" and (");
                if (orOperationInexclude)
                    sqlString.Append(string.Join(" and ", excludedTexts.Select(t => $" NOT Text like '%{t}%'")));
                else
                    sqlString.Append(string.Join(" Or ", excludedTexts.Select(t => $" NOT Text like '%{t}%'")));
                sqlString.Append(")");
            }

            if (ExcludedSources != null && ExcludedSources.Any())
            {
                sqlString.Append(" and (");
                sqlString.Append(string.Join(" and ", ExcludedSources.Select(l => $" NOT Source like '%{EscapeLikeValue(l)}%'")));
                sqlString.Append(")");
            }
            if (ExcludedModules != null && ExcludedModules.Any())
            {
                sqlString.Append(" and (");
                sqlString.Append(string.Join(" and", ExcludedModules.Select(l => $" NOT Module like '%{EscapeLikeValue(l)}%'")));
                sqlString.Append(")");
            }

            if (Modules != null && Modules.Any())
            {
                sqlString.Append(" and (");
                sqlString.Append(string.Join(" and ", Modules.Select(l => $" Module like '%{EscapeLikeValue(l)}%'")));
                sqlString.Append(")");
            }
            string sTemp = string.Join(",", Levels.Select(l => $"'{l}'"));
            sqlString.Append(" and Level in (" + sTemp + ")");
            return sqlString.ToString();
        }

        public bool Match(string rowLine, string criteria)
        {
            if (string.IsNullOrEmpty(criteria)) return false;
            List<string> includeTexts = new List<string>(1) { criteria.Trim() };

            bool orOperationInInclude = false;
            if (criteria.Contains('|'))
            {
                orOperationInInclude = true;
                var split = criteria.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                includeTexts = split.Select(itm => itm.Trim()).ToList();
            }

            if (criteria.Contains("&") || criteria.Contains('+'))
            {
                var split = criteria.Split(new[] { '&', '+' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                includeTexts = split.Select(itm => itm.Trim()).ToList();
            }
            //List<string> excludedTexts = new List<string>(0);
            //if (!string.IsNullOrEmpty(TextExclude))
            //    excludedTexts.Add(EscapeLikeValue(TextExclude.Trim()));
            //text = TextExclude.Trim();
            //if (text.Contains("|"))
            //{
            //    orOperationInexclude = true;
            //    var split = text.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            //    excludedTexts = split.Select(itm => itm.Trim()).Where(w => !string.IsNullOrEmpty(w)).ToList();
            //}

            //if (text.Contains("&") || text.Contains("+"))
            //{
            //    var split = text.Split(new[] { '&', '+' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            //    excludedTexts = split.Select(itm => itm.Trim()).ToList();
            //}

            if (orOperationInInclude)
                return includeTexts.Any(t => rowLine.Contains(t, StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(t));
            else
                return includeTexts.All(t => rowLine.Contains(t, StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(t));

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

            string json = JsonConvert.SerializeObject(messages);
            File.WriteAllText(filename, json);
        }
        public static void ExportToJson(List<AnalogyLogMessage> messages, string filename)
        {
            string json = JsonConvert.SerializeObject(messages);
            File.WriteAllText(filename, json);
        }

        public static void ExportToCSV(List<AnalogyLogMessage> messages, string fileName)
        {
            string text = string.Join(Environment.NewLine, messages.Select(GetCSVFromMessage).ToArray());
            File.WriteAllText(fileName, text);
        }

        private static string GetCSVFromMessage(AnalogyLogMessage m) =>
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