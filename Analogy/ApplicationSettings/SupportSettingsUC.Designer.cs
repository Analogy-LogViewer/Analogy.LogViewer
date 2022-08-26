
namespace Analogy.ApplicationSettings
{
    partial class SupportSettingsUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupportSettingsUC));
            this.lblPaypal = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblBinance = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.hlKofi = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblGithubSponsor = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.SuspendLayout();
            // 
            // lblPaypal
            // 
            this.lblPaypal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPaypal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPaypal.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblPaypal.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPaypal.ImageOptions.Image = global::Analogy.Properties.Resources.paypal64;
            this.lblPaypal.Location = new System.Drawing.Point(0, 38);
            this.lblPaypal.Name = "lblPaypal";
            this.lblPaypal.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaypal.ShowToolTips = false;
            this.lblPaypal.Size = new System.Drawing.Size(620, 68);
            this.lblPaypal.TabIndex = 13;
            this.lblPaypal.Text = resources.GetString("lblPaypal.Text");
            this.lblPaypal.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenLink);
            // 
            // lblBinance
            // 
            this.lblBinance.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBinance.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBinance.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblBinance.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBinance.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblBinance.ImageOptions.Image")));
            this.lblBinance.Location = new System.Drawing.Point(0, 175);
            this.lblBinance.Name = "lblBinance";
            this.lblBinance.Padding = new System.Windows.Forms.Padding(5);
            this.lblBinance.ShowToolTips = false;
            this.lblBinance.Size = new System.Drawing.Size(620, 68);
            this.lblBinance.TabIndex = 14;
            this.lblBinance.Text = "<href=https://www.binance.com/en/register?ref=V8P114PE>Trade CryptoCurrency with " +
    "5% cashback on your fees</href>";
            this.lblBinance.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenLink);
            // 
            // hlKofi
            // 
            this.hlKofi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.hlKofi.Dock = System.Windows.Forms.DockStyle.Top;
            this.hlKofi.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.hlKofi.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hlKofi.ImageOptions.Image = global::Analogy.Properties.Resources.ko_fi_logo_blue_32x32;
            this.hlKofi.Location = new System.Drawing.Point(0, 106);
            this.hlKofi.Name = "hlKofi";
            this.hlKofi.Padding = new System.Windows.Forms.Padding(5);
            this.hlKofi.ShowToolTips = false;
            this.hlKofi.Size = new System.Drawing.Size(620, 69);
            this.hlKofi.TabIndex = 15;
            this.hlKofi.Text = "<href=https://ko-fi.com/F1F77IVQT>Buy me a Coffee</href>";
            this.hlKofi.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenLink);
            // 
            // lblGithubSponsor
            // 
            this.lblGithubSponsor.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblGithubSponsor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGithubSponsor.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblGithubSponsor.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGithubSponsor.ImageOptions.Image = global::Analogy.Properties.Resources.heart32x32;
            this.lblGithubSponsor.Location = new System.Drawing.Point(0, 0);
            this.lblGithubSponsor.Name = "lblGithubSponsor";
            this.lblGithubSponsor.Padding = new System.Windows.Forms.Padding(5);
            this.lblGithubSponsor.ShowToolTips = false;
            this.lblGithubSponsor.Size = new System.Drawing.Size(620, 38);
            this.lblGithubSponsor.TabIndex = 16;
            this.lblGithubSponsor.Text = "<href=https://github.com/sponsors/LiorBanai>Support the project with GithHub spon" +
    "sor</href>\r\n";
            this.lblGithubSponsor.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenLink);
            // 
            // SupportSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBinance);
            this.Controls.Add(this.hlKofi);
            this.Controls.Add(this.lblPaypal);
            this.Controls.Add(this.lblGithubSponsor);
            this.Name = "SupportSettingsUC";
            this.Size = new System.Drawing.Size(620, 446);
            this.Load += new System.EventHandler(this.SupportSettings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.HyperlinkLabelControl lblPaypal;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblBinance;
        private DevExpress.XtraEditors.HyperlinkLabelControl hlKofi;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblGithubSponsor;
    }
}
