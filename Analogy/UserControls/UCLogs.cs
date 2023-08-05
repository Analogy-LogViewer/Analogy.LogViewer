using Analogy.Common.Interfaces;
using Analogy.DataTypes;
using Analogy.Forms;
using Analogy.Interfaces;

namespace Analogy.UserControls
{
    public partial class UCLogs : CommonControls.UserControls.LogMessagesUC
    {
        public UCLogs()
        {
            InitializeComponent();
            SetHighlightSettings(() =>
            {
                var user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ColorHighlighting,
                    ServicesProvider.Instance.GetService<IAnalogyUserSettings>(), ServicesProvider.Instance.GetService<IFactoriesManager>());
                user.ShowDialog(this);
            });
        }
    }
}
