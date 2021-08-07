
namespace Analogy.UserControls
{
    partial class FilePlotterUC
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
            this.lblFile = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.teFile = new DevExpress.XtraEditors.TextEdit();
            this.sbtnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.ceFirstCulmnIsXAxis = new DevExpress.XtraEditors.CheckEdit();
            this.ceFirstRowTitle = new DevExpress.XtraEditors.CheckEdit();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.rgFirstColumnType = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.teFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFirstCulmnIsXAxis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFirstRowTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel2.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgFirstColumnType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFile
            // 
            this.lblFile.Location = new System.Drawing.Point(360, 3);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(68, 16);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "File to load:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(333, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "You can use this window to plot a tabular Data from a file.";
            // 
            // teFile
            // 
            this.teFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teFile.Location = new System.Drawing.Point(449, 3);
            this.teFile.Name = "teFile";
            this.teFile.Size = new System.Drawing.Size(631, 22);
            this.teFile.TabIndex = 2;
            // 
            // sbtnLoad
            // 
            this.sbtnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnLoad.Location = new System.Drawing.Point(1153, 6);
            this.sbtnLoad.Name = "sbtnLoad";
            this.sbtnLoad.Size = new System.Drawing.Size(57, 20);
            this.sbtnLoad.TabIndex = 3;
            this.sbtnLoad.Text = "Load";
            // 
            // sbtnBrowse
            // 
            this.sbtnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnBrowse.Location = new System.Drawing.Point(1104, 6);
            this.sbtnBrowse.Name = "sbtnBrowse";
            this.sbtnBrowse.Size = new System.Drawing.Size(42, 20);
            this.sbtnBrowse.TabIndex = 4;
            this.sbtnBrowse.Text = "...";
            // 
            // ceFirstCulmnIsXAxis
            // 
            this.ceFirstCulmnIsXAxis.Location = new System.Drawing.Point(3, 55);
            this.ceFirstCulmnIsXAxis.Name = "ceFirstCulmnIsXAxis";
            this.ceFirstCulmnIsXAxis.Properties.Caption = "Use first column as the chart X axis values:";
            this.ceFirstCulmnIsXAxis.Size = new System.Drawing.Size(333, 24);
            this.ceFirstCulmnIsXAxis.TabIndex = 6;
            // 
            // ceFirstRowTitle
            // 
            this.ceFirstRowTitle.Location = new System.Drawing.Point(3, 25);
            this.ceFirstRowTitle.Name = "ceFirstRowTitle";
            this.ceFirstRowTitle.Properties.Caption = "First row is the columns\' titles to use";
            this.ceFirstRowTitle.Size = new System.Drawing.Size(296, 24);
            this.ceFirstRowTitle.TabIndex = 5;
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel2});
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dockPanel2.DockedAsTabbedDocument = true;
            this.dockPanel2.ID = new System.Guid("83625067-e18c-42ae-a234-6a5396d6d2c8");
            this.dockPanel2.Location = new System.Drawing.Point(-32768, -32768);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel2.SavedDockingContainerId = new System.Guid("cca371d2-8e46-4262-b33e-46c8bbc801cd");
            this.dockPanel2.SavedIndex = 1;
            this.dockPanel2.SavedMdiDocument = true;
            this.dockPanel2.SavedMdiDocumentIndex = 0;
            this.dockPanel2.Size = new System.Drawing.Size(1216, 288);
            this.dockPanel2.Text = "dockPanel2";
            this.dockPanel2.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(1216, 288);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dockPanel1.ID = new System.Guid("27f82a55-705d-4a8b-8dbf-d05c9fe6d846");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 153);
            this.dockPanel1.Size = new System.Drawing.Size(1222, 153);
            this.dockPanel1.Text = "Input File";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.rgFirstColumnType);
            this.dockPanel1_Container.Controls.Add(this.sbtnBrowse);
            this.dockPanel1_Container.Controls.Add(this.sbtnLoad);
            this.dockPanel1_Container.Controls.Add(this.ceFirstCulmnIsXAxis);
            this.dockPanel1_Container.Controls.Add(this.labelControl1);
            this.dockPanel1_Container.Controls.Add(this.ceFirstRowTitle);
            this.dockPanel1_Container.Controls.Add(this.lblFile);
            this.dockPanel1_Container.Controls.Add(this.teFile);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 32);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(1214, 115);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // rgFirstColumnType
            // 
            this.rgFirstColumnType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgFirstColumnType.Location = new System.Drawing.Point(449, 31);
            this.rgFirstColumnType.Name = "rgFirstColumnType";
            this.rgFirstColumnType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Unix Date/Time in Miliseconds"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Unix Date/Time in Seconds"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Numerical")});
            this.rgFirstColumnType.Size = new System.Drawing.Size(761, 81);
            this.rgFirstColumnType.TabIndex = 7;
            // 
            // FilePlotterUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dockPanel1);
            this.Name = "FilePlotterUC";
            this.Size = new System.Drawing.Size(1222, 479);
            this.Load += new System.EventHandler(this.GenericPlotterUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFirstCulmnIsXAxis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFirstRowTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgFirstColumnType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblFile;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit teFile;
        private DevExpress.XtraEditors.SimpleButton sbtnLoad;
        private DevExpress.XtraEditors.SimpleButton sbtnBrowse;
        private DevExpress.XtraEditors.CheckEdit ceFirstRowTitle;
        private DevExpress.XtraEditors.CheckEdit ceFirstCulmnIsXAxis;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraEditors.RadioGroup rgFirstColumnType;
    }
}
