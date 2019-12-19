using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Analogy.Interfaces;

namespace Analogy
{
    public class ExtensionsManager : IExtensionsManager
    {
        private static readonly Lazy<ExtensionsManager> instance = new Lazy<ExtensionsManager>(() => new ExtensionsManager());
        public static ExtensionsManager Instance => instance.Value;
        private IAnalogyLogger Log { get; } = AnalogyLogger.Intance;
        private List<IAnalogyExtension> LoadedExtensions { get; } = new List<IAnalogyExtension>();
        private readonly List<IAnalogyExtension> registeredExtensions = new List<IAnalogyExtension>();
        public bool HasAny => RegisteredExtensions.Any();
        public IEnumerable<IAnalogyExtension> RegisteredExtensions => registeredExtensions.ToList();
        public bool HasAnyInPlace => InPlaceRegisteredExtensions.Any();
        public bool HasAnyUserControl => UserControlRegisteredExtensions.Any();

        public IEnumerable<IAnalogyExtension> InPlaceRegisteredExtensions =>
            registeredExtensions.Where(e => e.AnalogyExtensionType == AnalogyExtensionType.InPlace).ToList();
        public IEnumerable<IAnalogyExtension> UserControlRegisteredExtensions =>
            registeredExtensions.Where(e => e.AnalogyExtensionType == AnalogyExtensionType.UserControl).ToList();
        private int ColumnIndexes { get; set; } = 12;
        private readonly List<Tuple<IAnalogyExtension, AnalogyColumnInfo, int>> extensionsDataColumns =
            new List<Tuple<IAnalogyExtension, AnalogyColumnInfo, int>>();

        private ExtensionsManager()
        {

        }
        public int GetIndexForExtension(IAnalogyExtension extension)
            => extensionsDataColumns.Single(e => e.Item1 == extension).Item3;

        public void RegisterExtension(IAnalogyExtension extension)
        {
            if (extension == null) return;
            registeredExtensions.Add(extension);
            if (extension.AnalogyExtensionType == AnalogyExtensionType.InPlace)
            {
                var columns = extension.GetColumnsInfo();
                foreach (AnalogyColumnInfo column in columns)
                {
                    extensionsDataColumns.Add(
                        new Tuple<IAnalogyExtension, AnalogyColumnInfo, int>(extension, column, ColumnIndexes));
                    ColumnIndexes++;
                }
            }
        }

        public IEnumerable<IAnalogyExtension> GetExtensions()
        {
            if (LoadedExtensions.Any()) return LoadedExtensions;
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            List<string> files = appSettings["AssembliesToLoad"]
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string dir = Environment.CurrentDirectory;
            Type isExtension = typeof(IAnalogyExtension);

            List<Type> res = new List<Type>();
            files.AddRange(Directory.GetFiles(dir, "Analogy.*.Extension.dll"));
            foreach (var file in files)
            {
                var fileToload = Path.Combine(dir, file);
                if (!File.Exists(fileToload))
                {
                    Log.LogError("Analogy", $"{file} does not exist. Skipping");
                    continue;
                }
                try
                {
                    var assm = Assembly.LoadFrom(fileToload).GetTypes()
                        .Where(t => t.GetInterfaces().Any(i => i.Name.Equals(isExtension.Name))).ToList();
                    res.AddRange(assm);
                }
                catch (Exception ex)
                {
                    Log.LogError("Analogy", $"Error for:{file}: {ex.Message}");
                }
            }

            foreach (Type type in res)
            {
                try
                {
                    IAnalogyExtension control = (IAnalogyExtension)Activator.CreateInstance(type);
                    LoadedExtensions.Add(control);
                }
                catch (Exception exception)
                {
                    Log.LogError("Analogy", $"Error for:{type.Name}: {exception.Message}");
                }
            }

            return LoadedExtensions;
        }
    }
}
