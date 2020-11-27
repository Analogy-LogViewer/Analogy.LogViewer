using DevExpress.XtraGrid.Views.Base;

namespace Philips.Analogy
{
    partial class LogStatisticsUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spltCTop = new System.Windows.Forms.SplitContainer();
            this.gridControlGlobal = new DevExpress.XtraGrid.GridControl();
            this.gridViewGlobal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnGlobalName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControlBottom = new System.Windows.Forms.TabControl();
            this.tabPageSources = new System.Windows.Forms.TabPage();
            this.spltcSources = new System.Windows.Forms.SplitContainer();
            this.GridControlSource = new DevExpress.XtraGrid.GridControl();
            this.logGridSource = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMessagesCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevelCritical = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevelError = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevelWarning = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevelInformation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevelDebug = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevelVerbose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevelTrace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPageModules = new System.Windows.Forms.TabPage();
            this.spltcModules = new System.Windows.Forms.SplitContainer();
            this.gridControlModules = new DevExpress.XtraGrid.GridControl();
            this.gridModules = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPageGlobal = new System.Windows.Forms.TabPage();
            this.tabPageFreeText = new System.Windows.Forms.TabPage();
            this.spltCFreeText = new System.Windows.Forms.SplitContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.chklistItems = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControlFreeText = new DevExpress.XtraGrid.GridControl();
            this.gridViewFreeText = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.spltCTop)).BeginInit();
            this.spltCTop.Panel1.SuspendLayout();
            this.spltCTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGlobal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGlobal)).BeginInit();
            this.tabControlBottom.SuspendLayout();
            this.tabPageSources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltcSources)).BeginInit();
            this.spltcSources.Panel1.SuspendLayout();
            this.spltcSources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logGridSource)).BeginInit();
            this.tabPageModules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltcModules)).BeginInit();
            this.spltcModules.Panel1.SuspendLayout();
            this.spltcModules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlModules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridModules)).BeginInit();
            this.tabPageGlobal.SuspendLayout();
            this.tabPageFreeText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltCFreeText)).BeginInit();
            this.spltCFreeText.Panel1.SuspendLayout();
            this.spltCFreeText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chklistItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFreeText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFreeText)).BeginInit();
            this.SuspendLayout();
            // 
            // spltCTop
            // 
            this.spltCTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltCTop.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltCTop.Location = new System.Drawing.Point(3, 3);
            this.spltCTop.Name = "spltCTop";
            // 
            // spltCTop.Panel1
            // 
            this.spltCTop.Panel1.Controls.Add(this.gridControlGlobal);
            this.spltCTop.Size = new System.Drawing.Size(962, 411);
            this.spltCTop.SplitterDistance = 357;
            this.spltCTop.TabIndex = 0;
            // 
            // gridControlGlobal
            // 
            this.gridControlGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlGlobal.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlGlobal.Location = new System.Drawing.Point(0, 0);
            this.gridControlGlobal.MainView = this.gridViewGlobal;
            this.gridControlGlobal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlGlobal.Name = "gridControlGlobal";
            this.gridControlGlobal.Size = new System.Drawing.Size(357, 411);
            this.gridControlGlobal.TabIndex = 3;
            this.gridControlGlobal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewGlobal});
            // 
            // gridViewGlobal
            // 
            this.gridViewGlobal.Appearance.Row.Options.UseTextOptions = true;
            this.gridViewGlobal.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridViewGlobal.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridViewGlobal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridViewGlobal.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnGlobalName,
            this.gridColumnValue});
            this.gridViewGlobal.DetailHeight = 431;
            this.gridViewGlobal.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewGlobal.GridControl = this.gridControlGlobal;
            this.gridViewGlobal.IndicatorWidth = 24;
            this.gridViewGlobal.Name = "gridViewGlobal";
            this.gridViewGlobal.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridViewGlobal.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewGlobal.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewGlobal.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridViewGlobal.OptionsLayout.Columns.StoreAppearance = true;
            this.gridViewGlobal.OptionsLayout.StoreAllOptions = true;
            this.gridViewGlobal.OptionsLayout.StoreAppearance = true;
            this.gridViewGlobal.OptionsLayout.StoreFormatRules = true;
            this.gridViewGlobal.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewGlobal.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridViewGlobal.OptionsView.RowAutoHeight = true;
            this.gridViewGlobal.OptionsView.ShowGroupPanel = false;
            this.gridViewGlobal.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewGlobal_FocusedRowChanged);
            // 
            // gridColumnGlobalName
            // 
            this.gridColumnGlobalName.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnGlobalName.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnGlobalName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnGlobalName.Caption = "Name";
            this.gridColumnGlobalName.FieldName = "Name";
            this.gridColumnGlobalName.MinWidth = 50;
            this.gridColumnGlobalName.Name = "gridColumnGlobalName";
            this.gridColumnGlobalName.OptionsColumn.AllowEdit = false;
            this.gridColumnGlobalName.OptionsColumn.AllowFocus = false;
            this.gridColumnGlobalName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnGlobalName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnGlobalName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnGlobalName.OptionsColumn.ReadOnly = true;
            this.gridColumnGlobalName.OptionsFilter.AllowFilter = false;
            this.gridColumnGlobalName.Visible = true;
            this.gridColumnGlobalName.VisibleIndex = 0;
            this.gridColumnGlobalName.Width = 200;
            // 
            // gridColumnValue
            // 
            this.gridColumnValue.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnValue.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnValue.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnValue.Caption = "Count";
            this.gridColumnValue.FieldName = "Value";
            this.gridColumnValue.MinWidth = 100;
            this.gridColumnValue.Name = "gridColumnValue";
            this.gridColumnValue.OptionsColumn.AllowEdit = false;
            this.gridColumnValue.OptionsColumn.AllowFocus = false;
            this.gridColumnValue.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnValue.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnValue.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnValue.OptionsColumn.ReadOnly = true;
            this.gridColumnValue.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnValue.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumnValue.Visible = true;
            this.gridColumnValue.VisibleIndex = 1;
            this.gridColumnValue.Width = 100;
            // 
            // tabControlBottom
            // 
            this.tabControlBottom.Controls.Add(this.tabPageSources);
            this.tabControlBottom.Controls.Add(this.tabPageModules);
            this.tabControlBottom.Controls.Add(this.tabPageGlobal);
            this.tabControlBottom.Controls.Add(this.tabPageFreeText);
            this.tabControlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlBottom.Location = new System.Drawing.Point(0, 0);
            this.tabControlBottom.Name = "tabControlBottom";
            this.tabControlBottom.SelectedIndex = 0;
            this.tabControlBottom.Size = new System.Drawing.Size(976, 446);
            this.tabControlBottom.TabIndex = 0;
            // 
            // tabPageSources
            // 
            this.tabPageSources.Controls.Add(this.spltcSources);
            this.tabPageSources.Location = new System.Drawing.Point(4, 25);
            this.tabPageSources.Name = "tabPageSources";
            this.tabPageSources.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSources.Size = new System.Drawing.Size(968, 417);
            this.tabPageSources.TabIndex = 0;
            this.tabPageSources.Text = "Per Source";
            this.tabPageSources.UseVisualStyleBackColor = true;
            // 
            // spltcSources
            // 
            this.spltcSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltcSources.Location = new System.Drawing.Point(3, 3);
            this.spltcSources.Name = "spltcSources";
            // 
            // spltcSources.Panel1
            // 
            this.spltcSources.Panel1.Controls.Add(this.GridControlSource);
            this.spltcSources.Size = new System.Drawing.Size(962, 411);
            this.spltcSources.SplitterDistance = 478;
            this.spltcSources.TabIndex = 1;
            // 
            // GridControlSource
            // 
            this.GridControlSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControlSource.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GridControlSource.Location = new System.Drawing.Point(0, 0);
            this.GridControlSource.MainView = this.logGridSource;
            this.GridControlSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GridControlSource.Name = "GridControlSource";
            this.GridControlSource.Size = new System.Drawing.Size(478, 411);
            this.GridControlSource.TabIndex = 1;
            this.GridControlSource.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.logGridSource});
            // 
            // logGridSource
            // 
            this.logGridSource.Appearance.Row.Options.UseTextOptions = true;
            this.logGridSource.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.logGridSource.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.logGridSource.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.logGridSource.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnName,
            this.gridColumnMessagesCount,
            this.gridColumnLevelCritical,
            this.gridColumnLevelError,
            this.gridColumnLevelWarning,
            this.gridColumnLevelInformation,
            this.gridColumnLevelDebug,
            this.gridColumnLevelVerbose,
            this.gridColumnLevelTrace});
            this.logGridSource.DetailHeight = 431;
            this.logGridSource.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.logGridSource.GridControl = this.GridControlSource;
            this.logGridSource.IndicatorWidth = 24;
            this.logGridSource.Name = "logGridSource";
            this.logGridSource.OptionsBehavior.AllowIncrementalSearch = true;
            this.logGridSource.OptionsFilter.AllowColumnMRUFilterList = false;
            this.logGridSource.OptionsFilter.AllowMRUFilterList = false;
            this.logGridSource.OptionsLayout.Columns.StoreAllOptions = true;
            this.logGridSource.OptionsLayout.Columns.StoreAppearance = true;
            this.logGridSource.OptionsLayout.StoreAllOptions = true;
            this.logGridSource.OptionsLayout.StoreAppearance = true;
            this.logGridSource.OptionsLayout.StoreFormatRules = true;
            this.logGridSource.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.logGridSource.OptionsView.AutoCalcPreviewLineCount = true;
            this.logGridSource.OptionsView.RowAutoHeight = true;
            this.logGridSource.OptionsView.ShowGroupPanel = false;
            this.logGridSource.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.logGridSource_FocusedRowChanged);
            // 
            // gridColumnName
            // 
            this.gridColumnName.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnName.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnName.Caption = "Name";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.MinWidth = 50;
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.OptionsColumn.AllowEdit = false;
            this.gridColumnName.OptionsColumn.AllowFocus = false;
            this.gridColumnName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnName.OptionsColumn.ReadOnly = true;
            this.gridColumnName.OptionsFilter.AllowFilter = false;
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 0;
            this.gridColumnName.Width = 200;
            // 
            // gridColumnMessagesCount
            // 
            this.gridColumnMessagesCount.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnMessagesCount.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnMessagesCount.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnMessagesCount.Caption = "Messages";
            this.gridColumnMessagesCount.FieldName = "Messages";
            this.gridColumnMessagesCount.MinWidth = 100;
            this.gridColumnMessagesCount.Name = "gridColumnMessagesCount";
            this.gridColumnMessagesCount.OptionsColumn.AllowEdit = false;
            this.gridColumnMessagesCount.OptionsColumn.AllowFocus = false;
            this.gridColumnMessagesCount.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnMessagesCount.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnMessagesCount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnMessagesCount.OptionsColumn.ReadOnly = true;
            this.gridColumnMessagesCount.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnMessagesCount.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumnMessagesCount.Visible = true;
            this.gridColumnMessagesCount.VisibleIndex = 1;
            this.gridColumnMessagesCount.Width = 100;
            // 
            // gridColumnLevelCritical
            // 
            this.gridColumnLevelCritical.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnLevelCritical.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnLevelCritical.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnLevelCritical.Caption = "Critical";
            this.gridColumnLevelCritical.FieldName = "Critical";
            this.gridColumnLevelCritical.MinWidth = 70;
            this.gridColumnLevelCritical.Name = "gridColumnLevelCritical";
            this.gridColumnLevelCritical.OptionsColumn.AllowEdit = false;
            this.gridColumnLevelCritical.OptionsColumn.AllowFocus = false;
            this.gridColumnLevelCritical.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnLevelCritical.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnLevelCritical.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnLevelCritical.OptionsColumn.ReadOnly = true;
            this.gridColumnLevelCritical.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnLevelCritical.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumnLevelCritical.Visible = true;
            this.gridColumnLevelCritical.VisibleIndex = 2;
            this.gridColumnLevelCritical.Width = 70;
            // 
            // gridColumnLevelError
            // 
            this.gridColumnLevelError.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnLevelError.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnLevelError.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnLevelError.Caption = "Error";
            this.gridColumnLevelError.FieldName = "Error";
            this.gridColumnLevelError.MinWidth = 70;
            this.gridColumnLevelError.Name = "gridColumnLevelError";
            this.gridColumnLevelError.OptionsColumn.AllowEdit = false;
            this.gridColumnLevelError.OptionsColumn.AllowFocus = false;
            this.gridColumnLevelError.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnLevelError.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnLevelError.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnLevelError.OptionsColumn.ReadOnly = true;
            this.gridColumnLevelError.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnLevelError.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumnLevelError.Visible = true;
            this.gridColumnLevelError.VisibleIndex = 4;
            this.gridColumnLevelError.Width = 70;
            // 
            // gridColumnLevelWarning
            // 
            this.gridColumnLevelWarning.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnLevelWarning.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnLevelWarning.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnLevelWarning.Caption = "Warning";
            this.gridColumnLevelWarning.FieldName = "Warning";
            this.gridColumnLevelWarning.MinWidth = 70;
            this.gridColumnLevelWarning.Name = "gridColumnLevelWarning";
            this.gridColumnLevelWarning.OptionsColumn.AllowEdit = false;
            this.gridColumnLevelWarning.OptionsColumn.AllowFocus = false;
            this.gridColumnLevelWarning.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnLevelWarning.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnLevelWarning.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnLevelWarning.OptionsColumn.ReadOnly = true;
            this.gridColumnLevelWarning.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumnLevelWarning.Visible = true;
            this.gridColumnLevelWarning.VisibleIndex = 5;
            this.gridColumnLevelWarning.Width = 70;
            // 
            // gridColumnLevelInformation
            // 
            this.gridColumnLevelInformation.Caption = "Information";
            this.gridColumnLevelInformation.FieldName = "Information";
            this.gridColumnLevelInformation.MinWidth = 70;
            this.gridColumnLevelInformation.Name = "gridColumnLevelInformation";
            this.gridColumnLevelInformation.OptionsColumn.AllowEdit = false;
            this.gridColumnLevelInformation.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumnLevelInformation.Visible = true;
            this.gridColumnLevelInformation.VisibleIndex = 8;
            this.gridColumnLevelInformation.Width = 70;
            // 
            // gridColumnLevelDebug
            // 
            this.gridColumnLevelDebug.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnLevelDebug.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnLevelDebug.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnLevelDebug.Caption = "Debug";
            this.gridColumnLevelDebug.FieldName = "Debug";
            this.gridColumnLevelDebug.MinWidth = 70;
            this.gridColumnLevelDebug.Name = "gridColumnLevelDebug";
            this.gridColumnLevelDebug.OptionsColumn.AllowEdit = false;
            this.gridColumnLevelDebug.OptionsColumn.AllowFocus = false;
            this.gridColumnLevelDebug.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnLevelDebug.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnLevelDebug.OptionsColumn.ReadOnly = true;
            this.gridColumnLevelDebug.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnLevelDebug.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumnLevelDebug.Visible = true;
            this.gridColumnLevelDebug.VisibleIndex = 3;
            this.gridColumnLevelDebug.Width = 70;
            // 
            // gridColumnLevelVerbose
            // 
            this.gridColumnLevelVerbose.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnLevelVerbose.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnLevelVerbose.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnLevelVerbose.Caption = "Verbose";
            this.gridColumnLevelVerbose.FieldName = "Verbose";
            this.gridColumnLevelVerbose.MinWidth = 70;
            this.gridColumnLevelVerbose.Name = "gridColumnLevelVerbose";
            this.gridColumnLevelVerbose.OptionsColumn.AllowEdit = false;
            this.gridColumnLevelVerbose.OptionsColumn.AllowFocus = false;
            this.gridColumnLevelVerbose.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnLevelVerbose.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnLevelVerbose.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnLevelVerbose.OptionsColumn.ReadOnly = true;
            this.gridColumnLevelVerbose.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnLevelVerbose.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumnLevelVerbose.Visible = true;
            this.gridColumnLevelVerbose.VisibleIndex = 7;
            this.gridColumnLevelVerbose.Width = 70;
            // 
            // gridColumnLevelTrace
            // 
            this.gridColumnLevelTrace.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnLevelTrace.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnLevelTrace.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnLevelTrace.Caption = "Trace";
            this.gridColumnLevelTrace.FieldName = "Trace";
            this.gridColumnLevelTrace.MinWidth = 70;
            this.gridColumnLevelTrace.Name = "gridColumnLevelTrace";
            this.gridColumnLevelTrace.OptionsColumn.AllowEdit = false;
            this.gridColumnLevelTrace.OptionsColumn.AllowFocus = false;
            this.gridColumnLevelTrace.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnLevelTrace.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnLevelTrace.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnLevelTrace.OptionsColumn.ReadOnly = true;
            this.gridColumnLevelTrace.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumnLevelTrace.Visible = true;
            this.gridColumnLevelTrace.VisibleIndex = 6;
            this.gridColumnLevelTrace.Width = 70;
            // 
            // tabPageModules
            // 
            this.tabPageModules.Controls.Add(this.spltcModules);
            this.tabPageModules.Location = new System.Drawing.Point(4, 25);
            this.tabPageModules.Name = "tabPageModules";
            this.tabPageModules.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageModules.Size = new System.Drawing.Size(968, 417);
            this.tabPageModules.TabIndex = 1;
            this.tabPageModules.Text = "Per Module";
            this.tabPageModules.UseVisualStyleBackColor = true;
            // 
            // spltcModules
            // 
            this.spltcModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltcModules.Location = new System.Drawing.Point(3, 3);
            this.spltcModules.Name = "spltcModules";
            // 
            // spltcModules.Panel1
            // 
            this.spltcModules.Panel1.Controls.Add(this.gridControlModules);
            this.spltcModules.Size = new System.Drawing.Size(962, 411);
            this.spltcModules.SplitterDistance = 478;
            this.spltcModules.TabIndex = 2;
            // 
            // gridControlModules
            // 
            this.gridControlModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlModules.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlModules.Location = new System.Drawing.Point(0, 0);
            this.gridControlModules.MainView = this.gridModules;
            this.gridControlModules.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlModules.Name = "gridControlModules";
            this.gridControlModules.Size = new System.Drawing.Size(478, 411);
            this.gridControlModules.TabIndex = 2;
            this.gridControlModules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridModules});
            // 
            // gridModules
            // 
            this.gridModules.Appearance.Row.Options.UseTextOptions = true;
            this.gridModules.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridModules.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridModules.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridModules.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gridModules.DetailHeight = 431;
            this.gridModules.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridModules.GridControl = this.gridControlModules;
            this.gridModules.IndicatorWidth = 24;
            this.gridModules.Name = "gridModules";
            this.gridModules.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridModules.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridModules.OptionsFilter.AllowMRUFilterList = false;
            this.gridModules.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridModules.OptionsLayout.Columns.StoreAppearance = true;
            this.gridModules.OptionsLayout.StoreAllOptions = true;
            this.gridModules.OptionsLayout.StoreAppearance = true;
            this.gridModules.OptionsLayout.StoreFormatRules = true;
            this.gridModules.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridModules.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridModules.OptionsView.RowAutoHeight = true;
            this.gridModules.OptionsView.ShowGroupPanel = false;
            this.gridModules.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridModules_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn1.Caption = "Name";
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.MinWidth = 50;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 200;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn2.Caption = "Messages";
            this.gridColumn2.FieldName = "Messages";
            this.gridColumn2.MinWidth = 100;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn3.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn3.Caption = "Critical";
            this.gridColumn3.FieldName = "Critical";
            this.gridColumn3.MinWidth = 70;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn3.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 70;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn4.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn4.Caption = "Error";
            this.gridColumn4.FieldName = "Error";
            this.gridColumn4.MinWidth = 70;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn4.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 70;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn5.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn5.Caption = "Warning";
            this.gridColumn5.FieldName = "Warning";
            this.gridColumn5.MinWidth = 70;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 70;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Information";
            this.gridColumn6.FieldName = "Information";
            this.gridColumn6.MinWidth = 70;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 70;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn7.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn7.Caption = "Debug";
            this.gridColumn7.FieldName = "Debug";
            this.gridColumn7.MinWidth = 70;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn7.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 70;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn8.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn8.Caption = "Verbose";
            this.gridColumn8.FieldName = "Verbose";
            this.gridColumn8.MinWidth = 70;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn8.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 70;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn9.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn9.Caption = "Trace";
            this.gridColumn9.FieldName = "Trace";
            this.gridColumn9.MinWidth = 70;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 70;
            // 
            // tabPageGlobal
            // 
            this.tabPageGlobal.Controls.Add(this.spltCTop);
            this.tabPageGlobal.Location = new System.Drawing.Point(4, 25);
            this.tabPageGlobal.Name = "tabPageGlobal";
            this.tabPageGlobal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGlobal.Size = new System.Drawing.Size(968, 417);
            this.tabPageGlobal.TabIndex = 2;
            this.tabPageGlobal.Text = "Global";
            this.tabPageGlobal.UseVisualStyleBackColor = true;
            // 
            // tabPageFreeText
            // 
            this.tabPageFreeText.Controls.Add(this.spltCFreeText);
            this.tabPageFreeText.Controls.Add(this.panelControl1);
            this.tabPageFreeText.Location = new System.Drawing.Point(4, 25);
            this.tabPageFreeText.Name = "tabPageFreeText";
            this.tabPageFreeText.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFreeText.Size = new System.Drawing.Size(968, 417);
            this.tabPageFreeText.TabIndex = 3;
            this.tabPageFreeText.Text = "Free Text";
            this.tabPageFreeText.UseVisualStyleBackColor = true;
            // 
            // spltCFreeText
            // 
            this.spltCFreeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltCFreeText.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltCFreeText.Location = new System.Drawing.Point(3, 141);
            this.spltCFreeText.Name = "spltCFreeText";
            // 
            // spltCFreeText.Panel1
            // 
            this.spltCFreeText.Panel1.Controls.Add(this.gridControlFreeText);
            this.spltCFreeText.Size = new System.Drawing.Size(962, 273);
            this.spltCFreeText.SplitterDistance = 357;
            this.spltCFreeText.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.sBtnAdd);
            this.panelControl1.Controls.Add(this.chklistItems);
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(962, 138);
            this.panelControl1.TabIndex = 0;
            // 
            // sBtnAdd
            // 
            this.sBtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sBtnAdd.Location = new System.Drawing.Point(899, 3);
            this.sBtnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sBtnAdd.Name = "sBtnAdd";
            this.sBtnAdd.Size = new System.Drawing.Size(58, 28);
            this.sBtnAdd.TabIndex = 7;
            this.sBtnAdd.Text = "Add";
            this.sBtnAdd.Click += new System.EventHandler(this.sBtnAdd_Click);
            // 
            // chklistItems
            // 
            this.chklistItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chklistItems.Location = new System.Drawing.Point(5, 36);
            this.chklistItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chklistItems.Name = "chklistItems";
            this.chklistItems.Size = new System.Drawing.Size(952, 93);
            this.chklistItems.TabIndex = 6;
            this.chklistItems.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chklistItems_ItemCheck);
            // 
            // textEdit1
            // 
            this.textEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit1.Location = new System.Drawing.Point(149, 6);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(776, 22);
            this.textEdit1.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 9);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 16);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Add text:";
            // 
            // gridControlFreeText
            // 
            this.gridControlFreeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlFreeText.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlFreeText.Location = new System.Drawing.Point(0, 0);
            this.gridControlFreeText.MainView = this.gridViewFreeText;
            this.gridControlFreeText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlFreeText.Name = "gridControlFreeText";
            this.gridControlFreeText.Size = new System.Drawing.Size(357, 273);
            this.gridControlFreeText.TabIndex = 4;
            this.gridControlFreeText.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFreeText});
            // 
            // gridViewFreeText
            // 
            this.gridViewFreeText.Appearance.Row.Options.UseTextOptions = true;
            this.gridViewFreeText.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridViewFreeText.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridViewFreeText.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridViewFreeText.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11});
            this.gridViewFreeText.DetailHeight = 431;
            this.gridViewFreeText.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewFreeText.GridControl = this.gridControlFreeText;
            this.gridViewFreeText.IndicatorWidth = 24;
            this.gridViewFreeText.Name = "gridViewFreeText";
            this.gridViewFreeText.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridViewFreeText.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewFreeText.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewFreeText.OptionsLayout.Columns.StoreAllOptions = true;
            this.gridViewFreeText.OptionsLayout.Columns.StoreAppearance = true;
            this.gridViewFreeText.OptionsLayout.StoreAllOptions = true;
            this.gridViewFreeText.OptionsLayout.StoreAppearance = true;
            this.gridViewFreeText.OptionsLayout.StoreFormatRules = true;
            this.gridViewFreeText.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewFreeText.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridViewFreeText.OptionsView.RowAutoHeight = true;
            this.gridViewFreeText.OptionsView.ShowGroupPanel = false;
            this.gridViewFreeText.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewFreeText_FocusedRowChanged);
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn10.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn10.Caption = "Name";
            this.gridColumn10.FieldName = "Name";
            this.gridColumn10.MinWidth = 50;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.OptionsFilter.AllowFilter = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            this.gridColumn10.Width = 200;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn11.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn11.Caption = "Count";
            this.gridColumn11.FieldName = "Value";
            this.gridColumn11.MinWidth = 100;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn11.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            this.gridColumn11.Width = 100;
            // 
            // LogStatisticsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlBottom);
            this.Name = "LogStatisticsUC";
            this.Size = new System.Drawing.Size(976, 446);
            this.Load += new System.EventHandler(this.LogStatisticsUC_Load);
            this.spltCTop.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltCTop)).EndInit();
            this.spltCTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlGlobal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGlobal)).EndInit();
            this.tabControlBottom.ResumeLayout(false);
            this.tabPageSources.ResumeLayout(false);
            this.spltcSources.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltcSources)).EndInit();
            this.spltcSources.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logGridSource)).EndInit();
            this.tabPageModules.ResumeLayout(false);
            this.spltcModules.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltcModules)).EndInit();
            this.spltcModules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlModules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridModules)).EndInit();
            this.tabPageGlobal.ResumeLayout(false);
            this.tabPageFreeText.ResumeLayout(false);
            this.spltCFreeText.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltCFreeText)).EndInit();
            this.spltCFreeText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chklistItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFreeText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFreeText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer spltCTop;
        private System.Windows.Forms.SplitContainer spltcSources;
        private System.Windows.Forms.TabControl tabControlBottom;
        private System.Windows.Forms.TabPage tabPageSources;
        private System.Windows.Forms.TabPage tabPageModules;
        private System.Windows.Forms.SplitContainer spltcModules;
        private System.Windows.Forms.TabPage tabPageGlobal;
        private System.Windows.Forms.TabPage tabPageFreeText;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton sBtnAdd;
        private DevExpress.XtraEditors.CheckedListBoxControl chklistItems;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.SplitContainer spltCFreeText;
        private DevExpress.XtraGrid.GridControl GridControlSource;
        private DevExpress.XtraGrid.Views.Grid.GridView logGridSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMessagesCount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevelCritical;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevelError;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevelWarning;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevelInformation;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevelDebug;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevelVerbose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevelTrace;
        private DevExpress.XtraGrid.GridControl gridControlModules;
        private DevExpress.XtraGrid.Views.Grid.GridView gridModules;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.GridControl gridControlGlobal;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewGlobal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGlobalName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnValue;
        private DevExpress.XtraGrid.GridControl gridControlFreeText;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFreeText;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
    }
}
