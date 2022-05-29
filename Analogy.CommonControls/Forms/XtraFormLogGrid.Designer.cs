using Analogy.CommonControls.UserControls;

namespace Analogy.CommonControls.Forms
{
    partial class XtraFormLogGrid
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
            System.Threading.CancellationTokenSource cancellationTokenSource1 = new System.Threading.CancellationTokenSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraFormLogGrid));
            this._logMessagesUcLogs1 = new LogMessagesUC();
            this.SuspendLayout();
            // 
            // _logMessagesUcLogs1
            // 
            this._logMessagesUcLogs1.CancellationTokenSource = cancellationTokenSource1;
            this._logMessagesUcLogs1.CurrentColumnsFields = ((System.Collections.Generic.List<System.ValueTuple<string, string>>)(resources.GetObject("_logMessagesUcLogs1.CurrentColumnsFields")));
            this._logMessagesUcLogs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._logMessagesUcLogs1.DoNotAddToRecentHistory = false;
            this._logMessagesUcLogs1.ExcludeFilterCriteriaUIOptions = ((System.Collections.Generic.List<DataTypes.FilterCriteriaUIOption>)(resources.GetObject("_logMessagesUcLogs1.ExcludeFilterCriteriaUIOptions")));
            this._logMessagesUcLogs1.FileDataProvider = null;
            this._logMessagesUcLogs1.ForceNoFileCaching = false;
            this._logMessagesUcLogs1.IncludeFilterCriteriaUIOptions = ((System.Collections.Generic.List<DataTypes.FilterCriteriaUIOption>)(resources.GetObject("_logMessagesUcLogs1.IncludeFilterCriteriaUIOptions")));
            this._logMessagesUcLogs1.Location = new System.Drawing.Point(0, 0);
            this._logMessagesUcLogs1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._logMessagesUcLogs1.Name = "_logMessagesUcLogs1";
            this._logMessagesUcLogs1.Size = new System.Drawing.Size(1200, 711);
            this._logMessagesUcLogs1.TabIndex = 0;
            // 
            // XtraFormLogGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 711);
            this.Controls.Add(this._logMessagesUcLogs1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "XtraFormLogGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Analogy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XtraFormLogGrid_FormClosing);
            this.Load += new System.EventHandler(this.XtraFormLogGrid_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LogMessagesUC _logMessagesUcLogs1;
    }
}