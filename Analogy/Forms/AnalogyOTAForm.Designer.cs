namespace Analogy
{
    partial class AnalogyOTAForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalogyOTAForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sbtnInit = new DevExpress.XtraEditors.SimpleButton();
            this.cbShares = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbShares);
            this.groupBox1.Controls.Add(this.sbtnInit);
            this.groupBox1.Location = new System.Drawing.Point(13, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Analogy Shareable Component";
            // 
            // sbtnInit
            // 
            this.sbtnInit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnInit.Location = new System.Drawing.Point(671, 22);
            this.sbtnInit.Name = "sbtnInit";
            this.sbtnInit.Size = new System.Drawing.Size(163, 40);
            this.sbtnInit.TabIndex = 1;
            this.sbtnInit.Text = "initialize Component";
            // 
            // cbShares
            // 
            this.cbShares.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShares.FormattingEnabled = true;
            this.cbShares.Location = new System.Drawing.Point(20, 31);
            this.cbShares.Name = "cbShares";
            this.cbShares.Size = new System.Drawing.Size(636, 24);
            this.cbShares.TabIndex = 2;
            // 
            // AnalogyOTAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 455);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnalogyOTAForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Share Logs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnalogyOTAForm_FormClosing);
            this.Load += new System.EventHandler(this.AnalogyOTAForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton sbtnInit;
        private System.Windows.Forms.ComboBox cbShares;
    }
}