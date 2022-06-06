using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Interfaces;
using Newtonsoft.Json;

namespace Analogy.CommonControls.DataTypes
{






    [Serializable]
    public class OnDemandPlottingFactorySettings
    {
        public Guid FactoryId { get; set; }
        public DataProviderFactoryStatus Status { get; set; }

        public OnDemandPlottingFactorySettings()
        {
        }
        public override string ToString() => $"{nameof(FactoryId)}: {FactoryId}, {nameof(Status)}: {Status}";

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