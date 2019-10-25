namespace Analogy
{
    partial class ExtensionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtensionsForm));
            this.rtxtbMessages = new System.Windows.Forms.RichTextBox();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.extensionsUC1 = new Analogy.ExtensionsUC();
            this.SuspendLayout();
            // 
            // rtxtbMessages
            // 
            this.rtxtbMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtbMessages.Location = new System.Drawing.Point(12, 459);
            this.rtxtbMessages.Name = "rtxtbMessages";
            this.rtxtbMessages.Size = new System.Drawing.Size(778, 106);
            this.rtxtbMessages.TabIndex = 14;
            this.rtxtbMessages.Text = "";
            // 
            // BtnLoad
            // 
            this.BtnLoad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnLoad.Location = new System.Drawing.Point(290, 572);
            this.BtnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(174, 34);
            this.BtnLoad.TabIndex = 13;
            this.BtnLoad.Text = "Load Selected";
            this.BtnLoad.UseVisualStyleBackColor = true;
            // 
            // extensionsUC1
            // 
            this.extensionsUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extensionsUC1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.extensionsUC1.Location = new System.Drawing.Point(0, 0);
            this.extensionsUC1.Margin = new System.Windows.Forms.Padding(4);
            this.extensionsUC1.Name = "extensionsUC1";
            this.extensionsUC1.Size = new System.Drawing.Size(805, 619);
            this.extensionsUC1.TabIndex = 15;
            // 
            // ExtensionsForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 619);
            this.Controls.Add(this.extensionsUC1);
            this.Controls.Add(this.rtxtbMessages);
            this.Controls.Add(this.BtnLoad);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ExtensionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Extensions";
            this.Load += new System.EventHandler(this.ExtensionsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtbMessages;
        private System.Windows.Forms.Button BtnLoad;
        private ExtensionsUC extensionsUC1;
    }
}