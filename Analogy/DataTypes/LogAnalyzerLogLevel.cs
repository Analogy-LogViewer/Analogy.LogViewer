using System.Collections.Generic;

namespace Analogy.DataTypes
{
    public class LogAnalyzerLogLevel
    {
        public string Name { get; private set; }
        public int Messages { get; private set; }
        public int Error { get; private set; }
        public int Warning { get; private set; }
        public int Critical { get; private set; }
        public int Information { get; private set; }
        public int Debug { get; private set; }
        public int Verbose { get; private set; }
        public int Trace { get; private set; }

        public LogAnalyzerLogLevel(string name, int total, int errors, int warnings, int critical, int events, int debug, int verbose,int trace)
            => (Name, Messages, Error, Warning, Critical, Information, Debug, Verbose,Trace) =
                (name, total, errors, warnings, critical, events, debug, verbose,trace);

        public IEnumerable<LogAnalyzerSingleDataPoint> AsList()
        {
            yield return new LogAnalyzerSingleDataPoint("Total Messages", Messages);
            yield return new LogAnalyzerSingleDataPoint(nameof(Critical), Critical);
            yield return new LogAnalyzerSingleDataPoint(nameof(Error), Error);
            yield return new LogAnalyzerSingleDataPoint(nameof(Warning), Warning);
            yield return new LogAnalyzerSingleDataPoint(nameof(Verbose), Verbose);
            yield return new LogAnalyzerSingleDataPoint(nameof(Debug), Debug);
            yield return new LogAnalyzerSingleDataPoint(nameof(Information), Information);
            yield return new LogAnalyzerSingleDataPoint(nameof(Trace), Trace);
        }
        public IEnumerable<LogAnalyzerSingleDataPoint> AsListWithoutTotal()
        {
            yield return new LogAnalyzerSingleDataPoint(nameof(Critical), Critical);
            yield return new LogAnalyzerSingleDataPoint(nameof(Error), Error);
            yield return new LogAnalyzerSingleDataPoint(nameof(Warning), Warning);
            yield return new LogAnalyzerSingleDataPoint(nameof(Verbose), Verbose);
            yield return new LogAnalyzerSingleDataPoint(nameof(Debug), Debug);
            yield return new LogAnalyzerSingleDataPoint(nameof(Information), Information);
            yield return new LogAnalyzerSingleDataPoint(nameof(Trace), Trace);
        }
        
    }

    public class LogAnalyzerSingleDataPoint
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public LogAnalyzerSingleDataPoint(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
