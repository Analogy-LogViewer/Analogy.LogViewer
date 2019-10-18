using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Analogy
{
    public class EmbeddedAssembly
    {
        private Dictionary<string, string> EmbeddedAssemblies;
        private Dictionary<string, Assembly> assemblies;

        public EmbeddedAssembly()
        {
            assemblies = new Dictionary<string, Assembly>();
        }

        public void Load()
        {
            EmbeddedAssemblies = new Dictionary<string, string>()
            {
            };
            foreach (var embeddedResource in EmbeddedAssemblies)
            {

                Assembly curAsm = Assembly.GetExecutingAssembly();

                using (Stream stm = curAsm.GetManifestResourceStream(embeddedResource.Key))
                {
                    // Either the file is not existed or it is not mark as embedded resource
                    if (stm == null)
                        continue;

                    // Get byte[] from the file from embedded resource
                    var ba = new byte[(int)stm.Length];
                    stm.Read(ba, 0, (int)stm.Length);
                    try
                    {
                        var asm = Assembly.Load(ba);

                        // Add the assembly/dll into dictionary
                        assemblies.Add(asm.FullName, asm);
                    }
                    catch
                    {
                        // Purposely do nothing
                        // Unmanaged dll or assembly cannot be loaded directly from byte[]
                        // Let the process fall through for next part
                    }
                }
            }
        }

        public Assembly Get(string assemblyFullName)
        {
            if (assemblies == null || assemblies.Count == 0)
                return null;

            if (assemblies.ContainsKey(assemblyFullName))
                return assemblies[assemblyFullName];

            return null;
        }
    }
}
