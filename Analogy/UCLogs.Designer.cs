using DevExpress.XtraGrid.Views.Grid;

namespace Philips.Analogy
{
    partial class UCLogs
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
            if (DesignMode) return;
            tmrNewData.Stop();
            tmrNewData.Dispose();
            tmrRefreshFilter.Stop();
            tmrRefreshFilter.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCLogs));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.cmsMessageOperation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiClearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiREmoveAllPreviousMessages = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTimeDiff = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBookmarkPersist = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyMessages = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddCommentToMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExclude = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExcludeSource = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExcludeModule = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOTAFull = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSaveLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiIncreaseFont = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDecreaseFont = new System.Windows.Forms.ToolStripMenuItem();
            this.logGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnDataSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTimeDiff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAudit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnObject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProcessID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnThread = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtbHighlight = new System.Windows.Forms.TextBox();
            this.pnlButtonsHighlight = new System.Windows.Forms.Panel();
            this.lblPageNumber = new DevExpress.XtraEditors.LabelControl();
            this.sBtnPageNext = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnLastPage = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnPagePrevious = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnPageFirst = new DevExpress.XtraEditors.SimpleButton();
            this.btnUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnDown = new DevExpress.XtraEditors.SimpleButton();
            this.chkbHighlight = new System.Windows.Forms.CheckBox();
            this.pnlTopFiltering = new System.Windows.Forms.Panel();
            this.spltFilteringBoth = new System.Windows.Forms.SplitContainer();
            this.pnlFilteringLeft = new System.Windows.Forms.Panel();
            this.sBtnMostCommon = new DevExpress.XtraEditors.SimpleButton();
            this.chkbInclude = new System.Windows.Forms.CheckBox();
            this.spltExcludes = new System.Windows.Forms.SplitContainer();
            this.txtbExcludeSource = new System.Windows.Forms.TextBox();
            this.spltFilteringTop = new System.Windows.Forms.SplitContainer();
            this.pboxInfoExclude = new System.Windows.Forms.PictureBox();
            this.chkbExcludeSourceAndModule = new System.Windows.Forms.CheckBox();
            this.txtbExcludeModule = new System.Windows.Forms.TextBox();
            this.lblExcludeModule = new System.Windows.Forms.Label();
            this.txtbExclude = new System.Windows.Forms.TextBox();
            this.chkExclude = new System.Windows.Forms.CheckBox();
            this.pboxInfo = new System.Windows.Forms.PictureBox();
            this.txtbInclude = new System.Windows.Forms.TextBox();
            this.chkLstLogLevel = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.tcBottom = new DevExpress.XtraTab.XtraTabControl();
            this.xtpMessageInfo = new DevExpress.XtraTab.XtraTabPage();
            this.rtxtContent = new System.Windows.Forms.RichTextBox();
            this.bdcMessageBottom = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barTopFiltering = new DevExpress.XtraBars.Bar();
            this.bBtnClearLog = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnRemoveBoomark = new DevExpress.XtraBars.BarButtonItem();
            this.btswitchExpand = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btswitchRefreshLog = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btsAutoScrollToBottom = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.bBtnSaveEntireLog = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnSaveLog = new DevExpress.XtraBars.BarButtonItem();
            this.bbiScreenshot = new DevExpress.XtraBars.BarButtonItem();
            this.bSMExports = new DevExpress.XtraBars.BarSubItem();
            this.bBtnExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnExportCSV = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnExportHtml = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnImport = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnUndockView = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnDataVisualizer = new DevExpress.XtraBars.BarButtonItem();
            this.bdcTopFiltering = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.BbarMainMenu = new DevExpress.XtraBars.Bar();
            this.barMessage = new DevExpress.XtraBars.Bar();
            this.bBtnCopyButtom = new DevExpress.XtraBars.BarButtonItem();
            this.barBookmark = new DevExpress.XtraBars.Bar();
            this.bBtnopyBookmarked = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnCopyAllBookmarks = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnGoToMessage = new DevExpress.XtraBars.BarButtonItem();
            this.bdcBookmarks = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnExpand = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnButtomExpand = new DevExpress.XtraBars.BarButtonItem();
            this.btSwitchExpandButtomMessage = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.xtpBookmarks = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlBookmarkedMessages = new DevExpress.XtraGrid.GridControl();
            this.gridViewBookmarkedMessages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageListBottom = new System.Windows.Forms.ImageList(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tmrRefreshFilter = new System.Windows.Forms.Timer(this.components);
            this.tmrNewData = new System.Windows.Forms.Timer(this.components);
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtpMain = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainerMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.sBtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblTotalMessages = new DevExpress.XtraEditors.LabelControl();
            this.xtCounts = new DevExpress.XtraTab.XtraTabPage();
            this.sBtnGroup = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnLength = new DevExpress.XtraEditors.SimpleButton();
            this.pbGrouping = new System.Windows.Forms.PictureBox();
            this.lblGroupByCharsLimit = new System.Windows.Forms.Label();
            this.txtbGroupByCharsLimit = new System.Windows.Forms.TextBox();
            this.spltGroupByChars = new System.Windows.Forms.SplitContainer();
            this.gCtrlGrouping = new DevExpress.XtraGrid.GridControl();
            this.gridViewGrouping = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControlMessageGrouping = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblGroupByChars = new System.Windows.Forms.Label();
            this.nudGroupBychars = new System.Windows.Forms.NumericUpDown();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.cmsBookmarked = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCalcDiffBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRemoveBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyMessagesBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExcludeBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExcludeSourceBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExcludeModuleBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEmailBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOTAFullBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSaveLayoutBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiIncreaseFontBookmark = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDecreaseFontBookmark = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.cmsMessageOperation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlButtonsHighlight.SuspendLayout();
            this.pnlTopFiltering.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltFilteringBoth)).BeginInit();
            this.spltFilteringBoth.Panel1.SuspendLayout();
            this.spltFilteringBoth.Panel2.SuspendLayout();
            this.spltFilteringBoth.SuspendLayout();
            this.pnlFilteringLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltExcludes)).BeginInit();
            this.spltExcludes.Panel1.SuspendLayout();
            this.spltExcludes.Panel2.SuspendLayout();
            this.spltExcludes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltFilteringTop)).BeginInit();
            this.spltFilteringTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxInfoExclude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstLogLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcBottom)).BeginInit();
            this.tcBottom.SuspendLayout();
            this.xtpMessageInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.xtpBookmarks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBookmarkedMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBookmarkedMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.xtCounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrouping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltGroupByChars)).BeginInit();
            this.spltGroupByChars.Panel1.SuspendLayout();
            this.spltGroupByChars.Panel2.SuspendLayout();
            this.spltGroupByChars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gCtrlGrouping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGrouping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMessageGrouping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGroupBychars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.cmsBookmarked.SuspendLayout();
            this.SuspendLayout();
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
            this.imageList.Images.SetKeyName(6, "debug.gif");
            this.imageList.Images.SetKeyName(7, "New_16x16.png");
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.cmsMessageOperation;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl.Location = new System.Drawing.Point(0, 92);
            this.gridControl.MainView = this.logGrid;
            this.gridControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(2014, 309);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.logGrid});
            this.gridControl.Click += new System.EventHandler(this.pmsGrid_Click);
            this.gridControl.DoubleClick += new System.EventHandler(this.pmsGrid_DoubleClick);
            this.gridControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LogGrid_KeyPress);
            // 
            // cmsMessageOperation
            // 
            this.cmsMessageOperation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMessageOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClearLog,
            this.tsmiREmoveAllPreviousMessages,
            this.tsmiTimeDiff,
            this.toolStripSeparator4,
            this.tsmiBookmark,
            this.tsmiBookmarkPersist,
            this.tsmiCopy,
            this.tsmiCopyMessages,
            this.tsmiAddCommentToMessage,
            this.toolStripSeparator2,
            this.tsmiExclude,
            this.tsmiExcludeSource,
            this.tsmiExcludeModule,
            this.toolStripSeparator3,
            this.tsmiEmail,
            this.tsmiOTAFull,
            this.toolStripSeparator1,
            this.tsmiSaveLayout,
            this.tsmiIncreaseFont,
            this.tsmiDecreaseFont});
            this.cmsMessageOperation.Name = "cmsMessageOperation";
            this.cmsMessageOperation.Size = new System.Drawing.Size(416, 444);
            this.cmsMessageOperation.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMessageOperation_Opening);
            // 
            // tsmiClearLog
            // 
            this.tsmiClearLog.Image = global::Philips.Analogy.Properties.Resources.Delete_16x16;
            this.tsmiClearLog.Name = "tsmiClearLog";
            this.tsmiClearLog.Size = new System.Drawing.Size(415, 26);
            this.tsmiClearLog.Text = "Clear Log";
            this.tsmiClearLog.Click += new System.EventHandler(this.tsmiClearLog_Click);
            // 
            // tsmiREmoveAllPreviousMessages
            // 
            this.tsmiREmoveAllPreviousMessages.Image = global::Philips.Analogy.Properties.Resources.FitNone_16x16;
            this.tsmiREmoveAllPreviousMessages.Name = "tsmiREmoveAllPreviousMessages";
            this.tsmiREmoveAllPreviousMessages.Size = new System.Drawing.Size(415, 26);
            this.tsmiREmoveAllPreviousMessages.Text = "Remove all messages before selected message";
            this.tsmiREmoveAllPreviousMessages.Click += new System.EventHandler(this.tsmiREmoveAllPreviousMessages_Click);
            // 
            // tsmiTimeDiff
            // 
            this.tsmiTimeDiff.Image = global::Philips.Analogy.Properties.Resources.Time2_16x16;
            this.tsmiTimeDiff.Name = "tsmiTimeDiff";
            this.tsmiTimeDiff.Size = new System.Drawing.Size(415, 26);
            this.tsmiTimeDiff.Text = "Calculate Time Difference from this entry";
            this.tsmiTimeDiff.Click += new System.EventHandler(this.tsmiTimeDiff_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(412, 6);
            // 
            // tsmiBookmark
            // 
            this.tsmiBookmark.Image = global::Philips.Analogy.Properties.Resources.RichEditBookmark_16x16;
            this.tsmiBookmark.Name = "tsmiBookmark";
            this.tsmiBookmark.Size = new System.Drawing.Size(415, 26);
            this.tsmiBookmark.Text = "Bookmark this message (current Analogy instance)";
            this.tsmiBookmark.Click += new System.EventHandler(this.tsmiBookmark_Click);
            // 
            // tsmiBookmarkPersist
            // 
            this.tsmiBookmarkPersist.Image = global::Philips.Analogy.Properties.Resources.RichEditBookmark_16x16;
            this.tsmiBookmarkPersist.Name = "tsmiBookmarkPersist";
            this.tsmiBookmarkPersist.Size = new System.Drawing.Size(415, 26);
            this.tsmiBookmarkPersist.Text = "Bookmark this message for later use (persistent)";
            this.tsmiBookmarkPersist.Click += new System.EventHandler(this.tsmiBookmarkPersist_Click);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Image = global::Philips.Analogy.Properties.Resources.Copy_16x16;
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(415, 26);
            this.tsmiCopy.Text = "Copy selected message to clipboard";
            this.tsmiCopy.Click += new System.EventHandler(this.tsmiCopy_Click);
            // 
            // tsmiCopyMessages
            // 
            this.tsmiCopyMessages.Image = global::Philips.Analogy.Properties.Resources.Copy_16x16;
            this.tsmiCopyMessages.Name = "tsmiCopyMessages";
            this.tsmiCopyMessages.Size = new System.Drawing.Size(415, 26);
            this.tsmiCopyMessages.Text = "Copy all messages in view to clipboard";
            this.tsmiCopyMessages.Click += new System.EventHandler(this.tsmiCopyMessages_Click);
            // 
            // tsmiAddCommentToMessage
            // 
            this.tsmiAddCommentToMessage.Enabled = false;
            this.tsmiAddCommentToMessage.Image = global::Philips.Analogy.Properties.Resources.EditComment_16x16;
            this.tsmiAddCommentToMessage.Name = "tsmiAddCommentToMessage";
            this.tsmiAddCommentToMessage.Size = new System.Drawing.Size(415, 26);
            this.tsmiAddCommentToMessage.Text = "Add message/comment at this timestamp";
            this.tsmiAddCommentToMessage.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(412, 6);
            // 
            // tsmiExclude
            // 
            this.tsmiExclude.Image = global::Philips.Analogy.Properties.Resources.ClearFilter_16x16;
            this.tsmiExclude.Name = "tsmiExclude";
            this.tsmiExclude.Size = new System.Drawing.Size(415, 26);
            this.tsmiExclude.Text = "Exclude selected message ";
            this.tsmiExclude.Click += new System.EventHandler(this.tsmiExclude_Click);
            // 
            // tsmiExcludeSource
            // 
            this.tsmiExcludeSource.Image = global::Philips.Analogy.Properties.Resources.ClearFilter_16x16;
            this.tsmiExcludeSource.Name = "tsmiExcludeSource";
            this.tsmiExcludeSource.Size = new System.Drawing.Size(415, 26);
            this.tsmiExcludeSource.Text = "Exclude Source";
            this.tsmiExcludeSource.Click += new System.EventHandler(this.tsmiExcludeSource_Click);
            // 
            // tsmiExcludeModule
            // 
            this.tsmiExcludeModule.Image = global::Philips.Analogy.Properties.Resources.ClearFilter_16x16;
            this.tsmiExcludeModule.Name = "tsmiExcludeModule";
            this.tsmiExcludeModule.Size = new System.Drawing.Size(415, 26);
            this.tsmiExcludeModule.Text = "Exclude Process";
            this.tsmiExcludeModule.Click += new System.EventHandler(this.tsmiExcludeModule_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(412, 6);
            // 
            // tsmiEmail
            // 
            this.tsmiEmail.Image = global::Philips.Analogy.Properties.Resources.Send_16x16;
            this.tsmiEmail.Name = "tsmiEmail";
            this.tsmiEmail.Size = new System.Drawing.Size(415, 26);
            this.tsmiEmail.Text = "Send selected message by mail";
            this.tsmiEmail.Click += new System.EventHandler(this.tsmiEmail_Click);
            // 
            // tsmiOTAFull
            // 
            this.tsmiOTAFull.Enabled = false;
            this.tsmiOTAFull.Image = global::Philips.Analogy.Properties.Resources.logIcon;
            this.tsmiOTAFull.Name = "tsmiOTAFull";
            this.tsmiOTAFull.Size = new System.Drawing.Size(415, 26);
            this.tsmiOTAFull.Text = "Send Log to another Analogy";
            this.tsmiOTAFull.Visible = false;
            this.tsmiOTAFull.Click += new System.EventHandler(this.tsmiOTAFull_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(412, 6);
            // 
            // tsmiSaveLayout
            // 
            this.tsmiSaveLayout.Image = global::Philips.Analogy.Properties.Resources.Save_16x16;
            this.tsmiSaveLayout.Name = "tsmiSaveLayout";
            this.tsmiSaveLayout.Size = new System.Drawing.Size(415, 26);
            this.tsmiSaveLayout.Text = "Save columns layout";
            this.tsmiSaveLayout.Click += new System.EventHandler(this.tsmiSaveLayout_Click);
            // 
            // tsmiIncreaseFont
            // 
            this.tsmiIncreaseFont.Image = global::Philips.Analogy.Properties.Resources.IncreaseFontSize_16x16;
            this.tsmiIncreaseFont.Name = "tsmiIncreaseFont";
            this.tsmiIncreaseFont.Size = new System.Drawing.Size(415, 26);
            this.tsmiIncreaseFont.Text = "Increase Font Size";
            this.tsmiIncreaseFont.Click += new System.EventHandler(this.tsmiIncreaseFont_Click);
            // 
            // tsmiDecreaseFont
            // 
            this.tsmiDecreaseFont.Image = global::Philips.Analogy.Properties.Resources.DecreaseFontSize_16x16;
            this.tsmiDecreaseFont.Name = "tsmiDecreaseFont";
            this.tsmiDecreaseFont.Size = new System.Drawing.Size(415, 26);
            this.tsmiDecreaseFont.Text = "Decrease Font Size";
            this.tsmiDecreaseFont.Click += new System.EventHandler(this.tsmiDecreaseFont_Click);
            // 
            // logGrid
            // 
            this.logGrid.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.logGrid.Appearance.OddRow.Options.UseBackColor = true;
            this.logGrid.Appearance.Row.Options.UseTextOptions = true;
            this.logGrid.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.logGrid.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.logGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.logGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnDataSource,
            this.gridColumnDate,
            this.gridColumnTimeDiff,
            this.gridColumnText,
            this.gridColumnSource,
            this.gridColumnLevel,
            this.gridColumnClass,
            this.gridColumnCategory,
            this.gridColumnUser,
            this.gridColumnModule,
            this.gridColumnAudit,
            this.gridColumnObject,
            this.gridColumnProcessID,
            this.gridColumnThread});
            this.logGrid.DetailHeight = 431;
            this.logGrid.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.logGrid.GridControl = this.gridControl;
            this.logGrid.Images = this.imageList;
            this.logGrid.IndicatorWidth = 24;
            this.logGrid.Name = "logGrid";
            this.logGrid.OptionsBehavior.Editable = false;
            this.logGrid.OptionsCustomization.AllowGroup = false;
            this.logGrid.OptionsFilter.AllowColumnMRUFilterList = false;
            this.logGrid.OptionsFilter.AllowMRUFilterList = false;
            this.logGrid.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.logGrid.OptionsView.AutoCalcPreviewLineCount = true;
            this.logGrid.OptionsView.ColumnAutoWidth = false;
            this.logGrid.OptionsView.RowAutoHeight = true;
            this.logGrid.OptionsView.ShowAutoFilterRow = true;
            this.logGrid.OptionsView.ShowGroupPanel = false;
            this.logGrid.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.pmsGridView_CustomDrawRowIndicator);
            this.logGrid.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.pmsGridView_RowStyle);
            this.logGrid.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.PmsGridView_SelectionChanged);
            this.logGrid.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.logGrid_FocusedRowChanged);
            this.logGrid.ShowFilterPopupListBox += new DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventHandler(this.GridViewShowFilterPopupListBox);
            this.logGrid.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.GridViewCustomColumnDisplayText);
            this.logGrid.Click += new System.EventHandler(this.logGrid_Click);
            // 
            // gridColumnDataSource
            // 
            this.gridColumnDataSource.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnDataSource.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnDataSource.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnDataSource.Caption = "Data Source/File Name";
            this.gridColumnDataSource.FieldName = "DataSource";
            this.gridColumnDataSource.MinWidth = 24;
            this.gridColumnDataSource.Name = "gridColumnDataSource";
            this.gridColumnDataSource.OptionsColumn.AllowEdit = false;
            this.gridColumnDataSource.OptionsColumn.AllowFocus = false;
            this.gridColumnDataSource.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDataSource.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDataSource.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnDataSource.OptionsColumn.ReadOnly = true;
            this.gridColumnDataSource.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnDataSource.Visible = true;
            this.gridColumnDataSource.VisibleIndex = 0;
            this.gridColumnDataSource.Width = 175;
            // 
            // gridColumnDate
            // 
            this.gridColumnDate.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnDate.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnDate.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnDate.Caption = "Date";
            this.gridColumnDate.DisplayFormat.FormatString = "yyyy.MM.dd HH:mm:ss.ff";
            this.gridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnDate.FieldName = "Date";
            this.gridColumnDate.MinWidth = 24;
            this.gridColumnDate.Name = "gridColumnDate";
            this.gridColumnDate.OptionsColumn.AllowEdit = false;
            this.gridColumnDate.OptionsColumn.AllowFocus = false;
            this.gridColumnDate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnDate.OptionsColumn.ReadOnly = true;
            this.gridColumnDate.OptionsFilter.AllowAutoFilter = false;
            this.gridColumnDate.Visible = true;
            this.gridColumnDate.VisibleIndex = 1;
            this.gridColumnDate.Width = 164;
            // 
            // gridColumnTimeDiff
            // 
            this.gridColumnTimeDiff.Caption = "Time Difference";
            this.gridColumnTimeDiff.FieldName = "TimeDiff";
            this.gridColumnTimeDiff.MinWidth = 22;
            this.gridColumnTimeDiff.Name = "gridColumnTimeDiff";
            this.gridColumnTimeDiff.Width = 87;
            // 
            // gridColumnText
            // 
            this.gridColumnText.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnText.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnText.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnText.Caption = "Text";
            this.gridColumnText.FieldName = "Text";
            this.gridColumnText.MinWidth = 24;
            this.gridColumnText.Name = "gridColumnText";
            this.gridColumnText.OptionsColumn.AllowEdit = false;
            this.gridColumnText.OptionsColumn.AllowFocus = false;
            this.gridColumnText.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnText.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnText.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnText.OptionsColumn.ReadOnly = true;
            this.gridColumnText.OptionsFilter.AllowFilter = false;
            this.gridColumnText.Visible = true;
            this.gridColumnText.VisibleIndex = 2;
            this.gridColumnText.Width = 290;
            // 
            // gridColumnSource
            // 
            this.gridColumnSource.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnSource.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnSource.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnSource.Caption = "Source";
            this.gridColumnSource.FieldName = "Source";
            this.gridColumnSource.MinWidth = 24;
            this.gridColumnSource.Name = "gridColumnSource";
            this.gridColumnSource.OptionsColumn.AllowEdit = false;
            this.gridColumnSource.OptionsColumn.AllowFocus = false;
            this.gridColumnSource.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnSource.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnSource.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnSource.OptionsColumn.ReadOnly = true;
            this.gridColumnSource.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnSource.Visible = true;
            this.gridColumnSource.VisibleIndex = 3;
            this.gridColumnSource.Width = 234;
            // 
            // gridColumnLevel
            // 
            this.gridColumnLevel.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnLevel.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnLevel.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnLevel.Caption = "Level";
            this.gridColumnLevel.FieldName = "Level";
            this.gridColumnLevel.MinWidth = 24;
            this.gridColumnLevel.Name = "gridColumnLevel";
            this.gridColumnLevel.OptionsColumn.AllowEdit = false;
            this.gridColumnLevel.OptionsColumn.AllowFocus = false;
            this.gridColumnLevel.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnLevel.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnLevel.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnLevel.OptionsColumn.ReadOnly = true;
            this.gridColumnLevel.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnLevel.Visible = true;
            this.gridColumnLevel.VisibleIndex = 4;
            this.gridColumnLevel.Width = 115;
            // 
            // gridColumnClass
            // 
            this.gridColumnClass.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnClass.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnClass.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnClass.Caption = "Class";
            this.gridColumnClass.FieldName = "Class";
            this.gridColumnClass.MinWidth = 24;
            this.gridColumnClass.Name = "gridColumnClass";
            this.gridColumnClass.OptionsColumn.AllowEdit = false;
            this.gridColumnClass.OptionsColumn.AllowFocus = false;
            this.gridColumnClass.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnClass.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnClass.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnClass.OptionsColumn.ReadOnly = true;
            this.gridColumnClass.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnClass.Visible = true;
            this.gridColumnClass.VisibleIndex = 6;
            this.gridColumnClass.Width = 115;
            // 
            // gridColumnCategory
            // 
            this.gridColumnCategory.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnCategory.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnCategory.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnCategory.Caption = "Category";
            this.gridColumnCategory.FieldName = "Category";
            this.gridColumnCategory.MinWidth = 24;
            this.gridColumnCategory.Name = "gridColumnCategory";
            this.gridColumnCategory.OptionsColumn.AllowEdit = false;
            this.gridColumnCategory.OptionsColumn.AllowFocus = false;
            this.gridColumnCategory.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnCategory.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnCategory.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnCategory.OptionsColumn.ReadOnly = true;
            this.gridColumnCategory.Visible = true;
            this.gridColumnCategory.VisibleIndex = 8;
            this.gridColumnCategory.Width = 115;
            // 
            // gridColumnUser
            // 
            this.gridColumnUser.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnUser.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnUser.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnUser.Caption = "User";
            this.gridColumnUser.FieldName = "User";
            this.gridColumnUser.MinWidth = 24;
            this.gridColumnUser.Name = "gridColumnUser";
            this.gridColumnUser.OptionsColumn.AllowEdit = false;
            this.gridColumnUser.OptionsColumn.AllowFocus = false;
            this.gridColumnUser.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnUser.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnUser.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnUser.OptionsColumn.ReadOnly = true;
            this.gridColumnUser.Visible = true;
            this.gridColumnUser.VisibleIndex = 9;
            this.gridColumnUser.Width = 115;
            // 
            // gridColumnModule
            // 
            this.gridColumnModule.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnModule.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnModule.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnModule.Caption = "Process/Module";
            this.gridColumnModule.FieldName = "Module";
            this.gridColumnModule.MinWidth = 24;
            this.gridColumnModule.Name = "gridColumnModule";
            this.gridColumnModule.OptionsColumn.AllowEdit = false;
            this.gridColumnModule.OptionsColumn.AllowFocus = false;
            this.gridColumnModule.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnModule.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnModule.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnModule.OptionsColumn.ReadOnly = true;
            this.gridColumnModule.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnModule.Visible = true;
            this.gridColumnModule.VisibleIndex = 5;
            this.gridColumnModule.Width = 115;
            // 
            // gridColumnAudit
            // 
            this.gridColumnAudit.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnAudit.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnAudit.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnAudit.Caption = "Audit";
            this.gridColumnAudit.FieldName = "Audit";
            this.gridColumnAudit.MinWidth = 24;
            this.gridColumnAudit.Name = "gridColumnAudit";
            this.gridColumnAudit.OptionsColumn.AllowEdit = false;
            this.gridColumnAudit.OptionsColumn.AllowFocus = false;
            this.gridColumnAudit.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnAudit.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnAudit.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnAudit.OptionsColumn.ReadOnly = true;
            this.gridColumnAudit.Visible = true;
            this.gridColumnAudit.VisibleIndex = 7;
            this.gridColumnAudit.Width = 115;
            // 
            // gridColumnObject
            // 
            this.gridColumnObject.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnObject.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnObject.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnObject.Caption = "Object";
            this.gridColumnObject.MinWidth = 24;
            this.gridColumnObject.Name = "gridColumnObject";
            this.gridColumnObject.OptionsColumn.AllowEdit = false;
            this.gridColumnObject.OptionsColumn.AllowFocus = false;
            this.gridColumnObject.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnObject.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnObject.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnObject.OptionsColumn.ReadOnly = true;
            this.gridColumnObject.OptionsColumn.ShowCaption = false;
            this.gridColumnObject.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumnObject.Width = 87;
            // 
            // gridColumnProcessID
            // 
            this.gridColumnProcessID.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnProcessID.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnProcessID.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnProcessID.Caption = "ProcessID";
            this.gridColumnProcessID.FieldName = "ProcessID";
            this.gridColumnProcessID.MinWidth = 24;
            this.gridColumnProcessID.Name = "gridColumnProcessID";
            this.gridColumnProcessID.OptionsColumn.AllowEdit = false;
            this.gridColumnProcessID.OptionsColumn.AllowFocus = false;
            this.gridColumnProcessID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnProcessID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnProcessID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnProcessID.OptionsColumn.ReadOnly = true;
            this.gridColumnProcessID.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnProcessID.Visible = true;
            this.gridColumnProcessID.VisibleIndex = 10;
            this.gridColumnProcessID.Width = 115;
            // 
            // gridColumnThread
            // 
            this.gridColumnThread.Caption = "Thread ID";
            this.gridColumnThread.FieldName = "ThreadID";
            this.gridColumnThread.MinWidth = 25;
            this.gridColumnThread.Name = "gridColumnThread";
            this.gridColumnThread.Visible = true;
            this.gridColumnThread.VisibleIndex = 11;
            this.gridColumnThread.Width = 109;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtbHighlight);
            this.panel1.Controls.Add(this.pnlButtonsHighlight);
            this.panel1.Controls.Add(this.chkbHighlight);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 401);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2014, 26);
            this.panel1.TabIndex = 4;
            // 
            // txtbHighlight
            // 
            this.txtbHighlight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbHighlight.Location = new System.Drawing.Point(200, 0);
            this.txtbHighlight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbHighlight.Name = "txtbHighlight";
            this.txtbHighlight.Size = new System.Drawing.Size(1294, 23);
            this.txtbHighlight.TabIndex = 10;
            this.txtbHighlight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbHighlight_KeyUp);
            // 
            // pnlButtonsHighlight
            // 
            this.pnlButtonsHighlight.Controls.Add(this.lblPageNumber);
            this.pnlButtonsHighlight.Controls.Add(this.sBtnPageNext);
            this.pnlButtonsHighlight.Controls.Add(this.sBtnLastPage);
            this.pnlButtonsHighlight.Controls.Add(this.sbtnPagePrevious);
            this.pnlButtonsHighlight.Controls.Add(this.sbtnPageFirst);
            this.pnlButtonsHighlight.Controls.Add(this.btnUp);
            this.pnlButtonsHighlight.Controls.Add(this.btnDown);
            this.pnlButtonsHighlight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtonsHighlight.Location = new System.Drawing.Point(1494, 0);
            this.pnlButtonsHighlight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlButtonsHighlight.Name = "pnlButtonsHighlight";
            this.pnlButtonsHighlight.Size = new System.Drawing.Size(520, 26);
            this.pnlButtonsHighlight.TabIndex = 12;
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageNumber.Appearance.Options.UseTextOptions = true;
            this.lblPageNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblPageNumber.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPageNumber.Location = new System.Drawing.Point(232, 4);
            this.lblPageNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(113, 18);
            this.lblPageNumber.TabIndex = 46;
            this.lblPageNumber.Text = "Page 1 / 1";
            // 
            // sBtnPageNext
            // 
            this.sBtnPageNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sBtnPageNext.Location = new System.Drawing.Point(355, 0);
            this.sBtnPageNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sBtnPageNext.Name = "sBtnPageNext";
            this.sBtnPageNext.Size = new System.Drawing.Size(87, 25);
            this.sBtnPageNext.TabIndex = 45;
            this.sBtnPageNext.Text = "Next Page";
            this.sBtnPageNext.Click += new System.EventHandler(this.sBtnPageNext_Click);
            // 
            // sBtnLastPage
            // 
            this.sBtnLastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sBtnLastPage.Location = new System.Drawing.Point(444, 0);
            this.sBtnLastPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sBtnLastPage.Name = "sBtnLastPage";
            this.sBtnLastPage.Size = new System.Drawing.Size(73, 25);
            this.sBtnLastPage.TabIndex = 44;
            this.sBtnLastPage.Text = "Last Page";
            this.sBtnLastPage.Click += new System.EventHandler(this.sBtnLastPage_Click);
            // 
            // sbtnPagePrevious
            // 
            this.sbtnPagePrevious.Location = new System.Drawing.Point(138, 0);
            this.sbtnPagePrevious.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sbtnPagePrevious.Name = "sbtnPagePrevious";
            this.sbtnPagePrevious.Size = new System.Drawing.Size(87, 25);
            this.sbtnPagePrevious.TabIndex = 43;
            this.sbtnPagePrevious.Text = "Previous Page";
            this.sbtnPagePrevious.Click += new System.EventHandler(this.sbtnPagePrevious_Click);
            // 
            // sbtnPageFirst
            // 
            this.sbtnPageFirst.Location = new System.Drawing.Point(61, 0);
            this.sbtnPageFirst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sbtnPageFirst.Name = "sbtnPageFirst";
            this.sbtnPageFirst.Size = new System.Drawing.Size(73, 25);
            this.sbtnPageFirst.TabIndex = 42;
            this.sbtnPageFirst.Text = "first Page";
            this.sbtnPageFirst.Click += new System.EventHandler(this.sbtnPageFirst_Click);
            // 
            // btnUp
            // 
            this.btnUp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.ImageOptions.Image")));
            this.btnUp.Location = new System.Drawing.Point(7, 0);
            this.btnUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(21, 26);
            this.btnUp.TabIndex = 41;
            this.btnUp.Visible = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.ImageOptions.Image")));
            this.btnDown.Location = new System.Drawing.Point(33, 0);
            this.btnDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(21, 26);
            this.btnDown.TabIndex = 40;
            this.btnDown.Visible = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // chkbHighlight
            // 
            this.chkbHighlight.AutoSize = true;
            this.chkbHighlight.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkbHighlight.Location = new System.Drawing.Point(0, 0);
            this.chkbHighlight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkbHighlight.Name = "chkbHighlight";
            this.chkbHighlight.Size = new System.Drawing.Size(200, 26);
            this.chkbHighlight.TabIndex = 11;
            this.chkbHighlight.Text = "Highlight lines that contains:";
            this.chkbHighlight.UseVisualStyleBackColor = true;
            this.chkbHighlight.CheckedChanged += new System.EventHandler(this.chkbHighlight_CheckedChanged);
            // 
            // pnlTopFiltering
            // 
            this.pnlTopFiltering.Controls.Add(this.spltFilteringBoth);
            this.pnlTopFiltering.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopFiltering.Location = new System.Drawing.Point(0, 0);
            this.pnlTopFiltering.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlTopFiltering.Name = "pnlTopFiltering";
            this.pnlTopFiltering.Size = new System.Drawing.Size(2014, 92);
            this.pnlTopFiltering.TabIndex = 3;
            // 
            // spltFilteringBoth
            // 
            this.spltFilteringBoth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltFilteringBoth.Location = new System.Drawing.Point(0, 0);
            this.spltFilteringBoth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.spltFilteringBoth.Name = "spltFilteringBoth";
            // 
            // spltFilteringBoth.Panel1
            // 
            this.spltFilteringBoth.Panel1.Controls.Add(this.pnlFilteringLeft);
            // 
            // spltFilteringBoth.Panel2
            // 
            this.spltFilteringBoth.Panel2.Controls.Add(this.chkLstLogLevel);
            this.spltFilteringBoth.Panel2MinSize = 150;
            this.spltFilteringBoth.Size = new System.Drawing.Size(2014, 92);
            this.spltFilteringBoth.SplitterDistance = 1551;
            this.spltFilteringBoth.SplitterWidth = 3;
            this.spltFilteringBoth.TabIndex = 19;
            // 
            // pnlFilteringLeft
            // 
            this.pnlFilteringLeft.Controls.Add(this.sBtnMostCommon);
            this.pnlFilteringLeft.Controls.Add(this.chkbInclude);
            this.pnlFilteringLeft.Controls.Add(this.spltExcludes);
            this.pnlFilteringLeft.Controls.Add(this.txtbExclude);
            this.pnlFilteringLeft.Controls.Add(this.chkExclude);
            this.pnlFilteringLeft.Controls.Add(this.pboxInfo);
            this.pnlFilteringLeft.Controls.Add(this.txtbInclude);
            this.pnlFilteringLeft.Location = new System.Drawing.Point(0, 1);
            this.pnlFilteringLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlFilteringLeft.Name = "pnlFilteringLeft";
            this.pnlFilteringLeft.Size = new System.Drawing.Size(509, 89);
            this.pnlFilteringLeft.TabIndex = 20;
            // 
            // sBtnMostCommon
            // 
            this.sBtnMostCommon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sBtnMostCommon.Location = new System.Drawing.Point(385, 34);
            this.sBtnMostCommon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnMostCommon.Name = "sBtnMostCommon";
            this.sBtnMostCommon.Size = new System.Drawing.Size(120, 25);
            this.sBtnMostCommon.TabIndex = 8;
            this.sBtnMostCommon.Text = "Most Common";
            this.sBtnMostCommon.Click += new System.EventHandler(this.sBtnMostCommon_Click);
            // 
            // chkbInclude
            // 
            this.chkbInclude.AutoSize = true;
            this.chkbInclude.Location = new System.Drawing.Point(3, 2);
            this.chkbInclude.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkbInclude.Name = "chkbInclude";
            this.chkbInclude.Size = new System.Drawing.Size(79, 21);
            this.chkbInclude.TabIndex = 9;
            this.chkbInclude.Text = "Include:";
            this.chkbInclude.UseVisualStyleBackColor = true;
            this.chkbInclude.CheckedChanged += new System.EventHandler(this.chkbInclude_CheckedChanged);
            // 
            // spltExcludes
            // 
            this.spltExcludes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.spltExcludes.Location = new System.Drawing.Point(0, 63);
            this.spltExcludes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spltExcludes.Name = "spltExcludes";
            // 
            // spltExcludes.Panel1
            // 
            this.spltExcludes.Panel1.Controls.Add(this.txtbExcludeSource);
            this.spltExcludes.Panel1.Controls.Add(this.spltFilteringTop);
            this.spltExcludes.Panel1.Controls.Add(this.pboxInfoExclude);
            this.spltExcludes.Panel1.Controls.Add(this.chkbExcludeSourceAndModule);
            // 
            // spltExcludes.Panel2
            // 
            this.spltExcludes.Panel2.Controls.Add(this.txtbExcludeModule);
            this.spltExcludes.Panel2.Controls.Add(this.lblExcludeModule);
            this.spltExcludes.Size = new System.Drawing.Size(509, 26);
            this.spltExcludes.SplitterDistance = 241;
            this.spltExcludes.SplitterWidth = 3;
            this.spltExcludes.TabIndex = 18;
            // 
            // txtbExcludeSource
            // 
            this.txtbExcludeSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbExcludeSource.Location = new System.Drawing.Point(157, 0);
            this.txtbExcludeSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbExcludeSource.Name = "txtbExcludeSource";
            this.txtbExcludeSource.Size = new System.Drawing.Size(84, 23);
            this.txtbExcludeSource.TabIndex = 13;
            this.txtbExcludeSource.TextChanged += new System.EventHandler(this.txtbExcludeSource_TextChanged);
            // 
            // spltFilteringTop
            // 
            this.spltFilteringTop.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spltFilteringTop.Location = new System.Drawing.Point(113, 27);
            this.spltFilteringTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.spltFilteringTop.Name = "spltFilteringTop";
            this.spltFilteringTop.Panel2Collapsed = true;
            this.spltFilteringTop.Size = new System.Drawing.Size(1207, 55);
            this.spltFilteringTop.SplitterDistance = 1009;
            this.spltFilteringTop.SplitterWidth = 3;
            this.spltFilteringTop.TabIndex = 0;
            // 
            // pboxInfoExclude
            // 
            this.pboxInfoExclude.Dock = System.Windows.Forms.DockStyle.Left;
            this.pboxInfoExclude.Image = global::Philips.Analogy.Properties.Resources.Info_16x16;
            this.pboxInfoExclude.Location = new System.Drawing.Point(136, 0);
            this.pboxInfoExclude.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pboxInfoExclude.Name = "pboxInfoExclude";
            this.pboxInfoExclude.Size = new System.Drawing.Size(21, 26);
            this.pboxInfoExclude.TabIndex = 15;
            this.pboxInfoExclude.TabStop = false;
            // 
            // chkbExcludeSourceAndModule
            // 
            this.chkbExcludeSourceAndModule.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkbExcludeSourceAndModule.Location = new System.Drawing.Point(0, 0);
            this.chkbExcludeSourceAndModule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkbExcludeSourceAndModule.Name = "chkbExcludeSourceAndModule";
            this.chkbExcludeSourceAndModule.Size = new System.Drawing.Size(136, 26);
            this.chkbExcludeSourceAndModule.TabIndex = 14;
            this.chkbExcludeSourceAndModule.Text = "Exclude: Sources:";
            this.chkbExcludeSourceAndModule.UseVisualStyleBackColor = true;
            this.chkbExcludeSourceAndModule.CheckedChanged += new System.EventHandler(this.chkbExcludeSourceAndModule_CheckedChanged);
            // 
            // txtbExcludeModule
            // 
            this.txtbExcludeModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbExcludeModule.Location = new System.Drawing.Point(59, 0);
            this.txtbExcludeModule.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbExcludeModule.Name = "txtbExcludeModule";
            this.txtbExcludeModule.Size = new System.Drawing.Size(206, 23);
            this.txtbExcludeModule.TabIndex = 16;
            this.txtbExcludeModule.TextChanged += new System.EventHandler(this.txtbExcludeModule_TextChanged);
            // 
            // lblExcludeModule
            // 
            this.lblExcludeModule.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblExcludeModule.Location = new System.Drawing.Point(0, 0);
            this.lblExcludeModule.Name = "lblExcludeModule";
            this.lblExcludeModule.Size = new System.Drawing.Size(59, 26);
            this.lblExcludeModule.TabIndex = 17;
            this.lblExcludeModule.Text = "Modules:";
            this.lblExcludeModule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtbExclude
            // 
            this.txtbExclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbExclude.Location = new System.Drawing.Point(98, 34);
            this.txtbExclude.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbExclude.Name = "txtbExclude";
            this.txtbExclude.Size = new System.Drawing.Size(282, 23);
            this.txtbExclude.TabIndex = 1;
            this.txtbExclude.TextChanged += new System.EventHandler(this.txtbExclude_TextChanged);
            this.txtbExclude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbExclude_KeyDown);
            // 
            // chkExclude
            // 
            this.chkExclude.AutoSize = true;
            this.chkExclude.Location = new System.Drawing.Point(3, 36);
            this.chkExclude.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkExclude.Name = "chkExclude";
            this.chkExclude.Size = new System.Drawing.Size(83, 21);
            this.chkExclude.TabIndex = 10;
            this.chkExclude.Text = "Exclude:";
            this.chkExclude.UseVisualStyleBackColor = true;
            this.chkExclude.CheckedChanged += new System.EventHandler(this.chkbExclude_CheckedChanged);
            // 
            // pboxInfo
            // 
            this.pboxInfo.Image = global::Philips.Analogy.Properties.Resources.Info_16x16;
            this.pboxInfo.Location = new System.Drawing.Point(77, 6);
            this.pboxInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pboxInfo.Name = "pboxInfo";
            this.pboxInfo.Size = new System.Drawing.Size(16, 18);
            this.pboxInfo.TabIndex = 12;
            this.pboxInfo.TabStop = false;
            // 
            // txtbInclude
            // 
            this.txtbInclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbInclude.Location = new System.Drawing.Point(98, 2);
            this.txtbInclude.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbInclude.Name = "txtbInclude";
            this.txtbInclude.Size = new System.Drawing.Size(406, 23);
            this.txtbInclude.TabIndex = 0;
            this.txtbInclude.TextChanged += new System.EventHandler(this.txtbInclude_TextChanged);
            this.txtbInclude.Enter += new System.EventHandler(this.txtbInclude_Enter);
            this.txtbInclude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbInclude_KeyDown);
            this.txtbInclude.MouseEnter += new System.EventHandler(this.txtbInclude_MouseEnter);
            // 
            // chkLstLogLevel
            // 
            this.chkLstLogLevel.CheckMode = DevExpress.XtraEditors.CheckMode.Single;
            this.chkLstLogLevel.CheckOnClick = true;
            this.chkLstLogLevel.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkLstLogLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLstLogLevel.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Error + Critical"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Warning"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Debug"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Verbose")});
            this.chkLstLogLevel.Location = new System.Drawing.Point(0, 0);
            this.chkLstLogLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkLstLogLevel.Name = "chkLstLogLevel";
            this.chkLstLogLevel.Size = new System.Drawing.Size(460, 92);
            this.chkLstLogLevel.TabIndex = 22;
            this.chkLstLogLevel.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkLstLogLevel_ItemCheck);
            this.chkLstLogLevel.SelectedIndexChanged += new System.EventHandler(this.chkLstLogLevel_SelectedIndexChanged);
            this.chkLstLogLevel.DrawItem += new DevExpress.XtraEditors.ListBoxDrawItemEventHandler(this.chkLstLogLevel_DrawItem);
            // 
            // tcBottom
            // 
            this.tcBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcBottom.Location = new System.Drawing.Point(0, 0);
            this.tcBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tcBottom.Name = "tcBottom";
            this.tcBottom.SelectedTabPage = this.xtpMessageInfo;
            this.tcBottom.Size = new System.Drawing.Size(2014, 204);
            this.tcBottom.TabIndex = 6;
            this.tcBottom.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpMessageInfo,
            this.xtpBookmarks});
            // 
            // xtpMessageInfo
            // 
            this.xtpMessageInfo.Controls.Add(this.rtxtContent);
            this.xtpMessageInfo.Controls.Add(this.bdcMessageBottom);
            this.xtpMessageInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtpMessageInfo.Name = "xtpMessageInfo";
            this.xtpMessageInfo.Size = new System.Drawing.Size(2007, 170);
            this.xtpMessageInfo.Text = "Message Info";
            // 
            // rtxtContent
            // 
            this.rtxtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtContent.Location = new System.Drawing.Point(0, 37);
            this.rtxtContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtxtContent.Name = "rtxtContent";
            this.rtxtContent.Size = new System.Drawing.Size(2007, 133);
            this.rtxtContent.TabIndex = 0;
            this.rtxtContent.Text = "";
            // 
            // bdcMessageBottom
            // 
            this.bdcMessageBottom.AutoSize = true;
            this.bdcMessageBottom.CausesValidation = false;
            this.bdcMessageBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.bdcMessageBottom.Location = new System.Drawing.Point(0, 0);
            this.bdcMessageBottom.Manager = this.barManager1;
            this.bdcMessageBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bdcMessageBottom.Name = "bdcMessageBottom";
            this.bdcMessageBottom.Size = new System.Drawing.Size(2007, 37);
            this.bdcMessageBottom.Text = "standaloneBarDockControl2";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTopFiltering,
            this.BbarMainMenu,
            this.barMessage,
            this.barBookmark});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.bdcTopFiltering);
            this.barManager1.DockControls.Add(this.bdcMessageBottom);
            this.barManager1.DockControls.Add(this.bdcBookmarks);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.btswitchExpand,
            this.btswitchRefreshLog,
            this.bBtnSaveLog,
            this.bBtnImport,
            this.bBtnClearLog,
            this.bBtnExpand,
            this.barButtonItem3,
            this.bBtnButtomExpand,
            this.bBtnCopyButtom,
            this.btSwitchExpandButtomMessage,
            this.bBtnopyBookmarked,
            this.barButtonItem4,
            this.bBtnGoToMessage,
            this.bBtnRemoveBoomark,
            this.bBtnCopyAllBookmarks,
            this.btsAutoScrollToBottom,
            this.bSMExports,
            this.bBtnExportExcel,
            this.bBtnExportCSV,
            this.bBtnExportHtml,
            this.bBtnUndockView,
            this.bBtnSaveEntireLog,
            this.bBtnDataVisualizer,
            this.bbiScreenshot});
            this.barManager1.MainMenu = this.BbarMainMenu;
            this.barManager1.MaxItemId = 28;
            // 
            // barTopFiltering
            // 
            this.barTopFiltering.BarName = "Log Operations";
            this.barTopFiltering.DockCol = 0;
            this.barTopFiltering.DockRow = 0;
            this.barTopFiltering.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.barTopFiltering.FloatLocation = new System.Drawing.Point(192, 279);
            this.barTopFiltering.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnClearLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnRemoveBoomark),
            new DevExpress.XtraBars.LinkPersistInfo(this.btswitchExpand),
            new DevExpress.XtraBars.LinkPersistInfo(this.btswitchRefreshLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.btsAutoScrollToBottom),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnSaveEntireLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnSaveLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiScreenshot),
            new DevExpress.XtraBars.LinkPersistInfo(this.bSMExports),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnImport),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnUndockView),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnDataVisualizer)});
            this.barTopFiltering.OptionsBar.AllowQuickCustomization = false;
            this.barTopFiltering.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.barTopFiltering.OptionsBar.DisableClose = true;
            this.barTopFiltering.OptionsBar.DisableCustomization = true;
            this.barTopFiltering.OptionsBar.UseWholeRow = true;
            this.barTopFiltering.StandaloneBarDockControl = this.bdcTopFiltering;
            this.barTopFiltering.Text = "Operations";
            // 
            // bBtnClearLog
            // 
            this.bBtnClearLog.Caption = "Clear Log";
            this.bBtnClearLog.Id = 6;
            this.bBtnClearLog.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnClearLog.ImageOptions.Image")));
            this.bBtnClearLog.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnClearLog.ImageOptions.LargeImage")));
            this.bBtnClearLog.Name = "bBtnClearLog";
            this.bBtnClearLog.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnClearLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnClearLog_ItemClick);
            // 
            // bBtnRemoveBoomark
            // 
            this.bBtnRemoveBoomark.Caption = "Delete message";
            this.bBtnRemoveBoomark.Id = 15;
            this.bBtnRemoveBoomark.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnRemoveBoomark.ImageOptions.Image")));
            this.bBtnRemoveBoomark.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnRemoveBoomark.ImageOptions.LargeImage")));
            this.bBtnRemoveBoomark.Name = "bBtnRemoveBoomark";
            this.bBtnRemoveBoomark.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnRemoveBoomark.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bBtnRemoveBoomark.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnRemoveBoomark_ItemClick);
            // 
            // btswitchExpand
            // 
            this.btswitchExpand.Caption = "Expand";
            this.btswitchExpand.Id = 2;
            this.btswitchExpand.Name = "btswitchExpand";
            this.btswitchExpand.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.btswitchExpand_CheckedChanged);
            // 
            // btswitchRefreshLog
            // 
            this.btswitchRefreshLog.Caption = "Refresh log:";
            this.btswitchRefreshLog.Id = 3;
            this.btswitchRefreshLog.Name = "btswitchRefreshLog";
            this.btswitchRefreshLog.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.btswitchRefreshLog_CheckedChanged);
            // 
            // btsAutoScrollToBottom
            // 
            this.btsAutoScrollToBottom.Caption = "Auto Scroll to bottom:";
            this.btsAutoScrollToBottom.Id = 18;
            this.btsAutoScrollToBottom.Name = "btsAutoScrollToBottom";
            this.btsAutoScrollToBottom.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.btsAutoScrollToBottom_CheckedChanged);
            // 
            // bBtnSaveEntireLog
            // 
            this.bBtnSaveEntireLog.Caption = "Save Entire Log";
            this.bBtnSaveEntireLog.Id = 25;
            this.bBtnSaveEntireLog.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnSaveEntireLog.ImageOptions.Image")));
            this.bBtnSaveEntireLog.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnSaveEntireLog.ImageOptions.LargeImage")));
            this.bBtnSaveEntireLog.Name = "bBtnSaveEntireLog";
            this.bBtnSaveEntireLog.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnSaveEntireLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnSaveEntireLog_ItemClick);
            // 
            // bBtnSaveLog
            // 
            this.bBtnSaveLog.Caption = "Save Current View";
            this.bBtnSaveLog.Id = 4;
            this.bBtnSaveLog.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnSaveLog.ImageOptions.Image")));
            this.bBtnSaveLog.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnSaveLog.ImageOptions.LargeImage")));
            this.bBtnSaveLog.Name = "bBtnSaveLog";
            this.bBtnSaveLog.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnSaveLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnSaveLog_ItemClick);
            // 
            // bbiScreenshot
            // 
            this.bbiScreenshot.Caption = "Take screenshot";
            this.bbiScreenshot.Hint = "Take screenshot of the messages control";
            this.bbiScreenshot.Id = 27;
            this.bbiScreenshot.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiScreenshot.ImageOptions.Image")));
            this.bbiScreenshot.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiScreenshot.ImageOptions.LargeImage")));
            this.bbiScreenshot.Name = "bbiScreenshot";
            this.bbiScreenshot.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiScreenshot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiScreenshot_ItemClick);
            // 
            // bSMExports
            // 
            this.bSMExports.Caption = "Export to other formats";
            this.bSMExports.Id = 20;
            this.bSMExports.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bSMExports.ImageOptions.Image")));
            this.bSMExports.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bSMExports.ImageOptions.LargeImage")));
            this.bSMExports.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bBtnExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnExportCSV),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnExportHtml)});
            this.bSMExports.Name = "bSMExports";
            this.bSMExports.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bBtnExportExcel
            // 
            this.bBtnExportExcel.Caption = "Export To Excel";
            this.bBtnExportExcel.Id = 21;
            this.bBtnExportExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnExportExcel.ImageOptions.Image")));
            this.bBtnExportExcel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnExportExcel.ImageOptions.LargeImage")));
            this.bBtnExportExcel.Name = "bBtnExportExcel";
            this.bBtnExportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnExportExcel_ItemClick);
            // 
            // bBtnExportCSV
            // 
            this.bBtnExportCSV.Caption = "Export To CSV";
            this.bBtnExportCSV.Id = 22;
            this.bBtnExportCSV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnExportCSV.ImageOptions.Image")));
            this.bBtnExportCSV.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnExportCSV.ImageOptions.LargeImage")));
            this.bBtnExportCSV.Name = "bBtnExportCSV";
            this.bBtnExportCSV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnExportCSV_ItemClick);
            // 
            // bBtnExportHtml
            // 
            this.bBtnExportHtml.Caption = "Export To Html";
            this.bBtnExportHtml.Id = 23;
            this.bBtnExportHtml.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnExportHtml.ImageOptions.Image")));
            this.bBtnExportHtml.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnExportHtml.ImageOptions.LargeImage")));
            this.bBtnExportHtml.Name = "bBtnExportHtml";
            this.bBtnExportHtml.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnExportHtml.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bBtnExportHtml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnExportHtml_ItemClick);
            // 
            // bBtnImport
            // 
            this.bBtnImport.Caption = "Import Log";
            this.bBtnImport.Id = 5;
            this.bBtnImport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnImport.ImageOptions.Image")));
            this.bBtnImport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnImport.ImageOptions.LargeImage")));
            this.bBtnImport.Name = "bBtnImport";
            this.bBtnImport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnImport_ItemClick);
            // 
            // bBtnUndockView
            // 
            this.bBtnUndockView.Caption = "Undock Current View";
            this.bBtnUndockView.Id = 24;
            this.bBtnUndockView.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnUndockView.ImageOptions.Image")));
            this.bBtnUndockView.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnUndockView.ImageOptions.LargeImage")));
            this.bBtnUndockView.Name = "bBtnUndockView";
            this.bBtnUndockView.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnUndockView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnUndockView_ItemClick);
            // 
            // bBtnDataVisualizer
            // 
            this.bBtnDataVisualizer.Caption = "Data Visualizer";
            this.bBtnDataVisualizer.Id = 26;
            this.bBtnDataVisualizer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnDataVisualizer.ImageOptions.Image")));
            this.bBtnDataVisualizer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnDataVisualizer.ImageOptions.LargeImage")));
            this.bBtnDataVisualizer.Name = "bBtnDataVisualizer";
            this.bBtnDataVisualizer.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnDataVisualizer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnDataVisualizer_ItemClick);
            // 
            // bdcTopFiltering
            // 
            this.bdcTopFiltering.CausesValidation = false;
            this.bdcTopFiltering.Dock = System.Windows.Forms.DockStyle.Top;
            this.bdcTopFiltering.Location = new System.Drawing.Point(0, 0);
            this.bdcTopFiltering.Manager = this.barManager1;
            this.bdcTopFiltering.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bdcTopFiltering.Name = "bdcTopFiltering";
            this.bdcTopFiltering.Size = new System.Drawing.Size(2014, 38);
            this.bdcTopFiltering.Text = "standaloneBarDockControl1";
            // 
            // BbarMainMenu
            // 
            this.BbarMainMenu.BarName = "Main menu";
            this.BbarMainMenu.DockCol = 0;
            this.BbarMainMenu.DockRow = 0;
            this.BbarMainMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BbarMainMenu.FloatLocation = new System.Drawing.Point(258, 133);
            this.BbarMainMenu.OptionsBar.MultiLine = true;
            this.BbarMainMenu.OptionsBar.UseWholeRow = true;
            this.BbarMainMenu.Text = "Main menu";
            this.BbarMainMenu.Visible = false;
            // 
            // barMessage
            // 
            this.barMessage.BarName = "Message";
            this.barMessage.DockCol = 0;
            this.barMessage.DockRow = 0;
            this.barMessage.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.barMessage.FloatLocation = new System.Drawing.Point(104, 295);
            this.barMessage.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnCopyButtom)});
            this.barMessage.OptionsBar.AllowCollapse = true;
            this.barMessage.OptionsBar.AllowDelete = true;
            this.barMessage.OptionsBar.AllowQuickCustomization = false;
            this.barMessage.OptionsBar.AllowRename = true;
            this.barMessage.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.barMessage.OptionsBar.DisableClose = true;
            this.barMessage.OptionsBar.DisableCustomization = true;
            this.barMessage.OptionsBar.UseWholeRow = true;
            this.barMessage.StandaloneBarDockControl = this.bdcMessageBottom;
            this.barMessage.Text = "Message Info";
            // 
            // bBtnCopyButtom
            // 
            this.bBtnCopyButtom.Caption = "Copy";
            this.bBtnCopyButtom.Id = 10;
            this.bBtnCopyButtom.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnCopyButtom.ImageOptions.Image")));
            this.bBtnCopyButtom.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnCopyButtom.ImageOptions.LargeImage")));
            this.bBtnCopyButtom.Name = "bBtnCopyButtom";
            this.bBtnCopyButtom.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnCopyButtom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnCopyButtom_ItemClick);
            // 
            // barBookmark
            // 
            this.barBookmark.BarName = "Boommarks";
            this.barBookmark.DockCol = 0;
            this.barBookmark.DockRow = 0;
            this.barBookmark.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.barBookmark.FloatLocation = new System.Drawing.Point(566, 323);
            this.barBookmark.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnopyBookmarked),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnCopyAllBookmarks),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnGoToMessage)});
            this.barBookmark.OptionsBar.AllowCollapse = true;
            this.barBookmark.OptionsBar.AllowDelete = true;
            this.barBookmark.OptionsBar.AllowQuickCustomization = false;
            this.barBookmark.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.barBookmark.OptionsBar.DisableClose = true;
            this.barBookmark.OptionsBar.DisableCustomization = true;
            this.barBookmark.OptionsBar.UseWholeRow = true;
            this.barBookmark.StandaloneBarDockControl = this.bdcBookmarks;
            this.barBookmark.Text = "Custom 5";
            // 
            // bBtnopyBookmarked
            // 
            this.bBtnopyBookmarked.Caption = "Copy Selected Message";
            this.bBtnopyBookmarked.Id = 12;
            this.bBtnopyBookmarked.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnopyBookmarked.ImageOptions.Image")));
            this.bBtnopyBookmarked.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnopyBookmarked.ImageOptions.LargeImage")));
            this.bBtnopyBookmarked.Name = "bBtnopyBookmarked";
            this.bBtnopyBookmarked.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnopyBookmarked.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnopyBookmarked_ItemClick);
            // 
            // bBtnCopyAllBookmarks
            // 
            this.bBtnCopyAllBookmarks.Caption = "Copy all messages in grid";
            this.bBtnCopyAllBookmarks.Id = 16;
            this.bBtnCopyAllBookmarks.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnCopyAllBookmarks.ImageOptions.Image")));
            this.bBtnCopyAllBookmarks.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnCopyAllBookmarks.ImageOptions.LargeImage")));
            this.bBtnCopyAllBookmarks.Name = "bBtnCopyAllBookmarks";
            this.bBtnCopyAllBookmarks.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnCopyAllBookmarks.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnCopyAllBookmarks_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Clear Bookmarks";
            this.barButtonItem4.Id = 13;
            this.barButtonItem4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.barButtonItem4.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.LargeImage")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // bBtnGoToMessage
            // 
            this.bBtnGoToMessage.Caption = "Go To Message";
            this.bBtnGoToMessage.Id = 14;
            this.bBtnGoToMessage.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnGoToMessage.ImageOptions.Image")));
            this.bBtnGoToMessage.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnGoToMessage.ImageOptions.LargeImage")));
            this.bBtnGoToMessage.Name = "bBtnGoToMessage";
            this.bBtnGoToMessage.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnGoToMessage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnGoToMessage_ItemClick);
            // 
            // bdcBookmarks
            // 
            this.bdcBookmarks.CausesValidation = false;
            this.bdcBookmarks.Dock = System.Windows.Forms.DockStyle.Top;
            this.bdcBookmarks.Location = new System.Drawing.Point(0, 0);
            this.bdcBookmarks.Manager = this.barManager1;
            this.bdcBookmarks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bdcBookmarks.Name = "bdcBookmarks";
            this.bdcBookmarks.Size = new System.Drawing.Size(2007, 32);
            this.bdcBookmarks.Text = "standaloneBarDockControl1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(2021, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 759);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(2021, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 739);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(2021, 20);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 739);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // bBtnExpand
            // 
            this.bBtnExpand.Caption = "Expand";
            this.bBtnExpand.Id = 7;
            this.bBtnExpand.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnExpand.ImageOptions.Image")));
            this.bBtnExpand.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnExpand.ImageOptions.LargeImage")));
            this.bBtnExpand.Name = "bBtnExpand";
            this.bBtnExpand.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Copy";
            this.barButtonItem3.Id = 8;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.LargeImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bBtnButtomExpand
            // 
            this.bBtnButtomExpand.Caption = "Expand";
            this.bBtnButtomExpand.Id = 9;
            this.bBtnButtomExpand.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bBtnButtomExpand.ImageOptions.Image")));
            this.bBtnButtomExpand.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bBtnButtomExpand.ImageOptions.LargeImage")));
            this.bBtnButtomExpand.Name = "bBtnButtomExpand";
            this.bBtnButtomExpand.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnButtomExpand.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnButtomExpand_ItemClick);
            // 
            // btSwitchExpandButtomMessage
            // 
            this.btSwitchExpandButtomMessage.Caption = "Expand";
            this.btSwitchExpandButtomMessage.Id = 11;
            this.btSwitchExpandButtomMessage.Name = "btSwitchExpandButtomMessage";
            this.btSwitchExpandButtomMessage.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barToggleSwitchItem1_CheckedChanged);
            // 
            // xtpBookmarks
            // 
            this.xtpBookmarks.Controls.Add(this.gridControlBookmarkedMessages);
            this.xtpBookmarks.Controls.Add(this.bdcBookmarks);
            this.xtpBookmarks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtpBookmarks.Name = "xtpBookmarks";
            this.xtpBookmarks.Size = new System.Drawing.Size(2007, 170);
            this.xtpBookmarks.Text = "Bookmarks";
            // 
            // gridControlBookmarkedMessages
            // 
            this.gridControlBookmarkedMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlBookmarkedMessages.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlBookmarkedMessages.Location = new System.Drawing.Point(0, 32);
            this.gridControlBookmarkedMessages.MainView = this.gridViewBookmarkedMessages;
            this.gridControlBookmarkedMessages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlBookmarkedMessages.Name = "gridControlBookmarkedMessages";
            this.gridControlBookmarkedMessages.Size = new System.Drawing.Size(2007, 138);
            this.gridControlBookmarkedMessages.TabIndex = 3;
            this.gridControlBookmarkedMessages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBookmarkedMessages});
            this.gridControlBookmarkedMessages.DoubleClick += new System.EventHandler(this.gridControlBookmarkedMessages_DoubleClick);
            // 
            // gridViewBookmarkedMessages
            // 
            this.gridViewBookmarkedMessages.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridViewBookmarkedMessages.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewBookmarkedMessages.Appearance.Row.Options.UseTextOptions = true;
            this.gridViewBookmarkedMessages.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridViewBookmarkedMessages.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridViewBookmarkedMessages.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridViewBookmarkedMessages.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12});
            this.gridViewBookmarkedMessages.DetailHeight = 431;
            this.gridViewBookmarkedMessages.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewBookmarkedMessages.GridControl = this.gridControlBookmarkedMessages;
            this.gridViewBookmarkedMessages.Images = this.imageList;
            this.gridViewBookmarkedMessages.IndicatorWidth = 24;
            this.gridViewBookmarkedMessages.Name = "gridViewBookmarkedMessages";
            this.gridViewBookmarkedMessages.OptionsBehavior.Editable = false;
            this.gridViewBookmarkedMessages.OptionsCustomization.AllowGroup = false;
            this.gridViewBookmarkedMessages.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridViewBookmarkedMessages.OptionsFilter.AllowMRUFilterList = false;
            this.gridViewBookmarkedMessages.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewBookmarkedMessages.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridViewBookmarkedMessages.OptionsView.ColumnAutoWidth = false;
            this.gridViewBookmarkedMessages.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewBookmarkedMessages.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewBookmarkedMessages.OptionsView.RowAutoHeight = true;
            this.gridViewBookmarkedMessages.OptionsView.ShowAutoFilterRow = true;
            this.gridViewBookmarkedMessages.OptionsView.ShowGroupPanel = false;
            this.gridViewBookmarkedMessages.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.pmsGridView_CustomDrawRowIndicator);
            this.gridViewBookmarkedMessages.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.pmsGridView_RowStyle);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn1.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn1.Caption = "Data Source";
            this.gridColumn1.FieldName = "DataSource";
            this.gridColumn1.MinWidth = 24;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 175;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn2.Caption = "Date";
            this.gridColumn2.DisplayFormat.FormatString = "yyyy.MM.dd HH:mm:ss.ff";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "Date";
            this.gridColumn2.MinWidth = 24;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 164;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn3.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn3.Caption = "Text";
            this.gridColumn3.FieldName = "Text";
            this.gridColumn3.MinWidth = 24;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 290;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn4.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn4.Caption = "Source";
            this.gridColumn4.FieldName = "Source";
            this.gridColumn4.MinWidth = 24;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 234;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn5.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn5.Caption = "Level";
            this.gridColumn5.FieldName = "Level";
            this.gridColumn5.MinWidth = 24;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 115;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn6.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn6.Caption = "Class";
            this.gridColumn6.FieldName = "Class";
            this.gridColumn6.MinWidth = 24;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 115;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn7.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn7.Caption = "Category";
            this.gridColumn7.FieldName = "Category";
            this.gridColumn7.MinWidth = 24;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 115;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn8.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn8.Caption = "User";
            this.gridColumn8.FieldName = "User";
            this.gridColumn8.MinWidth = 24;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            this.gridColumn8.Width = 115;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn9.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn9.Caption = "Module";
            this.gridColumn9.FieldName = "Module";
            this.gridColumn9.MinWidth = 24;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 10;
            this.gridColumn9.Width = 115;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn10.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn10.Caption = "Audit";
            this.gridColumn10.FieldName = "Audit";
            this.gridColumn10.MinWidth = 24;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 115;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn11.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn11.Caption = "Object";
            this.gridColumn11.MinWidth = 24;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.OptionsColumn.ShowCaption = false;
            this.gridColumn11.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn11.Width = 87;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn12.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn12.Caption = "ProcessID";
            this.gridColumn12.FieldName = "ProcessID";
            this.gridColumn12.MinWidth = 24;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            this.gridColumn12.Width = 115;
            // 
            // imageListBottom
            // 
            this.imageListBottom.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBottom.ImageStream")));
            this.imageListBottom.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListBottom.Images.SetKeyName(0, "Info_16x16.png");
            this.imageListBottom.Images.SetKeyName(1, "RichEditBookmark_16x16.png");
            this.imageListBottom.Images.SetKeyName(2, "RichEditBookmark_32x32.png");
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(173, 0);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1642, 30);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // tmrRefreshFilter
            // 
            this.tmrRefreshFilter.Enabled = true;
            this.tmrRefreshFilter.Interval = 500;
            this.tmrRefreshFilter.Tick += new System.EventHandler(this.tmrRefreshFilter_Tick);
            // 
            // tmrNewData
            // 
            this.tmrNewData.Enabled = true;
            this.tmrNewData.Interval = 1000;
            this.tmrNewData.Tick += new System.EventHandler(this.tmrNewData_Tick);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 20);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtpMain;
            this.xtraTabControl1.Size = new System.Drawing.Size(2021, 739);
            this.xtraTabControl1.TabIndex = 7;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpMain,
            this.xtCounts});
            // 
            // xtpMain
            // 
            this.xtpMain.Controls.Add(this.splitContainerMain);
            this.xtpMain.Controls.Add(this.bdcTopFiltering);
            this.xtpMain.Controls.Add(this.pnlBottom);
            this.xtpMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtpMain.Name = "xtpMain";
            this.xtpMain.Size = new System.Drawing.Size(2014, 705);
            this.xtpMain.Text = "Logs";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerMain.Horizontal = false;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 38);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Panel1.Controls.Add(this.gridControl);
            this.splitContainerMain.Panel1.Controls.Add(this.panel1);
            this.splitContainerMain.Panel1.Controls.Add(this.pnlTopFiltering);
            this.splitContainerMain.Panel1.Text = "Panel1";
            this.splitContainerMain.Panel2.Controls.Add(this.tcBottom);
            this.splitContainerMain.Panel2.Text = "Panel2";
            this.splitContainerMain.Size = new System.Drawing.Size(2014, 637);
            this.splitContainerMain.SplitterPosition = 204;
            this.splitContainerMain.TabIndex = 21;
            this.splitContainerMain.Text = "splitContainerControl1";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.progressBar1);
            this.pnlBottom.Controls.Add(this.sBtnCancel);
            this.pnlBottom.Controls.Add(this.lblTotalMessages);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 675);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(2014, 30);
            this.pnlBottom.TabIndex = 3;
            // 
            // sBtnCancel
            // 
            this.sBtnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sBtnCancel.Appearance.Options.UseFont = true;
            this.sBtnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.sBtnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sBtnCancel.ImageOptions.Image")));
            this.sBtnCancel.Location = new System.Drawing.Point(1815, 0);
            this.sBtnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnCancel.Name = "sBtnCancel";
            this.sBtnCancel.Size = new System.Drawing.Size(199, 30);
            this.sBtnCancel.TabIndex = 5;
            this.sBtnCancel.Text = "Cancel Processing";
            this.sBtnCancel.Visible = false;
            this.sBtnCancel.Click += new System.EventHandler(this.sBtnCancel_Click);
            // 
            // lblTotalMessages
            // 
            this.lblTotalMessages.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMessages.Appearance.Options.UseFont = true;
            this.lblTotalMessages.Appearance.Options.UseTextOptions = true;
            this.lblTotalMessages.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTotalMessages.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTotalMessages.Location = new System.Drawing.Point(0, 0);
            this.lblTotalMessages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblTotalMessages.Name = "lblTotalMessages";
            this.lblTotalMessages.Size = new System.Drawing.Size(173, 23);
            this.lblTotalMessages.TabIndex = 0;
            this.lblTotalMessages.Text = "Total messages: N/A";
            // 
            // xtCounts
            // 
            this.xtCounts.Controls.Add(this.sBtnGroup);
            this.xtCounts.Controls.Add(this.sBtnLength);
            this.xtCounts.Controls.Add(this.pbGrouping);
            this.xtCounts.Controls.Add(this.lblGroupByCharsLimit);
            this.xtCounts.Controls.Add(this.txtbGroupByCharsLimit);
            this.xtCounts.Controls.Add(this.spltGroupByChars);
            this.xtCounts.Controls.Add(this.lblGroupByChars);
            this.xtCounts.Controls.Add(this.nudGroupBychars);
            this.xtCounts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtCounts.Name = "xtCounts";
            this.xtCounts.Size = new System.Drawing.Size(2014, 705);
            this.xtCounts.Text = "Messages Grouping";
            // 
            // sBtnGroup
            // 
            this.sBtnGroup.Location = new System.Drawing.Point(413, 59);
            this.sBtnGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnGroup.Name = "sBtnGroup";
            this.sBtnGroup.Size = new System.Drawing.Size(83, 25);
            this.sBtnGroup.TabIndex = 13;
            this.sBtnGroup.Text = "Group";
            this.sBtnGroup.Click += new System.EventHandler(this.sBtnGroup_Click);
            // 
            // sBtnLength
            // 
            this.sBtnLength.Location = new System.Drawing.Point(413, 18);
            this.sBtnLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnLength.Name = "sBtnLength";
            this.sBtnLength.Size = new System.Drawing.Size(83, 25);
            this.sBtnLength.TabIndex = 12;
            this.sBtnLength.Text = "Set Length";
            this.sBtnLength.Click += new System.EventHandler(this.sBtnLength_Click);
            // 
            // pbGrouping
            // 
            this.pbGrouping.Image = global::Philips.Analogy.Properties.Resources.working;
            this.pbGrouping.Location = new System.Drawing.Point(524, 5);
            this.pbGrouping.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbGrouping.Name = "pbGrouping";
            this.pbGrouping.Size = new System.Drawing.Size(79, 90);
            this.pbGrouping.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGrouping.TabIndex = 8;
            this.pbGrouping.TabStop = false;
            this.pbGrouping.Visible = false;
            // 
            // lblGroupByCharsLimit
            // 
            this.lblGroupByCharsLimit.AutoSize = true;
            this.lblGroupByCharsLimit.Location = new System.Drawing.Point(10, 23);
            this.lblGroupByCharsLimit.Name = "lblGroupByCharsLimit";
            this.lblGroupByCharsLimit.Size = new System.Drawing.Size(107, 17);
            this.lblGroupByCharsLimit.TabIndex = 7;
            this.lblGroupByCharsLimit.Text = "text length limit:";
            // 
            // txtbGroupByCharsLimit
            // 
            this.txtbGroupByCharsLimit.Location = new System.Drawing.Point(150, 20);
            this.txtbGroupByCharsLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbGroupByCharsLimit.Name = "txtbGroupByCharsLimit";
            this.txtbGroupByCharsLimit.Size = new System.Drawing.Size(257, 23);
            this.txtbGroupByCharsLimit.TabIndex = 6;
            // 
            // spltGroupByChars
            // 
            this.spltGroupByChars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spltGroupByChars.Location = new System.Drawing.Point(12, 101);
            this.spltGroupByChars.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.spltGroupByChars.Name = "spltGroupByChars";
            this.spltGroupByChars.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltGroupByChars.Panel1
            // 
            this.spltGroupByChars.Panel1.Controls.Add(this.gCtrlGrouping);
            // 
            // spltGroupByChars.Panel2
            // 
            this.spltGroupByChars.Panel2.Controls.Add(this.gridControlMessageGrouping);
            this.spltGroupByChars.Size = new System.Drawing.Size(2004, 597);
            this.spltGroupByChars.SplitterDistance = 306;
            this.spltGroupByChars.TabIndex = 4;
            // 
            // gCtrlGrouping
            // 
            this.gCtrlGrouping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gCtrlGrouping.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gCtrlGrouping.Location = new System.Drawing.Point(0, 0);
            this.gCtrlGrouping.MainView = this.gridViewGrouping;
            this.gCtrlGrouping.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gCtrlGrouping.MenuManager = this.barManager1;
            this.gCtrlGrouping.Name = "gCtrlGrouping";
            this.gCtrlGrouping.Size = new System.Drawing.Size(2004, 306);
            this.gCtrlGrouping.TabIndex = 0;
            this.gCtrlGrouping.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewGrouping});
            // 
            // gridViewGrouping
            // 
            this.gridViewGrouping.GridControl = this.gCtrlGrouping;
            this.gridViewGrouping.Name = "gridViewGrouping";
            this.gridViewGrouping.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewGrouping.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewGrouping.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewGrouping.OptionsView.ShowGroupPanel = false;
            this.gridViewGrouping.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewGrouping_FocusedRowChanged);
            // 
            // gridControlMessageGrouping
            // 
            this.gridControlMessageGrouping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMessageGrouping.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlMessageGrouping.Location = new System.Drawing.Point(0, 0);
            this.gridControlMessageGrouping.MainView = this.gridView1;
            this.gridControlMessageGrouping.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControlMessageGrouping.Name = "gridControlMessageGrouping";
            this.gridControlMessageGrouping.Size = new System.Drawing.Size(2004, 287);
            this.gridControlMessageGrouping.TabIndex = 4;
            this.gridControlMessageGrouping.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridView1.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24});
            this.gridView1.DetailHeight = 431;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.gridControlMessageGrouping;
            this.gridView1.Images = this.imageList;
            this.gridView1.IndicatorWidth = 24;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "PMS Harmonize";
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.pmsGridView_CustomDrawRowIndicator);
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.pmsGridView_RowStyle);
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn13.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn13.Caption = "Data Source";
            this.gridColumn13.FieldName = "DataSource";
            this.gridColumn13.MinWidth = 24;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            this.gridColumn13.Width = 175;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn14.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn14.Caption = "Date";
            this.gridColumn14.DisplayFormat.FormatString = "yyyy.MM.dd HH:mm:ss.ff";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn14.FieldName = "Date";
            this.gridColumn14.MinWidth = 24;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn14.OptionsColumn.ReadOnly = true;
            this.gridColumn14.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 1;
            this.gridColumn14.Width = 164;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn15.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn15.Caption = "Text";
            this.gridColumn15.FieldName = "Text";
            this.gridColumn15.MinWidth = 24;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.OptionsFilter.AllowFilter = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 2;
            this.gridColumn15.Width = 290;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn16.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn16.Caption = "Source";
            this.gridColumn16.FieldName = "Source";
            this.gridColumn16.MinWidth = 24;
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 5;
            this.gridColumn16.Width = 234;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn17.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn17.Caption = "Level";
            this.gridColumn17.FieldName = "Level";
            this.gridColumn17.MinWidth = 24;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 6;
            this.gridColumn17.Width = 115;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn18.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn18.Caption = "Class";
            this.gridColumn18.FieldName = "Class";
            this.gridColumn18.MinWidth = 24;
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn18.OptionsColumn.ReadOnly = true;
            this.gridColumn18.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 7;
            this.gridColumn18.Width = 115;
            // 
            // gridColumn19
            // 
            this.gridColumn19.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn19.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn19.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn19.Caption = "Category";
            this.gridColumn19.FieldName = "Category";
            this.gridColumn19.MinWidth = 24;
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.AllowFocus = false;
            this.gridColumn19.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn19.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn19.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn19.OptionsColumn.ReadOnly = true;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 8;
            this.gridColumn19.Width = 115;
            // 
            // gridColumn20
            // 
            this.gridColumn20.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn20.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn20.Caption = "User";
            this.gridColumn20.FieldName = "User";
            this.gridColumn20.MinWidth = 24;
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.AllowFocus = false;
            this.gridColumn20.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn20.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn20.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn20.OptionsColumn.ReadOnly = true;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 9;
            this.gridColumn20.Width = 115;
            // 
            // gridColumn21
            // 
            this.gridColumn21.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn21.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn21.Caption = "Module";
            this.gridColumn21.FieldName = "Module";
            this.gridColumn21.MinWidth = 24;
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.AllowFocus = false;
            this.gridColumn21.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn21.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn21.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn21.OptionsColumn.ReadOnly = true;
            this.gridColumn21.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 10;
            this.gridColumn21.Width = 115;
            // 
            // gridColumn22
            // 
            this.gridColumn22.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn22.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn22.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn22.Caption = "Audit";
            this.gridColumn22.FieldName = "Audit";
            this.gridColumn22.MinWidth = 24;
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.AllowFocus = false;
            this.gridColumn22.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn22.OptionsColumn.ReadOnly = true;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 3;
            this.gridColumn22.Width = 115;
            // 
            // gridColumn23
            // 
            this.gridColumn23.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn23.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn23.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn23.Caption = "Object";
            this.gridColumn23.MinWidth = 24;
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn23.OptionsColumn.ReadOnly = true;
            this.gridColumn23.OptionsColumn.ShowCaption = false;
            this.gridColumn23.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn23.Width = 87;
            // 
            // gridColumn24
            // 
            this.gridColumn24.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn24.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumn24.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumn24.Caption = "ProcessID";
            this.gridColumn24.FieldName = "ProcessID";
            this.gridColumn24.MinWidth = 24;
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            this.gridColumn24.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn24.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn24.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn24.OptionsColumn.ReadOnly = true;
            this.gridColumn24.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 4;
            this.gridColumn24.Width = 115;
            // 
            // lblGroupByChars
            // 
            this.lblGroupByChars.AutoSize = true;
            this.lblGroupByChars.Location = new System.Drawing.Point(10, 59);
            this.lblGroupByChars.Name = "lblGroupByChars";
            this.lblGroupByChars.Size = new System.Drawing.Size(207, 17);
            this.lblGroupByChars.TabIndex = 2;
            this.lblGroupByChars.Text = "Group by number of characters:";
            // 
            // nudGroupBychars
            // 
            this.nudGroupBychars.Location = new System.Drawing.Point(320, 59);
            this.nudGroupBychars.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudGroupBychars.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.nudGroupBychars.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudGroupBychars.Name = "nudGroupBychars";
            this.nudGroupBychars.Size = new System.Drawing.Size(87, 23);
            this.nudGroupBychars.TabIndex = 0;
            this.nudGroupBychars.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // cmsBookmarked
            // 
            this.cmsBookmarked.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsBookmarked.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCalcDiffBookmark,
            this.toolStripSeparator5,
            this.tsmiRemoveBookmark,
            this.tsmiCopyBookmark,
            this.tsmiCopyMessagesBookmark,
            this.toolStripMenuItem5,
            this.toolStripSeparator6,
            this.tsmiExcludeBookmark,
            this.tsmiExcludeSourceBookmark,
            this.tsmiExcludeModuleBookmark,
            this.toolStripSeparator7,
            this.tsmiEmailBookmark,
            this.tsmiOTAFullBookmark,
            this.toolStripSeparator8,
            this.tsmiSaveLayoutBookmark,
            this.tsmiIncreaseFontBookmark,
            this.tsmiDecreaseFontBookmark});
            this.cmsBookmarked.Name = "cmsMessageOperation";
            this.cmsBookmarked.Size = new System.Drawing.Size(361, 366);
            this.cmsBookmarked.Opening += new System.ComponentModel.CancelEventHandler(this.cmsBookmarked_Opening);
            // 
            // tsmiCalcDiffBookmark
            // 
            this.tsmiCalcDiffBookmark.Image = global::Philips.Analogy.Properties.Resources.Time2_16x16;
            this.tsmiCalcDiffBookmark.Name = "tsmiCalcDiffBookmark";
            this.tsmiCalcDiffBookmark.Size = new System.Drawing.Size(360, 26);
            this.tsmiCalcDiffBookmark.Text = "Calculate Time Difference from this entry";
            this.tsmiCalcDiffBookmark.Click += new System.EventHandler(this.tsmiTimeDiff_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(357, 6);
            // 
            // tsmiRemoveBookmark
            // 
            this.tsmiRemoveBookmark.Image = global::Philips.Analogy.Properties.Resources.Clear_16x16;
            this.tsmiRemoveBookmark.Name = "tsmiRemoveBookmark";
            this.tsmiRemoveBookmark.Size = new System.Drawing.Size(360, 26);
            this.tsmiRemoveBookmark.Text = "Remove this message";
            this.tsmiRemoveBookmark.Click += new System.EventHandler(this.tsmiRemoveBookmark_Click);
            // 
            // tsmiCopyBookmark
            // 
            this.tsmiCopyBookmark.Image = global::Philips.Analogy.Properties.Resources.Copy_16x16;
            this.tsmiCopyBookmark.Name = "tsmiCopyBookmark";
            this.tsmiCopyBookmark.Size = new System.Drawing.Size(360, 26);
            this.tsmiCopyBookmark.Text = "Copy selected message to clipboard";
            this.tsmiCopyBookmark.Click += new System.EventHandler(this.tsmiCopy_Click);
            // 
            // tsmiCopyMessagesBookmark
            // 
            this.tsmiCopyMessagesBookmark.Image = global::Philips.Analogy.Properties.Resources.Copy_16x16;
            this.tsmiCopyMessagesBookmark.Name = "tsmiCopyMessagesBookmark";
            this.tsmiCopyMessagesBookmark.Size = new System.Drawing.Size(360, 26);
            this.tsmiCopyMessagesBookmark.Text = "Copy all messages in view to clipboard";
            this.tsmiCopyMessagesBookmark.Click += new System.EventHandler(this.tsmiCopyMessages_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Enabled = false;
            this.toolStripMenuItem5.Image = global::Philips.Analogy.Properties.Resources.EditComment_16x16;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(360, 26);
            this.toolStripMenuItem5.Text = "Add message/comment at this timestamp";
            this.toolStripMenuItem5.Visible = false;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(357, 6);
            // 
            // tsmiExcludeBookmark
            // 
            this.tsmiExcludeBookmark.Image = global::Philips.Analogy.Properties.Resources.ClearFilter_16x16;
            this.tsmiExcludeBookmark.Name = "tsmiExcludeBookmark";
            this.tsmiExcludeBookmark.Size = new System.Drawing.Size(360, 26);
            this.tsmiExcludeBookmark.Text = "Exclude selected message ";
            this.tsmiExcludeBookmark.Click += new System.EventHandler(this.tsmiExclude_Click);
            // 
            // tsmiExcludeSourceBookmark
            // 
            this.tsmiExcludeSourceBookmark.Image = global::Philips.Analogy.Properties.Resources.ClearFilter_16x16;
            this.tsmiExcludeSourceBookmark.Name = "tsmiExcludeSourceBookmark";
            this.tsmiExcludeSourceBookmark.Size = new System.Drawing.Size(360, 26);
            this.tsmiExcludeSourceBookmark.Text = "Exclude Source";
            this.tsmiExcludeSourceBookmark.Click += new System.EventHandler(this.tsmiExcludeSource_Click);
            // 
            // tsmiExcludeModuleBookmark
            // 
            this.tsmiExcludeModuleBookmark.Image = global::Philips.Analogy.Properties.Resources.ClearFilter_16x16;
            this.tsmiExcludeModuleBookmark.Name = "tsmiExcludeModuleBookmark";
            this.tsmiExcludeModuleBookmark.Size = new System.Drawing.Size(360, 26);
            this.tsmiExcludeModuleBookmark.Text = "Exclude Module";
            this.tsmiExcludeModuleBookmark.Click += new System.EventHandler(this.tsmiExcludeModule_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(357, 6);
            // 
            // tsmiEmailBookmark
            // 
            this.tsmiEmailBookmark.Image = global::Philips.Analogy.Properties.Resources.Send_16x16;
            this.tsmiEmailBookmark.Name = "tsmiEmailBookmark";
            this.tsmiEmailBookmark.Size = new System.Drawing.Size(360, 26);
            this.tsmiEmailBookmark.Text = "Send selected message by mail";
            this.tsmiEmailBookmark.Click += new System.EventHandler(this.tsmiEmail_Click);
            // 
            // tsmiOTAFullBookmark
            // 
            this.tsmiOTAFullBookmark.Image = global::Philips.Analogy.Properties.Resources.logIcon;
            this.tsmiOTAFullBookmark.Name = "tsmiOTAFullBookmark";
            this.tsmiOTAFullBookmark.Size = new System.Drawing.Size(360, 26);
            this.tsmiOTAFullBookmark.Text = "Send Log to another Analogy";
            this.tsmiOTAFullBookmark.Visible = false;
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(357, 6);
            // 
            // tsmiSaveLayoutBookmark
            // 
            this.tsmiSaveLayoutBookmark.Image = global::Philips.Analogy.Properties.Resources.Save_16x16;
            this.tsmiSaveLayoutBookmark.Name = "tsmiSaveLayoutBookmark";
            this.tsmiSaveLayoutBookmark.Size = new System.Drawing.Size(360, 26);
            this.tsmiSaveLayoutBookmark.Text = "Save columns layout";
            this.tsmiSaveLayoutBookmark.Click += new System.EventHandler(this.tsmiSaveLayout_Click);
            // 
            // tsmiIncreaseFontBookmark
            // 
            this.tsmiIncreaseFontBookmark.Image = global::Philips.Analogy.Properties.Resources.IncreaseFontSize_16x16;
            this.tsmiIncreaseFontBookmark.Name = "tsmiIncreaseFontBookmark";
            this.tsmiIncreaseFontBookmark.Size = new System.Drawing.Size(360, 26);
            this.tsmiIncreaseFontBookmark.Text = "Increase Font Size";
            this.tsmiIncreaseFontBookmark.Click += new System.EventHandler(this.tsmiIncreaseFont_Click);
            // 
            // tsmiDecreaseFontBookmark
            // 
            this.tsmiDecreaseFontBookmark.Image = global::Philips.Analogy.Properties.Resources.DecreaseFontSize_16x16;
            this.tsmiDecreaseFontBookmark.Name = "tsmiDecreaseFontBookmark";
            this.tsmiDecreaseFontBookmark.Size = new System.Drawing.Size(360, 26);
            this.tsmiDecreaseFontBookmark.Text = "Decrease Font Size";
            this.tsmiDecreaseFontBookmark.Click += new System.EventHandler(this.tsmiDecreaseFont_Click);
            // 
            // UCLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UCLogs";
            this.Size = new System.Drawing.Size(2021, 759);
            this.Load += new System.EventHandler(this.UCLogs_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.UCLogs_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.UCLogs_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.cmsMessageOperation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlButtonsHighlight.ResumeLayout(false);
            this.pnlTopFiltering.ResumeLayout(false);
            this.spltFilteringBoth.Panel1.ResumeLayout(false);
            this.spltFilteringBoth.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltFilteringBoth)).EndInit();
            this.spltFilteringBoth.ResumeLayout(false);
            this.pnlFilteringLeft.ResumeLayout(false);
            this.pnlFilteringLeft.PerformLayout();
            this.spltExcludes.Panel1.ResumeLayout(false);
            this.spltExcludes.Panel1.PerformLayout();
            this.spltExcludes.Panel2.ResumeLayout(false);
            this.spltExcludes.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltExcludes)).EndInit();
            this.spltExcludes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltFilteringTop)).EndInit();
            this.spltFilteringTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxInfoExclude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstLogLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcBottom)).EndInit();
            this.tcBottom.ResumeLayout(false);
            this.xtpMessageInfo.ResumeLayout(false);
            this.xtpMessageInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.xtpBookmarks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlBookmarkedMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBookmarkedMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.xtCounts.ResumeLayout(false);
            this.xtCounts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGrouping)).EndInit();
            this.spltGroupByChars.Panel1.ResumeLayout(false);
            this.spltGroupByChars.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltGroupByChars)).EndInit();
            this.spltGroupByChars.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gCtrlGrouping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGrouping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMessageGrouping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGroupBychars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.cmsBookmarked.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
        private GridView logGrid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDataSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnText;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLevel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnClass;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModule;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAudit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnObject;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProcessID;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel pnlTopFiltering;
        private System.Windows.Forms.TextBox txtbInclude;
        private System.Windows.Forms.CheckBox chkbInclude;
        private System.Windows.Forms.CheckBox chkExclude;
        private System.Windows.Forms.TextBox txtbExclude;
        private System.Windows.Forms.RichTextBox rtxtContent;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer tmrRefreshFilter;
        private System.Windows.Forms.ContextMenuStrip cmsMessageOperation;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiExclude;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiOTAFull;
        private System.Windows.Forms.Timer tmrNewData;
        private System.Windows.Forms.Label lblExcludeModule;
        private System.Windows.Forms.TextBox txtbExcludeModule;
        private System.Windows.Forms.CheckBox chkbExcludeSourceAndModule;
        private System.Windows.Forms.TextBox txtbExcludeSource;
        private System.Windows.Forms.SplitContainer spltExcludes;
        private System.Windows.Forms.SplitContainer spltFilteringTop;
        private System.Windows.Forms.PictureBox pboxInfo;
        private System.Windows.Forms.PictureBox pboxInfoExclude;
        private DevExpress.XtraGrid.GridControl gridControlBookmarkedMessages;
        private GridView gridViewBookmarkedMessages;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private System.Windows.Forms.ImageList imageListBottom;
        private System.Windows.Forms.ToolStripMenuItem tsmiBookmark;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddCommentToMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtbHighlight;
        private System.Windows.Forms.CheckBox chkbHighlight;
        private System.Windows.Forms.ToolStripMenuItem tsmiExcludeSource;
        private System.Windows.Forms.ToolStripMenuItem tsmiExcludeModule;
        private System.Windows.Forms.Panel pnlButtonsHighlight;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtpMain;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.ToolStripMenuItem tsmiTimeDiff;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTimeDiff;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.SplitContainer spltFilteringBoth;
        private System.Windows.Forms.Panel pnlFilteringLeft;
        private DevExpress.XtraTab.XtraTabPage xtCounts;
        private System.Windows.Forms.NumericUpDown nudGroupBychars;
        private System.Windows.Forms.Label lblGroupByChars;
        private System.Windows.Forms.SplitContainer spltGroupByChars;
        private DevExpress.XtraGrid.GridControl gridControlMessageGrouping;
        private GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private System.Windows.Forms.Label lblGroupByCharsLimit;
        private System.Windows.Forms.TextBox txtbGroupByCharsLimit;
        private System.Windows.Forms.PictureBox pbGrouping;
        private DevExpress.XtraEditors.SimpleButton btnUp;
        private DevExpress.XtraEditors.SimpleButton btnDown;
        private DevExpress.XtraEditors.LabelControl lblTotalMessages;
        private DevExpress.XtraTab.XtraTabControl tcBottom;
        private DevExpress.XtraTab.XtraTabPage xtpMessageInfo;
        private DevExpress.XtraTab.XtraTabPage xtpBookmarks;
        private DevExpress.XtraBars.StandaloneBarDockControl bdcTopFiltering;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barTopFiltering;
        private DevExpress.XtraBars.Bar BbarMainMenu;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarToggleSwitchItem btswitchExpand;
        private DevExpress.XtraBars.BarButtonItem bBtnSaveLog;
        private DevExpress.XtraBars.BarButtonItem bBtnImport;
        private DevExpress.XtraBars.BarButtonItem bBtnClearLog;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        internal DevExpress.XtraBars.BarToggleSwitchItem btswitchRefreshLog;
        private DevExpress.XtraEditors.SimpleButton sBtnMostCommon;
        private DevExpress.XtraEditors.CheckedListBoxControl chkLstLogLevel;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.SimpleButton sBtnLength;
        private DevExpress.XtraEditors.SimpleButton sBtnGroup;
        private DevExpress.XtraBars.StandaloneBarDockControl bdcMessageBottom;
        private DevExpress.XtraBars.BarButtonItem bBtnExpand;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Bar barMessage;
        private DevExpress.XtraBars.BarButtonItem bBtnButtomExpand;
        private DevExpress.XtraBars.BarButtonItem bBtnCopyButtom;
        private DevExpress.XtraBars.BarToggleSwitchItem btSwitchExpandButtomMessage;
        private DevExpress.XtraBars.StandaloneBarDockControl bdcBookmarks;
        private DevExpress.XtraBars.Bar barBookmark;
        private DevExpress.XtraBars.BarButtonItem bBtnopyBookmarked;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem bBtnGoToMessage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveLayout;
        private System.Windows.Forms.ToolStripMenuItem tsmiBookmarkPersist;
        private System.Windows.Forms.ContextMenuStrip cmsBookmarked;
        private System.Windows.Forms.ToolStripMenuItem tsmiCalcDiffBookmark;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemoveBookmark;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyBookmark;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsmiExcludeBookmark;
        private System.Windows.Forms.ToolStripMenuItem tsmiExcludeSourceBookmark;
        private System.Windows.Forms.ToolStripMenuItem tsmiExcludeModuleBookmark;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmailBookmark;
        private System.Windows.Forms.ToolStripMenuItem tsmiOTAFullBookmark;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveLayoutBookmark;
        private DevExpress.XtraBars.BarButtonItem bBtnRemoveBoomark;
        private DevExpress.XtraGrid.GridControl gCtrlGrouping;
        private GridView gridViewGrouping;
        private DevExpress.XtraEditors.SimpleButton sBtnCancel;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyMessages;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyMessagesBookmark;
        private DevExpress.XtraBars.BarButtonItem bBtnCopyAllBookmarks;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerMain;
        private DevExpress.XtraEditors.SimpleButton sbtnPageFirst;
        private DevExpress.XtraEditors.LabelControl lblPageNumber;
        private DevExpress.XtraEditors.SimpleButton sBtnPageNext;
        private DevExpress.XtraEditors.SimpleButton sBtnLastPage;
        private DevExpress.XtraEditors.SimpleButton sbtnPagePrevious;
        private DevExpress.XtraBars.BarSubItem bSMExports;
        private DevExpress.XtraBars.BarButtonItem bBtnExportExcel;
        private DevExpress.XtraBars.BarButtonItem bBtnExportCSV;
        private DevExpress.XtraBars.BarButtonItem bBtnExportHtml;
        internal DevExpress.XtraBars.BarToggleSwitchItem btsAutoScrollToBottom;
        private DevExpress.XtraBars.BarButtonItem bBtnUndockView;
        private DevExpress.XtraBars.BarButtonItem bBtnSaveEntireLog;
        private System.Windows.Forms.ToolStripMenuItem tsmiIncreaseFont;
        private System.Windows.Forms.ToolStripMenuItem tsmiDecreaseFont;
        private System.Windows.Forms.ToolStripMenuItem tsmiIncreaseFontBookmark;
        private System.Windows.Forms.ToolStripMenuItem tsmiDecreaseFontBookmark;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearLog;
        private System.Windows.Forms.ToolStripMenuItem tsmiREmoveAllPreviousMessages;
        private DevExpress.XtraBars.BarButtonItem bBtnDataVisualizer;
        private DevExpress.XtraBars.BarButtonItem bbiScreenshot;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnThread;
    }
}
