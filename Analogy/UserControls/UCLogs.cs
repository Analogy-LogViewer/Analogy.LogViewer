using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.DataTypes;
using Analogy.Forms;
using Analogy.Interfaces;
using Microsoft.Extensions.Logging;

namespace Analogy.UserControls
{
    public partial class UCLogs : CommonControls.UserControls.LogMessagesUC
    {
        public UCLogs() : base(ServicesProvider.Instance.GetService<IAnalogyUserSettings>(),
            ServicesProvider.Instance.GetService<ExtensionsManager>(),
            ServicesProvider.Instance.GetService<FactoriesManager>(), 
            ServicesProvider.Instance.GetService<ILogger>())
        {
            InitializeComponent();
            SetHighlightSettings(() =>
            {
                var user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ColorHighlighting,
                    ServicesProvider.Instance.GetService<IAnalogyUserSettings>(), ServicesProvider.Instance.GetService<FactoriesManager>());
                user.ShowDialog(this);
            });
        }
    }
}
