namespace Analogy
{
    partial class UserSettingsDataProvidersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSettingsDataProvidersForm));
            this.tabControlMain = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageNLog = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lstBAnalogyColumns = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.sBtnMoveUp = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnMoveDown = new DevExpress.XtraEditors.SimpleButton();
            this.lstBoxItems = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.sBtnSaveNlogMapping = new DevExpress.XtraEditors.SimpleButton();
            this.txtSeperator = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtLayout = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.sbtnCheckLayout = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageSerilog = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageLog4Net = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.xtraTabPageNLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstBAnalogyColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeperator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLayout.Properties)).BeginInit();
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
            this.tabControlMain.SelectedTabPage = this.xtraTabPageNLog;
            this.tabControlMain.Size = new System.Drawing.Size(945, 569);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageNLog,
            this.xtraTabPageSerilog,
            this.xtraTabPageLog4Net});
            // 
            // xtraTabPageNLog
            // 
            this.xtraTabPageNLog.Controls.Add(this.splitContainerControl1);
            this.xtraTabPageNLog.Controls.Add(this.sBtnSaveNlogMapping);
            this.xtraTabPageNLog.Controls.Add(this.txtSeperator);
            this.xtraTabPageNLog.Controls.Add(this.labelControl8);
            this.xtraTabPageNLog.Controls.Add(this.txtLayout);
            this.xtraTabPageNLog.Controls.Add(this.labelControl7);
            this.xtraTabPageNLog.Controls.Add(this.sbtnCheckLayout);
            this.xtraTabPageNLog.ImageOptions.Image = global::Analogy.Properties.Resources.nlog;
            this.xtraTabPageNLog.Name = "xtraTabPageNLog";
            this.xtraTabPageNLog.Size = new System.Drawing.Size(805, 562);
            this.xtraTabPageNLog.Text = "NLog Parser";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Location = new System.Drawing.Point(13, 86);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.lstBAnalogyColumns);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl9);
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.lstBoxItems);
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl10);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(777, 429);
            this.splitContainerControl1.SplitterPosition = 175;
            this.splitContainerControl1.TabIndex = 9;
            // 
            // lstBAnalogyColumns
            // 
            this.lstBAnalogyColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBAnalogyColumns.Items.AddRange(new object[] {
            "Date",
            "Text",
            "Source",
            "Module",
            "MethodName",
            "FileName",
            "User",
            "LineNumber",
            "ProcessID",
            "Thread",
            "Level",
            "Class",
            "Category",
            "ID"});
            this.lstBAnalogyColumns.Location = new System.Drawing.Point(44, 16);
            this.lstBAnalogyColumns.Name = "lstBAnalogyColumns";
            this.lstBAnalogyColumns.Size = new System.Drawing.Size(131, 409);
            this.lstBAnalogyColumns.TabIndex = 0;
            this.lstBAnalogyColumns.SelectedIndexChanged += new System.EventHandler(this.lstBAnalogyColumns_SelectedIndexChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl9.Location = new System.Drawing.Point(44, 0);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(122, 16);
            this.labelControl9.TabIndex = 7;
            this.labelControl9.Text = "Log message Column";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.sBtnMoveUp);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.sBtnMoveDown);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(44, 425);
            this.splitContainerControl2.SplitterPosition = 184;
            this.splitContainerControl2.TabIndex = 1;
            // 
            // sBtnMoveUp
            // 
            this.sBtnMoveUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sBtnMoveUp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sBtnMoveUp.ImageOptions.Image")));
            this.sBtnMoveUp.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.sBtnMoveUp.Location = new System.Drawing.Point(0, 0);
            this.sBtnMoveUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnMoveUp.Name = "sBtnMoveUp";
            this.sBtnMoveUp.Size = new System.Drawing.Size(44, 184);
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
            this.sBtnMoveDown.Size = new System.Drawing.Size(44, 235);
            this.sBtnMoveDown.TabIndex = 3;
            this.sBtnMoveDown.Text = "Down";
            this.sBtnMoveDown.Click += new System.EventHandler(this.sBtnMoveDown_Click);
            // 
            // lstBoxItems
            // 
            this.lstBoxItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxItems.Location = new System.Drawing.Point(0, 16);
            this.lstBoxItems.Name = "lstBoxItems";
            this.lstBoxItems.Size = new System.Drawing.Size(592, 409);
            this.lstBoxItems.TabIndex = 2;
            // 
            // labelControl10
            // 
            this.labelControl10.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl10.Location = new System.Drawing.Point(0, 0);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(94, 16);
            this.labelControl10.TabIndex = 8;
            this.labelControl10.Text = "Parsed columns.";
            // 
            // sBtnSaveNlogMapping
            // 
            this.sBtnSaveNlogMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sBtnSaveNlogMapping.Location = new System.Drawing.Point(688, 520);
            this.sBtnSaveNlogMapping.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnSaveNlogMapping.Name = "sBtnSaveNlogMapping";
            this.sBtnSaveNlogMapping.Size = new System.Drawing.Size(111, 37);
            this.sBtnSaveNlogMapping.TabIndex = 8;
            this.sBtnSaveNlogMapping.Text = "Save Mapping";
            this.sBtnSaveNlogMapping.Click += new System.EventHandler(this.sBtnSaveNlogMapping_Click);
            // 
            // txtSeperator
            // 
            this.txtSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeperator.EditValue = "|";
            this.txtSeperator.Location = new System.Drawing.Point(145, 39);
            this.txtSeperator.Name = "txtSeperator";
            this.txtSeperator.Size = new System.Drawing.Size(536, 22);
            this.txtSeperator.TabIndex = 7;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(3, 42);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(120, 16);
            this.labelControl8.TabIndex = 6;
            this.labelControl8.Text = "Seperator character:";
            // 
            // txtLayout
            // 
            this.txtLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLayout.Location = new System.Drawing.Point(145, 11);
            this.txtLayout.Name = "txtLayout";
            this.txtLayout.Size = new System.Drawing.Size(536, 22);
            this.txtLayout.TabIndex = 5;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(3, 14);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(104, 16);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "NLog Layout/Row:";
            // 
            // sbtnCheckLayout
            // 
            this.sbtnCheckLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnCheckLayout.Location = new System.Drawing.Point(703, 14);
            this.sbtnCheckLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sbtnCheckLayout.Name = "sbtnCheckLayout";
            this.sbtnCheckLayout.Size = new System.Drawing.Size(96, 37);
            this.sbtnCheckLayout.TabIndex = 1;
            this.sbtnCheckLayout.Text = "Load layout";
            this.sbtnCheckLayout.Click += new System.EventHandler(this.sbtnCheckLayout_Click);
            // 
            // xtraTabPageSerilog
            // 
            this.xtraTabPageSerilog.ImageOptions.Image = global::Analogy.Properties.Resources.serilog32x32;
            this.xtraTabPageSerilog.Name = "xtraTabPageSerilog";
            this.xtraTabPageSerilog.Size = new System.Drawing.Size(805, 562);
            this.xtraTabPageSerilog.Text = "Serilog parser";
            // 
            // xtraTabPageLog4Net
            // 
            this.xtraTabPageLog4Net.Name = "xtraTabPageLog4Net";
            this.xtraTabPageLog4Net.Size = new System.Drawing.Size(0, 0);
            this.xtraTabPageLog4Net.Text = "Log4Net Parser";
            // 
            // UserSettingsDataProvidersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 569);
            this.Controls.Add(this.tabControlMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserSettingsDataProvidersForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Settings";
            this.Load += new System.EventHandler(this.UserSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.xtraTabPageNLog.ResumeLayout(false);
            this.xtraTabPageNLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstBAnalogyColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeperator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLayout.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabControlMain;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageNLog;
        private DevExpress.XtraEditors.TextEdit txtSeperator;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtLayout;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton sbtnCheckLayout;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton sBtnSaveNlogMapping;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.ListBoxControl lstBAnalogyColumns;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SimpleButton sBtnMoveUp;
        private DevExpress.XtraEditors.SimpleButton sBtnMoveDown;
        private DevExpress.XtraEditors.ListBoxControl lstBoxItems;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageSerilog;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageLog4Net;
    }
}