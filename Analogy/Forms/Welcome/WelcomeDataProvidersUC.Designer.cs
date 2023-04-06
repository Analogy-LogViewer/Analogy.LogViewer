namespace Analogy.Forms.Welcome
{
    partial class WelcomeDataProvidersUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeDataProvidersUC));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sbtnDataProvidersSettings = new DevExpress.XtraEditors.SimpleButton();
            this.hllcDataProviders = new DevExpress.XtraEditors.HyperlinkLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::Analogy.Properties.Resources.Providers;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1100, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 159);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(1100, 252);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = resources.GetString("labelControl1.Text");
            // 
            // sbtnDataProvidersSettings
            // 
            this.sbtnDataProvidersSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sbtnDataProvidersSettings.Location = new System.Drawing.Point(10, 560);
            this.sbtnDataProvidersSettings.Name = "sbtnDataProvidersSettings";
            this.sbtnDataProvidersSettings.Size = new System.Drawing.Size(149, 33);
            this.sbtnDataProvidersSettings.TabIndex = 3;
            this.sbtnDataProvidersSettings.Text = "Select Data Providers";
            this.sbtnDataProvidersSettings.Click += new System.EventHandler(this.sbtnDataProvidersSettings_Click);
            // 
            // hllcDataProviders
            // 
            this.hllcDataProviders.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hllcDataProviders.Appearance.Options.UseFont = true;
            this.hllcDataProviders.Location = new System.Drawing.Point(10, 512);
            this.hllcDataProviders.Name = "hllcDataProviders";
            this.hllcDataProviders.Size = new System.Drawing.Size(265, 28);
            this.hllcDataProviders.TabIndex = 4;
            this.hllcDataProviders.Text = "<href=https://github.com/Analogy-LogViewer/Analogy>List Of Data Providers (Github" +
    ")</href>";
            // 
            // WelcomeDataProvidersUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hllcDataProviders);
            this.Controls.Add(this.sbtnDataProvidersSettings);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "WelcomeDataProvidersUC";
            this.Size = new System.Drawing.Size(1100, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton sbtnDataProvidersSettings;
        private DevExpress.XtraEditors.HyperlinkLabelControl hllcDataProviders;
    }
}
