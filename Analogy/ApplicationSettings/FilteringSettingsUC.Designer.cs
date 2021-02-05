
namespace Analogy.ApplicationSettings
{
    partial class FilteringSettingsUC
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
            this.gcFiltering = new DevExpress.XtraEditors.GroupControl();
            this.tsTrackActiveMessage = new DevExpress.XtraEditors.ToggleSwitch();
            this.chkLstLogLevel = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.tsLogLevels = new DevExpress.XtraEditors.ToggleSwitch();
            this.tsSimpleMode = new DevExpress.XtraEditors.ToggleSwitch();
            this.tsDataTimeAscendDescend = new DevExpress.XtraEditors.ToggleSwitch();
            this.tsHistory = new DevExpress.XtraEditors.ToggleSwitch();
            this.checkEditSearchAlsoInSourceAndModule = new DevExpress.XtraEditors.CheckEdit();
            this.chkEditPaging = new DevExpress.XtraEditors.CheckEdit();
            this.nudPageLength = new System.Windows.Forms.NumericUpDown();
            this.tsErrorLevelAsDefault = new DevExpress.XtraEditors.ToggleSwitch();
            this.tsFilteringExclude = new DevExpress.XtraEditors.ToggleSwitch();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.chklExclusionLogLevel = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcFiltering)).BeginInit();
            this.gcFiltering.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsTrackActiveMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstLogLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsLogLevels.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsSimpleMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsDataTimeAscendDescend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsHistory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSearchAlsoInSourceAndModule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditPaging.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPageLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsErrorLevelAsDefault.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsFilteringExclude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chklExclusionLogLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // gcFiltering
            // 
            this.gcFiltering.Controls.Add(this.tsTrackActiveMessage);
            this.gcFiltering.Controls.Add(this.chkLstLogLevel);
            this.gcFiltering.Controls.Add(this.tsLogLevels);
            this.gcFiltering.Controls.Add(this.tsSimpleMode);
            this.gcFiltering.Controls.Add(this.tsDataTimeAscendDescend);
            this.gcFiltering.Controls.Add(this.tsHistory);
            this.gcFiltering.Controls.Add(this.checkEditSearchAlsoInSourceAndModule);
            this.gcFiltering.Controls.Add(this.chkEditPaging);
            this.gcFiltering.Controls.Add(this.nudPageLength);
            this.gcFiltering.Controls.Add(this.tsErrorLevelAsDefault);
            this.gcFiltering.Controls.Add(this.tsFilteringExclude);
            this.gcFiltering.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcFiltering.Location = new System.Drawing.Point(0, 0);
            this.gcFiltering.Margin = new System.Windows.Forms.Padding(10);
            this.gcFiltering.Name = "gcFiltering";
            this.gcFiltering.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.gcFiltering.Size = new System.Drawing.Size(840, 449);
            this.gcFiltering.TabIndex = 4;
            this.gcFiltering.Text = "Filtering and search ";
            // 
            // tsTrackActiveMessage
            // 
            this.tsTrackActiveMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsTrackActiveMessage.Location = new System.Drawing.Point(7, 186);
            this.tsTrackActiveMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsTrackActiveMessage.Name = "tsTrackActiveMessage";
            this.tsTrackActiveMessage.Properties.OffText = "Do not track Active / Selected message in log grid";
            this.tsTrackActiveMessage.Properties.OnText = "Track Active / Selected message in log grid";
            this.tsTrackActiveMessage.Size = new System.Drawing.Size(817, 28);
            this.tsTrackActiveMessage.TabIndex = 35;
            // 
            // chkLstLogLevel
            // 
            this.chkLstLogLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLstLogLevel.CheckMode = DevExpress.XtraEditors.CheckMode.Single;
            this.chkLstLogLevel.CheckOnClick = true;
            this.chkLstLogLevel.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkLstLogLevel.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Trace"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Error + Critical"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Warning"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Debug"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Verbose")});
            this.chkLstLogLevel.Location = new System.Drawing.Point(433, 292);
            this.chkLstLogLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkLstLogLevel.Name = "chkLstLogLevel";
            this.chkLstLogLevel.Size = new System.Drawing.Size(390, 137);
            this.chkLstLogLevel.TabIndex = 34;
            // 
            // tsLogLevels
            // 
            this.tsLogLevels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsLogLevels.Location = new System.Drawing.Point(7, 288);
            this.tsLogLevels.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsLogLevels.Name = "tsLogLevels";
            this.tsLogLevels.Properties.OffText = "Single Selection";
            this.tsLogLevels.Properties.OnText = "Multiple Selection";
            this.tsLogLevels.Size = new System.Drawing.Size(387, 28);
            this.tsLogLevels.TabIndex = 33;
            // 
            // tsSimpleMode
            // 
            this.tsSimpleMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsSimpleMode.Location = new System.Drawing.Point(7, 27);
            this.tsSimpleMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsSimpleMode.Name = "tsSimpleMode";
            this.tsSimpleMode.Properties.OffText = "Simple mode is off (Additional options in filtering UI)";
            this.tsSimpleMode.Properties.OnText = "Simple mode is on (Less options in filtering UI)";
            this.tsSimpleMode.Size = new System.Drawing.Size(817, 28);
            this.tsSimpleMode.TabIndex = 8;
            // 
            // tsDataTimeAscendDescend
            // 
            this.tsDataTimeAscendDescend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsDataTimeAscendDescend.Location = new System.Drawing.Point(6, 88);
            this.tsDataTimeAscendDescend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsDataTimeAscendDescend.Name = "tsDataTimeAscendDescend";
            this.tsDataTimeAscendDescend.Properties.OffText = "Default sort is by ascending date (new messages are at the bottom)";
            this.tsDataTimeAscendDescend.Properties.OnText = "Default sort is by descending date (new messages are at the top)";
            this.tsDataTimeAscendDescend.Size = new System.Drawing.Size(817, 28);
            this.tsDataTimeAscendDescend.TabIndex = 7;
            // 
            // tsHistory
            // 
            this.tsHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsHistory.Location = new System.Drawing.Point(5, 149);
            this.tsHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsHistory.Name = "tsHistory";
            this.tsHistory.Properties.OffText = "Don\'t show history of cleared Messages";
            this.tsHistory.Properties.OnText = "Show history of cleared Messages";
            this.tsHistory.Size = new System.Drawing.Size(817, 28);
            this.tsHistory.TabIndex = 0;
            // 
            // checkEditSearchAlsoInSourceAndModule
            // 
            this.checkEditSearchAlsoInSourceAndModule.Location = new System.Drawing.Point(6, 254);
            this.checkEditSearchAlsoInSourceAndModule.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkEditSearchAlsoInSourceAndModule.Name = "checkEditSearchAlsoInSourceAndModule";
            this.checkEditSearchAlsoInSourceAndModule.Properties.Caption = "Search text also in Source and Module/Process columns";
            this.checkEditSearchAlsoInSourceAndModule.Size = new System.Drawing.Size(363, 20);
            this.checkEditSearchAlsoInSourceAndModule.TabIndex = 6;
            // 
            // chkEditPaging
            // 
            this.chkEditPaging.Location = new System.Drawing.Point(6, 223);
            this.chkEditPaging.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEditPaging.Name = "chkEditPaging";
            this.chkEditPaging.Properties.Caption = "Enable Paging (number of rows per page):";
            this.chkEditPaging.Size = new System.Drawing.Size(336, 20);
            this.chkEditPaging.TabIndex = 5;
            // 
            // nudPageLength
            // 
            this.nudPageLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPageLength.Location = new System.Drawing.Point(592, 223);
            this.nudPageLength.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudPageLength.Maximum = new decimal(new int[] {
            1874919424,
            2328306,
            0,
            0});
            this.nudPageLength.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudPageLength.Name = "nudPageLength";
            this.nudPageLength.Size = new System.Drawing.Size(230, 23);
            this.nudPageLength.TabIndex = 4;
            this.nudPageLength.Value = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            // 
            // tsErrorLevelAsDefault
            // 
            this.tsErrorLevelAsDefault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsErrorLevelAsDefault.Location = new System.Drawing.Point(5, 120);
            this.tsErrorLevelAsDefault.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsErrorLevelAsDefault.Name = "tsErrorLevelAsDefault";
            this.tsErrorLevelAsDefault.Properties.OffText = "Don\'t filter logs on Load";
            this.tsErrorLevelAsDefault.Properties.OnText = "Start logs with Error and Critical  level as default filtering";
            this.tsErrorLevelAsDefault.Size = new System.Drawing.Size(817, 28);
            this.tsErrorLevelAsDefault.TabIndex = 3;
            // 
            // tsFilteringExclude
            // 
            this.tsFilteringExclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsFilteringExclude.Location = new System.Drawing.Point(5, 57);
            this.tsFilteringExclude.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsFilteringExclude.Name = "tsFilteringExclude";
            this.tsFilteringExclude.Properties.OffText = "Don\'t save filtering text upon exit";
            this.tsFilteringExclude.Properties.OnText = "Save filtering text for next startup";
            this.tsFilteringExclude.Size = new System.Drawing.Size(817, 28);
            this.tsFilteringExclude.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl13);
            this.groupControl1.Controls.Add(this.chklExclusionLogLevel);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 449);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(840, 278);
            this.groupControl1.TabIndex = 37;
            this.groupControl1.Text = "Filtering Exclusion";
            this.groupControl1.Visible = false;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(7, 29);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(350, 16);
            this.labelControl13.TabIndex = 36;
            this.labelControl13.Text = "Always show the following log levels regardless active filters:";
            // 
            // chklExclusionLogLevel
            // 
            this.chklExclusionLogLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chklExclusionLogLevel.CheckMode = DevExpress.XtraEditors.CheckMode.Single;
            this.chklExclusionLogLevel.CheckOnClick = true;
            this.chklExclusionLogLevel.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chklExclusionLogLevel.Location = new System.Drawing.Point(608, 27);
            this.chklExclusionLogLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chklExclusionLogLevel.Name = "chklExclusionLogLevel";
            this.chklExclusionLogLevel.Size = new System.Drawing.Size(227, 247);
            this.chklExclusionLogLevel.TabIndex = 35;
            // 
            // FilteringSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gcFiltering);
            this.Name = "FilteringSettingsUC";
            this.Size = new System.Drawing.Size(840, 798);
            this.Load += new System.EventHandler(this.FilteringSettingsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcFiltering)).EndInit();
            this.gcFiltering.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tsTrackActiveMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstLogLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsLogLevels.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsSimpleMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsDataTimeAscendDescend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsHistory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSearchAlsoInSourceAndModule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditPaging.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPageLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsErrorLevelAsDefault.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsFilteringExclude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chklExclusionLogLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcFiltering;
        private DevExpress.XtraEditors.ToggleSwitch tsTrackActiveMessage;
        private DevExpress.XtraEditors.CheckedListBoxControl chkLstLogLevel;
        private DevExpress.XtraEditors.ToggleSwitch tsLogLevels;
        private DevExpress.XtraEditors.ToggleSwitch tsSimpleMode;
        private DevExpress.XtraEditors.ToggleSwitch tsDataTimeAscendDescend;
        private DevExpress.XtraEditors.ToggleSwitch tsHistory;
        private DevExpress.XtraEditors.CheckEdit checkEditSearchAlsoInSourceAndModule;
        private DevExpress.XtraEditors.CheckEdit chkEditPaging;
        private System.Windows.Forms.NumericUpDown nudPageLength;
        private DevExpress.XtraEditors.ToggleSwitch tsErrorLevelAsDefault;
        private DevExpress.XtraEditors.ToggleSwitch tsFilteringExclude;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.CheckedListBoxControl chklExclusionLogLevel;
    }
}
