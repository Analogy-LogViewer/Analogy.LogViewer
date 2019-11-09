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
        private readonly LogParserSettings _logFileSettings;
        private readonly string[] splitters;

        public GeneralFileParser(LogParserSettings logFileSettings)
        {
            _logFileSettings = logFileSettings;
            splitters = _logFileSettings.Splitter.Split();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AnalogyLogMessage Parse(string line)
        {
            var items = line.Split(splitters, StringSplitOptions.RemoveEmptyEntries).ToList();
            List< (AnalogyLogMessagePropertyName , string ) > map = new List<(AnalogyLogMessagePropertyName, string)>();
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                if (_logFileSettings.Maps.ContainsKey(i))
                {
                    map.Add((_logFileSettings.Maps[i],items[i]));
                }
            }
            return AnalogyLogMessage.Parse(map);
        }
    }
}
