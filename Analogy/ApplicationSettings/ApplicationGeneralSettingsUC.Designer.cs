
namespace Analogy.ApplicationSettings
{
    partial class ApplicationGeneralSettingsUC
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.gcCompressedArchives = new DevExpress.XtraEditors.GroupControl();
            this.tsEnableCompressedArchive = new DevExpress.XtraEditors.ToggleSwitch();
            this.gcGeneral = new DevExpress.XtraEditors.GroupControl();
            this.nudRecentFolders = new System.Windows.Forms.NumericUpDown();
            this.nudRecentFiles = new System.Windows.Forms.NumericUpDown();
            this.lblRecentFolders = new DevExpress.XtraEditors.LabelControl();
            this.lblRecent = new DevExpress.XtraEditors.LabelControl();
            this.nudRealTimeRefreshInterval = new System.Windows.Forms.NumericUpDown();
            this.lblRealTimeRefreshInterval = new DevExpress.XtraEditors.LabelControl();
            this.tsWhatsNew = new DevExpress.XtraEditors.ToggleSwitch();
            this.tsCheckAdditionalInformation = new DevExpress.XtraEditors.ToggleSwitch();
            this.tsAutoComplete = new DevExpress.XtraEditors.ToggleSwitch();
            this.nudAutoCompleteCount = new System.Windows.Forms.NumericUpDown();
            this.tsTraybar = new DevExpress.XtraEditors.ToggleSwitch();
            this.tsFileCaching = new DevExpress.XtraEditors.ToggleSwitch();
            this.tsSingleInstance = new DevExpress.XtraEditors.ToggleSwitch();
            this.gcSettingsLocation = new DevExpress.XtraEditors.GroupControl();
            this.ceSettingsLocationApplicationFolder = new DevExpress.XtraEditors.CheckEdit();
            this.ceSettingsLocationPerUser = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.nudIdleTime = new System.Windows.Forms.NumericUpDown();
            this.toggleSwitchIdleMode = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.gcCompressedArchives)).BeginInit();
            this.gcCompressedArchives.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsEnableCompressedArchive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGeneral)).BeginInit();
            this.gcGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecentFolders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecentFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRealTimeRefreshInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsWhatsNew.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsCheckAdditionalInformation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsAutoComplete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoCompleteCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsTraybar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsFileCaching.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsSingleInstance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSettingsLocation)).BeginInit();
            this.gcSettingsLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceSettingsLocationApplicationFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSettingsLocationPerUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdleTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitchIdleMode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCompressedArchives
            // 
            this.gcCompressedArchives.Controls.Add(this.tsEnableCompressedArchive);
            this.gcCompressedArchives.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcCompressedArchives.Location = new System.Drawing.Point(0, 476);
            this.gcCompressedArchives.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcCompressedArchives.Name = "gcCompressedArchives";
            this.gcCompressedArchives.Size = new System.Drawing.Size(786, 75);
            this.gcCompressedArchives.TabIndex = 10;
            this.gcCompressedArchives.Text = "Compressed Archives";
            // 
            // tsEnableCompressedArchive
            // 
            this.tsEnableCompressedArchive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsEnableCompressedArchive.EditValue = true;
            this.tsEnableCompressedArchive.Location = new System.Drawing.Point(11, 37);
            this.tsEnableCompressedArchive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsEnableCompressedArchive.Name = "tsEnableCompressedArchive";
            this.tsEnableCompressedArchive.Properties.AutoHeight = false;
            this.tsEnableCompressedArchive.Properties.OffText = "Disable support for archives files  (Zip and gz)";
            this.tsEnableCompressedArchive.Properties.OnText = "Enable support for archives files  (Zip and gz) - Add extensions to Open File dia" +
    "log";
            this.tsEnableCompressedArchive.Size = new System.Drawing.Size(763, 28);
            this.tsEnableCompressedArchive.TabIndex = 5;
            // 
            // gcGeneral
            // 
            this.gcGeneral.Controls.Add(this.nudRecentFolders);
            this.gcGeneral.Controls.Add(this.nudRecentFiles);
            this.gcGeneral.Controls.Add(this.lblRecentFolders);
            this.gcGeneral.Controls.Add(this.lblRecent);
            this.gcGeneral.Controls.Add(this.nudRealTimeRefreshInterval);
            this.gcGeneral.Controls.Add(this.lblRealTimeRefreshInterval);
            this.gcGeneral.Controls.Add(this.tsWhatsNew);
            this.gcGeneral.Controls.Add(this.tsCheckAdditionalInformation);
            this.gcGeneral.Controls.Add(this.tsAutoComplete);
            this.gcGeneral.Controls.Add(this.nudAutoCompleteCount);
            this.gcGeneral.Controls.Add(this.tsTraybar);
            this.gcGeneral.Controls.Add(this.tsFileCaching);
            this.gcGeneral.Controls.Add(this.tsSingleInstance);
            this.gcGeneral.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcGeneral.Location = new System.Drawing.Point(0, 91);
            this.gcGeneral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcGeneral.Name = "gcGeneral";
            this.gcGeneral.Size = new System.Drawing.Size(786, 313);
            this.gcGeneral.TabIndex = 8;
            this.gcGeneral.Text = "General";
            // 
            // nudRecentFolders
            // 
            this.nudRecentFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRecentFolders.Location = new System.Drawing.Point(700, 280);
            this.nudRecentFolders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudRecentFolders.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudRecentFolders.Name = "nudRecentFolders";
            this.nudRecentFolders.Size = new System.Drawing.Size(73, 23);
            this.nudRecentFolders.TabIndex = 41;
            this.nudRecentFolders.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudRecentFiles
            // 
            this.nudRecentFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRecentFiles.Location = new System.Drawing.Point(700, 249);
            this.nudRecentFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudRecentFiles.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudRecentFiles.Name = "nudRecentFiles";
            this.nudRecentFiles.Size = new System.Drawing.Size(73, 23);
            this.nudRecentFiles.TabIndex = 40;
            this.nudRecentFiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblRecentFolders
            // 
            this.lblRecentFolders.Location = new System.Drawing.Point(11, 287);
            this.lblRecentFolders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblRecentFolders.Name = "lblRecentFolders";
            this.lblRecentFolders.Size = new System.Drawing.Size(194, 16);
            this.lblRecentFolders.TabIndex = 39;
            this.lblRecentFolders.Text = "Number of recent folders to keep:";
            // 
            // lblRecent
            // 
            this.lblRecent.Location = new System.Drawing.Point(11, 256);
            this.lblRecent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblRecent.Name = "lblRecent";
            this.lblRecent.Size = new System.Drawing.Size(178, 16);
            this.lblRecent.TabIndex = 38;
            this.lblRecent.Text = "Number of recent files to keep:";
            // 
            // nudRealTimeRefreshInterval
            // 
            this.nudRealTimeRefreshInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRealTimeRefreshInterval.DecimalPlaces = 1;
            this.nudRealTimeRefreshInterval.Location = new System.Drawing.Point(543, 222);
            this.nudRealTimeRefreshInterval.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudRealTimeRefreshInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRealTimeRefreshInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRealTimeRefreshInterval.Name = "nudRealTimeRefreshInterval";
            this.nudRealTimeRefreshInterval.Size = new System.Drawing.Size(230, 23);
            this.nudRealTimeRefreshInterval.TabIndex = 36;
            this.nudRealTimeRefreshInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblRealTimeRefreshInterval
            // 
            this.lblRealTimeRefreshInterval.Location = new System.Drawing.Point(10, 224);
            this.lblRealTimeRefreshInterval.Name = "lblRealTimeRefreshInterval";
            this.lblRealTimeRefreshInterval.Size = new System.Drawing.Size(305, 16);
            this.lblRealTimeRefreshInterval.TabIndex = 37;
            this.lblRealTimeRefreshInterval.Text = "Refresh time in Seconds for real time date providers:";
            // 
            // tsWhatsNew
            // 
            this.tsWhatsNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsWhatsNew.EditValue = true;
            this.tsWhatsNew.Location = new System.Drawing.Point(10, 153);
            this.tsWhatsNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsWhatsNew.Name = "tsWhatsNew";
            this.tsWhatsNew.Properties.OffText = "Dont show what is new at start of application";
            this.tsWhatsNew.Properties.OnText = "Show what is new at start of application";
            this.tsWhatsNew.Size = new System.Drawing.Size(756, 28);
            this.tsWhatsNew.TabIndex = 5;
            // 
            // tsCheckAdditionalInformation
            // 
            this.tsCheckAdditionalInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsCheckAdditionalInformation.Location = new System.Drawing.Point(10, 121);
            this.tsCheckAdditionalInformation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsCheckAdditionalInformation.Name = "tsCheckAdditionalInformation";
            this.tsCheckAdditionalInformation.Properties.OffText = "Don\'t load dynamic columns at run time";
            this.tsCheckAdditionalInformation.Properties.OnText = "Load dynamic columns at run time";
            this.tsCheckAdditionalInformation.Size = new System.Drawing.Size(763, 28);
            this.tsCheckAdditionalInformation.TabIndex = 4;
            // 
            // tsAutoComplete
            // 
            this.tsAutoComplete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsAutoComplete.Location = new System.Drawing.Point(10, 185);
            this.tsAutoComplete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsAutoComplete.Name = "tsAutoComplete";
            this.tsAutoComplete.Properties.OffText = "Don\'t save last searches";
            this.tsAutoComplete.Properties.OnText = "Save last searches";
            this.tsAutoComplete.Size = new System.Drawing.Size(516, 28);
            this.tsAutoComplete.TabIndex = 2;
            // 
            // nudAutoCompleteCount
            // 
            this.nudAutoCompleteCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudAutoCompleteCount.Location = new System.Drawing.Point(543, 191);
            this.nudAutoCompleteCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudAutoCompleteCount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudAutoCompleteCount.Name = "nudAutoCompleteCount";
            this.nudAutoCompleteCount.Size = new System.Drawing.Size(230, 23);
            this.nudAutoCompleteCount.TabIndex = 4;
            this.nudAutoCompleteCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tsTraybar
            // 
            this.tsTraybar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsTraybar.Location = new System.Drawing.Point(10, 89);
            this.tsTraybar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsTraybar.Name = "tsTraybar";
            this.tsTraybar.Properties.OffText = "Close application on exit or on ALT+F4";
            this.tsTraybar.Properties.OnText = "Minimized to the system tray instead of closing";
            this.tsTraybar.Size = new System.Drawing.Size(763, 28);
            this.tsTraybar.TabIndex = 3;
            // 
            // tsFileCaching
            // 
            this.tsFileCaching.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsFileCaching.EditValue = true;
            this.tsFileCaching.Location = new System.Drawing.Point(10, 57);
            this.tsFileCaching.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsFileCaching.Name = "tsFileCaching";
            this.tsFileCaching.Properties.OffText = "Don\'t use caching of loaded logs";
            this.tsFileCaching.Properties.OnText = "Use caching of loaded logs";
            this.tsFileCaching.Size = new System.Drawing.Size(763, 28);
            toolTipTitleItem1.Text = "Caching";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "When enable files that were loaded won\'t be loaded again and the messages will be" +
    " loaded from in-memory cache.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.tsFileCaching.SuperTip = superToolTip1;
            this.tsFileCaching.TabIndex = 1;
            // 
            // tsSingleInstance
            // 
            this.tsSingleInstance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsSingleInstance.EditValue = true;
            this.tsSingleInstance.Location = new System.Drawing.Point(10, 25);
            this.tsSingleInstance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsSingleInstance.Name = "tsSingleInstance";
            this.tsSingleInstance.Properties.OffText = "Multi Instance Mode";
            this.tsSingleInstance.Properties.OnText = "Single Instance Mode";
            this.tsSingleInstance.Size = new System.Drawing.Size(763, 28);
            toolTipTitleItem2.Text = "Single Instance mode";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "When enabled only one instance will run and other instances will exit immediately" +
    "";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.tsSingleInstance.SuperTip = superToolTip2;
            this.tsSingleInstance.TabIndex = 2;
            // 
            // gcSettingsLocation
            // 
            this.gcSettingsLocation.Controls.Add(this.ceSettingsLocationApplicationFolder);
            this.gcSettingsLocation.Controls.Add(this.ceSettingsLocationPerUser);
            this.gcSettingsLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcSettingsLocation.Location = new System.Drawing.Point(0, 0);
            this.gcSettingsLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcSettingsLocation.Name = "gcSettingsLocation";
            this.gcSettingsLocation.Size = new System.Drawing.Size(786, 91);
            this.gcSettingsLocation.TabIndex = 11;
            this.gcSettingsLocation.Text = "Settings Location";
            // 
            // ceSettingsLocationApplicationFolder
            // 
            this.ceSettingsLocationApplicationFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.ceSettingsLocationApplicationFolder.Location = new System.Drawing.Point(2, 52);
            this.ceSettingsLocationApplicationFolder.Name = "ceSettingsLocationApplicationFolder";
            this.ceSettingsLocationApplicationFolder.Properties.Caption = "Portable: Store settings in the Application Folder (May need folder permissions)";
            this.ceSettingsLocationApplicationFolder.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgRadio2;
            this.ceSettingsLocationApplicationFolder.Properties.RadioGroupIndex = 0;
            this.ceSettingsLocationApplicationFolder.Size = new System.Drawing.Size(782, 27);
            this.ceSettingsLocationApplicationFolder.TabIndex = 1;
            this.ceSettingsLocationApplicationFolder.TabStop = false;
            // 
            // ceSettingsLocationPerUser
            // 
            this.ceSettingsLocationPerUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.ceSettingsLocationPerUser.EditValue = true;
            this.ceSettingsLocationPerUser.Location = new System.Drawing.Point(2, 25);
            this.ceSettingsLocationPerUser.Name = "ceSettingsLocationPerUser";
            this.ceSettingsLocationPerUser.Properties.Caption = "Per User: Store settings in: %userprofile%\\appdata\\local\\Analogy.LogViewer";
            this.ceSettingsLocationPerUser.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgRadio2;
            this.ceSettingsLocationPerUser.Properties.RadioGroupIndex = 0;
            this.ceSettingsLocationPerUser.Size = new System.Drawing.Size(782, 27);
            this.ceSettingsLocationPerUser.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.nudIdleTime);
            this.groupControl1.Controls.Add(this.toggleSwitchIdleMode);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 404);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(786, 72);
            this.groupControl1.TabIndex = 12;
            this.groupControl1.Text = "Idle mode";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(255, 35);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(208, 16);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Idle time (in minutes) of no activity :";
            // 
            // nudIdleTime
            // 
            this.nudIdleTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudIdleTime.Location = new System.Drawing.Point(672, 28);
            this.nudIdleTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nudIdleTime.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudIdleTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIdleTime.Name = "nudIdleTime";
            this.nudIdleTime.Size = new System.Drawing.Size(101, 23);
            this.nudIdleTime.TabIndex = 10;
            this.nudIdleTime.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // toggleSwitchIdleMode
            // 
            this.toggleSwitchIdleMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toggleSwitchIdleMode.Location = new System.Drawing.Point(11, 29);
            this.toggleSwitchIdleMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toggleSwitchIdleMode.Name = "toggleSwitchIdleMode";
            this.toggleSwitchIdleMode.Properties.OffText = "don\'t enable idle mode";
            this.toggleSwitchIdleMode.Properties.OnText = "Idle mode: ignore incoming messages when user is idle";
            this.toggleSwitchIdleMode.Size = new System.Drawing.Size(767, 28);
            this.toggleSwitchIdleMode.TabIndex = 9;
            // 
            // ApplicationGeneralSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.gcCompressedArchives);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.gcGeneral);
            this.Controls.Add(this.gcSettingsLocation);
            this.Name = "ApplicationGeneralSettingsUC";
            this.Size = new System.Drawing.Size(786, 643);
            this.Load += new System.EventHandler(this.ApplicationGeneralSettingsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcCompressedArchives)).EndInit();
            this.gcCompressedArchives.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tsEnableCompressedArchive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGeneral)).EndInit();
            this.gcGeneral.ResumeLayout(false);
            this.gcGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecentFolders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecentFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRealTimeRefreshInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsWhatsNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsCheckAdditionalInformation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsAutoComplete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoCompleteCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsTraybar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsFileCaching.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsSingleInstance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSettingsLocation)).EndInit();
            this.gcSettingsLocation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceSettingsLocationApplicationFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSettingsLocationPerUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdleTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitchIdleMode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcCompressedArchives;
        private DevExpress.XtraEditors.ToggleSwitch tsEnableCompressedArchive;
        private DevExpress.XtraEditors.GroupControl gcGeneral;
        private System.Windows.Forms.NumericUpDown nudRealTimeRefreshInterval;
        private DevExpress.XtraEditors.LabelControl lblRealTimeRefreshInterval;
        private DevExpress.XtraEditors.ToggleSwitch tsWhatsNew;
        private DevExpress.XtraEditors.ToggleSwitch tsCheckAdditionalInformation;
        private DevExpress.XtraEditors.ToggleSwitch tsAutoComplete;
        private System.Windows.Forms.NumericUpDown nudAutoCompleteCount;
        private DevExpress.XtraEditors.ToggleSwitch tsTraybar;
        private DevExpress.XtraEditors.ToggleSwitch tsFileCaching;
        private DevExpress.XtraEditors.ToggleSwitch tsSingleInstance;
        private DevExpress.XtraEditors.GroupControl gcSettingsLocation;
        private DevExpress.XtraEditors.CheckEdit ceSettingsLocationPerUser;
        private DevExpress.XtraEditors.CheckEdit ceSettingsLocationApplicationFolder;
        private DevExpress.XtraEditors.LabelControl lblRecentFolders;
        private DevExpress.XtraEditors.LabelControl lblRecent;
        private System.Windows.Forms.NumericUpDown nudRecentFolders;
        private System.Windows.Forms.NumericUpDown nudRecentFiles;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.NumericUpDown nudIdleTime;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitchIdleMode;
    }
}
