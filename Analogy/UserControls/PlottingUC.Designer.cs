
namespace Analogy.UserControls
{
    partial class PlottingUC
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.rbChartType = new DevExpress.XtraEditors.RadioGroup();
            this.lblChartType = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.nudWindow = new DevExpress.XtraEditors.SpinEdit();
            this.nudRefreshInterval = new DevExpress.XtraEditors.SpinEdit();
            this.sbtnSaveChart = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnCopyChart = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbChartType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWindow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRefreshInterval.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(810, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(180, 16);
            this.labelControl1.TabIndex = 20;
            this.labelControl1.Text = "Plotting Data Window To show:";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.sbtnCopyChart);
            this.splitContainerControl1.Panel1.Controls.Add(this.sbtnSaveChart);
            this.splitContainerControl1.Panel1.Controls.Add(this.nudRefreshInterval);
            this.splitContainerControl1.Panel1.Controls.Add(this.nudWindow);
            this.splitContainerControl1.Panel1.Controls.Add(this.rbChartType);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblChartType);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.chartControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1107, 521);
            this.splitContainerControl1.SplitterPosition = 101;
            this.splitContainerControl1.TabIndex = 21;
            // 
            // rbChartType
            // 
            this.rbChartType.Location = new System.Drawing.Point(95, 9);
            this.rbChartType.Name = "rbChartType";
            this.rbChartType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Single Chart"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Pane Per Series - Horizontal"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Pane Per Series - Vertical"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Pane Per Series - Auto Layout")});
            this.rbChartType.Size = new System.Drawing.Size(565, 75);
            this.rbChartType.TabIndex = 24;
            this.rbChartType.SelectedIndexChanged += new System.EventHandler(this.rbChartType_SelectedIndexChanged);
            // 
            // lblChartType
            // 
            this.lblChartType.Location = new System.Drawing.Point(12, 13);
            this.lblChartType.Name = "lblChartType";
            this.lblChartType.Size = new System.Drawing.Size(68, 16);
            this.lblChartType.TabIndex = 23;
            this.lblChartType.Text = "Chart Type:";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Location = new System.Drawing.Point(820, 37);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(170, 16);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "Chart refresh rate (Seconds):";
            // 
            // chartControl1
            // 
            this.chartControl1.BorderOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(217)))), ((int)(((byte)(240)))));
            this.chartControl1.BorderOptions.Thickness = 2;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartControl1.Size = new System.Drawing.Size(1107, 408);
            this.chartControl1.TabIndex = 1;
            // 
            // nudWindow
            // 
            this.nudWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudWindow.EditValue = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nudWindow.Location = new System.Drawing.Point(1001, 3);
            this.nudWindow.Name = "nudWindow";
            this.nudWindow.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nudWindow.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.nudWindow.Properties.MaskSettings.Set("mask", "n0");
            this.nudWindow.Size = new System.Drawing.Size(103, 24);
            this.nudWindow.TabIndex = 26;
            this.nudWindow.EditValueChanged += new System.EventHandler(this.nudWindow_EditValueChanged);
            // 
            // nudRefreshInterval
            // 
            this.nudRefreshInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRefreshInterval.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRefreshInterval.Location = new System.Drawing.Point(1001, 33);
            this.nudRefreshInterval.Name = "nudRefreshInterval";
            this.nudRefreshInterval.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nudRefreshInterval.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.nudRefreshInterval.Properties.MaskSettings.Set("mask", "n1");
            this.nudRefreshInterval.Size = new System.Drawing.Size(103, 24);
            this.nudRefreshInterval.TabIndex = 27;
            this.nudRefreshInterval.EditValueChanged += new System.EventHandler(this.nudRefreshInterval_EditValueChanged);
            // 
            // sbtnSaveChart
            // 
            this.sbtnSaveChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnSaveChart.Location = new System.Drawing.Point(1011, 63);
            this.sbtnSaveChart.Name = "sbtnSaveChart";
            this.sbtnSaveChart.Size = new System.Drawing.Size(93, 34);
            this.sbtnSaveChart.TabIndex = 28;
            this.sbtnSaveChart.Text = "Save Chart";
            this.sbtnSaveChart.Click += new System.EventHandler(this.sbtnSaveChart_Click);
            // 
            // sbtnCopyChart
            // 
            this.sbtnCopyChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnCopyChart.Location = new System.Drawing.Point(912, 63);
            this.sbtnCopyChart.Name = "sbtnCopyChart";
            this.sbtnCopyChart.Size = new System.Drawing.Size(93, 34);
            this.sbtnCopyChart.TabIndex = 29;
            this.sbtnCopyChart.Text = "Copy Chart";
            this.sbtnCopyChart.Click += new System.EventHandler(this.sbtnCopyChart_Click);
            // 
            // PlottingUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "PlottingUC";
            this.Size = new System.Drawing.Size(1107, 521);
            this.Load += new System.EventHandler(this.PlottingUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            this.splitContainerControl1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbChartType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWindow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRefreshInterval.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblChartType;
        private DevExpress.XtraEditors.RadioGroup rbChartType;
        private DevExpress.XtraEditors.SpinEdit nudWindow;
        private DevExpress.XtraEditors.SpinEdit nudRefreshInterval;
        private DevExpress.XtraEditors.SimpleButton sbtnSaveChart;
        private DevExpress.XtraEditors.SimpleButton sbtnCopyChart;
    }
}
