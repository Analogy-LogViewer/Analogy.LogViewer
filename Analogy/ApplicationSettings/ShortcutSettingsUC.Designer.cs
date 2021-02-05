
namespace Analogy.ApplicationSettings
{
    partial class ShortcutSettingsUC
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
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(14, 9);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(445, 16);
            this.labelControl10.TabIndex = 13;
            this.labelControl10.Text = "Show/Hide Selected message detailed information: Ctrl + D or Plus/Minus key";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 137);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(284, 16);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Toggle on/off warning log level filtering: ALT + W";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 105);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(317, 16);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Toggle on/off Error + Critical log level filtering: ALT + E";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 70);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(219, 16);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Go to exclude filter textbox: SHIFT + F";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 38);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(201, 16);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Go to include filter textbox: Ctrl + F";
            // 
            // ShortcutSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "ShortcutSettingsUC";
            this.Size = new System.Drawing.Size(732, 419);
            this.Load += new System.EventHandler(this.ShortcutSettingsUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
