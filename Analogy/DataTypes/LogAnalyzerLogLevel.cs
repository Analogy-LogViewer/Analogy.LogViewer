using System.Collections.Generic;

namespace Analogy.DataTypes
{
    public class LogAnalyzerLogLevel
    {
        public string Name { get; private set; }
        public int TotalMessages { get; private set; }
        public int Error { get; private set; }
        public int Warning { get; private set; }
        public int Critical { get; private set; }
        public int Information { get; private set; }
        public int Debug { get; private set; }
        public int Verbose { get; private set; }
        public int Trace { get; private set; }

        public LogAnalyzerLogLevel(string name, int total, int errors, int warnings, int critical, int events, int debug, int verbose,int trace)
            => (Name, TotalMessages, Error, Warning, Critical, Information, Debug, Verbose,Trace) =
                (name, total, errors, warnings, critical, events, debug, verbose,trace);

        public IEnumerable<Statistics> AsList()
        {
            yield return new Statistics(nameof(Critical), Critical);
            yield return new Statistics(nameof(Error), Error);
            yield return new Statistics(nameof(Warning), Warning);
            yield return new Statistics(nameof(Verbose), Verbose);
            yield return new Statistics(nameof(Debug), Debug);
            yield return new Statistics(nameof(Information), Information);
            yield return new Statistics(nameof(Trace), Trace);
        }
    }

    public class Statistics
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Statistics(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
