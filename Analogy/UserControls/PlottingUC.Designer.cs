
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
            this.nudWindow = new System.Windows.Forms.NumericUpDown();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.nudRefreshInterval = new System.Windows.Forms.NumericUpDown();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.nudWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRefreshInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // nudWindow
            // 
            this.nudWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudWindow.Location = new System.Drawing.Point(1031, 3);
            this.nudWindow.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudWindow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWindow.Name = "nudWindow";
            this.nudWindow.Size = new System.Drawing.Size(73, 23);
            this.nudWindow.TabIndex = 19;
            this.nudWindow.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(845, 7);
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
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.nudRefreshInterval);
            this.splitContainerControl1.Panel1.Controls.Add(this.nudWindow);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.chartControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1107, 521);
            this.splitContainerControl1.SplitterPosition = 54;
            this.splitContainerControl1.TabIndex = 21;
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
            this.chartControl1.Size = new System.Drawing.Size(1107, 461);
            this.chartControl1.TabIndex = 1;
            // 
            // nudRefreshInterval
            // 
            this.nudRefreshInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRefreshInterval.Location = new System.Drawing.Point(1031, 31);
            this.nudRefreshInterval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudRefreshInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudRefreshInterval.Name = "nudRefreshInterval";
            this.nudRefreshInterval.Size = new System.Drawing.Size(73, 23);
            this.nudRefreshInterval.TabIndex = 21;
            this.nudRefreshInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Location = new System.Drawing.Point(834, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(191, 16);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "Chart refresh rate (milliseconds):";
            // 
            // PlottingUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "PlottingUC";
            this.Size = new System.Drawing.Size(1107, 521);
            this.Load += new System.EventHandler(this.PlottingUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRefreshInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudWindow;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.NumericUpDown nudRefreshInterval;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
