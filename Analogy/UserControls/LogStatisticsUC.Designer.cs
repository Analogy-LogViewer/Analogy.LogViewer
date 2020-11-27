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
            this.dgvTop = new System.Windows.Forms.DataGridView();
            this.ColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlBottom = new System.Windows.Forms.TabControl();
            this.tabPageSources = new System.Windows.Forms.TabPage();
            this.spltcSources = new System.Windows.Forms.SplitContainer();
            this.tabPageModules = new System.Windows.Forms.TabPage();
            this.spltcModules = new System.Windows.Forms.SplitContainer();
            this.dgvModules = new System.Windows.Forms.DataGridView();
            this.tabPageGlobal = new System.Windows.Forms.TabPage();
            this.tabPageFreeText = new System.Windows.Forms.TabPage();
            this.spltCFreeText = new System.Windows.Forms.SplitContainer();
            this.dgvFreeText = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.chklistItems = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridSource = new DevExpress.XtraGrid.GridControl();
            this.logGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMessagesCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevelCritical = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevelError = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevelWarning = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevelTrace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevelDebug = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevelVerbose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevelInformation = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.spltCTop)).BeginInit();
            this.spltCTop.Panel1.SuspendLayout();
            this.spltCTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop)).BeginInit();
            this.tabControlBottom.SuspendLayout();
            this.tabPageSources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltcSources)).BeginInit();
            this.spltcSources.Panel1.SuspendLayout();
            this.spltcSources.SuspendLayout();
            this.tabPageModules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltcModules)).BeginInit();
            this.spltcModules.Panel1.SuspendLayout();
            this.spltcModules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModules)).BeginInit();
            this.tabPageGlobal.SuspendLayout();
            this.tabPageFreeText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltCFreeText)).BeginInit();
            this.spltCFreeText.Panel1.SuspendLayout();
            this.spltCFreeText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFreeText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chklistItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).BeginInit();
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
            this.spltCTop.Panel1.Controls.Add(this.dgvTop);
            this.spltCTop.Size = new System.Drawing.Size(962, 411);
            this.spltCTop.SplitterDistance = 357;
            this.spltCTop.TabIndex = 0;
            // 
            // dgvTop
            // 
            this.dgvTop.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTitle,
            this.ColumnValue});
            this.dgvTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTop.Location = new System.Drawing.Point(0, 0);
            this.dgvTop.Name = "dgvTop";
            this.dgvTop.RowHeadersWidth = 51;
            this.dgvTop.RowTemplate.Height = 24;
            this.dgvTop.Size = new System.Drawing.Size(357, 411);
            this.dgvTop.TabIndex = 0;
            // 
            // ColumnTitle
            // 
            this.ColumnTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnTitle.HeaderText = "Type";
            this.ColumnTitle.MinimumWidth = 6;
            this.ColumnTitle.Name = "ColumnTitle";
            this.ColumnTitle.Width = 69;
            // 
            // ColumnValue
            // 
            this.ColumnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnValue.HeaderText = "Count";
            this.ColumnValue.MinimumWidth = 6;
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.Width = 74;
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
            this.spltcSources.Panel1.Controls.Add(this.gridSource);
            this.spltcSources.Size = new System.Drawing.Size(962, 411);
            this.spltcSources.SplitterDistance = 478;
            this.spltcSources.TabIndex = 1;
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
            this.spltcModules.Panel1.Controls.Add(this.dgvModules);
            this.spltcModules.Size = new System.Drawing.Size(962, 411);
            this.spltcModules.SplitterDistance = 478;
            this.spltcModules.TabIndex = 2;
            // 
            // dgvModules
            // 
            this.dgvModules.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvModules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvModules.Location = new System.Drawing.Point(0, 0);
            this.dgvModules.MultiSelect = false;
            this.dgvModules.Name = "dgvModules";
            this.dgvModules.RowHeadersWidth = 51;
            this.dgvModules.RowTemplate.Height = 24;
            this.dgvModules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModules.Size = new System.Drawing.Size(478, 411);
            this.dgvModules.TabIndex = 0;
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
            this.spltCFreeText.Panel1.Controls.Add(this.dgvFreeText);
            this.spltCFreeText.Size = new System.Drawing.Size(962, 273);
            this.spltCFreeText.SplitterDistance = 357;
            this.spltCFreeText.TabIndex = 1;
            // 
            // dgvFreeText
            // 
            this.dgvFreeText.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFreeText.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFreeText.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvFreeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFreeText.Location = new System.Drawing.Point(0, 0);
            this.dgvFreeText.Name = "dgvFreeText";
            this.dgvFreeText.RowHeadersWidth = 51;
            this.dgvFreeText.RowTemplate.Height = 24;
            this.dgvFreeText.Size = new System.Drawing.Size(357, 273);
            this.dgvFreeText.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Type";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 69;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Count";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 74;
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
            this.textEdit1.Size = new System.Drawing.Size(744, 22);
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
            // gridSource
            // 
            this.gridSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSource.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridSource.Location = new System.Drawing.Point(0, 0);
            this.gridSource.MainView = this.logGrid;
            this.gridSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridSource.Name = "gridSource";
            this.gridSource.Size = new System.Drawing.Size(478, 411);
            this.gridSource.TabIndex = 1;
            this.gridSource.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.logGrid});
            // 
            // logGrid
            // 
            this.logGrid.Appearance.Row.Options.UseTextOptions = true;
            this.logGrid.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.logGrid.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.logGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.logGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnName,
            this.gridColumnMessagesCount,
            this.gridColumnLevelCritical,
            this.gridColumnLevelError,
            this.gridColumnLevelWarning,
            this.gridColumnLevelInformation,
            this.gridColumnLevelDebug,
            this.gridColumnLevelVerbose,
            this.gridColumnLevelTrace});
            this.logGrid.DetailHeight = 431;
            this.logGrid.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.logGrid.GridControl = this.gridSource;
            this.logGrid.IndicatorWidth = 24;
            this.logGrid.Name = "logGrid";
            this.logGrid.OptionsBehavior.AllowIncrementalSearch = true;
            this.logGrid.OptionsFilter.AllowColumnMRUFilterList = false;
            this.logGrid.OptionsFilter.AllowMRUFilterList = false;
            this.logGrid.OptionsLayout.Columns.StoreAllOptions = true;
            this.logGrid.OptionsLayout.Columns.StoreAppearance = true;
            this.logGrid.OptionsLayout.StoreAllOptions = true;
            this.logGrid.OptionsLayout.StoreAppearance = true;
            this.logGrid.OptionsLayout.StoreFormatRules = true;
            this.logGrid.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.logGrid.OptionsView.AutoCalcPreviewLineCount = true;
            this.logGrid.OptionsView.ColumnAutoWidth = false;
            this.logGrid.OptionsView.RowAutoHeight = true;
            this.logGrid.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnName
            // 
            this.gridColumnName.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnName.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnName.Caption = "Name";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.MinWidth = 24;
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
            this.gridColumnMessagesCount.FieldName = "MessagesCount";
            this.gridColumnMessagesCount.MinWidth = 24;
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
            this.gridColumnMessagesCount.Width = 234;
            // 
            // gridColumnLevelCritical
            // 
            this.gridColumnLevelCritical.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnLevelCritical.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnLevelCritical.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnLevelCritical.Caption = "Critical";
            this.gridColumnLevelCritical.FieldName = "Critical";
            this.gridColumnLevelCritical.MinWidth = 24;
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
            this.gridColumnLevelCritical.Width = 115;
            // 
            // gridColumnLevelError
            // 
            this.gridColumnLevelError.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnLevelError.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnLevelError.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnLevelError.Caption = "Error";
            this.gridColumnLevelError.FieldName = "Error";
            this.gridColumnLevelError.MinWidth = 24;
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
            this.gridColumnLevelError.Width = 115;
            // 
            // gridColumnLevelWarning
            // 
            this.gridColumnLevelWarning.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnLevelWarning.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnLevelWarning.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnLevelWarning.Caption = "Warning";
            this.gridColumnLevelWarning.FieldName = "Warning";
            this.gridColumnLevelWarning.MinWidth = 24;
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
            this.gridColumnLevelWarning.Width = 115;
            // 
            // gridColumnLevelTrace
            // 
            this.gridColumnLevelTrace.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnLevelTrace.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnLevelTrace.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnLevelTrace.Caption = "Trace";
            this.gridColumnLevelTrace.FieldName = "Trace";
            this.gridColumnLevelTrace.MinWidth = 24;
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
            this.gridColumnLevelTrace.Width = 115;
            // 
            // gridColumnLevelDebug
            // 
            this.gridColumnLevelDebug.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnLevelDebug.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnLevelDebug.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnLevelDebug.Caption = "Debug";
            this.gridColumnLevelDebug.FieldName = "Debug";
            this.gridColumnLevelDebug.MinWidth = 24;
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
            this.gridColumnLevelDebug.Width = 115;
            // 
            // gridColumnLevelVerbose
            // 
            this.gridColumnLevelVerbose.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnLevelVerbose.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnLevelVerbose.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnLevelVerbose.Caption = "Verbose";
            this.gridColumnLevelVerbose.FieldName = "Verbose";
            this.gridColumnLevelVerbose.MinWidth = 24;
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
            this.gridColumnLevelVerbose.Width = 115;
            // 
            // gridColumnLevelInformation
            // 
            this.gridColumnLevelInformation.Caption = "Information";
            this.gridColumnLevelInformation.FieldName = "Information";
            this.gridColumnLevelInformation.MinWidth = 25;
            this.gridColumnLevelInformation.Name = "gridColumnLevelInformation";
            this.gridColumnLevelInformation.OptionsColumn.AllowEdit = false;
            this.gridColumnLevelInformation.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.gridColumnLevelInformation.Visible = true;
            this.gridColumnLevelInformation.VisibleIndex = 8;
            this.gridColumnLevelInformation.Width = 109;
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop)).EndInit();
            this.tabControlBottom.ResumeLayout(false);
            this.tabPageSources.ResumeLayout(false);
            this.spltcSources.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltcSources)).EndInit();
            this.spltcSources.ResumeLayout(false);
            this.tabPageModules.ResumeLayout(false);
            this.spltcModules.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltcModules)).EndInit();
            this.spltcModules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModules)).EndInit();
            this.tabPageGlobal.ResumeLayout(false);
            this.tabPageFreeText.ResumeLayout(false);
            this.spltCFreeText.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltCFreeText)).EndInit();
            this.spltCFreeText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFreeText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chklistItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer spltCTop;
        private System.Windows.Forms.DataGridView dgvTop;
        private System.Windows.Forms.SplitContainer spltcSources;
        private System.Windows.Forms.TabControl tabControlBottom;
        private System.Windows.Forms.TabPage tabPageSources;
        private System.Windows.Forms.TabPage tabPageModules;
        private System.Windows.Forms.SplitContainer spltcModules;
        private System.Windows.Forms.DataGridView dgvModules;
        private System.Windows.Forms.TabPage tabPageGlobal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.TabPage tabPageFreeText;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton sBtnAdd;
        private DevExpress.XtraEditors.CheckedListBoxControl chklistItems;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.SplitContainer spltCFreeText;
        private System.Windows.Forms.DataGridView dgvFreeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DevExpress.XtraGrid.GridControl gridSource;
        private DevExpress.XtraGrid.Views.Grid.GridView logGrid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMessagesCount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevelCritical;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevelError;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevelWarning;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevelInformation;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevelDebug;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevelVerbose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevelTrace;
    }
}
