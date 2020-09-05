using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Types
{
    public class DownloadEntry
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Image  Icon { get; set; }
        public string URL { get; set; }
    }
}
