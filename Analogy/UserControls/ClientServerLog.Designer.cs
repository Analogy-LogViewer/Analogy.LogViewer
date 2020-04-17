using DevExpress.XtraGrid.Views.Grid;

namespace Analogy
{
    partial class ClientServerUCLog
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
            if (disposing)
            {

                if (components != null)
                {
                    components.Dispose();

                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientServerUCLog));
            this.spltMain = new System.Windows.Forms.SplitContainer();
            this.splcLeft = new System.Windows.Forms.SplitContainer();
            this.lBoxSources = new DevExpress.XtraEditors.ListBoxControl();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bBtnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnRemove = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bBtnOpenFolder = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.standaloneBarDockControl2 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.lBoxFiles = new DevExpress.XtraEditors.ListBoxControl();
            this.chkbSelectionMode = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditRecursiveLoad = new DevExpress.XtraEditors.CheckEdit();
            this.ucLogs1 = new Analogy.UCLogs();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imageListBottom = new System.Windows.Forms.ImageList(this.components);
            this.tsPrimary = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).BeginInit();
            this.spltMain.Panel1.SuspendLayout();
            this.spltMain.Panel2.SuspendLayout();
            this.spltMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splcLeft)).BeginInit();
            this.splcLeft.Panel1.SuspendLayout();
            this.splcLeft.Panel2.SuspendLayout();
            this.splcLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lBoxSources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lBoxFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkbSelectionMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditRecursiveLoad.Properties)).BeginInit();
            this.tsPrimary.SuspendLayout();
            this.SuspendLayout();
            // 
            // spltMain
            // 
            this.spltMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltMain.Location = new System.Drawing.Point(0, 0);
            this.spltMain.Margin = new System.Windows.Forms.Padding(2);
            this.spltMain.Name = "spltMain";
            // 
            // spltMain.Panel1
            // 
            this.spltMain.Panel1.Controls.Add(this.splcLeft);
            // 
            // spltMain.Panel2
            // 
            this.spltMain.Panel2.Controls.Add(this.ucLogs1);
            this.spltMain.Size = new System.Drawing.Size(1040, 546);
            this.spltMain.SplitterDistance = 282;
            this.spltMain.SplitterWidth = 3;
            this.spltMain.TabIndex = 5;
            // 
            // splcLeft
            // 
            this.splcLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splcLeft.Location = new System.Drawing.Point(0, 0);
            this.splcLeft.Margin = new System.Windows.Forms.Padding(2);
            this.splcLeft.Name = "splcLeft";
            this.splcLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splcLeft.Panel1
            // 
            this.splcLeft.Panel1.Controls.Add(this.lBoxSources);
            this.splcLeft.Panel1.Controls.Add(this.standaloneBarDockControl1);
            // 
            // splcLeft.Panel2
            // 
            this.splcLeft.Panel2.Controls.Add(this.lBoxFiles);
            this.splcLeft.Panel2.Controls.Add(this.standaloneBarDockControl2);
            this.splcLeft.Panel2.Controls.Add(this.chkbSelectionMode);
            this.splcLeft.Panel2.Controls.Add(this.checkEditRecursiveLoad);
            this.splcLeft.Size = new System.Drawing.Size(282, 546);
            this.splcLeft.SplitterDistance = 191;
            this.splcLeft.SplitterWidth = 3;
            this.splcLeft.TabIndex = 4;
            // 
            // lBoxSources
            // 
            this.lBoxSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lBoxSources.Location = new System.Drawing.Point(0, 31);
            this.lBoxSources.Margin = new System.Windows.Forms.Padding(2);
            this.lBoxSources.Name = "lBoxSources";
            this.lBoxSources.Size = new System.Drawing.Size(282, 160);
            this.lBoxSources.TabIndex = 1;
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.AutoSize = true;
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 0);
            this.standaloneBarDockControl1.Manager = this.barManager1;
            this.standaloneBarDockControl1.Margin = new System.Windows.Forms.Padding(2);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(282, 31);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3,
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl2);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bBtnAdd,
            this.bBtnRemove,
            this.bBtnOpenFolder,
            this.bBtnRefresh,
            this.bBtnDelete});
            this.barManager1.MaxItemId = 5;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Sources";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.FloatLocation = new System.Drawing.Point(87, 205);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnRemove)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar1.Text = "Sources";
            // 
            // bBtnAdd
            // 
            this.bBtnAdd.Caption = "Add";
            this.bBtnAdd.Id = 0;
            this.bBtnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnAdd.ImageOptions.Image")));
            this.bBtnAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnAdd.ImageOptions.LargeImage")));
            this.bBtnAdd.Name = "bBtnAdd";
            this.bBtnAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnAdd_ItemClick);
            // 
            // bBtnRemove
            // 
            this.bBtnRemove.Caption = "Remove";
            this.bBtnRemove.Id = 1;
            this.bBtnRemove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnRemove.ImageOptions.Image")));
            this.bBtnRemove.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnRemove.ImageOptions.LargeImage")));
            this.bBtnRemove.Name = "bBtnRemove";
            this.bBtnRemove.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnRemove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnRemove_ItemClick);
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
            // bar2
            // 
            this.bar2.BarName = "Custom 4";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar2.FloatLocation = new System.Drawing.Point(346, 374);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnOpenFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnDelete)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.StandaloneBarDockControl = this.standaloneBarDockControl2;
            this.bar2.Text = "Custom 4";
            // 
            // bBtnOpenFolder
            // 
            this.bBtnOpenFolder.Caption = "Open";
            this.bBtnOpenFolder.Id = 2;
            this.bBtnOpenFolder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnOpenFolder.ImageOptions.Image")));
            this.bBtnOpenFolder.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnOpenFolder.ImageOptions.LargeImage")));
            this.bBtnOpenFolder.Name = "bBtnOpenFolder";
            this.bBtnOpenFolder.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnOpenFolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnOpenFolder_ItemClick);
            // 
            // bBtnRefresh
            // 
            this.bBtnRefresh.Caption = "Refresh";
            this.bBtnRefresh.Id = 3;
            this.bBtnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnRefresh.ImageOptions.Image")));
            this.bBtnRefresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnRefresh.ImageOptions.LargeImage")));
            this.bBtnRefresh.Name = "bBtnRefresh";
            this.bBtnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnRefresh_ItemClick);
            // 
            // bBtnDelete
            // 
            this.bBtnDelete.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bBtnDelete.Caption = "Delete";
            this.bBtnDelete.Id = 4;
            this.bBtnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnDelete.ImageOptions.Image")));
            this.bBtnDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnDelete.ImageOptions.LargeImage")));
            this.bBtnDelete.Name = "bBtnDelete";
            this.bBtnDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnDelete_ItemClick);
            // 
            // standaloneBarDockControl2
            // 
            this.standaloneBarDockControl2.CausesValidation = false;
            this.standaloneBarDockControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl2.Location = new System.Drawing.Point(0, 38);
            this.standaloneBarDockControl2.Manager = this.barManager1;
            this.standaloneBarDockControl2.Margin = new System.Windows.Forms.Padding(2);
            this.standaloneBarDockControl2.Name = "standaloneBarDockControl2";
            this.standaloneBarDockControl2.Size = new System.Drawing.Size(282, 30);
            this.standaloneBarDockControl2.Text = "standaloneBarDockControl2";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlTop.Size = new System.Drawing.Size(1040, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 546);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1040, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 546);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1040, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 546);
            // 
            // lBoxFiles
            // 
            this.lBoxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lBoxFiles.HorizontalScrollbar = true;
            this.lBoxFiles.Location = new System.Drawing.Point(0, 68);
            this.lBoxFiles.Margin = new System.Windows.Forms.Padding(2);
            this.lBoxFiles.Name = "lBoxFiles";
            this.lBoxFiles.Size = new System.Drawing.Size(282, 284);
            this.lBoxFiles.TabIndex = 3;
            // 
            // chkbSelectionMode
            // 
            this.chkbSelectionMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkbSelectionMode.EditValue = true;
            this.chkbSelectionMode.Location = new System.Drawing.Point(0, 19);
            this.chkbSelectionMode.Margin = new System.Windows.Forms.Padding(2);
            this.chkbSelectionMode.MenuManager = this.barManager1;
            this.chkbSelectionMode.Name = "chkbSelectionMode";
            this.chkbSelectionMode.Properties.Caption = "Clear log between selection";
            this.chkbSelectionMode.Properties.ImageOptions.ImageChecked = ((System.Drawing.Image)(resources.GetObject("chkbSelectionMode.Properties.ImageOptions.ImageChecked")));
            this.chkbSelectionMode.Properties.ImageOptions.ImageUnchecked = ((System.Drawing.Image)(resources.GetObject("chkbSelectionMode.Properties.ImageOptions.ImageUnchecked")));
            this.chkbSelectionMode.Size = new System.Drawing.Size(282, 19);
            this.chkbSelectionMode.TabIndex = 4;
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
            this.checkEditRecursiveLoad.Size = new System.Drawing.Size(282, 19);
            this.checkEditRecursiveLoad.TabIndex = 8;
            // 
            // ucLogs1
            // 
            this.ucLogs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLogs1.Location = new System.Drawing.Point(0, 0);
            this.ucLogs1.Margin = new System.Windows.Forms.Padding(2);
            this.ucLogs1.Name = "ucLogs1";
            this.ucLogs1.Size = new System.Drawing.Size(755, 546);
            this.ucLogs1.TabIndex = 0;
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
            // imageListBottom
            // 
            this.imageListBottom.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBottom.ImageStream")));
            this.imageListBottom.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListBottom.Images.SetKeyName(0, "Info_16x16.png");
            this.imageListBottom.Images.SetKeyName(1, "RichEditBookmark_16x16.png");
            this.imageListBottom.Images.SetKeyName(2, "RichEditBookmark_32x32.png");
            // 
            // tsPrimary
            // 
            this.tsPrimary.AutoSize = false;
            this.tsPrimary.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsPrimary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1});
            this.tsPrimary.Location = new System.Drawing.Point(0, 0);
            this.tsPrimary.Name = "tsPrimary";
            this.tsPrimary.Size = new System.Drawing.Size(1040, 37);
            this.tsPrimary.TabIndex = 6;
            this.tsPrimary.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 37);
            // 
            // ClientServerUCLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spltMain);
            this.Controls.Add(this.tsPrimary);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClientServerUCLog";
            this.Size = new System.Drawing.Size(1040, 569);
            this.Load += new System.EventHandler(this.ClientServerUCLog_Load);
            this.spltMain.Panel1.ResumeLayout(false);
            this.spltMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).EndInit();
            this.spltMain.ResumeLayout(false);
            this.splcLeft.Panel1.ResumeLayout(false);
            this.splcLeft.Panel1.PerformLayout();
            this.splcLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splcLeft)).EndInit();
            this.splcLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lBoxSources)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lBoxFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkbSelectionMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditRecursiveLoad.Properties)).EndInit();
            this.tsPrimary.ResumeLayout(false);
            this.tsPrimary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer spltMain;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStrip tsPrimary;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splcLeft;
        private System.Windows.Forms.ImageList imageListBottom;
        private UCLogs ucLogs1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarButtonItem bBtnAdd;
        private DevExpress.XtraBars.BarButtonItem bBtnRemove;
        private DevExpress.XtraEditors.ListBoxControl lBoxSources;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bBtnOpenFolder;
        private DevExpress.XtraBars.BarButtonItem bBtnRefresh;
        private DevExpress.XtraBars.BarButtonItem bBtnDelete;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl2;
        private DevExpress.XtraEditors.ListBoxControl lBoxFiles;
        private DevExpress.XtraEditors.CheckEdit chkbSelectionMode;
        private DevExpress.XtraEditors.CheckEdit checkEditRecursiveLoad;
    }
}
