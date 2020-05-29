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
            this.dgvSource = new System.Windows.Forms.DataGridView();
            this.tabPageModules = new System.Windows.Forms.TabPage();
            this.spltcModules = new System.Windows.Forms.SplitContainer();
            this.dgvModules = new System.Windows.Forms.DataGridView();
            this.tabPageGlobal = new System.Windows.Forms.TabPage();
            this.tabPageFreeText = new System.Windows.Forms.TabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.sBtnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.chklistItems = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spltCFreeText = new System.Windows.Forms.SplitContainer();
            this.dgvFreeText = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.spltCTop)).BeginInit();
            this.spltCTop.Panel1.SuspendLayout();
            this.spltCTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop)).BeginInit();
            this.tabControlBottom.SuspendLayout();
            this.tabPageSources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltcSources)).BeginInit();
            this.spltcSources.Panel1.SuspendLayout();
            this.spltcSources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).BeginInit();
            this.tabPageModules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltcModules)).BeginInit();
            this.spltcModules.Panel1.SuspendLayout();
            this.spltcModules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModules)).BeginInit();
            this.tabPageGlobal.SuspendLayout();
            this.tabPageFreeText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chklistItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltCFreeText)).BeginInit();
            this.spltCFreeText.Panel1.SuspendLayout();
            this.spltCFreeText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFreeText)).BeginInit();
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
            this.spltcSources.Panel1.Controls.Add(this.dgvSource);
            this.spltcSources.Size = new System.Drawing.Size(962, 411);
            this.spltcSources.SplitterDistance = 478;
            this.spltcSources.TabIndex = 1;
            // 
            // dgvSource
            // 
            this.dgvSource.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSource.Location = new System.Drawing.Point(0, 0);
            this.dgvSource.MultiSelect = false;
            this.dgvSource.Name = "dgvSource";
            this.dgvSource.RowHeadersWidth = 51;
            this.dgvSource.RowTemplate.Height = 24;
            this.dgvSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSource.Size = new System.Drawing.Size(478, 411);
            this.dgvSource.TabIndex = 0;
            this.dgvSource.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSource_CellContentClick);
            this.dgvSource.SelectionChanged += new System.EventHandler(this.dgvSource_SelectionChanged);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).EndInit();
            this.tabPageModules.ResumeLayout(false);
            this.spltcModules.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltcModules)).EndInit();
            this.spltcModules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModules)).EndInit();
            this.tabPageGlobal.ResumeLayout(false);
            this.tabPageFreeText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chklistItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.spltCFreeText.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltCFreeText)).EndInit();
            this.spltCFreeText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFreeText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer spltCTop;
        private System.Windows.Forms.DataGridView dgvTop;
        private System.Windows.Forms.SplitContainer spltcSources;
        private System.Windows.Forms.DataGridView dgvSource;
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
    }
}
