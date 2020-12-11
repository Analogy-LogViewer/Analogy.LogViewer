using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Managers
{
    public class AnalogyNonPersistSettings
    {
        private static readonly Lazy<AnalogyNonPersistSettings> _instance =
            new Lazy<AnalogyNonPersistSettings>(() => new AnalogyNonPersistSettings());
        public static AnalogyNonPersistSettings Instance { get; set; } = _instance.Value;
        public List<string> AdditionalAssembliesDependenciesLocations { get; }
        public AnalogyNonPersistSettings()
        {
            AdditionalAssembliesDependenciesLocations=new List<string>();
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
                    AnalogyLogManager.Instance.LogWarning($"{path} already exist in dependencies list",nameof(AddDependencyLocation));
                }
            }
            else
            {
                AnalogyLogManager.Instance.LogError($"{path} does not exist. Ignoring", nameof(AddDependencyLocation));
            }
        }
    }
}
