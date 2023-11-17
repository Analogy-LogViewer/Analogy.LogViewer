using Analogy.Common.DataTypes;
using Analogy.CommonControls.Managers;
using Analogy.DataTypes;
using Analogy.Interfaces.DataTypes;
using Analogy.Managers;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Windows.Forms;

namespace Analogy.UserControls
{
    public partial class ComponentDownloadInformationUC : XtraUserControl
    {
        private UpdateManager UpdateManager { get; }
        private FactoryContainer? Factory { get; }
        private IAnalogyDownloadInformation? DownloadInfo { get; }

        public ComponentDownloadInformationUC(UpdateManager updateManager)
        {
            UpdateManager = updateManager;
            InitializeComponent();
            btnCheckNow.Click += async (s, e) =>
            {
                if (DownloadInfo != null)
                {
                    await DownloadInfo.CheckVersion();
                }
                UpdateLatestVersionText();
            };
            btnDownload.Click += async (s, e) =>
            {
                if (DownloadInfo != null && DownloadInfo.IsUpdateAvailable && DownloadInfo.DownloadURL != null)
                {
                    btnDownload.Enabled = false;
                    await UpdateManager.InitiateUpdate(DownloadInfo.Name, DownloadInfo.DownloadURL, false);
                    btnDownload.Enabled = true;
                }
                else
                {
                    XtraMessageBox.Show("Download file was not found.", "", MessageBoxButtons.OK);
                }
            };
        }

        public ComponentDownloadInformationUC(FactoryContainer factory, UpdateManager updateManager) : this(updateManager)
        {
            Factory = factory;
            DownloadInfo = Factory.DownloadInformation!;
        }

        public ComponentDownloadInformationUC(IAnalogyDownloadInformation downloadInfo, UpdateManager updateManager) : this(updateManager)
        {
            DownloadInfo = downloadInfo;
        }
        private void ComponentDownloadInformationUC_Load(object sender, EventArgs e)
        {
            if (Factory != null)
            {
                if (Factory.Factory.LargeImage != null)
                {
                    picture.Image = Factory.Factory.LargeImage;
                }

                lblTitle.Text = Factory.Factory.Title;
            }
            else
            {
                lblTitle.Text = DownloadInfo?.Name;
                if (DownloadInfo is MissingDownloadInformation mdi)
                {
                    picture.Image = mdi.Image;
                }
            }

            lblCurrentVersion.Text = DownloadInfo?.InstalledVersion > new Version(0, 0, 0)
                    ? DownloadInfo.InstalledVersion.ToString()
                    : "N/A";
            UpdateLatestVersionText();
        }

        private void UpdateLatestVersionText()
        {
            if (DownloadInfo?.LatestVersion != null)
            {
                lblLatestVersion.Text = "released Version: " + DownloadInfo.LatestVersion.ToString();
                if (DownloadInfo.LatestVersion >= DownloadInfo.InstalledVersion || DownloadInfo.InstalledVersion.Equals(new Version(0, 0, 0)))
                {
                    lblLatestVersion.Appearance.BackColor = Color.GreenYellow;
                    btnDownload.Visible = true;
                }
            }
        }
    }
}