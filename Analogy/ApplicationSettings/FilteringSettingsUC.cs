using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.DataTypes;

namespace Analogy.ApplicationSettings
{
    public partial class FilteringSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

        public FilteringSettingsUC()
        {
            InitializeComponent();
        }

        private void FilteringSettingsUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            SetupEventsHandlers();
        }

        private void SetupEventsHandlers()
        {
            tsFilteringExclude.IsOnChanged += (s, e) => Settings.SaveSearchFilters = tsFilteringExclude.IsOn;
            tsDataTimeAscendDescend.IsOnChanged +=
                (s, e) => Settings.DefaultDescendOrder = tsDataTimeAscendDescend.IsOn;
            tsErrorLevelAsDefault.IsOnChanged += (s, e) => Settings.StartupErrorLogLevel = tsErrorLevelAsDefault.IsOn;
            tsHistory.IsOnChanged += (s, e) => Settings.ShowHistoryOfClearedMessages = tsHistory.IsOn;
            chkEditPaging.CheckedChanged += (s, e) =>
            {
                Settings.PagingEnabled = chkEditPaging.Checked;
                nudPageLength.Enabled = Settings.PagingEnabled;
            };
            nudPageLength.ValueChanged += (s, e) => Settings.PagingSize = (int)nudPageLength.Value;
            checkEditSearchAlsoInSourceAndModule.CheckedChanged += (s, e) =>
              Settings.SearchAlsoInSourceAndModule = checkEditSearchAlsoInSourceAndModule.Checked;

            chklExclusionLogLevel.ItemCheck += (s, e) =>
            {
                var item = chklExclusionLogLevel.Items[e.Index].Value.ToString();
                Settings.FilteringExclusion.SetLogLevelExclusion(item, e.State == CheckState.Checked);
            };

            tsLogLevels.IsOnChanged += (s, e) =>
            {
                Settings.LogLevelSelection = tsLogLevels.IsOn ? LogLevelSelectionType.Multiple : LogLevelSelectionType.Single;
                Utils.SetLogLevel(chkLstLogLevel);
            };

            tsTrackActiveMessage.IsOnChanged += (s, e) => Settings.TrackActiveMessage = tsTrackActiveMessage.IsOn;
            tsSimpleMode.IsOnChanged += (s, e) => Settings.SimpleMode = tsSimpleMode.IsOn;
            tsLogLevels.IsOnChanged += (s, e) => Settings.LogLevelSelection = tsLogLevels.IsOn ? LogLevelSelectionType.Multiple : LogLevelSelectionType.Single;
            

        }

        private void LoadSettings()
        {
            tsSimpleMode.IsOn = Settings.SimpleMode;
            tsTrackActiveMessage.IsOn = Settings.TrackActiveMessage;
            tsHistory.IsOn = Settings.ShowHistoryOfClearedMessages;
            tsFilteringExclude.IsOn = Settings.SaveSearchFilters;
            tsDataTimeAscendDescend.IsOn = Settings.DefaultDescendOrder;
            tsErrorLevelAsDefault.IsOn = Settings.StartupErrorLogLevel;
            chkEditPaging.Checked = Settings.PagingEnabled;
            nudPageLength.Enabled = Settings.PagingEnabled;
            nudPageLength.Value = Settings.PagingSize;
            checkEditSearchAlsoInSourceAndModule.Checked = Settings.SearchAlsoInSourceAndModule;

            if (Settings.PagingEnabled)
            {
                nudPageLength.Value = Settings.PagingSize;
            }
            else
            {
                nudPageLength.Enabled = false;
            }
            tsLogLevels.IsOn = Settings.LogLevelSelection == LogLevelSelectionType.Multiple;
            Utils.SetLogLevel(chkLstLogLevel);
            Utils.FillLogLevels(chklExclusionLogLevel);

        }
    }
}
