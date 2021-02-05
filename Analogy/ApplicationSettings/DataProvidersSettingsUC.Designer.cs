
namespace Analogy.ApplicationSettings
{
    partial class DataProvidersSettingsUC
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
            this.chkLstDataProviderStatus = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.tsRememberLastOpenedDataProvider = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstDataProviderStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsRememberLastOpenedDataProvider.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chkLstDataProviderStatus
            // 
            this.chkLstDataProviderStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLstDataProviderStatus.ItemHeight = 62;
            this.chkLstDataProviderStatus.Location = new System.Drawing.Point(0, 64);
            this.chkLstDataProviderStatus.Name = "chkLstDataProviderStatus";
            this.chkLstDataProviderStatus.Size = new System.Drawing.Size(734, 474);
            this.chkLstDataProviderStatus.TabIndex = 15;
            // 
            // labelControl7
            // 
            this.labelControl7.AutoEllipsis = true;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl7.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl7.Location = new System.Drawing.Point(0, 28);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Padding = new System.Windows.Forms.Padding(3, 10, 10, 10);
            this.labelControl7.Size = new System.Drawing.Size(734, 36);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "Status (enable/ disabled) of data providers. Re-enabling  a provider will take af" +
    "fect after restarting of the application";
            // 
            // tsRememberLastOpenedDataProvider
            // 
            this.tsRememberLastOpenedDataProvider.Dock = System.Windows.Forms.DockStyle.Top;
            this.tsRememberLastOpenedDataProvider.Location = new System.Drawing.Point(0, 0);
            this.tsRememberLastOpenedDataProvider.Margin = new System.Windows.Forms.Padding(5);
            this.tsRememberLastOpenedDataProvider.Name = "tsRememberLastOpenedDataProvider";
            this.tsRememberLastOpenedDataProvider.Properties.OffText = "Don\'t remember last opened Data provider on startup";
            this.tsRememberLastOpenedDataProvider.Properties.OnText = "Remember last opened Data provider on startup and switch to it after restart";
            this.tsRememberLastOpenedDataProvider.Size = new System.Drawing.Size(734, 28);
            this.tsRememberLastOpenedDataProvider.TabIndex = 14;
            // 
            // DataProvidersSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.chkLstDataProviderStatus);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.tsRememberLastOpenedDataProvider);
            this.Name = "DataProvidersSettingsUC";
            this.Size = new System.Drawing.Size(734, 538);
            this.Load += new System.EventHandler(this.DataProvidersSettingsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkLstDataProviderStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsRememberLastOpenedDataProvider.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl chkLstDataProviderStatus;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ToggleSwitch tsRememberLastOpenedDataProvider;
    }
}
