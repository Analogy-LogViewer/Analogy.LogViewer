using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.CommonControls.DataTypes;
using Analogy.DataTypes;
using Analogy.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.ApplicationSettings
{
    public partial class FilteringSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private IAnalogyUserSettings Settings { get; } 
        public FilteringSettingsUC(IAnalogyUserSettings settings)
        {
            this.Settings = settings;
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
            tsCheckAdditionalInformation.IsOnChanged += (s, e) =>
                Settings.CheckAdditionalInformation = tsCheckAdditionalInformation.IsOn;
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
            tsLogLevels.IsOnChanged += (s, e) => Settings.LogLevelSelection = tsLogLevels.IsOn ? LogLevelSelectionType.Multiple : LogLevelSelectionType.Single;
            sePoolingDelay.ValueChanged += (s, e) =>
            {
                Settings.FilePoolingDelayInterval = decimal.ToInt32((decimal)sePoolingDelay.EditValue);
            };
            ceEnablePoolingDelay.CheckStateChanged += (s, e) =>
            {
                Settings.EnableFilePoolingDelay = ceEnablePoolingDelay.Checked;
            };

            tsShowProgressCounter.IsOnChanged += (s, e) =>
            {
                Settings.ShowProcessedCounter = tsShowProgressCounter.IsOn;
            };


        }

        private void LoadSettings()
        {
            tsCheckAdditionalInformation.IsOn = Settings.CheckAdditionalInformation;
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

            sePoolingDelay.Value = Settings.FilePoolingDelayInterval;
            ceEnablePoolingDelay.Checked = Settings.EnableFilePoolingDelay;
            tsShowProgressCounter.IsOn = Settings.ShowProcessedCounter;
        }
    }
}