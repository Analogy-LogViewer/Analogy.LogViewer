using Analogy.Common.Interfaces;
using Analogy.CommonControls.Interfaces;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.WinForms;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Analogy
{
    public class ExtensionsManager : IExtensionsManager
    {
        private IFactoriesManager FactoriesManager { get; }
        private ILogger Logger { get; }
        private List<IAnalogyExtension> LoadedExtensions { get; } = new List<IAnalogyExtension>();
        private readonly List<IAnalogyExtension> registeredExtensions = new List<IAnalogyExtension>();
        public bool HasAny => RegisteredExtensions.Any();
        public IEnumerable<IAnalogyExtension> RegisteredExtensions => registeredExtensions.ToList();
        public bool HasAnyInPlace => InPlaceRegisteredExtensions.Any();
        public bool HasAnyUserControl => UserControlRegisteredExtensions.Any();

        public IEnumerable<IAnalogyExtensionInPlace> InPlaceRegisteredExtensions =>
            registeredExtensions.Where(e => e is IAnalogyExtensionInPlace).Cast<IAnalogyExtensionInPlace>();

        public IEnumerable<IAnalogyExtensionUserControlWinForms> UserControlRegisteredExtensions =>
            registeredExtensions.Where(e => e is IAnalogyExtensionUserControlWinForms).Cast<IAnalogyExtensionUserControlWinForms>();
        private int ColumnIndexes { get; set; } = 12;
        private readonly List<Tuple<IAnalogyExtension, AnalogyColumnInfo, int>> extensionsDataColumns =
            new List<Tuple<IAnalogyExtension, AnalogyColumnInfo, int>>();

        public ExtensionsManager(IFactoriesManager factoriesManager, ILogger logger)
        {
            FactoriesManager = factoriesManager;
            Logger = logger;
        }
        public int GetIndexForExtension(IAnalogyExtension extension)
            => extensionsDataColumns.Single(e => e.Item1 == extension).Item3;

        public void RegisterExtension(IAnalogyExtension extension)
        {
            if (extension == null)
            {
                return;
            }

            registeredExtensions.Add(extension);
            if (extension is IAnalogyExtensionInPlace inPlaceExtension)
            {
                var columns = inPlaceExtension.GetColumnsInfo();
                foreach (AnalogyColumnInfo column in columns)
                {
                    extensionsDataColumns.Add(
                        new Tuple<IAnalogyExtension, AnalogyColumnInfo, int>(extension, column, ColumnIndexes));
                    ColumnIndexes++;
                }
            }
        }

        public IEnumerable<IAnalogyExtension> GetExtensions() => FactoriesManager.GetAllExtensions();
    }
}