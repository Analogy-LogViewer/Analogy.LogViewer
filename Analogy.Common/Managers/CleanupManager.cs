using System;
using System.Collections.Generic;
using System.IO;
using Analogy.Interfaces;
using Microsoft.Extensions.Logging;
using Exception = System.Exception;

namespace Analogy.Common.Managers
{
    public class CleanupManager
    {
        private static Lazy<CleanupManager> _instance = new Lazy<CleanupManager>();
        public static CleanupManager Instance => _instance.Value;

        private List<string> FoldersToClean { get; set; }

        public CleanupManager()
        {
            FoldersToClean = new List<string>();
        }

        public void AddFolder(string path)
        {
            if (!FoldersToClean.Contains(path))
            {
                FoldersToClean.Add(path);
            }
        }

        public void Clean(ILogger logger)
        {
            foreach (string path in FoldersToClean)
            {

                if (Directory.Exists(path))
                {
                    try
                    {
                        Directory.Delete(path, true);
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, $"Error delete folder: {e.Message}", e, "Cleanup");
                    }
                }
            }


        }
    }
}
