using Analogy.Interfaces.DataTypes;
using Analogy.Managers;
using DevExpress.XtraEditors;
using System;
using System.Drawing;

namespace Analogy.UserControls
{
    public partial class ComponentDownloadInformationUC : XtraUserControl
    {
        private FactoryContainer? Factory { get; }
        private IAnalogyDownloadInformation? DownloadInfo { get; }

        public ComponentDownloadInformationUC()
        {
            InitializeComponent();
            btnCheckNow.Click += async (s, e) =>
            {
                if (DownloadInfo != null)
                {
                    await DownloadInfo.CheckVersion();
                    UpdateLatestVersionText();

                }
            };
            btnDownload.Click += async (s, e) =>
            {
                if (DownloadInfo != null && DownloadInfo.IsUpdateAvailable && DownloadInfo.DownloadURL != null)
                {
                    btnDownload.Enabled = false;
                    await UpdateManager.Instance.InitiateUpdate(DownloadInfo.Name, DownloadInfo.DownloadURL);
                    btnDownload.Enabled = true;
                }
            };
        }


        public ComponentDownloadInformationUC(FactoryContainer factory) : this()
        {
            Factory = factory;
            DownloadInfo = Factory.DownloadInformation;
        }

        private void ComponentDownloadInformationUC_Load(object sender, EventArgs e)
        {
            if (Factory != null)
            {
                if (Factory.Factory.LargeImage != null)
                    picture.Image = Factory.Factory.LargeImage;
                lblTitle.Text = Factory.Factory.Title;
            }
            if (DownloadInfo != null)
            {
                lblCurrentVersion.Text = "Current Version: " + DownloadInfo.InstalledVersion.ToString();
                UpdateLatestVersionText();
            }
        }

        private void UpdateLatestVersionText()
        {
            if (DownloadInfo != null && DownloadInfo.LatestVersion != null)
            {
                lblLatestVersion.Text = "released Version: " + DownloadInfo.LatestVersion.ToString();
                if (DownloadInfo.LatestVersion >= DownloadInfo.InstalledVersion || DownloadInfo.InstalledVersion.Equals(new Version(0,0,0)))
                {
                    lblLatestVersion.Appearance.BackColor = Color.GreenYellow;
                    btnDownload.Visible = true;
                }

            }
        }


    }
}
