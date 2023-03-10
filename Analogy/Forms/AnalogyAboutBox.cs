using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Analogy.CommonControls.DataTypes;
using Analogy.CommonUtilities.Github;
using Analogy.CommonUtilities.Web;
using Analogy.Managers;
using Analogy.UserControls;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;

namespace Analogy.Forms
{
    partial class AnalogyAboutBox : XtraForm
    {
        private int SelectedTab { get; set; }
        public AnalogyAboutBox()
        {
            InitializeComponent();
            this.Text = string.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = string.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.meAbout.Text = AssemblyDescription +
                                $"{Environment.NewLine}Created by Lior Banai (2018){Environment.NewLine}Contact info:{Environment.NewLine}mail: Liorbanai@gmail.com";
        }

        public AnalogyAboutBox(int selectedTab):this()
        {
            SelectedTab = selectedTab;
        }
        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }

                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion =>
            FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }

                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }

                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }

                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }

                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void sbtnFetchReleases_Click(object sender, EventArgs e)
        {
            var (_, releases) = await Utils
                .GetAsync<GithubReleaseEntry[]>(AnalogyNonPersistSettings.Instance.AnalogyReleasesUrl, "", DateTime.MinValue)
                .ConfigureAwait(true);
            if (releases == null)
            {
                return;
            }

            DownloadStatisticsUC uc = new DownloadStatisticsUC(releases);
           panelChart.Controls.Add(uc);
           uc.Dock = DockStyle.Fill;
        }

        private void AnalogyAboutBox_Load(object sender, EventArgs e)
        {
            if (SelectedTab > 0)
            {
                xtraTabControl1.SelectedTabPageIndex = SelectedTab;
                sbtnFetchReleases_Click(sender,e);
            }
        }
    }
}
