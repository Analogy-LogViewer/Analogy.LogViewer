using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;

namespace Analogy.LogLoaders
{
    public class GeneralFileParser
    {
        private LogParserSettings _logFileSettings;
        private string[] splitters;

        public GeneralFileParser(LogParserSettings logFileSettings)
        {
            _logFileSettings = logFileSettings;
            splitters = _logFileSettings.Splitter.Split();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnalogyLogMessage Parse(string line)
        {
            var items = line.Split(splitters, StringSplitOptions.RemoveEmptyEntries).ToList();
            var sameSize = items.Take(_logFileSettings.Maps.Values.Count);
            var data = _logFileSettings.Maps.Values.Zip(sameSize,(name,value)=> (name,value));
            return AnalogyLogMessage.Parse(data);
        }
    }
}
