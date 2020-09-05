namespace Analogy.WhatIsNew
{
    partial class WhatIsNew4_2_8
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.issue418 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.issue420 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.issue417 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.issue415 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.highlight415 = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(789, 357);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.highlight415);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(782, 323);
            this.xtraTabPage1.Text = "V4.2.8 Highlight / Changes";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.issue415);
            this.xtraTabPage2.Controls.Add(this.issue417);
            this.xtraTabPage2.Controls.Add(this.issue418);
            this.xtraTabPage2.Controls.Add(this.issue420);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(782, 323);
            this.xtraTabPage2.Text = "Github Issues";
            // 
            // issue418
            // 
            this.issue418.Dock = System.Windows.Forms.DockStyle.Top;
            this.issue418.Location = new System.Drawing.Point(0, 26);
            this.issue418.Name = "issue418";
            this.issue418.Padding = new System.Windows.Forms.Padding(5);
            this.issue418.Size = new System.Drawing.Size(441, 26);
            this.issue418.TabIndex = 0;
            this.issue418.Text = "<href=https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues/418>[Debuggin" +
    "g] handle Could not load file or assembly xxxx.resources.dll #418</href>";
            this.issue418.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenGithubIssue);
            // 
            // issue420
            // 
            this.issue420.Dock = System.Windows.Forms.DockStyle.Top;
            this.issue420.Location = new System.Drawing.Point(0, 0);
            this.issue420.Name = "issue420";
            this.issue420.Padding = new System.Windows.Forms.Padding(5);
            this.issue420.Size = new System.Drawing.Size(300, 26);
            this.issue420.TabIndex = 1;
            this.issue420.Text = "<href=https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues/420>Add Show " +
    "what is new at start of application #420</href>";
            this.issue420.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenGithubIssue);
            // 
            // issue417
            // 
            this.issue417.Dock = System.Windows.Forms.DockStyle.Top;
            this.issue417.Location = new System.Drawing.Point(0, 52);
            this.issue417.Name = "issue417";
            this.issue417.Padding = new System.Windows.Forms.Padding(5);
            this.issue417.Size = new System.Drawing.Size(427, 26);
            this.issue417.TabIndex = 2;
            this.issue417.Text = "<href=https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues/417>[Filterin" +
    "g] Message layout does not affect view and keeps resetting #417</href>";
            this.issue417.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenGithubIssue);
            // 
            // issue415
            // 
            this.issue415.Dock = System.Windows.Forms.DockStyle.Top;
            this.issue415.Location = new System.Drawing.Point(0, 78);
            this.issue415.Name = "issue415";
            this.issue415.Padding = new System.Windows.Forms.Padding(5);
            this.issue415.Size = new System.Drawing.Size(464, 26);
            this.issue415.TabIndex = 3;
            this.issue415.Text = "<href=https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues/415>Add optio" +
    "n to select multi log levels (checkboxes instead of radio buttons) #415</href>";
            this.issue415.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenGithubIssue);
            // 
            // highlight415
            // 
            this.highlight415.Dock = System.Windows.Forms.DockStyle.Top;
            this.highlight415.Location = new System.Drawing.Point(0, 0);
            this.highlight415.Name = "highlight415";
            this.highlight415.Padding = new System.Windows.Forms.Padding(5);
            this.highlight415.Size = new System.Drawing.Size(464, 26);
            this.highlight415.TabIndex = 4;
            this.highlight415.Text = "<href=https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues/415>Add optio" +
    "n to select multi log levels (checkboxes instead of radio buttons) #415</href>";
            this.highlight415.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenGithubIssue);
            // 
            // WhatIsNew4_2_8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "WhatIsNew4_2_8";
            this.Size = new System.Drawing.Size(789, 357);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.HyperlinkLabelControl issue418;
        private DevExpress.XtraEditors.HyperlinkLabelControl issue415;
        private DevExpress.XtraEditors.HyperlinkLabelControl issue417;
        private DevExpress.XtraEditors.HyperlinkLabelControl issue420;
        private DevExpress.XtraEditors.HyperlinkLabelControl highlight415;
    }
}
