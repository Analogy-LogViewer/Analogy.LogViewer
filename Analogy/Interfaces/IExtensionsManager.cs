using System.Collections.Generic;

namespace Analogy.Interfaces
{
    interface IExtensionsManager
    {
        IEnumerable<IAnalogyExtension> GetExtensions();
        bool HasAny { get; }
        IEnumerable<IAnalogyExtension> RegisteredExtensions { get; }
        bool HasAnyInPlace { get; }
        bool HasAnyUserControl { get; }
        IEnumerable<IAnalogyExtensionInPlace> InPlaceRegisteredExtensions { get; }
        IEnumerable<IAnalogyExtensionUserControl> UserControlRegisteredExtensions { get; }

        void RegisterExtension(IAnalogyExtension analogyExtension);
        int GetIndexForExtension(IAnalogyExtension extension);
    }
}
