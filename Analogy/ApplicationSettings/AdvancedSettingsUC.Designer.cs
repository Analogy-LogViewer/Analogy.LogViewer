namespace Analogy.ApplicationSettings
{
    partial class AdvancedSettingsUC
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
            this.gcAdvancedSettings = new DevExpress.XtraEditors.GroupControl();
            this.tsAdvancedModeAdditionalColumns = new DevExpress.XtraEditors.ToggleSwitch();
            this.tsAdvancedModeRawSQLFiltering = new DevExpress.XtraEditors.ToggleSwitch();
            this.tsEnabledAdvancedSettings = new DevExpress.XtraEditors.ToggleSwitch();
            this.tsLinux = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.gcAdvancedSettings)).BeginInit();
            this.gcAdvancedSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsAdvancedModeAdditionalColumns.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsAdvancedModeRawSQLFiltering.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsEnabledAdvancedSettings.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsLinux.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcAdvancedSettings
            // 
            this.gcAdvancedSettings.Controls.Add(this.tsLinux);
            this.gcAdvancedSettings.Controls.Add(this.tsAdvancedModeAdditionalColumns);
            this.gcAdvancedSettings.Controls.Add(this.tsAdvancedModeRawSQLFiltering);
            this.gcAdvancedSettings.Controls.Add(this.tsEnabledAdvancedSettings);
            this.gcAdvancedSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAdvancedSettings.Location = new System.Drawing.Point(0, 0);
            this.gcAdvancedSettings.Margin = new System.Windows.Forms.Padding(10);
            this.gcAdvancedSettings.Name = "gcAdvancedSettings";
            this.gcAdvancedSettings.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.gcAdvancedSettings.Size = new System.Drawing.Size(766, 501);
            this.gcAdvancedSettings.TabIndex = 5;
            this.gcAdvancedSettings.Text = "Advanced Features/Mode";
            // 
            // tsAdvancedModeAdditionalColumns
            // 
            this.tsAdvancedModeAdditionalColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsAdvancedModeAdditionalColumns.Location = new System.Drawing.Point(71, 61);
            this.tsAdvancedModeAdditionalColumns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsAdvancedModeAdditionalColumns.Name = "tsAdvancedModeAdditionalColumns";
            this.tsAdvancedModeAdditionalColumns.Properties.OffText = "Show Additional Columns for filtering messages";
            this.tsAdvancedModeAdditionalColumns.Properties.OnText = "Show Additional Columns for filtering messages";
            this.tsAdvancedModeAdditionalColumns.Size = new System.Drawing.Size(678, 24);
            this.tsAdvancedModeAdditionalColumns.TabIndex = 7;
            // 
            // tsAdvancedModeRawSQLFiltering
            // 
            this.tsAdvancedModeRawSQLFiltering.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsAdvancedModeRawSQLFiltering.Location = new System.Drawing.Point(70, 93);
            this.tsAdvancedModeRawSQLFiltering.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsAdvancedModeRawSQLFiltering.Name = "tsAdvancedModeRawSQLFiltering";
            this.tsAdvancedModeRawSQLFiltering.Properties.OffText = "Raw SQL filtering Disabled";
            this.tsAdvancedModeRawSQLFiltering.Properties.OnText = "Raw SQL filtering Enabled";
            this.tsAdvancedModeRawSQLFiltering.Size = new System.Drawing.Size(678, 24);
            this.tsAdvancedModeRawSQLFiltering.TabIndex = 3;
            // 
            // tsEnabledAdvancedSettings
            // 
            this.tsEnabledAdvancedSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsEnabledAdvancedSettings.Location = new System.Drawing.Point(5, 30);
            this.tsEnabledAdvancedSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsEnabledAdvancedSettings.Name = "tsEnabledAdvancedSettings";
            this.tsEnabledAdvancedSettings.Properties.OffText = "Advanced features Disabled";
            this.tsEnabledAdvancedSettings.Properties.OnText = "Advanced features Enabled";
            this.tsEnabledAdvancedSettings.Size = new System.Drawing.Size(743, 24);
            this.tsEnabledAdvancedSettings.TabIndex = 1;
            // 
            // tsLinux
            // 
            this.tsLinux.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsLinux.Location = new System.Drawing.Point(5, 137);
            this.tsLinux.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsLinux.Name = "tsLinux";
            this.tsLinux.Properties.OffText = "Don\'t Process Linux Style Text Formatting";
            this.tsLinux.Properties.OnText = "Process Linux Style Text Formating";
            this.tsLinux.Size = new System.Drawing.Size(743, 24);
            this.tsLinux.TabIndex = 8;
            // 
            // AdvancedSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcAdvancedSettings);
            this.Name = "AdvancedSettingsUC";
            this.Size = new System.Drawing.Size(766, 501);
            this.Load += new System.EventHandler(this.AdvancedSettingsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcAdvancedSettings)).EndInit();
            this.gcAdvancedSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tsAdvancedModeAdditionalColumns.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsAdvancedModeRawSQLFiltering.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsEnabledAdvancedSettings.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsLinux.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcAdvancedSettings;
        private DevExpress.XtraEditors.ToggleSwitch tsAdvancedModeAdditionalColumns;
        private DevExpress.XtraEditors.ToggleSwitch tsAdvancedModeRawSQLFiltering;
        private DevExpress.XtraEditors.ToggleSwitch tsEnabledAdvancedSettings;
        private DevExpress.XtraEditors.ToggleSwitch tsLinux;
    }
}
