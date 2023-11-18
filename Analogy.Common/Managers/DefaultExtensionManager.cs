using Analogy.Common.Interfaces;
using Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Common.Managers
{
    public class DefaultExtensionManager : IExtensionsManager
    {
        public IEnumerable<IAnalogyExtension> GetExtensions()
        {
            return new List<IAnalogyExtension>(0);
        }

        public bool HasAny { get; }
        public IEnumerable<IAnalogyExtension> RegisteredExtensions { get; } = new List<IAnalogyExtension>(0);
        public bool HasAnyInPlace { get; }
        public bool HasAnyUserControl { get; }
        public IEnumerable<IAnalogyExtensionInPlace> InPlaceRegisteredExtensions { get; } = new List<IAnalogyExtensionInPlace>(0);
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