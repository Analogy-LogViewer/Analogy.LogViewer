using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Philips.Analogy
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
                //{"Philips.Analogy.DevExpress.DevExpress.Data.v18.1.dll", "DevExpress.Data.v18.1.dll"},
                //{"Philips.Analogy.DevExpress.DevExpress.Utils.v18.1.dll", "DevExpress.Utils.v18.1.dll"},
                //{"Philips.Analogy.DevExpress.DevExpress.XtraEditors.v18.1.dll", "DevExpress.XtraEditors.v18.1.dll"},
                //{"Philips.Analogy.DevExpress.DevExpress.XtraGrid.v18.1.dll", "DevExpress.XtraGrid.v18.1.dll"},
                //{"Philips.Analogy.DevExpress.DevExpress.XtraLayout.v18.1.dll","DevExpress.XtraLayout.v18.1.dll" },
                //{"Philips.Analogy.DevExpress.DevExpress.XtraBars.v18.1.dll","DevExpress.XtraBars.v18.1.dll"},
                //{"Philips.Analogy.DevExpress.DevExpress.Printing.v18.1.Core.dll","DevExpress.Printing.v18.1.Core.dll"},
                //{"Philips.Analogy.DevExpress.DevExpress.Images.v18.1.dll","DevExpress.Images.v18.1.dll"},
                {"Philips.Analogy.Redist.Ionic.Zip.dll", "Ionic.Zip.dll"},
                {"Philips.Analogy.redist.Ionic.Zip.dll", "Ionic.Zip.dll"},
                {"Philips.Analogy.ZedGraph.ZedGraph.dll", "ZedGraph.dll"},
                //{"Philips.Analogy.Microsoft.MSagl.Microsoft.Msagl.dll","Microsoft.Msagl.dll" },
                //{"Philips.Analogy.Microsoft.MSagl.Microsoft.Msagl.Drawing.dll","Microsoft.Msagl.Drawing.dll"},
                //{"Philips.Analogy.Microsoft.MSagl.Microsoft.Msagl.GraphViewerGdi.dll","Microsoft.Msagl.GraphViewerGdi.dll"},
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
                    var ba = new byte[(int) stm.Length];
                    stm.Read(ba, 0, (int) stm.Length);
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
