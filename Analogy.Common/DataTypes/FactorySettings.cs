using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Common.DataTypes
{
    [Serializable]
    public class FactorySettings
    {
        public string FactoryName { get; set; }
        public Guid FactoryId { get; set; }
        public List<string> UserSettingFileAssociations { get; set; }
        public DataProviderFactoryStatus Status { get; set; }

        public FactorySettings()
        {
            UserSettingFileAssociations = new List<string>();
        }
        public override string ToString() => $"{nameof(FactoryName)}: {FactoryName}, {nameof(FactoryId)}: {FactoryId}, {nameof(Status)}: {Status}";

    }
}
