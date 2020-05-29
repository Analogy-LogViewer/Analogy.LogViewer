using System;
using System.Globalization;

namespace Analogy.Forms
{
    public partial class UnixTimeConverter : DevExpress.XtraEditors.XtraForm
    {
        public UnixTimeConverter()
        {
            InitializeComponent();
        }

        private void UnixTimeConverter_Load(object sender, EventArgs e)
        {
            Icon = UserSettingsManager.UserSettings.GetIcon();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            textEdit1.Text = new DateTimeOffset(dateEdit1.DateTime).ToUnixTimeMilliseconds().ToString();
        }

        private void sbtnToUnix_Click(object sender, EventArgs e)
        {
            textEdit1.Text = new DateTimeOffset(dateEdit1.DateTime).ToUnixTimeMilliseconds().ToString();

        }

        private void sbtnFromUnix_Click(object sender, EventArgs e)
        {
            if (long.TryParse(textEdit1.Text,NumberStyles.AllowThousands| NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out var val))
            {
                dateEdit1.DateTime = DateTimeOffset.FromUnixTimeMilliseconds(val).DateTime;
            }

        }
    }
}