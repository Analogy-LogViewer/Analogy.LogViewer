using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Analogy.Common.DataTypes;
using Analogy.CommonControls.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Newtonsoft.Json;

namespace Analogy.CommonControls
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
        public static DataRow CreateRow(DataTable table, IAnalogyLogMessage message, string dataSource, TimeOffsetType timeOffsetType, TimeSpan customOffset)
        {
            var dtr = table.NewRow();
            dtr.BeginEdit();
            dtr["Date"] = GetOffsetTime(message.Date,timeOffsetType,customOffset);
            dtr["Text"] = message.Text ?? "";
            dtr["Source"] = message.Source ?? "";
            dtr["Level"] = message.Level;
            dtr["Class"] = message.Class;
            dtr["User"] = message.User ?? "";
            dtr[Common.CommonUtils.ColumnModule] = message.Module ?? "";
            dtr[Common.CommonUtils.AnalogyMessageColumn] = message;
            dtr[Common.CommonUtils.ColumnProcessId] = message.ProcessId;
            dtr[Common.CommonUtils.ColumnThreadId] = message.ThreadId;
            dtr["DataProvider"] = dataSource ?? string.Empty;
            dtr["MachineName"] = message.MachineName ?? string.Empty;
            dtr["RawText"] = message.RawText ?? string.Empty;
            dtr["LineNumber"] = message.LineNumber;
            dtr["MethodName"] = message.MethodName;
            if (message.AdditionalProperties != null && message.AdditionalProperties.Any())
            {
                foreach (KeyValuePair<string, string> info in message.AdditionalProperties)
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
            dtb.Columns.Add(new DataColumn(Common.CommonUtils.ColumnModule, typeof(string)));
            dtb.Columns.Add(new DataColumn(Common.CommonUtils.AnalogyMessageColumn, typeof(object)));
            dtb.Columns.Add(new DataColumn(Common.CommonUtils.ColumnProcessId, typeof(int)));
            dtb.Columns.Add(new DataColumn(Common.CommonUtils.ColumnThreadId, typeof(int)));
            dtb.Columns.Add(new DataColumn("DataProvider", typeof(string)));
            dtb.Columns.Add(new DataColumn("MachineName", typeof(string)));
            dtb.Columns.Add(new DataColumn("RawText", typeof(string)));
            dtb.Columns.Add(new DataColumn("LineNumber", typeof(long)));
            dtb.Columns.Add(new DataColumn("MethodName", typeof(string)));
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

        public static string GetOpenFilter(string openFilter,bool addCompressedArchives)
        {
            if (!addCompressedArchives)
            {
                return openFilter;
            }
            //if (openFilter.Contains("*.gz") || openFilter.Contains("*.zip")) return openFilter;
            //string compressedFilter = "|Compressed archives (*.gz, *.zip)|*.gz;*.zip";
            //return openFilter + compressedFilter;
            if (!openFilter.Contains("*.zip", StringComparison.InvariantCultureIgnoreCase))
            {
                string compressedFilter = "|Compressed Zip Archive (*.zip)|*.zip";
                openFilter = openFilter + compressedFilter;
            }
            if (!openFilter.Contains("*.gz", StringComparison.InvariantCultureIgnoreCase))
            {
                string compressedFilter = "|Compressed Gzip Archive (*.gz)|*.gz";
                openFilter = openFilter + compressedFilter;
            }

            return openFilter;
        }
        /// <summary>
        /// Case insensitive contains(string)
        /// </summary>
        /// <param name="source">the original string</param>
        /// <param name="toCheck">the string</param>
        /// <param name="comp">string comparison</param>
        /// <returns></returns>
        private static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return string.IsNullOrEmpty(toCheck) || (!string.IsNullOrEmpty(source) && source.IndexOf(toCheck, comp) >= 0);
        }
        public static SuperToolTip GetSuperTip(string title, string content)
        {
            SuperToolTip toolTip = new SuperToolTip();
            // Create an object to initialize the SuperToolTip.
            SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
            args.Title.Text = title;
            args.Contents.Text = content;
            // args.Contents.Image = realTime.ToolTip.Image;
            toolTip.Setup(args);
            return toolTip;
        }
    }
}
