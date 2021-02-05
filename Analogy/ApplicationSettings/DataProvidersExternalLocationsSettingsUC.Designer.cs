
namespace Analogy.ApplicationSettings
{
    partial class DataProvidersExternalLocationsSettingsUC
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
            this.lblAssemblies = new DevExpress.XtraEditors.LabelControl();
            this.lblFoldersProbing = new DevExpress.XtraEditors.LabelControl();
            this.listBoxFoldersProbing = new DevExpress.XtraEditors.ListBoxControl();
            this.sbtnDeleteFolderProbing = new DevExpress.XtraEditors.SimpleButton();
            this.teFoldersProbing = new DevExpress.XtraEditors.TextEdit();
            this.sbtnFolderProbingBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnFolderProbingAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxFoldersProbing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFoldersProbing.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAssemblies
            // 
            this.lblAssemblies.AutoEllipsis = true;
            this.lblAssemblies.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblAssemblies.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAssemblies.Location = new System.Drawing.Point(0, 0);
            this.lblAssemblies.Name = "lblAssemblies";
            this.lblAssemblies.Padding = new System.Windows.Forms.Padding(5);
            this.lblAssemblies.Size = new System.Drawing.Size(830, 42);
            this.lblAssemblies.TabIndex = 11;
            this.lblAssemblies.Text = "Any Analogy.LogViewer.*.dll that is placed at the same folder as the application " +
    "will be loaded. You can specify aditional folders below (a restart is needed for" +
    " the changes to take affect):";
            // 
            // lblFoldersProbing
            // 
            this.lblFoldersProbing.Location = new System.Drawing.Point(3, 48);
            this.lblFoldersProbing.Name = "lblFoldersProbing";
            this.lblFoldersProbing.Size = new System.Drawing.Size(270, 16);
            this.lblFoldersProbing.TabIndex = 12;
            this.lblFoldersProbing.Text = "Additional Folders for Data Providers asseblies:";
            // 
            // listBoxFoldersProbing
            // 
            this.listBoxFoldersProbing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFoldersProbing.Location = new System.Drawing.Point(13, 119);
            this.listBoxFoldersProbing.Name = "listBoxFoldersProbing";
            this.listBoxFoldersProbing.Size = new System.Drawing.Size(813, 405);
            this.listBoxFoldersProbing.TabIndex = 13;
            // 
            // sbtnDeleteFolderProbing
            // 
            this.sbtnDeleteFolderProbing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnDeleteFolderProbing.Location = new System.Drawing.Point(770, 86);
            this.sbtnDeleteFolderProbing.Name = "sbtnDeleteFolderProbing";
            this.sbtnDeleteFolderProbing.Size = new System.Drawing.Size(56, 27);
            this.sbtnDeleteFolderProbing.TabIndex = 17;
            this.sbtnDeleteFolderProbing.Text = "Delete";
            // 
            // teFoldersProbing
            // 
            this.teFoldersProbing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teFoldersProbing.Location = new System.Drawing.Point(13, 89);
            this.teFoldersProbing.Name = "teFoldersProbing";
            this.teFoldersProbing.Size = new System.Drawing.Size(620, 22);
            this.teFoldersProbing.TabIndex = 14;
            // 
            // sbtnFolderProbingBrowse
            // 
            this.sbtnFolderProbingBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnFolderProbingBrowse.Location = new System.Drawing.Point(638, 86);
            this.sbtnFolderProbingBrowse.Name = "sbtnFolderProbingBrowse";
            this.sbtnFolderProbingBrowse.Size = new System.Drawing.Size(36, 27);
            this.sbtnFolderProbingBrowse.TabIndex = 15;
            this.sbtnFolderProbingBrowse.Text = "...";
            // 
            // sbtnFolderProbingAdd
            // 
            this.sbtnFolderProbingAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnFolderProbingAdd.Location = new System.Drawing.Point(677, 86);
            this.sbtnFolderProbingAdd.Name = "sbtnFolderProbingAdd";
            this.sbtnFolderProbingAdd.Size = new System.Drawing.Size(56, 27);
            this.sbtnFolderProbingAdd.TabIndex = 16;
            this.sbtnFolderProbingAdd.Text = "Add";
            // 
            // DataProvidersExternalLocationsSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.sbtnDeleteFolderProbing);
            this.Controls.Add(this.teFoldersProbing);
            this.Controls.Add(this.sbtnFolderProbingBrowse);
            this.Controls.Add(this.sbtnFolderProbingAdd);
            this.Controls.Add(this.listBoxFoldersProbing);
            this.Controls.Add(this.lblFoldersProbing);
            this.Controls.Add(this.lblAssemblies);
            this.Name = "DataProvidersExternalLocationsSettingsUC";
            this.Size = new System.Drawing.Size(830, 527);
            this.Load += new System.EventHandler(this.DataProvidersExternalLocations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxFoldersProbing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFoldersProbing.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblAssemblies;
        private DevExpress.XtraEditors.LabelControl lblFoldersProbing;
        private DevExpress.XtraEditors.ListBoxControl listBoxFoldersProbing;
        private DevExpress.XtraEditors.SimpleButton sbtnDeleteFolderProbing;
        private DevExpress.XtraEditors.TextEdit teFoldersProbing;
        private DevExpress.XtraEditors.SimpleButton sbtnFolderProbingBrowse;
        private DevExpress.XtraEditors.SimpleButton sbtnFolderProbingAdd;
    }
}
