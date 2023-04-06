namespace Analogy.Forms.Welcome
{
    partial class WelcomeExtensionsUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeExtensionsUC));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sbtnExtensionsSettings = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(1100, 196);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = resources.GetString("labelControl1.Text");
            // 
            // sbtnExtensionsSettings
            // 
            this.sbtnExtensionsSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sbtnExtensionsSettings.Location = new System.Drawing.Point(10, 560);
            this.sbtnExtensionsSettings.Name = "sbtnExtensionsSettings";
            this.sbtnExtensionsSettings.Size = new System.Drawing.Size(149, 33);
            this.sbtnExtensionsSettings.TabIndex = 4;
            this.sbtnExtensionsSettings.Text = "Extensions";
            this.sbtnExtensionsSettings.Click += new System.EventHandler(this.sbtnExtensionsSettings_Click);
            // 
            // WelcomeExtensionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sbtnExtensionsSettings);
            this.Controls.Add(this.labelControl1);
            this.Name = "WelcomeExtensionsUC";
            this.Size = new System.Drawing.Size(1100, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton sbtnExtensionsSettings;
    }
}
