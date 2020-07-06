using System;
using System.Drawing;
using System.Windows.Forms;

namespace Analogy
{
    [Serializable]
    public class AnalogyPositionState
    {
        public FormWindowState WindowState { get; set; }
        public Point Location { get; set; }
        public Size Size { get; set; }
        public bool RememberLastPosition { get; set; }
        public AnalogyPositionState()
        {
            WindowState = FormWindowState.Maximized;
            RememberLastPosition = true;
        }

        public AnalogyPositionState(FormWindowState formWindowState, Point location, Size size)
        {
            WindowState = formWindowState;
            Location = location;
            Size = size;
        }

    }
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
