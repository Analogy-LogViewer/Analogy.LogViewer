
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
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barMain = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
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
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(50, 55);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(1117, 579);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1});
            this.accordionControl1.Location = new System.Drawing.Point(0, 55);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(50, 579);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Element1";
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
            this.barButtonItem1,
            this.bbtnStar,
            this.bbiFileCaching,
            this.bbtnErrors,
            this.bbtnCheckUpdates,
            this.bbtnReportIssueOrRequest,
            this.bbtnIdleMessage,
            this.bbtnMemoryUsage});
            this.barManager1.MainMenu = this.barMain;
            this.barManager1.MaxItemId = 8;
            this.barManager1.StatusBar = this.barButtom;
            // 
            // barMain
            // 
            this.barMain.BarName = "Main menu";
            this.barMain.DockCol = 0;
            this.barMain.DockRow = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.barMain.OptionsBar.MultiLine = true;
            this.barMain.OptionsBar.UseWholeRow = true;
            this.barMain.Text = "Main menu";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "File";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 634);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1167, 32);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 55);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 579);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1167, 55);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 579);
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
            // FluentDesignMainForm
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 666);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "FluentDesignMainForm";
            this.NavigationControl = this.accordionControl1;
            this.Text = "FluentDesignMainForm";
            this.Load += new System.EventHandler(this.FluentDesignMainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
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
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
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
    }
}