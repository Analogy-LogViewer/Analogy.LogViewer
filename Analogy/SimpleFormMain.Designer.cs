namespace Philips.Analogy
{
    partial class SimpleFormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleFormMain));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.bsiFile = new DevExpress.XtraBars.BarSubItem();
            this.bBtnServerLog = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnFileLog = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnSettings = new DevExpress.XtraBars.BarButtonItem();
            this.BBtnExit = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barIcons = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.xtcLogs = new DevExpress.XtraTab.XtraTabControl();
            this.TmrAutoConnect = new System.Windows.Forms.Timer(this.components);
            this.bBtnRealTime = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnOpenFile = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMenu,
            this.bar3,
            this.barIcons});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bsiFile,
            this.bBtnServerLog,
            this.bBtnFileLog,
            this.bBtnSettings,
            this.BBtnExit,
            this.bBtnRealTime,
            this.bBtnOpenFile});
            this.barManager1.MainMenu = this.barMenu;
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // barMenu
            // 
            this.barMenu.BarName = "Main menu";
            this.barMenu.DockCol = 0;
            this.barMenu.DockRow = 0;
            this.barMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiFile)});
            this.barMenu.OptionsBar.AllowQuickCustomization = false;
            this.barMenu.OptionsBar.DisableClose = true;
            this.barMenu.OptionsBar.MultiLine = true;
            this.barMenu.OptionsBar.UseWholeRow = true;
            this.barMenu.Text = "Main menu";
            // 
            // bsiFile
            // 
            this.bsiFile.Caption = "File";
            this.bsiFile.Id = 0;
            this.bsiFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnServerLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnFileLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnSettings),
            new DevExpress.XtraBars.LinkPersistInfo(this.BBtnExit)});
            this.bsiFile.Name = "bsiFile";
            // 
            // bBtnServerLog
            // 
            this.bBtnServerLog.Caption = "Open Real Time Server Log";
            this.bBtnServerLog.Id = 1;
            this.bBtnServerLog.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnServerLog.ImageOptions.Image")));
            this.bBtnServerLog.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnServerLog.ImageOptions.LargeImage")));
            this.bBtnServerLog.Name = "bBtnServerLog";
            this.bBtnServerLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnServerLog_ItemClick);
            // 
            // bBtnFileLog
            // 
            this.bBtnFileLog.Caption = "Open File Log";
            this.bBtnFileLog.Id = 2;
            this.bBtnFileLog.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnFileLog.ImageOptions.Image")));
            this.bBtnFileLog.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnFileLog.ImageOptions.LargeImage")));
            this.bBtnFileLog.Name = "bBtnFileLog";
            this.bBtnFileLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnFileLog_ItemClick);
            // 
            // bBtnSettings
            // 
            this.bBtnSettings.Caption = "Settings";
            this.bBtnSettings.Id = 3;
            this.bBtnSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnSettings.ImageOptions.Image")));
            this.bBtnSettings.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnSettings.ImageOptions.LargeImage")));
            this.bBtnSettings.Name = "bBtnSettings";
            this.bBtnSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnSettings_ItemClick);
            // 
            // BBtnExit
            // 
            this.BBtnExit.Caption = "Exit";
            this.BBtnExit.Id = 4;
            this.BBtnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BBtnExit.ImageOptions.Image")));
            this.BBtnExit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BBtnExit.ImageOptions.LargeImage")));
            this.BBtnExit.Name = "BBtnExit";
            this.BBtnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BBtnExit_ItemClick);
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
            // barIcons
            // 
            this.barIcons.BarName = "Operations";
            this.barIcons.DockCol = 0;
            this.barIcons.DockRow = 1;
            this.barIcons.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barIcons.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnRealTime),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnOpenFile)});
            this.barIcons.OptionsBar.AllowQuickCustomization = false;
            this.barIcons.OptionsBar.DisableClose = true;
            this.barIcons.OptionsBar.DisableCustomization = true;
            this.barIcons.OptionsBar.UseWholeRow = true;
            this.barIcons.Text = "Custom 4";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(992, 66);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 342);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(992, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 66);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 276);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(992, 66);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 276);
            // 
            // xtcLogs
            // 
            this.xtcLogs.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtcLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtcLogs.Location = new System.Drawing.Point(0, 66);
            this.xtcLogs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtcLogs.Name = "xtcLogs";
            this.xtcLogs.Size = new System.Drawing.Size(992, 276);
            this.xtcLogs.TabIndex = 5;
            // 
            // TmrAutoConnect
            // 
            this.TmrAutoConnect.Enabled = true;
            this.TmrAutoConnect.Interval = 1000;
            this.TmrAutoConnect.Tick += new System.EventHandler(this.TmrAutoConnect_Tick);
            // 
            // bBtnRealTime
            // 
            this.bBtnRealTime.Caption = "Real Time Log";
            this.bBtnRealTime.Id = 5;
            this.bBtnRealTime.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnRealTime.ImageOptions.Image")));
            this.bBtnRealTime.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnRealTime.ImageOptions.LargeImage")));
            this.bBtnRealTime.Name = "bBtnRealTime";
            this.bBtnRealTime.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnRealTime.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnRealTime_ItemClick);
            // 
            // bBtnOpenFile
            // 
            this.bBtnOpenFile.Caption = "Open File";
            this.bBtnOpenFile.Id = 6;
            this.bBtnOpenFile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnOpenFile.ImageOptions.Image")));
            this.bBtnOpenFile.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnOpenFile.ImageOptions.LargeImage")));
            this.bBtnOpenFile.Name = "bBtnOpenFile";
            this.bBtnOpenFile.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnOpenFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnOpenFile_ItemClick);
            // 
            // SimpleFormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 366);
            this.Controls.Add(this.xtcLogs);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SimpleFormMain";
            this.Text = "Analogy - Simple Mode";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SimpleFormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barMenu;
        private DevExpress.XtraBars.BarSubItem bsiFile;
        private DevExpress.XtraBars.BarButtonItem bBtnServerLog;
        private DevExpress.XtraBars.BarButtonItem bBtnFileLog;
        private DevExpress.XtraBars.BarButtonItem bBtnSettings;
        private DevExpress.XtraBars.BarButtonItem BBtnExit;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTab.XtraTabControl xtcLogs;
        private System.Windows.Forms.Timer TmrAutoConnect;
        private DevExpress.XtraBars.Bar barIcons;
        private DevExpress.XtraBars.BarButtonItem bBtnRealTime;
        private DevExpress.XtraBars.BarButtonItem bBtnOpenFile;
    }
}