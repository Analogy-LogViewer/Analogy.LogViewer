namespace Analogy
{
    partial class CombineFilesUC
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._folderAndFileSystemUc1 = new Analogy.FolderAndFileSystemUC();
            this.processFilesUC1 = new Analogy.FilesOperationsUC();
            this.panel3 = new System.Windows.Forms.Panel();
            this.sBtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnCombined = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._folderAndFileSystemUc1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.processFilesUC1);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(1018, 569);
            this.splitContainer1.SplitterDistance = 336;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 5;
            // 
            // fileSystemUC1
            // 
            this._folderAndFileSystemUc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._folderAndFileSystemUc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this._folderAndFileSystemUc1.Location = new System.Drawing.Point(0, 0);
            this._folderAndFileSystemUc1.Margin = new System.Windows.Forms.Padding(6);
            this._folderAndFileSystemUc1.Name = "_folderAndFileSystemUc1";
            this._folderAndFileSystemUc1.Size = new System.Drawing.Size(336, 569);
            this._folderAndFileSystemUc1.TabIndex = 0;
            // 
            // processFilesUC1
            // 
            this.processFilesUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processFilesUC1.Location = new System.Drawing.Point(0, 40);
            this.processFilesUC1.Margin = new System.Windows.Forms.Padding(6);
            this.processFilesUC1.Name = "processFilesUC1";
            this.processFilesUC1.Size = new System.Drawing.Size(676, 529);
            this.processFilesUC1.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.sBtnSave);
            this.panel3.Controls.Add(this.sBtnCombined);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(676, 40);
            this.panel3.TabIndex = 11;
            // 
            // sBtnSave
            // 
            this.sBtnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.sBtnSave.Location = new System.Drawing.Point(506, 0);
            this.sBtnSave.Margin = new System.Windows.Forms.Padding(4);
            this.sBtnSave.Name = "sBtnSave";
            this.sBtnSave.Size = new System.Drawing.Size(170, 40);
            this.sBtnSave.TabIndex = 12;
            this.sBtnSave.Text = "Save result";
            this.sBtnSave.Click += new System.EventHandler(this.sBtnSave_Click);
            // 
            // sBtnCombined
            // 
            this.sBtnCombined.Dock = System.Windows.Forms.DockStyle.Left;
            this.sBtnCombined.Location = new System.Drawing.Point(0, 0);
            this.sBtnCombined.Margin = new System.Windows.Forms.Padding(4);
            this.sBtnCombined.Name = "sBtnCombined";
            this.sBtnCombined.Size = new System.Drawing.Size(250, 40);
            this.sBtnCombined.TabIndex = 11;
            this.sBtnCombined.Text = "Combine selected Files";
            this.sBtnCombined.Click += new System.EventHandler(this.sBtnCombined_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 0;
            // 
            // CombineFilesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CombineFilesUC";
            this.Size = new System.Drawing.Size(1018, 569);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private FolderAndFileSystemUC _folderAndFileSystemUc1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private FilesOperationsUC processFilesUC1;
        private DevExpress.XtraEditors.SimpleButton sBtnSave;
        private DevExpress.XtraEditors.SimpleButton sBtnCombined;
    }
}
