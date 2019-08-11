using Philips.Analogy.Interfaces;
using System;
using System.Linq;

namespace Philips.Analogy.Extensions
{
    public class EnvironmentDataEntry
    {
        public string Hostname { get; } = string.Empty;
        public float NormalSliceUsage { get; }
        public float TotalWeightUsage { get; }
        public int UserCount { get; }
        public int ClinicalUserCount { get; }
        public float AvgCPUUsage { get; }
        public int AvailableMemoryGB { get; }
        public float MaxAvgCPUUsage { get; }
        public DateTime DateTime { get; }
        public EnvironmentDataEntry(float normalSliceUsage, float totalWeightUsage, int userCount, int clinicalUserCount, float avgCpuUsage, int availableMemoryGb, float maxAvgCpuUsage, DateTime time)
        {
            NormalSliceUsage = normalSliceUsage;
            TotalWeightUsage = totalWeightUsage;
            UserCount = userCount;
            ClinicalUserCount = clinicalUserCount;
            AvgCPUUsage = avgCpuUsage;
            AvailableMemoryGB = availableMemoryGb;
            MaxAvgCPUUsage = maxAvgCpuUsage;
            DateTime = time;
        }

        public EnvironmentDataEntry(string[] items, AnalogyLogMessage message)
        {
            DateTime = message.Date;
            Hostname = items.First();
            for (var index = 1; index < items.Length; index++)
            {
                var item = items[index];
                if (item.StartsWith("normalSliceUsage"))
                    NormalSliceUsage = float.Parse(item.Substring(item.IndexOf("=") + 1).Trim('%'));
                else if (item.StartsWith("totalWeightUsage"))
                    TotalWeightUsage = float.Parse(item.Substring(item.IndexOf("=") + 1).Trim('%'));
                else if (item.StartsWith("userCount"))
                    UserCount = int.Parse(item.Substring(item.IndexOf("=") + 1).Trim('%'));
                else if (item.StartsWith("clinicalUserCount"))
                    ClinicalUserCount = int.Parse(item.Substring(item.IndexOf("=") + 1).Trim('%'));
                else if (item.StartsWith("avgCPUUsage"))
                    AvgCPUUsage = float.Parse(item.Substring(item.IndexOf("=") + 1).Trim('%'));
                else if (item.StartsWith("AvailableMemory"))
                    AvailableMemoryGB = int.Parse(item.Substring(item.IndexOf("=") + 1).Trim('M', 'B', ' ')) /1024;
                else if (item.StartsWith("maxTotalWeightUsage"))
                    TotalWeightUsage = float.Parse(item.Substring(item.IndexOf("=") + 1));
                else if (item.StartsWith("maxAvgCPUUsage"))
                    MaxAvgCPUUsage = float.Parse(item.Substring(item.IndexOf("=") + 1).Trim('%'));
            }
        }
    }
}
