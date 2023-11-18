using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Managers
{
    public class FolderAccessManager : IAnalogyFoldersAccess
    {
        public event EventHandler? RootFolderChanged;
        public string WriteableRootFolder { get; private set; }
        public string ConfigurationsFolder { get; private set; }
        private bool IsRunningFromProgramFileFolder { get; } = Utils.IsRunningFromProgramFileFolder();
        private string ApplicationDataFolder => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Analogy Log Viewer");
        private string CommonApplicationData => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Analogy Log Viewer");
        public void SetWorkingMode(SettingsMode settingsMode)
        {
            switch (settingsMode)
            {
                case SettingsMode.PerUser:
                    WriteableRootFolder = ApplicationDataFolder;
                    ConfigurationsFolder = Path.Combine(WriteableRootFolder, "Configuration Files");
                    Directory.CreateDirectory(ConfigurationsFolder);
                    break;
                case SettingsMode.ApplicationFolder:
                    if (IsRunningFromProgramFileFolder)
                    {
                        WriteableRootFolder = CommonApplicationData;
                        ConfigurationsFolder = Path.Combine(WriteableRootFolder, "Configuration Files");
                        Directory.CreateDirectory(ConfigurationsFolder);
                    }
                    else
                    {
                        WriteableRootFolder = Utils.ApplicationBaseDirectory;
                        ConfigurationsFolder = Utils.ApplicationBaseDirectory;
                    }
                    break;
                case SettingsMode.ProgramData:
                    WriteableRootFolder = CommonApplicationData;
                    ConfigurationsFolder = Path.Combine(WriteableRootFolder, "Configuration Files");
                    Directory.CreateDirectory(ConfigurationsFolder);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            RootFolderChanged?.Invoke(this, EventArgs.Empty);
        }
        private string GetConfigurationFilePath(string folder, string configFile)
        {
            if (Path.IsPathRooted(configFile) && !Path.GetPathRoot(configFile)
                    .Equals(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
            {
                return configFile; //already mapped to full path
            }
#if NET
            return Path.Join(folder, configFile);
#else
            return Path.Combine(folder, configFile);
#endif
        }

        public string GetConfigurationFilePath(string configFile) =>
            GetConfigurationFilePath(ConfigurationsFolder, configFile);

        public bool TryGetConfigurationFilePathFromAnyValidLocation(string configFile, out string finalLocation)
        {
            var file = GetConfigurationFilePath(Utils.ApplicationBaseDirectory, configFile);
            if (File.Exists(file))
            {
                finalLocation = file;
                return true;
            }
            file = GetConfigurationFilePath(CommonApplicationData, configFile);
            if (File.Exists(file))
            {
                finalLocation = file;
                return true;
            }
            file = GetConfigurationFilePath(ApplicationDataFolder, configFile);
            if (File.Exists(file))
            {
                finalLocation = file;
                return true;
            }

            finalLocation = "";
            return false;
        }
    }
}