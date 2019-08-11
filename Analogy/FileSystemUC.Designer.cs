namespace Philips.Analogy
{
    partial class FileSystemUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSystemUC));
            this.splcLeft = new System.Windows.Forms.SplitContainer();
            this.tvFolderUC = new Philips.Analogy.FolderTreeViewUC();
            this.lBoxFiles = new DevExpress.XtraEditors.ListBoxControl();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bBtnOpen = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.checkEditRecursiveLoad = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splcLeft)).BeginInit();
            this.splcLeft.Panel1.SuspendLayout();
            this.splcLeft.Panel2.SuspendLayout();
            this.splcLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lBoxFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditRecursiveLoad.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splcLeft
            // 
            this.splcLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splcLeft.Location = new System.Drawing.Point(0, 20);
            this.splcLeft.Margin = new System.Windows.Forms.Padding(2);
            this.splcLeft.Name = "splcLeft";
            this.splcLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splcLeft.Panel1
            // 
            this.splcLeft.Panel1.Controls.Add(this.tvFolderUC);
            // 
            // splcLeft.Panel2
            // 
            this.splcLeft.Panel2.Controls.Add(this.lBoxFiles);
            this.splcLeft.Panel2.Controls.Add(this.standaloneBarDockControl1);
            this.splcLeft.Panel2.Controls.Add(this.checkEditRecursiveLoad);
            this.splcLeft.Size = new System.Drawing.Size(392, 323);
            this.splcLeft.SplitterDistance = 153;
            this.splcLeft.SplitterWidth = 3;
            this.splcLeft.TabIndex = 5;
            // 
            // tvFolderUC
            // 
            this.tvFolderUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFolderUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.tvFolderUC.Location = new System.Drawing.Point(0, 0);
            this.tvFolderUC.Name = "tvFolderUC";
            this.tvFolderUC.Size = new System.Drawing.Size(392, 153);
            this.tvFolderUC.TabIndex = 0;
            // 
            // lBoxFiles
            // 
            this.lBoxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lBoxFiles.HorizontalScrollbar = true;
            this.lBoxFiles.Location = new System.Drawing.Point(0, 47);
            this.lBoxFiles.Margin = new System.Windows.Forms.Padding(2);
            this.lBoxFiles.Name = "lBoxFiles";
            this.lBoxFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lBoxFiles.Size = new System.Drawing.Size(392, 120);
            this.lBoxFiles.TabIndex = 6;
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 19);
            this.standaloneBarDockControl1.Manager = this.barManager1;
            this.standaloneBarDockControl1.Margin = new System.Windows.Forms.Padding(2);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(392, 28);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bBtnOpen});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.FloatLocation = new System.Drawing.Point(70, 278);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnOpen)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar1.Text = "Tools";
            // 
            // bBtnOpen
            // 
            this.bBtnOpen.Caption = "Open";
            this.bBtnOpen.Id = 0;
            this.bBtnOpen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnOpen.ImageOptions.Image")));
            this.bBtnOpen.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnOpen.ImageOptions.LargeImage")));
            this.bBtnOpen.Name = "bBtnOpen";
            this.bBtnOpen.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnOpen_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.bar2.Visible = false;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            this.bar3.Visible = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlTop.Size = new System.Drawing.Size(392, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 343);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlBottom.Size = new System.Drawing.Size(392, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 323);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(392, 20);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 323);
            // 
            // checkEditRecursiveLoad
            // 
            this.checkEditRecursiveLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkEditRecursiveLoad.EditValue = true;
            this.checkEditRecursiveLoad.Location = new System.Drawing.Point(0, 0);
            this.checkEditRecursiveLoad.Margin = new System.Windows.Forms.Padding(2);
            this.checkEditRecursiveLoad.Name = "checkEditRecursiveLoad";
            this.checkEditRecursiveLoad.Properties.Caption = "Load Recursive Files";
            this.checkEditRecursiveLoad.Properties.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("checkEditRecursiveLoad.Properties.ImageOptions.ImageChecked")));
            this.checkEditRecursiveLoad.Properties.ImageOptions.ImageUnchecked = ((System.Drawing.Image)(resources.GetObject("checkEditRecursiveLoad.Properties.ImageOptions.ImageUnchecked")));
            this.checkEditRecursiveLoad.Size = new System.Drawing.Size(392, 19);
            this.checkEditRecursiveLoad.TabIndex = 8;
            // 
            // FileSystemUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splcLeft);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FileSystemUC";
            this.Size = new System.Drawing.Size(392, 366);
            this.Load += new System.EventHandler(this.FileSystemUC_Load);
            this.splcLeft.Panel1.ResumeLayout(false);
            this.splcLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splcLeft)).EndInit();
            this.splcLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lBoxFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditRecursiveLoad.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splcLeft;
        private FolderTreeViewUC tvFolderUC;
        private DevExpress.XtraEditors.ListBoxControl lBoxFiles;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bBtnOpen;
        private DevExpress.XtraEditors.CheckEdit checkEditRecursiveLoad;
    }
}
