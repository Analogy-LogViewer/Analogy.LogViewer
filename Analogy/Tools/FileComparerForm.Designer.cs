namespace Analogy.Tools
{
    partial class FileComparerForm
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
            this.logsComparerUC1 = new Analogy.Tools.LogsComparerUC();
            this.SuspendLayout();
            // 
            // logsComparerUC1
            // 
            this.logsComparerUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logsComparerUC1.Location = new System.Drawing.Point(0, 0);
            this.logsComparerUC1.Name = "logsComparerUC1";
            this.logsComparerUC1.Size = new System.Drawing.Size(533, 368);
            this.logsComparerUC1.TabIndex = 0;
            // 
            // FileComparerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 368);
            this.Controls.Add(this.logsComparerUC1);
            this.Name = "FileComparerForm";
            this.Text = "Logs comparer";
            this.ResumeLayout(false);

        }

        #endregion

        private LogsComparerUC logsComparerUC1;
    }
}