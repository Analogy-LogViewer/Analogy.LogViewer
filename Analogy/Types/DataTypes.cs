using System;
using System.Drawing;
using System.Windows.Forms;

namespace Analogy
{
    public struct FactoryCheckItem
    {
        public string Name { get; }
        public Guid ID { get; }
        public string Description { get; }
        public Image Image { get; }

        public FactoryCheckItem(string name, Guid id, string description, Image image)
        {
            Name = name;
            ID = id;
            Description = description;
            Image = image;
        }

        public override string ToString() => $"{Name} ({ID})";
    }
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
    public class FilterCriteriaUIOption
    {
        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }
        public bool CheckMember { get; set; }


        public FilterCriteriaUIOption(string displayMember, string valueMember, bool checkMember)
        {
            DisplayMember = displayMember;
            ValueMember = valueMember;
            CheckMember = checkMember;
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
