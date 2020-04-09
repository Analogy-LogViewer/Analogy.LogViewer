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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.spltCTop)).BeginInit();
            this.spltCTop.Panel1.SuspendLayout();
            this.spltCTop.Panel2.SuspendLayout();
            this.spltCTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop)).BeginInit();
            this.tabControlBottom.SuspendLayout();
            this.tabPageSources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltcSources)).BeginInit();
            this.spltcSources.Panel1.SuspendLayout();
            this.spltcSources.Panel2.SuspendLayout();
            this.spltcSources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).BeginInit();
            this.tabPageModules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltcModules)).BeginInit();
            this.spltcModules.Panel1.SuspendLayout();
            this.spltcModules.Panel2.SuspendLayout();
            this.spltcModules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModules)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spltCTop
            // 
            this.spltCTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltCTop.Location = new System.Drawing.Point(3, 3);
            this.spltCTop.Name = "spltCTop";
            // 
            // spltCTop.Panel1
            // 
            this.spltCTop.Panel1.Controls.Add(this.dgvTop);
            // 
            // spltCTop.Panel2
            // 
            this.spltCTop.Size = new System.Drawing.Size(962, 411);
            this.spltCTop.SplitterDistance = 478;
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
            this.dgvTop.RowTemplate.Height = 24;
            this.dgvTop.Size = new System.Drawing.Size(478, 411);
            this.dgvTop.TabIndex = 0;
            // 
            // ColumnTitle
            // 
            this.ColumnTitle.HeaderText = "Type";
            this.ColumnTitle.Name = "ColumnTitle";
            this.ColumnTitle.Width = 218;
            // 
            // ColumnValue
            // 
            this.ColumnValue.HeaderText = "Count";
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.Width = 217;
            // 
            // tabControlBottom
            // 
            this.tabControlBottom.Controls.Add(this.tabPageSources);
            this.tabControlBottom.Controls.Add(this.tabPageModules);
            this.tabControlBottom.Controls.Add(this.tabPage1);
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
            // 
            // spltcSources.Panel2
            // 
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
            // 
            // spltcModules.Panel2
            // 
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
            this.dgvModules.RowTemplate.Height = 24;
            this.dgvModules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModules.Size = new System.Drawing.Size(478, 411);
            this.dgvModules.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.spltCTop);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(968, 417);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Global";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.spltCTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltCTop)).EndInit();
            this.spltCTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop)).EndInit();
            this.tabControlBottom.ResumeLayout(false);
            this.tabPageSources.ResumeLayout(false);
            this.spltcSources.Panel1.ResumeLayout(false);
            this.spltcSources.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltcSources)).EndInit();
            this.spltcSources.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).EndInit();
            this.tabPageModules.ResumeLayout(false);
            this.spltcModules.Panel1.ResumeLayout(false);
            this.spltcModules.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltcModules)).EndInit();
            this.spltcModules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModules)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer spltCTop;
        private System.Windows.Forms.DataGridView dgvTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.SplitContainer spltcSources;
        private System.Windows.Forms.DataGridView dgvSource;
        private System.Windows.Forms.TabControl tabControlBottom;
        private System.Windows.Forms.TabPage tabPageSources;
        private System.Windows.Forms.TabPage tabPageModules;
        private System.Windows.Forms.SplitContainer spltcModules;
        private System.Windows.Forms.DataGridView dgvModules;
        private System.Windows.Forms.TabPage tabPage1;
    }
}
