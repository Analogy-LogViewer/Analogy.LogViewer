using System.Windows.Forms;
using Analogy.DataTypes;
using Analogy.Forms.Welcome;
using Analogy.Interfaces;
using Microsoft.Extensions.Logging;

namespace Analogy.Forms
{
    public partial class WelcomeForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private IAnalogyUserSettings Settings { get; }
        private FactoriesManager FactoriesManager { get; }

        public WelcomeForm(IAnalogyUserSettings settings,FactoriesManager factoriesManager)
        {
            Settings = settings;
            FactoriesManager = factoriesManager;
            InitializeComponent();
            EnableAcrylicAccent = false;
        }

  
        private void AddOrBringToFrontUserControl(ApplicationWelcomeSelectionType type)
        {
            string name = type.ToString();
            if (!fluentDesignFormContainer1.Controls.ContainsKey(name))
            {
                var uc = GetUserControlByType(type);
                uc.Name = name;
                fluentDesignFormContainer1.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                uc.BringToFront();
            }

            foreach (UserControl others in fluentDesignFormContainer1.Controls)
            {
                if (others.Name == name)
                {
                    continue;
                }

                others.SendToBack();
            }

            fluentDesignFormContainer1.Controls[name].BringToFront();
        }

        private UserControl GetUserControlByType(ApplicationWelcomeSelectionType selectionType)
        {
            switch (selectionType)
            {
                case ApplicationWelcomeSelectionType.General:
                    return new WelcomeGeneralUC(Settings, FactoriesManager);
                case ApplicationWelcomeSelectionType.Theme:
                    return new WelcomeThemeSelectionUC(Settings, FactoriesManager);
                case ApplicationWelcomeSelectionType.DataProvides:
                    return new WelcomeDataProvidersUC(Settings, FactoriesManager);
                case ApplicationWelcomeSelectionType.Extensions:
                    return new WelcomeExtensionsUC(Settings, FactoriesManager);
                case ApplicationWelcomeSelectionType.GlobalTools:
                    return new WelcomeGlobalToolsUC();
                case ApplicationWelcomeSelectionType.WhatIsNew:
                    return new WelcomeWhatIsNewUC();
                case ApplicationWelcomeSelectionType.ShareAndSupport:
                    return new WelcomeShareAndSupportUC();
                case ApplicationWelcomeSelectionType.Feedback:
                    return new WelcomeFeedbackUC();
                default:
                {
                    ServicesProvider.Instance.GetService<ILogger>().LogError($"Selection with {selectionType} was not found");
                    throw new Exception($"Selection with {selectionType} was not found");
                }
            }
        }

        private async void WelcomeForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            ShowIcon = true;
            Icon = ServicesProvider.Instance.GetService<IAnalogyUserSettings>().GetIcon();
            await FactoriesManager.InitializeBuiltInFactories();
            await FactoriesManager.AddExternalDataSources();
            AddOrBringToFrontUserControl(ApplicationWelcomeSelectionType.General);
        }
      private void aceGeneral_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationWelcomeSelectionType.General);
        }

        private void aceTheme_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationWelcomeSelectionType.Theme);
        }

        private void aceDataProviders_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationWelcomeSelectionType.DataProvides);
        }

        private void aceExtensions_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationWelcomeSelectionType.Extensions);
        }

        private void aceGlobalTools_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationWelcomeSelectionType.GlobalTools);
        }

        private void aceWhatIsNew_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationWelcomeSelectionType.WhatIsNew);
        }

        private void aceShareAndSupport_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationWelcomeSelectionType.ShareAndSupport);
        }

        private void aceFeedback_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationWelcomeSelectionType.Feedback);

        }
    }
}
