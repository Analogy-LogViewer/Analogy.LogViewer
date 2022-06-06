using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;

namespace Analogy.Common
{
    public static class CommonUtils
    {
        public static List<string> LogLevels { get; } = Enum.GetValues(typeof(AnalogyLogLevel)).Cast<AnalogyLogLevel>().Select(e => e.ToString()).ToList();

    }
}
