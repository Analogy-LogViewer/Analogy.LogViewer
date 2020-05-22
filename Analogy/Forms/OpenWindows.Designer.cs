namespace Analogy.Forms
{
    partial class OpenWindows
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCombineSelected = new DevExpress.XtraEditors.SimpleButton();
            this.chklistLogs = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.chklistLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCombineSelected
            // 
            this.btnCombineSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCombineSelected.Location = new System.Drawing.Point(607, 285);
            this.btnCombineSelected.Name = "btnCombineSelected";
            this.btnCombineSelected.Size = new System.Drawing.Size(152, 39);
            this.btnCombineSelected.TabIndex = 0;
            this.btnCombineSelected.Text = "Combine Selected";
            this.btnCombineSelected.Click += new System.EventHandler(this.btnCombineSelected_Click);
            // 
            // chklistLogs
            // 
            this.chklistLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chklistLogs.Location = new System.Drawing.Point(8, 2);
            this.chklistLogs.Name = "chklistLogs";
            this.chklistLogs.Size = new System.Drawing.Size(749, 277);
            this.chklistLogs.TabIndex = 1;
            // 
            // OpenWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 326);
            this.Controls.Add(this.chklistLogs);
            this.Controls.Add(this.btnCombineSelected);
            this.Name = "OpenWindows";
            this.Text = "Open Log Windows";
            this.Load += new System.EventHandler(this.OpenWindows_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chklistLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCombineSelected;
        private DevExpress.XtraEditors.CheckedListBoxControl chklistLogs;
    }
}