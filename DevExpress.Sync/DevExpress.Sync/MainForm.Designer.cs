
namespace DevExpress.Sync
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtbSource = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtbTarget = new System.Windows.Forms.TextBox();
            btnCopy = new System.Windows.Forms.Button();
            btnVersionUpgrade = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // txtbSource
            // 
            txtbSource.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtbSource.Location = new System.Drawing.Point(91, 19);
            txtbSource.Name = "txtbSource";
            txtbSource.Size = new System.Drawing.Size(697, 27);
            txtbSource.TabIndex = 0;
            txtbSource.Text = "C:\\Program Files\\DevExpress 25.2\\Components\\Bin\\";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 21);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 20);
            label1.TabIndex = 1;
            label1.Text = "Source:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 55);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(53, 20);
            label2.TabIndex = 3;
            label2.Text = "Target:";
            // 
            // txtbTarget
            // 
            txtbTarget.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtbTarget.Location = new System.Drawing.Point(91, 51);
            txtbTarget.Name = "txtbTarget";
            txtbTarget.Size = new System.Drawing.Size(697, 27);
            txtbTarget.TabIndex = 2;
            txtbTarget.Text = "e:\\files\\Programming\\Analogy.LogViewer\\DevExpress\\";
            // 
            // btnCopy
            // 
            btnCopy.Location = new System.Drawing.Point(91, 88);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new System.Drawing.Size(130, 51);
            btnCopy.TabIndex = 4;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // btnVersionUpgrade
            // 
            btnVersionUpgrade.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnVersionUpgrade.Location = new System.Drawing.Point(658, 88);
            btnVersionUpgrade.Name = "btnVersionUpgrade";
            btnVersionUpgrade.Size = new System.Drawing.Size(130, 51);
            btnVersionUpgrade.TabIndex = 5;
            btnVersionUpgrade.Text = "Version Upgrade";
            btnVersionUpgrade.UseVisualStyleBackColor = true;
            btnVersionUpgrade.Click += btnVersionUpgrade_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 159);
            Controls.Add(btnVersionUpgrade);
            Controls.Add(btnCopy);
            Controls.Add(label2);
            Controls.Add(txtbTarget);
            Controls.Add(label1);
            Controls.Add(txtbSource);
            Name = "MainForm";
            Text = "DevExpress Syncer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtbSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbTarget;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnVersionUpgrade;
    }
}

