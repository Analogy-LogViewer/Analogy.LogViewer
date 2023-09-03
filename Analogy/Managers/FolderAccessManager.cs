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
    internal class FolderAccessManager : IAnalogyFoldersAccess
    {
        public event EventHandler? RootFolderChanged;
        public string WriteableRootFolder { get; }
        public string ConfigurationsFolder { get; }
        private bool IsRunningFromProgramFileFolder { get; }
        public FolderAccessManager(IAnalogyUserSettings settings)
        {
            IsRunningFromProgramFileFolder = Utils.IsRunningFromProgramFileFolder();
            switch (settings.SettingsMode)
            {
                case SettingsMode.PerUser:
                    WriteableRootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Analogy Log Viewer");
                    ConfigurationsFolder = Path.Combine(WriteableRootFolder, "Configuration Files");
                    Directory.CreateDirectory(ConfigurationsFolder);
                    break;
                case SettingsMode.ApplicationFolder:
                    if (IsRunningFromProgramFileFolder)
                    {
                        WriteableRootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Analogy Log Viewer");
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
                    WriteableRootFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Analogy Log Viewer");
                    ConfigurationsFolder = Path.Combine(WriteableRootFolder, "Configuration Files");
                    Directory.CreateDirectory(ConfigurationsFolder);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
            var file = GetConfigurationFilePath(ConfigurationsFolder, configFile);
            if (File.Exists(file))
            {
                finalLocation = file;
                return true;
            }

            if (IsRunningFromProgramFileFolder) //check also app root folder
            {
                file = GetConfigurationFilePath(Utils.ApplicationBaseDirectory, configFile);
                if (File.Exists(file))
                {
                    finalLocation = file;
                    return true;
                }
            }

            finalLocation = "";
            return false;
        }
    }
}