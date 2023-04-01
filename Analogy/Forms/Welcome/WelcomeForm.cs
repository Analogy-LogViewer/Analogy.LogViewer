using DevExpress.XtraBars;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Analogy.ApplicationSettings;
using Analogy.Common.Interfaces;
using Analogy.DataTypes;
using Analogy.Forms.Welcome;

namespace Analogy.Forms
{
    public partial class WelcomeForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private IUserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

        public WelcomeForm()
        {
            InitializeComponent();
            EnableAcrylicAccent = false;
        }

        private void aceGeneral_Click(object sender, EventArgs e)
        {
            AddOrBringToFrontUserControl(ApplicationWelcomeSelectionType.General);
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
                    return new WelcomeGeneralUC();
                default:
                {
                    AnalogyLogger.Instance.LogError($"Selection with {selectionType} was not found");
                    throw new Exception($"Selection with {selectionType} was not found");
                }
            }
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            ShowIcon = true;
            Icon = UserSettingsManager.UserSettings.GetIcon();
            AddOrBringToFrontUserControl(ApplicationWelcomeSelectionType.General);
        }
    }
}
