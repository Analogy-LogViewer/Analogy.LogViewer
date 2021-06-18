
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
            this.SuspendLayout();
            // 
            // lblPaypal
            // 
            this.lblPaypal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaypal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPaypal.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblPaypal.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPaypal.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblPaypal.ImageOptions.Image")));
            this.lblPaypal.Location = new System.Drawing.Point(3, 15);
            this.lblPaypal.Name = "lblPaypal";
            this.lblPaypal.Padding = new System.Windows.Forms.Padding(5);
            this.lblPaypal.Size = new System.Drawing.Size(604, 68);
            this.lblPaypal.TabIndex = 13;
            this.lblPaypal.Text = "<href=https://www.paypal.com/paypalme/liorbanai>Support the project with small Pa" +
    "yPal donation</href>";
            this.lblPaypal.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenLink);
            // 
            // lblBinance
            // 
            this.lblBinance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBinance.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBinance.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblBinance.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBinance.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblBinance.ImageOptions.Image")));
            this.lblBinance.Location = new System.Drawing.Point(8, 89);
            this.lblBinance.Name = "lblBinance";
            this.lblBinance.Padding = new System.Windows.Forms.Padding(5);
            this.lblBinance.Size = new System.Drawing.Size(604, 68);
            this.lblBinance.TabIndex = 14;
            this.lblBinance.Text = "<href=https://www.binance.com/en/register?ref=V8P114PE>Trade CryptoCurrency with " +
    "5% cashback on your fees</href>";
            this.lblBinance.HyperlinkClick += new DevExpress.Utils.HyperlinkClickEventHandler(this.OpenLink);
            // 
            // SupportSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblBinance);
            this.Controls.Add(this.lblPaypal);
            this.Name = "SupportSettingsUC";
            this.Size = new System.Drawing.Size(620, 446);
            this.Load += new System.EventHandler(this.SupportSettings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.HyperlinkLabelControl lblPaypal;
        private DevExpress.XtraEditors.HyperlinkLabelControl lblBinance;
    }
}
