
namespace Analogy.ApplicationSettings
{
    partial class UpdateSettingsUC
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
            this.gcIntervals = new DevExpress.XtraEditors.GroupControl();
            this.lblDisableUpdates = new DevExpress.XtraEditors.LabelControl();
            this.cbUpdates = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblUpdates = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcIntervals)).BeginInit();
            this.gcIntervals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbUpdates.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcIntervals
            // 
            this.gcIntervals.Controls.Add(this.lblDisableUpdates);
            this.gcIntervals.Controls.Add(this.cbUpdates);
            this.gcIntervals.Controls.Add(this.lblUpdates);
            this.gcIntervals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcIntervals.Location = new System.Drawing.Point(0, 0);
            this.gcIntervals.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcIntervals.Name = "gcIntervals";
            this.gcIntervals.Size = new System.Drawing.Size(941, 403);
            this.gcIntervals.TabIndex = 7;
            this.gcIntervals.Text = "General";
            // 
            // lblDisableUpdates
            // 
            this.lblDisableUpdates.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblDisableUpdates.Appearance.Options.UseForeColor = true;
            this.lblDisableUpdates.Location = new System.Drawing.Point(5, 69);
            this.lblDisableUpdates.Name = "lblDisableUpdates";
            this.lblDisableUpdates.Size = new System.Drawing.Size(297, 16);
            this.lblDisableUpdates.TabIndex = 14;
            this.lblDisableUpdates.Text = "Updates are disabled due to data provider overrides";
            this.lblDisableUpdates.Visible = false;
            // 
            // cbUpdates
            // 
            this.cbUpdates.Location = new System.Drawing.Point(322, 35);
            this.cbUpdates.Name = "cbUpdates";
            this.cbUpdates.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUpdates.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbUpdates.Size = new System.Drawing.Size(198, 22);
            this.cbUpdates.TabIndex = 13;
            // 
            // lblUpdates
            // 
            this.lblUpdates.Location = new System.Drawing.Point(5, 38);
            this.lblUpdates.Name = "lblUpdates";
            this.lblUpdates.Size = new System.Drawing.Size(235, 16);
            this.lblUpdates.TabIndex = 12;
            this.lblUpdates.Text = "Choose interval for checking for updates:";
            // 
            // UpdateSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcIntervals);
            this.Name = "UpdateSettingsUC";
            this.Size = new System.Drawing.Size(941, 403);
            this.Load += new System.EventHandler(this.UpdateSettingsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcIntervals)).EndInit();
            this.gcIntervals.ResumeLayout(false);
            this.gcIntervals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbUpdates.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcIntervals;
        private DevExpress.XtraEditors.LabelControl lblDisableUpdates;
        private DevExpress.XtraEditors.ComboBoxEdit cbUpdates;
        private DevExpress.XtraEditors.LabelControl lblUpdates;
    }
}
