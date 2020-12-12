﻿namespace Analogy
{
    partial class DataVisualizerUC
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
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel2 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.seRefreshInterval = new DevExpress.XtraEditors.SpinEdit();
            this.ceAutoRefresh = new DevExpress.XtraEditors.CheckEdit();
            this.sBtnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.chklistItems = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.chartControlFrequency = new DevExpress.XtraCharts.ChartControl();
            this.tnpTimeDistribution = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.chartTimeDistribution = new DevExpress.XtraCharts.ChartControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtpMessagesText = new DevExpress.XtraTab.XtraTabPage();
            this.xtpPieChart = new DevExpress.XtraTab.XtraTabPage();
            this.logStatisticsUC1 = new Philips.Analogy.LogStatisticsUC();
            this.tmrPlotting = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seRefreshInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAutoRefresh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chklistItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.tabNavigationPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            this.tnpTimeDistribution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeDistribution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtpMessagesText.SuspendLayout();
            this.xtpPieChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.seRefreshInterval);
            this.splitContainerControl1.Panel1.Controls.Add(this.ceAutoRefresh);
            this.splitContainerControl1.Panel1.Controls.Add(this.sBtnAdd);
            this.splitContainerControl1.Panel1.Controls.Add(this.chklistItems);
            this.splitContainerControl1.Panel1.Controls.Add(this.textEdit1);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.tabPane1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1008, 537);
            this.splitContainerControl1.SplitterPosition = 138;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // seRefreshInterval
            // 
            this.seRefreshInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.seRefreshInterval.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seRefreshInterval.Enabled = false;
            this.seRefreshInterval.Location = new System.Drawing.Point(894, 51);
            this.seRefreshInterval.Name = "seRefreshInterval";
            this.seRefreshInterval.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seRefreshInterval.Properties.MaxValue = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.seRefreshInterval.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seRefreshInterval.Size = new System.Drawing.Size(110, 22);
            this.seRefreshInterval.TabIndex = 5;
            this.seRefreshInterval.EditValueChanged += new System.EventHandler(this.seRefreshInterval_EditValueChanged);
            // 
            // ceAutoRefresh
            // 
            this.ceAutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ceAutoRefresh.Enabled = false;
            this.ceAutoRefresh.Location = new System.Drawing.Point(721, 52);
            this.ceAutoRefresh.Name = "ceAutoRefresh";
            this.ceAutoRefresh.Properties.Caption = "Auto Refresh (seconds):";
            this.ceAutoRefresh.Size = new System.Drawing.Size(167, 20);
            this.ceAutoRefresh.TabIndex = 4;
            this.ceAutoRefresh.EditValueChanged += new System.EventHandler(this.ceAutoRefresh_EditValueChanged);
            // 
            // sBtnAdd
            // 
            this.sBtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sBtnAdd.Location = new System.Drawing.Point(919, 6);
            this.sBtnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sBtnAdd.Name = "sBtnAdd";
            this.sBtnAdd.Size = new System.Drawing.Size(85, 28);
            this.sBtnAdd.TabIndex = 3;
            this.sBtnAdd.Text = "Add";
            this.sBtnAdd.Click += new System.EventHandler(this.sBtnAdd_Click);
            // 
            // chklistItems
            // 
            this.chklistItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chklistItems.Location = new System.Drawing.Point(18, 40);
            this.chklistItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chklistItems.Name = "chklistItems";
            this.chklistItems.Size = new System.Drawing.Size(497, 93);
            this.chklistItems.TabIndex = 2;
            this.chklistItems.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chklistItems_ItemCheck);
            // 
            // textEdit1
            // 
            this.textEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit1.Location = new System.Drawing.Point(337, 10);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(576, 22);
            this.textEdit1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 13);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(307, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Filter messages (add empty for non filtering plotting):";
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.tabNavigationPage2);
            this.tabPane1.Controls.Add(this.tnpTimeDistribution);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(0, 0);
            this.tabPane1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tnpTimeDistribution,
            this.tabNavigationPage2});
            this.tabPane1.RegularSize = new System.Drawing.Size(1008, 393);
            this.tabPane1.SelectedPage = this.tnpTimeDistribution;
            this.tabPane1.Size = new System.Drawing.Size(1008, 393);
            this.tabPane1.TabIndex = 1;
            // 
            // tabNavigationPage2
            // 
            this.tabNavigationPage2.Caption = "Frequency Plot";
            this.tabNavigationPage2.Controls.Add(this.chartControlFrequency);
            this.tabNavigationPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabNavigationPage2.Name = "tabNavigationPage2";
            this.tabNavigationPage2.Size = new System.Drawing.Size(1008, 360);
            // 
            // chartControlFrequency
            // 
            this.chartControlFrequency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControlFrequency.Legend.Name = "Default Legend";
            this.chartControlFrequency.Location = new System.Drawing.Point(0, 0);
            this.chartControlFrequency.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartControlFrequency.Name = "chartControlFrequency";
            this.chartControlFrequency.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            sideBySideBarSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartControlFrequency.SeriesTemplate.Label = sideBySideBarSeriesLabel1;
            this.chartControlFrequency.Size = new System.Drawing.Size(1008, 360);
            this.chartControlFrequency.TabIndex = 2;
            // 
            // tnpTimeDistribution
            // 
            this.tnpTimeDistribution.Caption = "Time Distribution";
            this.tnpTimeDistribution.Controls.Add(this.chartTimeDistribution);
            this.tnpTimeDistribution.Name = "tnpTimeDistribution";
            this.tnpTimeDistribution.Size = new System.Drawing.Size(1008, 360);
            // 
            // chartTimeDistribution
            // 
            this.chartTimeDistribution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTimeDistribution.Legend.Name = "Default Legend";
            this.chartTimeDistribution.Location = new System.Drawing.Point(0, 0);
            this.chartTimeDistribution.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chartTimeDistribution.Name = "chartTimeDistribution";
            this.chartTimeDistribution.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            sideBySideBarSeriesLabel2.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartTimeDistribution.SeriesTemplate.Label = sideBySideBarSeriesLabel2;
            this.chartTimeDistribution.Size = new System.Drawing.Size(1008, 360);
            this.chartTimeDistribution.TabIndex = 3;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtpMessagesText;
            this.xtraTabControl1.Size = new System.Drawing.Size(1015, 571);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpMessagesText,
            this.xtpPieChart});
            // 
            // xtpMessagesText
            // 
            this.xtpMessagesText.Controls.Add(this.splitContainerControl1);
            this.xtpMessagesText.Name = "xtpMessagesText";
            this.xtpMessagesText.Size = new System.Drawing.Size(1008, 537);
            this.xtpMessagesText.Text = "Messages Text";
            // 
            // xtpPieChart
            // 
            this.xtpPieChart.Controls.Add(this.logStatisticsUC1);
            this.xtpPieChart.Name = "xtpPieChart";
            this.xtpPieChart.Size = new System.Drawing.Size(1008, 537);
            this.xtpPieChart.Text = "Pies";
            // 
            // logStatisticsUC1
            // 
            this.logStatisticsUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logStatisticsUC1.FreeTextStatistics = null;
            this.logStatisticsUC1.Location = new System.Drawing.Point(0, 0);
            this.logStatisticsUC1.Name = "logStatisticsUC1";
            this.logStatisticsUC1.Size = new System.Drawing.Size(1008, 537);
            this.logStatisticsUC1.Statistics = null;
            this.logStatisticsUC1.TabIndex = 0;
            // 
            // tmrPlotting
            // 
            this.tmrPlotting.Interval = 5000;
            this.tmrPlotting.Tick += new System.EventHandler(this.tmrPlotting_Tick);
            // 
            // DataVisualizerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataVisualizerUC";
            this.Size = new System.Drawing.Size(1015, 571);
            this.Load += new System.EventHandler(this.DataVisualizerUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seRefreshInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceAutoRefresh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chklistItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.tabNavigationPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlFrequency)).EndInit();
            this.tnpTimeDistribution.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTimeDistribution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtpMessagesText.ResumeLayout(false);
            this.xtpPieChart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton sBtnAdd;
        private DevExpress.XtraEditors.CheckedListBoxControl chklistItems;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage2;
        private DevExpress.XtraCharts.ChartControl chartControlFrequency;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tnpTimeDistribution;
        private DevExpress.XtraCharts.ChartControl chartTimeDistribution;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtpMessagesText;
        private DevExpress.XtraTab.XtraTabPage xtpPieChart;
        private Philips.Analogy.LogStatisticsUC logStatisticsUC1;
        private System.Windows.Forms.Timer tmrPlotting;
        private DevExpress.XtraEditors.SpinEdit seRefreshInterval;
        private DevExpress.XtraEditors.CheckEdit ceAutoRefresh;
    }
}
