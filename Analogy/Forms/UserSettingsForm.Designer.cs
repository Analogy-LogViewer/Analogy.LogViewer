namespace Analogy.Forms
{
    partial class UserSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSettingsForm));
            this.tabControlMain = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageApplication = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageFilter = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPagePreDefined = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabControlQueries = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageColorHighlight = new DevExpress.XtraTab.XtraTabPage();
            this.sbtnDeleteHighlight = new DevExpress.XtraEditors.SimpleButton();
            this.lboxHighlightItems = new DevExpress.XtraEditors.ListBoxControl();
            this.gcHighlight = new DevExpress.XtraEditors.GroupControl();
            this.sbtnAddHighlight = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.cpeHighlightPreDefined = new DevExpress.XtraEditors.ColorPickEdit();
            this.teHighlightEquals = new DevExpress.XtraEditors.TextEdit();
            this.teHighlightContains = new DevExpress.XtraEditors.TextEdit();
            this.rbtnHighlightEquals = new System.Windows.Forms.RadioButton();
            this.rbtnHighlightContains = new System.Windows.Forms.RadioButton();
            this.xtraTabPageFilters = new DevExpress.XtraTab.XtraTabPage();
            this.sbtnDeleteFilter = new DevExpress.XtraEditors.SimpleButton();
            this.lboxFilters = new DevExpress.XtraEditors.ListBoxControl();
            this.sbtnAddFilter = new DevExpress.XtraEditors.SimpleButton();
            this.lblExplaination = new System.Windows.Forms.Label();
            this.lblModules = new System.Windows.Forms.Label();
            this.lblSources = new System.Windows.Forms.Label();
            this.lblExcludeMessageText = new System.Windows.Forms.Label();
            this.lblIncludeText = new System.Windows.Forms.Label();
            this.txtbSourcesFilter = new DevExpress.XtraEditors.TextEdit();
            this.txtbModulesFilter = new DevExpress.XtraEditors.TextEdit();
            this.txtbExcludeFilter = new DevExpress.XtraEditors.TextEdit();
            this.txtbIncludeTextFilter = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabPageAlerts = new DevExpress.XtraTab.XtraTabPage();
            this.sbtnDeleteAlerts = new DevExpress.XtraEditors.SimpleButton();
            this.lboxAlerts = new DevExpress.XtraEditors.ListBoxControl();
            this.sbtnAddAlerts = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbSourcesAlert = new DevExpress.XtraEditors.TextEdit();
            this.txtbModulesAlert = new DevExpress.XtraEditors.TextEdit();
            this.txtbExcludeAlert = new DevExpress.XtraEditors.TextEdit();
            this.txtbIncludeTextAlert = new DevExpress.XtraEditors.TextEdit();
            this.tpColors = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.sbtnDateTimeFormat = new DevExpress.XtraEditors.SimpleButton();
            this.teDateTimeFormat = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.panelControlMessages = new DevExpress.XtraEditors.PanelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.logGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnDataSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTimeDiff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnObject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProcessID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnThread = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.sbtnHeaderSet = new DevExpress.XtraEditors.SimpleButton();
            this.teHeader = new DevExpress.XtraEditors.TextEdit();
            this.gcColors = new DevExpress.XtraEditors.GroupControl();
            this.sBtnExportColors = new DevExpress.XtraEditors.SimpleButton();
            this.cpeNewMessagesColorText = new DevExpress.XtraEditors.ColorPickEdit();
            this.sBtnImportColors = new DevExpress.XtraEditors.SimpleButton();
            this.cpeHighlightColorText = new DevExpress.XtraEditors.ColorPickEdit();
            this.tsEnableColors = new DevExpress.XtraEditors.ToggleSwitch();
            this.ceOverrideLogLevelColor = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lblLogLevelRowTextColor = new DevExpress.XtraEditors.LabelControl();
            this.cpeLogLevelAnalogyInformationText = new DevExpress.XtraEditors.ColorPickEdit();
            this.cpeLogLevelCriticalText = new DevExpress.XtraEditors.ColorPickEdit();
            this.cpeLogLevelErrorText = new DevExpress.XtraEditors.ColorPickEdit();
            this.cpeLogLevelWarningText = new DevExpress.XtraEditors.ColorPickEdit();
            this.cpeLogLevelEventText = new DevExpress.XtraEditors.ColorPickEdit();
            this.cpeLogLevelDebugText = new DevExpress.XtraEditors.ColorPickEdit();
            this.cpeLogLevelVerboseText = new DevExpress.XtraEditors.ColorPickEdit();
            this.cpeLogLevelTraceText = new DevExpress.XtraEditors.ColorPickEdit();
            this.cpeLogLevelDisabledText = new DevExpress.XtraEditors.ColorPickEdit();
            this.cpeLogLevelUnknownText = new DevExpress.XtraEditors.ColorPickEdit();
            this.lblLogLevelBackground = new DevExpress.XtraEditors.LabelControl();
            this.lblLogLevelAnalogyInformation = new DevExpress.XtraEditors.LabelControl();
            this.cpeLogLevelAnalogyInformation = new DevExpress.XtraEditors.ColorPickEdit();
            this.lblLogLevelCritical = new DevExpress.XtraEditors.LabelControl();
            this.cpeLogLevelCritical = new DevExpress.XtraEditors.ColorPickEdit();
            this.lblLogLevelError = new DevExpress.XtraEditors.LabelControl();
            this.cpeLogLevelError = new DevExpress.XtraEditors.ColorPickEdit();
            this.lblLogLevelWarning = new DevExpress.XtraEditors.LabelControl();
            this.cpeLogLevelWarning = new DevExpress.XtraEditors.ColorPickEdit();
            this.lblLogLevelEvent = new DevExpress.XtraEditors.LabelControl();
            this.cpeLogLevelEvent = new DevExpress.XtraEditors.ColorPickEdit();
            this.lblLogLevelDebug = new DevExpress.XtraEditors.LabelControl();
            this.cpeLogLevelDebug = new DevExpress.XtraEditors.ColorPickEdit();
            this.lblLogLevelVerbose = new DevExpress.XtraEditors.LabelControl();
            this.cpeLogLevelVerbose = new DevExpress.XtraEditors.ColorPickEdit();
            this.lblLogLevelTrace = new DevExpress.XtraEditors.LabelControl();
            this.cpeLogLevelTrace = new DevExpress.XtraEditors.ColorPickEdit();
            this.lblLogLevelDisabled = new DevExpress.XtraEditors.LabelControl();
            this.cpeLogLevelDisabled = new DevExpress.XtraEditors.ColorPickEdit();
            this.lblLogLevelUnknown = new DevExpress.XtraEditors.LabelControl();
            this.cpeLogLevelUnknown = new DevExpress.XtraEditors.ColorPickEdit();
            this.ceNewMessagesColor = new DevExpress.XtraEditors.CheckEdit();
            this.lblHighlightColor = new DevExpress.XtraEditors.LabelControl();
            this.cpeNewMessagesColor = new DevExpress.XtraEditors.ColorPickEdit();
            this.cpeHighlightColor = new DevExpress.XtraEditors.ColorPickEdit();
            this.xtShortcuts = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xTabMRU = new DevExpress.XtraTab.XtraTabPage();
            this.lblRecentFolders = new DevExpress.XtraEditors.LabelControl();
            this.nudRecentFolders = new System.Windows.Forms.NumericUpDown();
            this.lblRecent = new DevExpress.XtraEditors.LabelControl();
            this.nudRecentFiles = new System.Windows.Forms.NumericUpDown();
            this.xtraTabPageResources = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.nudIdleTime = new System.Windows.Forms.NumericUpDown();
            this.toggleSwitchIdleMode = new DevExpress.XtraEditors.ToggleSwitch();
            this.xtraTabPageDataProviders = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabControlDataProviderSettings = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageDataProvidersOrder = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControlDataProviders = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControlDataProvidersButtons = new DevExpress.XtraEditors.SplitContainerControl();
            this.sBtnMoveUp = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnMoveDown = new DevExpress.XtraEditors.SimpleButton();
            this.chkLstDataProviderStatus = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.tsRememberLastOpenedDataProvider = new DevExpress.XtraEditors.ToggleSwitch();
            this.xtraTabPageDataProvidersRealTime = new DevExpress.XtraTab.XtraTabPage();
            this.chkLstItemRealTimeDataSources = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPageDataProviderAssociation = new DevExpress.XtraTab.XtraTabPage();
            this.cbDataProviderAssociation = new DevExpress.XtraEditors.LookUpEdit();
            this.txtbDataProviderAssociation = new DevExpress.XtraEditors.TextEdit();
            this.btnSetFileAssociation = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPageDataProvidersCustom = new DevExpress.XtraTab.XtraTabPage();
            this.btnDataProviderCustomSettings = new DevExpress.XtraEditors.SimpleButton();
            this.xtpExternalLocations = new DevExpress.XtraTab.XtraTabPage();
            this.lblAssemblies = new DevExpress.XtraEditors.LabelControl();
            this.sbtnDeleteFolderProbing = new DevExpress.XtraEditors.SimpleButton();
            this.lblFoldersProbing = new DevExpress.XtraEditors.LabelControl();
            this.teFoldersProbing = new DevExpress.XtraEditors.TextEdit();
            this.sbtnFolderProbingBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.listBoxFoldersProbing = new DevExpress.XtraEditors.ListBoxControl();
            this.sbtnFolderProbingAdd = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageExtension = new DevExpress.XtraTab.XtraTabPage();
            this.chkLstItemExtensions = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPageUpdates = new DevExpress.XtraTab.XtraTabPage();
            this.gcIntervals = new DevExpress.XtraEditors.GroupControl();
            this.lblDisableUpdates = new DevExpress.XtraEditors.LabelControl();
            this.cbUpdates = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblUpdates = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPageDebugging = new DevExpress.XtraTab.XtraTabPage();
            this.tsEnableFirstChanceException = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.xtraTabPagePreDefined.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlQueries)).BeginInit();
            this.xtraTabControlQueries.SuspendLayout();
            this.xtraTabPageColorHighlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lboxHighlightItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHighlight)).BeginInit();
            this.gcHighlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpeHighlightPreDefined.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHighlightEquals.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHighlightContains.Properties)).BeginInit();
            this.xtraTabPageFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lboxFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbSourcesFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbModulesFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbExcludeFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbIncludeTextFilter.Properties)).BeginInit();
            this.xtraTabPageAlerts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lboxAlerts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbSourcesAlert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbModulesAlert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbExcludeAlert.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbIncludeTextAlert.Properties)).BeginInit();
            this.tpColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teDateTimeFormat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMessages)).BeginInit();
            this.panelControlMessages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHeader.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcColors)).BeginInit();
            this.gcColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpeNewMessagesColorText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeHighlightColorText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsEnableColors.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceOverrideLogLevelColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelAnalogyInformationText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelCriticalText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelErrorText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelWarningText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelEventText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelDebugText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelVerboseText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelTraceText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelDisabledText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelUnknownText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelAnalogyInformation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelCritical.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelError.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelWarning.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelEvent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelDebug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelVerbose.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelTrace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelDisabled.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelUnknown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceNewMessagesColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeNewMessagesColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeHighlightColor.Properties)).BeginInit();
            this.xtShortcuts.SuspendLayout();
            this.xTabMRU.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecentFolders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecentFiles)).BeginInit();
            this.xtraTabPageResources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdleTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitchIdleMode.Properties)).BeginInit();
            this.xtraTabPageDataProviders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDataProviderSettings)).BeginInit();
            this.xtraTabControlDataProviderSettings.SuspendLayout();
            this.xtraTabPageDataProvidersOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlDataProviders)).BeginInit();
            this.splitContainerControlDataProviders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlDataProvidersButtons)).BeginInit();
            this.splitContainerControlDataProvidersButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstDataProviderStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsRememberLastOpenedDataProvider.Properties)).BeginInit();
            this.xtraTabPageDataProvidersRealTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstItemRealTimeDataSources)).BeginInit();
            this.xtraTabPageDataProviderAssociation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDataProviderAssociation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDataProviderAssociation.Properties)).BeginInit();
            this.xtraTabPageDataProvidersCustom.SuspendLayout();
            this.xtpExternalLocations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teFoldersProbing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxFoldersProbing)).BeginInit();
            this.xtraTabPageExtension.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstItemExtensions)).BeginInit();
            this.xtraTabPageUpdates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcIntervals)).BeginInit();
            this.gcIntervals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbUpdates.Properties)).BeginInit();
            this.xtraTabPageDebugging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsEnableFirstChanceException.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.tabControlMain.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlMain.MinimumSize = new System.Drawing.Size(814, 382);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedTabPage = this.xtraTabPageApplication;
            this.tabControlMain.Size = new System.Drawing.Size(991, 932);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageApplication,
            this.xtraTabPageFilter,
            this.xtraTabPagePreDefined,
            this.tpColors,
            this.xtShortcuts,
            this.xTabMRU,
            this.xtraTabPageResources,
            this.xtraTabPageDataProviders,
            this.xtraTabPageExtension,
            this.xtraTabPageUpdates,
            this.xtraTabPageDebugging});
            // 
            // xtraTabPageApplication
            // 
            this.xtraTabPageApplication.AutoScroll = true;
            this.xtraTabPageApplication.ImageOptions.Image = global::Analogy.Properties.Resources.Analogy_icon1;
            this.xtraTabPageApplication.Name = "xtraTabPageApplication";
            this.xtraTabPageApplication.Size = new System.Drawing.Size(817, 925);
            this.xtraTabPageApplication.Text = "Application Settings";
            // 
            // xtraTabPageFilter
            // 
            this.xtraTabPageFilter.AutoScroll = true;
            this.xtraTabPageFilter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPageFilter.ImageOptions.Image")));
            this.xtraTabPageFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPageFilter.Name = "xtraTabPageFilter";
            this.xtraTabPageFilter.Size = new System.Drawing.Size(817, 925);
            this.xtraTabPageFilter.Text = "Filtering";
            // 
            // xtraTabPagePreDefined
            // 
            this.xtraTabPagePreDefined.AutoScroll = true;
            this.xtraTabPagePreDefined.Controls.Add(this.xtraTabControlQueries);
            this.xtraTabPagePreDefined.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPagePreDefined.ImageOptions.Image")));
            this.xtraTabPagePreDefined.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPagePreDefined.Name = "xtraTabPagePreDefined";
            this.xtraTabPagePreDefined.Size = new System.Drawing.Size(817, 924);
            this.xtraTabPagePreDefined.Text = "Pre-Defined Queries";
            // 
            // xtraTabControlQueries
            // 
            this.xtraTabControlQueries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlQueries.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlQueries.Name = "xtraTabControlQueries";
            this.xtraTabControlQueries.SelectedTabPage = this.xtraTabPageColorHighlight;
            this.xtraTabControlQueries.Size = new System.Drawing.Size(817, 924);
            this.xtraTabControlQueries.TabIndex = 0;
            this.xtraTabControlQueries.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageColorHighlight,
            this.xtraTabPageFilters,
            this.xtraTabPageAlerts});
            // 
            // xtraTabPageColorHighlight
            // 
            this.xtraTabPageColorHighlight.Controls.Add(this.sbtnDeleteHighlight);
            this.xtraTabPageColorHighlight.Controls.Add(this.lboxHighlightItems);
            this.xtraTabPageColorHighlight.Controls.Add(this.gcHighlight);
            this.xtraTabPageColorHighlight.Name = "xtraTabPageColorHighlight";
            this.xtraTabPageColorHighlight.Size = new System.Drawing.Size(810, 890);
            this.xtraTabPageColorHighlight.Text = "Color Highlighting";
            // 
            // sbtnDeleteHighlight
            // 
            this.sbtnDeleteHighlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnDeleteHighlight.Location = new System.Drawing.Point(697, 860);
            this.sbtnDeleteHighlight.Name = "sbtnDeleteHighlight";
            this.sbtnDeleteHighlight.Size = new System.Drawing.Size(110, 27);
            this.sbtnDeleteHighlight.TabIndex = 7;
            this.sbtnDeleteHighlight.Text = "Delete";
            this.sbtnDeleteHighlight.Click += new System.EventHandler(this.sbtnDeleteHighlight_Click);
            // 
            // lboxHighlightItems
            // 
            this.lboxHighlightItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lboxHighlightItems.Location = new System.Drawing.Point(5, 206);
            this.lboxHighlightItems.Name = "lboxHighlightItems";
            this.lboxHighlightItems.Size = new System.Drawing.Size(802, 648);
            this.lboxHighlightItems.TabIndex = 1;
            // 
            // gcHighlight
            // 
            this.gcHighlight.Controls.Add(this.sbtnAddHighlight);
            this.gcHighlight.Controls.Add(this.labelControl9);
            this.gcHighlight.Controls.Add(this.cpeHighlightPreDefined);
            this.gcHighlight.Controls.Add(this.teHighlightEquals);
            this.gcHighlight.Controls.Add(this.teHighlightContains);
            this.gcHighlight.Controls.Add(this.rbtnHighlightEquals);
            this.gcHighlight.Controls.Add(this.rbtnHighlightContains);
            this.gcHighlight.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcHighlight.Location = new System.Drawing.Point(0, 0);
            this.gcHighlight.Name = "gcHighlight";
            this.gcHighlight.Size = new System.Drawing.Size(810, 200);
            this.gcHighlight.TabIndex = 0;
            this.gcHighlight.Text = "Highlight defintions";
            // 
            // sbtnAddHighlight
            // 
            this.sbtnAddHighlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnAddHighlight.Location = new System.Drawing.Point(681, 147);
            this.sbtnAddHighlight.Name = "sbtnAddHighlight";
            this.sbtnAddHighlight.Size = new System.Drawing.Size(110, 27);
            this.sbtnAddHighlight.TabIndex = 6;
            this.sbtnAddHighlight.Text = "Add";
            this.sbtnAddHighlight.Click += new System.EventHandler(this.sbtnAddHighlight_Click);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(5, 109);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(74, 16);
            this.labelControl9.TabIndex = 5;
            this.labelControl9.Text = "Select Color:";
            // 
            // cpeHighlightPreDefined
            // 
            this.cpeHighlightPreDefined.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeHighlightPreDefined.EditValue = System.Drawing.Color.Empty;
            this.cpeHighlightPreDefined.Location = new System.Drawing.Point(194, 106);
            this.cpeHighlightPreDefined.Name = "cpeHighlightPreDefined";
            this.cpeHighlightPreDefined.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeHighlightPreDefined.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeHighlightPreDefined.Size = new System.Drawing.Size(597, 22);
            this.cpeHighlightPreDefined.TabIndex = 4;
            // 
            // teHighlightEquals
            // 
            this.teHighlightEquals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teHighlightEquals.Enabled = false;
            this.teHighlightEquals.Location = new System.Drawing.Point(194, 76);
            this.teHighlightEquals.Name = "teHighlightEquals";
            this.teHighlightEquals.Size = new System.Drawing.Size(597, 22);
            this.teHighlightEquals.TabIndex = 3;
            // 
            // teHighlightContains
            // 
            this.teHighlightContains.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teHighlightContains.Location = new System.Drawing.Point(194, 43);
            this.teHighlightContains.Name = "teHighlightContains";
            this.teHighlightContains.Size = new System.Drawing.Size(597, 22);
            this.teHighlightContains.TabIndex = 2;
            // 
            // rbtnHighlightEquals
            // 
            this.rbtnHighlightEquals.AutoSize = true;
            this.rbtnHighlightEquals.Location = new System.Drawing.Point(5, 77);
            this.rbtnHighlightEquals.Name = "rbtnHighlightEquals";
            this.rbtnHighlightEquals.Size = new System.Drawing.Size(160, 21);
            this.rbtnHighlightEquals.TabIndex = 1;
            this.rbtnHighlightEquals.Text = "Message Text Equals:";
            this.rbtnHighlightEquals.UseVisualStyleBackColor = true;
            this.rbtnHighlightEquals.CheckedChanged += new System.EventHandler(this.rbtnHighlightEquals_CheckedChanged);
            // 
            // rbtnHighlightContains
            // 
            this.rbtnHighlightContains.AutoSize = true;
            this.rbtnHighlightContains.Checked = true;
            this.rbtnHighlightContains.Location = new System.Drawing.Point(5, 44);
            this.rbtnHighlightContains.Name = "rbtnHighlightContains";
            this.rbtnHighlightContains.Size = new System.Drawing.Size(174, 21);
            this.rbtnHighlightContains.TabIndex = 0;
            this.rbtnHighlightContains.TabStop = true;
            this.rbtnHighlightContains.Text = "Message Text Contains:";
            this.rbtnHighlightContains.UseVisualStyleBackColor = true;
            this.rbtnHighlightContains.CheckedChanged += new System.EventHandler(this.rbtnHighlightContains_CheckedChanged);
            // 
            // xtraTabPageFilters
            // 
            this.xtraTabPageFilters.Controls.Add(this.sbtnDeleteFilter);
            this.xtraTabPageFilters.Controls.Add(this.lboxFilters);
            this.xtraTabPageFilters.Controls.Add(this.sbtnAddFilter);
            this.xtraTabPageFilters.Controls.Add(this.lblExplaination);
            this.xtraTabPageFilters.Controls.Add(this.lblModules);
            this.xtraTabPageFilters.Controls.Add(this.lblSources);
            this.xtraTabPageFilters.Controls.Add(this.lblExcludeMessageText);
            this.xtraTabPageFilters.Controls.Add(this.lblIncludeText);
            this.xtraTabPageFilters.Controls.Add(this.txtbSourcesFilter);
            this.xtraTabPageFilters.Controls.Add(this.txtbModulesFilter);
            this.xtraTabPageFilters.Controls.Add(this.txtbExcludeFilter);
            this.xtraTabPageFilters.Controls.Add(this.txtbIncludeTextFilter);
            this.xtraTabPageFilters.Name = "xtraTabPageFilters";
            this.xtraTabPageFilters.Size = new System.Drawing.Size(810, 890);
            this.xtraTabPageFilters.Text = "Filters";
            // 
            // sbtnDeleteFilter
            // 
            this.sbtnDeleteFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnDeleteFilter.Location = new System.Drawing.Point(696, 858);
            this.sbtnDeleteFilter.Name = "sbtnDeleteFilter";
            this.sbtnDeleteFilter.Size = new System.Drawing.Size(110, 27);
            this.sbtnDeleteFilter.TabIndex = 38;
            this.sbtnDeleteFilter.Text = "Delete";
            this.sbtnDeleteFilter.Click += new System.EventHandler(this.sbtnDeleteFilter_Click);
            // 
            // lboxFilters
            // 
            this.lboxFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lboxFilters.Location = new System.Drawing.Point(4, 251);
            this.lboxFilters.Name = "lboxFilters";
            this.lboxFilters.Size = new System.Drawing.Size(802, 601);
            this.lboxFilters.TabIndex = 37;
            // 
            // sbtnAddFilter
            // 
            this.sbtnAddFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnAddFilter.Location = new System.Drawing.Point(724, 126);
            this.sbtnAddFilter.Name = "sbtnAddFilter";
            this.sbtnAddFilter.Size = new System.Drawing.Size(84, 27);
            this.sbtnAddFilter.TabIndex = 36;
            this.sbtnAddFilter.Text = "Add";
            this.sbtnAddFilter.Click += new System.EventHandler(this.sbtnAddFilter_Click);
            // 
            // lblExplaination
            // 
            this.lblExplaination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExplaination.AutoEllipsis = true;
            this.lblExplaination.Location = new System.Drawing.Point(4, 161);
            this.lblExplaination.Name = "lblExplaination";
            this.lblExplaination.Size = new System.Drawing.Size(803, 87);
            this.lblExplaination.TabIndex = 35;
            this.lblExplaination.Text = resources.GetString("lblExplaination.Text");
            // 
            // lblModules
            // 
            this.lblModules.AutoEllipsis = true;
            this.lblModules.Location = new System.Drawing.Point(4, 96);
            this.lblModules.Name = "lblModules";
            this.lblModules.Size = new System.Drawing.Size(190, 22);
            this.lblModules.TabIndex = 34;
            this.lblModules.Text = "Processes/Modules:";
            // 
            // lblSources
            // 
            this.lblSources.AutoEllipsis = true;
            this.lblSources.Location = new System.Drawing.Point(4, 67);
            this.lblSources.Name = "lblSources";
            this.lblSources.Size = new System.Drawing.Size(190, 22);
            this.lblSources.TabIndex = 33;
            this.lblSources.Text = "Sources";
            // 
            // lblExcludeMessageText
            // 
            this.lblExcludeMessageText.AutoEllipsis = true;
            this.lblExcludeMessageText.Location = new System.Drawing.Point(4, 37);
            this.lblExcludeMessageText.Name = "lblExcludeMessageText";
            this.lblExcludeMessageText.Size = new System.Drawing.Size(190, 22);
            this.lblExcludeMessageText.TabIndex = 32;
            this.lblExcludeMessageText.Text = "Exclude Message\'s text";
            // 
            // lblIncludeText
            // 
            this.lblIncludeText.AutoEllipsis = true;
            this.lblIncludeText.Location = new System.Drawing.Point(4, 8);
            this.lblIncludeText.Name = "lblIncludeText";
            this.lblIncludeText.Size = new System.Drawing.Size(190, 22);
            this.lblIncludeText.TabIndex = 31;
            this.lblIncludeText.Text = "Message\'s text";
            // 
            // txtbSourcesFilter
            // 
            this.txtbSourcesFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbSourcesFilter.Location = new System.Drawing.Point(200, 67);
            this.txtbSourcesFilter.Name = "txtbSourcesFilter";
            this.txtbSourcesFilter.Size = new System.Drawing.Size(607, 22);
            this.txtbSourcesFilter.TabIndex = 30;
            // 
            // txtbModulesFilter
            // 
            this.txtbModulesFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbModulesFilter.Location = new System.Drawing.Point(200, 97);
            this.txtbModulesFilter.Name = "txtbModulesFilter";
            this.txtbModulesFilter.Size = new System.Drawing.Size(607, 22);
            this.txtbModulesFilter.TabIndex = 29;
            // 
            // txtbExcludeFilter
            // 
            this.txtbExcludeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbExcludeFilter.Location = new System.Drawing.Point(200, 37);
            this.txtbExcludeFilter.Name = "txtbExcludeFilter";
            this.txtbExcludeFilter.Size = new System.Drawing.Size(607, 22);
            this.txtbExcludeFilter.TabIndex = 28;
            // 
            // txtbIncludeTextFilter
            // 
            this.txtbIncludeTextFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbIncludeTextFilter.Location = new System.Drawing.Point(200, 8);
            this.txtbIncludeTextFilter.Name = "txtbIncludeTextFilter";
            this.txtbIncludeTextFilter.Size = new System.Drawing.Size(607, 22);
            this.txtbIncludeTextFilter.TabIndex = 27;
            // 
            // xtraTabPageAlerts
            // 
            this.xtraTabPageAlerts.Controls.Add(this.sbtnDeleteAlerts);
            this.xtraTabPageAlerts.Controls.Add(this.lboxAlerts);
            this.xtraTabPageAlerts.Controls.Add(this.sbtnAddAlerts);
            this.xtraTabPageAlerts.Controls.Add(this.label5);
            this.xtraTabPageAlerts.Controls.Add(this.label1);
            this.xtraTabPageAlerts.Controls.Add(this.label2);
            this.xtraTabPageAlerts.Controls.Add(this.label3);
            this.xtraTabPageAlerts.Controls.Add(this.label4);
            this.xtraTabPageAlerts.Controls.Add(this.txtbSourcesAlert);
            this.xtraTabPageAlerts.Controls.Add(this.txtbModulesAlert);
            this.xtraTabPageAlerts.Controls.Add(this.txtbExcludeAlert);
            this.xtraTabPageAlerts.Controls.Add(this.txtbIncludeTextAlert);
            this.xtraTabPageAlerts.Name = "xtraTabPageAlerts";
            this.xtraTabPageAlerts.Size = new System.Drawing.Size(810, 890);
            this.xtraTabPageAlerts.Text = "Alert and Notifications";
            // 
            // sbtnDeleteAlerts
            // 
            this.sbtnDeleteAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnDeleteAlerts.Location = new System.Drawing.Point(696, 858);
            this.sbtnDeleteAlerts.Name = "sbtnDeleteAlerts";
            this.sbtnDeleteAlerts.Size = new System.Drawing.Size(110, 27);
            this.sbtnDeleteAlerts.TabIndex = 46;
            this.sbtnDeleteAlerts.Text = "Delete";
            this.sbtnDeleteAlerts.Click += new System.EventHandler(this.btnDeleteAlerts_Click);
            // 
            // lboxAlerts
            // 
            this.lboxAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lboxAlerts.Location = new System.Drawing.Point(4, 251);
            this.lboxAlerts.Name = "lboxAlerts";
            this.lboxAlerts.Size = new System.Drawing.Size(802, 601);
            this.lboxAlerts.TabIndex = 45;
            // 
            // sbtnAddAlerts
            // 
            this.sbtnAddAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnAddAlerts.Location = new System.Drawing.Point(724, 126);
            this.sbtnAddAlerts.Name = "sbtnAddAlerts";
            this.sbtnAddAlerts.Size = new System.Drawing.Size(84, 27);
            this.sbtnAddAlerts.TabIndex = 44;
            this.sbtnAddAlerts.Text = "Add";
            this.sbtnAddAlerts.Click += new System.EventHandler(this.sbtnAddAlerts_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoEllipsis = true;
            this.label5.Location = new System.Drawing.Point(4, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(803, 87);
            this.label5.TabIndex = 43;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(4, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 22);
            this.label1.TabIndex = 42;
            this.label1.Text = "Processes/Modules:";
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.Location = new System.Drawing.Point(4, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 22);
            this.label2.TabIndex = 41;
            this.label2.Text = "Sources";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.Location = new System.Drawing.Point(4, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 22);
            this.label3.TabIndex = 40;
            this.label3.Text = "Exclude Message\'s text";
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.Location = new System.Drawing.Point(4, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 22);
            this.label4.TabIndex = 39;
            this.label4.Text = "Message\'s text";
            // 
            // txtbSourcesAlert
            // 
            this.txtbSourcesAlert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbSourcesAlert.Location = new System.Drawing.Point(200, 67);
            this.txtbSourcesAlert.Name = "txtbSourcesAlert";
            this.txtbSourcesAlert.Size = new System.Drawing.Size(607, 22);
            this.txtbSourcesAlert.TabIndex = 38;
            // 
            // txtbModulesAlert
            // 
            this.txtbModulesAlert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbModulesAlert.Location = new System.Drawing.Point(200, 97);
            this.txtbModulesAlert.Name = "txtbModulesAlert";
            this.txtbModulesAlert.Size = new System.Drawing.Size(607, 22);
            this.txtbModulesAlert.TabIndex = 37;
            // 
            // txtbExcludeAlert
            // 
            this.txtbExcludeAlert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbExcludeAlert.Location = new System.Drawing.Point(200, 37);
            this.txtbExcludeAlert.Name = "txtbExcludeAlert";
            this.txtbExcludeAlert.Size = new System.Drawing.Size(607, 22);
            this.txtbExcludeAlert.TabIndex = 36;
            // 
            // txtbIncludeTextAlert
            // 
            this.txtbIncludeTextAlert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbIncludeTextAlert.Location = new System.Drawing.Point(200, 8);
            this.txtbIncludeTextAlert.Name = "txtbIncludeTextAlert";
            this.txtbIncludeTextAlert.Size = new System.Drawing.Size(607, 22);
            this.txtbIncludeTextAlert.TabIndex = 35;
            // 
            // tpColors
            // 
            this.tpColors.AutoScroll = true;
            this.tpColors.Controls.Add(this.groupControl5);
            this.tpColors.Controls.Add(this.gcColors);
            this.tpColors.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tpColors.ImageOptions.Image")));
            this.tpColors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpColors.Name = "tpColors";
            this.tpColors.Size = new System.Drawing.Size(817, 924);
            this.tpColors.Text = "Colors and Layout";
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.sbtnDateTimeFormat);
            this.groupControl5.Controls.Add(this.teDateTimeFormat);
            this.groupControl5.Controls.Add(this.labelControl11);
            this.groupControl5.Controls.Add(this.panelControlMessages);
            this.groupControl5.Controls.Add(this.lblHeader);
            this.groupControl5.Controls.Add(this.sbtnHeaderSet);
            this.groupControl5.Controls.Add(this.teHeader);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl5.Location = new System.Drawing.Point(0, 548);
            this.groupControl5.Margin = new System.Windows.Forms.Padding(10);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(817, 324);
            this.groupControl5.TabIndex = 10;
            this.groupControl5.Text = "Messages Layout";
            // 
            // sbtnDateTimeFormat
            // 
            this.sbtnDateTimeFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnDateTimeFormat.Location = new System.Drawing.Point(703, 292);
            this.sbtnDateTimeFormat.Name = "sbtnDateTimeFormat";
            this.sbtnDateTimeFormat.Size = new System.Drawing.Size(110, 27);
            this.sbtnDateTimeFormat.TabIndex = 14;
            this.sbtnDateTimeFormat.Text = "Set";
            this.sbtnDateTimeFormat.Click += new System.EventHandler(this.btnDateTimeFormat_Click);
            // 
            // teDateTimeFormat
            // 
            this.teDateTimeFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teDateTimeFormat.Location = new System.Drawing.Point(118, 295);
            this.teDateTimeFormat.Name = "teDateTimeFormat";
            this.teDateTimeFormat.Size = new System.Drawing.Size(579, 22);
            this.teDateTimeFormat.TabIndex = 13;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(7, 298);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(105, 16);
            this.labelControl11.TabIndex = 12;
            this.labelControl11.Text = "DateTime Format:";
            // 
            // panelControlMessages
            // 
            this.panelControlMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControlMessages.Controls.Add(this.gridControl);
            this.panelControlMessages.Location = new System.Drawing.Point(5, 88);
            this.panelControlMessages.Name = "panelControlMessages";
            this.panelControlMessages.Size = new System.Drawing.Size(801, 198);
            this.panelControlMessages.TabIndex = 8;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl.Location = new System.Drawing.Point(2, 2);
            this.gridControl.MainView = this.logGrid;
            this.gridControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(797, 194);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.logGrid});
            // 
            // logGrid
            // 
            this.logGrid.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.logGrid.Appearance.OddRow.Options.UseBackColor = true;
            this.logGrid.Appearance.Row.Options.UseTextOptions = true;
            this.logGrid.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.logGrid.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.logGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.logGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnDataSource,
            this.gridColumnDate,
            this.gridColumnTimeDiff,
            this.gridColumnText,
            this.gridColumnSource,
            this.gridColumnLevel,
            this.gridColumnClass,
            this.gridColumnCategory,
            this.gridColumnUser,
            this.gridColumnModule,
            this.gridColumnObject,
            this.gridColumnProcessID,
            this.gridColumnThread});
            this.logGrid.DetailHeight = 431;
            this.logGrid.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.logGrid.GridControl = this.gridControl;
            this.logGrid.IndicatorWidth = 24;
            this.logGrid.Name = "logGrid";
            this.logGrid.OptionsBehavior.Editable = false;
            this.logGrid.OptionsFilter.AllowColumnMRUFilterList = false;
            this.logGrid.OptionsFilter.AllowMRUFilterList = false;
            this.logGrid.OptionsLayout.Columns.StoreAllOptions = true;
            this.logGrid.OptionsLayout.Columns.StoreAppearance = true;
            this.logGrid.OptionsLayout.StoreAllOptions = true;
            this.logGrid.OptionsLayout.StoreAppearance = true;
            this.logGrid.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.logGrid.OptionsView.AutoCalcPreviewLineCount = true;
            this.logGrid.OptionsView.ColumnAutoWidth = false;
            this.logGrid.OptionsView.RowAutoHeight = true;
            this.logGrid.OptionsView.ShowAutoFilterRow = true;
            this.logGrid.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnDataSource
            // 
            this.gridColumnDataSource.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnDataSource.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnDataSource.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnDataSource.Caption = "Data Source/File Name";
            this.gridColumnDataSource.FieldName = "DataProvider";
            this.gridColumnDataSource.MinWidth = 24;
            this.gridColumnDataSource.Name = "gridColumnDataSource";
            this.gridColumnDataSource.OptionsColumn.AllowEdit = false;
            this.gridColumnDataSource.OptionsColumn.AllowFocus = false;
            this.gridColumnDataSource.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDataSource.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDataSource.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnDataSource.OptionsColumn.ReadOnly = true;
            this.gridColumnDataSource.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnDataSource.Visible = true;
            this.gridColumnDataSource.VisibleIndex = 0;
            this.gridColumnDataSource.Width = 175;
            // 
            // gridColumnDate
            // 
            this.gridColumnDate.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnDate.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnDate.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnDate.Caption = "Date";
            this.gridColumnDate.DisplayFormat.FormatString = "yyyy.MM.dd HH:mm:ss.ff";
            this.gridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnDate.FieldName = "Date";
            this.gridColumnDate.MinWidth = 24;
            this.gridColumnDate.Name = "gridColumnDate";
            this.gridColumnDate.OptionsColumn.AllowEdit = false;
            this.gridColumnDate.OptionsColumn.AllowFocus = false;
            this.gridColumnDate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnDate.OptionsColumn.ReadOnly = true;
            this.gridColumnDate.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnDate.Visible = true;
            this.gridColumnDate.VisibleIndex = 1;
            this.gridColumnDate.Width = 164;
            // 
            // gridColumnTimeDiff
            // 
            this.gridColumnTimeDiff.Caption = "Time Difference";
            this.gridColumnTimeDiff.FieldName = "TimeDiff";
            this.gridColumnTimeDiff.MinWidth = 22;
            this.gridColumnTimeDiff.Name = "gridColumnTimeDiff";
            this.gridColumnTimeDiff.Width = 87;
            // 
            // gridColumnText
            // 
            this.gridColumnText.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnText.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnText.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnText.Caption = "Text";
            this.gridColumnText.FieldName = "Text";
            this.gridColumnText.MinWidth = 24;
            this.gridColumnText.Name = "gridColumnText";
            this.gridColumnText.OptionsColumn.AllowEdit = false;
            this.gridColumnText.OptionsColumn.AllowFocus = false;
            this.gridColumnText.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnText.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnText.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnText.OptionsColumn.ReadOnly = true;
            this.gridColumnText.OptionsFilter.AllowFilter = false;
            this.gridColumnText.Visible = true;
            this.gridColumnText.VisibleIndex = 2;
            this.gridColumnText.Width = 290;
            // 
            // gridColumnSource
            // 
            this.gridColumnSource.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnSource.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnSource.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnSource.Caption = "Source";
            this.gridColumnSource.FieldName = "Source";
            this.gridColumnSource.MinWidth = 24;
            this.gridColumnSource.Name = "gridColumnSource";
            this.gridColumnSource.OptionsColumn.AllowEdit = false;
            this.gridColumnSource.OptionsColumn.AllowFocus = false;
            this.gridColumnSource.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnSource.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnSource.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnSource.OptionsColumn.ReadOnly = true;
            this.gridColumnSource.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnSource.Visible = true;
            this.gridColumnSource.VisibleIndex = 3;
            this.gridColumnSource.Width = 234;
            // 
            // gridColumnLevel
            // 
            this.gridColumnLevel.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnLevel.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnLevel.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnLevel.Caption = "Level";
            this.gridColumnLevel.FieldName = "Level";
            this.gridColumnLevel.MinWidth = 24;
            this.gridColumnLevel.Name = "gridColumnLevel";
            this.gridColumnLevel.OptionsColumn.AllowEdit = false;
            this.gridColumnLevel.OptionsColumn.AllowFocus = false;
            this.gridColumnLevel.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnLevel.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnLevel.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnLevel.OptionsColumn.ReadOnly = true;
            this.gridColumnLevel.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnLevel.Visible = true;
            this.gridColumnLevel.VisibleIndex = 4;
            this.gridColumnLevel.Width = 115;
            // 
            // gridColumnClass
            // 
            this.gridColumnClass.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnClass.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnClass.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnClass.Caption = "Class";
            this.gridColumnClass.FieldName = "Class";
            this.gridColumnClass.MinWidth = 24;
            this.gridColumnClass.Name = "gridColumnClass";
            this.gridColumnClass.OptionsColumn.AllowEdit = false;
            this.gridColumnClass.OptionsColumn.AllowFocus = false;
            this.gridColumnClass.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnClass.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnClass.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnClass.OptionsColumn.ReadOnly = true;
            this.gridColumnClass.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnClass.Visible = true;
            this.gridColumnClass.VisibleIndex = 6;
            this.gridColumnClass.Width = 115;
            // 
            // gridColumnCategory
            // 
            this.gridColumnCategory.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnCategory.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnCategory.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnCategory.Caption = "Category";
            this.gridColumnCategory.FieldName = "Category";
            this.gridColumnCategory.MinWidth = 24;
            this.gridColumnCategory.Name = "gridColumnCategory";
            this.gridColumnCategory.OptionsColumn.AllowEdit = false;
            this.gridColumnCategory.OptionsColumn.AllowFocus = false;
            this.gridColumnCategory.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnCategory.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnCategory.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnCategory.OptionsColumn.ReadOnly = true;
            this.gridColumnCategory.Visible = true;
            this.gridColumnCategory.VisibleIndex = 7;
            this.gridColumnCategory.Width = 115;
            // 
            // gridColumnUser
            // 
            this.gridColumnUser.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnUser.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnUser.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnUser.Caption = "User";
            this.gridColumnUser.FieldName = "User";
            this.gridColumnUser.MinWidth = 24;
            this.gridColumnUser.Name = "gridColumnUser";
            this.gridColumnUser.OptionsColumn.AllowEdit = false;
            this.gridColumnUser.OptionsColumn.AllowFocus = false;
            this.gridColumnUser.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnUser.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnUser.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnUser.OptionsColumn.ReadOnly = true;
            this.gridColumnUser.Visible = true;
            this.gridColumnUser.VisibleIndex = 8;
            this.gridColumnUser.Width = 115;
            // 
            // gridColumnModule
            // 
            this.gridColumnModule.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnModule.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnModule.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnModule.Caption = "Process/Module";
            this.gridColumnModule.FieldName = "Module";
            this.gridColumnModule.MinWidth = 24;
            this.gridColumnModule.Name = "gridColumnModule";
            this.gridColumnModule.OptionsColumn.AllowEdit = false;
            this.gridColumnModule.OptionsColumn.AllowFocus = false;
            this.gridColumnModule.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnModule.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnModule.OptionsColumn.ReadOnly = true;
            this.gridColumnModule.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnModule.Visible = true;
            this.gridColumnModule.VisibleIndex = 5;
            this.gridColumnModule.Width = 115;
            // 
            // gridColumnObject
            // 
            this.gridColumnObject.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnObject.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnObject.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnObject.Caption = "Object";
            this.gridColumnObject.FieldName = "Object";
            this.gridColumnObject.MinWidth = 24;
            this.gridColumnObject.Name = "gridColumnObject";
            this.gridColumnObject.OptionsColumn.AllowEdit = false;
            this.gridColumnObject.OptionsColumn.AllowFocus = false;
            this.gridColumnObject.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnObject.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnObject.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnObject.OptionsColumn.ReadOnly = true;
            this.gridColumnObject.OptionsColumn.ShowCaption = false;
            this.gridColumnObject.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumnObject.Width = 87;
            // 
            // gridColumnProcessID
            // 
            this.gridColumnProcessID.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnProcessID.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnProcessID.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnProcessID.Caption = "ProcessID";
            this.gridColumnProcessID.FieldName = "ProcessID";
            this.gridColumnProcessID.MinWidth = 24;
            this.gridColumnProcessID.Name = "gridColumnProcessID";
            this.gridColumnProcessID.OptionsColumn.AllowEdit = false;
            this.gridColumnProcessID.OptionsColumn.AllowFocus = false;
            this.gridColumnProcessID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnProcessID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnProcessID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnProcessID.OptionsColumn.ReadOnly = true;
            this.gridColumnProcessID.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnProcessID.Visible = true;
            this.gridColumnProcessID.VisibleIndex = 9;
            this.gridColumnProcessID.Width = 115;
            // 
            // gridColumnThread
            // 
            this.gridColumnThread.Caption = "Thread ID";
            this.gridColumnThread.FieldName = "ThreadID";
            this.gridColumnThread.MinWidth = 25;
            this.gridColumnThread.Name = "gridColumnThread";
            this.gridColumnThread.Visible = true;
            this.gridColumnThread.VisibleIndex = 10;
            this.gridColumnThread.Width = 109;
            // 
            // lblHeader
            // 
            this.lblHeader.Location = new System.Drawing.Point(5, 28);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(229, 16);
            this.lblHeader.TabIndex = 11;
            this.lblHeader.Text = "Click on any header below to rename it:";
            // 
            // sbtnHeaderSet
            // 
            this.sbtnHeaderSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnHeaderSet.Location = new System.Drawing.Point(702, 51);
            this.sbtnHeaderSet.Name = "sbtnHeaderSet";
            this.sbtnHeaderSet.Size = new System.Drawing.Size(110, 27);
            this.sbtnHeaderSet.TabIndex = 10;
            this.sbtnHeaderSet.Text = "Set";
            this.sbtnHeaderSet.Click += new System.EventHandler(this.btnHeaderSet_Click);
            // 
            // teHeader
            // 
            this.teHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teHeader.Location = new System.Drawing.Point(5, 54);
            this.teHeader.Name = "teHeader";
            this.teHeader.Size = new System.Drawing.Size(691, 22);
            this.teHeader.TabIndex = 9;
            // 
            // gcColors
            // 
            this.gcColors.Controls.Add(this.sBtnExportColors);
            this.gcColors.Controls.Add(this.cpeNewMessagesColorText);
            this.gcColors.Controls.Add(this.sBtnImportColors);
            this.gcColors.Controls.Add(this.cpeHighlightColorText);
            this.gcColors.Controls.Add(this.tsEnableColors);
            this.gcColors.Controls.Add(this.ceOverrideLogLevelColor);
            this.gcColors.Controls.Add(this.groupControl2);
            this.gcColors.Controls.Add(this.ceNewMessagesColor);
            this.gcColors.Controls.Add(this.lblHighlightColor);
            this.gcColors.Controls.Add(this.cpeNewMessagesColor);
            this.gcColors.Controls.Add(this.cpeHighlightColor);
            this.gcColors.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcColors.Location = new System.Drawing.Point(0, 0);
            this.gcColors.Name = "gcColors";
            this.gcColors.Size = new System.Drawing.Size(817, 548);
            this.gcColors.TabIndex = 33;
            this.gcColors.Text = "Colors";
            // 
            // sBtnExportColors
            // 
            this.sBtnExportColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sBtnExportColors.Location = new System.Drawing.Point(535, 28);
            this.sBtnExportColors.Name = "sBtnExportColors";
            this.sBtnExportColors.Size = new System.Drawing.Size(134, 32);
            this.sBtnExportColors.TabIndex = 22;
            this.sBtnExportColors.Text = "Export Colors";
            this.sBtnExportColors.Click += new System.EventHandler(this.sBtnExportColors_Click);
            // 
            // cpeNewMessagesColorText
            // 
            this.cpeNewMessagesColorText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeNewMessagesColorText.EditValue = System.Drawing.Color.Empty;
            this.cpeNewMessagesColorText.Location = new System.Drawing.Point(591, 456);
            this.cpeNewMessagesColorText.Name = "cpeNewMessagesColorText";
            this.cpeNewMessagesColorText.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeNewMessagesColorText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeNewMessagesColorText.Size = new System.Drawing.Size(206, 22);
            this.cpeNewMessagesColorText.TabIndex = 32;
            // 
            // sBtnImportColors
            // 
            this.sBtnImportColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sBtnImportColors.Location = new System.Drawing.Point(675, 28);
            this.sBtnImportColors.Name = "sBtnImportColors";
            this.sBtnImportColors.Size = new System.Drawing.Size(134, 32);
            this.sBtnImportColors.TabIndex = 23;
            this.sBtnImportColors.Text = "Import Colors";
            this.sBtnImportColors.Click += new System.EventHandler(this.sBtnImportColors_Click);
            // 
            // cpeHighlightColorText
            // 
            this.cpeHighlightColorText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeHighlightColorText.EditValue = System.Drawing.Color.Empty;
            this.cpeHighlightColorText.Location = new System.Drawing.Point(591, 425);
            this.cpeHighlightColorText.Name = "cpeHighlightColorText";
            this.cpeHighlightColorText.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeHighlightColorText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeHighlightColorText.Size = new System.Drawing.Size(206, 22);
            this.cpeHighlightColorText.TabIndex = 31;
            // 
            // tsEnableColors
            // 
            this.tsEnableColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsEnableColors.Location = new System.Drawing.Point(7, 30);
            this.tsEnableColors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsEnableColors.Name = "tsEnableColors";
            this.tsEnableColors.Properties.OffText = "Colors are disabled";
            this.tsEnableColors.Properties.OnText = "Colors are enabled";
            this.tsEnableColors.Size = new System.Drawing.Size(522, 28);
            this.tsEnableColors.TabIndex = 28;
            // 
            // ceOverrideLogLevelColor
            // 
            this.ceOverrideLogLevelColor.Location = new System.Drawing.Point(29, 483);
            this.ceOverrideLogLevelColor.Name = "ceOverrideLogLevelColor";
            this.ceOverrideLogLevelColor.Properties.Caption = "New messages Color: Override Log Level Colors";
            this.ceOverrideLogLevelColor.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.ceOverrideLogLevelColor.Size = new System.Drawing.Size(300, 20);
            this.ceOverrideLogLevelColor.TabIndex = 27;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.lblLogLevelRowTextColor);
            this.groupControl2.Controls.Add(this.cpeLogLevelAnalogyInformationText);
            this.groupControl2.Controls.Add(this.cpeLogLevelCriticalText);
            this.groupControl2.Controls.Add(this.cpeLogLevelErrorText);
            this.groupControl2.Controls.Add(this.cpeLogLevelWarningText);
            this.groupControl2.Controls.Add(this.cpeLogLevelEventText);
            this.groupControl2.Controls.Add(this.cpeLogLevelDebugText);
            this.groupControl2.Controls.Add(this.cpeLogLevelVerboseText);
            this.groupControl2.Controls.Add(this.cpeLogLevelTraceText);
            this.groupControl2.Controls.Add(this.cpeLogLevelDisabledText);
            this.groupControl2.Controls.Add(this.cpeLogLevelUnknownText);
            this.groupControl2.Controls.Add(this.lblLogLevelBackground);
            this.groupControl2.Controls.Add(this.lblLogLevelAnalogyInformation);
            this.groupControl2.Controls.Add(this.cpeLogLevelAnalogyInformation);
            this.groupControl2.Controls.Add(this.lblLogLevelCritical);
            this.groupControl2.Controls.Add(this.cpeLogLevelCritical);
            this.groupControl2.Controls.Add(this.lblLogLevelError);
            this.groupControl2.Controls.Add(this.cpeLogLevelError);
            this.groupControl2.Controls.Add(this.lblLogLevelWarning);
            this.groupControl2.Controls.Add(this.cpeLogLevelWarning);
            this.groupControl2.Controls.Add(this.lblLogLevelEvent);
            this.groupControl2.Controls.Add(this.cpeLogLevelEvent);
            this.groupControl2.Controls.Add(this.lblLogLevelDebug);
            this.groupControl2.Controls.Add(this.cpeLogLevelDebug);
            this.groupControl2.Controls.Add(this.lblLogLevelVerbose);
            this.groupControl2.Controls.Add(this.cpeLogLevelVerbose);
            this.groupControl2.Controls.Add(this.lblLogLevelTrace);
            this.groupControl2.Controls.Add(this.cpeLogLevelTrace);
            this.groupControl2.Controls.Add(this.lblLogLevelDisabled);
            this.groupControl2.Controls.Add(this.cpeLogLevelDisabled);
            this.groupControl2.Controls.Add(this.lblLogLevelUnknown);
            this.groupControl2.Controls.Add(this.cpeLogLevelUnknown);
            this.groupControl2.Location = new System.Drawing.Point(10, 69);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(802, 350);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Log Level Colors Settings";
            // 
            // lblLogLevelRowTextColor
            // 
            this.lblLogLevelRowTextColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogLevelRowTextColor.Location = new System.Drawing.Point(656, 28);
            this.lblLogLevelRowTextColor.Name = "lblLogLevelRowTextColor";
            this.lblLogLevelRowTextColor.Size = new System.Drawing.Size(86, 16);
            this.lblLogLevelRowTextColor.TabIndex = 31;
            this.lblLogLevelRowTextColor.Text = "Row Text color";
            // 
            // cpeLogLevelAnalogyInformationText
            // 
            this.cpeLogLevelAnalogyInformationText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelAnalogyInformationText.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelAnalogyInformationText.Location = new System.Drawing.Point(581, 302);
            this.cpeLogLevelAnalogyInformationText.Name = "cpeLogLevelAnalogyInformationText";
            this.cpeLogLevelAnalogyInformationText.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelAnalogyInformationText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelAnalogyInformationText.Size = new System.Drawing.Size(206, 22);
            this.cpeLogLevelAnalogyInformationText.TabIndex = 30;
            // 
            // cpeLogLevelCriticalText
            // 
            this.cpeLogLevelCriticalText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelCriticalText.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelCriticalText.Location = new System.Drawing.Point(581, 274);
            this.cpeLogLevelCriticalText.Name = "cpeLogLevelCriticalText";
            this.cpeLogLevelCriticalText.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelCriticalText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelCriticalText.Size = new System.Drawing.Size(206, 22);
            this.cpeLogLevelCriticalText.TabIndex = 29;
            // 
            // cpeLogLevelErrorText
            // 
            this.cpeLogLevelErrorText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelErrorText.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelErrorText.Location = new System.Drawing.Point(581, 246);
            this.cpeLogLevelErrorText.Name = "cpeLogLevelErrorText";
            this.cpeLogLevelErrorText.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelErrorText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelErrorText.Size = new System.Drawing.Size(206, 22);
            this.cpeLogLevelErrorText.TabIndex = 28;
            // 
            // cpeLogLevelWarningText
            // 
            this.cpeLogLevelWarningText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelWarningText.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelWarningText.Location = new System.Drawing.Point(581, 218);
            this.cpeLogLevelWarningText.Name = "cpeLogLevelWarningText";
            this.cpeLogLevelWarningText.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelWarningText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelWarningText.Size = new System.Drawing.Size(206, 22);
            this.cpeLogLevelWarningText.TabIndex = 27;
            // 
            // cpeLogLevelEventText
            // 
            this.cpeLogLevelEventText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelEventText.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelEventText.Location = new System.Drawing.Point(581, 190);
            this.cpeLogLevelEventText.Name = "cpeLogLevelEventText";
            this.cpeLogLevelEventText.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelEventText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelEventText.Size = new System.Drawing.Size(206, 22);
            this.cpeLogLevelEventText.TabIndex = 26;
            // 
            // cpeLogLevelDebugText
            // 
            this.cpeLogLevelDebugText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelDebugText.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelDebugText.Location = new System.Drawing.Point(581, 162);
            this.cpeLogLevelDebugText.Name = "cpeLogLevelDebugText";
            this.cpeLogLevelDebugText.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelDebugText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelDebugText.Size = new System.Drawing.Size(206, 22);
            this.cpeLogLevelDebugText.TabIndex = 25;
            // 
            // cpeLogLevelVerboseText
            // 
            this.cpeLogLevelVerboseText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelVerboseText.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelVerboseText.Location = new System.Drawing.Point(581, 134);
            this.cpeLogLevelVerboseText.Name = "cpeLogLevelVerboseText";
            this.cpeLogLevelVerboseText.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelVerboseText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelVerboseText.Size = new System.Drawing.Size(206, 22);
            this.cpeLogLevelVerboseText.TabIndex = 24;
            // 
            // cpeLogLevelTraceText
            // 
            this.cpeLogLevelTraceText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelTraceText.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelTraceText.Location = new System.Drawing.Point(581, 106);
            this.cpeLogLevelTraceText.Name = "cpeLogLevelTraceText";
            this.cpeLogLevelTraceText.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelTraceText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelTraceText.Size = new System.Drawing.Size(206, 22);
            this.cpeLogLevelTraceText.TabIndex = 23;
            // 
            // cpeLogLevelDisabledText
            // 
            this.cpeLogLevelDisabledText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelDisabledText.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelDisabledText.Location = new System.Drawing.Point(581, 78);
            this.cpeLogLevelDisabledText.Name = "cpeLogLevelDisabledText";
            this.cpeLogLevelDisabledText.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelDisabledText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelDisabledText.Size = new System.Drawing.Size(206, 22);
            this.cpeLogLevelDisabledText.TabIndex = 22;
            // 
            // cpeLogLevelUnknownText
            // 
            this.cpeLogLevelUnknownText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelUnknownText.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelUnknownText.Location = new System.Drawing.Point(581, 50);
            this.cpeLogLevelUnknownText.Name = "cpeLogLevelUnknownText";
            this.cpeLogLevelUnknownText.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelUnknownText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelUnknownText.Size = new System.Drawing.Size(206, 22);
            this.cpeLogLevelUnknownText.TabIndex = 21;
            // 
            // lblLogLevelBackground
            // 
            this.lblLogLevelBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogLevelBackground.Location = new System.Drawing.Point(425, 28);
            this.lblLogLevelBackground.Name = "lblLogLevelBackground";
            this.lblLogLevelBackground.Size = new System.Drawing.Size(127, 16);
            this.lblLogLevelBackground.TabIndex = 20;
            this.lblLogLevelBackground.Text = "Row background color";
            // 
            // lblLogLevelAnalogyInformation
            // 
            this.lblLogLevelAnalogyInformation.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblLogLevelAnalogyInformation.Location = new System.Drawing.Point(18, 310);
            this.lblLogLevelAnalogyInformation.Name = "lblLogLevelAnalogyInformation";
            this.lblLogLevelAnalogyInformation.Size = new System.Drawing.Size(140, 16);
            this.lblLogLevelAnalogyInformation.TabIndex = 19;
            this.lblLogLevelAnalogyInformation.Text = "AnalogyInformation:";
            // 
            // cpeLogLevelAnalogyInformation
            // 
            this.cpeLogLevelAnalogyInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelAnalogyInformation.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelAnalogyInformation.Location = new System.Drawing.Point(397, 302);
            this.cpeLogLevelAnalogyInformation.Name = "cpeLogLevelAnalogyInformation";
            this.cpeLogLevelAnalogyInformation.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelAnalogyInformation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelAnalogyInformation.Size = new System.Drawing.Size(171, 22);
            this.cpeLogLevelAnalogyInformation.TabIndex = 18;
            // 
            // lblLogLevelCritical
            // 
            this.lblLogLevelCritical.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblLogLevelCritical.Location = new System.Drawing.Point(19, 282);
            this.lblLogLevelCritical.Name = "lblLogLevelCritical";
            this.lblLogLevelCritical.Size = new System.Drawing.Size(140, 16);
            this.lblLogLevelCritical.TabIndex = 17;
            this.lblLogLevelCritical.Text = "Critical:";
            // 
            // cpeLogLevelCritical
            // 
            this.cpeLogLevelCritical.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelCritical.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelCritical.Location = new System.Drawing.Point(397, 274);
            this.cpeLogLevelCritical.Name = "cpeLogLevelCritical";
            this.cpeLogLevelCritical.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelCritical.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelCritical.Size = new System.Drawing.Size(171, 22);
            this.cpeLogLevelCritical.TabIndex = 16;
            // 
            // lblLogLevelError
            // 
            this.lblLogLevelError.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblLogLevelError.Location = new System.Drawing.Point(19, 254);
            this.lblLogLevelError.Name = "lblLogLevelError";
            this.lblLogLevelError.Size = new System.Drawing.Size(140, 16);
            this.lblLogLevelError.TabIndex = 15;
            this.lblLogLevelError.Text = "Error:";
            // 
            // cpeLogLevelError
            // 
            this.cpeLogLevelError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelError.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelError.Location = new System.Drawing.Point(397, 246);
            this.cpeLogLevelError.Name = "cpeLogLevelError";
            this.cpeLogLevelError.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelError.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelError.Size = new System.Drawing.Size(171, 22);
            this.cpeLogLevelError.TabIndex = 14;
            // 
            // lblLogLevelWarning
            // 
            this.lblLogLevelWarning.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblLogLevelWarning.Location = new System.Drawing.Point(19, 226);
            this.lblLogLevelWarning.Name = "lblLogLevelWarning";
            this.lblLogLevelWarning.Size = new System.Drawing.Size(140, 16);
            this.lblLogLevelWarning.TabIndex = 13;
            this.lblLogLevelWarning.Text = "Warning:";
            // 
            // cpeLogLevelWarning
            // 
            this.cpeLogLevelWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelWarning.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelWarning.Location = new System.Drawing.Point(397, 218);
            this.cpeLogLevelWarning.Name = "cpeLogLevelWarning";
            this.cpeLogLevelWarning.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelWarning.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelWarning.Size = new System.Drawing.Size(171, 22);
            this.cpeLogLevelWarning.TabIndex = 12;
            // 
            // lblLogLevelEvent
            // 
            this.lblLogLevelEvent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblLogLevelEvent.Location = new System.Drawing.Point(19, 198);
            this.lblLogLevelEvent.Name = "lblLogLevelEvent";
            this.lblLogLevelEvent.Size = new System.Drawing.Size(140, 16);
            this.lblLogLevelEvent.TabIndex = 11;
            this.lblLogLevelEvent.Text = "Event:";
            // 
            // cpeLogLevelEvent
            // 
            this.cpeLogLevelEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelEvent.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelEvent.Location = new System.Drawing.Point(397, 190);
            this.cpeLogLevelEvent.Name = "cpeLogLevelEvent";
            this.cpeLogLevelEvent.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelEvent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelEvent.Size = new System.Drawing.Size(171, 22);
            this.cpeLogLevelEvent.TabIndex = 10;
            // 
            // lblLogLevelDebug
            // 
            this.lblLogLevelDebug.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblLogLevelDebug.Location = new System.Drawing.Point(19, 170);
            this.lblLogLevelDebug.Name = "lblLogLevelDebug";
            this.lblLogLevelDebug.Size = new System.Drawing.Size(140, 16);
            this.lblLogLevelDebug.TabIndex = 9;
            this.lblLogLevelDebug.Text = "Debug:";
            // 
            // cpeLogLevelDebug
            // 
            this.cpeLogLevelDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelDebug.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelDebug.Location = new System.Drawing.Point(397, 162);
            this.cpeLogLevelDebug.Name = "cpeLogLevelDebug";
            this.cpeLogLevelDebug.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelDebug.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelDebug.Size = new System.Drawing.Size(171, 22);
            this.cpeLogLevelDebug.TabIndex = 8;
            // 
            // lblLogLevelVerbose
            // 
            this.lblLogLevelVerbose.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblLogLevelVerbose.Location = new System.Drawing.Point(19, 142);
            this.lblLogLevelVerbose.Name = "lblLogLevelVerbose";
            this.lblLogLevelVerbose.Size = new System.Drawing.Size(140, 16);
            this.lblLogLevelVerbose.TabIndex = 7;
            this.lblLogLevelVerbose.Text = "Verbose:";
            // 
            // cpeLogLevelVerbose
            // 
            this.cpeLogLevelVerbose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelVerbose.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelVerbose.Location = new System.Drawing.Point(397, 134);
            this.cpeLogLevelVerbose.Name = "cpeLogLevelVerbose";
            this.cpeLogLevelVerbose.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelVerbose.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelVerbose.Size = new System.Drawing.Size(171, 22);
            this.cpeLogLevelVerbose.TabIndex = 6;
            // 
            // lblLogLevelTrace
            // 
            this.lblLogLevelTrace.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblLogLevelTrace.Location = new System.Drawing.Point(19, 114);
            this.lblLogLevelTrace.Name = "lblLogLevelTrace";
            this.lblLogLevelTrace.Size = new System.Drawing.Size(140, 16);
            this.lblLogLevelTrace.TabIndex = 5;
            this.lblLogLevelTrace.Text = "Trace:";
            // 
            // cpeLogLevelTrace
            // 
            this.cpeLogLevelTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelTrace.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelTrace.Location = new System.Drawing.Point(397, 106);
            this.cpeLogLevelTrace.Name = "cpeLogLevelTrace";
            this.cpeLogLevelTrace.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelTrace.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelTrace.Size = new System.Drawing.Size(171, 22);
            this.cpeLogLevelTrace.TabIndex = 4;
            // 
            // lblLogLevelDisabled
            // 
            this.lblLogLevelDisabled.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblLogLevelDisabled.Location = new System.Drawing.Point(19, 86);
            this.lblLogLevelDisabled.Name = "lblLogLevelDisabled";
            this.lblLogLevelDisabled.Size = new System.Drawing.Size(140, 16);
            this.lblLogLevelDisabled.TabIndex = 3;
            this.lblLogLevelDisabled.Text = "Disabled:";
            // 
            // cpeLogLevelDisabled
            // 
            this.cpeLogLevelDisabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelDisabled.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelDisabled.Location = new System.Drawing.Point(397, 78);
            this.cpeLogLevelDisabled.Name = "cpeLogLevelDisabled";
            this.cpeLogLevelDisabled.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelDisabled.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelDisabled.Size = new System.Drawing.Size(171, 22);
            this.cpeLogLevelDisabled.TabIndex = 2;
            // 
            // lblLogLevelUnknown
            // 
            this.lblLogLevelUnknown.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblLogLevelUnknown.Location = new System.Drawing.Point(19, 58);
            this.lblLogLevelUnknown.Name = "lblLogLevelUnknown";
            this.lblLogLevelUnknown.Size = new System.Drawing.Size(140, 16);
            this.lblLogLevelUnknown.TabIndex = 1;
            this.lblLogLevelUnknown.Text = "Unknown:";
            // 
            // cpeLogLevelUnknown
            // 
            this.cpeLogLevelUnknown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeLogLevelUnknown.EditValue = System.Drawing.Color.Empty;
            this.cpeLogLevelUnknown.Location = new System.Drawing.Point(397, 50);
            this.cpeLogLevelUnknown.Name = "cpeLogLevelUnknown";
            this.cpeLogLevelUnknown.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeLogLevelUnknown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeLogLevelUnknown.Size = new System.Drawing.Size(171, 22);
            this.cpeLogLevelUnknown.TabIndex = 0;
            // 
            // ceNewMessagesColor
            // 
            this.ceNewMessagesColor.Location = new System.Drawing.Point(28, 457);
            this.ceNewMessagesColor.Name = "ceNewMessagesColor";
            this.ceNewMessagesColor.Properties.Caption = "New messages Color (for reload or pooling):";
            this.ceNewMessagesColor.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.ceNewMessagesColor.Size = new System.Drawing.Size(300, 20);
            this.ceNewMessagesColor.TabIndex = 26;
            this.ceNewMessagesColor.CheckedChanged += new System.EventHandler(this.ceNewMessagesColor_CheckedChanged);
            // 
            // lblHighlightColor
            // 
            this.lblHighlightColor.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblHighlightColor.Location = new System.Drawing.Point(28, 428);
            this.lblHighlightColor.Name = "lblHighlightColor";
            this.lblHighlightColor.Size = new System.Drawing.Size(140, 16);
            this.lblHighlightColor.TabIndex = 21;
            this.lblHighlightColor.Text = "Highlight Color:";
            // 
            // cpeNewMessagesColor
            // 
            this.cpeNewMessagesColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeNewMessagesColor.EditValue = System.Drawing.Color.Empty;
            this.cpeNewMessagesColor.Location = new System.Drawing.Point(407, 455);
            this.cpeNewMessagesColor.Name = "cpeNewMessagesColor";
            this.cpeNewMessagesColor.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeNewMessagesColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeNewMessagesColor.Size = new System.Drawing.Size(171, 22);
            this.cpeNewMessagesColor.TabIndex = 24;
            // 
            // cpeHighlightColor
            // 
            this.cpeHighlightColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeHighlightColor.EditValue = System.Drawing.Color.Empty;
            this.cpeHighlightColor.Location = new System.Drawing.Point(407, 425);
            this.cpeHighlightColor.Name = "cpeHighlightColor";
            this.cpeHighlightColor.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeHighlightColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeHighlightColor.Size = new System.Drawing.Size(171, 22);
            this.cpeHighlightColor.TabIndex = 20;
            // 
            // xtShortcuts
            // 
            this.xtShortcuts.AutoScroll = true;
            this.xtShortcuts.Controls.Add(this.labelControl10);
            this.xtShortcuts.Controls.Add(this.labelControl3);
            this.xtShortcuts.Controls.Add(this.labelControl4);
            this.xtShortcuts.Controls.Add(this.labelControl2);
            this.xtShortcuts.Controls.Add(this.labelControl1);
            this.xtShortcuts.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtShortcuts.ImageOptions.Image")));
            this.xtShortcuts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtShortcuts.Name = "xtShortcuts";
            this.xtShortcuts.Size = new System.Drawing.Size(817, 924);
            this.xtShortcuts.Text = "Shortcuts";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(26, 19);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(445, 16);
            this.labelControl10.TabIndex = 8;
            this.labelControl10.Text = "Show/Hide Selected message detailed information: Ctrl + D or Plus/Minus key";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(26, 147);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(284, 16);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Toggle on/off warning log level filtering: ALT + W";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(26, 115);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(317, 16);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Toggle on/off Error + Critical log level filtering: ALT + E";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(26, 80);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(219, 16);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Go to exclude filter textbox: SHIFT + F";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 48);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(201, 16);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Go to include filter textbox: Ctrl + F";
            // 
            // xTabMRU
            // 
            this.xTabMRU.AutoScroll = true;
            this.xTabMRU.Controls.Add(this.lblRecentFolders);
            this.xTabMRU.Controls.Add(this.nudRecentFolders);
            this.xTabMRU.Controls.Add(this.lblRecent);
            this.xTabMRU.Controls.Add(this.nudRecentFiles);
            this.xTabMRU.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xTabMRU.ImageOptions.Image")));
            this.xTabMRU.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xTabMRU.Name = "xTabMRU";
            this.xTabMRU.Size = new System.Drawing.Size(817, 924);
            this.xTabMRU.Text = "Most Recently Used";
            // 
            // lblRecentFolders
            // 
            this.lblRecentFolders.Location = new System.Drawing.Point(20, 43);
            this.lblRecentFolders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblRecentFolders.Name = "lblRecentFolders";
            this.lblRecentFolders.Size = new System.Drawing.Size(194, 16);
            this.lblRecentFolders.TabIndex = 5;
            this.lblRecentFolders.Text = "Number of recent folders to keep:";
            // 
            // nudRecentFolders
            // 
            this.nudRecentFolders.Location = new System.Drawing.Point(247, 41);
            this.nudRecentFolders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudRecentFolders.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudRecentFolders.Name = "nudRecentFolders";
            this.nudRecentFolders.Size = new System.Drawing.Size(73, 23);
            this.nudRecentFolders.TabIndex = 4;
            this.nudRecentFolders.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRecent
            // 
            this.lblRecent.Location = new System.Drawing.Point(20, 12);
            this.lblRecent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblRecent.Name = "lblRecent";
            this.lblRecent.Size = new System.Drawing.Size(178, 16);
            this.lblRecent.TabIndex = 3;
            this.lblRecent.Text = "Number of recent files to keep:";
            // 
            // nudRecentFiles
            // 
            this.nudRecentFiles.Location = new System.Drawing.Point(247, 10);
            this.nudRecentFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudRecentFiles.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudRecentFiles.Name = "nudRecentFiles";
            this.nudRecentFiles.Size = new System.Drawing.Size(73, 23);
            this.nudRecentFiles.TabIndex = 2;
            this.nudRecentFiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xtraTabPageResources
            // 
            this.xtraTabPageResources.AutoScroll = true;
            this.xtraTabPageResources.Controls.Add(this.labelControl5);
            this.xtraTabPageResources.Controls.Add(this.nudIdleTime);
            this.xtraTabPageResources.Controls.Add(this.toggleSwitchIdleMode);
            this.xtraTabPageResources.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPageResources.ImageOptions.Image")));
            this.xtraTabPageResources.Name = "xtraTabPageResources";
            this.xtraTabPageResources.Size = new System.Drawing.Size(817, 924);
            this.xtraTabPageResources.Text = "Resources Usage";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(16, 52);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(208, 16);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Idle time (in minutes) of no activity :";
            // 
            // nudIdleTime
            // 
            this.nudIdleTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudIdleTime.Location = new System.Drawing.Point(410, 52);
            this.nudIdleTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudIdleTime.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudIdleTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIdleTime.Name = "nudIdleTime";
            this.nudIdleTime.Size = new System.Drawing.Size(271, 23);
            this.nudIdleTime.TabIndex = 7;
            this.nudIdleTime.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudIdleTime.ValueChanged += new System.EventHandler(this.NudIdleTime_ValueChanged);
            // 
            // toggleSwitchIdleMode
            // 
            this.toggleSwitchIdleMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleSwitchIdleMode.Location = new System.Drawing.Point(16, 10);
            this.toggleSwitchIdleMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toggleSwitchIdleMode.Name = "toggleSwitchIdleMode";
            this.toggleSwitchIdleMode.Properties.OffText = "don\'t enable idle mode";
            this.toggleSwitchIdleMode.Properties.OnText = "Idle mode: ignore incoming messages when user is idle";
            this.toggleSwitchIdleMode.Size = new System.Drawing.Size(709, 28);
            this.toggleSwitchIdleMode.TabIndex = 6;
            this.toggleSwitchIdleMode.Toggled += new System.EventHandler(this.ToggleSwitchIdleMode_Toggled);
            // 
            // xtraTabPageDataProviders
            // 
            this.xtraTabPageDataProviders.AutoScroll = true;
            this.xtraTabPageDataProviders.Controls.Add(this.xtraTabControlDataProviderSettings);
            this.xtraTabPageDataProviders.ImageOptions.Image = global::Analogy.Properties.Resources.Analogy_Icon2;
            this.xtraTabPageDataProviders.Name = "xtraTabPageDataProviders";
            this.xtraTabPageDataProviders.Size = new System.Drawing.Size(817, 924);
            this.xtraTabPageDataProviders.Text = "Data Providers";
            // 
            // xtraTabControlDataProviderSettings
            // 
            this.xtraTabControlDataProviderSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlDataProviderSettings.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlDataProviderSettings.Name = "xtraTabControlDataProviderSettings";
            this.xtraTabControlDataProviderSettings.SelectedTabPage = this.xtraTabPageDataProvidersOrder;
            this.xtraTabControlDataProviderSettings.Size = new System.Drawing.Size(817, 924);
            this.xtraTabControlDataProviderSettings.TabIndex = 10;
            this.xtraTabControlDataProviderSettings.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageDataProvidersOrder,
            this.xtraTabPageDataProvidersRealTime,
            this.xtraTabPageDataProviderAssociation,
            this.xtraTabPageDataProvidersCustom,
            this.xtpExternalLocations});
            // 
            // xtraTabPageDataProvidersOrder
            // 
            this.xtraTabPageDataProvidersOrder.Controls.Add(this.splitContainerControlDataProviders);
            this.xtraTabPageDataProvidersOrder.Name = "xtraTabPageDataProvidersOrder";
            this.xtraTabPageDataProvidersOrder.Size = new System.Drawing.Size(810, 890);
            this.xtraTabPageDataProvidersOrder.Text = "Data Providers Enable/Disable";
            // 
            // splitContainerControlDataProviders
            // 
            this.splitContainerControlDataProviders.Collapsed = true;
            this.splitContainerControlDataProviders.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitContainerControlDataProviders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControlDataProviders.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlDataProviders.Name = "splitContainerControlDataProviders";
            this.splitContainerControlDataProviders.Panel1.Controls.Add(this.splitContainerControlDataProvidersButtons);
            this.splitContainerControlDataProviders.Panel1.Text = "Panel1";
            this.splitContainerControlDataProviders.Panel2.Controls.Add(this.chkLstDataProviderStatus);
            this.splitContainerControlDataProviders.Panel2.Controls.Add(this.labelControl7);
            this.splitContainerControlDataProviders.Panel2.Controls.Add(this.tsRememberLastOpenedDataProvider);
            this.splitContainerControlDataProviders.Panel2.Text = "Panel2";
            this.splitContainerControlDataProviders.Size = new System.Drawing.Size(810, 890);
            this.splitContainerControlDataProviders.SplitterPosition = 46;
            this.splitContainerControlDataProviders.TabIndex = 14;
            // 
            // splitContainerControlDataProvidersButtons
            // 
            this.splitContainerControlDataProvidersButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainerControlDataProvidersButtons.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControlDataProvidersButtons.Horizontal = false;
            this.splitContainerControlDataProvidersButtons.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControlDataProvidersButtons.Name = "splitContainerControlDataProvidersButtons";
            this.splitContainerControlDataProvidersButtons.Panel1.Controls.Add(this.sBtnMoveUp);
            this.splitContainerControlDataProvidersButtons.Panel1.Text = "Panel1";
            this.splitContainerControlDataProvidersButtons.Panel2.Controls.Add(this.sBtnMoveDown);
            this.splitContainerControlDataProvidersButtons.Panel2.Text = "Panel2";
            this.splitContainerControlDataProvidersButtons.Size = new System.Drawing.Size(46, 0);
            this.splitContainerControlDataProvidersButtons.SplitterPosition = 0;
            this.splitContainerControlDataProvidersButtons.TabIndex = 2;
            // 
            // sBtnMoveUp
            // 
            this.sBtnMoveUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sBtnMoveUp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sBtnMoveUp.ImageOptions.Image")));
            this.sBtnMoveUp.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.sBtnMoveUp.Location = new System.Drawing.Point(0, 0);
            this.sBtnMoveUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnMoveUp.Name = "sBtnMoveUp";
            this.sBtnMoveUp.Size = new System.Drawing.Size(0, 0);
            this.sBtnMoveUp.TabIndex = 2;
            this.sBtnMoveUp.Text = "Up";
            this.sBtnMoveUp.Click += new System.EventHandler(this.sBtnMoveUp_Click);
            // 
            // sBtnMoveDown
            // 
            this.sBtnMoveDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sBtnMoveDown.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sBtnMoveDown.ImageOptions.Image")));
            this.sBtnMoveDown.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomLeft;
            this.sBtnMoveDown.Location = new System.Drawing.Point(0, 0);
            this.sBtnMoveDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnMoveDown.Name = "sBtnMoveDown";
            this.sBtnMoveDown.Size = new System.Drawing.Size(0, 0);
            this.sBtnMoveDown.TabIndex = 3;
            this.sBtnMoveDown.Text = "Down";
            this.sBtnMoveDown.Click += new System.EventHandler(this.sBtnMoveDown_Click);
            // 
            // chkLstDataProviderStatus
            // 
            this.chkLstDataProviderStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLstDataProviderStatus.ItemHeight = 62;
            this.chkLstDataProviderStatus.Location = new System.Drawing.Point(0, 64);
            this.chkLstDataProviderStatus.Name = "chkLstDataProviderStatus";
            this.chkLstDataProviderStatus.Size = new System.Drawing.Size(804, 826);
            this.chkLstDataProviderStatus.TabIndex = 12;
            // 
            // labelControl7
            // 
            this.labelControl7.AutoEllipsis = true;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl7.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl7.Location = new System.Drawing.Point(0, 28);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Padding = new System.Windows.Forms.Padding(3, 10, 10, 10);
            this.labelControl7.Size = new System.Drawing.Size(804, 36);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "Status (enable/ disabled) of data providers. Re-enabling  a provider will take af" +
    "fect after restarting of the application";
            // 
            // tsRememberLastOpenedDataProvider
            // 
            this.tsRememberLastOpenedDataProvider.Dock = System.Windows.Forms.DockStyle.Top;
            this.tsRememberLastOpenedDataProvider.Location = new System.Drawing.Point(0, 0);
            this.tsRememberLastOpenedDataProvider.Margin = new System.Windows.Forms.Padding(5);
            this.tsRememberLastOpenedDataProvider.Name = "tsRememberLastOpenedDataProvider";
            this.tsRememberLastOpenedDataProvider.Properties.OffText = "Don\'t remember last opened Data provider on startup";
            this.tsRememberLastOpenedDataProvider.Properties.OnText = "Remember last opened Data provider on startup and switch to it after restart";
            this.tsRememberLastOpenedDataProvider.Size = new System.Drawing.Size(804, 28);
            this.tsRememberLastOpenedDataProvider.TabIndex = 11;
            // 
            // xtraTabPageDataProvidersRealTime
            // 
            this.xtraTabPageDataProvidersRealTime.Controls.Add(this.chkLstItemRealTimeDataSources);
            this.xtraTabPageDataProvidersRealTime.Controls.Add(this.labelControl6);
            this.xtraTabPageDataProvidersRealTime.Name = "xtraTabPageDataProvidersRealTime";
            this.xtraTabPageDataProvidersRealTime.Size = new System.Drawing.Size(810, 890);
            this.xtraTabPageDataProvidersRealTime.Text = "Real time Auto-Startup";
            // 
            // chkLstItemRealTimeDataSources
            // 
            this.chkLstItemRealTimeDataSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLstItemRealTimeDataSources.Location = new System.Drawing.Point(0, 36);
            this.chkLstItemRealTimeDataSources.Name = "chkLstItemRealTimeDataSources";
            this.chkLstItemRealTimeDataSources.Size = new System.Drawing.Size(810, 854);
            this.chkLstItemRealTimeDataSources.TabIndex = 10;
            // 
            // labelControl6
            // 
            this.labelControl6.AutoEllipsis = true;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl6.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl6.Location = new System.Drawing.Point(0, 0);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Padding = new System.Windows.Forms.Padding(10);
            this.labelControl6.Size = new System.Drawing.Size(810, 36);
            this.labelControl6.TabIndex = 9;
            this.labelControl6.Text = "Load the following real time data sources at startup:";
            // 
            // xtraTabPageDataProviderAssociation
            // 
            this.xtraTabPageDataProviderAssociation.Controls.Add(this.cbDataProviderAssociation);
            this.xtraTabPageDataProviderAssociation.Controls.Add(this.txtbDataProviderAssociation);
            this.xtraTabPageDataProviderAssociation.Controls.Add(this.btnSetFileAssociation);
            this.xtraTabPageDataProviderAssociation.Controls.Add(this.labelControl8);
            this.xtraTabPageDataProviderAssociation.Name = "xtraTabPageDataProviderAssociation";
            this.xtraTabPageDataProviderAssociation.Size = new System.Drawing.Size(810, 890);
            this.xtraTabPageDataProviderAssociation.Text = "Default File Associations";
            // 
            // cbDataProviderAssociation
            // 
            this.cbDataProviderAssociation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDataProviderAssociation.Location = new System.Drawing.Point(15, 12);
            this.cbDataProviderAssociation.Name = "cbDataProviderAssociation";
            this.cbDataProviderAssociation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDataProviderAssociation.Size = new System.Drawing.Size(713, 22);
            this.cbDataProviderAssociation.TabIndex = 8;
            this.cbDataProviderAssociation.EditValueChanged += new System.EventHandler(this.cbDataProviderAssociation_SelectedIndexChanged);
            // 
            // txtbDataProviderAssociation
            // 
            this.txtbDataProviderAssociation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbDataProviderAssociation.Location = new System.Drawing.Point(318, 54);
            this.txtbDataProviderAssociation.Name = "txtbDataProviderAssociation";
            this.txtbDataProviderAssociation.Size = new System.Drawing.Size(410, 22);
            this.txtbDataProviderAssociation.TabIndex = 6;
            // 
            // btnSetFileAssociation
            // 
            this.btnSetFileAssociation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetFileAssociation.Location = new System.Drawing.Point(753, 53);
            this.btnSetFileAssociation.Name = "btnSetFileAssociation";
            this.btnSetFileAssociation.Size = new System.Drawing.Size(47, 23);
            this.btnSetFileAssociation.TabIndex = 3;
            this.btnSetFileAssociation.Text = "set";
            this.btnSetFileAssociation.Click += new System.EventHandler(this.btnSetFileAssociation_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(15, 57);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(282, 16);
            this.labelControl8.TabIndex = 2;
            this.labelControl8.Text = "File Types (use , as seperator. e.g: *.nlog,*.txt):";
            // 
            // xtraTabPageDataProvidersCustom
            // 
            this.xtraTabPageDataProvidersCustom.Controls.Add(this.btnDataProviderCustomSettings);
            this.xtraTabPageDataProvidersCustom.Name = "xtraTabPageDataProvidersCustom";
            this.xtraTabPageDataProvidersCustom.Size = new System.Drawing.Size(810, 890);
            this.xtraTabPageDataProvidersCustom.Text = "Custom Settings";
            // 
            // btnDataProviderCustomSettings
            // 
            this.btnDataProviderCustomSettings.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDataProviderCustomSettings.Location = new System.Drawing.Point(232, 3);
            this.btnDataProviderCustomSettings.Name = "btnDataProviderCustomSettings";
            this.btnDataProviderCustomSettings.Size = new System.Drawing.Size(304, 29);
            this.btnDataProviderCustomSettings.TabIndex = 0;
            this.btnDataProviderCustomSettings.Text = "Open Data Providers custom settings";
            this.btnDataProviderCustomSettings.Click += new System.EventHandler(this.btnDataProviderCustomSettings_Click);
            // 
            // xtpExternalLocations
            // 
            this.xtpExternalLocations.Controls.Add(this.lblAssemblies);
            this.xtpExternalLocations.Controls.Add(this.sbtnDeleteFolderProbing);
            this.xtpExternalLocations.Controls.Add(this.lblFoldersProbing);
            this.xtpExternalLocations.Controls.Add(this.teFoldersProbing);
            this.xtpExternalLocations.Controls.Add(this.sbtnFolderProbingBrowse);
            this.xtpExternalLocations.Controls.Add(this.listBoxFoldersProbing);
            this.xtpExternalLocations.Controls.Add(this.sbtnFolderProbingAdd);
            this.xtpExternalLocations.Name = "xtpExternalLocations";
            this.xtpExternalLocations.Size = new System.Drawing.Size(810, 890);
            this.xtpExternalLocations.Text = "External Locations";
            // 
            // lblAssemblies
            // 
            this.lblAssemblies.AutoEllipsis = true;
            this.lblAssemblies.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblAssemblies.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAssemblies.Location = new System.Drawing.Point(0, 0);
            this.lblAssemblies.Name = "lblAssemblies";
            this.lblAssemblies.Padding = new System.Windows.Forms.Padding(5);
            this.lblAssemblies.Size = new System.Drawing.Size(810, 42);
            this.lblAssemblies.TabIndex = 10;
            this.lblAssemblies.Text = "Any Analogy.LogViewer.*.dll that is placed at the same folder as the application " +
    "will be loaded. You can specify aditional folders below (a restart is needed for" +
    " the changes to take affect):";
            // 
            // sbtnDeleteFolderProbing
            // 
            this.sbtnDeleteFolderProbing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnDeleteFolderProbing.Location = new System.Drawing.Point(747, 64);
            this.sbtnDeleteFolderProbing.Name = "sbtnDeleteFolderProbing";
            this.sbtnDeleteFolderProbing.Size = new System.Drawing.Size(56, 27);
            this.sbtnDeleteFolderProbing.TabIndex = 9;
            this.sbtnDeleteFolderProbing.Text = "Delete";
            this.sbtnDeleteFolderProbing.Click += new System.EventHandler(this.btnDeleteFolderProbing_Click);
            // 
            // lblFoldersProbing
            // 
            this.lblFoldersProbing.Location = new System.Drawing.Point(11, 46);
            this.lblFoldersProbing.Name = "lblFoldersProbing";
            this.lblFoldersProbing.Size = new System.Drawing.Size(270, 16);
            this.lblFoldersProbing.TabIndex = 7;
            this.lblFoldersProbing.Text = "Additional Folders for Data Providers asseblies:";
            // 
            // teFoldersProbing
            // 
            this.teFoldersProbing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teFoldersProbing.Location = new System.Drawing.Point(14, 67);
            this.teFoldersProbing.Name = "teFoldersProbing";
            this.teFoldersProbing.Size = new System.Drawing.Size(596, 22);
            this.teFoldersProbing.TabIndex = 6;
            // 
            // sbtnFolderProbingBrowse
            // 
            this.sbtnFolderProbingBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnFolderProbingBrowse.Location = new System.Drawing.Point(615, 64);
            this.sbtnFolderProbingBrowse.Name = "sbtnFolderProbingBrowse";
            this.sbtnFolderProbingBrowse.Size = new System.Drawing.Size(36, 27);
            this.sbtnFolderProbingBrowse.TabIndex = 8;
            this.sbtnFolderProbingBrowse.Text = "...";
            this.sbtnFolderProbingBrowse.Click += new System.EventHandler(this.btnFolderProbingBrowse_Click);
            // 
            // listBoxFoldersProbing
            // 
            this.listBoxFoldersProbing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFoldersProbing.Location = new System.Drawing.Point(11, 95);
            this.listBoxFoldersProbing.Name = "listBoxFoldersProbing";
            this.listBoxFoldersProbing.Size = new System.Drawing.Size(792, 782);
            this.listBoxFoldersProbing.TabIndex = 2;
            // 
            // sbtnFolderProbingAdd
            // 
            this.sbtnFolderProbingAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnFolderProbingAdd.Location = new System.Drawing.Point(654, 64);
            this.sbtnFolderProbingAdd.Name = "sbtnFolderProbingAdd";
            this.sbtnFolderProbingAdd.Size = new System.Drawing.Size(56, 27);
            this.sbtnFolderProbingAdd.TabIndex = 8;
            this.sbtnFolderProbingAdd.Text = "Add";
            this.sbtnFolderProbingAdd.Click += new System.EventHandler(this.btnFolderProbingAdd_Click);
            // 
            // xtraTabPageExtension
            // 
            this.xtraTabPageExtension.Controls.Add(this.chkLstItemExtensions);
            this.xtraTabPageExtension.Controls.Add(this.labelControl12);
            this.xtraTabPageExtension.ImageOptions.Image = global::Analogy.Properties.Resources.extension32;
            this.xtraTabPageExtension.Name = "xtraTabPageExtension";
            this.xtraTabPageExtension.Size = new System.Drawing.Size(817, 924);
            this.xtraTabPageExtension.Text = "Extensions";
            // 
            // chkLstItemExtensions
            // 
            this.chkLstItemExtensions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLstItemExtensions.Location = new System.Drawing.Point(0, 36);
            this.chkLstItemExtensions.Name = "chkLstItemExtensions";
            this.chkLstItemExtensions.Size = new System.Drawing.Size(817, 888);
            this.chkLstItemExtensions.TabIndex = 12;
            // 
            // labelControl12
            // 
            this.labelControl12.AutoEllipsis = true;
            this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl12.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl12.Location = new System.Drawing.Point(0, 0);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Padding = new System.Windows.Forms.Padding(10);
            this.labelControl12.Size = new System.Drawing.Size(817, 36);
            this.labelControl12.TabIndex = 11;
            this.labelControl12.Text = "Load the following Extensions:";
            // 
            // xtraTabPageUpdates
            // 
            this.xtraTabPageUpdates.AutoScroll = true;
            this.xtraTabPageUpdates.Controls.Add(this.gcIntervals);
            this.xtraTabPageUpdates.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPageUpdates.ImageOptions.Image")));
            this.xtraTabPageUpdates.Name = "xtraTabPageUpdates";
            this.xtraTabPageUpdates.Size = new System.Drawing.Size(817, 924);
            this.xtraTabPageUpdates.Text = "Updates";
            // 
            // gcIntervals
            // 
            this.gcIntervals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcIntervals.Controls.Add(this.lblDisableUpdates);
            this.gcIntervals.Controls.Add(this.cbUpdates);
            this.gcIntervals.Controls.Add(this.lblUpdates);
            this.gcIntervals.Location = new System.Drawing.Point(5, 10);
            this.gcIntervals.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcIntervals.Name = "gcIntervals";
            this.gcIntervals.Size = new System.Drawing.Size(781, 132);
            this.gcIntervals.TabIndex = 6;
            this.gcIntervals.Text = "General";
            // 
            // lblDisableUpdates
            // 
            this.lblDisableUpdates.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblDisableUpdates.Appearance.Options.UseForeColor = true;
            this.lblDisableUpdates.Location = new System.Drawing.Point(5, 69);
            this.lblDisableUpdates.Name = "lblDisableUpdates";
            this.lblDisableUpdates.Size = new System.Drawing.Size(297, 16);
            this.lblDisableUpdates.TabIndex = 14;
            this.lblDisableUpdates.Text = "Updates are disabled due to data provider overrides";
            this.lblDisableUpdates.Visible = false;
            // 
            // cbUpdates
            // 
            this.cbUpdates.Location = new System.Drawing.Point(322, 35);
            this.cbUpdates.Name = "cbUpdates";
            this.cbUpdates.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUpdates.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbUpdates.Size = new System.Drawing.Size(198, 22);
            this.cbUpdates.TabIndex = 13;
            // 
            // lblUpdates
            // 
            this.lblUpdates.Location = new System.Drawing.Point(5, 38);
            this.lblUpdates.Name = "lblUpdates";
            this.lblUpdates.Size = new System.Drawing.Size(235, 16);
            this.lblUpdates.TabIndex = 12;
            this.lblUpdates.Text = "Choose interval for checking for updates:";
            // 
            // xtraTabPageDebugging
            // 
            this.xtraTabPageDebugging.Controls.Add(this.tsEnableFirstChanceException);
            this.xtraTabPageDebugging.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPageDebugging.ImageOptions.Image")));
            this.xtraTabPageDebugging.Name = "xtraTabPageDebugging";
            this.xtraTabPageDebugging.Size = new System.Drawing.Size(817, 924);
            this.xtraTabPageDebugging.Text = "Debugging";
            // 
            // tsEnableFirstChanceException
            // 
            this.tsEnableFirstChanceException.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsEnableFirstChanceException.EditValue = true;
            this.tsEnableFirstChanceException.Location = new System.Drawing.Point(17, 10);
            this.tsEnableFirstChanceException.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsEnableFirstChanceException.Name = "tsEnableFirstChanceException";
            this.tsEnableFirstChanceException.Properties.OffText = "First Chance Exception logging is disabled";
            this.tsEnableFirstChanceException.Properties.OnText = "First Chance Exception logging is enabled";
            this.tsEnableFirstChanceException.Size = new System.Drawing.Size(767, 28);
            this.tsEnableFirstChanceException.TabIndex = 3;
            // 
            // UserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 932);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserSettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserSettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.UserSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.xtraTabPagePreDefined.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlQueries)).EndInit();
            this.xtraTabControlQueries.ResumeLayout(false);
            this.xtraTabPageColorHighlight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lboxHighlightItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHighlight)).EndInit();
            this.gcHighlight.ResumeLayout(false);
            this.gcHighlight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpeHighlightPreDefined.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHighlightEquals.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHighlightContains.Properties)).EndInit();
            this.xtraTabPageFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lboxFilters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbSourcesFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbModulesFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbExcludeFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbIncludeTextFilter.Properties)).EndInit();
            this.xtraTabPageAlerts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lboxAlerts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbSourcesAlert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbModulesAlert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbExcludeAlert.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbIncludeTextAlert.Properties)).EndInit();
            this.tpColors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teDateTimeFormat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlMessages)).EndInit();
            this.panelControlMessages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHeader.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcColors)).EndInit();
            this.gcColors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpeNewMessagesColorText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeHighlightColorText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsEnableColors.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceOverrideLogLevelColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelAnalogyInformationText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelCriticalText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelErrorText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelWarningText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelEventText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelDebugText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelVerboseText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelTraceText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelDisabledText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelUnknownText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelAnalogyInformation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelCritical.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelError.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelWarning.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelEvent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelDebug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelVerbose.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelTrace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelDisabled.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeLogLevelUnknown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceNewMessagesColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeNewMessagesColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpeHighlightColor.Properties)).EndInit();
            this.xtShortcuts.ResumeLayout(false);
            this.xtShortcuts.PerformLayout();
            this.xTabMRU.ResumeLayout(false);
            this.xTabMRU.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecentFolders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecentFiles)).EndInit();
            this.xtraTabPageResources.ResumeLayout(false);
            this.xtraTabPageResources.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdleTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitchIdleMode.Properties)).EndInit();
            this.xtraTabPageDataProviders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlDataProviderSettings)).EndInit();
            this.xtraTabControlDataProviderSettings.ResumeLayout(false);
            this.xtraTabPageDataProvidersOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlDataProviders)).EndInit();
            this.splitContainerControlDataProviders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControlDataProvidersButtons)).EndInit();
            this.splitContainerControlDataProvidersButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkLstDataProviderStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsRememberLastOpenedDataProvider.Properties)).EndInit();
            this.xtraTabPageDataProvidersRealTime.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkLstItemRealTimeDataSources)).EndInit();
            this.xtraTabPageDataProviderAssociation.ResumeLayout(false);
            this.xtraTabPageDataProviderAssociation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDataProviderAssociation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDataProviderAssociation.Properties)).EndInit();
            this.xtraTabPageDataProvidersCustom.ResumeLayout(false);
            this.xtpExternalLocations.ResumeLayout(false);
            this.xtpExternalLocations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teFoldersProbing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxFoldersProbing)).EndInit();
            this.xtraTabPageExtension.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkLstItemExtensions)).EndInit();
            this.xtraTabPageUpdates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcIntervals)).EndInit();
            this.gcIntervals.ResumeLayout(false);
            this.gcIntervals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbUpdates.Properties)).EndInit();
            this.xtraTabPageDebugging.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tsEnableFirstChanceException.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabControlMain;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageFilter;
        private DevExpress.XtraTab.XtraTabPage xtraTabPagePreDefined;
        private DevExpress.XtraEditors.LabelControl lblRecent;
        private System.Windows.Forms.NumericUpDown nudRecentFiles;
        private DevExpress.XtraTab.XtraTabPage tpColors;
        private DevExpress.XtraTab.XtraTabPage xtShortcuts;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraTab.XtraTabPage xTabMRU;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageResources;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.NumericUpDown nudIdleTime;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitchIdleMode;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDataProviders;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelUnknown;
        private DevExpress.XtraEditors.LabelControl lblLogLevelUnknown;
        private DevExpress.XtraEditors.LabelControl lblLogLevelAnalogyInformation;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelAnalogyInformation;
        private DevExpress.XtraEditors.LabelControl lblLogLevelCritical;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelCritical;
        private DevExpress.XtraEditors.LabelControl lblLogLevelError;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelError;
        private DevExpress.XtraEditors.LabelControl lblLogLevelWarning;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelWarning;
        private DevExpress.XtraEditors.LabelControl lblLogLevelEvent;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelEvent;
        private DevExpress.XtraEditors.LabelControl lblLogLevelDebug;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelDebug;
        private DevExpress.XtraEditors.LabelControl lblLogLevelVerbose;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelVerbose;
        private DevExpress.XtraEditors.LabelControl lblLogLevelTrace;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelTrace;
        private DevExpress.XtraEditors.LabelControl lblLogLevelDisabled;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelDisabled;
        private DevExpress.XtraEditors.LabelControl lblHighlightColor;
        private DevExpress.XtraEditors.ColorPickEdit cpeHighlightColor;
        private DevExpress.XtraEditors.SimpleButton sBtnImportColors;
        private DevExpress.XtraEditors.SimpleButton sBtnExportColors;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlDataProviderSettings;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDataProvidersRealTime;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDataProvidersOrder;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlDataProviders;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControlDataProvidersButtons;
        private DevExpress.XtraEditors.SimpleButton sBtnMoveUp;
        private DevExpress.XtraEditors.SimpleButton sBtnMoveDown;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDataProvidersCustom;
        private DevExpress.XtraEditors.SimpleButton btnDataProviderCustomSettings;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDataProviderAssociation;
        private DevExpress.XtraEditors.SimpleButton btnSetFileAssociation;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ToggleSwitch tsRememberLastOpenedDataProvider;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlQueries;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageColorHighlight;
        private DevExpress.XtraEditors.GroupControl gcHighlight;
        private DevExpress.XtraEditors.TextEdit teHighlightEquals;
        private DevExpress.XtraEditors.TextEdit teHighlightContains;
        private System.Windows.Forms.RadioButton rbtnHighlightEquals;
        private System.Windows.Forms.RadioButton rbtnHighlightContains;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageFilters;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageAlerts;
        private DevExpress.XtraEditors.SimpleButton sbtnDeleteHighlight;
        private DevExpress.XtraEditors.ListBoxControl lboxHighlightItems;
        private DevExpress.XtraEditors.SimpleButton sbtnAddHighlight;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.ColorPickEdit cpeHighlightPreDefined;
        private DevExpress.XtraEditors.TextEdit txtbSourcesFilter;
        private DevExpress.XtraEditors.TextEdit txtbModulesFilter;
        private DevExpress.XtraEditors.TextEdit txtbExcludeFilter;
        private DevExpress.XtraEditors.TextEdit txtbIncludeTextFilter;
        private DevExpress.XtraEditors.SimpleButton sbtnDeleteFilter;
        private DevExpress.XtraEditors.ListBoxControl lboxFilters;
        private DevExpress.XtraEditors.SimpleButton sbtnAddFilter;
        private System.Windows.Forms.Label lblExplaination;
        private System.Windows.Forms.Label lblModules;
        private System.Windows.Forms.Label lblSources;
        private System.Windows.Forms.Label lblExcludeMessageText;
        private System.Windows.Forms.Label lblIncludeText;
        private DevExpress.XtraEditors.SimpleButton sbtnDeleteAlerts;
        private DevExpress.XtraEditors.ListBoxControl lboxAlerts;
        private DevExpress.XtraEditors.SimpleButton sbtnAddAlerts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtbSourcesAlert;
        private DevExpress.XtraEditors.TextEdit txtbModulesAlert;
        private DevExpress.XtraEditors.TextEdit txtbExcludeAlert;
        private DevExpress.XtraEditors.TextEdit txtbIncludeTextAlert;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.ListBoxControl listBoxFoldersProbing;
        private DevExpress.XtraEditors.SimpleButton sbtnDeleteFolderProbing;
        private DevExpress.XtraEditors.SimpleButton sbtnFolderProbingAdd;
        private DevExpress.XtraEditors.LabelControl lblFoldersProbing;
        private DevExpress.XtraEditors.TextEdit teFoldersProbing;
        private DevExpress.XtraEditors.SimpleButton sbtnFolderProbingBrowse;
        private DevExpress.XtraTab.XtraTabPage xtpExternalLocations;
        private DevExpress.XtraEditors.LabelControl lblAssemblies;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageApplication;
        private DevExpress.XtraEditors.PanelControl panelControlMessages;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView logGrid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDataSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTimeDiff;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnText;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnClass;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModule;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnObject;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProcessID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnThread;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraEditors.SimpleButton sbtnHeaderSet;
        private DevExpress.XtraEditors.TextEdit teHeader;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.SimpleButton sbtnDateTimeFormat;
        private DevExpress.XtraEditors.TextEdit teDateTimeFormat;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageUpdates;
        private DevExpress.XtraEditors.GroupControl gcIntervals;
        private DevExpress.XtraEditors.LabelControl lblUpdates;
        private DevExpress.XtraEditors.ComboBoxEdit cbUpdates;
        private DevExpress.XtraEditors.ColorPickEdit cpeNewMessagesColor;
        private DevExpress.XtraEditors.CheckEdit ceNewMessagesColor;
        private DevExpress.XtraEditors.CheckEdit ceOverrideLogLevelColor;
        private DevExpress.XtraEditors.LabelControl lblRecentFolders;
        private System.Windows.Forms.NumericUpDown nudRecentFolders;
        private DevExpress.XtraEditors.ToggleSwitch tsEnableColors;
        private DevExpress.XtraEditors.LabelControl lblLogLevelRowTextColor;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelAnalogyInformationText;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelCriticalText;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelErrorText;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelWarningText;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelEventText;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelDebugText;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelVerboseText;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelTraceText;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelDisabledText;
        private DevExpress.XtraEditors.ColorPickEdit cpeLogLevelUnknownText;
        private DevExpress.XtraEditors.LabelControl lblLogLevelBackground;
        private DevExpress.XtraEditors.ColorPickEdit cpeNewMessagesColorText;
        private DevExpress.XtraEditors.ColorPickEdit cpeHighlightColorText;
        private DevExpress.XtraEditors.CheckedListBoxControl chkLstDataProviderStatus;
        private DevExpress.XtraEditors.CheckedListBoxControl chkLstItemRealTimeDataSources;
        private DevExpress.XtraEditors.TextEdit txtbDataProviderAssociation;
        private DevExpress.XtraEditors.LookUpEdit cbDataProviderAssociation;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDebugging;
        private DevExpress.XtraEditors.ToggleSwitch tsEnableFirstChanceException;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageExtension;
        private DevExpress.XtraEditors.CheckedListBoxControl chkLstItemExtensions;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl lblDisableUpdates;
        private DevExpress.XtraEditors.GroupControl gcColors;
    }
}