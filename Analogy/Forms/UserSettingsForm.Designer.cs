namespace Analogy.Forms
{
    partial class UserSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSettingsForm));
            this.tabControlMain = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageApplication = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageFilter = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPagePreDefined = new DevExpress.XtraTab.XtraTabPage();
            this.tpColors = new DevExpress.XtraTab.XtraTabPage();
            this.xtShortcuts = new DevExpress.XtraTab.XtraTabPage();
            this.xTabMRU = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageResources = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageDataProviders = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageExtension = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageUpdates = new DevExpress.XtraTab.XtraTabPage();
            this.gcIntervals = new DevExpress.XtraEditors.GroupControl();
            this.lblDisableUpdates = new DevExpress.XtraEditors.LabelControl();
            this.cbUpdates = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblUpdates = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPageDebugging = new DevExpress.XtraTab.XtraTabPage();
            this.tsEnableFirstChanceException = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.xtraTabPageUpdates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcIntervals)).BeginInit();
            this.gcIntervals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbUpdates.Properties)).BeginInit();
            this.xtraTabPageDebugging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsEnableFirstChanceException.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.tabControlMain.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlMain.MinimumSize = new System.Drawing.Size(814, 382);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedTabPage = this.xtraTabPageApplication;
            this.tabControlMain.Size = new System.Drawing.Size(991, 941);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageApplication,
            this.xtraTabPageFilter,
            this.xtraTabPagePreDefined,
            this.tpColors,
            this.xtShortcuts,
            this.xTabMRU,
            this.xtraTabPageResources,
            this.xtraTabPageDataProviders,
            this.xtraTabPageExtension,
            this.xtraTabPageUpdates,
            this.xtraTabPageDebugging});
            // 
            // xtraTabPageApplication
            // 
            this.xtraTabPageApplication.AutoScroll = true;
            this.xtraTabPageApplication.ImageOptions.Image = global::Analogy.Properties.Resources.Analogy_icon1;
            this.xtraTabPageApplication.Name = "xtraTabPageApplication";
            this.xtraTabPageApplication.Size = new System.Drawing.Size(817, 934);
            this.xtraTabPageApplication.Text = "Application Settings";
            // 
            // xtraTabPageFilter
            // 
            this.xtraTabPageFilter.AutoScroll = true;
            this.xtraTabPageFilter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPageFilter.ImageOptions.Image")));
            this.xtraTabPageFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPageFilter.Name = "xtraTabPageFilter";
            this.xtraTabPageFilter.Size = new System.Drawing.Size(817, 933);
            this.xtraTabPageFilter.Text = "Filtering";
            // 
            // xtraTabPagePreDefined
            // 
            this.xtraTabPagePreDefined.AutoScroll = true;
            this.xtraTabPagePreDefined.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPagePreDefined.ImageOptions.Image")));
            this.xtraTabPagePreDefined.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPagePreDefined.Name = "xtraTabPagePreDefined";
            this.xtraTabPagePreDefined.Size = new System.Drawing.Size(817, 933);
            this.xtraTabPagePreDefined.Text = "Pre-Defined Queries";
            // 
            // tpColors
            // 
            this.tpColors.AutoScroll = true;
            this.tpColors.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tpColors.ImageOptions.Image")));
            this.tpColors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpColors.Name = "tpColors";
            this.tpColors.Size = new System.Drawing.Size(817, 933);
            this.tpColors.Text = "Colors and Layout";
            // 
            // xtShortcuts
            // 
            this.xtShortcuts.AutoScroll = true;
            this.xtShortcuts.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtShortcuts.ImageOptions.Image")));
            this.xtShortcuts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtShortcuts.Name = "xtShortcuts";
            this.xtShortcuts.Size = new System.Drawing.Size(817, 933);
            this.xtShortcuts.Text = "Shortcuts";
            // 
            // xTabMRU
            // 
            this.xTabMRU.AutoScroll = true;
            this.xTabMRU.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xTabMRU.ImageOptions.Image")));
            this.xTabMRU.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xTabMRU.Name = "xTabMRU";
            this.xTabMRU.Size = new System.Drawing.Size(817, 933);
            this.xTabMRU.Text = "Most Recently Used";
            // 
            // xtraTabPageResources
            // 
            this.xtraTabPageResources.AutoScroll = true;
            this.xtraTabPageResources.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPageResources.ImageOptions.Image")));
            this.xtraTabPageResources.Name = "xtraTabPageResources";
            this.xtraTabPageResources.Size = new System.Drawing.Size(817, 933);
            this.xtraTabPageResources.Text = "Resources Usage";
            // 
            // xtraTabPageDataProviders
            // 
            this.xtraTabPageDataProviders.AutoScroll = true;
            this.xtraTabPageDataProviders.ImageOptions.Image = global::Analogy.Properties.Resources.Analogy_Icon2;
            this.xtraTabPageDataProviders.Name = "xtraTabPageDataProviders";
            this.xtraTabPageDataProviders.Size = new System.Drawing.Size(817, 934);
            this.xtraTabPageDataProviders.Text = "Data Providers";
            // 
            // xtraTabPageExtension
            // 
            this.xtraTabPageExtension.ImageOptions.Image = global::Analogy.Properties.Resources.extension32;
            this.xtraTabPageExtension.Name = "xtraTabPageExtension";
            this.xtraTabPageExtension.Size = new System.Drawing.Size(817, 934);
            this.xtraTabPageExtension.Text = "Extensions";
            // 
            // xtraTabPageUpdates
            // 
            this.xtraTabPageUpdates.AutoScroll = true;
            this.xtraTabPageUpdates.Controls.Add(this.gcIntervals);
            this.xtraTabPageUpdates.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPageUpdates.ImageOptions.Image")));
            this.xtraTabPageUpdates.Name = "xtraTabPageUpdates";
            this.xtraTabPageUpdates.Size = new System.Drawing.Size(817, 934);
            this.xtraTabPageUpdates.Text = "Updates";
            // 
            // gcIntervals
            // 
            this.gcIntervals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcIntervals.Controls.Add(this.lblDisableUpdates);
            this.gcIntervals.Controls.Add(this.cbUpdates);
            this.gcIntervals.Controls.Add(this.lblUpdates);
            this.gcIntervals.Location = new System.Drawing.Point(5, 10);
            this.gcIntervals.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcIntervals.Name = "gcIntervals";
            this.gcIntervals.Size = new System.Drawing.Size(781, 134);
            this.gcIntervals.TabIndex = 6;
            this.gcIntervals.Text = "General";
            // 
            // lblDisableUpdates
            // 
            this.lblDisableUpdates.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblDisableUpdates.Appearance.Options.UseForeColor = true;
            this.lblDisableUpdates.Location = new System.Drawing.Point(5, 69);
            this.lblDisableUpdates.Name = "lblDisableUpdates";
            this.lblDisableUpdates.Size = new System.Drawing.Size(297, 16);
            this.lblDisableUpdates.TabIndex = 14;
            this.lblDisableUpdates.Text = "Updates are disabled due to data provider overrides";
            this.lblDisableUpdates.Visible = false;
            // 
            // cbUpdates
            // 
            this.cbUpdates.Location = new System.Drawing.Point(322, 35);
            this.cbUpdates.Name = "cbUpdates";
            this.cbUpdates.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUpdates.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbUpdates.Size = new System.Drawing.Size(198, 22);
            this.cbUpdates.TabIndex = 13;
            // 
            // lblUpdates
            // 
            this.lblUpdates.Location = new System.Drawing.Point(5, 38);
            this.lblUpdates.Name = "lblUpdates";
            this.lblUpdates.Size = new System.Drawing.Size(235, 16);
            this.lblUpdates.TabIndex = 12;
            this.lblUpdates.Text = "Choose interval for checking for updates:";
            // 
            // xtraTabPageDebugging
            // 
            this.xtraTabPageDebugging.Controls.Add(this.tsEnableFirstChanceException);
            this.xtraTabPageDebugging.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPageDebugging.ImageOptions.Image")));
            this.xtraTabPageDebugging.Name = "xtraTabPageDebugging";
            this.xtraTabPageDebugging.Size = new System.Drawing.Size(817, 933);
            this.xtraTabPageDebugging.Text = "Debugging";
            // 
            // tsEnableFirstChanceException
            // 
            this.tsEnableFirstChanceException.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsEnableFirstChanceException.EditValue = true;
            this.tsEnableFirstChanceException.Location = new System.Drawing.Point(17, 10);
            this.tsEnableFirstChanceException.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsEnableFirstChanceException.Name = "tsEnableFirstChanceException";
            this.tsEnableFirstChanceException.Properties.OffText = "First Chance Exception logging is disabled";
            this.tsEnableFirstChanceException.Properties.OnText = "First Chance Exception logging is enabled";
            this.tsEnableFirstChanceException.Size = new System.Drawing.Size(767, 28);
            this.tsEnableFirstChanceException.TabIndex = 3;
            // 
            // UserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 941);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserSettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserSettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.UserSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.xtraTabPageUpdates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcIntervals)).EndInit();
            this.gcIntervals.ResumeLayout(false);
            this.gcIntervals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbUpdates.Properties)).EndInit();
            this.xtraTabPageDebugging.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tsEnableFirstChanceException.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabControlMain;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageFilter;
        private DevExpress.XtraTab.XtraTabPage xtraTabPagePreDefined;
        private DevExpress.XtraTab.XtraTabPage tpColors;
        private DevExpress.XtraTab.XtraTabPage xtShortcuts;
        private DevExpress.XtraTab.XtraTabPage xTabMRU;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageResources;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDataProviders;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageApplication;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageUpdates;
        private DevExpress.XtraEditors.GroupControl gcIntervals;
        private DevExpress.XtraEditors.LabelControl lblUpdates;
        private DevExpress.XtraEditors.ComboBoxEdit cbUpdates;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDebugging;
        private DevExpress.XtraEditors.ToggleSwitch tsEnableFirstChanceException;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageExtension;
        private DevExpress.XtraEditors.LabelControl lblDisableUpdates;
    }
}