using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.CommonControls.Interfaces;
using Analogy.Interfaces;

namespace Analogy.CommonControls.Managers
{
    public class DefaultExtensionManager : IExtensionsManager
    {
        public IEnumerable<IAnalogyExtension> GetExtensions()
        {
            return new List<IAnalogyExtension>(0);
        }

        public bool HasAny { get; } = false;
        public IEnumerable<IAnalogyExtension> RegisteredExtensions { get; } = new List<IAnalogyExtension>(0);
        public bool HasAnyInPlace { get; } = false;
        public bool HasAnyUserControl { get; } = false;
        public IEnumerable<IAnalogyExtensionInPlace> InPlaceRegisteredExtensions { get; }=new List<IAnalogyExtensionInPlace>(0);
        public IEnumerable<IAnalogyExtensionUserControl> UserControlRegisteredExtensions { get; } = new List<IAnalogyExtensionUserControl>(0);
        public void RegisterExtension(IAnalogyExtension analogyExtension)
        {
        }

        public int GetIndexForExtension(IAnalogyExtension extension)
        {
            return -1;
        }
    }
}
