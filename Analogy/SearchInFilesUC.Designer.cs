namespace Analogy
{
    partial class SearchInFilesUC
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
            this.txtbSearch = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileSystemUC1 = new Analogy.FileSystemUC();
            this.processFilesUC1 = new Analogy.FilesOperationsUC();
            this.sBtnSearch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbSearch
            // 
            this.txtbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbSearch.Location = new System.Drawing.Point(3, 5);
            this.txtbSearch.Name = "txtbSearch";
            this.txtbSearch.Size = new System.Drawing.Size(634, 30);
            this.txtbSearch.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.fileSystemUC1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.processFilesUC1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1118, 393);
            this.splitContainer1.SplitterDistance = 372;
            this.splitContainer1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sBtnSearch);
            this.panel1.Controls.Add(this.txtbSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(742, 41);
            this.panel1.TabIndex = 0;
            // 
            // fileSystemUC1
            // 
            this.fileSystemUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileSystemUC1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.fileSystemUC1.Location = new System.Drawing.Point(0, 0);
            this.fileSystemUC1.Margin = new System.Windows.Forms.Padding(4);
            this.fileSystemUC1.Name = "fileSystemUC1";
            this.fileSystemUC1.Size = new System.Drawing.Size(372, 393);
            this.fileSystemUC1.TabIndex = 0;
            // 
            // processFilesUC1
            // 
            this.processFilesUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processFilesUC1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.processFilesUC1.Location = new System.Drawing.Point(0, 41);
            this.processFilesUC1.Margin = new System.Windows.Forms.Padding(4);
            this.processFilesUC1.Name = "processFilesUC1";
            this.processFilesUC1.Size = new System.Drawing.Size(742, 352);
            this.processFilesUC1.TabIndex = 1;
            // 
            // sBtnSearch
            // 
            this.sBtnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.sBtnSearch.Location = new System.Drawing.Point(661, 0);
            this.sBtnSearch.Name = "sBtnSearch";
            this.sBtnSearch.Size = new System.Drawing.Size(81, 41);
            this.sBtnSearch.TabIndex = 4;
            this.sBtnSearch.Text = "Search";
            this.sBtnSearch.Click += new System.EventHandler(this.sBtnSearch_Click);
            // 
            // SearchInFilesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchInFilesUC";
            this.Size = new System.Drawing.Size(1118, 393);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FileSystemUC fileSystemUC1;
        private FilesOperationsUC processFilesUC1;
        private System.Windows.Forms.TextBox txtbSearch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton sBtnSearch;
    }
}
