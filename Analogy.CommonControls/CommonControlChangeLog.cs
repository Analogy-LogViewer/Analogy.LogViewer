using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;

namespace Analogy.CommonControls
{
    internal static class CommonControlChangeLog
    {
        public static IEnumerable<AnalogyChangeLog> GetChangeLog()
        {
            return new List<AnalogyChangeLog>
            {
                new AnalogyChangeLog("V1.0.0 - Initial Version",AnalogChangeLogType.Improvement,"Lior Banai",new DateTime(2021,12,01), "")
            };
        }

        public static string GetChangeLogFull => string.Join(Environment.NewLine,
            GetChangeLog().OrderByDescending(c => c.Date).Select(cl => $"{cl.Date.ToString()}: {cl.ChangeInformation} ({cl.Name})"));

    }
}
