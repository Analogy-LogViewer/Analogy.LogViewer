using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.DataSources;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.Properties;

namespace Analogy.DataProviders
{
    public class NLogBuiltInFactory : IAnalogyFactory
    {
        public static Guid AnalogyNLogGuid { get; } = new Guid("33CBFA00-DA3E-4F9F-B5A1-BE978FD09D57");
        public Guid FactoryID { get; } = AnalogyNLogGuid;
        public string Title { get; } = "Analogy NLogs Parser";
        public IAnalogyDataProvidersFactory DataProviders { get; }
        public IAnalogyCustomActionsFactory Actions { get; }
        public IEnumerable<IAnalogyChangeLog> ChangeLog => CommonChangeLog.GetChangeLog();
        public IEnumerable<string> Contributors { get; } = new List<string> { "Lior Banai" };
        public string About { get; } = "Analogy NLogs Parser";
        public NLogBuiltInFactory()
        {
            DataProviders = new AnalogyNLogDataProviderFactory();
            Actions = new AnalogyNLogCustomActionFactory();

        }

   
    }

    public class AnalogyNLogDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public string Title { get; } = "Analogy NLogs Data Provider";
        public IEnumerable<IAnalogyDataProvider> Items { get; }

        public AnalogyNLogDataProviderFactory()
        {
            var builtInItems = new List<IAnalogyDataProvider>();
            var adpnlog = new NLogDataProvider();
            builtInItems.Add(adpnlog);
            adpnlog.InitDataProvider();
            Items = builtInItems;
        }
    }

    public class AnalogyNLogCustomActionFactory : IAnalogyCustomActionsFactory
    {
        public string Title { get; } = "Analogy NLog Built-In tools";
        public IEnumerable<IAnalogyCustomAction> Items { get; }

        public AnalogyNLogCustomActionFactory()
        {
            Items = new List<IAnalogyCustomAction>() { new AnalogyNLogCustomAction() };
        }
    }

    public class AnalogyNLogCustomAction : IAnalogyCustomAction
    {
        public Action Action => () =>
        {
            UserSettingsDataProvidersForm user = new UserSettingsDataProvidersForm("xtraTabPageNLog");
            user.ShowDialog(Application.OpenForms[0]);
        };
        public Guid ID { get; } = new Guid("8D24EC70-60C0-4823-BE9C-F4A59303FFB3");
        public Image Image { get; } = Resources.nlog;
        public string Title { get; } = "NLog Settings";

    }

}

