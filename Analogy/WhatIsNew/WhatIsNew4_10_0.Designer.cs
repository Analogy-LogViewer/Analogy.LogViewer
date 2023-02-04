namespace Analogy.WhatIsNew
{
    partial class WhatIsNew4_10_0
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
            this.gcImprovements = new DevExpress.XtraEditors.GroupControl();
            this.Issue1552 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.Issue1551 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.Issue1495 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.Issue1538 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.gcBugs = new DevExpress.XtraEditors.GroupControl();
            this.Bug1537 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcImprovements)).BeginInit();
            this.gcImprovements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBugs)).BeginInit();
            this.gcBugs.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcImprovements
            // 
            this.gcImprovements.Controls.Add(this.Issue1552);
            this.gcImprovements.Controls.Add(this.Issue1551);
            this.gcImprovements.Controls.Add(this.Issue1495);
            this.gcImprovements.Controls.Add(this.Issue1538);
            this.gcImprovements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcImprovements.Location = new System.Drawing.Point(0, 75);
            this.gcImprovements.Name = "gcImprovements";
            this.gcImprovements.Size = new System.Drawing.Size(789, 387);
            this.gcImprovements.TabIndex = 7;
            this.gcImprovements.Text = "Improvements / Changes";
            // 
            // Issue1552
            // 
            this.Issue1552.Dock = System.Windows.Forms.DockStyle.Top;
            this.Issue1552.Location = new System.Drawing.Point(2, 106);
            this.Issue1552.Name = "Issue1552";
            this.Issue1552.Padding = new System.Windows.Forms.Padding(5);
            this.Issue1552.Size = new System.Drawing.Size(240, 26);
            this.Issue1552.TabIndex = 16;
            this.Issue1552.Text = "<href=https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues/1552>reverse " +
    "connect/disconnect icons #1552</href>";
            this.Issue1552.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenGithubIssue);
            // 
            // Issue1551
            // 
            this.Issue1551.Dock = System.Windows.Forms.DockStyle.Top;
            this.Issue1551.Location = new System.Drawing.Point(2, 80);
            this.Issue1551.Name = "Issue1551";
            this.Issue1551.Padding = new System.Windows.Forms.Padding(5);
            this.Issue1551.Size = new System.Drawing.Size(218, 26);
            this.Issue1551.TabIndex = 15;
            this.Issue1551.Text = "<href=https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues/1551>Add NET7" +
    " Target Framework #1551</href>";
            this.Issue1551.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenGithubIssue);
            // 
            // Issue1495
            // 
            this.Issue1495.Dock = System.Windows.Forms.DockStyle.Top;
            this.Issue1495.Location = new System.Drawing.Point(2, 54);
            this.Issue1495.Name = "Issue1495";
            this.Issue1495.Padding = new System.Windows.Forms.Padding(5);
            this.Issue1495.Size = new System.Drawing.Size(299, 26);
            this.Issue1495.TabIndex = 14;
            this.Issue1495.Text = "<href=https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues/1495>Reduce n" +
    "umber of builds due to low usage. #1495</href>";
            this.Issue1495.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenGithubIssue);
            // 
            // Issue1538
            // 
            this.Issue1538.Dock = System.Windows.Forms.DockStyle.Top;
            this.Issue1538.Location = new System.Drawing.Point(2, 28);
            this.Issue1538.Name = "Issue1538";
            this.Issue1538.Padding = new System.Windows.Forms.Padding(5);
            this.Issue1538.Size = new System.Drawing.Size(247, 26);
            this.Issue1538.TabIndex = 13;
            this.Issue1538.Text = "<href=https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues/1538>[Improve" +
    "ments] lazy init providers #1538</href>";
            this.Issue1538.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenGithubIssue);
            // 
            // gcBugs
            // 
            this.gcBugs.Controls.Add(this.Bug1537);
            this.gcBugs.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBugs.Location = new System.Drawing.Point(0, 0);
            this.gcBugs.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.gcBugs.Name = "gcBugs";
            this.gcBugs.Size = new System.Drawing.Size(789, 75);
            this.gcBugs.TabIndex = 6;
            this.gcBugs.Text = "Bug Fixes";
            // 
            // Bug1537
            // 
            this.Bug1537.Dock = System.Windows.Forms.DockStyle.Top;
            this.Bug1537.Location = new System.Drawing.Point(2, 28);
            this.Bug1537.Name = "Bug1537";
            this.Bug1537.Padding = new System.Windows.Forms.Padding(5);
            this.Bug1537.Size = new System.Drawing.Size(658, 26);
            this.Bug1537.TabIndex = 21;
            this.Bug1537.Text = "<href=https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues/1537>[Real Ti" +
    "me providers] closing the application does not call StopReceiving unless the tab" +
    " is closed manually #1537</href>";
            this.Bug1537.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenGithubIssue);
            // 
            // WhatIsNew4_10_0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcImprovements);
            this.Controls.Add(this.gcBugs);
            this.Name = "WhatIsNew4_10_0";
            this.Size = new System.Drawing.Size(789, 462);
            ((System.ComponentModel.ISupportInitialize)(this.gcImprovements)).EndInit();
            this.gcImprovements.ResumeLayout(false);
            this.gcImprovements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBugs)).EndInit();
            this.gcBugs.ResumeLayout(false);
            this.gcBugs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl gcBugs;
        private DevExpress.XtraEditors.GroupControl gcImprovements;
        private DevExpress.XtraEditors.HyperlinkLabelControl Issue1538;
        private DevExpress.XtraEditors.HyperlinkLabelControl Issue1495;
        private DevExpress.XtraEditors.HyperlinkLabelControl Issue1552;
        private DevExpress.XtraEditors.HyperlinkLabelControl Issue1551;
        private DevExpress.XtraEditors.HyperlinkLabelControl Bug1537;
    }
}
