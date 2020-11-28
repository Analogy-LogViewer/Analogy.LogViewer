
namespace Analogy.Forms
{
    partial class UserStatisticsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblOpenedFiles = new DevExpress.XtraEditors.LabelControl();
            this.lblRunningTime = new DevExpress.XtraEditors.LabelControl();
            this.lblLaunchCount = new DevExpress.XtraEditors.LabelControl();
            this.btnClearStatistics = new DevExpress.XtraEditors.SimpleButton();
            this.tsUserStatistics = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsUserStatistics.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblOpenedFiles);
            this.groupControl1.Controls.Add(this.lblRunningTime);
            this.groupControl1.Controls.Add(this.lblLaunchCount);
            this.groupControl1.Controls.Add(this.btnClearStatistics);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 28);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(800, 422);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Statistics";
            // 
            // lblOpenedFiles
            // 
            this.lblOpenedFiles.Location = new System.Drawing.Point(26, 90);
            this.lblOpenedFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblOpenedFiles.Name = "lblOpenedFiles";
            this.lblOpenedFiles.Size = new System.Drawing.Size(156, 16);
            this.lblOpenedFiles.TabIndex = 3;
            this.lblOpenedFiles.Text = "Number Of Opened Files: 0";
            // 
            // lblRunningTime
            // 
            this.lblRunningTime.Location = new System.Drawing.Point(26, 63);
            this.lblRunningTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblRunningTime.Name = "lblRunningTime";
            this.lblRunningTime.Size = new System.Drawing.Size(95, 16);
            this.lblRunningTime.TabIndex = 2;
            this.lblRunningTime.Text = "Running Time: 0";
            // 
            // lblLaunchCount
            // 
            this.lblLaunchCount.Location = new System.Drawing.Point(26, 36);
            this.lblLaunchCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblLaunchCount.Name = "lblLaunchCount";
            this.lblLaunchCount.Size = new System.Drawing.Size(182, 16);
            this.lblLaunchCount.TabIndex = 1;
            this.lblLaunchCount.Text = "Number of Analogy Launches: 0";
            // 
            // btnClearStatistics
            // 
            this.btnClearStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearStatistics.Location = new System.Drawing.Point(699, 36);
            this.btnClearStatistics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearStatistics.Name = "btnClearStatistics";
            this.btnClearStatistics.Size = new System.Drawing.Size(96, 33);
            this.btnClearStatistics.TabIndex = 0;
            this.btnClearStatistics.Text = "Clear";
            this.btnClearStatistics.Click += new System.EventHandler(this.btnClearStatistics_Click);
            // 
            // tsUserStatistics
            // 
            this.tsUserStatistics.Dock = System.Windows.Forms.DockStyle.Top;
            this.tsUserStatistics.Location = new System.Drawing.Point(0, 0);
            this.tsUserStatistics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsUserStatistics.Name = "tsUserStatistics";
            this.tsUserStatistics.Properties.OffText = "User Statistics are disabled";
            this.tsUserStatistics.Properties.OnText = "User Statistics are enabled";
            this.tsUserStatistics.Size = new System.Drawing.Size(800, 28);
            this.tsUserStatistics.TabIndex = 4;
            this.tsUserStatistics.Toggled += new System.EventHandler(this.tsUserStatistics_Toggled);
            // 
            // UserStatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tsUserStatistics);
            this.Name = "UserStatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Statistics";
            this.Load += new System.EventHandler(this.UserStatisticsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsUserStatistics.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblOpenedFiles;
        private DevExpress.XtraEditors.LabelControl lblRunningTime;
        private DevExpress.XtraEditors.LabelControl lblLaunchCount;
        private DevExpress.XtraEditors.SimpleButton btnClearStatistics;
        private DevExpress.XtraEditors.ToggleSwitch tsUserStatistics;
    }
}