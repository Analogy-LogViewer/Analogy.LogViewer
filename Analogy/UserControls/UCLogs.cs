using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.DataTypes;
using Analogy.Forms;

namespace Analogy.UserControls
{
    public partial class UCLogs : CommonControls.UserControls.LogMessagesUC
    {
        public UCLogs() : base(ServicesProvider.Instance.GetService<IAnalogyUserSettings>(), ExtensionsManager.Instance, FactoriesManager.Instance, ServicesProvider.Instance.GetService<ILogger>())
        {
            InitializeComponent();
            SetHighlightSettings(() =>
            {
                var user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ColorHighlighting);
                user.ShowDialog(this);
            });
        }
    }
}
