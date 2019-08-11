using System;
using System.IO;

namespace Philips.Analogy
{
    public partial class XtraFormClientServer : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormClientServer()
        {
            InitializeComponent();
        }

        public void UpdateUI()
        {
            if (rbtnClient.Checked || rBtnserver.Checked)
                lblPath.Text = "IP/Hostname:";
            else if (rBtnNetwork.Checked)
                lblPath.Text = "Network Path:";
            else if (rBtnLocal.Checked)
                lblPath.Text = "Local Path:";
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void sBtnTest_Click(object sender, EventArgs e)
        {
            var valid = TestConnection();
            sBtnTest.Image = valid ? Properties.Resources.OK_32x32 : Properties.Resources.NotOk_32x32;
        }

        private bool TestConnection()
        {
            if (rBtnserver.Checked)
            {
                return CheckPath($@"\\{txtbPath.Text}\d$\PortalPms\Log\Data");
            }
            else if (rbtnClient.Checked)
            {
                return CheckPath($@"\\{txtbPath.Text}\c$\Program Files (x86)\Philips IntelliSpace Portal\Log\data");
            }

            else if (rBtnNetwork.Checked)
            {
                return CheckPath(txtbPath.Text);
            }
            else if (rBtnLocal.Checked)
            {

                return CheckPath(txtbPath.Text);
            }

            return false;
        }

        private bool CheckPath(string path)
        {
            try
            {
                return Directory.Exists(path);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void sBtnAdd_Click(object sender, EventArgs e)
        {
            var valid = TestConnection();
            if (valid)
            {
                if (rBtnserver.Checked)
                {

                    DataSource data = new DataSource(txtbPath.Text, $@"\\{txtbPath.Text}\d$\PortalPms\Log\Data",txtDisplayName.Text, DataSourceType.Server);
                    ClientServerDataSourceManager.Instance.Add(data);
                    return;
                }
                if (rbtnClient.Checked)
                {
                    DataSource data = new DataSource(txtbPath.Text, $@"\\{txtbPath.Text}\c$\Program Files (x86)\Philips IntelliSpace Portal\Log\data", txtDisplayName.Text, DataSourceType.Client);
                    ClientServerDataSourceManager.Instance.Add(data);
                    return;
                }
                if (rBtnNetwork.Checked)
                {
                    DataSource data = new DataSource(txtbPath.Text, txtbPath.Text, txtDisplayName.Text, DataSourceType.NetworkPath);
                    ClientServerDataSourceManager.Instance.Add(data);
                    return;
                }
                if (rBtnLocal.Checked)
                {
                    DataSource data = new DataSource(txtbPath.Text, txtbPath.Text, txtDisplayName.Text, DataSourceType.LocalPath);
                    ClientServerDataSourceManager.Instance.Add(data);
                }

                Close();

            }
        }
    }
}