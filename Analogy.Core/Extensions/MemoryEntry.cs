namespace Analogy.Extensions
{
    public class MemoryEntry
    {
        public string Process { get; }
        public int Thread { get; }
        public double TotalMinutes { get; }
        public string StartTime { get; }
        public long WorkingSet64 { get; }
        public long PrivateMemorySize64 { get; }
        public long VirtualMemorySize64 { get; }
        public string TimeWithMilliseconds { get; }
        public string File { get; }
        public MemoryEntry(string process, int thread, double minutes, string startDateTime, long workingSet, long privateSet, long virutal, string time, string file)
        {
            Process = process;
            Thread = thread;
            TotalMinutes = minutes;
            StartTime = startDateTime;
            WorkingSet64 = workingSet;
            PrivateMemorySize64 = privateSet;
            VirtualMemorySize64 = virutal;
            TimeWithMilliseconds = time;
            File = file;
        }
    }
}
