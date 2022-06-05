using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Analogy.CommonControls.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Newtonsoft.Json;

namespace Analogy.CommonControls
{
    public static class Utils
    {
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
        public static List<string> LogLevels { get; } = Enum.GetValues(typeof(AnalogyLogLevel)).Cast<AnalogyLogLevel>().Select(e => e.ToString()).ToList();

        public static string GetFileNameAsDataSource(string fileName)
        {
            string file = Path.GetFileName(fileName);
            return fileName != null && fileName.Equals(file) ? fileName : $"{file} ({fileName})";
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DataRow CreateRow(DataTable table, AnalogyLogMessage message, string dataSource, TimeOffsetType timeOffsetType, TimeSpan customOffset)
        {
            var dtr = table.NewRow();
            dtr.BeginEdit();
            dtr["Date"] = Utils.GetOffsetTime(message.Date,timeOffsetType,customOffset);
            dtr["Text"] = message.Text ?? "";
            dtr["Source"] = message.Source ?? "";
            dtr["Level"] = string.Intern(message.Level.ToString());
            dtr["Class"] = string.Intern(message.Class.ToString());
            dtr["Category"] = message.Category ?? "";
            dtr["User"] = message.User ?? "";
            dtr["Module"] = message.Module ?? "";
            dtr["Object"] = message;
            dtr["ProcessID"] = message.ProcessId;
            dtr["ThreadID"] = message.ThreadId;
            dtr["DataProvider"] = dataSource ?? string.Empty;
            dtr["MachineName"] = message.MachineName ?? string.Empty;
            if (message.AdditionalInformation != null && message.AdditionalInformation.Any())
            {
                foreach (KeyValuePair<string, string> info in message.AdditionalInformation)
                {
                    if (dtr.Table.Columns.Contains(info.Key))
                    {
                        dtr[info.Key] = info.Value;
                    }
                }

            }
            return dtr;
        }
        public static bool IsCompressedArchive(string filename)
        {
            return filename.EndsWith(".gz", StringComparison.InvariantCultureIgnoreCase) ||
                   filename.EndsWith(".zip", StringComparison.InvariantCultureIgnoreCase);
        }

        public static DateTime GetOffsetTime(DateTime time, TimeOffsetType timeOffsetType,TimeSpan customOffset)
        {
            return timeOffsetType switch
            {
                TimeOffsetType.None => time,
                TimeOffsetType.Predefined => time.Add(customOffset),
                TimeOffsetType.UtcToLocalTime => time.ToLocalTime(),
                TimeOffsetType.LocalTimeToUtc => time.ToUniversalTime(),
                _ => time
            };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DataTable DataTableConstructor()
        {

            DataTable dtb = new DataTable();
            dtb.Columns.Add(new DataColumn("Date", typeof(DateTime)));
            dtb.Columns.Add(new DataColumn("TimeDiff", typeof(string)));
            dtb.Columns.Add(new DataColumn("Text", typeof(string)));
            dtb.Columns.Add(new DataColumn("Source", typeof(string)));
            dtb.Columns.Add(new DataColumn("Level", typeof(string)));
            dtb.Columns.Add(new DataColumn("Class", typeof(string)));
            dtb.Columns.Add(new DataColumn("Category", typeof(string)));
            dtb.Columns.Add(new DataColumn("User", typeof(string)));
            dtb.Columns.Add(new DataColumn("Module", typeof(string)));
            dtb.Columns.Add(new DataColumn("Object", typeof(object)));
            dtb.Columns.Add(new DataColumn("ProcessID", typeof(int)));
            dtb.Columns.Add(new DataColumn("ThreadID", typeof(int)));
            dtb.Columns.Add(new DataColumn("DataProvider", typeof(string)));
            dtb.Columns.Add(new DataColumn("MachineName", typeof(string)));

            dtb.DefaultView.AllowNew = false;
            dtb.DefaultView.RowStateFilter = DataViewRowState.Unchanged;
            dtb.DefaultView.Sort = "Date DESC";

            return dtb;
        }

        public static string ExtractJsonObject(string mixedString)
        {
            for (var i = mixedString.IndexOf('{'); i > -1; i = mixedString.IndexOf('{', i + 1))
            {
                for (var j = mixedString.LastIndexOf('}'); j > -1; j = mixedString.LastIndexOf("}", j - 1))
                {
                    var jsonProbe = mixedString.Substring(i, j - i + 1);
                    try
                    {
                        var valid = JsonConvert.DeserializeObject(jsonProbe);
                        return jsonProbe;
                    }
                    catch
                    {
                    }
                }
            }

            return string.Empty;
        }
        public static void SetLogLevel(CheckedListBoxControl chkLstLogLevel)
        {
            chkLstLogLevel.Items.Clear();
            var logLevelSelection = LogLevelSelectionType.Single;
            switch (logLevelSelection)
            {
                case LogLevelSelectionType.Single:
                    chkLstLogLevel.CheckMode = CheckMode.Single;
                    chkLstLogLevel.CheckStyle = CheckStyles.Radio;
                    CheckedListBoxItem[] radioLevels = {
                        new CheckedListBoxItem("Trace"),
                        new CheckedListBoxItem("Error + Critical"),
                        new CheckedListBoxItem("Warning"),
                        new CheckedListBoxItem("Debug"),
                        new CheckedListBoxItem("Verbose")
                    };
                    chkLstLogLevel.Items.AddRange(radioLevels);
                    break;
                case LogLevelSelectionType.Multiple:
                    chkLstLogLevel.CheckMode = CheckMode.Multiple;
                    chkLstLogLevel.CheckStyle = CheckStyles.Standard;
                    chkLstLogLevel.Items.AddRange(LogLevels.Select(l => new CheckedListBoxItem(l, false)).ToArray());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        public static void FillLogLevels(CheckedListBoxControl chkLstLogLevel)
        {
            chkLstLogLevel.Items.Clear();
            chkLstLogLevel.CheckStyle = CheckStyles.Standard;
            chkLstLogLevel.Items.AddRange(LogLevels.Select(l => new CheckedListBoxItem(l, false)).ToArray());

        }
    }
}
