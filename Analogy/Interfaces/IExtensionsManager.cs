using System.Collections.Generic;
using Philips.Analogy.Interfaces.Interfaces;

namespace Philips.Analogy.Interfaces
{
    interface IExtensionsManager
    {
        IEnumerable<IAnalogyExtension> GetExtensions();
        bool HasAny { get; }
        IEnumerable<IAnalogyExtension> RegisteredExtensions { get; }
        bool HasAnyInPlace { get; }
        bool HasAnyUserControl { get; }
        IEnumerable<IAnalogyExtension> InPlaceRegisteredExtensions { get; }
        IEnumerable<IAnalogyExtension> UserControlRegisteredExtensions { get; }

        void RegisterExtension(IAnalogyExtension analogyExtension);
        int GetIndexForExtension(IAnalogyExtension extension);
    }
}
