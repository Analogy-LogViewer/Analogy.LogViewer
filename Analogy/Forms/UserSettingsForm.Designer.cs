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
            this.xtraTabPageDebugging = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).BeginInit();
            this.tabControlMain.SuspendLayout();
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
            this.tabControlMain.Size = new System.Drawing.Size(991, 942);
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
            this.xtraTabPageApplication.Size = new System.Drawing.Size(817, 935);
            this.xtraTabPageApplication.Text = "Application Settings";
            // 
            // xtraTabPageFilter
            // 
            this.xtraTabPageFilter.AutoScroll = true;
            this.xtraTabPageFilter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPageFilter.ImageOptions.Image")));
            this.xtraTabPageFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPageFilter.Name = "xtraTabPageFilter";
            this.xtraTabPageFilter.Size = new System.Drawing.Size(817, 934);
            this.xtraTabPageFilter.Text = "Filtering";
            // 
            // xtraTabPagePreDefined
            // 
            this.xtraTabPagePreDefined.AutoScroll = true;
            this.xtraTabPagePreDefined.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPagePreDefined.ImageOptions.Image")));
            this.xtraTabPagePreDefined.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtraTabPagePreDefined.Name = "xtraTabPagePreDefined";
            this.xtraTabPagePreDefined.Size = new System.Drawing.Size(817, 934);
            this.xtraTabPagePreDefined.Text = "Pre-Defined Queries";
            // 
            // tpColors
            // 
            this.tpColors.AutoScroll = true;
            this.tpColors.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tpColors.ImageOptions.Image")));
            this.tpColors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tpColors.Name = "tpColors";
            this.tpColors.Size = new System.Drawing.Size(817, 934);
            this.tpColors.Text = "Colors and Layout";
            // 
            // xtShortcuts
            // 
            this.xtShortcuts.AutoScroll = true;
            this.xtShortcuts.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtShortcuts.ImageOptions.Image")));
            this.xtShortcuts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtShortcuts.Name = "xtShortcuts";
            this.xtShortcuts.Size = new System.Drawing.Size(817, 934);
            this.xtShortcuts.Text = "Shortcuts";
            // 
            // xTabMRU
            // 
            this.xTabMRU.AutoScroll = true;
            this.xTabMRU.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xTabMRU.ImageOptions.Image")));
            this.xTabMRU.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xTabMRU.Name = "xTabMRU";
            this.xTabMRU.Size = new System.Drawing.Size(817, 934);
            this.xTabMRU.Text = "Most Recently Used";
            // 
            // xtraTabPageResources
            // 
            this.xtraTabPageResources.AutoScroll = true;
            this.xtraTabPageResources.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPageResources.ImageOptions.Image")));
            this.xtraTabPageResources.Name = "xtraTabPageResources";
            this.xtraTabPageResources.Size = new System.Drawing.Size(817, 934);
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
            this.xtraTabPageUpdates.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPageUpdates.ImageOptions.Image")));
            this.xtraTabPageUpdates.Name = "xtraTabPageUpdates";
            this.xtraTabPageUpdates.Size = new System.Drawing.Size(817, 935);
            this.xtraTabPageUpdates.Text = "Updates";
            // 
            // xtraTabPageDebugging
            // 
            this.xtraTabPageDebugging.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPageDebugging.ImageOptions.Image")));
            this.xtraTabPageDebugging.Name = "xtraTabPageDebugging";
            this.xtraTabPageDebugging.Size = new System.Drawing.Size(817, 935);
            this.xtraTabPageDebugging.Text = "Debugging";
            // 
            // UserSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 942);
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
        private DevExpress.XtraTab.XtraTabPage xtraTabPageDebugging;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageExtension;
    }
}