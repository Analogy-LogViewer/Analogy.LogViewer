
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
            this.lblFile = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.teFile = new DevExpress.XtraEditors.TextEdit();
            this.sbtnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.spltcMain = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.logGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.teFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltcMain.Panel1)).BeginInit();
            this.spltcMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltcMain.Panel2)).BeginInit();
            this.spltcMain.Panel2.SuspendLayout();
            this.spltcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFile
            // 
            this.lblFile.Location = new System.Drawing.Point(19, 37);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(68, 16);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "File to load:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(341, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "You can use this window to plot a tabular Data  from  a file.";
            // 
            // teFile
            // 
            this.teFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teFile.Location = new System.Drawing.Point(110, 36);
            this.teFile.Name = "teFile";
            this.teFile.Size = new System.Drawing.Size(983, 22);
            this.teFile.TabIndex = 2;
            // 
            // sbtnLoad
            // 
            this.sbtnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnLoad.Location = new System.Drawing.Point(1150, 38);
            this.sbtnLoad.Name = "sbtnLoad";
            this.sbtnLoad.Size = new System.Drawing.Size(57, 20);
            this.sbtnLoad.TabIndex = 3;
            this.sbtnLoad.Text = "Load";
            // 
            // sbtnBrowse
            // 
            this.sbtnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnBrowse.Location = new System.Drawing.Point(1101, 37);
            this.sbtnBrowse.Name = "sbtnBrowse";
            this.sbtnBrowse.Size = new System.Drawing.Size(42, 20);
            this.sbtnBrowse.TabIndex = 4;
            this.sbtnBrowse.Text = "...";
            // 
            // spltcMain
            // 
            this.spltcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltcMain.Horizontal = false;
            this.spltcMain.Location = new System.Drawing.Point(0, 0);
            this.spltcMain.Name = "spltcMain";
            // 
            // spltcMain.spltcMain_Panel1
            // 
            this.spltcMain.Panel1.Controls.Add(this.sbtnBrowse);
            this.spltcMain.Panel1.Controls.Add(this.labelControl1);
            this.spltcMain.Panel1.Controls.Add(this.teFile);
            this.spltcMain.Panel1.Controls.Add(this.lblFile);
            this.spltcMain.Panel1.Controls.Add(this.sbtnLoad);
            this.spltcMain.Panel1.Text = "Panel1";
            // 
            // spltcMain.spltcMain_Panel2
            // 
            this.spltcMain.Panel2.Controls.Add(this.gridControl);
            this.spltcMain.Panel2.Text = "Panel2";
            this.spltcMain.Size = new System.Drawing.Size(1222, 479);
            this.spltcMain.SplitterPosition = 70;
            this.spltcMain.TabIndex = 5;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.logGrid;
            this.gridControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1222, 403);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.logGrid});
            // 
            // logGrid
            // 
            this.logGrid.Appearance.Row.Options.UseTextOptions = true;
            this.logGrid.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.logGrid.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.logGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.logGrid.DetailHeight = 431;
            this.logGrid.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.logGrid.GridControl = this.gridControl;
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
            this.logGrid.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.logGrid.OptionsView.AutoCalcPreviewLineCount = true;
            this.logGrid.OptionsView.ColumnAutoWidth = false;
            this.logGrid.OptionsView.RowAutoHeight = true;
            this.logGrid.OptionsView.ShowAutoFilterRow = true;
            this.logGrid.OptionsView.ShowGroupPanel = false;
            // 
            // FilePlotterUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spltcMain);
            this.Name = "FilePlotterUC";
            this.Size = new System.Drawing.Size(1222, 479);
            this.Load += new System.EventHandler(this.GenericPlotterUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltcMain.Panel1)).EndInit();
            this.spltcMain.Panel1.ResumeLayout(false);
            this.spltcMain.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltcMain.Panel2)).EndInit();
            this.spltcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltcMain)).EndInit();
            this.spltcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblFile;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit teFile;
        private DevExpress.XtraEditors.SimpleButton sbtnLoad;
        private DevExpress.XtraEditors.SimpleButton sbtnBrowse;
        private DevExpress.XtraEditors.SplitContainerControl spltcMain;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView logGrid;
    }
}
