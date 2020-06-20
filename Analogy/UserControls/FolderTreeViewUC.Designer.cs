namespace Analogy
{
    partial class FolderTreeViewUC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderTreeViewUC));
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtbFolder = new System.Windows.Forms.TextBox();
            this.btnOpenFolder = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnRecent = new DevExpress.XtraEditors.SimpleButton();
            this.cmsFolders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.xtraUCFileSystem1 = new Analogy.XtraUCFileSystem();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtbFolder);
            this.panel2.Controls.Add(this.btnOpenFolder);
            this.panel2.Controls.Add(this.sbtnRecent);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(444, 23);
            this.panel2.TabIndex = 5;
            // 
            // txtbFolder
            // 
            this.txtbFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbFolder.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbFolder.Location = new System.Drawing.Point(0, 0);
            this.txtbFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbFolder.Name = "txtbFolder";
            this.txtbFolder.Size = new System.Drawing.Size(392, 27);
            this.txtbFolder.TabIndex = 12;
            this.txtbFolder.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbFolder_KeyUp);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOpenFolder.Location = new System.Drawing.Point(392, 0);
            this.btnOpenFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(26, 23);
            this.btnOpenFolder.TabIndex = 13;
            this.btnOpenFolder.Text = "...";
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // sbtnRecent
            // 
            this.sbtnRecent.ContextMenuStrip = this.cmsFolders;
            this.sbtnRecent.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbtnRecent.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sbtnRecent.ImageOptions.Image")));
            this.sbtnRecent.Location = new System.Drawing.Point(418, 0);
            this.sbtnRecent.Margin = new System.Windows.Forms.Padding(2);
            this.sbtnRecent.Name = "sbtnRecent";
            this.sbtnRecent.Size = new System.Drawing.Size(26, 23);
            this.sbtnRecent.TabIndex = 14;
            this.sbtnRecent.ToolTip = "Recent Folders";
            this.sbtnRecent.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sbtnRecent_MouseUp);
            // 
            // cmsFolders
            // 
            this.cmsFolders.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsFolders.Name = "cmsFolders";
            this.cmsFolders.Size = new System.Drawing.Size(61, 4);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Error_16x16.png");
            this.imageList.Images.SetKeyName(1, "Warning_16x16.png");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "folder32x32.gif");
            this.imageList.Images.SetKeyName(4, "Error_32x32.png");
            this.imageList.Images.SetKeyName(5, "Warning_32x32.png");
            // 
            // xtraUCFileSystem1
            // 
            this.xtraUCFileSystem1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraUCFileSystem1.Location = new System.Drawing.Point(0, 23);
            this.xtraUCFileSystem1.Margin = new System.Windows.Forms.Padding(2);
            this.xtraUCFileSystem1.Name = "xtraUCFileSystem1";
            this.xtraUCFileSystem1.Size = new System.Drawing.Size(444, 288);
            this.xtraUCFileSystem1.TabIndex = 6;
            // 
            // FolderTreeViewUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraUCFileSystem1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.Name = "FolderTreeViewUC";
            this.Size = new System.Drawing.Size(444, 311);
            this.Load += new System.EventHandler(this.FolderTreeViewUC_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtbFolder;
        private System.Windows.Forms.ImageList imageList;
        private DevExpress.XtraEditors.SimpleButton btnOpenFolder;
        private XtraUCFileSystem xtraUCFileSystem1;
        private DevExpress.XtraEditors.SimpleButton sbtnRecent;
        private System.Windows.Forms.ContextMenuStrip cmsFolders;
    }
}
