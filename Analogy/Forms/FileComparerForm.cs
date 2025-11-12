using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.WinForms;

namespace Analogy.Forms
{
    public partial class FileComparerForm : DevExpress.XtraEditors.XtraForm
    {
        private IAnalogyOfflineDataProvider offlineAnalogy;

        private FileComparerForm()
        {
            InitializeComponent();
        }

        public FileComparerForm(IAnalogyOfflineDataProviderWinForms offlineAnalogy) : this()
        {
            this.offlineAnalogy = offlineAnalogy;
            logsComparerUC1.SetDataSource(offlineAnalogy);
        }

        private void FileComparerForm_Load(object sender, System.EventArgs e)
        {
            Icon = ServicesProvider.Instance.GetService<IAnalogyUserSettings>().GetIcon();
        }
    }
}