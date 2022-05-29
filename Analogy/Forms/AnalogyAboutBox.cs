using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Analogy.CommonUtilities.Web;
using DevExpress.XtraEditors;

namespace Analogy.Forms
{
    partial class AnalogyAboutBox : XtraForm
    {
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
                .GetAsync<GithubObjects.GithubReleaseEntry[]>(
                    $"https://api.github.com/repos/Analogy-LogViewer/Analogy.LogViewer/releases", "", DateTime.MinValue)
                .ConfigureAwait(false);
            if (releases == null)
            {
                return;
            }

            var net471 = releases.Select(r => r.Assets.Where(a => a.Name.Contains("471", StringComparison.InvariantCultureIgnoreCase)));
            var net472 = releases.Select(r => r.Assets.Where(a => a.Name.Contains("472", StringComparison.InvariantCultureIgnoreCase)));
            var net48 = releases.Select(r => r.Assets.Where(a => a.Name.Contains("48", StringComparison.InvariantCultureIgnoreCase)));
            var net31 = releases.Select(r => r.Assets.Where(a => a.Name.Contains("3.1", StringComparison.InvariantCultureIgnoreCase)));
            var net5 = releases.Select(r => r.Assets.Where(a => a.Name.Contains("net5.0", StringComparison.InvariantCultureIgnoreCase)));
            var net6 = releases.Select(r => r.Assets.Where(a => a.Name.Contains("net6.0", StringComparison.InvariantCultureIgnoreCase)));

            var net471Downloads = net471.Sum(r => r.Sum(a => a.Downloads));
            var net472Downloads = net472.Sum(r => r.Sum(a => a.Downloads));
            var net48Downloads = net48.Sum(r => r.Sum(a => a.Downloads));
            var net31Downloads = net31.Sum(r => r.Sum(a => a.Downloads));
            var net5Downloads = net5.Sum(r => r.Sum(a => a.Downloads));
            var net6Downloads = net6.Sum(r => r.Sum(a => a.Downloads));


            var net471percentage = (double)net471Downloads / (net471Downloads + net472Downloads + net48Downloads + net31Downloads + net5Downloads + net6Downloads) * 100.0;
            var net472percentage = (double)net472Downloads / (net471Downloads + net472Downloads + net48Downloads + net31Downloads + net5Downloads + net6Downloads) * 100.0;
            var net48percentage = (double)net48Downloads / (net471Downloads + net472Downloads + net48Downloads + net31Downloads + net5Downloads + net6Downloads) * 100.0;
            var net31percentage = (double)net31Downloads / (net471Downloads + net472Downloads + net48Downloads + net31Downloads + net5Downloads + net6Downloads) * 100.0;
            var net5percentage = (double)net5Downloads / (net471Downloads + net472Downloads + net48Downloads + net31Downloads + net5Downloads + net6Downloads) * 100.0;
            var net6percentage = (double)net6Downloads / (net471Downloads + net472Downloads + net48Downloads + net31Downloads + net5Downloads + net6Downloads) * 100.0;

        }
    }
}
