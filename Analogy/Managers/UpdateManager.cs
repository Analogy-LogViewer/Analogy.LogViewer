using System;
using System.Diagnostics;

namespace Analogy.Managers
{
    public class UpdateManager
    {
        private static readonly Lazy<UpdateManager>
            _instance = new Lazy<UpdateManager>(() => new UpdateManager());

        public static readonly UpdateManager Instance = _instance.Value;

        public string CurrentVersion { get; }


        public UpdateManager()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            CurrentVersion = fvi.FileVersion;
        }
    }
}
