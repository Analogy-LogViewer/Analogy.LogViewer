namespace Analogy.UserControls
{
    partial class AnalogyColumnsMatcherUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalogyColumnsMatcherUC));
            this.spltNlogParser = new DevExpress.XtraEditors.SplitContainerControl();
            this.lstBAnalogyColumns = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.sBtnMoveUp = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnMoveDown = new DevExpress.XtraEditors.SimpleButton();
            this.lstBoxItemsNlog = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.spltNlogParser)).BeginInit();
            this.spltNlogParser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstBAnalogyColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxItemsNlog)).BeginInit();
            this.SuspendLayout();
            // 
            // spltNlogParser
            // 
            this.spltNlogParser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.spltNlogParser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltNlogParser.Location = new System.Drawing.Point(0, 0);
            this.spltNlogParser.Name = "spltNlogParser";
            this.spltNlogParser.Panel1.Controls.Add(this.lstBAnalogyColumns);
            this.spltNlogParser.Panel1.Controls.Add(this.labelControl9);
            this.spltNlogParser.Panel1.Controls.Add(this.splitContainerControl2);
            this.spltNlogParser.Panel1.Text = "Panel1";
            this.spltNlogParser.Panel2.Controls.Add(this.lstBoxItemsNlog);
            this.spltNlogParser.Panel2.Controls.Add(this.labelControl10);
            this.spltNlogParser.Panel2.Text = "Panel2";
            this.spltNlogParser.Size = new System.Drawing.Size(688, 483);
            this.spltNlogParser.SplitterPosition = 191;
            this.spltNlogParser.TabIndex = 10;
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
            "ID",
            "__ignore__",
            "__ignore__",
            "__ignore__",
            "__ignore__",
            "__ignore__",
            "__ignore__",
            "__ignore__"});
            this.lstBAnalogyColumns.Location = new System.Drawing.Point(44, 16);
            this.lstBAnalogyColumns.Name = "lstBAnalogyColumns";
            this.lstBAnalogyColumns.Size = new System.Drawing.Size(147, 463);
            this.lstBAnalogyColumns.TabIndex = 0;
            this.lstBAnalogyColumns.SelectedIndexChanged += new System.EventHandler(this.lstBAnalogyColumns_SelectedIndexChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl9.Location = new System.Drawing.Point(44, 0);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(128, 16);
            this.labelControl9.TabIndex = 7;
            this.labelControl9.Text = "Log message Columns";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.sBtnMoveUp);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.sBtnMoveDown);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(44, 479);
            this.splitContainerControl2.SplitterPosition = 237;
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
            this.sBtnMoveUp.Size = new System.Drawing.Size(44, 237);
            this.sBtnMoveUp.TabIndex = 2;
            this.sBtnMoveUp.Text = "Up";
            this.sBtnMoveUp.Click += new System.EventHandler(this.SBtnMoveUp_Click);
            // 
            // sBtnMoveDown
            // 
            this.sBtnMoveDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sBtnMoveDown.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sBtnMoveDown.ImageOptions.Image")));
            this.sBtnMoveDown.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomLeft;
            this.sBtnMoveDown.Location = new System.Drawing.Point(0, 0);
            this.sBtnMoveDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnMoveDown.Name = "sBtnMoveDown";
            this.sBtnMoveDown.Size = new System.Drawing.Size(44, 236);
            this.sBtnMoveDown.TabIndex = 3;
            this.sBtnMoveDown.Text = "Down";
            this.sBtnMoveDown.Click += new System.EventHandler(this.SBtnMoveDown_Click);
            // 
            // lstBoxItemsNlog
            // 
            this.lstBoxItemsNlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxItemsNlog.Location = new System.Drawing.Point(0, 16);
            this.lstBoxItemsNlog.Name = "lstBoxItemsNlog";
            this.lstBoxItemsNlog.Size = new System.Drawing.Size(487, 463);
            this.lstBoxItemsNlog.TabIndex = 2;
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
            // AnalogyColumnsMatcherUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spltNlogParser);
            this.Name = "AnalogyColumnsMatcherUC";
            this.Size = new System.Drawing.Size(688, 483);
            ((System.ComponentModel.ISupportInitialize)(this.spltNlogParser)).EndInit();
            this.spltNlogParser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstBAnalogyColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxItemsNlog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl spltNlogParser;
        private DevExpress.XtraEditors.ListBoxControl lstBAnalogyColumns;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SimpleButton sBtnMoveUp;
        private DevExpress.XtraEditors.SimpleButton sBtnMoveDown;
        private DevExpress.XtraEditors.ListBoxControl lstBoxItemsNlog;
        private DevExpress.XtraEditors.LabelControl labelControl10;
    }
}
