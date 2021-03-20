
namespace Analogy.UserControls
{
    partial class LogGridUC
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
            this.layoutControlLogs = new DevExpress.XtraLayout.LayoutControl();
            this.sbtnPageFirst = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnMoreHighlight = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnPagePrevious = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnPageNext = new DevExpress.XtraEditors.SimpleButton();
            this.chkbHighlight = new DevExpress.XtraEditors.CheckEdit();
            this.sBtnLastPage = new DevExpress.XtraEditors.SimpleButton();
            this.txtbHighlight = new DevExpress.XtraEditors.TextEdit();
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
            this.gridColumnMachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblPageNumber = new DevExpress.XtraLayout.SimpleLabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlLogs)).BeginInit();
            this.layoutControlLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkbHighlight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbHighlight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPageNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControlLogs
            // 
            this.layoutControlLogs.Controls.Add(this.sbtnPageFirst);
            this.layoutControlLogs.Controls.Add(this.sbtnMoreHighlight);
            this.layoutControlLogs.Controls.Add(this.sbtnPagePrevious);
            this.layoutControlLogs.Controls.Add(this.sBtnPageNext);
            this.layoutControlLogs.Controls.Add(this.chkbHighlight);
            this.layoutControlLogs.Controls.Add(this.sBtnLastPage);
            this.layoutControlLogs.Controls.Add(this.txtbHighlight);
            this.layoutControlLogs.Controls.Add(this.gridControl);
            this.layoutControlLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlLogs.Location = new System.Drawing.Point(0, 0);
            this.layoutControlLogs.Name = "layoutControlLogs";
            this.layoutControlLogs.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(520, 50, 812, 500);
            this.layoutControlLogs.Root = this.layoutControlGroup1;
            this.layoutControlLogs.Size = new System.Drawing.Size(1052, 407);
            this.layoutControlLogs.TabIndex = 7;
            this.layoutControlLogs.Text = "layoutControl2";
            // 
            // sbtnPageFirst
            // 
            this.sbtnPageFirst.Location = new System.Drawing.Point(696, 373);
            this.sbtnPageFirst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sbtnPageFirst.Name = "sbtnPageFirst";
            this.sbtnPageFirst.Size = new System.Drawing.Size(63, 27);
            this.sbtnPageFirst.StyleController = this.layoutControlLogs;
            this.sbtnPageFirst.TabIndex = 5;
            this.sbtnPageFirst.Text = "first Page";
            // 
            // sbtnMoreHighlight
            // 
            this.sbtnMoreHighlight.Location = new System.Drawing.Point(638, 373);
            this.sbtnMoreHighlight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sbtnMoreHighlight.Name = "sbtnMoreHighlight";
            this.sbtnMoreHighlight.Size = new System.Drawing.Size(54, 27);
            this.sbtnMoreHighlight.StyleController = this.layoutControlLogs;
            this.sbtnMoreHighlight.TabIndex = 4;
            this.sbtnMoreHighlight.Text = "More ...";
            // 
            // sbtnPagePrevious
            // 
            this.sbtnPagePrevious.Location = new System.Drawing.Point(763, 373);
            this.sbtnPagePrevious.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sbtnPagePrevious.Name = "sbtnPagePrevious";
            this.sbtnPagePrevious.Size = new System.Drawing.Size(89, 27);
            this.sbtnPagePrevious.StyleController = this.layoutControlLogs;
            this.sbtnPagePrevious.TabIndex = 6;
            this.sbtnPagePrevious.Text = "Previous Page";
            // 
            // sBtnPageNext
            // 
            this.sBtnPageNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sBtnPageNext.Location = new System.Drawing.Point(911, 373);
            this.sBtnPageNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sBtnPageNext.Name = "sBtnPageNext";
            this.sBtnPageNext.Size = new System.Drawing.Size(66, 27);
            this.sBtnPageNext.StyleController = this.layoutControlLogs;
            this.sBtnPageNext.TabIndex = 7;
            this.sBtnPageNext.Text = "Next Page";
            // 
            // chkbHighlight
            // 
            this.chkbHighlight.Location = new System.Drawing.Point(7, 373);
            this.chkbHighlight.Name = "chkbHighlight";
            this.chkbHighlight.Properties.Caption = "Highlight lines that contains:";
            this.chkbHighlight.Size = new System.Drawing.Size(183, 20);
            this.chkbHighlight.StyleController = this.layoutControlLogs;
            this.chkbHighlight.TabIndex = 2;
            // 
            // sBtnLastPage
            // 
            this.sBtnLastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sBtnLastPage.Location = new System.Drawing.Point(981, 373);
            this.sBtnLastPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sBtnLastPage.Name = "sBtnLastPage";
            this.sBtnLastPage.Size = new System.Drawing.Size(64, 27);
            this.sBtnLastPage.StyleController = this.layoutControlLogs;
            this.sBtnLastPage.TabIndex = 8;
            this.sBtnLastPage.Text = "Last Page";
            // 
            // txtbHighlight
            // 
            this.txtbHighlight.Location = new System.Drawing.Point(194, 373);
            this.txtbHighlight.Name = "txtbHighlight";
            this.txtbHighlight.Size = new System.Drawing.Size(440, 22);
            this.txtbHighlight.StyleController = this.layoutControlLogs;
            this.txtbHighlight.TabIndex = 3;
            // 
            // gridControl
            // 
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl.Location = new System.Drawing.Point(7, 7);
            this.gridControl.MainView = this.logGrid;
            this.gridControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1038, 362);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.logGrid});
            // 
            // logGrid
            // 
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
            this.gridColumnThread,
            this.gridColumnMachineName});
            this.logGrid.DetailHeight = 431;
            this.logGrid.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.logGrid.GridControl = this.gridControl;
            this.logGrid.IndicatorWidth = 24;
            this.logGrid.Name = "logGrid";
            this.logGrid.OptionsBehavior.AllowIncrementalSearch = true;
            this.logGrid.OptionsFilter.AllowColumnMRUFilterList = false;
            this.logGrid.OptionsFilter.AllowMRUFilterList = false;
            this.logGrid.OptionsFind.AlwaysVisible = true;
            this.logGrid.OptionsLayout.Columns.StoreAllOptions = true;
            this.logGrid.OptionsLayout.Columns.StoreAppearance = true;
            this.logGrid.OptionsLayout.StoreAllOptions = true;
            this.logGrid.OptionsLayout.StoreAppearance = true;
            this.logGrid.OptionsLayout.StoreFormatRules = true;
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
            this.gridColumnTimeDiff.OptionsColumn.AllowEdit = false;
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
            this.gridColumnLevel.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)});
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
            this.gridColumnThread.OptionsColumn.AllowEdit = false;
            this.gridColumnThread.Visible = true;
            this.gridColumnThread.VisibleIndex = 10;
            this.gridColumnThread.Width = 109;
            // 
            // gridColumnMachineName
            // 
            this.gridColumnMachineName.Caption = "Machine Name";
            this.gridColumnMachineName.FieldName = "MachineName";
            this.gridColumnMachineName.MinWidth = 25;
            this.gridColumnMachineName.Name = "gridColumnMachineName";
            this.gridColumnMachineName.OptionsColumn.AllowEdit = false;
            this.gridColumnMachineName.Visible = true;
            this.gridColumnMachineName.VisibleIndex = 11;
            this.gridColumnMachineName.Width = 94;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem20,
            this.layoutControlItem22,
            this.layoutControlItem23,
            this.layoutControlItem24,
            this.layoutControlItem25,
            this.layoutControlItem27,
            this.layoutControlItem28,
            this.layoutControlItem21,
            this.lblPageNumber});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1052, 407);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.gridControl;
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(1042, 366);
            this.layoutControlItem20.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem20.TextVisible = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.txtbHighlight;
            this.layoutControlItem22.Location = new System.Drawing.Point(187, 366);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(444, 31);
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.chkbHighlight;
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 366);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(187, 31);
            this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem23.TextVisible = false;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.sBtnLastPage;
            this.layoutControlItem24.Location = new System.Drawing.Point(974, 366);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(68, 31);
            this.layoutControlItem24.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem24.TextVisible = false;
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.sBtnPageNext;
            this.layoutControlItem25.Location = new System.Drawing.Point(904, 366);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(70, 31);
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextVisible = false;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.sbtnPagePrevious;
            this.layoutControlItem27.Location = new System.Drawing.Point(756, 366);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(93, 31);
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextVisible = false;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.sbtnPageFirst;
            this.layoutControlItem28.Location = new System.Drawing.Point(689, 366);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(67, 31);
            this.layoutControlItem28.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem28.TextVisible = false;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.sbtnMoreHighlight;
            this.layoutControlItem21.Location = new System.Drawing.Point(631, 366);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(58, 31);
            this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem21.TextVisible = false;
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AllowHotTrack = false;
            this.lblPageNumber.Location = new System.Drawing.Point(849, 366);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(55, 31);
            this.lblPageNumber.Text = "Page 1/1";
            this.lblPageNumber.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lblPageNumber.TextSize = new System.Drawing.Size(51, 16);
            // 
            // LogGridUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControlLogs);
            this.Name = "LogGridUC";
            this.Size = new System.Drawing.Size(1052, 407);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlLogs)).EndInit();
            this.layoutControlLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkbHighlight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbHighlight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPageNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControlLogs;
        private DevExpress.XtraEditors.SimpleButton sbtnPageFirst;
        private DevExpress.XtraEditors.SimpleButton sbtnMoreHighlight;
        private DevExpress.XtraEditors.SimpleButton sbtnPagePrevious;
        private DevExpress.XtraEditors.SimpleButton sBtnPageNext;
        private DevExpress.XtraEditors.CheckEdit chkbHighlight;
        private DevExpress.XtraEditors.SimpleButton sBtnLastPage;
        private DevExpress.XtraEditors.TextEdit txtbHighlight;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMachineName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.SimpleLabelItem lblPageNumber;
    }
}
