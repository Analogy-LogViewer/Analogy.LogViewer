
namespace Analogy.ApplicationSettings
{
    partial class DebuggingSettingsUC
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
            this.tsEnableFirstChanceException = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.tsEnableFirstChanceException.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tsEnableFirstChanceException
            // 
            this.tsEnableFirstChanceException.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsEnableFirstChanceException.EditValue = true;
            this.tsEnableFirstChanceException.Location = new System.Drawing.Point(3, 17);
            this.tsEnableFirstChanceException.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsEnableFirstChanceException.Name = "tsEnableFirstChanceException";
            this.tsEnableFirstChanceException.Properties.OffText = "First Chance Exception logging is disabled";
            this.tsEnableFirstChanceException.Properties.OnText = "First Chance Exception logging is enabled";
            this.tsEnableFirstChanceException.Size = new System.Drawing.Size(612, 28);
            this.tsEnableFirstChanceException.TabIndex = 4;
            // 
            // DebuggingSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tsEnableFirstChanceException);
            this.Name = "DebuggingSettingsUC";
            this.Size = new System.Drawing.Size(618, 243);
            this.Load += new System.EventHandler(this.DebuggingSettingsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tsEnableFirstChanceException.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ToggleSwitch tsEnableFirstChanceException;
    }
}
