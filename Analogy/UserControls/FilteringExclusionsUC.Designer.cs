
namespace Analogy.UserControls
{
    partial class FilteringExclusionsUC
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkLstLogLevel = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstLogLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.chkLstLogLevel);
            this.groupControl1.Location = new System.Drawing.Point(46, 45);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(646, 169);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Filtering Exclusion";
            // 
            // chkLstLogLevel
            // 
            this.chkLstLogLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLstLogLevel.CheckMode = DevExpress.XtraEditors.CheckMode.Single;
            this.chkLstLogLevel.CheckOnClick = true;
            this.chkLstLogLevel.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkLstLogLevel.Location = new System.Drawing.Point(414, 27);
            this.chkLstLogLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkLstLogLevel.Name = "chkLstLogLevel";
            this.chkLstLogLevel.Size = new System.Drawing.Size(227, 137);
            this.chkLstLogLevel.TabIndex = 35;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(344, 16);
            this.labelControl1.TabIndex = 36;
            this.labelControl1.Text = "Always show the following log level regardless active filters:";
            // 
            // FilteringExclusionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "FilteringExclusionsUC";
            this.Size = new System.Drawing.Size(772, 472);
            this.Load += new System.EventHandler(this.FilteringExclusionsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstLogLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl chkLstLogLevel;
    }
}
