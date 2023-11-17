using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Common.DataTypes
{
    [Serializable]
    public class PreDefineFilter
    {
        public string Name { get; set; }
        public string IncludeText { get; }
        public string ExcludeText { get; }
        public string Sources { get; }
        public string Modules { get; }

        public PreDefineFilter(string name, string includeText, string excludeText, string sources, string modules)
        {
            Name = name ?? string.Empty;
            IncludeText = includeText ?? string.Empty;
            ExcludeText = excludeText ?? string.Empty;
            Sources = sources ?? string.Empty;
            Modules = modules ?? string.Empty;
        }
        public override string ToString()
        {
            return $"Filter: Message Text:{IncludeText}. Exclude:{ExcludeText}. Sources:{Sources}. Modules:{Modules}";
        }

        public string NiceText() =>
            $"Message Text: {IncludeText}{Environment.NewLine}Exclude Text: {ExcludeText}{Environment.NewLine}Sources: {Sources}{Environment.NewLine}Module: {Modules}";
    }
}