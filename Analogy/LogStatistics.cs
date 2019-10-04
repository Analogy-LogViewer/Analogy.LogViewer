using System.Collections.Generic;
using System.Linq;
using Philips.Analogy.Interfaces.DataTypes;

namespace Philips.Analogy
{
    public class LogStatistics
    {
        private List<AnalogyLogMessage> Messages { get; }
        private List<string> Sources => Messages.Select(m => m.Source).Distinct().ToList();
        private List<string> Modules => Messages.Select(m => m.Module).Distinct().ToList();

        public LogStatistics(List<AnalogyLogMessage> messages)
        {
            Messages = messages;
        }

        public ItemStatistics CalculateGlobalStatistics()
        {
            return new ItemStatistics("Global", Messages.Count, CountMessages(Messages, AnalogyLogLevel.Error),
                CountMessages(Messages, AnalogyLogLevel.Warning), CountMessages(Messages, AnalogyLogLevel.Critical),
                CountMessages(Messages, AnalogyLogLevel.Event), CountMessages(Messages, AnalogyLogLevel.Debug),
                CountMessages(Messages, AnalogyLogLevel.Verbose));
        }
        public IEnumerable<ItemStatistics> CalculateModulesStatistics()
        {
            foreach (var module in Modules)
            {
                yield return new ItemStatistics(module, Messages.Count(m => m.Module.Equals(module)),
                    CountModuleMessages(module, AnalogyLogLevel.Error), CountModuleMessages(module, AnalogyLogLevel.Warning),
                    CountModuleMessages(module, AnalogyLogLevel.Critical), CountModuleMessages(module, AnalogyLogLevel.Event),
                    CountModuleMessages(module, AnalogyLogLevel.Debug), CountModuleMessages(module, AnalogyLogLevel.Verbose));
            }

        }
        public IEnumerable<ItemStatistics> CalculateSourcesStatistics()
        {
            foreach (var source in Sources)
            {
                yield return new ItemStatistics(source, Messages.Count(m => m.Source.Equals(source)),
                    CountSourceMessages(source, AnalogyLogLevel.Error), CountSourceMessages(source, AnalogyLogLevel.Warning),
                    CountSourceMessages(source, AnalogyLogLevel.Critical), CountSourceMessages(source, AnalogyLogLevel.Event),
                    CountSourceMessages(source, AnalogyLogLevel.Debug), CountSourceMessages(source, AnalogyLogLevel.Verbose));
            }

        }

        private int CountMessages(List<AnalogyLogMessage> messages, AnalogyLogLevel level) => messages.Count(m => m.Level == level);
        private int CountModuleMessages(string module, AnalogyLogLevel level) => Messages.Count(m => m.Level == level && m.Module.Equals(module));
        private int CountSourceMessages(string source, AnalogyLogLevel level) => Messages.Count(m => m.Level == level && m.Source.Equals(source));
    }
}
