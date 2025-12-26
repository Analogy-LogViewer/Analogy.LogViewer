using DevExpress.XtraGrid.Views.Grid;

namespace Analogy.CommonControls.UserControls
{
    partial class LogMessagesUC
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
            tmrNewData?.Stop();
            tmrNewData?.Dispose();
            if (disposing)
            {

                if (components != null)
                {
                    components.Dispose();

                }
                if (frmDataVisualizer != null && !frmDataVisualizer.IsDisposed)
                    frmDataVisualizer.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogMessagesUC));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.Animation.PushTransition pushTransition1 = new DevExpress.Utils.Animation.PushTransition();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem8 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip9 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem9 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip10 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem8 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem10 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer dockingContainer1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer();
            this.documentGroup1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.documentMessages = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.logGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnDataSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTimeDiff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnObject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProcessID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnThread = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMachineName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRawText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnLineNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMethodName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.chkbHighlight = new DevExpress.XtraEditors.CheckEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barTopFiltering = new DevExpress.XtraBars.Bar();
            this.bbiCollapseFolderPanel = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnClearLog = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnReload = new DevExpress.XtraBars.BarButtonItem();
            this.btswitchMessageDetails = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btswitchRefreshLog = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btsAutoScrollToBottom = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btsiInlineJsonViewer = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.bbiJsonColumn = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGoToActiveMessage = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItemSaveLog = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemSaveEntireInAnalogy = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnSaveViewAgnostic = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnSaveCurrentSelectionAnalogyFormat = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnSaveEntireLog = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnSaveLog = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnSaveCurrentSelectionCustomFormat = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnFullGrid = new DevExpress.XtraBars.BarButtonItem();
            this.bsiUndock = new DevExpress.XtraBars.BarSubItem();
            this.bBtnUndockView = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnUndockViewPerProcess = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnUndockSelection = new DevExpress.XtraBars.BarButtonItem();
            this.bsiSettings = new DevExpress.XtraBars.BarSubItem();
            this.bBtnImport = new DevExpress.XtraBars.BarButtonItem();
            this.bSMExports = new DevExpress.XtraBars.BarSubItem();
            this.bBtnExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnExportCSV = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnExportHtml = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportToSimpleList = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnShare = new DevExpress.XtraBars.BarButtonItem();
            this.bbiScreenshot = new DevExpress.XtraBars.BarButtonItem();
            this.bsiLayouts = new DevExpress.XtraBars.BarSubItem();
            this.bwmiLayout = new DevExpress.XtraBars.BarWorkspaceMenuItem();
            this.wsLogs = new DevExpress.Utils.WorkspaceManager(this.components);
            this.bsiTimeOffset = new DevExpress.XtraBars.BarSubItem();
            this.bciTimeOffset = new DevExpress.XtraBars.BarCheckItem();
            this.bciTimeOffsetPredefined = new DevExpress.XtraBars.BarCheckItem();
            this.bciTimeOffsetUTCToLocal = new DevExpress.XtraBars.BarCheckItem();
            this.bciTimeOffsetLocalToUTC = new DevExpress.XtraBars.BarCheckItem();
            this.bBtnDataVisualizer = new DevExpress.XtraBars.BarButtonItem();
            this.barMessage = new DevExpress.XtraBars.Bar();
            this.bBtnCopyButtom = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGoToMessage = new DevExpress.XtraBars.BarButtonItem();
            this.btsViewAsHTML = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.bbtnRawMessageViewer = new DevExpress.XtraBars.BarButtonItem();
            this.sbarMessageInfo = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barGroup = new DevExpress.XtraBars.Bar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bstaticTotalMessages = new DevExpress.XtraBars.BarStaticItem();
            this.bstaticAlert = new DevExpress.XtraBars.BarStaticItem();
            this.bbtnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.bprogressBar = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.bsiProgress = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bdcTopFiltering = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.bBtnExpand = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.bBtnButtomExpand = new DevExpress.XtraBars.BarButtonItem();
            this.btSwitchExpandButtomMessage = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.bbiDiffTime = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDatetiemFilterFrom = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDatetiemFilterTo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCopyMessage = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCopyAllMessages = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAddNoteToMessage = new DevExpress.XtraBars.BarButtonItem();
            this.bbiIncludeMessage = new DevExpress.XtraBars.BarButtonItem();
            this.bbiIncludeColumnHeaderFilter = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExcludeMessage = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExcludeSource = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExcludeModule = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiIncreaseFontSize = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDecreaseFontSize = new DevExpress.XtraBars.BarButtonItem();
            this.bbiIncludeSource = new DevExpress.XtraBars.BarButtonItem();
            this.bbiIncludeModule = new DevExpress.XtraBars.BarButtonItem();
            this.bbiJsonViewer = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.repositoryItemProgressBar2 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.ddbGoTo = new DevExpress.XtraEditors.DropDownButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.deOlderThanFilter = new DevExpress.XtraEditors.DateEdit();
            this.sbtnIncludeModules = new DevExpress.XtraEditors.SimpleButton();
            this.ceOlderThanFilter = new DevExpress.XtraEditors.CheckEdit();
            this.deNewerThanFilter = new DevExpress.XtraEditors.DateEdit();
            this.ceNewerThanFilter = new DevExpress.XtraEditors.CheckEdit();
            this.ceModulesProcess = new DevExpress.XtraEditors.CheckEdit();
            this.txtbModule = new DevExpress.XtraEditors.TextEdit();
            this.sbtnIncludeSources = new DevExpress.XtraEditors.SimpleButton();
            this.ceSources = new DevExpress.XtraEditors.CheckEdit();
            this.txtbSource = new DevExpress.XtraEditors.TextEdit();
            this.sbtnTextExclude = new DevExpress.XtraEditors.SimpleButton();
            this.txtbExclude = new DevExpress.XtraEditors.TextEdit();
            this.sBtnMostCommon = new DevExpress.XtraEditors.SimpleButton();
            this.ceExcludeText = new DevExpress.XtraEditors.CheckEdit();
            this.sbtnPreDefinedFilters = new DevExpress.XtraEditors.SimpleButton();
            this.txtbInclude = new DevExpress.XtraEditors.TextEdit();
            this.sbtnTextInclude = new DevExpress.XtraEditors.SimpleButton();
            this.ceIncludeText = new DevExpress.XtraEditors.CheckEdit();
            this.defaultToolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.ceSearchEverywhere = new DevExpress.XtraEditors.CheckEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.popupMenuGoTo = new DevExpress.XtraBars.PopupMenu(this.components);
            this.layoutControlLogs = new DevExpress.XtraLayout.LayoutControl();
            this.spltcMessages = new DevExpress.XtraEditors.SplitContainerControl();
            this.sbtnPageFirst = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnMoreHighlight = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnPagePrevious = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnPageNext = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnLastPage = new DevExpress.XtraEditors.SimpleButton();
            this.txtbHighlight = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblPageNumber = new DevExpress.XtraLayout.SimpleLabelItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkLstLogLevel = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.imageListBottom = new System.Windows.Forms.ImageList(this.components);
            this.tmrNewData = new System.Windows.Forms.Timer(this.components);
            this.ceFilterPanelFilter = new DevExpress.XtraEditors.CheckEdit();
            this.ceFilterPanelSearch = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sbtnToggleSearchFilter = new DevExpress.XtraEditors.SimpleButton();
            this.pnlExtraFilters = new System.Windows.Forms.Panel();
            this.xtcFilters = new DevExpress.XtraTab.XtraTabControl();
            this.xtpFiltersIncludes = new DevExpress.XtraTab.XtraTabPage();
            this.clbInclude = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.xtpFiltersExclude = new DevExpress.XtraTab.XtraTabPage();
            this.clbExclude = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.xtpServerSide = new DevExpress.XtraTab.XtraTabPage();
            this.sbtnServerSide = new DevExpress.XtraEditors.SimpleButton();
            this.pnlLevel = new DevExpress.XtraEditors.PanelControl();
            this.pnlLevelFilteringType = new DevExpress.XtraEditors.PanelControl();
            this.ceLogLevelOr = new DevExpress.XtraEditors.CheckEdit();
            this.ceLogLevelAnd = new DevExpress.XtraEditors.CheckEdit();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.LogGridPopupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanelLogs = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelMessageInfo = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.scMessageDetails = new DevExpress.XtraEditors.SplitContainerControl();
            this.meMessageDetails = new DevExpress.XtraEditors.MemoEdit();
            this.recMessageDetails = new DevExpress.XtraRichEdit.RichEditControl();
            this.dockPanelFiltering = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer2 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.xtabFilters = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtpSQLraw = new DevExpress.XtraTab.XtraTabPage();
            this.sbtnRawFilter = new DevExpress.XtraEditors.SimpleButton();
            this.meRawSQL = new DevExpress.XtraEditors.MemoEdit();
            this.dockPanelTree = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelTreeContainer = new DevExpress.XtraBars.Docking.ControlContainer();
            this.filtersPopupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bbiBookmark = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkbHighlight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deOlderThanFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOlderThanFilter.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceOlderThanFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNewerThanFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNewerThanFilter.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceNewerThanFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceModulesProcess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbModule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSources.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbExclude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceExcludeText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbInclude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIncludeText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSearchEverywhere.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuGoTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlLogs)).BeginInit();
            this.layoutControlLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltcMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltcMessages.Panel1)).BeginInit();
            this.spltcMessages.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltcMessages.Panel2)).BeginInit();
            this.spltcMessages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbHighlight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPageNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstLogLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFilterPanelFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFilterPanelSearch.Properties)).BeginInit();
            this.pnlExtraFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtcFilters)).BeginInit();
            this.xtcFilters.SuspendLayout();
            this.xtpFiltersIncludes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clbInclude)).BeginInit();
            this.xtpFiltersExclude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clbExclude)).BeginInit();
            this.xtpServerSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLevel)).BeginInit();
            this.pnlLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLevelFilteringType)).BeginInit();
            this.pnlLevelFilteringType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceLogLevelOr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceLogLevelAnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogGridPopupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanelLogs.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            this.dockPanelMessageInfo.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMessageDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scMessageDetails.Panel1)).BeginInit();
            this.scMessageDetails.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMessageDetails.Panel2)).BeginInit();
            this.scMessageDetails.Panel2.SuspendLayout();
            this.scMessageDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meMessageDetails.Properties)).BeginInit();
            this.dockPanelFiltering.SuspendLayout();
            this.controlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtabFilters)).BeginInit();
            this.xtabFilters.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtpSQLraw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meRawSQL.Properties)).BeginInit();
            this.dockPanelTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filtersPopupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // documentGroup1
            // 
            this.documentGroup1.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.documentMessages});
            // 
            // documentMessages
            // 
            this.documentMessages.Caption = "Logs";
            this.documentMessages.ControlName = "dockPanelLogs";
            this.documentMessages.ControlTypeName = null;
            this.documentMessages.FloatLocation = new System.Drawing.Point(0, 0);
            this.documentMessages.FloatSize = new System.Drawing.Size(200, 200);
            this.documentMessages.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            this.documentMessages.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.documentMessages.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.logGrid;
            this.gridControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1368, 201);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.logGrid});
            this.gridControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LogGrid_KeyPress);
            // 
            // logGrid
            // 
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
            this.gridColumnUser,
            this.gridColumnModule,
            this.gridColumnObject,
            this.gridColumnProcessID,
            this.gridColumnThread,
            this.gridColumnMachineName,
            this.gridColumnRawText,
            this.gridColumnLineNumber,
            this.gridColumnMethodName});
            this.logGrid.DetailHeight = 431;
            this.logGrid.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.logGrid.GridControl = this.gridControl;
            this.logGrid.Images = this.imageList;
            this.logGrid.IndicatorWidth = 24;
            this.logGrid.Name = "logGrid";
            this.logGrid.OptionsBehavior.AllowIncrementalSearch = true;
            this.logGrid.OptionsFilter.AllowColumnMRUFilterList = false;
            this.logGrid.OptionsFilter.AllowMRUFilterList = false;
            this.logGrid.OptionsFind.AlwaysVisible = true;
            this.logGrid.OptionsLayout.Columns.StoreAllOptions = true;
            this.logGrid.OptionsLayout.Columns.StoreAppearance = true;
            this.logGrid.OptionsLayout.StoreAllOptions = true;
            this.logGrid.OptionsLayout.StoreAppearance = true;
            this.logGrid.OptionsLayout.StoreFormatRules = true;
            this.logGrid.OptionsMenu.ShowConditionalFormattingItem = true;
            this.logGrid.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.logGrid.OptionsView.AutoCalcPreviewLineCount = true;
            this.logGrid.OptionsView.ColumnAutoWidth = false;
            this.logGrid.OptionsView.RowAutoHeight = true;
            this.logGrid.OptionsView.ShowAutoFilterRow = true;
            this.logGrid.OptionsView.ShowGroupPanel = false;
            this.logGrid.ShowFilterPopupListBox += new DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventHandler(this.GridViewShowFilterPopupListBox);
            this.logGrid.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.LogGridViewCustomColumnDisplayText);
            this.logGrid.Click += new System.EventHandler(this.logGrid_Click);
            this.logGrid.DoubleClick += new System.EventHandler(this.LogGrid_DoubleClick);
            // 
            // gridColumnDataSource
            // 
            this.gridColumnDataSource.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnDataSource.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnDataSource.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.gridColumnDataSource.Caption = "Data Source/File Name";
            this.gridColumnDataSource.FieldName = "DataProvider";
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
            this.gridColumnDate.DisplayFormat.FormatString = "yyyy.MM.dd HH:mm:ss.fffffff";
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
            this.gridColumnTimeDiff.OptionsColumn.AllowEdit = false;
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
            this.gridColumnLevel.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)});
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
            this.gridColumnUser.VisibleIndex = 7;
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
            this.gridColumnModule.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnModule.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnModule.OptionsColumn.ReadOnly = true;
            this.gridColumnModule.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.gridColumnModule.Visible = true;
            this.gridColumnModule.VisibleIndex = 5;
            this.gridColumnModule.Width = 115;
            // 
            // gridColumnObject
            // 
            this.gridColumnObject.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnObject.AppearanceCell.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.gridColumnObject.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
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
            this.gridColumnProcessID.Caption = "Process ID";
            this.gridColumnProcessID.FieldName = "ProcessId";
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
            this.gridColumnProcessID.VisibleIndex = 8;
            this.gridColumnProcessID.Width = 115;
            // 
            // gridColumnThread
            // 
            this.gridColumnThread.Caption = "Thread ID";
            this.gridColumnThread.FieldName = "ThreadId";
            this.gridColumnThread.MinWidth = 25;
            this.gridColumnThread.Name = "gridColumnThread";
            this.gridColumnThread.OptionsColumn.AllowEdit = false;
            this.gridColumnThread.Visible = true;
            this.gridColumnThread.VisibleIndex = 9;
            this.gridColumnThread.Width = 109;
            // 
            // gridColumnMachineName
            // 
            this.gridColumnMachineName.Caption = "Machine Name";
            this.gridColumnMachineName.FieldName = "MachineName";
            this.gridColumnMachineName.MinWidth = 25;
            this.gridColumnMachineName.Name = "gridColumnMachineName";
            this.gridColumnMachineName.OptionsColumn.AllowEdit = false;
            this.gridColumnMachineName.Visible = true;
            this.gridColumnMachineName.VisibleIndex = 10;
            this.gridColumnMachineName.Width = 94;
            // 
            // gridColumnRawText
            // 
            this.gridColumnRawText.Caption = "Raw Text";
            this.gridColumnRawText.FieldName = "RawText";
            this.gridColumnRawText.MinWidth = 25;
            this.gridColumnRawText.Name = "gridColumnRawText";
            this.gridColumnRawText.Visible = true;
            this.gridColumnRawText.VisibleIndex = 11;
            this.gridColumnRawText.Width = 94;
            // 
            // gridColumnLineNumber
            // 
            this.gridColumnLineNumber.Caption = "Line Number";
            this.gridColumnLineNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumnLineNumber.FieldName = "LineNumber";
            this.gridColumnLineNumber.MinWidth = 25;
            this.gridColumnLineNumber.Name = "gridColumnLineNumber";
            this.gridColumnLineNumber.Visible = true;
            this.gridColumnLineNumber.VisibleIndex = 12;
            this.gridColumnLineNumber.Width = 94;
            // 
            // gridColumnMethodName
            // 
            this.gridColumnMethodName.Caption = "Method Name";
            this.gridColumnMethodName.FieldName = "MethodName";
            this.gridColumnMethodName.MinWidth = 25;
            this.gridColumnMethodName.Name = "gridColumnMethodName";
            this.gridColumnMethodName.Visible = true;
            this.gridColumnMethodName.VisibleIndex = 13;
            this.gridColumnMethodName.Width = 94;
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
            this.imageList.Images.SetKeyName(8, "Analogy_icon1_16x16.ico");
            this.imageList.Images.SetKeyName(9, "Question_16x16.png");
            this.imageList.Images.SetKeyName(10, "log16x16.ico");
            // 
            // chkbHighlight
            // 
            this.chkbHighlight.Location = new System.Drawing.Point(8, 213);
            this.chkbHighlight.MenuManager = this.barManager1;
            this.chkbHighlight.Name = "chkbHighlight";
            this.chkbHighlight.Properties.Caption = "Highlight lines which contain:";
            this.chkbHighlight.Size = new System.Drawing.Size(194, 24);
            this.chkbHighlight.StyleController = this.layoutControlLogs;
            this.chkbHighlight.TabIndex = 2;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barTopFiltering,
            this.barMessage,
            this.barGroup,
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.bdcTopFiltering);
            this.barManager1.DockControls.Add(this.sbarMessageInfo);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btswitchMessageDetails,
            this.btswitchRefreshLog,
            this.bBtnSaveLog,
            this.bBtnImport,
            this.bBtnClearLog,
            this.bBtnExpand,
            this.barButtonItem3,
            this.bBtnButtomExpand,
            this.bBtnCopyButtom,
            this.btSwitchExpandButtomMessage,
            this.btsAutoScrollToBottom,
            this.bSMExports,
            this.bBtnExportExcel,
            this.bBtnExportCSV,
            this.bBtnExportHtml,
            this.bBtnUndockView,
            this.bBtnSaveEntireLog,
            this.bBtnDataVisualizer,
            this.bbiScreenshot,
            this.bbtnSaveViewAgnostic,
            this.barSubItemSaveLog,
            this.barButtonItemSaveEntireInAnalogy,
            this.bsiUndock,
            this.bBtnUndockViewPerProcess,
            this.bBtnShare,
            this.bBtnFullGrid,
            this.bbtnReload,
            this.bBtnSaveCurrentSelectionCustomFormat,
            this.bBtnSaveCurrentSelectionAnalogyFormat,
            this.bBtnUndockSelection,
            this.bbiDiffTime,
            this.bbiDatetiemFilterFrom,
            this.bbiDatetiemFilterTo,
            this.bbiCopyMessage,
            this.bbiCopyAllMessages,
            this.bbiAddNoteToMessage,
            this.bbiIncludeMessage,
            this.bbiIncludeColumnHeaderFilter,
            this.bbiExcludeMessage,
            this.bbiExcludeSource,
            this.bbiExcludeModule,
            this.bbiSaveLayout,
            this.bbiIncreaseFontSize,
            this.bbiDecreaseFontSize,
            this.bbiIncludeSource,
            this.bbiIncludeModule,
            this.bbiJsonViewer,
            this.bbtnCancel,
            this.bstaticTotalMessages,
            this.bstaticAlert,
            this.bprogressBar,
            this.bsiSettings,
            this.bwmiLayout,
            this.bsiLayouts,
            this.bbiGoToMessage,
            this.bbiGoToActiveMessage,
            this.btsViewAsHTML,
            this.bbtnRawMessageViewer,
            this.bsiTimeOffset,
            this.bciTimeOffset,
            this.bciTimeOffsetPredefined,
            this.bciTimeOffsetUTCToLocal,
            this.bciTimeOffsetLocalToUTC,
            this.btsiInlineJsonViewer,
            this.bsiProgress,
            this.bbiJsonColumn,
            this.bbiExportToSimpleList,
            this.bbiCollapseFolderPanel,
            this.bbiBookmark});
            this.barManager1.MaxItemId = 96;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1,
            this.repositoryItemProgressBar2,
            this.repositoryItemMarqueeProgressBar1});
            this.barManager1.StatusBar = this.bar1;
            // 
            // barTopFiltering
            // 
            this.barTopFiltering.BarName = "Log Operations";
            this.barTopFiltering.DockCol = 0;
            this.barTopFiltering.DockRow = 0;
            this.barTopFiltering.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barTopFiltering.FloatLocation = new System.Drawing.Point(104, 140);
            this.barTopFiltering.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCollapseFolderPanel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnClearLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnReload),
            new DevExpress.XtraBars.LinkPersistInfo(this.btswitchMessageDetails),
            new DevExpress.XtraBars.LinkPersistInfo(this.btswitchRefreshLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.btsAutoScrollToBottom),
            new DevExpress.XtraBars.LinkPersistInfo(this.btsiInlineJsonViewer),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiJsonColumn),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiGoToActiveMessage, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItemSaveLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnFullGrid),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiUndock),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiSettings)});
            this.barTopFiltering.OptionsBar.AllowQuickCustomization = false;
            this.barTopFiltering.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.barTopFiltering.OptionsBar.DisableClose = true;
            this.barTopFiltering.OptionsBar.DisableCustomization = true;
            this.barTopFiltering.OptionsBar.UseWholeRow = true;
            this.barTopFiltering.Text = "Operations";
            // 
            // bbiCollapseFolderPanel
            // 
            this.bbiCollapseFolderPanel.Id = 94;
            this.bbiCollapseFolderPanel.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Stretch_16x16;
            this.bbiCollapseFolderPanel.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.Stretch_32x32;
            this.bbiCollapseFolderPanel.Name = "bbiCollapseFolderPanel";
            toolTipItem1.Text = "Toggle collapse of Folder and files panel";
            superToolTip1.Items.Add(toolTipItem1);
            this.bbiCollapseFolderPanel.SuperTip = superToolTip1;
            // 
            // bBtnClearLog
            // 
            this.bBtnClearLog.Caption = "Clear Log";
            this.bBtnClearLog.Id = 6;
            this.bBtnClearLog.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Action_Delete;
            this.bBtnClearLog.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.Action_Delete_32x32;
            this.bBtnClearLog.Name = "bBtnClearLog";
            this.bBtnClearLog.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnClearLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnClearLog_ItemClick);
            // 
            // bbtnReload
            // 
            this.bbtnReload.Caption = "Reload Files";
            this.bbtnReload.Id = 38;
            this.bbtnReload.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Refresh2_16x16;
            this.bbtnReload.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.Refresh2_32x32;
            this.bbtnReload.Name = "bbtnReload";
            this.bbtnReload.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbtnReload.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btswitchMessageDetails
            // 
            this.btswitchMessageDetails.BindableChecked = true;
            this.btswitchMessageDetails.Caption = "Message Details";
            this.btswitchMessageDetails.Checked = true;
            this.btswitchMessageDetails.Hint = "Show/Hide selected message details (CTRL+D)";
            this.btswitchMessageDetails.Id = 2;
            this.btswitchMessageDetails.Name = "btswitchMessageDetails";
            this.btswitchMessageDetails.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.btswitchExpand_CheckedChanged);
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
            this.btsAutoScrollToBottom.Caption = "Scroll to newest message:";
            this.btsAutoScrollToBottom.Id = 18;
            this.btsAutoScrollToBottom.Name = "btsAutoScrollToBottom";
            this.btsAutoScrollToBottom.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.btsAutoScrollToBottom_CheckedChanged);
            // 
            // btsiInlineJsonViewer
            // 
            this.btsiInlineJsonViewer.Caption = "Inline Json Viewer";
            this.btsiInlineJsonViewer.Id = 89;
            this.btsiInlineJsonViewer.Name = "btsiInlineJsonViewer";
            // 
            // bbiJsonColumn
            // 
            this.bbiJsonColumn.ActAsDropDown = true;
            this.bbiJsonColumn.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.bbiJsonColumn.Caption = "bbiJsonColumn";
            this.bbiJsonColumn.Id = 92;
            this.bbiJsonColumn.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.json16x16;
            this.bbiJsonColumn.Name = "bbiJsonColumn";
            toolTipItem2.Text = "Choose which column will be used for the Json inline parsing";
            superToolTip2.Items.Add(toolTipItem2);
            this.bbiJsonColumn.SuperTip = superToolTip2;
            // 
            // bbiGoToActiveMessage
            // 
            this.bbiGoToActiveMessage.Caption = "Go To Active Message";
            this.bbiGoToActiveMessage.Id = 75;
            this.bbiGoToActiveMessage.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.GoToPreviousHeaderFooter_16x16;
            this.bbiGoToActiveMessage.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.GoToPreviousHeaderFooter_32x32;
            this.bbiGoToActiveMessage.Name = "bbiGoToActiveMessage";
            // 
            // barSubItemSaveLog
            // 
            this.barSubItemSaveLog.Caption = "Save Log";
            this.barSubItemSaveLog.Id = 31;
            this.barSubItemSaveLog.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.SaveTo_16x16;
            this.barSubItemSaveLog.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.SaveTo_32x32;
            this.barSubItemSaveLog.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSaveEntireInAnalogy),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnSaveViewAgnostic),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnSaveCurrentSelectionAnalogyFormat),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnSaveEntireLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnSaveLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnSaveCurrentSelectionCustomFormat)});
            this.barSubItemSaveLog.Name = "barSubItemSaveLog";
            this.barSubItemSaveLog.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItemSaveEntireInAnalogy
            // 
            this.barButtonItemSaveEntireInAnalogy.Caption = "Save entire log in Analogy Format (agnostic to specific implementation)";
            this.barButtonItemSaveEntireInAnalogy.Id = 32;
            this.barButtonItemSaveEntireInAnalogy.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Save_16x16;
            this.barButtonItemSaveEntireInAnalogy.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.SaveDialog_32x32;
            this.barButtonItemSaveEntireInAnalogy.Name = "barButtonItemSaveEntireInAnalogy";
            this.barButtonItemSaveEntireInAnalogy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarButtonItemSaveEntireInAnalogy_ItemClick);
            // 
            // bbtnSaveViewAgnostic
            // 
            this.bbtnSaveViewAgnostic.Caption = "Save current view in Analogy Format (agnostic to Specific implementation)";
            this.bbtnSaveViewAgnostic.Id = 30;
            this.bbtnSaveViewAgnostic.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.SaveTo_16x16;
            this.bbtnSaveViewAgnostic.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.SaveTo_32x32;
            this.bbtnSaveViewAgnostic.Name = "bbtnSaveViewAgnostic";
            this.bbtnSaveViewAgnostic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BbtnSaveViewAgnostic_ItemClick);
            // 
            // bBtnSaveCurrentSelectionAnalogyFormat
            // 
            this.bBtnSaveCurrentSelectionAnalogyFormat.Caption = "Save current rows selection in Analogy Format (agnostic to Specific implementatio" +
    "n)";
            this.bBtnSaveCurrentSelectionAnalogyFormat.Id = 40;
            this.bBtnSaveCurrentSelectionAnalogyFormat.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Save_16x16;
            this.bBtnSaveCurrentSelectionAnalogyFormat.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.SaveDialog_32x32;
            this.bBtnSaveCurrentSelectionAnalogyFormat.Name = "bBtnSaveCurrentSelectionAnalogyFormat";
            this.bBtnSaveCurrentSelectionAnalogyFormat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnSaveCurrentSelectionAnalogyFormat_ItemClick);
            // 
            // bBtnSaveEntireLog
            // 
            this.bBtnSaveEntireLog.Caption = "Save entire Log (custom Format)";
            this.bBtnSaveEntireLog.Id = 25;
            this.bBtnSaveEntireLog.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.SaveTo_16x16;
            this.bBtnSaveEntireLog.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.SaveTo_32x32;
            this.bBtnSaveEntireLog.Name = "bBtnSaveEntireLog";
            this.bBtnSaveEntireLog.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnSaveEntireLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnSaveEntireLog_ItemClick);
            // 
            // bBtnSaveLog
            // 
            this.bBtnSaveLog.Caption = "Save current view (custom Format)";
            this.bBtnSaveLog.Id = 4;
            this.bBtnSaveLog.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.SaveTo_16x16;
            this.bBtnSaveLog.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.SaveDialog_32x32;
            this.bBtnSaveLog.Name = "bBtnSaveLog";
            this.bBtnSaveLog.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnSaveLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnSaveLog_ItemClick);
            // 
            // bBtnSaveCurrentSelectionCustomFormat
            // 
            this.bBtnSaveCurrentSelectionCustomFormat.Caption = "save current rows selection (custom Format)";
            this.bBtnSaveCurrentSelectionCustomFormat.Id = 39;
            this.bBtnSaveCurrentSelectionCustomFormat.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.SaveTo_16x16;
            this.bBtnSaveCurrentSelectionCustomFormat.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.SaveTo_32x32;
            this.bBtnSaveCurrentSelectionCustomFormat.Name = "bBtnSaveCurrentSelectionCustomFormat";
            this.bBtnSaveCurrentSelectionCustomFormat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnSaveCurrentSelectionCustomFormat_ItemClick);
            // 
            // bBtnFullGrid
            // 
            this.bBtnFullGrid.Caption = "Full";
            this.bBtnFullGrid.Id = 37;
            this.bBtnFullGrid.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.FullscreenBlue16;
            this.bBtnFullGrid.Name = "bBtnFullGrid";
            this.bBtnFullGrid.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bsiUndock
            // 
            this.bsiUndock.Caption = "Undock View";
            this.bsiUndock.Id = 34;
            this.bsiUndock.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.FullExtent_16x16;
            this.bsiUndock.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.FullExtent_32x32;
            this.bsiUndock.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnUndockView),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnUndockViewPerProcess),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnUndockSelection)});
            this.bsiUndock.Name = "bsiUndock";
            this.bsiUndock.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bBtnUndockView
            // 
            this.bBtnUndockView.Caption = "Undock View (No Filtering)";
            this.bBtnUndockView.Id = 24;
            this.bBtnUndockView.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.FullExtent_16x16;
            this.bBtnUndockView.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.FullExtent_32x32;
            this.bBtnUndockView.Name = "bBtnUndockView";
            this.bBtnUndockView.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnUndockView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnUndockView_ItemClick);
            // 
            // bBtnUndockViewPerProcess
            // 
            this.bBtnUndockViewPerProcess.Caption = "Undock View per process/Module";
            this.bBtnUndockViewPerProcess.Id = 35;
            this.bBtnUndockViewPerProcess.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.FullExtent_16x16;
            this.bBtnUndockViewPerProcess.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.FullExtent_32x32;
            this.bBtnUndockViewPerProcess.Name = "bBtnUndockViewPerProcess";
            this.bBtnUndockViewPerProcess.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnUndockViewPerProcess_ItemClick);
            // 
            // bBtnUndockSelection
            // 
            this.bBtnUndockSelection.Caption = "Undock rows selection";
            this.bBtnUndockSelection.Id = 41;
            this.bBtnUndockSelection.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.FullExtent_16x16;
            this.bBtnUndockSelection.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.FullExtent_32x32;
            this.bBtnUndockSelection.Name = "bBtnUndockSelection";
            this.bBtnUndockSelection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnUndockSelection_ItemClick);
            // 
            // bsiSettings
            // 
            this.bsiSettings.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiSettings.Caption = "More";
            this.bsiSettings.Id = 71;
            this.bsiSettings.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Properties_16x16;
            this.bsiSettings.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.Properties_32x32;
            this.bsiSettings.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnImport),
            new DevExpress.XtraBars.LinkPersistInfo(this.bSMExports),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnShare),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiScreenshot),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiLayouts),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiTimeOffset),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnDataVisualizer)});
            this.bsiSettings.Name = "bsiSettings";
            this.bsiSettings.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bBtnImport
            // 
            this.bBtnImport.Caption = "Import Log";
            this.bBtnImport.Id = 5;
            this.bBtnImport.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Insert_16x16;
            this.bBtnImport.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.Insert_32x32;
            this.bBtnImport.Name = "bBtnImport";
            this.bBtnImport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnImport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bBtnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnImport_ItemClick);
            // 
            // bSMExports
            // 
            this.bSMExports.Caption = "Export Log";
            this.bSMExports.Id = 20;
            this.bSMExports.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Export_16x16;
            this.bSMExports.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.Export_32x32;
            this.bSMExports.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bBtnExportExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnExportCSV),
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnExportHtml),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExportToSimpleList)});
            this.bSMExports.Name = "bSMExports";
            this.bSMExports.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bBtnExportExcel
            // 
            this.bBtnExportExcel.Caption = "Export To Excel";
            this.bBtnExportExcel.Id = 21;
            this.bBtnExportExcel.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.ExportToXLS_16x16;
            this.bBtnExportExcel.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.ExportToXLS_32x32;
            this.bBtnExportExcel.Name = "bBtnExportExcel";
            this.bBtnExportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnExportExcel_ItemClick);
            // 
            // bBtnExportCSV
            // 
            this.bBtnExportCSV.Caption = "Export To CSV";
            this.bBtnExportCSV.Id = 22;
            this.bBtnExportCSV.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.ExportToCSV_16x16;
            this.bBtnExportCSV.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.ExportToCSV_32x32;
            this.bBtnExportCSV.Name = "bBtnExportCSV";
            this.bBtnExportCSV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnExportCSV_ItemClick);
            // 
            // bBtnExportHtml
            // 
            this.bBtnExportHtml.Caption = "Export To Html";
            this.bBtnExportHtml.Id = 23;
            this.bBtnExportHtml.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.ExportToHTML_16x16;
            this.bBtnExportHtml.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.ExportToHTML_32x32;
            this.bBtnExportHtml.Name = "bBtnExportHtml";
            this.bBtnExportHtml.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnExportHtml.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bBtnExportHtml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnExportHtml_ItemClick);
            // 
            // bbiExportToSimpleList
            // 
            this.bbiExportToSimpleList.Caption = "Export to simple list";
            this.bbiExportToSimpleList.Id = 93;
            this.bbiExportToSimpleList.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Watermark_16x16;
            this.bbiExportToSimpleList.Name = "bbiExportToSimpleList";
            // 
            // bBtnShare
            // 
            this.bBtnShare.Caption = "Share Log";
            this.bBtnShare.Id = 36;
            this.bBtnShare.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.upload16x16;
            this.bBtnShare.Name = "bBtnShare";
            this.bBtnShare.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bbiScreenshot
            // 
            this.bbiScreenshot.Caption = "Take screenshot";
            this.bbiScreenshot.Hint = "Take screenshot of the messages control";
            this.bbiScreenshot.Id = 27;
            this.bbiScreenshot.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Image_16x16;
            this.bbiScreenshot.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.ImportImage_32x32;
            this.bbiScreenshot.Name = "bbiScreenshot";
            this.bbiScreenshot.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiScreenshot.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiScreenshot_ItemClick);
            // 
            // bsiLayouts
            // 
            this.bsiLayouts.Caption = "Windows Layouts";
            this.bsiLayouts.Id = 73;
            this.bsiLayouts.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.TableLayout_16x16;
            this.bsiLayouts.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.TableLayout_32x32;
            this.bsiLayouts.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bwmiLayout)});
            this.bsiLayouts.Name = "bsiLayouts";
            // 
            // bwmiLayout
            // 
            this.bwmiLayout.Caption = "Windows Layout";
            this.bwmiLayout.Id = 72;
            this.bwmiLayout.Name = "bwmiLayout";
            this.bwmiLayout.ShowSaveLoadCommands = true;
            this.bwmiLayout.WorkspaceManager = this.wsLogs;
            // 
            // wsLogs
            // 
            this.wsLogs.TargetControl = this;
            this.wsLogs.TransitionType = pushTransition1;
            // 
            // bsiTimeOffset
            // 
            this.bsiTimeOffset.Caption = "Change Time offset";
            this.bsiTimeOffset.Id = 83;
            this.bsiTimeOffset.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Time2_16x16;
            this.bsiTimeOffset.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.Time2_32x32;
            this.bsiTimeOffset.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bciTimeOffset),
            new DevExpress.XtraBars.LinkPersistInfo(this.bciTimeOffsetPredefined),
            new DevExpress.XtraBars.LinkPersistInfo(this.bciTimeOffsetUTCToLocal),
            new DevExpress.XtraBars.LinkPersistInfo(this.bciTimeOffsetLocalToUTC)});
            this.bsiTimeOffset.Name = "bsiTimeOffset";
            // 
            // bciTimeOffset
            // 
            this.bciTimeOffset.Caption = "No Time Offset";
            this.bciTimeOffset.GroupIndex = 10;
            this.bciTimeOffset.Id = 85;
            this.bciTimeOffset.Name = "bciTimeOffset";
            // 
            // bciTimeOffsetPredefined
            // 
            this.bciTimeOffsetPredefined.Caption = "Predefined Offset";
            this.bciTimeOffsetPredefined.GroupIndex = 10;
            this.bciTimeOffsetPredefined.Id = 86;
            this.bciTimeOffsetPredefined.Name = "bciTimeOffsetPredefined";
            // 
            // bciTimeOffsetUTCToLocal
            // 
            this.bciTimeOffsetUTCToLocal.Caption = "UTC To Local Time";
            this.bciTimeOffsetUTCToLocal.GroupIndex = 10;
            this.bciTimeOffsetUTCToLocal.Id = 87;
            this.bciTimeOffsetUTCToLocal.Name = "bciTimeOffsetUTCToLocal";
            // 
            // bciTimeOffsetLocalToUTC
            // 
            this.bciTimeOffsetLocalToUTC.Caption = "Local Time To UTC";
            this.bciTimeOffsetLocalToUTC.GroupIndex = 10;
            this.bciTimeOffsetLocalToUTC.Id = 88;
            this.bciTimeOffsetLocalToUTC.Name = "bciTimeOffsetLocalToUTC";
            // 
            // bBtnDataVisualizer
            // 
            this.bBtnDataVisualizer.Caption = "Data Visualizer";
            this.bBtnDataVisualizer.Id = 26;
            this.bBtnDataVisualizer.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Line_16x16;
            this.bBtnDataVisualizer.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.Line_32x32;
            this.bBtnDataVisualizer.Name = "bBtnDataVisualizer";
            this.bBtnDataVisualizer.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnDataVisualizer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnDataVisualizer_ItemClick);
            // 
            // barMessage
            // 
            this.barMessage.BarName = "Message";
            this.barMessage.DockCol = 0;
            this.barMessage.DockRow = 0;
            this.barMessage.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.barMessage.FloatLocation = new System.Drawing.Point(901, 601);
            this.barMessage.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnCopyButtom),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiGoToMessage, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btsViewAsHTML),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnRawMessageViewer)});
            this.barMessage.OptionsBar.AllowCollapse = true;
            this.barMessage.OptionsBar.AllowDelete = true;
            this.barMessage.OptionsBar.AllowQuickCustomization = false;
            this.barMessage.OptionsBar.AllowRename = true;
            this.barMessage.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.barMessage.OptionsBar.DisableClose = true;
            this.barMessage.OptionsBar.DisableCustomization = true;
            this.barMessage.OptionsBar.UseWholeRow = true;
            this.barMessage.StandaloneBarDockControl = this.sbarMessageInfo;
            this.barMessage.Text = "Message Info";
            // 
            // bBtnCopyButtom
            // 
            this.bBtnCopyButtom.Caption = "Copy";
            this.bBtnCopyButtom.Id = 10;
            this.bBtnCopyButtom.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Copy_16x16;
            this.bBtnCopyButtom.Name = "bBtnCopyButtom";
            this.bBtnCopyButtom.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bBtnCopyButtom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bBtnCopyButtom_ItemClick);
            // 
            // bbiGoToMessage
            // 
            this.bbiGoToMessage.Caption = "Go To This Message";
            this.bbiGoToMessage.Id = 74;
            this.bbiGoToMessage.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.GoToPreviousHeaderFooter_16x16;
            this.bbiGoToMessage.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.GoToPreviousHeaderFooter_32x32;
            this.bbiGoToMessage.Name = "bbiGoToMessage";
            // 
            // btsViewAsHTML
            // 
            this.btsViewAsHTML.Caption = "View as HTML";
            this.btsViewAsHTML.Id = 76;
            this.btsViewAsHTML.Name = "btsViewAsHTML";
            // 
            // bbtnRawMessageViewer
            // 
            this.bbtnRawMessageViewer.Caption = "Raw Data Viewer";
            this.bbtnRawMessageViewer.Id = 77;
            this.bbtnRawMessageViewer.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.json16x16;
            this.bbtnRawMessageViewer.Name = "bbtnRawMessageViewer";
            this.bbtnRawMessageViewer.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbtnRawMessageViewer.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // sbarMessageInfo
            // 
            this.sbarMessageInfo.AutoSize = true;
            this.sbarMessageInfo.CausesValidation = false;
            this.sbarMessageInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.sbarMessageInfo.Location = new System.Drawing.Point(0, 0);
            this.sbarMessageInfo.Manager = this.barManager1;
            this.sbarMessageInfo.Name = "sbarMessageInfo";
            this.sbarMessageInfo.Size = new System.Drawing.Size(1845, 30);
            this.sbarMessageInfo.Text = "standaloneBarDockControl1";
            // 
            // barGroup
            // 
            this.barGroup.BarName = "Counts";
            this.barGroup.DockCol = 0;
            this.barGroup.DockRow = 0;
            this.barGroup.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.barGroup.FloatLocation = new System.Drawing.Point(327, 221);
            this.barGroup.OptionsBar.AllowQuickCustomization = false;
            this.barGroup.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.barGroup.OptionsBar.UseWholeRow = true;
            this.barGroup.Text = "Counts";
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 7";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bstaticTotalMessages),
            new DevExpress.XtraBars.LinkPersistInfo(this.bstaticAlert),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbtnCancel),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.bprogressBar, "", false, true, true, 534),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiProgress)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 7";
            // 
            // bstaticTotalMessages
            // 
            this.bstaticTotalMessages.Caption = "Total messages: N/A";
            this.bstaticTotalMessages.Id = 67;
            this.bstaticTotalMessages.Name = "bstaticTotalMessages";
            // 
            // bstaticAlert
            // 
            this.bstaticAlert.Caption = "ALERTS EXISTS: !";
            this.bstaticAlert.Id = 68;
            this.bstaticAlert.Name = "bstaticAlert";
            this.bstaticAlert.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbtnCancel
            // 
            this.bbtnCancel.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbtnCancel.Caption = "Cancel Processing";
            this.bbtnCancel.Id = 66;
            this.bbtnCancel.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Close_16x16;
            this.bbtnCancel.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.Close_32x32;
            this.bbtnCancel.Name = "bbtnCancel";
            this.bbtnCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbtnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bprogressBar
            // 
            this.bprogressBar.AutoFillWidth = true;
            this.bprogressBar.Edit = this.repositoryItemMarqueeProgressBar1;
            this.bprogressBar.Id = 70;
            this.bprogressBar.Name = "bprogressBar";
            this.bprogressBar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bprogressBar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repositoryItemMarqueeProgressBar1
            // 
            this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
            // 
            // bsiProgress
            // 
            this.bsiProgress.Caption = "0/0";
            this.bsiProgress.Id = 90;
            this.bsiProgress.Name = "bsiProgress";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(1853, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 727);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1853, 32);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 697);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1853, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 697);
            // 
            // bdcTopFiltering
            // 
            this.bdcTopFiltering.AutoSize = true;
            this.bdcTopFiltering.CausesValidation = false;
            this.bdcTopFiltering.Dock = System.Windows.Forms.DockStyle.Top;
            this.bdcTopFiltering.Location = new System.Drawing.Point(0, 0);
            this.bdcTopFiltering.Manager = this.barManager1;
            this.bdcTopFiltering.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bdcTopFiltering.Name = "bdcTopFiltering";
            this.bdcTopFiltering.Size = new System.Drawing.Size(1647, 0);
            this.bdcTopFiltering.Text = "standaloneBarDockControl1";
            // 
            // bBtnExpand
            // 
            this.bBtnExpand.Caption = "Expand";
            this.bBtnExpand.Id = 7;
            this.bBtnExpand.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.FullExtent_16x16;
            this.bBtnExpand.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.FullExtent_32x32;
            this.bBtnExpand.Name = "bBtnExpand";
            this.bBtnExpand.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Copy";
            this.barButtonItem3.Id = 8;
            this.barButtonItem3.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Copy_16x16;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bBtnButtomExpand
            // 
            this.bBtnButtomExpand.Caption = "Expand";
            this.bBtnButtomExpand.Id = 9;
            this.bBtnButtomExpand.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.FullExtent_16x16;
            this.bBtnButtomExpand.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.FullExtent_32x32;
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
            // bbiDiffTime
            // 
            this.bbiDiffTime.Caption = "Calculate time difference from this point";
            this.bbiDiffTime.Id = 43;
            this.bbiDiffTime.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Time2_16x16;
            this.bbiDiffTime.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.Time2_32x32;
            this.bbiDiffTime.Name = "bbiDiffTime";
            // 
            // bbiDatetiemFilterFrom
            // 
            this.bbiDatetiemFilterFrom.Caption = "Date Time Filter: From";
            this.bbiDatetiemFilterFrom.Id = 44;
            this.bbiDatetiemFilterFrom.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Time2_16x16;
            this.bbiDatetiemFilterFrom.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.Time2_32x32;
            this.bbiDatetiemFilterFrom.Name = "bbiDatetiemFilterFrom";
            // 
            // bbiDatetiemFilterTo
            // 
            this.bbiDatetiemFilterTo.Caption = "Date Time Filter: To";
            this.bbiDatetiemFilterTo.Id = 45;
            this.bbiDatetiemFilterTo.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Time2_16x16;
            this.bbiDatetiemFilterTo.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.Time2_32x32;
            this.bbiDatetiemFilterTo.Name = "bbiDatetiemFilterTo";
            // 
            // bbiCopyMessage
            // 
            this.bbiCopyMessage.Caption = "Copy selected message to clipboard";
            this.bbiCopyMessage.Id = 48;
            this.bbiCopyMessage.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Copy_16x16;
            this.bbiCopyMessage.Name = "bbiCopyMessage";
            // 
            // bbiCopyAllMessages
            // 
            this.bbiCopyAllMessages.Caption = "Copy all messages in view to clipboard";
            this.bbiCopyAllMessages.Id = 49;
            this.bbiCopyAllMessages.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Copy_16x16;
            this.bbiCopyAllMessages.Name = "bbiCopyAllMessages";
            // 
            // bbiAddNoteToMessage
            // 
            this.bbiAddNoteToMessage.Caption = "Add Note/Comment to this message (not auto saved)";
            this.bbiAddNoteToMessage.Id = 50;
            this.bbiAddNoteToMessage.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.EditComment_16x16;
            this.bbiAddNoteToMessage.Name = "bbiAddNoteToMessage";
            // 
            // bbiIncludeMessage
            // 
            this.bbiIncludeMessage.Caption = "Include Selected message";
            this.bbiIncludeMessage.Id = 51;
            this.bbiIncludeMessage.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.MultipleMasterFilter_16x16;
            this.bbiIncludeMessage.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.MultipleMasterFilter_32x32;
            this.bbiIncludeMessage.Name = "bbiIncludeMessage";
            // 
            // bbiIncludeColumnHeaderFilter
            // 
            this.bbiIncludeColumnHeaderFilter.Caption = "Set X as column header filter for Y";
            this.bbiIncludeColumnHeaderFilter.Id = 52;
            this.bbiIncludeColumnHeaderFilter.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.MultipleMasterFilter_16x16;
            this.bbiIncludeColumnHeaderFilter.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.MultipleMasterFilter_32x32;
            this.bbiIncludeColumnHeaderFilter.Name = "bbiIncludeColumnHeaderFilter";
            // 
            // bbiExcludeMessage
            // 
            this.bbiExcludeMessage.Caption = "Exclude selected message";
            this.bbiExcludeMessage.Id = 53;
            this.bbiExcludeMessage.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.ClearFilter_16x16;
            this.bbiExcludeMessage.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.ClearFilter_32x32;
            this.bbiExcludeMessage.Name = "bbiExcludeMessage";
            // 
            // bbiExcludeSource
            // 
            this.bbiExcludeSource.Caption = "Exclude source";
            this.bbiExcludeSource.Id = 54;
            this.bbiExcludeSource.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.ClearFilter_16x16;
            this.bbiExcludeSource.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.ClearFilter_32x32;
            this.bbiExcludeSource.Name = "bbiExcludeSource";
            // 
            // bbiExcludeModule
            // 
            this.bbiExcludeModule.Caption = "Exclude process/module";
            this.bbiExcludeModule.Id = 55;
            this.bbiExcludeModule.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.ClearFilter_16x16;
            this.bbiExcludeModule.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.ClearFilter_32x32;
            this.bbiExcludeModule.Name = "bbiExcludeModule";
            // 
            // bbiSaveLayout
            // 
            this.bbiSaveLayout.Caption = "Save columns layout";
            this.bbiSaveLayout.Id = 56;
            this.bbiSaveLayout.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Save_16x16;
            this.bbiSaveLayout.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.SaveDialog_32x32;
            this.bbiSaveLayout.Name = "bbiSaveLayout";
            // 
            // bbiIncreaseFontSize
            // 
            this.bbiIncreaseFontSize.Caption = "Increase font size";
            this.bbiIncreaseFontSize.Id = 57;
            this.bbiIncreaseFontSize.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.FontSizeIncrease_16x16;
            this.bbiIncreaseFontSize.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.FontSizeIncrease_32x32;
            this.bbiIncreaseFontSize.Name = "bbiIncreaseFontSize";
            // 
            // bbiDecreaseFontSize
            // 
            this.bbiDecreaseFontSize.Caption = "Decrease font size";
            this.bbiDecreaseFontSize.Id = 58;
            this.bbiDecreaseFontSize.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.FontSizeDecrease_16x16;
            this.bbiDecreaseFontSize.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.FontSizeDecrease_32x32;
            this.bbiDecreaseFontSize.Name = "bbiDecreaseFontSize";
            // 
            // bbiIncludeSource
            // 
            this.bbiIncludeSource.Caption = "Include source";
            this.bbiIncludeSource.Id = 59;
            this.bbiIncludeSource.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.MultipleMasterFilter_16x16;
            this.bbiIncludeSource.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.MultipleMasterFilter_32x32;
            this.bbiIncludeSource.Name = "bbiIncludeSource";
            // 
            // bbiIncludeModule
            // 
            this.bbiIncludeModule.Caption = "Include process/module";
            this.bbiIncludeModule.Id = 60;
            this.bbiIncludeModule.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.MultipleMasterFilter_16x16;
            this.bbiIncludeModule.ImageOptions.LargeImage = global::Analogy.CommonControls.Properties.Resources.MultipleMasterFilter_32x32;
            this.bbiIncludeModule.Name = "bbiIncludeModule";
            // 
            // bbiJsonViewer
            // 
            this.bbiJsonViewer.Caption = "Open message in JSON Visualizer";
            this.bbiJsonViewer.Id = 62;
            this.bbiJsonViewer.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.json16x16;
            this.bbiJsonViewer.Name = "bbiJsonViewer";
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // repositoryItemProgressBar2
            // 
            this.repositoryItemProgressBar2.Name = "repositoryItemProgressBar2";
            // 
            // ddbGoTo
            // 
            this.ddbGoTo.Location = new System.Drawing.Point(1360, 101);
            this.ddbGoTo.MenuManager = this.barManager1;
            this.ddbGoTo.Name = "ddbGoTo";
            this.barManager1.SetPopupContextMenu(this.ddbGoTo, this.popupMenuGoTo);
            this.ddbGoTo.Size = new System.Drawing.Size(60, 27);
            this.ddbGoTo.StyleController = this.layoutControl1;
            this.ddbGoTo.TabIndex = 30;
            this.ddbGoTo.Text = "Go To";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ddbGoTo);
            this.layoutControl1.Controls.Add(this.deOlderThanFilter);
            this.layoutControl1.Controls.Add(this.sbtnIncludeModules);
            this.layoutControl1.Controls.Add(this.ceOlderThanFilter);
            this.layoutControl1.Controls.Add(this.deNewerThanFilter);
            this.layoutControl1.Controls.Add(this.ceNewerThanFilter);
            this.layoutControl1.Controls.Add(this.ceModulesProcess);
            this.layoutControl1.Controls.Add(this.txtbModule);
            this.layoutControl1.Controls.Add(this.sbtnIncludeSources);
            this.layoutControl1.Controls.Add(this.ceSources);
            this.layoutControl1.Controls.Add(this.txtbSource);
            this.layoutControl1.Controls.Add(this.sbtnTextExclude);
            this.layoutControl1.Controls.Add(this.txtbExclude);
            this.layoutControl1.Controls.Add(this.sBtnMostCommon);
            this.layoutControl1.Controls.Add(this.ceExcludeText);
            this.layoutControl1.Controls.Add(this.sbtnPreDefinedFilters);
            this.layoutControl1.Controls.Add(this.txtbInclude);
            this.layoutControl1.Controls.Add(this.sbtnTextInclude);
            this.layoutControl1.Controls.Add(this.ceIncludeText);
            this.layoutControl1.Controls.Add(this.ceSearchEverywhere);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(391, 19, 812, 837);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1428, 142);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // deOlderThanFilter
            // 
            this.deOlderThanFilter.EditValue = new System.DateTime(2019, 11, 29, 10, 2, 22, 242);
            this.deOlderThanFilter.Location = new System.Drawing.Point(1181, 101);
            this.deOlderThanFilter.MenuManager = this.barManager1;
            this.deOlderThanFilter.MinimumSize = new System.Drawing.Size(175, 0);
            this.deOlderThanFilter.Name = "deOlderThanFilter";
            this.deOlderThanFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deOlderThanFilter.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deOlderThanFilter.Properties.CalendarTimeProperties.EditFormat.FormatString = "dd.MM.yyyy hh:mm:ss.fff";
            this.deOlderThanFilter.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deOlderThanFilter.Properties.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss.fff";
            this.deOlderThanFilter.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deOlderThanFilter.Properties.EditFormat.FormatString = "dd.MM.yyyy HH:mm:ss.fff";
            this.deOlderThanFilter.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deOlderThanFilter.Properties.Mask.EditMask = "dd.MM.yyyy HH:mm:ss.fff";
            this.deOlderThanFilter.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deOlderThanFilter.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.deOlderThanFilter.Size = new System.Drawing.Size(175, 22);
            this.deOlderThanFilter.StyleController = this.layoutControl1;
            this.deOlderThanFilter.TabIndex = 27;
            // 
            // sbtnIncludeModules
            // 
            this.sbtnIncludeModules.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Close_16x16;
            this.sbtnIncludeModules.Location = new System.Drawing.Point(857, 101);
            this.sbtnIncludeModules.Name = "sbtnIncludeModules";
            this.sbtnIncludeModules.Size = new System.Drawing.Size(22, 27);
            this.sbtnIncludeModules.StyleController = this.layoutControl1;
            this.sbtnIncludeModules.TabIndex = 24;
            this.sbtnIncludeModules.ToolTip = "Clear the text";
            this.sbtnIncludeModules.Click += new System.EventHandler(this.sbtnIncludeModules_Click);
            // 
            // ceOlderThanFilter
            // 
            this.ceOlderThanFilter.Location = new System.Drawing.Point(1129, 101);
            this.ceOlderThanFilter.MenuManager = this.barManager1;
            this.ceOlderThanFilter.Name = "ceOlderThanFilter";
            this.ceOlderThanFilter.Properties.Appearance.Options.UseImage = true;
            this.ceOlderThanFilter.Properties.AutoWidth = true;
            this.ceOlderThanFilter.Properties.Caption = "To:";
            this.ceOlderThanFilter.Size = new System.Drawing.Size(48, 24);
            this.ceOlderThanFilter.StyleController = this.layoutControl1;
            this.ceOlderThanFilter.TabIndex = 29;
            // 
            // deNewerThanFilter
            // 
            this.deNewerThanFilter.EditValue = new System.DateTime(2019, 11, 29, 10, 2, 22, 242);
            this.deNewerThanFilter.Location = new System.Drawing.Point(950, 101);
            this.deNewerThanFilter.MenuManager = this.barManager1;
            this.deNewerThanFilter.MinimumSize = new System.Drawing.Size(175, 0);
            this.deNewerThanFilter.Name = "deNewerThanFilter";
            this.deNewerThanFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deNewerThanFilter.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deNewerThanFilter.Properties.CalendarTimeProperties.EditFormat.FormatString = "dd.MM.yyyy hh:mm:ss.fff";
            this.deNewerThanFilter.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deNewerThanFilter.Properties.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss.fff";
            this.deNewerThanFilter.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deNewerThanFilter.Properties.EditFormat.FormatString = "dd.MM.yyyy HH:mm:ss.fff";
            this.deNewerThanFilter.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.deNewerThanFilter.Properties.Mask.EditMask = "dd.MM.yyyy HH:mm:ss.fff";
            this.deNewerThanFilter.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deNewerThanFilter.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.deNewerThanFilter.Size = new System.Drawing.Size(175, 22);
            this.deNewerThanFilter.StyleController = this.layoutControl1;
            this.deNewerThanFilter.TabIndex = 25;
            // 
            // ceNewerThanFilter
            // 
            this.ceNewerThanFilter.Location = new System.Drawing.Point(883, 101);
            this.ceNewerThanFilter.MenuManager = this.barManager1;
            this.ceNewerThanFilter.Name = "ceNewerThanFilter";
            this.ceNewerThanFilter.Properties.Appearance.Options.UseImage = true;
            this.ceNewerThanFilter.Properties.AutoWidth = true;
            this.ceNewerThanFilter.Properties.Caption = "From:";
            this.ceNewerThanFilter.Size = new System.Drawing.Size(63, 24);
            this.ceNewerThanFilter.StyleController = this.layoutControl1;
            this.ceNewerThanFilter.TabIndex = 28;
            // 
            // ceModulesProcess
            // 
            this.ceModulesProcess.Location = new System.Drawing.Point(8, 101);
            this.ceModulesProcess.MenuManager = this.barManager1;
            this.ceModulesProcess.Name = "ceModulesProcess";
            this.ceModulesProcess.Properties.AutoWidth = true;
            this.ceModulesProcess.Properties.Caption = "Processes/Modules (Include/Exclude):";
            this.ceModulesProcess.Size = new System.Drawing.Size(245, 24);
            this.ceModulesProcess.StyleController = this.layoutControl1;
            toolTipTitleItem1.Text = "Process / Module Property Filtering (include and exclude)";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "Use , to separate values. to exclude source or module prefix it with -. e.g: incl" +
    "udeA, -ExcludeB";
            superToolTip3.Items.Add(toolTipTitleItem1);
            superToolTip3.Items.Add(toolTipItem3);
            this.ceModulesProcess.SuperTip = superToolTip3;
            this.ceModulesProcess.TabIndex = 27;
            this.ceModulesProcess.ToolTip = "Use , to separate values. to exclude source or module prefix it with -";
            // 
            // txtbModule
            // 
            this.txtbModule.Location = new System.Drawing.Point(334, 101);
            this.txtbModule.MenuManager = this.barManager1;
            this.txtbModule.Name = "txtbModule";
            this.txtbModule.Properties.NullText = "Use , to separate values. to exclude source or module prefix it with -. e.g: incl" +
    "udeA, -ExcludeB";
            this.txtbModule.Size = new System.Drawing.Size(519, 22);
            this.txtbModule.StyleController = this.layoutControl1;
            this.txtbModule.TabIndex = 26;
            // 
            // sbtnIncludeSources
            // 
            this.sbtnIncludeSources.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Close_16x16;
            this.sbtnIncludeSources.Location = new System.Drawing.Point(1389, 70);
            this.sbtnIncludeSources.Name = "sbtnIncludeSources";
            this.sbtnIncludeSources.Size = new System.Drawing.Size(31, 27);
            this.sbtnIncludeSources.StyleController = this.layoutControl1;
            this.sbtnIncludeSources.TabIndex = 24;
            this.sbtnIncludeSources.ToolTip = "Clear the text";
            this.sbtnIncludeSources.Click += new System.EventHandler(this.sbtnIncludeSources_Click);
            // 
            // ceSources
            // 
            this.ceSources.Location = new System.Drawing.Point(8, 70);
            this.ceSources.MenuManager = this.barManager1;
            this.ceSources.Name = "ceSources";
            this.ceSources.Properties.AutoWidth = true;
            this.ceSources.Properties.Caption = "Sources (Include/Exclude):";
            this.ceSources.Size = new System.Drawing.Size(182, 24);
            this.ceSources.StyleController = this.layoutControl1;
            toolTipTitleItem2.Text = "Source Propery Filtering (include and exclude)";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "Use , to separate values. to exclude source prefix it with -. e.g: includeA, incl" +
    "udeB, -ExcludeC, -ExcludeD";
            superToolTip4.Items.Add(toolTipTitleItem2);
            superToolTip4.Items.Add(toolTipItem4);
            this.ceSources.SuperTip = superToolTip4;
            this.ceSources.TabIndex = 26;
            this.ceSources.ToolTip = "Use , to separate values. to exclude source or module prefix it with -";
            // 
            // txtbSource
            // 
            this.txtbSource.EditValue = "Use , to separate values. to exclude source or module prefix it with -. e.g: incl" +
    "udeA, includeB, -ExcludeC, -ExcludeD";
            this.txtbSource.Location = new System.Drawing.Point(252, 70);
            this.txtbSource.MenuManager = this.barManager1;
            this.txtbSource.Name = "txtbSource";
            this.txtbSource.Properties.NullText = "Use , to separate values. to exclude source or module prefix it with -. e.g: incl" +
    "udeA, includeB, -ExcludeC, -ExcludeD";
            this.txtbSource.Size = new System.Drawing.Size(1133, 22);
            this.txtbSource.StyleController = this.layoutControl1;
            this.txtbSource.TabIndex = 25;
            // 
            // sbtnTextExclude
            // 
            this.sbtnTextExclude.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Close_16x16;
            this.sbtnTextExclude.Location = new System.Drawing.Point(1298, 39);
            this.sbtnTextExclude.Name = "sbtnTextExclude";
            this.sbtnTextExclude.Size = new System.Drawing.Size(22, 27);
            this.sbtnTextExclude.StyleController = this.layoutControl1;
            this.sbtnTextExclude.TabIndex = 20;
            this.sbtnTextExclude.ToolTip = "Clear the text";
            this.sbtnTextExclude.Click += new System.EventHandler(this.sbtnTextExclude_Click);
            // 
            // txtbExclude
            // 
            this.txtbExclude.Location = new System.Drawing.Point(170, 39);
            this.txtbExclude.MenuManager = this.barManager1;
            this.txtbExclude.Name = "txtbExclude";
            this.txtbExclude.Properties.NullText = "Use & or + for AND operations. Use | for OR operations";
            this.txtbExclude.Size = new System.Drawing.Size(1124, 22);
            this.txtbExclude.StyleController = this.layoutControl1;
            this.txtbExclude.TabIndex = 20;
            this.txtbExclude.EditValueChanged += new System.EventHandler(this.txtbExclude_EditValueChanged);
            // 
            // sBtnMostCommon
            // 
            this.sBtnMostCommon.Location = new System.Drawing.Point(1324, 39);
            this.sBtnMostCommon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnMostCommon.Name = "sBtnMostCommon";
            this.sBtnMostCommon.Size = new System.Drawing.Size(96, 27);
            this.sBtnMostCommon.StyleController = this.layoutControl1;
            this.sBtnMostCommon.TabIndex = 8;
            this.sBtnMostCommon.Text = "Most Common";
            this.sBtnMostCommon.Click += new System.EventHandler(this.sBtnMostCommon_Click);
            // 
            // ceExcludeText
            // 
            this.ceExcludeText.Location = new System.Drawing.Point(8, 39);
            this.ceExcludeText.MenuManager = this.barManager1;
            this.ceExcludeText.Name = "ceExcludeText";
            this.ceExcludeText.Properties.AutoWidth = true;
            this.ceExcludeText.Properties.Caption = "Exclude Text:";
            this.ceExcludeText.Size = new System.Drawing.Size(105, 24);
            this.ceExcludeText.StyleController = this.layoutControl1;
            toolTipTitleItem3.Text = "Text Property Filtering (exclude)";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "Use (&& or +) for AND operations. Use | for OR operations";
            superToolTip5.Items.Add(toolTipTitleItem3);
            superToolTip5.Items.Add(toolTipItem5);
            this.ceExcludeText.SuperTip = superToolTip5;
            this.ceExcludeText.TabIndex = 23;
            // 
            // sbtnPreDefinedFilters
            // 
            this.sbtnPreDefinedFilters.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.SingleMasterFilter_16x16;
            this.sbtnPreDefinedFilters.Location = new System.Drawing.Point(1398, 8);
            this.sbtnPreDefinedFilters.Name = "sbtnPreDefinedFilters";
            this.sbtnPreDefinedFilters.Size = new System.Drawing.Size(22, 27);
            this.sbtnPreDefinedFilters.StyleController = this.layoutControl1;
            this.sbtnPreDefinedFilters.TabIndex = 21;
            this.sbtnPreDefinedFilters.ToolTip = "Pre-defined filters";
            this.sbtnPreDefinedFilters.Click += new System.EventHandler(this.sbtnPreDefinedFilters_Click);
            // 
            // txtbInclude
            // 
            this.txtbInclude.Location = new System.Drawing.Point(170, 8);
            this.txtbInclude.MenuManager = this.barManager1;
            this.txtbInclude.Name = "txtbInclude";
            this.txtbInclude.Properties.NullText = "Use & or + for AND operations. Use | for OR operations";
            this.txtbInclude.Size = new System.Drawing.Size(1055, 22);
            this.txtbInclude.StyleController = this.layoutControl1;
            this.txtbInclude.TabIndex = 19;
            this.txtbInclude.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbInclude_KeyPress);
            // 
            // sbtnTextInclude
            // 
            this.sbtnTextInclude.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Close_16x16;
            this.sbtnTextInclude.Location = new System.Drawing.Point(1372, 8);
            this.sbtnTextInclude.Name = "sbtnTextInclude";
            this.sbtnTextInclude.Size = new System.Drawing.Size(22, 27);
            this.sbtnTextInclude.StyleController = this.layoutControl1;
            this.sbtnTextInclude.TabIndex = 20;
            this.sbtnTextInclude.ToolTip = "Clear the text";
            this.sbtnTextInclude.Click += new System.EventHandler(this.sbtnTextInclude_Click);
            // 
            // ceIncludeText
            // 
            this.ceIncludeText.Location = new System.Drawing.Point(8, 8);
            this.ceIncludeText.MenuManager = this.barManager1;
            this.ceIncludeText.Name = "ceIncludeText";
            this.ceIncludeText.Properties.Appearance.Options.UseImage = true;
            this.ceIncludeText.Properties.AutoWidth = true;
            this.ceIncludeText.Properties.Caption = "Include Text:";
            this.ceIncludeText.Size = new System.Drawing.Size(103, 24);
            this.ceIncludeText.StyleController = this.layoutControl1;
            toolTipTitleItem4.Text = "Text Property Filtering";
            toolTipItem6.LeftIndent = 6;
            toolTipItem6.Text = "Use (&& or +) for AND operations. Use | for OR operations";
            superToolTip6.Items.Add(toolTipTitleItem4);
            superToolTip6.Items.Add(toolTipItem6);
            this.ceIncludeText.SuperTip = superToolTip6;
            this.ceIncludeText.TabIndex = 22;
            this.ceIncludeText.ToolTip = "Use & or + for AND operations. Use | for OR operations";
            this.ceIncludeText.ToolTipController = this.defaultToolTipController;
            // 
            // defaultToolTipController
            // 
            this.defaultToolTipController.Appearance.Options.UseBorderColor = true;
            // 
            // ceSearchEverywhere
            // 
            this.ceSearchEverywhere.Location = new System.Drawing.Point(1229, 8);
            this.ceSearchEverywhere.MenuManager = this.barManager1;
            this.ceSearchEverywhere.Name = "ceSearchEverywhere";
            this.ceSearchEverywhere.Properties.Caption = "Search Everywhere";
            this.ceSearchEverywhere.Size = new System.Drawing.Size(139, 24);
            this.ceSearchEverywhere.StyleController = this.layoutControl1;
            this.ceSearchEverywhere.TabIndex = 31;
            this.ceSearchEverywhere.ToolTip = "Search in all columns";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.layoutControlItem17,
            this.layoutControlItem18,
            this.layoutControlItem19,
            this.layoutControlItem14,
            this.layoutControlItem20});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.Root.Size = new System.Drawing.Size(1428, 142);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.ceIncludeText;
            this.layoutControlItem2.CustomizationFormText = "includeTextcheckbox";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(162, 30);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(162, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(162, 31);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "includeText";
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtbInclude;
            this.layoutControlItem1.Location = new System.Drawing.Point(162, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1059, 31);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.sbtnTextInclude;
            this.layoutControlItem3.Location = new System.Drawing.Point(1364, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(26, 31);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.sbtnPreDefinedFilters;
            this.layoutControlItem4.Location = new System.Drawing.Point(1390, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(26, 31);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtbExclude;
            this.layoutControlItem5.Location = new System.Drawing.Point(162, 31);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1128, 31);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.ceExcludeText;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 31);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(162, 30);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(162, 30);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(162, 31);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.sBtnMostCommon;
            this.layoutControlItem7.Location = new System.Drawing.Point(1316, 31);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(100, 31);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.sbtnTextExclude;
            this.layoutControlItem8.Location = new System.Drawing.Point(1290, 31);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(26, 31);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtbSource;
            this.layoutControlItem9.Location = new System.Drawing.Point(244, 62);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(1137, 31);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.ceSources;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 62);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(244, 30);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(244, 30);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(244, 31);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.sbtnIncludeSources;
            this.layoutControlItem11.Location = new System.Drawing.Point(1381, 62);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(35, 31);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.txtbModule;
            this.layoutControlItem12.Location = new System.Drawing.Point(326, 93);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(523, 37);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.ceModulesProcess;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 93);
            this.layoutControlItem13.MaxSize = new System.Drawing.Size(326, 30);
            this.layoutControlItem13.MinSize = new System.Drawing.Size(326, 30);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(326, 37);
            this.layoutControlItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.sbtnIncludeModules;
            this.layoutControlItem15.Location = new System.Drawing.Point(849, 93);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(26, 37);
            this.layoutControlItem15.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.ceNewerThanFilter;
            this.layoutControlItem16.Location = new System.Drawing.Point(875, 93);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(67, 37);
            this.layoutControlItem16.TextVisible = false;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.deNewerThanFilter;
            this.layoutControlItem17.Location = new System.Drawing.Point(942, 93);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(179, 37);
            this.layoutControlItem17.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.ceOlderThanFilter;
            this.layoutControlItem18.Location = new System.Drawing.Point(1121, 93);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(52, 37);
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.deOlderThanFilter;
            this.layoutControlItem19.Location = new System.Drawing.Point(1173, 93);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(179, 37);
            this.layoutControlItem19.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.ddbGoTo;
            this.layoutControlItem14.Location = new System.Drawing.Point(1352, 93);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(64, 37);
            this.layoutControlItem14.TextVisible = false;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.ceSearchEverywhere;
            this.layoutControlItem20.Location = new System.Drawing.Point(1221, 0);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(143, 31);
            this.layoutControlItem20.TextVisible = false;
            // 
            // popupMenuGoTo
            // 
            this.popupMenuGoTo.Manager = this.barManager1;
            this.popupMenuGoTo.Name = "popupMenuGoTo";
            // 
            // layoutControlLogs
            // 
            this.layoutControlLogs.Controls.Add(this.spltcMessages);
            this.layoutControlLogs.Controls.Add(this.sbtnPageFirst);
            this.layoutControlLogs.Controls.Add(this.sbtnMoreHighlight);
            this.layoutControlLogs.Controls.Add(this.sbtnPagePrevious);
            this.layoutControlLogs.Controls.Add(this.sBtnPageNext);
            this.layoutControlLogs.Controls.Add(this.chkbHighlight);
            this.layoutControlLogs.Controls.Add(this.sBtnLastPage);
            this.layoutControlLogs.Controls.Add(this.txtbHighlight);
            this.layoutControlLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlLogs.Location = new System.Drawing.Point(0, 0);
            this.layoutControlLogs.Name = "layoutControlLogs";
            this.layoutControlLogs.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(520, 50, 812, 500);
            this.layoutControlLogs.Root = this.layoutControlGroup1;
            this.layoutControlLogs.Size = new System.Drawing.Size(1647, 248);
            this.layoutControlLogs.TabIndex = 6;
            this.layoutControlLogs.Text = "layoutControl2";
            // 
            // spltcMessages
            // 
            this.spltcMessages.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.spltcMessages.Location = new System.Drawing.Point(8, 8);
            this.spltcMessages.Name = "spltcMessages";
            // 
            // spltcMessages.Panel1
            // 
            this.spltcMessages.Panel1.Controls.Add(this.gridControl);
            this.spltcMessages.Panel1.Text = "Panel1";
            // 
            // spltcMessages.Panel2
            // 
            this.spltcMessages.Panel2.Text = "Panel2";
            this.spltcMessages.Size = new System.Drawing.Size(1631, 201);
            this.spltcMessages.SplitterPosition = 251;
            this.spltcMessages.TabIndex = 0;
            // 
            // sbtnPageFirst
            // 
            this.sbtnPageFirst.Location = new System.Drawing.Point(1298, 213);
            this.sbtnPageFirst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sbtnPageFirst.Name = "sbtnPageFirst";
            this.sbtnPageFirst.Size = new System.Drawing.Size(61, 27);
            this.sbtnPageFirst.StyleController = this.layoutControlLogs;
            this.sbtnPageFirst.TabIndex = 5;
            this.sbtnPageFirst.Text = "first Page";
            this.sbtnPageFirst.Click += new System.EventHandler(this.sbtnPageFirst_Click);
            // 
            // sbtnMoreHighlight
            // 
            this.sbtnMoreHighlight.Location = new System.Drawing.Point(1230, 213);
            this.sbtnMoreHighlight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sbtnMoreHighlight.Name = "sbtnMoreHighlight";
            this.sbtnMoreHighlight.Size = new System.Drawing.Size(64, 27);
            this.sbtnMoreHighlight.StyleController = this.layoutControlLogs;
            this.sbtnMoreHighlight.TabIndex = 4;
            this.sbtnMoreHighlight.Text = "More ...";
            this.sbtnMoreHighlight.Visible = false;
            // 
            // sbtnPagePrevious
            // 
            this.sbtnPagePrevious.Location = new System.Drawing.Point(1363, 213);
            this.sbtnPagePrevious.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sbtnPagePrevious.Name = "sbtnPagePrevious";
            this.sbtnPagePrevious.Size = new System.Drawing.Size(87, 27);
            this.sbtnPagePrevious.StyleController = this.layoutControlLogs;
            this.sbtnPagePrevious.TabIndex = 6;
            this.sbtnPagePrevious.Text = "Previous Page";
            this.sbtnPagePrevious.Click += new System.EventHandler(this.sbtnPagePrevious_Click);
            // 
            // sBtnPageNext
            // 
            this.sBtnPageNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sBtnPageNext.Location = new System.Drawing.Point(1509, 213);
            this.sBtnPageNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sBtnPageNext.Name = "sBtnPageNext";
            this.sBtnPageNext.Size = new System.Drawing.Size(64, 27);
            this.sBtnPageNext.StyleController = this.layoutControlLogs;
            this.sBtnPageNext.TabIndex = 7;
            this.sBtnPageNext.Text = "Next Page";
            this.sBtnPageNext.Click += new System.EventHandler(this.sBtnPageNext_Click);
            // 
            // sBtnLastPage
            // 
            this.sBtnLastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sBtnLastPage.Location = new System.Drawing.Point(1577, 213);
            this.sBtnLastPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sBtnLastPage.Name = "sBtnLastPage";
            this.sBtnLastPage.Size = new System.Drawing.Size(62, 27);
            this.sBtnLastPage.StyleController = this.layoutControlLogs;
            this.sBtnLastPage.TabIndex = 8;
            this.sBtnLastPage.Text = "Last Page";
            this.sBtnLastPage.Click += new System.EventHandler(this.sBtnLastPage_Click);
            // 
            // txtbHighlight
            // 
            this.txtbHighlight.Location = new System.Drawing.Point(206, 213);
            this.txtbHighlight.MenuManager = this.barManager1;
            this.txtbHighlight.Name = "txtbHighlight";
            this.txtbHighlight.Size = new System.Drawing.Size(1020, 22);
            this.txtbHighlight.StyleController = this.layoutControlLogs;
            this.txtbHighlight.TabIndex = 3;
            this.txtbHighlight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbHighlight_KeyUp);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem22,
            this.layoutControlItem23,
            this.layoutControlItem24,
            this.layoutControlItem25,
            this.layoutControlItem27,
            this.layoutControlItem28,
            this.layoutControlItem21,
            this.lblPageNumber,
            this.layoutControlItem26});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1647, 248);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.txtbHighlight;
            this.layoutControlItem22.Location = new System.Drawing.Point(198, 205);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(1024, 31);
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.chkbHighlight;
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 205);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(198, 31);
            this.layoutControlItem23.TextVisible = false;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.sBtnLastPage;
            this.layoutControlItem24.Location = new System.Drawing.Point(1569, 205);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(66, 31);
            this.layoutControlItem24.TextVisible = false;
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.sBtnPageNext;
            this.layoutControlItem25.Location = new System.Drawing.Point(1501, 205);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(68, 31);
            this.layoutControlItem25.TextVisible = false;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.sbtnPagePrevious;
            this.layoutControlItem27.Location = new System.Drawing.Point(1355, 205);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(91, 31);
            this.layoutControlItem27.TextVisible = false;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.sbtnPageFirst;
            this.layoutControlItem28.Location = new System.Drawing.Point(1290, 205);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(65, 31);
            this.layoutControlItem28.TextVisible = false;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.sbtnMoreHighlight;
            this.layoutControlItem21.Location = new System.Drawing.Point(1222, 205);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(68, 31);
            this.layoutControlItem21.TextVisible = false;
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.Location = new System.Drawing.Point(1446, 205);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(55, 31);
            this.lblPageNumber.Text = "Page 1/1";
            this.lblPageNumber.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lblPageNumber.TextSize = new System.Drawing.Size(51, 16);
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.spltcMessages;
            this.layoutControlItem26.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(1635, 205);
            this.layoutControlItem26.TextVisible = false;
            // 
            // chkLstLogLevel
            // 
            this.chkLstLogLevel.CheckMode = DevExpress.XtraEditors.CheckMode.Single;
            this.chkLstLogLevel.CheckOnClick = true;
            this.chkLstLogLevel.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkLstLogLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLstLogLevel.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Trace"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Error + Critical"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Warning"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Debug"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Verbose")});
            this.chkLstLogLevel.Location = new System.Drawing.Point(2, 28);
            this.chkLstLogLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkLstLogLevel.Name = "chkLstLogLevel";
            this.chkLstLogLevel.Size = new System.Drawing.Size(137, 142);
            this.chkLstLogLevel.TabIndex = 22;
            this.chkLstLogLevel.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkLstLogLevel_ItemCheck);
            this.chkLstLogLevel.SelectedIndexChanged += new System.EventHandler(this.chkLstLogLevel_SelectedIndexChanged);
            // 
            // imageListBottom
            // 
            this.imageListBottom.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBottom.ImageStream")));
            this.imageListBottom.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListBottom.Images.SetKeyName(0, "Info_16x16.png");
            this.imageListBottom.Images.SetKeyName(1, "RichEditBookmark_16x16.png");
            this.imageListBottom.Images.SetKeyName(2, "RichEditBookmark_32x32.png");
            // 
            // tmrNewData
            // 
            this.tmrNewData.Enabled = true;
            this.tmrNewData.Interval = 1000;
            this.tmrNewData.Tick += new System.EventHandler(this.tmrNewData_Tick);
            // 
            // ceFilterPanelFilter
            // 
            this.ceFilterPanelFilter.Location = new System.Drawing.Point(266, 40);
            this.ceFilterPanelFilter.MenuManager = this.barManager1;
            this.ceFilterPanelFilter.Name = "ceFilterPanelFilter";
            this.ceFilterPanelFilter.Properties.Caption = "Filter Mode (ALT +F)";
            this.ceFilterPanelFilter.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceFilterPanelFilter.Properties.RadioGroupIndex = 1;
            this.ceFilterPanelFilter.Size = new System.Drawing.Size(184, 24);
            toolTipTitleItem6.Text = "AND Log Level Filtering";
            toolTipItem8.LeftIndent = 6;
            superToolTip8.Items.Add(toolTipTitleItem6);
            superToolTip8.Items.Add(toolTipItem8);
            this.ceFilterPanelFilter.SuperTip = superToolTip8;
            this.ceFilterPanelFilter.TabIndex = 30;
            this.ceFilterPanelFilter.TabStop = false;
            // 
            // ceFilterPanelSearch
            // 
            this.ceFilterPanelSearch.EditValue = true;
            this.ceFilterPanelSearch.Location = new System.Drawing.Point(83, 40);
            this.ceFilterPanelSearch.MenuManager = this.barManager1;
            this.ceFilterPanelSearch.Name = "ceFilterPanelSearch";
            this.ceFilterPanelSearch.Properties.Caption = "Search Mode (CTRL +F)";
            this.ceFilterPanelSearch.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceFilterPanelSearch.Properties.RadioGroupIndex = 1;
            this.ceFilterPanelSearch.Size = new System.Drawing.Size(184, 24);
            toolTipTitleItem5.Text = "AND Log Level Filtering";
            toolTipItem7.LeftIndent = 6;
            superToolTip7.Items.Add(toolTipTitleItem5);
            superToolTip7.Items.Add(toolTipItem7);
            this.ceFilterPanelSearch.SuperTip = superToolTip7;
            this.ceFilterPanelSearch.TabIndex = 29;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Text Mode:";
            // 
            // sbtnToggleSearchFilter
            // 
            this.sbtnToggleSearchFilter.Location = new System.Drawing.Point(3, 8);
            this.sbtnToggleSearchFilter.Name = "sbtnToggleSearchFilter";
            this.sbtnToggleSearchFilter.Size = new System.Drawing.Size(294, 28);
            this.sbtnToggleSearchFilter.TabIndex = 0;
            this.sbtnToggleSearchFilter.Text = "Toggle Search/Filter Panel On/Off";
            // 
            // pnlExtraFilters
            // 
            this.pnlExtraFilters.Controls.Add(this.xtcFilters);
            this.pnlExtraFilters.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlExtraFilters.Location = new System.Drawing.Point(1430, 0);
            this.pnlExtraFilters.Name = "pnlExtraFilters";
            this.pnlExtraFilters.Size = new System.Drawing.Size(274, 172);
            this.pnlExtraFilters.TabIndex = 30;
            // 
            // xtcFilters
            // 
            this.xtcFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtcFilters.Location = new System.Drawing.Point(0, 0);
            this.xtcFilters.Name = "xtcFilters";
            this.xtcFilters.SelectedTabPage = this.xtpFiltersIncludes;
            this.xtcFilters.Size = new System.Drawing.Size(274, 172);
            this.xtcFilters.TabIndex = 29;
            this.xtcFilters.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpFiltersIncludes,
            this.xtpFiltersExclude,
            this.xtpServerSide});
            // 
            // xtpFiltersIncludes
            // 
            this.xtpFiltersIncludes.Controls.Add(this.clbInclude);
            this.xtpFiltersIncludes.Name = "xtpFiltersIncludes";
            this.xtpFiltersIncludes.Size = new System.Drawing.Size(272, 142);
            this.xtpFiltersIncludes.Text = "Includes";
            // 
            // clbInclude
            // 
            this.clbInclude.CheckOnClick = true;
            this.clbInclude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbInclude.Location = new System.Drawing.Point(0, 0);
            this.clbInclude.Name = "clbInclude";
            this.clbInclude.Size = new System.Drawing.Size(272, 142);
            this.clbInclude.TabIndex = 21;
            // 
            // xtpFiltersExclude
            // 
            this.xtpFiltersExclude.Controls.Add(this.clbExclude);
            this.xtpFiltersExclude.Name = "xtpFiltersExclude";
            this.xtpFiltersExclude.Size = new System.Drawing.Size(272, 142);
            this.xtpFiltersExclude.Text = "Excludes";
            // 
            // clbExclude
            // 
            this.clbExclude.CheckOnClick = true;
            this.clbExclude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbExclude.Location = new System.Drawing.Point(0, 0);
            this.clbExclude.Name = "clbExclude";
            this.clbExclude.Size = new System.Drawing.Size(272, 142);
            this.clbExclude.TabIndex = 22;
            // 
            // xtpServerSide
            // 
            this.xtpServerSide.Controls.Add(this.sbtnServerSide);
            this.xtpServerSide.Name = "xtpServerSide";
            this.xtpServerSide.Size = new System.Drawing.Size(272, 142);
            this.xtpServerSide.Text = "Server Side Data";
            // 
            // sbtnServerSide
            // 
            this.sbtnServerSide.Location = new System.Drawing.Point(27, 10);
            this.sbtnServerSide.Name = "sbtnServerSide";
            this.sbtnServerSide.Size = new System.Drawing.Size(218, 34);
            this.sbtnServerSide.TabIndex = 1;
            this.sbtnServerSide.Text = "Fetch Data From Server";
            // 
            // pnlLevel
            // 
            this.pnlLevel.Controls.Add(this.chkLstLogLevel);
            this.pnlLevel.Controls.Add(this.pnlLevelFilteringType);
            this.pnlLevel.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLevel.Location = new System.Drawing.Point(1704, 0);
            this.pnlLevel.Name = "pnlLevel";
            this.pnlLevel.Size = new System.Drawing.Size(141, 172);
            this.pnlLevel.TabIndex = 29;
            // 
            // pnlLevelFilteringType
            // 
            this.pnlLevelFilteringType.Controls.Add(this.ceLogLevelOr);
            this.pnlLevelFilteringType.Controls.Add(this.ceLogLevelAnd);
            this.pnlLevelFilteringType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLevelFilteringType.Location = new System.Drawing.Point(2, 2);
            this.pnlLevelFilteringType.Name = "pnlLevelFilteringType";
            this.pnlLevelFilteringType.Size = new System.Drawing.Size(137, 26);
            this.pnlLevelFilteringType.TabIndex = 23;
            // 
            // ceLogLevelOr
            // 
            this.ceLogLevelOr.Dock = System.Windows.Forms.DockStyle.Right;
            this.ceLogLevelOr.Location = new System.Drawing.Point(69, 2);
            this.ceLogLevelOr.MenuManager = this.barManager1;
            this.ceLogLevelOr.Name = "ceLogLevelOr";
            this.ceLogLevelOr.Properties.Caption = "Or";
            this.ceLogLevelOr.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceLogLevelOr.Properties.RadioGroupIndex = 5;
            this.ceLogLevelOr.Size = new System.Drawing.Size(66, 22);
            toolTipTitleItem7.Text = "Or Log level Filtering";
            toolTipItem9.LeftIndent = 6;
            toolTipItem9.Text = "The OR type allows to always show some log levels regardless the current filters." +
    " This is usefull when you want to see some log level alongs with other filters";
            superToolTip9.Items.Add(toolTipTitleItem7);
            superToolTip9.Items.Add(toolTipItem9);
            this.ceLogLevelOr.SuperTip = superToolTip9;
            this.ceLogLevelOr.TabIndex = 1;
            this.ceLogLevelOr.TabStop = false;
            // 
            // ceLogLevelAnd
            // 
            this.ceLogLevelAnd.Dock = System.Windows.Forms.DockStyle.Left;
            this.ceLogLevelAnd.EditValue = true;
            this.ceLogLevelAnd.Location = new System.Drawing.Point(2, 2);
            this.ceLogLevelAnd.MenuManager = this.barManager1;
            this.ceLogLevelAnd.Name = "ceLogLevelAnd";
            this.ceLogLevelAnd.Properties.Caption = "And";
            this.ceLogLevelAnd.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceLogLevelAnd.Properties.RadioGroupIndex = 5;
            this.ceLogLevelAnd.Size = new System.Drawing.Size(61, 22);
            toolTipTitleItem8.Text = "AND Log Level Filtering";
            toolTipItem10.LeftIndent = 6;
            superToolTip10.Items.Add(toolTipTitleItem8);
            superToolTip10.Items.Add(toolTipItem10);
            this.ceLogLevelAnd.SuperTip = superToolTip10;
            this.ceLogLevelAnd.TabIndex = 0;
            // 
            // LogGridPopupMenu
            // 
            this.LogGridPopupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bBtnClearLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiBookmark),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDiffTime),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDatetiemFilterFrom),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDatetiemFilterTo),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiJsonViewer),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCopyMessage),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiCopyAllMessages),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiAddNoteToMessage),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiIncludeMessage, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiIncludeSource),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiIncludeModule),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiIncludeColumnHeaderFilter),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExcludeMessage, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExcludeSource),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiExcludeModule),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSaveLayout, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiIncreaseFontSize),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDecreaseFontSize)});
            this.LogGridPopupMenu.Manager = this.barManager1;
            this.LogGridPopupMenu.Name = "LogGridPopupMenu";
            // 
            // alertControl1
            // 
            this.alertControl1.ShowPinButton = false;
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.MenuManager = this.barManager1;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // tabbedView1
            // 
            this.tabbedView1.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] {
            this.documentGroup1});
            this.tabbedView1.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.documentMessages});
            this.tabbedView1.Orientation = System.Windows.Forms.Orientation.Vertical;
            dockingContainer1.Element = this.documentGroup1;
            dockingContainer1.Length.UnitValue = 1.4189383070301291D;
            this.tabbedView1.RootContainer.Nodes.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer[] {
            dockingContainer1});
            this.tabbedView1.RootContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelLogs,
            this.dockPanelMessageInfo,
            this.dockPanelFiltering,
            this.dockPanelTree});
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
            // dockPanelLogs
            // 
            this.dockPanelLogs.Controls.Add(this.dockPanel2_Container);
            this.dockPanelLogs.DockedAsTabbedDocument = true;
            this.dockPanelLogs.ID = new System.Guid("3e67bfab-0a04-4919-82f8-b34cb75b93ba");
            this.dockPanelLogs.Name = "dockPanelLogs";
            this.dockPanelLogs.Options.ShowCloseButton = false;
            this.dockPanelLogs.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanelLogs.Text = "Logs";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.layoutControlLogs);
            this.dockPanel2_Container.Controls.Add(this.bdcTopFiltering);
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(1647, 248);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // dockPanelMessageInfo
            // 
            this.dockPanelMessageInfo.Controls.Add(this.controlContainer1);
            this.dockPanelMessageInfo.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelMessageInfo.FloatSize = new System.Drawing.Size(428, 200);
            this.dockPanelMessageInfo.ID = new System.Guid("476f3ac6-a99d-4213-81ee-71700997df5e");
            this.dockPanelMessageInfo.Location = new System.Drawing.Point(0, 523);
            this.dockPanelMessageInfo.Name = "dockPanelMessageInfo";
            this.dockPanelMessageInfo.Options.ShowCloseButton = false;
            this.dockPanelMessageInfo.OriginalSize = new System.Drawing.Size(200, 204);
            this.dockPanelMessageInfo.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelMessageInfo.SavedIndex = 1;
            this.dockPanelMessageInfo.Size = new System.Drawing.Size(1853, 204);
            this.dockPanelMessageInfo.Text = "Message Info";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.scMessageDetails);
            this.controlContainer1.Controls.Add(this.sbarMessageInfo);
            this.controlContainer1.Location = new System.Drawing.Point(4, 34);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(1845, 166);
            this.controlContainer1.TabIndex = 0;
            // 
            // scMessageDetails
            // 
            this.scMessageDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMessageDetails.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.scMessageDetails.Location = new System.Drawing.Point(0, 30);
            this.scMessageDetails.Name = "scMessageDetails";
            // 
            // scMessageDetails.Panel1
            // 
            this.scMessageDetails.Panel1.Controls.Add(this.meMessageDetails);
            this.scMessageDetails.Panel1.Text = "Panel1";
            // 
            // scMessageDetails.Panel2
            // 
            this.scMessageDetails.Panel2.Controls.Add(this.recMessageDetails);
            this.scMessageDetails.Panel2.Text = "Panel2";
            this.scMessageDetails.Size = new System.Drawing.Size(1845, 136);
            this.scMessageDetails.SplitterPosition = 783;
            this.scMessageDetails.TabIndex = 6;
            // 
            // meMessageDetails
            // 
            this.meMessageDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meMessageDetails.Location = new System.Drawing.Point(0, 0);
            this.meMessageDetails.MenuManager = this.barManager1;
            this.meMessageDetails.Name = "meMessageDetails";
            this.meMessageDetails.Size = new System.Drawing.Size(783, 136);
            this.meMessageDetails.TabIndex = 0;
            // 
            // recMessageDetails
            // 
            this.recMessageDetails.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.recMessageDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recMessageDetails.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.recMessageDetails.Location = new System.Drawing.Point(0, 0);
            this.recMessageDetails.MenuManager = this.barManager1;
            this.recMessageDetails.Name = "recMessageDetails";
            this.recMessageDetails.Size = new System.Drawing.Size(1050, 136);
            this.recMessageDetails.TabIndex = 4;
            // 
            // dockPanelFiltering
            // 
            this.dockPanelFiltering.Controls.Add(this.controlContainer2);
            this.dockPanelFiltering.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dockPanelFiltering.ID = new System.Guid("9e59d497-904f-4217-ad0d-6beb031f1056");
            this.dockPanelFiltering.Location = new System.Drawing.Point(0, 30);
            this.dockPanelFiltering.Name = "dockPanelFiltering";
            this.dockPanelFiltering.Options.AllowDockAsTabbedDocument = false;
            this.dockPanelFiltering.Options.ShowCloseButton = false;
            this.dockPanelFiltering.OriginalSize = new System.Drawing.Size(200, 210);
            this.dockPanelFiltering.Size = new System.Drawing.Size(1853, 210);
            this.dockPanelFiltering.Text = "Filtering";
            // 
            // controlContainer2
            // 
            this.controlContainer2.Controls.Add(this.xtabFilters);
            this.controlContainer2.Controls.Add(this.pnlExtraFilters);
            this.controlContainer2.Controls.Add(this.pnlLevel);
            this.controlContainer2.Location = new System.Drawing.Point(4, 32);
            this.controlContainer2.Name = "controlContainer2";
            this.controlContainer2.Size = new System.Drawing.Size(1845, 172);
            this.controlContainer2.TabIndex = 0;
            // 
            // xtabFilters
            // 
            this.xtabFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtabFilters.Location = new System.Drawing.Point(0, 0);
            this.xtabFilters.Name = "xtabFilters";
            this.xtabFilters.SelectedTabPage = this.xtraTabPage1;
            this.xtabFilters.Size = new System.Drawing.Size(1430, 172);
            this.xtabFilters.TabIndex = 32;
            this.xtabFilters.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtpSQLraw});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.layoutControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1428, 142);
            this.xtraTabPage1.Text = "Filter";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.sbtnToggleSearchFilter);
            this.xtraTabPage2.Controls.Add(this.labelControl1);
            this.xtraTabPage2.Controls.Add(this.ceFilterPanelSearch);
            this.xtraTabPage2.Controls.Add(this.ceFilterPanelFilter);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1428, 142);
            this.xtraTabPage2.Text = "Grid Pane";
            // 
            // xtpSQLraw
            // 
            this.xtpSQLraw.Controls.Add(this.sbtnRawFilter);
            this.xtpSQLraw.Controls.Add(this.meRawSQL);
            this.xtpSQLraw.Name = "xtpSQLraw";
            this.xtpSQLraw.Size = new System.Drawing.Size(1428, 142);
            this.xtpSQLraw.Text = "Raw SQL Filtering";
            // 
            // sbtnRawFilter
            // 
            this.sbtnRawFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnRawFilter.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.sbtnRawFilter.Location = new System.Drawing.Point(1371, 12);
            this.sbtnRawFilter.Name = "sbtnRawFilter";
            this.sbtnRawFilter.Size = new System.Drawing.Size(110, 34);
            this.sbtnRawFilter.TabIndex = 1;
            this.sbtnRawFilter.Text = "Apply";
            // 
            // meRawSQL
            // 
            this.meRawSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.meRawSQL.Location = new System.Drawing.Point(3, 11);
            this.meRawSQL.MenuManager = this.barManager1;
            this.meRawSQL.Name = "meRawSQL";
            this.meRawSQL.Size = new System.Drawing.Size(1362, 118);
            this.meRawSQL.TabIndex = 0;
            // 
            // dockPanelTree
            // 
            this.dockPanelTree.Controls.Add(this.dockPanelTreeContainer);
            this.dockPanelTree.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelTree.FloatSize = new System.Drawing.Size(500, 800);
            this.dockPanelTree.ID = new System.Guid("b1cbea9d-31d1-466d-ac5f-9854cb01fd71");
            this.dockPanelTree.Location = new System.Drawing.Point(1653, 240);
            this.dockPanelTree.Name = "dockPanelTree";
            this.dockPanelTree.OriginalSize = new System.Drawing.Size(200, 204);
            this.dockPanelTree.Size = new System.Drawing.Size(200, 283);
            this.dockPanelTree.Text = "dockPanelTree";
            // 
            // dockPanelTreeContainer
            // 
            this.dockPanelTreeContainer.Location = new System.Drawing.Point(6, 32);
            this.dockPanelTreeContainer.Name = "dockPanelTreeContainer";
            this.dockPanelTreeContainer.Size = new System.Drawing.Size(190, 247);
            this.dockPanelTreeContainer.TabIndex = 0;
            // 
            // filtersPopupMenu
            // 
            this.filtersPopupMenu.Manager = this.barManager1;
            this.filtersPopupMenu.Name = "filtersPopupMenu";
            // 
            // bbiBookmark
            // 
            this.bbiBookmark.Caption = "Bookmark Message";
            this.bbiBookmark.Id = 95;
            this.bbiBookmark.ImageOptions.Image = global::Analogy.CommonControls.Properties.Resources.Bookmark_16x16;
            this.bbiBookmark.Name = "bbiBookmark";
            // 
            // LogMessagesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dockPanelTree);
            this.Controls.Add(this.dockPanelFiltering);
            this.Controls.Add(this.dockPanelMessageInfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LogMessagesUC";
            this.Size = new System.Drawing.Size(1853, 759);
            this.Load += new System.EventHandler(this.LogMessagesUC_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.UCLogs_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.UCLogs_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkbHighlight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deOlderThanFilter.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deOlderThanFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceOlderThanFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNewerThanFilter.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNewerThanFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceNewerThanFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceModulesProcess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbModule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSources.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbExclude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceExcludeText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbInclude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIncludeText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSearchEverywhere.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuGoTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlLogs)).EndInit();
            this.layoutControlLogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltcMessages.Panel1)).EndInit();
            this.spltcMessages.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltcMessages.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltcMessages)).EndInit();
            this.spltcMessages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtbHighlight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPageNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstLogLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFilterPanelFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFilterPanelSearch.Properties)).EndInit();
            this.pnlExtraFilters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtcFilters)).EndInit();
            this.xtcFilters.ResumeLayout(false);
            this.xtpFiltersIncludes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clbInclude)).EndInit();
            this.xtpFiltersExclude.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clbExclude)).EndInit();
            this.xtpServerSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLevel)).EndInit();
            this.pnlLevel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLevelFilteringType)).EndInit();
            this.pnlLevelFilteringType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceLogLevelOr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceLogLevelAnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogGridPopupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanelLogs.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            this.dockPanel2_Container.PerformLayout();
            this.dockPanelMessageInfo.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            this.controlContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMessageDetails.Panel1)).EndInit();
            this.scMessageDetails.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMessageDetails.Panel2)).EndInit();
            this.scMessageDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMessageDetails)).EndInit();
            this.scMessageDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meMessageDetails.Properties)).EndInit();
            this.dockPanelFiltering.ResumeLayout(false);
            this.controlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtabFilters)).EndInit();
            this.xtabFilters.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            this.xtpSQLraw.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meRawSQL.Properties)).EndInit();
            this.dockPanelTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filtersPopupMenu)).EndInit();
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

        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModule;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnObject;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProcessID;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Timer tmrNewData;
        private System.Windows.Forms.ImageList imageListBottom;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTimeDiff;
        private DevExpress.XtraBars.StandaloneBarDockControl bdcTopFiltering;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barTopFiltering;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarToggleSwitchItem btswitchMessageDetails;
        private DevExpress.XtraBars.BarButtonItem bBtnSaveLog;
        private DevExpress.XtraBars.BarButtonItem bBtnImport;
        private DevExpress.XtraBars.BarButtonItem bBtnClearLog;
        internal DevExpress.XtraBars.BarToggleSwitchItem btswitchRefreshLog;
        private DevExpress.XtraEditors.SimpleButton sBtnMostCommon;
        private DevExpress.XtraEditors.CheckedListBoxControl chkLstLogLevel;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraBars.BarButtonItem bBtnExpand;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.Bar barMessage;
        private DevExpress.XtraBars.BarButtonItem bBtnButtomExpand;
        private DevExpress.XtraBars.BarButtonItem bBtnCopyButtom;
        private DevExpress.XtraBars.BarToggleSwitchItem btSwitchExpandButtomMessage;
        private DevExpress.XtraEditors.SimpleButton sbtnPageFirst;
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
        private DevExpress.XtraBars.BarButtonItem bBtnDataVisualizer;
        private DevExpress.XtraBars.BarButtonItem bbiScreenshot;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnThread;
        private DevExpress.XtraBars.BarButtonItem bbtnSaveViewAgnostic;
        private DevExpress.XtraBars.BarSubItem barSubItemSaveLog;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSaveEntireInAnalogy;
        private DevExpress.XtraEditors.TextEdit txtbInclude;
        private DevExpress.XtraEditors.TextEdit txtbExclude;
        private DevExpress.XtraEditors.TextEdit txtbHighlight;
        private DevExpress.XtraBars.BarSubItem bsiUndock;
        private DevExpress.XtraBars.BarButtonItem bBtnUndockViewPerProcess;
        private DevExpress.XtraEditors.SimpleButton sbtnTextInclude;
        private DevExpress.XtraEditors.SimpleButton sbtnTextExclude;
        private DevExpress.XtraEditors.TextEdit txtbSource;
        private DevExpress.XtraEditors.SimpleButton sbtnIncludeSources;
        private DevExpress.XtraEditors.TextEdit txtbModule;
        private DevExpress.XtraEditors.SimpleButton sbtnIncludeModules;
        private DevExpress.XtraEditors.DateEdit deNewerThanFilter;
        private DevExpress.XtraEditors.DateEdit deOlderThanFilter;
        private DevExpress.XtraEditors.SimpleButton sbtnMoreHighlight;
        private DevExpress.XtraEditors.SimpleButton sbtnPreDefinedFilters;
        private DevExpress.XtraBars.Bar barGroup;
        private DevExpress.XtraBars.BarButtonItem bBtnShare;
        private DevExpress.XtraBars.BarButtonItem bBtnFullGrid;
        private DevExpress.XtraBars.BarButtonItem bbtnReload;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMachineName;
        private DevExpress.XtraBars.BarButtonItem bBtnSaveCurrentSelectionCustomFormat;
        private DevExpress.XtraBars.BarButtonItem bBtnSaveCurrentSelectionAnalogyFormat;
        private DevExpress.XtraBars.BarButtonItem bBtnUndockSelection;
        private DevExpress.XtraEditors.CheckEdit ceExcludeText;
        private DevExpress.XtraEditors.CheckEdit ceIncludeText;
        private DevExpress.XtraEditors.CheckEdit ceSources;
        private DevExpress.XtraEditors.CheckEdit ceModulesProcess;
        private DevExpress.XtraEditors.CheckEdit ceOlderThanFilter;
        private DevExpress.XtraEditors.CheckEdit ceNewerThanFilter;
        private DevExpress.XtraEditors.CheckedListBoxControl clbInclude;
        private DevExpress.XtraEditors.CheckedListBoxControl clbExclude;
        private DevExpress.XtraTab.XtraTabControl xtcFilters;
        private DevExpress.XtraTab.XtraTabPage xtpFiltersIncludes;
        private DevExpress.XtraTab.XtraTabPage xtpFiltersExclude;
        private DevExpress.XtraEditors.SimpleButton sbtnToggleSearchFilter;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.PopupMenu LogGridPopupMenu;
        private DevExpress.XtraBars.BarButtonItem bbiDiffTime;
        private DevExpress.XtraBars.BarButtonItem bbiDatetiemFilterFrom;
        private DevExpress.XtraBars.BarButtonItem bbiDatetiemFilterTo;
        private DevExpress.XtraBars.BarButtonItem bbiCopyMessage;
        private DevExpress.XtraBars.BarButtonItem bbiCopyAllMessages;
        private DevExpress.XtraBars.BarButtonItem bbiAddNoteToMessage;
        private DevExpress.XtraBars.BarButtonItem bbiIncludeMessage;
        private DevExpress.XtraBars.BarButtonItem bbiIncludeColumnHeaderFilter;
        private DevExpress.XtraBars.BarButtonItem bbiExcludeMessage;
        private DevExpress.XtraBars.BarButtonItem bbiExcludeSource;
        private DevExpress.XtraBars.BarButtonItem bbiExcludeModule;
        private DevExpress.XtraBars.BarButtonItem bbiSaveLayout;
        private DevExpress.XtraBars.BarButtonItem bbiIncreaseFontSize;
        private DevExpress.XtraBars.BarButtonItem bbiDecreaseFontSize;
        private DevExpress.XtraBars.BarButtonItem bbiIncludeSource;
        private DevExpress.XtraBars.BarButtonItem bbiIncludeModule;
        private DevExpress.XtraBars.BarButtonItem bbiJsonViewer;
        private DevExpress.Utils.ToolTipController defaultToolTipController;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.Document documentMessages;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelLogs;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraBars.BarButtonItem bbtnCancel;
        private DevExpress.XtraBars.BarStaticItem bstaticTotalMessages;
        private DevExpress.XtraBars.BarStaticItem bstaticAlert;
        private DevExpress.XtraBars.BarEditItem bprogressBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar2;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelMessageInfo;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanelTreeContainer;
        private DevExpress.XtraBars.StandaloneBarDockControl sbarMessageInfo;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelTree;
        private DevExpress.XtraEditors.PanelControl pnlLevel;
        private DevExpress.XtraEditors.PanelControl pnlLevelFilteringType;
        private DevExpress.XtraEditors.CheckEdit ceLogLevelOr;
        private DevExpress.XtraEditors.CheckEdit ceLogLevelAnd;
        private System.Windows.Forms.Panel pnlExtraFilters;
        private DevExpress.XtraEditors.CheckEdit ceFilterPanelFilter;
        private DevExpress.XtraEditors.CheckEdit ceFilterPanelSearch;
        private DevExpress.XtraBars.BarSubItem bsiSettings;
        private DevExpress.XtraBars.BarWorkspaceMenuItem bwmiLayout;
        private DevExpress.Utils.WorkspaceManager wsLogs;
        private DevExpress.XtraBars.BarSubItem bsiLayouts;
        private DevExpress.XtraBars.BarButtonItem bbiGoToMessage;
        private DevExpress.XtraBars.BarButtonItem bbiGoToActiveMessage;
        private DevExpress.XtraRichEdit.RichEditControl recMessageDetails;
        private DevExpress.XtraEditors.SplitContainerControl scMessageDetails;
        private DevExpress.XtraEditors.MemoEdit meMessageDetails;
        private DevExpress.XtraBars.BarToggleSwitchItem btsViewAsHTML;
        private DevExpress.XtraBars.Docking.DockPanel dockPanelFiltering;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer2;
        private DevExpress.XtraTab.XtraTabControl xtabFilters;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraBars.BarButtonItem bbtnRawMessageViewer;
        private DevExpress.XtraLayout.LayoutControl layoutControlLogs;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraEditors.CheckEdit chkbHighlight;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.SimpleLabelItem lblPageNumber;
        private DevExpress.XtraBars.BarSubItem bsiTimeOffset;
        private DevExpress.XtraBars.BarCheckItem bciTimeOffset;
        private DevExpress.XtraBars.BarCheckItem bciTimeOffsetPredefined;
        private DevExpress.XtraBars.BarCheckItem bciTimeOffsetUTCToLocal;
        private DevExpress.XtraBars.BarCheckItem bciTimeOffsetLocalToUTC;
        private DevExpress.XtraEditors.DropDownButton ddbGoTo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraBars.PopupMenu popupMenuGoTo;
        private DevExpress.XtraEditors.SplitContainerControl spltcMessages;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraBars.BarToggleSwitchItem btsiInlineJsonViewer;
        private DevExpress.XtraBars.BarStaticItem bsiProgress;
        private DevExpress.XtraBars.PopupMenu filtersPopupMenu;
        private DevExpress.XtraTab.XtraTabPage xtpSQLraw;
        private DevExpress.XtraEditors.SimpleButton sbtnRawFilter;
        private DevExpress.XtraEditors.MemoEdit meRawSQL;
        private DevExpress.XtraBars.BarButtonItem bbiJsonColumn;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRawText;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnLineNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMethodName;
        private DevExpress.XtraEditors.CheckEdit ceSearchEverywhere;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraBars.BarButtonItem bbiExportToSimpleList;
        private DevExpress.XtraTab.XtraTabPage xtpServerSide;
        private DevExpress.XtraEditors.SimpleButton sbtnServerSide;
        private DevExpress.XtraBars.BarButtonItem bbiCollapseFolderPanel;
        private DevExpress.XtraBars.BarButtonItem bbiBookmark;
    }
}
