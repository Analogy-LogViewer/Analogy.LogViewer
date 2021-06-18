using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Newtonsoft.Json;
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
using DevExpress.Utils;

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
        public static List<string> LogLevels { get; } = Enum.GetValues(typeof(AnalogyLogLevel)).Cast<AnalogyLogLevel>().Select(e => e.ToString()).ToList();



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
                {
                    Directory.CreateDirectory(directoryName);
                }

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
            {
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
            }

            throw new FileNotFoundException("GeneralDataUtils: File does not exist: " + filename, filename);
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
            var manager = ExtensionsManager.Instance;
            foreach (var extension in manager.InPlaceRegisteredExtensions)
            {
                var columns = extension.GetColumnsInfo();
                foreach (AnalogyColumnInfo column in columns)
                {
                    dtb.Columns.Add(new DataColumn(column.ColumnName, column.ColumnType));
                }
            }
            dtb.DefaultView.AllowNew = false;
            dtb.DefaultView.RowStateFilter = DataViewRowState.Unchanged;
            dtb.DefaultView.Sort = UserSettingsManager.UserSettings.DefaultDescendOrder ?
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
            {
                SetSkin(c, skinName);
            }
        }
        private static void SetLookAndFellSkin(UserLookAndFeel lookAndFeel, string skinName)
        {
            lookAndFeel.UseDefaultLookAndFeel = false;
            lookAndFeel.SkinName = skinName;
        }

        public static string GetFileNameAsDataSource(string fileName)
        {
            string file = Path.GetFileName(fileName);
            return fileName != null && fileName.Equals(file) ? fileName : $"{file} ({fileName})";
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
  
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DataRow CreateRow(DataTable table, AnalogyLogMessage message, string dataSource, bool checkAdditionalInformation)
        {
            var dtr = table.NewRow();
            dtr.BeginEdit();
            dtr["Date"] = Utils.GetOffsetTime(message.Date);
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
            if (checkAdditionalInformation && message.AdditionalInformation != null && message.AdditionalInformation.Any())
            {
                foreach (KeyValuePair<string, string> info in message.AdditionalInformation)
                {
                    if (dtr.Table.Columns.Contains(info.Key))
                    {
                        dtr[info.Key] = info.Value;
                    }
                    else
                    {
                        AnalogyLogger.Instance.LogError("",
                            $"key {info.Key} does not exist in table {table.TableName}");
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

        public static void SetLogLevel(CheckedListBoxControl chkLstLogLevel)
        {
            chkLstLogLevel.Items.Clear();
            switch (UserSettingsManager.UserSettings.LogLevelSelection)
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
            chkLstLogLevel.Items.AddRange(LogLevels.Select(l => new CheckedListBoxItem(l, UserSettingsManager.UserSettings.FilteringExclusion.IsLogLevelExcluded(l))).ToArray());

        }

        public static void OpenLink(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo(url)
                {
                    UseShellExecute = true,
                    Verb = "open"
                });
            }
            catch (Exception exception)
            {
                AnalogyLogger.Instance.LogException($"Error: {exception.Message}", exception, "");
            }
        }

        public static string CurrentDirectory()
        {
            string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var directory = System.IO.Path.GetDirectoryName(location);
            return directory;
        }

        public static string GetOpenFilter(string openFilter)
        {
            if (!UserSettingsManager.UserSettings.EnableCompressedArchives)
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

        public static T? GetLogWindows<T>(Control mainControl) where T : class
        {
            while (true)
            {
                if (mainControl is T logWindow)
                {
                    return logWindow;
                }

                if (mainControl is SplitContainer split)
                {
                    var log1 = GetLogWindows<T>(split.Panel1);
                    if (log1 != null)
                    {
                        return log1;
                    }

                    mainControl = split.Panel2;
                    continue;
                }

                for (int i = 0; i < mainControl.Controls.Count; i++)
                {
                    var control = mainControl.Controls[i];
                    if (control is T logWindow2)
                    {
                        return logWindow2;
                    }

                    if (GetLogWindows<T>(control) is T log)
                    {
                        return log;
                    }
                }

                return null;
            }
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

        public static DateTime GetOffsetTime(DateTime time)
        {
            return UserSettingsManager.UserSettings.TimeOffsetType switch
            {
                TimeOffsetType.None => time,
                TimeOffsetType.Predefined => time.Add(UserSettingsManager.UserSettings.TimeOffset),
                TimeOffsetType.UtcToLocalTime => time.ToLocalTime(),
                TimeOffsetType.LocalTimeToUtc => time.ToUniversalTime(),
                _ => time
            };
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