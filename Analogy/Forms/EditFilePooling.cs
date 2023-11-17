using Analogy.DataTypes;
using Analogy.Interfaces;
using System.IO;

namespace Analogy.Forms
{
    public partial class EditFilePooling : DevExpress.XtraEditors.XtraForm
    {
        public EditFilePooling(string fileName)
        {
            InitializeComponent();
            Icon = ServicesProvider.Instance.GetService<IAnalogyUserSettings>().GetIcon();
            Dir = Path.GetDirectoryName(fileName) ?? string.Empty;
            txtFilename.Text = Path.GetFileName(fileName);
        }

        public string Dir { get; set; }

        public string Filter => Path.Combine(Dir, txtFilename.Text);

        private void BtnOk_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}