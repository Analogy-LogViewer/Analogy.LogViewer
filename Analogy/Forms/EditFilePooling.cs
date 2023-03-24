using System.IO;
using System.Windows.Forms;

namespace Analogy.Forms
{
    public partial class EditFilePooling : Form
    {
        public EditFilePooling(string fileName)
        {
            InitializeComponent();
            Dir = Path.GetDirectoryName(fileName) ?? string.Empty;
            
            txtFilename.Text = Path.GetFileName(fileName);
        }
        

        public string Dir { get; set; }

        public string Filter
        {
            get { return Path.Combine(Dir, txtFilename.Text); }
        }

        private void BtnOk_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}