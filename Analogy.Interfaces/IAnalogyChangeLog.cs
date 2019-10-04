using System;
using Philips.Analogy.Interfaces.DataTypes;

namespace Philips.Analogy.Interfaces
{
    public interface IAnalogyChangeLog
    {
        /// <summary>
        /// Information about this change
        /// </summary>
        string ChangeInformation { get; }
        /// <summary>
        /// Cgange type
        /// </summary>
        AnalogChangeLogType ChangeLogType { get; }
        /// <summary>
        /// The person who did this commit/fix/change
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Time of the commit
        /// </summary>
        DateTime Date { get; }
    }

    public class AnalogyChangeLog: IAnalogyChangeLog
    {
        public string ChangeInformation { get; }
        public AnalogChangeLogType ChangeLogType { get; }
        public string Name { get; }
        public DateTime Date { get; }

        public AnalogyChangeLog(string changeInformation, AnalogChangeLogType changeLogType, string name, DateTime date)
        {
            ChangeInformation = changeInformation;
            ChangeLogType = changeLogType;
            Name = name;
            Date = date;
        }
    }
}
