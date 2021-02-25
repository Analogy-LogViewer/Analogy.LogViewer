using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;

namespace Analogy.Managers
{
    public class AnalogyNonPersistSettings
    {
        private static readonly Lazy<AnalogyNonPersistSettings> _instance =
            new Lazy<AnalogyNonPersistSettings>(() => new AnalogyNonPersistSettings());
        public static AnalogyNonPersistSettings Instance { get; set; } = _instance.Value;
        private static string AnalogyRegistryKey => @"SOFTWARE\Analogy.LogViewer";
        public List<string> AdditionalAssembliesDependenciesLocations { get; }
        public bool DisableUpdatesByDataProvidersOverrides { get; set; }
        public bool DisableUpdateFromRegistry { get; set; }

        public bool UpdateAreDisabled => DisableUpdateFromRegistry || DisableUpdatesByDataProvidersOverrides;

        public string CurrentLogLayoutFileName { get; } = "AnalogyLogsCurrentLayout.xml";
        public string CurrentLogLayoutName { get; } = "Active Layout";
        public AnalogyNonPersistSettings()
        {
            AdditionalAssembliesDependenciesLocations = new List<string>();
            try
            {
                using (RegistryKey? key = Registry.LocalMachine.OpenSubKey(AnalogyRegistryKey))
                {
                    object? updateRegistryValue = key?.GetValue("DisableUpdates");
                    if (updateRegistryValue != null && bool.TryParse(updateRegistryValue.ToString(), out var disable))
                    {
                        AnalogyLogger.Instance.LogInformation($"Disable mode: {disable}");
                        DisableUpdateFromRegistry = disable;
                    }
                }
            }
            catch (Exception e)
            {
                AnalogyLogManager.Instance.LogError($"Error reading registry: {e}", nameof(AnalogyNonPersistSettings));
            }

        }

        public void AddDependencyLocation(string path)
        {
            if (Directory.Exists(path))
            {
                if (!AdditionalAssembliesDependenciesLocations.Contains(path))
                {
                    AdditionalAssembliesDependenciesLocations.Add(path);
                }
                else
                {
                    AnalogyLogManager.Instance.LogWarning($"{path} already exist in dependencies list", nameof(AddDependencyLocation));
                }
            }
            else
            {
                AnalogyLogManager.Instance.LogError($"{path} does not exist. Ignoring", nameof(AddDependencyLocation));
            }
        }
    }
}
