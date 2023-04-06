namespace Analogy.Forms.Welcome
{
    partial class WelcomeShareAndSupportUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeShareAndSupportUC));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.hlKofi = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblPaypal = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblGithubSponsor = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1100, 79);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.hlKofi);
            this.panelControl2.Controls.Add(this.lblPaypal);
            this.panelControl2.Controls.Add(this.lblGithubSponsor);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 79);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1100, 521);
            this.panelControl2.TabIndex = 1;
            // 
            // hlKofi
            // 
            this.hlKofi.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hlKofi.Appearance.Options.UseFont = true;
            this.hlKofi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.hlKofi.Dock = System.Windows.Forms.DockStyle.Top;
            this.hlKofi.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.hlKofi.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hlKofi.ImageOptions.Image = global::Analogy.Properties.Resources.ko_fi_logo_blue_32x32;
            this.hlKofi.Location = new System.Drawing.Point(2, 108);
            this.hlKofi.Name = "hlKofi";
            this.hlKofi.Padding = new System.Windows.Forms.Padding(5);
            this.hlKofi.ShowToolTips = false;
            this.hlKofi.Size = new System.Drawing.Size(1096, 69);
            this.hlKofi.TabIndex = 18;
            this.hlKofi.Text = "<href=https://ko-fi.com/F1F77IVQT>Buy me a Coffee</href>";
            this.hlKofi.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenLink);
            // 
            // lblPaypal
            // 
            this.lblPaypal.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPaypal.Appearance.Options.UseFont = true;
            this.lblPaypal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPaypal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPaypal.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblPaypal.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPaypal.ImageOptions.Image = global::Analogy.Properties.Resources.paypal64;
            this.lblPaypal.Location = new System.Drawing.Point(2, 40);
            this.lblPaypal.Name = "lblPaypal";
            this.lblPaypal.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaypal.ShowToolTips = false;
            this.lblPaypal.Size = new System.Drawing.Size(1096, 68);
            this.lblPaypal.TabIndex = 17;
            this.lblPaypal.Text = resources.GetString("lblPaypal.Text");
            this.lblPaypal.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenLink);
            // 
            // lblGithubSponsor
            // 
            this.lblGithubSponsor.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblGithubSponsor.Appearance.Options.UseFont = true;
            this.lblGithubSponsor.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblGithubSponsor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGithubSponsor.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblGithubSponsor.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGithubSponsor.ImageOptions.Image = global::Analogy.Properties.Resources.heart32x32;
            this.lblGithubSponsor.Location = new System.Drawing.Point(2, 2);
            this.lblGithubSponsor.Name = "lblGithubSponsor";
            this.lblGithubSponsor.Padding = new System.Windows.Forms.Padding(5);
            this.lblGithubSponsor.ShowToolTips = false;
            this.lblGithubSponsor.Size = new System.Drawing.Size(1096, 38);
            this.lblGithubSponsor.TabIndex = 19;
            this.lblGithubSponsor.Text = "<href=https://github.com/sponsors/LiorBanai>Support the project with GithHub spon" +
    "sor</href>\r\n";
            this.lblGithubSponsor.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenLink);
            // 
            // WelcomeShareAndSupportUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "WelcomeShareAndSupportUC";
            this.Size = new System.Drawing.Size(1100, 600);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.HyperlinkLabelControl hlKofi;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblPaypal;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblGithubSponsor;
    }
}
