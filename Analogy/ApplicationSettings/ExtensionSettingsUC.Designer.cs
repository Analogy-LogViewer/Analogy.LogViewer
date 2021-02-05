
namespace Analogy.ApplicationSettings
{
    partial class ExtensionSettingsUC
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
            this.chkLstItemExtensions = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstItemExtensions)).BeginInit();
            this.SuspendLayout();
            // 
            // chkLstItemExtensions
            // 
            this.chkLstItemExtensions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLstItemExtensions.Location = new System.Drawing.Point(0, 36);
            this.chkLstItemExtensions.Name = "chkLstItemExtensions";
            this.chkLstItemExtensions.Size = new System.Drawing.Size(715, 413);
            this.chkLstItemExtensions.TabIndex = 14;
            // 
            // labelControl12
            // 
            this.labelControl12.AutoEllipsis = true;
            this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl12.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl12.Location = new System.Drawing.Point(0, 0);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Padding = new System.Windows.Forms.Padding(10);
            this.labelControl12.Size = new System.Drawing.Size(715, 36);
            this.labelControl12.TabIndex = 13;
            this.labelControl12.Text = "Load the following Extensions:";
            // 
            // ExtensionSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.chkLstItemExtensions);
            this.Controls.Add(this.labelControl12);
            this.Name = "ExtensionSettingsUC";
            this.Size = new System.Drawing.Size(715, 449);
            this.Load += new System.EventHandler(this.ExtensionSettingsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkLstItemExtensions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl chkLstItemExtensions;
        private DevExpress.XtraEditors.LabelControl labelControl12;
    }
}
