
namespace Analogy
{
    partial class FluentDesignMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FluentDesignMainForm));
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barMain = new DevExpress.XtraBars.Bar();
            this.barButtom = new DevExpress.XtraBars.Bar();
            this.bbtnStar = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFileCaching = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnReportIssueOrRequest = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnCheckUpdates = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnIdleMessage = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnMemoryUsage = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnErrors = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.notifyIconAnalogy = new System.Windows.Forms.NotifyIcon(this.components);
            this.defaultToolTipController1 = new DevExpress.Utils.DefaultToolTipController(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TmrAutoConnect = new System.Windows.Forms.Timer(this.components);
            this.tmrStatusUpdates = new System.Windows.Forms.Timer(this.components);
            this.bsiFile = new DevExpress.XtraBars.BarSubItem();
            this.bsiDataProviders = new DevExpress.XtraBars.BarSubItem();
            this.bsiGlobalTools = new DevExpress.XtraBars.BarSubItem();
            this.bsiHelp = new DevExpress.XtraBars.BarSubItem();
            this.bbtnWhatsNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnFirstRun = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnItemChangeLog = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnDebugLog = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnUpdates = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnDataProvidersUpdates = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUserSettingsStatistics = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnItemHelp = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.fluentDesignFormContainer1, DevExpress.Utils.DefaultBoolean.Default);
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(312, 55);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(855, 708);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // accordionControl
            // 
            this.accordionControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl.Location = new System.Drawing.Point(0, 55);
            this.accordionControl.Name = "accordionControl";
            this.accordionControl.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl.Size = new System.Drawing.Size(312, 708);
            this.accordionControl.TabIndex = 1;
            this.accordionControl.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1167, 30);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMain,
            this.barButtom});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbtnStar,
            this.bbiFileCaching,
            this.bbtnErrors,
            this.bbtnCheckUpdates,
            this.bbtnReportIssueOrRequest,
            this.bbtnIdleMessage,
            this.bbtnMemoryUsage,
            this.bsiFile,
            this.bsiDataProviders,
            this.bsiGlobalTools,
            this.bsiHelp,
            this.bbtnWhatsNew,
            this.bbtnFirstRun,
            this.bbtnItemChangeLog,
            this.bbtnDebugLog,
            this.bbtnUpdates,
            this.bbtnDataProvidersUpdates,
            this.bbiUserSettingsStatistics,
            this.bbtnItemHelp});
            this.barManager1.MainMenu = this.barMain;
            this.barManager1.MaxItemId = 24;
            this.barManager1.StatusBar = this.barButtom;
            // 
            // barMain
            // 
            this.barMain.BarName = "Main menu";
            this.barMain.DockCol = 0;
            this.barMain.DockRow = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiFile),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiDataProviders),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiGlobalTools),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiHelp)});
            this.barMain.OptionsBar.MultiLine = true;
            this.barMain.OptionsBar.UseWholeRow = true;
            this.barMain.Text = "Main menu";
            // 
            // barButtom
            // 
            this.barButtom.BarName = "Status bar";
            this.barButtom.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barButtom.DockCol = 0;
            this.barButtom.DockRow = 0;
            this.barButtom.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barButtom.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnStar),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiFileCaching),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnReportIssueOrRequest),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnCheckUpdates),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnIdleMessage),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnMemoryUsage),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnErrors)});
            this.barButtom.OptionsBar.AllowQuickCustomization = false;
            this.barButtom.OptionsBar.DisableClose = true;
            this.barButtom.OptionsBar.DisableCustomization = true;
            this.barButtom.OptionsBar.DrawDragBorder = false;
            this.barButtom.OptionsBar.UseWholeRow = true;
            this.barButtom.Text = "Status bar";
            // 
            // bbtnStar
            // 
            this.bbtnStar.Caption = "GitHub";
            this.bbtnStar.Id = 1;
            this.bbtnStar.ImageOptions.Image = global::Analogy.Properties.Resources.github16x16;
            this.bbtnStar.Name = "bbtnStar";
            this.bbtnStar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiFileCaching
            // 
            this.bbiFileCaching.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbiFileCaching.Caption = "File caching mode";
            this.bbiFileCaching.Id = 2;
            this.bbiFileCaching.Name = "bbiFileCaching";
            // 
            // bbtnReportIssueOrRequest
            // 
            this.bbtnReportIssueOrRequest.Caption = "Report Issue Or Request";
            this.bbtnReportIssueOrRequest.Id = 5;
            this.bbtnReportIssueOrRequest.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnReportIssueOrRequest.ImageOptions.Image")));
            this.bbtnReportIssueOrRequest.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbtnReportIssueOrRequest.ImageOptions.LargeImage")));
            this.bbtnReportIssueOrRequest.Name = "bbtnReportIssueOrRequest";
            this.bbtnReportIssueOrRequest.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbtnCheckUpdates
            // 
            this.bbtnCheckUpdates.Caption = "Check For Update";
            this.bbtnCheckUpdates.Id = 4;
            this.bbtnCheckUpdates.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnCheckUpdates.ImageOptions.Image")));
            this.bbtnCheckUpdates.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbtnCheckUpdates.ImageOptions.LargeImage")));
            this.bbtnCheckUpdates.Name = "bbtnCheckUpdates";
            this.bbtnCheckUpdates.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbtnIdleMessage
            // 
            this.bbtnIdleMessage.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbtnIdleMessage.Caption = "Idle mode";
            this.bbtnIdleMessage.Id = 6;
            this.bbtnIdleMessage.Name = "bbtnIdleMessage";
            // 
            // bbtnMemoryUsage
            // 
            this.bbtnMemoryUsage.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbtnMemoryUsage.Caption = "Memory Usage";
            this.bbtnMemoryUsage.Id = 7;
            this.bbtnMemoryUsage.Name = "bbtnMemoryUsage";
            // 
            // bbtnErrors
            // 
            this.bbtnErrors.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbtnErrors.Caption = "Errors";
            this.bbtnErrors.Id = 3;
            this.bbtnErrors.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnErrors.ImageOptions.Image")));
            this.bbtnErrors.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbtnErrors.ImageOptions.LargeImage")));
            this.bbtnErrors.Name = "bbtnErrors";
            this.bbtnErrors.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 30);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1167, 25);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 763);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1167, 32);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 55);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 708);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1167, 55);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 708);
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.MenuManager = this.barManager1;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // notifyIconAnalogy
            // 
            this.notifyIconAnalogy.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconAnalogy.Icon")));
            this.notifyIconAnalogy.Text = "Analogy";
            this.notifyIconAnalogy.Visible = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pause.png");
            this.imageList1.Images.SetKeyName(1, "play.jpg");
            this.imageList1.Images.SetKeyName(2, "54834.png");
            this.imageList1.Images.SetKeyName(3, "json.png");
            // 
            // TmrAutoConnect
            // 
            this.TmrAutoConnect.Enabled = true;
            this.TmrAutoConnect.Interval = 1000;
            // 
            // tmrStatusUpdates
            // 
            this.tmrStatusUpdates.Enabled = true;
            this.tmrStatusUpdates.Interval = 1000;
            // 
            // bsiFile
            // 
            this.bsiFile.Caption = "File";
            this.bsiFile.Id = 12;
            this.bsiFile.Name = "bsiFile";
            // 
            // bsiDataProviders
            // 
            this.bsiDataProviders.Caption = "Data Providers";
            this.bsiDataProviders.Id = 13;
            this.bsiDataProviders.Name = "bsiDataProviders";
            // 
            // bsiGlobalTools
            // 
            this.bsiGlobalTools.Caption = "Global Tools";
            this.bsiGlobalTools.Id = 14;
            this.bsiGlobalTools.Name = "bsiGlobalTools";
            // 
            // bsiHelp
            // 
            this.bsiHelp.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiHelp.Caption = "Help";
            this.bsiHelp.Id = 15;
            this.bsiHelp.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnWhatsNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnFirstRun),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnItemChangeLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnDebugLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnUpdates),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnDataProvidersUpdates),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiUserSettingsStatistics),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnItemHelp)});
            this.bsiHelp.Name = "bsiHelp";
            // 
            // bbtnWhatsNew
            // 
            this.bbtnWhatsNew.Caption = "What\'s New";
            this.bbtnWhatsNew.Id = 16;
            this.bbtnWhatsNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnWhatsNew.ImageOptions.Image")));
            this.bbtnWhatsNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbtnWhatsNew.ImageOptions.LargeImage")));
            this.bbtnWhatsNew.Name = "bbtnWhatsNew";
            // 
            // bbtnFirstRun
            // 
            this.bbtnFirstRun.Caption = "Show first run window";
            this.bbtnFirstRun.Id = 17;
            this.bbtnFirstRun.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnFirstRun.ImageOptions.Image")));
            this.bbtnFirstRun.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbtnFirstRun.ImageOptions.LargeImage")));
            this.bbtnFirstRun.Name = "bbtnFirstRun";
            // 
            // bbtnItemChangeLog
            // 
            this.bbtnItemChangeLog.Caption = "Change Log";
            this.bbtnItemChangeLog.Id = 18;
            this.bbtnItemChangeLog.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnItemChangeLog.ImageOptions.Image")));
            this.bbtnItemChangeLog.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbtnItemChangeLog.ImageOptions.LargeImage")));
            this.bbtnItemChangeLog.Name = "bbtnItemChangeLog";
            // 
            // bbtnDebugLog
            // 
            this.bbtnDebugLog.Caption = "Internal log";
            this.bbtnDebugLog.Id = 19;
            this.bbtnDebugLog.ImageOptions.Image = global::Analogy.Properties.Resources.Analogy_image_16x16;
            this.bbtnDebugLog.Name = "bbtnDebugLog";
            // 
            // bbtnUpdates
            // 
            this.bbtnUpdates.Caption = "Check for Updates";
            this.bbtnUpdates.Id = 20;
            this.bbtnUpdates.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnUpdates.ImageOptions.Image")));
            this.bbtnUpdates.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbtnUpdates.ImageOptions.LargeImage")));
            this.bbtnUpdates.Name = "bbtnUpdates";
            // 
            // bbtnDataProvidersUpdates
            // 
            this.bbtnDataProvidersUpdates.Caption = "Check for Updates (Data Providers)";
            this.bbtnDataProvidersUpdates.Id = 21;
            this.bbtnDataProvidersUpdates.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnDataProvidersUpdates.ImageOptions.Image")));
            this.bbtnDataProvidersUpdates.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbtnDataProvidersUpdates.ImageOptions.LargeImage")));
            this.bbtnDataProvidersUpdates.Name = "bbtnDataProvidersUpdates";
            // 
            // bbiUserSettingsStatistics
            // 
            this.bbiUserSettingsStatistics.Caption = "User Statistics";
            this.bbiUserSettingsStatistics.Id = 22;
            this.bbiUserSettingsStatistics.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiUserSettingsStatistics.ImageOptions.Image")));
            this.bbiUserSettingsStatistics.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiUserSettingsStatistics.ImageOptions.LargeImage")));
            this.bbiUserSettingsStatistics.Name = "bbiUserSettingsStatistics";
            // 
            // bbtnItemHelp
            // 
            this.bbtnItemHelp.Caption = "About";
            this.bbtnItemHelp.Id = 23;
            this.bbtnItemHelp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnItemHelp.ImageOptions.Image")));
            this.bbtnItemHelp.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbtnItemHelp.ImageOptions.LargeImage")));
            this.bbtnItemHelp.Name = "bbtnItemHelp";
            // 
            // FluentDesignMainForm
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 795);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.accordionControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.MinimumSize = new System.Drawing.Size(10, 800);
            this.Name = "FluentDesignMainForm";
            this.NavigationControl = this.accordionControl;
            this.Text = "Analogy";
            this.Load += new System.EventHandler(this.FluentDesignMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.Bar barButtom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem bbtnStar;
        private DevExpress.Utils.DefaultToolTipController defaultToolTipController1;
        private System.Windows.Forms.NotifyIcon notifyIconAnalogy;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer TmrAutoConnect;
        private System.Windows.Forms.Timer tmrStatusUpdates;
        private DevExpress.XtraBars.BarButtonItem bbiFileCaching;
        private DevExpress.XtraBars.BarButtonItem bbtnErrors;
        private DevExpress.XtraBars.BarButtonItem bbtnCheckUpdates;
        private DevExpress.XtraBars.BarButtonItem bbtnReportIssueOrRequest;
        private DevExpress.XtraBars.BarButtonItem bbtnIdleMessage;
        private DevExpress.XtraBars.BarButtonItem bbtnMemoryUsage;
        private DevExpress.XtraBars.BarSubItem bsiFile;
        private DevExpress.XtraBars.BarSubItem bsiDataProviders;
        private DevExpress.XtraBars.BarSubItem bsiGlobalTools;
        private DevExpress.XtraBars.BarSubItem bsiHelp;
        private DevExpress.XtraBars.BarButtonItem bbtnWhatsNew;
        private DevExpress.XtraBars.BarButtonItem bbtnFirstRun;
        private DevExpress.XtraBars.BarButtonItem bbtnItemChangeLog;
        private DevExpress.XtraBars.BarButtonItem bbtnDebugLog;
        private DevExpress.XtraBars.BarButtonItem bbtnUpdates;
        private DevExpress.XtraBars.BarButtonItem bbtnDataProvidersUpdates;
        private DevExpress.XtraBars.BarButtonItem bbiUserSettingsStatistics;
        private DevExpress.XtraBars.BarButtonItem bbtnItemHelp;
    }
}