
namespace Analogy.ApplicationSettings
{
    partial class DataProvidersRealTimeSettingsUC
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
            this.chkLstItemRealTimeDataSources = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstItemRealTimeDataSources)).BeginInit();
            this.SuspendLayout();
            // 
            // chkLstItemRealTimeDataSources
            // 
            this.chkLstItemRealTimeDataSources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLstItemRealTimeDataSources.Location = new System.Drawing.Point(0, 36);
            this.chkLstItemRealTimeDataSources.Name = "chkLstItemRealTimeDataSources";
            this.chkLstItemRealTimeDataSources.Size = new System.Drawing.Size(598, 504);
            this.chkLstItemRealTimeDataSources.TabIndex = 12;
            // 
            // labelControl6
            // 
            this.labelControl6.AutoEllipsis = true;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl6.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl6.Location = new System.Drawing.Point(0, 0);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Padding = new System.Windows.Forms.Padding(10);
            this.labelControl6.Size = new System.Drawing.Size(598, 36);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Load the following real time data sources at startup:";
            // 
            // DataProvidersRealTimeSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.chkLstItemRealTimeDataSources);
            this.Controls.Add(this.labelControl6);
            this.Name = "DataProvidersRealTimeSettingsUC";
            this.Size = new System.Drawing.Size(598, 540);
            this.Load += new System.EventHandler(this.DataProvidersRealTimeSettingsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkLstItemRealTimeDataSources)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl chkLstItemRealTimeDataSources;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}
