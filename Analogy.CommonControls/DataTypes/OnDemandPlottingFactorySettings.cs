using Analogy.Common.DataTypes;
using Analogy.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
}