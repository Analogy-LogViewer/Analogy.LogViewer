using Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Common.DataTypes
{
    [Serializable]
    public class FilteringExclusion
    {
        public List<string> ExcludeTexts { get; set; }
        public List<string> ExcludeSources { get; set; }
        public List<string> ExcludeModules { get; set; }
        public Dictionary<string, bool> ExcludeLogLevels { get; set; }

        public FilteringExclusion()
        {
            ExcludeTexts = new List<string>();
            ExcludeModules = new List<string>();
            ExcludeSources = new List<string>();
            ExcludeLogLevels = new Dictionary<string, bool>();
            foreach (string value in CommonUtils.LogLevels)
            {
                ExcludeLogLevels.Add(value, false);
            }
        }

        public bool IsLogLevelExcluded(AnalogyLogLevel level) => IsLogLevelExcluded(level.ToString());
        public bool IsLogLevelExcluded(string level) => ExcludeLogLevels.ContainsKey(level) && ExcludeLogLevels[level];

        public void SetLogLevelExclusion(string level, bool exclude) => ExcludeLogLevels[level] = exclude;
    }
}