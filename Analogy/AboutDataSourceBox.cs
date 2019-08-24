using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using DevExpress.XtraEditors;
using Philips.Analogy.Interfaces.Interfaces;

namespace Philips.Analogy
{
    partial class AboutDataSourceBox : XtraForm
    {
        private IAnalogyFactories Factory;
        private Assembly FactoryAssemblly;
        public AboutDataSourceBox()
        {
            InitializeComponent();
        }

        public AboutDataSourceBox(IAnalogyFactories factory) : this()
        {
            Factory = factory;
            FactoryAssemblly = AnalogyFactoriesManager.AnalogyFactories.GetAssemblyOfFactory(factory);
        }

        private string AssemblyTitle
        {
            get
            {
                object[] attributes = FactoryAssemblly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(FactoryAssemblly.CodeBase);
            }
        }

        private string AssemblyVersion => FileVersionInfo.GetVersionInfo(FactoryAssemblly.Location).FileVersion;

        private string AssemblyDescription
        {
            get
            {
                object[] attributes = FactoryAssemblly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        private string AssemblyProduct
        {
            get
            {
                object[] attributes = FactoryAssemblly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        private string AssemblyCopyright
        {
            get
            {
                object[] attributes = FactoryAssemblly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        private string AssemblyCompany
        {
            get
            {
                object[] attributes = FactoryAssemblly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        
        private void AboutDataSourceBox_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = string.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = $"{AssemblyDescription}{Environment.NewLine}{Factory.About}";
            rtxtChangeLog.Text = string.Join(Environment.NewLine,
                Factory.ChangeLog.Select(cl => $"{cl.Date.ToShortDateString()}: {cl.ChangeInformation} ({cl.Name})"));
            rtxtContributions.Text = string.Join(Environment.NewLine, Factory.Contributors);
        }
    }
}
