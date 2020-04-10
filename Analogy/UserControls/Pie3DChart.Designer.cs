namespace DevExpress.XtraCharts.Demos {
    partial class Pie3DChart {
        System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.SimpleDiagram3D simpleDiagram3D1 = new DevExpress.XtraCharts.SimpleDiagram3D();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Pie3DSeriesLabel pie3DSeriesLabel1 = new DevExpress.XtraCharts.Pie3DSeriesLabel();
            DevExpress.XtraCharts.Pie3DSeriesView pie3DSeriesView1 = new DevExpress.XtraCharts.Pie3DSeriesView();
            DevExpress.XtraCharts.SimpleDiagram3D simpleDiagram3D2 = new DevExpress.XtraCharts.SimpleDiagram3D();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Doughnut3DSeriesLabel doughnut3DSeriesLabel1 = new DevExpress.XtraCharts.Doughnut3DSeriesLabel();
            DevExpress.XtraCharts.SeriesPoint seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint("Russia", new object[] {
            ((object)(17.0752D))}, 0);
            DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint("Canada", new object[] {
            ((object)(9.98467D))}, 1);
            DevExpress.XtraCharts.SeriesPoint seriesPoint3 = new DevExpress.XtraCharts.SeriesPoint("USA", new object[] {
            ((object)(9.63142D))}, 2);
            DevExpress.XtraCharts.SeriesPoint seriesPoint4 = new DevExpress.XtraCharts.SeriesPoint("China", new object[] {
            ((object)(9.59696D))}, 3);
            DevExpress.XtraCharts.SeriesPoint seriesPoint5 = new DevExpress.XtraCharts.SeriesPoint("Brazil", new object[] {
            ((object)(8.511965D))}, 4);
            DevExpress.XtraCharts.SeriesPoint seriesPoint6 = new DevExpress.XtraCharts.SeriesPoint("Australia", new object[] {
            ((object)(7.68685D))}, 5);
            DevExpress.XtraCharts.SeriesPoint seriesPoint7 = new DevExpress.XtraCharts.SeriesPoint("India", new object[] {
            ((object)(3.28759D))}, 6);
            DevExpress.XtraCharts.SeriesPoint seriesPoint8 = new DevExpress.XtraCharts.SeriesPoint("Others", new object[] {
            ((object)(81.2D))}, 7);
            DevExpress.XtraCharts.Doughnut3DSeriesView doughnut3DSeriesView1 = new DevExpress.XtraCharts.Doughnut3DSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer dockingContainer1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer();
            this.documentGroup = new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup(this.components);
            this.documentPie3D = new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document(this.components);
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanelPie3D = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelPie3D_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.chartPie3D = new DevExpress.XtraCharts.ChartControl();
            this.dockPanelDoughnut3D = new DevExpress.XtraBars.Docking.DockPanel();
            this.documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.currentTabbedView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.checkEditLabelVisible = new DevExpress.XtraEditors.CheckEdit();
            this.checkEditValueAsPercent = new DevExpress.XtraEditors.CheckEdit();
            this.comboBoxEditPerspectiveAngle = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButtonRestoreDefaultAngles = new DevExpress.XtraEditors.SimpleButton();
            this.spinEditHoleRadius = new DevExpress.XtraEditors.SpinEdit();
            this.comboBoxEditExplodedPoints = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEditHeightToWidthRatio = new DevExpress.XtraEditors.ComboBoxEdit();
            this.spinEditPointDistance = new DevExpress.XtraEditors.SpinEdit();
            this.comboBoxEditLabelPosition = new DevExpress.XtraEditors.ComboBoxEdit();
            this.spinEditExplodedDistance = new DevExpress.XtraEditors.SpinEdit();
            this.spinEditFunnelHoleRadius = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroupRoot = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroupPieDoughnutGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemDoughnutHoleRadius = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroupExplodedDistance = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemExplodedPoints = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroupLabel = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemLabelVisible = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemPosition = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemValueAsPercent = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroupFunnelGeneral = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemPointDistance = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemHeightToWidthRatio = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemFunnelHoleRadius = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroupCamera = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemPerspectiveAngle = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemRestoreDefaultAngles = new DevExpress.XtraLayout.LayoutControlItem();
            this.sidePanelOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneOptions)).BeginInit();
            this.tabPaneOptions.SuspendLayout();
            this.tabNavigationPageOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentPie3D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            this.dockPanelPie3D.SuspendLayout();
            this.dockPanelPie3D_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie3D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram3D1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pie3DSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pie3DSeriesView1)).BeginInit();
            this.dockPanelDoughnut3D.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram3D2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(doughnut3DSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(doughnut3DSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentTabbedView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLabelVisible.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditValueAsPercent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditPerspectiveAngle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditHoleRadius.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditExplodedPoints.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditHeightToWidthRatio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPointDistance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLabelPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditExplodedDistance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditFunnelHoleRadius.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupPieDoughnutGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDoughnutHoleRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupExplodedDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemExplodedPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemLabelVisible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemValueAsPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupFunnelGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPointDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemHeightToWidthRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFunnelHoleRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPerspectiveAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemRestoreDefaultAngles)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanelOptions
            // 
            this.sidePanelOptions.Location = new System.Drawing.Point(500, 0);
            this.sidePanelOptions.Size = new System.Drawing.Size(550, 747);
            // 
            // tabPaneOptions
            // 
            this.tabPaneOptions.RegularSize = new System.Drawing.Size(549, 747);
            this.tabPaneOptions.Size = new System.Drawing.Size(549, 747);
            // 
            // tabNavigationPageOptions
            // 
            this.tabNavigationPageOptions.Controls.Add(this.layoutControl);
            this.tabNavigationPageOptions.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.tabNavigationPageOptions.Size = new System.Drawing.Size(549, 714);
            // 
            // documentGroup
            // 
            this.documentGroup.Items.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.Document[] {
            this.documentPie3D});
            // 
            // documentPie3D
            // 
            this.documentPie3D.Caption = "Pie 3D";
            this.documentPie3D.ControlName = "dockPanelPie3D";
            this.documentPie3D.FloatLocation = new System.Drawing.Point(0, 0);
            this.documentPie3D.FloatSize = new System.Drawing.Size(200, 200);
            this.documentPie3D.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.documentPie3D.Properties.AllowClose = DevExpress.Utils.DefaultBoolean.False;
            this.documentPie3D.Properties.AllowFloat = DevExpress.Utils.DefaultBoolean.True;
            this.documentPie3D.Properties.AllowFloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            // 
            // dockManager
            // 
            this.dockManager.DockingOptions.FloatOnDblClick = false;
            this.dockManager.DockingOptions.ShowAutoHideButton = false;
            this.dockManager.DockingOptions.ShowCloseButton = false;
            this.dockManager.DockingOptions.ShowMaximizeButton = false;
            this.dockManager.Form = this;
            this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelPie3D,
            this.dockPanelDoughnut3D});
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // dockPanelPie3D
            // 
            this.dockPanelPie3D.Controls.Add(this.dockPanelPie3D_Container);
            this.dockPanelPie3D.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dockPanelPie3D.DockedAsTabbedDocument = true;
            this.dockPanelPie3D.ID = new System.Guid("7e379c16-fc83-4f40-9a2f-161f41dcd445");
            this.dockPanelPie3D.Location = new System.Drawing.Point(0, 0);
            this.dockPanelPie3D.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.dockPanelPie3D.Name = "dockPanelPie3D";
            this.dockPanelPie3D.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanelPie3D.Size = new System.Drawing.Size(1050, 719);
            this.dockPanelPie3D.Text = "Pie 3D";
            // 
            // dockPanelPie3D_Container
            // 
            this.dockPanelPie3D_Container.Controls.Add(this.chartPie3D);
            this.dockPanelPie3D_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanelPie3D_Container.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.dockPanelPie3D_Container.Name = "dockPanelPie3D_Container";
            this.dockPanelPie3D_Container.Size = new System.Drawing.Size(1050, 719);
            this.dockPanelPie3D_Container.TabIndex = 0;
            // 
            // chartPie3D
            // 
            this.chartPie3D.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            simpleDiagram3D1.LabelsResolveOverlappingMinIndent = 5;
            simpleDiagram3D1.RotationMatrixSerializable = "0.988078949645626;-0.149699007203377;0.0359193055267118;0;0.145375032739626;0.984" +
    "077045693696;0.102266651430075;0;-0.0506565802551933;-0.0958257553118746;0.99410" +
    "8311752679;0;0;0;0;1";
            simpleDiagram3D1.RuntimeRotation = true;
            simpleDiagram3D1.RuntimeScrolling = true;
            simpleDiagram3D1.RuntimeZooming = true;
            this.chartPie3D.Diagram = simpleDiagram3D1;
            this.chartPie3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPie3D.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.chartPie3D.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;
            this.chartPie3D.Legend.BackColor = System.Drawing.Color.Transparent;
            this.chartPie3D.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartPie3D.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartPie3D.Legend.Name = "Default Legend";
            this.chartPie3D.Location = new System.Drawing.Point(0, 0);
            this.chartPie3D.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.chartPie3D.Name = "chartPie3D";
            pie3DSeriesLabel1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            pie3DSeriesLabel1.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.Radial;
            pie3DSeriesLabel1.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
            pie3DSeriesLabel1.TextPattern = "{A}: {VP:P2}";
            series1.Label = pie3DSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.LegendTextPattern = "{A}";
            series1.Name = "Series 1";
            series1.View = pie3DSeriesView1;
            this.chartPie3D.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartPie3D.Size = new System.Drawing.Size(1050, 719);
            this.chartPie3D.TabIndex = 1;
            // 
            // dockPanelDoughnut3D
            // 
            this.dockPanelDoughnut3D.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dockPanelDoughnut3D.DockedAsTabbedDocument = true;
            this.dockPanelDoughnut3D.ID = new System.Guid("a60845bf-46cb-4dc4-8479-8abe2e400624");
            this.dockPanelDoughnut3D.Location = new System.Drawing.Point(0, 0);
            this.dockPanelDoughnut3D.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.dockPanelDoughnut3D.Name = "dockPanelDoughnut3D";
            this.dockPanelDoughnut3D.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanelDoughnut3D.Size = new System.Drawing.Size(1050, 719);
            this.dockPanelDoughnut3D.Text = "Doughnut 3D";
            // 
            // chartDoughnut3D
            // 
            simpleDiagram3D2.LabelsResolveOverlappingMinIndent = 3;
            simpleDiagram3D2.RotationMatrixSerializable = "0.965925826289068;0.258819045102521;0;0;-0.212012149896655;0.791240115236224;-0.5" +
    "73576436351046;0;-0.148452505549685;0.554032293222323;0.819152044288992;0;0;0;0;" +
    "1";
            simpleDiagram3D2.RuntimeRotation = true;
            simpleDiagram3D2.RuntimeScrolling = true;
            simpleDiagram3D2.RuntimeZooming = true;
            doughnut3DSeriesLabel1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            doughnut3DSeriesLabel1.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.Radial;
            doughnut3DSeriesLabel1.TextPattern = "{A}: {VP:P2}";
            series2.Label = doughnut3DSeriesLabel1;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.LegendTextPattern = "{A}";
            series2.Name = "Series 1";
            series2.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint1,
            seriesPoint2,
            seriesPoint3,
            seriesPoint4,
            seriesPoint5,
            seriesPoint6,
            seriesPoint7,
            seriesPoint8});
            series2.View = doughnut3DSeriesView1;
            chartTitle1.Indent = 10;
            chartTitle1.Text = "Land Area by Country";
            chartTitle2.Alignment = System.Drawing.StringAlignment.Far;
            chartTitle2.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Bottom;
            chartTitle2.Font = new System.Drawing.Font("Tahoma", 8F);
            chartTitle2.Text = "From www.nationmaster.com";
            chartTitle2.TextColor = System.Drawing.Color.Gray;
            // 
            // documentManager
            // 
            this.documentManager.ContainerControl = this;
            this.documentManager.View = this.currentTabbedView;
            this.documentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.currentTabbedView});
            // 
            // currentTabbedView
            // 
            this.currentTabbedView.DocumentGroupProperties.HeaderButtons = DevExpress.XtraTab.TabButtons.None;
            this.currentTabbedView.DocumentGroupProperties.ShowDocumentSelectorButton = false;
            this.currentTabbedView.DocumentGroups.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DocumentGroup[] {
            this.documentGroup});
            this.currentTabbedView.DocumentProperties.AllowAnimation = false;
            this.currentTabbedView.DocumentProperties.AllowClose = false;
            this.currentTabbedView.DocumentProperties.AllowDock = false;
            this.currentTabbedView.DocumentProperties.AllowDockFill = false;
            this.currentTabbedView.DocumentProperties.AllowFloat = false;
            this.currentTabbedView.DocumentProperties.AllowFloatOnDoubleClick = false;
            this.currentTabbedView.DocumentProperties.AllowTabReordering = false;
            this.currentTabbedView.DocumentProperties.ShowInDocumentSelector = false;
            this.currentTabbedView.DocumentProperties.ShowPinButton = false;
            this.currentTabbedView.Documents.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseDocument[] {
            this.documentPie3D});
            dockingContainer1.Element = this.documentGroup;
            this.currentTabbedView.RootContainer.Nodes.AddRange(new DevExpress.XtraBars.Docking2010.Views.Tabbed.DockingContainer[] {
            dockingContainer1});
            this.currentTabbedView.Style = DevExpress.XtraBars.Docking2010.Views.DockingViewStyle.Light;
            this.currentTabbedView.DocumentActivated += new DevExpress.XtraBars.Docking2010.Views.DocumentEventHandler(this.tabbedView_DocumentActivated);
            // 
            // layoutControl
            // 
            this.layoutControl.AllowCustomization = false;
            this.layoutControl.Controls.Add(this.checkEditLabelVisible);
            this.layoutControl.Controls.Add(this.checkEditValueAsPercent);
            this.layoutControl.Controls.Add(this.comboBoxEditPerspectiveAngle);
            this.layoutControl.Controls.Add(this.simpleButtonRestoreDefaultAngles);
            this.layoutControl.Controls.Add(this.spinEditHoleRadius);
            this.layoutControl.Controls.Add(this.comboBoxEditExplodedPoints);
            this.layoutControl.Controls.Add(this.comboBoxEditHeightToWidthRatio);
            this.layoutControl.Controls.Add(this.spinEditPointDistance);
            this.layoutControl.Controls.Add(this.comboBoxEditLabelPosition);
            this.layoutControl.Controls.Add(this.spinEditExplodedDistance);
            this.layoutControl.Controls.Add(this.spinEditFunnelHoleRadius);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(325, 182, 650, 400);
            this.layoutControl.Root = this.layoutControlGroupRoot;
            this.layoutControl.Size = new System.Drawing.Size(549, 714);
            this.layoutControl.TabIndex = 2;
            this.layoutControl.Text = "layoutControl1";
            // 
            // checkEditLabelVisible
            // 
            this.checkEditLabelVisible.EditValue = true;
            this.checkEditLabelVisible.Location = new System.Drawing.Point(13, 285);
            this.checkEditLabelVisible.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.checkEditLabelVisible.Name = "checkEditLabelVisible";
            this.checkEditLabelVisible.Properties.Caption = "Visible";
            this.checkEditLabelVisible.Size = new System.Drawing.Size(523, 20);
            this.checkEditLabelVisible.StyleController = this.layoutControl;
            this.checkEditLabelVisible.TabIndex = 7;
            this.checkEditLabelVisible.CheckedChanged += new System.EventHandler(this.checkEditLabelVisible_CheckedChanged);
            // 
            // checkEditValueAsPercent
            // 
            this.checkEditValueAsPercent.Location = new System.Drawing.Point(13, 309);
            this.checkEditValueAsPercent.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.checkEditValueAsPercent.Name = "checkEditValueAsPercent";
            this.checkEditValueAsPercent.Properties.Caption = "Value as Percent";
            this.checkEditValueAsPercent.Size = new System.Drawing.Size(523, 20);
            this.checkEditValueAsPercent.StyleController = this.layoutControl;
            this.checkEditValueAsPercent.TabIndex = 8;
            // 
            // comboBoxEditPerspectiveAngle
            // 
            this.comboBoxEditPerspectiveAngle.Location = new System.Drawing.Point(148, 405);
            this.comboBoxEditPerspectiveAngle.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.comboBoxEditPerspectiveAngle.Name = "comboBoxEditPerspectiveAngle";
            this.comboBoxEditPerspectiveAngle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditPerspectiveAngle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditPerspectiveAngle.Size = new System.Drawing.Size(388, 22);
            this.comboBoxEditPerspectiveAngle.StyleController = this.layoutControl;
            this.comboBoxEditPerspectiveAngle.TabIndex = 10;
            // 
            // simpleButtonRestoreDefaultAngles
            // 
            this.simpleButtonRestoreDefaultAngles.Location = new System.Drawing.Point(14, 447);
            this.simpleButtonRestoreDefaultAngles.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.simpleButtonRestoreDefaultAngles.Name = "simpleButtonRestoreDefaultAngles";
            this.simpleButtonRestoreDefaultAngles.Size = new System.Drawing.Size(521, 27);
            this.simpleButtonRestoreDefaultAngles.StyleController = this.layoutControl;
            this.simpleButtonRestoreDefaultAngles.TabIndex = 11;
            this.simpleButtonRestoreDefaultAngles.Text = "Restore Default Angles";
            // 
            // spinEditHoleRadius
            // 
            this.spinEditHoleRadius.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditHoleRadius.Location = new System.Drawing.Point(148, 63);
            this.spinEditHoleRadius.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.spinEditHoleRadius.Name = "spinEditHoleRadius";
            this.spinEditHoleRadius.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditHoleRadius.Properties.DisplayFormat.FormatString = "0\\%";
            this.spinEditHoleRadius.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditHoleRadius.Properties.IsFloatValue = false;
            this.spinEditHoleRadius.Properties.Mask.EditMask = "N00";
            this.spinEditHoleRadius.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEditHoleRadius.Size = new System.Drawing.Size(388, 22);
            this.spinEditHoleRadius.StyleController = this.layoutControl;
            this.spinEditHoleRadius.TabIndex = 2;
            // 
            // comboBoxEditExplodedPoints
            // 
            this.comboBoxEditExplodedPoints.Location = new System.Drawing.Point(148, 37);
            this.comboBoxEditExplodedPoints.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.comboBoxEditExplodedPoints.Name = "comboBoxEditExplodedPoints";
            this.comboBoxEditExplodedPoints.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditExplodedPoints.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditExplodedPoints.Size = new System.Drawing.Size(388, 22);
            this.comboBoxEditExplodedPoints.StyleController = this.layoutControl;
            this.comboBoxEditExplodedPoints.TabIndex = 0;
            this.comboBoxEditExplodedPoints.EditValueChanged += new System.EventHandler(this.comboBoxEditExplodedPoints_SelectedIndexChanged);
            // 
            // comboBoxEditHeightToWidthRatio
            // 
            this.comboBoxEditHeightToWidthRatio.Location = new System.Drawing.Point(148, 213);
            this.comboBoxEditHeightToWidthRatio.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.comboBoxEditHeightToWidthRatio.Name = "comboBoxEditHeightToWidthRatio";
            this.comboBoxEditHeightToWidthRatio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditHeightToWidthRatio.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditHeightToWidthRatio.Size = new System.Drawing.Size(388, 22);
            this.comboBoxEditHeightToWidthRatio.StyleController = this.layoutControl;
            this.comboBoxEditHeightToWidthRatio.TabIndex = 6;
            this.comboBoxEditHeightToWidthRatio.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditHeightToWidthRatio_SelectedIndexChanged);
            // 
            // spinEditPointDistance
            // 
            this.spinEditPointDistance.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinEditPointDistance.Location = new System.Drawing.Point(148, 187);
            this.spinEditPointDistance.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.spinEditPointDistance.Name = "spinEditPointDistance";
            this.spinEditPointDistance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditPointDistance.Properties.DisplayFormat.FormatString = "0 px";
            this.spinEditPointDistance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditPointDistance.Properties.IsFloatValue = false;
            this.spinEditPointDistance.Properties.Mask.EditMask = "N00";
            this.spinEditPointDistance.Properties.MaxValue = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.spinEditPointDistance.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditPointDistance.Size = new System.Drawing.Size(388, 22);
            this.spinEditPointDistance.StyleController = this.layoutControl;
            this.spinEditPointDistance.TabIndex = 5;
            this.spinEditPointDistance.EditValueChanged += new System.EventHandler(this.spinEditPointDistance_EditValueChanged);
            // 
            // comboBoxEditLabelPosition
            // 
            this.comboBoxEditLabelPosition.Location = new System.Drawing.Point(148, 333);
            this.comboBoxEditLabelPosition.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.comboBoxEditLabelPosition.Name = "comboBoxEditLabelPosition";
            this.comboBoxEditLabelPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditLabelPosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditLabelPosition.Size = new System.Drawing.Size(388, 22);
            this.comboBoxEditLabelPosition.StyleController = this.layoutControl;
            this.comboBoxEditLabelPosition.TabIndex = 9;
            this.comboBoxEditLabelPosition.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditLabelPosition_SelectedIndexChanged);
            // 
            // spinEditExplodedDistance
            // 
            this.spinEditExplodedDistance.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditExplodedDistance.Location = new System.Drawing.Point(148, 89);
            this.spinEditExplodedDistance.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.spinEditExplodedDistance.Name = "spinEditExplodedDistance";
            this.spinEditExplodedDistance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditExplodedDistance.Properties.DisplayFormat.FormatString = "0px";
            this.spinEditExplodedDistance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditExplodedDistance.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spinEditExplodedDistance.Properties.IsFloatValue = false;
            this.spinEditExplodedDistance.Properties.Mask.EditMask = "N00";
            this.spinEditExplodedDistance.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spinEditExplodedDistance.Size = new System.Drawing.Size(388, 22);
            this.spinEditExplodedDistance.StyleController = this.layoutControl;
            this.spinEditExplodedDistance.TabIndex = 3;
            this.spinEditExplodedDistance.EditValueChanged += new System.EventHandler(this.spinEditExplodedDistance_EditValueChanged);
            // 
            // spinEditFunnelHoleRadius
            // 
            this.spinEditFunnelHoleRadius.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditFunnelHoleRadius.Location = new System.Drawing.Point(148, 161);
            this.spinEditFunnelHoleRadius.Margin = new System.Windows.Forms.Padding(9, 4, 9, 4);
            this.spinEditFunnelHoleRadius.Name = "spinEditFunnelHoleRadius";
            this.spinEditFunnelHoleRadius.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditFunnelHoleRadius.Properties.DisplayFormat.FormatString = "0\\%";
            this.spinEditFunnelHoleRadius.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEditFunnelHoleRadius.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spinEditFunnelHoleRadius.Properties.IsFloatValue = false;
            this.spinEditFunnelHoleRadius.Properties.Mask.EditMask = "N00";
            this.spinEditFunnelHoleRadius.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.spinEditFunnelHoleRadius.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEditFunnelHoleRadius.Size = new System.Drawing.Size(388, 22);
            this.spinEditFunnelHoleRadius.StyleController = this.layoutControl;
            this.spinEditFunnelHoleRadius.TabIndex = 4;
            this.spinEditFunnelHoleRadius.EditValueChanged += new System.EventHandler(this.spinEditFunnelHoleRadius_EditValueChanged);
            // 
            // layoutControlGroupRoot
            // 
            this.layoutControlGroupRoot.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroupRoot.GroupBordersVisible = false;
            this.layoutControlGroupRoot.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroupPieDoughnutGeneral,
            this.layoutControlGroupLabel,
            this.emptySpaceItem,
            this.layoutControlGroupFunnelGeneral,
            this.layoutControlGroupCamera});
            this.layoutControlGroupRoot.Name = "Root";
            this.layoutControlGroupRoot.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroupRoot.Size = new System.Drawing.Size(549, 714);
            this.layoutControlGroupRoot.TextVisible = false;
            // 
            // layoutControlGroupPieDoughnutGeneral
            // 
            this.layoutControlGroupPieDoughnutGeneral.AppearanceGroup.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControlGroupPieDoughnutGeneral.AppearanceGroup.Options.UseBorderColor = true;
            this.layoutControlGroupPieDoughnutGeneral.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroupPieDoughnutGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemDoughnutHoleRadius,
            this.layoutControlGroupExplodedDistance,
            this.layoutControlItemExplodedPoints});
            this.layoutControlGroupPieDoughnutGeneral.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupPieDoughnutGeneral.Name = "layoutControlGroupPieDoughnutGeneral";
            this.layoutControlGroupPieDoughnutGeneral.Size = new System.Drawing.Size(549, 124);
            this.layoutControlGroupPieDoughnutGeneral.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroupPieDoughnutGeneral.Text = "General";
            // 
            // layoutControlItemDoughnutHoleRadius
            // 
            this.layoutControlItemDoughnutHoleRadius.Control = this.spinEditHoleRadius;
            this.layoutControlItemDoughnutHoleRadius.CustomizationFormText = "HoleRadius (%)";
            this.layoutControlItemDoughnutHoleRadius.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItemDoughnutHoleRadius.Name = "layoutControlItemDoughnutHoleRadius";
            this.layoutControlItemDoughnutHoleRadius.Size = new System.Drawing.Size(527, 26);
            this.layoutControlItemDoughnutHoleRadius.Text = "Hole Radius:";
            this.layoutControlItemDoughnutHoleRadius.TextSize = new System.Drawing.Size(132, 16);
            // 
            // layoutControlGroupExplodedDistance
            // 
            this.layoutControlGroupExplodedDistance.Control = this.spinEditExplodedDistance;
            this.layoutControlGroupExplodedDistance.Location = new System.Drawing.Point(0, 52);
            this.layoutControlGroupExplodedDistance.Name = "layoutControlGroupExplodedDistanstance";
            this.layoutControlGroupExplodedDistance.Size = new System.Drawing.Size(527, 26);
            this.layoutControlGroupExplodedDistance.Text = "Exploded Distanstance:";
            this.layoutControlGroupExplodedDistance.TextSize = new System.Drawing.Size(132, 16);
            // 
            // layoutControlItemExplodedPoints
            // 
            this.layoutControlItemExplodedPoints.Control = this.comboBoxEditExplodedPoints;
            this.layoutControlItemExplodedPoints.CustomizationFormText = "Exploded Points";
            this.layoutControlItemExplodedPoints.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemExplodedPoints.Name = "layoutControlItemExplodedPoints";
            this.layoutControlItemExplodedPoints.Size = new System.Drawing.Size(527, 26);
            this.layoutControlItemExplodedPoints.Text = "Exploded Points:";
            this.layoutControlItemExplodedPoints.TextSize = new System.Drawing.Size(132, 16);
            // 
            // layoutControlGroupLabel
            // 
            this.layoutControlGroupLabel.AppearanceGroup.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControlGroupLabel.AppearanceGroup.Options.UseBorderColor = true;
            this.layoutControlGroupLabel.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroupLabel.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemLabelVisible,
            this.layoutControlItemPosition,
            this.layoutControlItemValueAsPercent});
            this.layoutControlGroupLabel.Location = new System.Drawing.Point(0, 248);
            this.layoutControlGroupLabel.Name = "layoutControlGroupLabel";
            this.layoutControlGroupLabel.Size = new System.Drawing.Size(549, 120);
            this.layoutControlGroupLabel.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroupLabel.Text = "Label";
            // 
            // layoutControlItemLabelVisible
            // 
            this.layoutControlItemLabelVisible.Control = this.checkEditLabelVisible;
            this.layoutControlItemLabelVisible.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemLabelVisible.Name = "layoutControlItemLabelVisible";
            this.layoutControlItemLabelVisible.Size = new System.Drawing.Size(527, 24);
            this.layoutControlItemLabelVisible.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemLabelVisible.TextVisible = false;
            // 
            // layoutControlItemPosition
            // 
            this.layoutControlItemPosition.Control = this.comboBoxEditLabelPosition;
            this.layoutControlItemPosition.CustomizationFormText = "Label Position";
            this.layoutControlItemPosition.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItemPosition.Name = "layoutControlItemPosition";
            this.layoutControlItemPosition.Size = new System.Drawing.Size(527, 26);
            this.layoutControlItemPosition.Text = "Position:";
            this.layoutControlItemPosition.TextSize = new System.Drawing.Size(132, 16);
            // 
            // layoutControlItemValueAsPercent
            // 
            this.layoutControlItemValueAsPercent.Control = this.checkEditValueAsPercent;
            this.layoutControlItemValueAsPercent.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItemValueAsPercent.Name = "layoutControlItemValueAsPercent";
            this.layoutControlItemValueAsPercent.Size = new System.Drawing.Size(527, 24);
            this.layoutControlItemValueAsPercent.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItemValueAsPercent.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemValueAsPercent.TextVisible = false;
            // 
            // emptySpaceItem
            // 
            this.emptySpaceItem.AllowHotTrack = false;
            this.emptySpaceItem.Location = new System.Drawing.Point(0, 488);
            this.emptySpaceItem.Name = "emptySpaceItem";
            this.emptySpaceItem.Size = new System.Drawing.Size(549, 226);
            this.emptySpaceItem.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroupFunnelGeneral
            // 
            this.layoutControlGroupFunnelGeneral.AppearanceGroup.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControlGroupFunnelGeneral.AppearanceGroup.Options.UseBorderColor = true;
            this.layoutControlGroupFunnelGeneral.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroupFunnelGeneral.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemPointDistance,
            this.layoutControlItemHeightToWidthRatio,
            this.layoutControlItemFunnelHoleRadius});
            this.layoutControlGroupFunnelGeneral.Location = new System.Drawing.Point(0, 124);
            this.layoutControlGroupFunnelGeneral.Name = "layoutControlGroupFunnelGeneral";
            this.layoutControlGroupFunnelGeneral.Size = new System.Drawing.Size(549, 124);
            this.layoutControlGroupFunnelGeneral.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroupFunnelGeneral.Text = "General";
            // 
            // layoutControlItemPointDistance
            // 
            this.layoutControlItemPointDistance.Control = this.spinEditPointDistance;
            this.layoutControlItemPointDistance.CustomizationFormText = "Size:";
            this.layoutControlItemPointDistance.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItemPointDistance.Name = "layoutControlItemPointDistance";
            this.layoutControlItemPointDistance.Size = new System.Drawing.Size(527, 26);
            this.layoutControlItemPointDistance.Text = "Point Distance:";
            this.layoutControlItemPointDistance.TextSize = new System.Drawing.Size(132, 16);
            // 
            // layoutControlItemHeightToWidthRatio
            // 
            this.layoutControlItemHeightToWidthRatio.Control = this.comboBoxEditHeightToWidthRatio;
            this.layoutControlItemHeightToWidthRatio.CustomizationFormText = "Kind:";
            this.layoutControlItemHeightToWidthRatio.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItemHeightToWidthRatio.Name = "layoutControlItemHeightToWidthRatio";
            this.layoutControlItemHeightToWidthRatio.Size = new System.Drawing.Size(527, 26);
            this.layoutControlItemHeightToWidthRatio.Text = "Height / Width Ratio:";
            this.layoutControlItemHeightToWidthRatio.TextSize = new System.Drawing.Size(132, 16);
            // 
            // layoutControlItemFunnelHoleRadius
            // 
            this.layoutControlItemFunnelHoleRadius.Control = this.spinEditFunnelHoleRadius;
            this.layoutControlItemFunnelHoleRadius.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemFunnelHoleRadius.Name = "layoutControlItemFunnelHoleRadius";
            this.layoutControlItemFunnelHoleRadius.Size = new System.Drawing.Size(527, 26);
            this.layoutControlItemFunnelHoleRadius.Text = "Hole Radius:";
            this.layoutControlItemFunnelHoleRadius.TextSize = new System.Drawing.Size(132, 16);
            // 
            // layoutControlGroupCamera
            // 
            this.layoutControlGroupCamera.AppearanceGroup.BorderColor = System.Drawing.Color.Transparent;
            this.layoutControlGroupCamera.AppearanceGroup.Options.UseBorderColor = true;
            this.layoutControlGroupCamera.GroupStyle = DevExpress.Utils.GroupStyle.Title;
            this.layoutControlGroupCamera.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemPerspectiveAngle,
            this.layoutControlItemRestoreDefaultAngles});
            this.layoutControlGroupCamera.Location = new System.Drawing.Point(0, 368);
            this.layoutControlGroupCamera.Name = "layoutControlGroupCamera";
            this.layoutControlGroupCamera.Size = new System.Drawing.Size(549, 120);
            this.layoutControlGroupCamera.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroupCamera.Text = "Camera";
            // 
            // layoutControlItemPerspectiveAngle
            // 
            this.layoutControlItemPerspectiveAngle.Control = this.comboBoxEditPerspectiveAngle;
            this.layoutControlItemPerspectiveAngle.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemPerspectiveAngle.Name = "layoutControlItemPerspectiveAngle";
            this.layoutControlItemPerspectiveAngle.Size = new System.Drawing.Size(527, 26);
            this.layoutControlItemPerspectiveAngle.Text = "Perspective Angle:";
            this.layoutControlItemPerspectiveAngle.TextSize = new System.Drawing.Size(132, 16);
            // 
            // layoutControlItemRestoreDefaultAngles
            // 
            this.layoutControlItemRestoreDefaultAngles.Control = this.simpleButtonRestoreDefaultAngles;
            this.layoutControlItemRestoreDefaultAngles.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItemRestoreDefaultAngles.Name = "layoutControlItemRestoreDefaultAngles";
            this.layoutControlItemRestoreDefaultAngles.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 18, 3);
            this.layoutControlItemRestoreDefaultAngles.Size = new System.Drawing.Size(527, 48);
            this.layoutControlItemRestoreDefaultAngles.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItemRestoreDefaultAngles.TextVisible = false;
            // 
            // Pie3DChart
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Pie3DChart";
            this.Size = new System.Drawing.Size(1050, 747);
            this.Controls.SetChildIndex(this.sidePanelOptions, 0);
            this.sidePanelOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneOptions)).EndInit();
            this.tabPaneOptions.ResumeLayout(false);
            this.tabNavigationPageOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentPie3D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            this.dockPanelPie3D.ResumeLayout(false);
            this.dockPanelPie3D_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram3D1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pie3DSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pie3DSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie3D)).EndInit();
            this.dockPanelDoughnut3D.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram3D2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(doughnut3DSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(doughnut3DSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentTabbedView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLabelVisible.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditValueAsPercent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditPerspectiveAngle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditHoleRadius.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditExplodedPoints.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditHeightToWidthRatio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditPointDistance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLabelPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditExplodedDistance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditFunnelHoleRadius.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupPieDoughnutGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDoughnutHoleRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupExplodedDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemExplodedPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemLabelVisible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemValueAsPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupFunnelGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPointDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemHeightToWidthRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemFunnelHoleRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemPerspectiveAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemRestoreDefaultAngles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        XtraBars.Docking.DockManager dockManager;
        XtraBars.Docking.DockPanel dockPanelPie3D;
        XtraBars.Docking.ControlContainer dockPanelPie3D_Container;
        XtraBars.Docking2010.DocumentManager documentManager;
        XtraBars.Docking2010.Views.Tabbed.TabbedView currentTabbedView;
        XtraBars.Docking2010.Views.Tabbed.DocumentGroup documentGroup;
        XtraBars.Docking2010.Views.Tabbed.Document documentPie3D;
        XtraBars.Docking.DockPanel dockPanelDoughnut3D;
        XtraLayout.LayoutControl layoutControl;
        XtraEditors.CheckEdit checkEditLabelVisible;
        XtraEditors.CheckEdit checkEditValueAsPercent;
        XtraEditors.ComboBoxEdit comboBoxEditPerspectiveAngle;
        XtraEditors.SimpleButton simpleButtonRestoreDefaultAngles;
        XtraLayout.LayoutControlGroup layoutControlGroupRoot;
        XtraLayout.LayoutControlGroup layoutControlGroupCamera;
        XtraLayout.LayoutControlItem layoutControlItemPerspectiveAngle;
        XtraLayout.LayoutControlItem layoutControlItemRestoreDefaultAngles;
        XtraLayout.LayoutControlGroup layoutControlGroupPieDoughnutGeneral;
        XtraLayout.LayoutControlGroup layoutControlGroupLabel;
        XtraLayout.LayoutControlItem layoutControlItemLabelVisible;
        XtraLayout.LayoutControlItem layoutControlItemValueAsPercent;
        XtraLayout.EmptySpaceItem emptySpaceItem;
        XtraEditors.SpinEdit spinEditHoleRadius;
        XtraEditors.ComboBoxEdit comboBoxEditExplodedPoints;
        XtraLayout.LayoutControlItem layoutControlItemDoughnutHoleRadius;
        XtraLayout.LayoutControlItem layoutControlItemExplodedPoints;
        XtraEditors.ComboBoxEdit comboBoxEditHeightToWidthRatio;
        XtraEditors.SpinEdit spinEditPointDistance;
        XtraLayout.LayoutControlItem layoutControlItemHeightToWidthRatio;
        XtraLayout.LayoutControlItem layoutControlItemPointDistance;
        XtraEditors.ComboBoxEdit comboBoxEditLabelPosition;
        XtraLayout.LayoutControlItem layoutControlItemPosition;
        XtraEditors.SpinEdit spinEditExplodedDistance;
        XtraLayout.LayoutControlItem layoutControlGroupExplodedDistance;
        XtraLayout.LayoutControlGroup layoutControlGroupFunnelGeneral;
        XtraEditors.SpinEdit spinEditFunnelHoleRadius;
        XtraLayout.LayoutControlItem layoutControlItemFunnelHoleRadius;
        ChartControl chartPie3D;
    }
}
