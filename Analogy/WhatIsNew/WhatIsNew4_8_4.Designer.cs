namespace Analogy.WhatIsNew
{
    partial class WhatIsNew4_8_4
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
            this.xtcV4_8_0 = new DevExpress.XtraTab.XtraTabControl();
            this.xtPageHighlight = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.highlight1211 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtPageIssues = new DevExpress.XtraTab.XtraTabPage();
            this.gcImprovements = new DevExpress.XtraEditors.GroupControl();
            this.Issue1211 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.gcBugs = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.highlight1208 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.Issue1208 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtcV4_8_0)).BeginInit();
            this.xtcV4_8_0.SuspendLayout();
            this.xtPageHighlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.xtPageIssues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcImprovements)).BeginInit();
            this.gcImprovements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBugs)).BeginInit();
            this.gcBugs.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtcV4_8_0
            // 
            this.xtcV4_8_0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtcV4_8_0.Location = new System.Drawing.Point(0, 0);
            this.xtcV4_8_0.Name = "xtcV4_8_0";
            this.xtcV4_8_0.SelectedTabPage = this.xtPageHighlight;
            this.xtcV4_8_0.Size = new System.Drawing.Size(789, 462);
            this.xtcV4_8_0.TabIndex = 2;
            this.xtcV4_8_0.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtPageHighlight,
            this.xtPageIssues});
            // 
            // xtPageHighlight
            // 
            this.xtPageHighlight.AutoScroll = true;
            this.xtPageHighlight.Controls.Add(this.groupControl2);
            this.xtPageHighlight.Controls.Add(this.groupControl1);
            this.xtPageHighlight.Name = "xtPageHighlight";
            this.xtPageHighlight.Size = new System.Drawing.Size(787, 432);
            this.xtPageHighlight.Text = "V4.8.4 Highlights / Changes";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.highlight1208);
            this.groupControl2.Controls.Add(this.highlight1211);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 197);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(787, 235);
            this.groupControl2.TabIndex = 11;
            this.groupControl2.Text = "Improvements / Changes";
            // 
            // highlight1211
            // 
            this.highlight1211.Dock = System.Windows.Forms.DockStyle.Top;
            this.highlight1211.Location = new System.Drawing.Point(2, 28);
            this.highlight1211.Name = "highlight1211";
            this.highlight1211.Padding = new System.Windows.Forms.Padding(5);
            this.highlight1211.Size = new System.Drawing.Size(278, 26);
            this.highlight1211.TabIndex = 7;
            this.highlight1211.Text = "<href=https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues/1211>[DevExpr" +
    "ess] Update version to V21.2.6 #1211</href>";
            this.highlight1211.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenGithubIssue);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(787, 197);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "Notice";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.AutoEllipsis = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(2, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(783, 154);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Inline Json Viewer in the message log grid\r\n\r\nUpgrade DevExpress Version to V21.2" +
    ".6\r\n\r\nBump Markdig from 0.27.0 to 0.28.0\r\n\r\nFixed some donation links and miscel" +
    "laneous links";
            // 
            // xtPageIssues
            // 
            this.xtPageIssues.AutoScroll = true;
            this.xtPageIssues.Controls.Add(this.gcImprovements);
            this.xtPageIssues.Controls.Add(this.gcBugs);
            this.xtPageIssues.Name = "xtPageIssues";
            this.xtPageIssues.Padding = new System.Windows.Forms.Padding(10);
            this.xtPageIssues.Size = new System.Drawing.Size(787, 432);
            this.xtPageIssues.Text = "Github Issues";
            // 
            // gcImprovements
            // 
            this.gcImprovements.Controls.Add(this.Issue1208);
            this.gcImprovements.Controls.Add(this.Issue1211);
            this.gcImprovements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcImprovements.Location = new System.Drawing.Point(10, 85);
            this.gcImprovements.Name = "gcImprovements";
            this.gcImprovements.Size = new System.Drawing.Size(767, 337);
            this.gcImprovements.TabIndex = 7;
            this.gcImprovements.Text = "Improvements / Changes";
            // 
            // Issue1211
            // 
            this.Issue1211.Dock = System.Windows.Forms.DockStyle.Top;
            this.Issue1211.Location = new System.Drawing.Point(2, 28);
            this.Issue1211.Name = "Issue1211";
            this.Issue1211.Padding = new System.Windows.Forms.Padding(5);
            this.Issue1211.Size = new System.Drawing.Size(278, 26);
            this.Issue1211.TabIndex = 13;
            this.Issue1211.Text = "<href=https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues/1211>[DevExpr" +
    "ess] Update version to V21.2.6 #1211</href>";
            this.Issue1211.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenGithubIssue);
            // 
            // gcBugs
            // 
            this.gcBugs.Controls.Add(this.labelControl2);
            this.gcBugs.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcBugs.Location = new System.Drawing.Point(10, 10);
            this.gcBugs.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.gcBugs.Name = "gcBugs";
            this.gcBugs.Size = new System.Drawing.Size(767, 75);
            this.gcBugs.TabIndex = 6;
            this.gcBugs.Text = "Bug Fixes";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl2.AutoEllipsis = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.Location = new System.Drawing.Point(2, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(763, 22);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "None";
            // 
            // highlight1208
            // 
            this.highlight1208.Dock = System.Windows.Forms.DockStyle.Top;
            this.highlight1208.Location = new System.Drawing.Point(2, 54);
            this.highlight1208.Name = "highlight1208";
            this.highlight1208.Padding = new System.Windows.Forms.Padding(5);
            this.highlight1208.Size = new System.Drawing.Size(293, 26);
            this.highlight1208.TabIndex = 8;
            this.highlight1208.Text = "<href=https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues/1208>Inline J" +
    "son Viewer in the message log grid #1208</href>";
            this.highlight1208.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenGithubIssue);
            // 
            // Issue1208
            // 
            this.Issue1208.Dock = System.Windows.Forms.DockStyle.Top;
            this.Issue1208.Location = new System.Drawing.Point(2, 54);
            this.Issue1208.Name = "Issue1208";
            this.Issue1208.Padding = new System.Windows.Forms.Padding(5);
            this.Issue1208.Size = new System.Drawing.Size(293, 26);
            this.Issue1208.TabIndex = 14;
            this.Issue1208.Text = "<href=https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues/1208>Inline J" +
    "son Viewer in the message log grid #1208</href>";
            this.Issue1208.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenGithubIssue);
            // 
            // WhatIsNew4_8_4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtcV4_8_0);
            this.Name = "WhatIsNew4_8_4";
            this.Size = new System.Drawing.Size(789, 462);
            ((System.ComponentModel.ISupportInitialize)(this.xtcV4_8_0)).EndInit();
            this.xtcV4_8_0.ResumeLayout(false);
            this.xtPageHighlight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.xtPageIssues.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcImprovements)).EndInit();
            this.gcImprovements.ResumeLayout(false);
            this.gcImprovements.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBugs)).EndInit();
            this.gcBugs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtcV4_8_0;
        private DevExpress.XtraTab.XtraTabPage xtPageHighlight;
        private DevExpress.XtraTab.XtraTabPage xtPageIssues;
        private DevExpress.XtraEditors.GroupControl gcBugs;
        private DevExpress.XtraEditors.GroupControl gcImprovements;
        private DevExpress.XtraEditors.HyperlinkLabelControl highlight1211;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.HyperlinkLabelControl Issue1211;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.HyperlinkLabelControl highlight1208;
        private DevExpress.XtraEditors.HyperlinkLabelControl Issue1208;
    }
}
