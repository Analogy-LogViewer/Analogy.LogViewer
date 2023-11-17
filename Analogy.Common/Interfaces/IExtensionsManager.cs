using Analogy.Interfaces;
using System.Collections.Generic;

namespace Analogy.Common.Interfaces
{
    public interface IExtensionsManager
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