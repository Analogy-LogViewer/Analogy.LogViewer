using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.Factories;
using DevExpress.XtraEditors;
using System;
using System.Drawing;
using Analogy.Managers;

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
                    var hasUpdate = await DownloadInfo.CheckVersion();
                    if (hasUpdate)
                    {

                    }
                }
            };
            btnDownload.Click += (s, e) =>
            {
                if (DownloadInfo != null && DownloadInfo.IsUpdateAvailable)
                {
                    UpdateLatestVersionText();
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
            if (Factory != null && DownloadInfo != null)
            {
                if (Factory.Factory.LargeImage != null)
                    picture.Image = Factory.Factory.LargeImage;
                lblTitle.Text = Factory.Factory.Title;
                lblCurrentVersion.Text = DownloadInfo.InstalledVersion.ToString();
                UpdateLatestVersionText();

            }
        }

        private void UpdateLatestVersionText()
        {
            if (DownloadInfo != null && DownloadInfo.LatestVersion != null)
            {
                lblLatestVersion.Text = DownloadInfo.LatestVersion.ToString();
                if (DownloadInfo.IsUpdateAvailable)
                {
                    lblLatestVersion.Appearance.BackColor = Color.GreenYellow;
                    btnDownload.Visible = true;
                }

            }
        }
    }
}
