using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.WinForms;
using DevExpress.XtraEditors;

namespace Analogy.Forms
{
    public partial class FormCombineFiles : XtraForm
    {
        private IAnalogyOfflineDataProvider offlineAnalogy;

        private FormCombineFiles()
        {
            InitializeComponent();
        }

        public FormCombineFiles(IAnalogyOfflineDataProviderWinForms offlineAnalogy) : this()
        {
            this.offlineAnalogy = offlineAnalogy;
            combineFilesUC1.SetDataSource(offlineAnalogy);
        }

        private void FormCombineFiles_Load(object sender, System.EventArgs e)
        {
            Icon = ServicesProvider.Instance.GetService<IAnalogyUserSettings>().GetIcon();
        }
    }
}