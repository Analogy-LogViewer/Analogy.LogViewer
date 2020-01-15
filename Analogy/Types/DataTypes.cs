using System;

namespace Analogy
{
    public enum DataSourceType
    {
        Client,
        Server,
        NetworkPath,
        LocalPath
    }
    [Serializable]
    public class DataSource
    {
        public string HostNameOrIP { get; set; }
        public string Path { get; set; }
        public DataSourceType Type { get; set; }
        public string DisplayName { get; set; }
        public DataSource(string hostNameOrIp, string path, string displayName, DataSourceType type)
        {
            HostNameOrIP = hostNameOrIp ?? throw new ArgumentNullException(nameof(hostNameOrIp));
            Path = path ?? throw new ArgumentNullException(nameof(path));
            Type = type;
            DisplayName = !string.IsNullOrEmpty(displayName) ? displayName : hostNameOrIp;
        }

        public override string ToString()
        {
            return $"{DisplayName} ({Type})";
        }
    }
}
