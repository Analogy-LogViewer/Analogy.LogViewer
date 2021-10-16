using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Analogy.CommonControls.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;

namespace Analogy.CommonControls
{
    public static class Utils
    {
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
    }
}
