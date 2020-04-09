namespace Analogy
{
    public class ItemStatistics
    {
        public string Name { get; private set; }
        public int TotalMessages { get; private set; }
        public int Errors { get; private set; }
        public int Warnings { get; private set; }
        public int Critical { get; private set; }
        public int Events { get; private set; }
        public int Debug { get; private set; }
        public int Verbose { get; private set; }

        public ItemStatistics(string name, int total, int errors, int warnings, int critical, int events, int debug, int verbose)
            => (Name, TotalMessages, Errors, Warnings, Critical, Events, Debug, Verbose) =
                (name, total, errors, warnings, critical, events, debug, verbose);

    }
}
