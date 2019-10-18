namespace Analogy
{
    partial class XtraUCWindowsEventLogs
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lstSelected = new DevExpress.XtraEditors.ListBoxControl();
            this.btnRemove = new DevExpress.XtraEditors.SimpleButton();
            this.lstAvailable = new DevExpress.XtraEditors.ListBoxControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.lblLaunchCount = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstAvailable)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.splitContainerControl1);
            this.groupControl1.Controls.Add(this.lblLaunchCount);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(742, 486);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Windows Event logs";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 61);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.lstSelected);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnRemove);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.lstAvailable);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnAdd);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(738, 423);
            this.splitContainerControl1.SplitterPosition = 351;
            this.splitContainerControl1.TabIndex = 4;
            // 
            // lstSelected
            // 
            this.lstSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSelected.Location = new System.Drawing.Point(0, 30);
            this.lstSelected.Name = "lstSelected";
            this.lstSelected.Size = new System.Drawing.Size(351, 393);
            this.lstSelected.TabIndex = 2;
            // 
            // btnRemove
            // 
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRemove.Location = new System.Drawing.Point(0, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(351, 30);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "remove from selected logs ->";
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // lstAvailable
            // 
            this.lstAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAvailable.Location = new System.Drawing.Point(0, 30);
            this.lstAvailable.Name = "lstAvailable";
            this.lstAvailable.Size = new System.Drawing.Size(381, 393);
            this.lstAvailable.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(381, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "<-- Add to selected logs";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // lblLaunchCount
            // 
            this.lblLaunchCount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLaunchCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLaunchCount.Location = new System.Drawing.Point(2, 25);
            this.lblLaunchCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblLaunchCount.Name = "lblLaunchCount";
            this.lblLaunchCount.Size = new System.Drawing.Size(738, 36);
            this.lblLaunchCount.TabIndex = 1;
            this.lblLaunchCount.Text = "Select logs from the right list or remove selected log from the left list:";
            // 
            // XtraUCWindowsEventLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "XtraUCWindowsEventLogs";
            this.Size = new System.Drawing.Size(742, 486);
            this.Load += new System.EventHandler(this.XtraUCWindowsEventLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstAvailable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.ListBoxControl lstSelected;
        private DevExpress.XtraEditors.SimpleButton btnRemove;
        private DevExpress.XtraEditors.ListBoxControl lstAvailable;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl lblLaunchCount;
    }
}
