namespace Analogy.UserControls
{
    partial class DownloadStatisticsUC
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
            this.panelChart = new DevExpress.XtraEditors.PanelControl();
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.cbeReleases = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbeReleases.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelChart
            // 
            this.panelChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChart.Location = new System.Drawing.Point(0, 41);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(766, 411);
            this.panelChart.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.cbeReleases);
            this.panelTop.Controls.Add(this.lblTotal);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(766, 41);
            this.panelTop.TabIndex = 4;
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(7, 13);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(125, 16);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total Downloads: N/A";
            // 
            // cbeReleases
            // 
            this.cbeReleases.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbeReleases.Location = new System.Drawing.Point(496, 2);
            this.cbeReleases.Name = "cbeReleases";
            this.cbeReleases.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeReleases.Size = new System.Drawing.Size(268, 22);
            this.cbeReleases.TabIndex = 1;
            this.cbeReleases.SelectedIndexChanged += new System.EventHandler(this.cbeReleases_SelectedIndexChanged);
            // 
            // DownloadStatisticsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelChart);
            this.Controls.Add(this.panelTop);
            this.Name = "DownloadStatisticsUC";
            this.Size = new System.Drawing.Size(766, 452);
            this.Load += new System.EventHandler(this.DownloadStatisticsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbeReleases.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelChart;
        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private DevExpress.XtraEditors.ComboBoxEdit cbeReleases;
    }
}
