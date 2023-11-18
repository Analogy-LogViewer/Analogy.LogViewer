using Analogy.LogViewer.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Common.DataTypes
{
    public class FileAssociations
    {
        public Guid OfflineDataProviderId { get; set; }
        public IEnumerable<string> Associations { get; set; }

        public FileAssociations(Guid dataProviderId, IEnumerable<string> fileAssociations)
        {
            OfflineDataProviderId = dataProviderId;
            Associations = fileAssociations;
        }

        public void Update(List<string> fileAssociations)
        {
            Associations = fileAssociations;
        }
    }
}