using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.Types;

namespace Analogy.Managers
{
    public class ExternalDataProviders
    {
        private static readonly AsyncLazy<ExternalDataProviders> _instance =
            new AsyncLazy<ExternalDataProviders>(() => new ExternalDataProviders());

        public static async Task<ExternalDataProviders> GetExternalDataProviders() => await _instance.Start();
        public List<FactoryContainer> Factories { get; private set; }
        public List<(Guid id, IAnalogyImages images)> DataProvidersImages { get; set; }

        private ExternalDataProviders()
        {
            DataProvidersImages = new List<(Guid id, IAnalogyImages images)>();
            Factories = new List<FactoryContainer>();
            var analogyAssemblies = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory,
                @"*Analogy.LogViewer.*.dll", SearchOption.TopDirectoryOnly).ToList();
            if (UserSettingsManager.UserSettings.AdditionalProbingLocations != null)
            {
                foreach (string folder in UserSettingsManager.UserSettings.AdditionalProbingLocations)
                {
                    try
                    {
                        if (Directory.Exists(folder))
                            analogyAssemblies.AddRange(Directory.EnumerateFiles(folder, @"*Analogy.LogViewer.*.dll",
                                SearchOption.TopDirectoryOnly).ToList());
                    }
                    catch (Exception e)
                    {
                        AnalogyLogger.Instance.LogException($"Error probing folder {folder}. Error: {e.Message}", e, nameof(ExternalDataProviders));
                    }
                }


            }
            foreach (string aFile in analogyAssemblies)
            {
                try
                {
                    string fileName = Path.GetFullPath(aFile);
                    string path = Path.GetDirectoryName(aFile);
                    Assembly assembly = Assembly.LoadFrom(fileName);
                    if (!FactoriesManager.Instance.ProbingPaths.Contains(path))
                        FactoriesManager.Instance.ProbingPaths.Add(path);
                    var types = assembly.GetTypes().ToList();

                    foreach (var f in types.Where(aType => aType.GetInterface(nameof(IAnalogyFactory)) != null))
                    {
                        var factory = Activator.CreateInstance(f) as IAnalogyFactory;
                        var setting = UserSettingsManager.UserSettings.GetOrAddFactorySetting(factory);
                        setting.FactoryName = factory.Title;
                        FactoryContainer fc = new FactoryContainer(assembly, fileName, factory, setting);
                        if (Factories.Exists(fa => fa.Factory.FactoryId == factory.FactoryId))
                        {
                            Factories.Remove(Factories.FirstOrDefault(fa =>
                                fa.Factory.FactoryId == factory.FactoryId));
                        }
                        Factories.Add(fc);

                    }
                    foreach (var t in types.Where(aType => aType.GetInterface(nameof(IAnalogyImages)) != null))
                    {
                        var images = Activator.CreateInstance(t) as IAnalogyImages;
                        var factory = Factories.First(f => f.Assembly == assembly);
                        factory.AddComponentImages(images);

                    }
                    foreach (var t in types.Where(aType => aType.GetInterface(nameof(IAnalogyImages)) != null))
                    {
                        var images = Activator.CreateInstance(t) as IAnalogyImages;
                        var factory = Factories.First(f => f.Assembly == assembly);
                        factory.AddImages(images);

                    }

                    foreach (Type aType in types.Where(aType =>
                        aType.GetInterface(nameof(IAnalogyDataProvidersFactory)) != null))
                    {

                        var dataProviderFactory = Activator.CreateInstance(aType) as IAnalogyDataProvidersFactory;
                        var factory = Factories.FirstOrDefault(f => f.Factory.FactoryId == dataProviderFactory?.FactoryId);
                        factory?.AddDataProviderFactory(dataProviderFactory);
                    }

                    foreach (Type aType in types.Where(aType =>
                        aType.GetInterface(nameof(IAnalogyDataProviderSettings)) != null))
                    {

                        var settings = Activator.CreateInstance(aType) as IAnalogyDataProviderSettings;
                        var factory = Factories.FirstOrDefault(f => f.Factory.FactoryId == settings?.FactoryId);
                        factory?.AddDataProvidersSettings(settings);
                    }

                    foreach (Type aType in types.Where(aType =>
                        aType.GetInterface(nameof(IAnalogyCustomActionsFactory)) != null))
                    {

                        var custom = Activator.CreateInstance(aType) as IAnalogyCustomActionsFactory;
                        var factory = Factories.FirstOrDefault(f => f.Factory.FactoryId == custom?.FactoryId);
                        factory?.AddCustomActionFactory(custom);
                    }

                    foreach (Type aType in types.Where(aType =>
                        aType.GetInterface(nameof(IAnalogyShareableFactory)) != null))
                    {

                        var share = Activator.CreateInstance(aType) as IAnalogyShareableFactory;
                        var factory = Factories.FirstOrDefault(f => f.Factory.FactoryId == share?.FactoryId);
                        factory?.AddShareableFactory(share);
                    }
                    foreach (Type aType in types.Where(aType =>
                        aType.GetInterface(nameof(IAnalogyExtensionsFactory)) != null))
                    {

                        var extension = Activator.CreateInstance(aType) as IAnalogyExtensionsFactory;
                        var factory = Factories.FirstOrDefault(f => f.Factory.FactoryId == extension?.FactoryId);
                        factory?.AddExtensionFactory(extension);
                    }
                }
                catch (ReflectionTypeLoadException ex)
                {
                    AnalogyLogManager.Instance.LogError(
                        $"{aFile}: Error during data providers: {string.Join(",", ex.LoaderExceptions.ToList())}. {aFile})",
                        nameof(FactoriesManager));
                }
                catch (Exception e)
                {
                    AnalogyLogManager.Instance.LogError(
                        $"{aFile}: Error during data providers: {e} ({e.InnerException}. {aFile})",
                        nameof(FactoriesManager));
                }

            }

            Factories.RemoveAll(f => f.FactorySetting.Status == DataProviderFactoryStatus.Disabled);
        }

    }
}
