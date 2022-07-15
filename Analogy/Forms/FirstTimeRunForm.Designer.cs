namespace Analogy.Forms
{
    partial class FirstTimeRunForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstTimeRunForm));
            DevExpress.XtraEditors.TableLayout.ItemTemplateBase itemTemplateBase1 = new DevExpress.XtraEditors.TableLayout.ItemTemplateBase();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement1 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement2 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement3 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan1 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tpWelcome = new DevExpress.XtraTab.XtraTabPage();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.tpSettings = new DevExpress.XtraTab.XtraTabPage();
            this.pictureEdit3 = new DevExpress.XtraEditors.PictureEdit();
            this.tpDataProviders = new DevExpress.XtraTab.XtraTabPage();
            this.chkLstDataProviderStatus = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.lblDataProviders = new DevExpress.XtraEditors.LabelControl();
            this.tpFinish = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.hyperLinkEdit2 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.pnlBottom1 = new DevExpress.XtraEditors.PanelControl();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.stepProgressBar1 = new DevExpress.XtraEditors.StepProgressBar();
            this.spbiWelcome = new DevExpress.XtraEditors.StepProgressBarItem();
            this.spbiSettings = new DevExpress.XtraEditors.StepProgressBarItem();
            this.spbiThemes = new DevExpress.XtraEditors.StepProgressBarItem();
            this.spbiDataProviders = new DevExpress.XtraEditors.StepProgressBarItem();
            this.tpTheme = new DevExpress.XtraTab.XtraTabPage();
            this.spbiDone = new DevExpress.XtraEditors.StepProgressBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tpWelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.tpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).BeginInit();
            this.tpDataProviders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstDataProviderStatus)).BeginInit();
            this.tpFinish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom1)).BeginInit();
            this.pnlBottom1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stepProgressBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 140);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tpWelcome;
            this.xtraTabControl1.Size = new System.Drawing.Size(1317, 364);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpWelcome,
            this.tpSettings,
            this.tpTheme,
            this.tpDataProviders,
            this.tpFinish});
            // 
            // tpWelcome
            // 
            this.tpWelcome.Controls.Add(this.memoEdit1);
            this.tpWelcome.Controls.Add(this.pictureEdit1);
            this.tpWelcome.Name = "tpWelcome";
            this.tpWelcome.Size = new System.Drawing.Size(1315, 334);
            this.tpWelcome.Text = "Welcome";
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit1.EditValue = resources.GetString("memoEdit1.EditValue");
            this.memoEdit1.Location = new System.Drawing.Point(336, 0);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(979, 334);
            this.memoEdit1.TabIndex = 1;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureEdit1.EditValue = global::Analogy.Properties.Resources.Analogy512x512;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ReadOnly = true;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEdit1.Properties.ShowMenu = false;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(336, 334);
            this.pictureEdit1.TabIndex = 0;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.pictureEdit3);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Size = new System.Drawing.Size(1315, 334);
            this.tpSettings.Text = "Settings";
            // 
            // pictureEdit3
            // 
            this.pictureEdit3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureEdit3.EditValue = global::Analogy.Properties.Resources.SettingsMenu;
            this.pictureEdit3.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit3.Name = "pictureEdit3";
            this.pictureEdit3.Properties.ReadOnly = true;
            this.pictureEdit3.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEdit3.Properties.ShowMenu = false;
            this.pictureEdit3.Size = new System.Drawing.Size(414, 334);
            this.pictureEdit3.TabIndex = 5;
            // 
            // tpDataProviders
            // 
            this.tpDataProviders.Controls.Add(this.chkLstDataProviderStatus);
            this.tpDataProviders.Controls.Add(this.lblDataProviders);
            this.tpDataProviders.Name = "tpDataProviders";
            this.tpDataProviders.Size = new System.Drawing.Size(1315, 334);
            this.tpDataProviders.Text = "Data Providers";
            // 
            // chkLstDataProviderStatus
            // 
            this.chkLstDataProviderStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLstDataProviderStatus.ItemHeight = 62;
            this.chkLstDataProviderStatus.Location = new System.Drawing.Point(0, 36);
            this.chkLstDataProviderStatus.Name = "chkLstDataProviderStatus";
            this.chkLstDataProviderStatus.Size = new System.Drawing.Size(1315, 298);
            this.chkLstDataProviderStatus.TabIndex = 16;
            tableColumnDefinition1.Length.Value = 70D;
            tableColumnDefinition2.Length.Value = 660D;
            itemTemplateBase1.Columns.Add(tableColumnDefinition1);
            itemTemplateBase1.Columns.Add(tableColumnDefinition2);
            templatedItemElement1.FieldName = null;
            templatedItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement1.Text = "";
            templatedItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement2.Appearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            templatedItemElement2.Appearance.Normal.ForeColor = System.Drawing.Color.Blue;
            templatedItemElement2.Appearance.Normal.Options.UseFont = true;
            templatedItemElement2.Appearance.Normal.Options.UseForeColor = true;
            templatedItemElement2.ColumnIndex = 1;
            templatedItemElement2.FieldName = null;
            templatedItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement2.Text = "Name";
            templatedItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            templatedItemElement3.ColumnIndex = 1;
            templatedItemElement3.FieldName = null;
            templatedItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement3.RowIndex = 1;
            templatedItemElement3.Text = "description";
            templatedItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            itemTemplateBase1.Elements.Add(templatedItemElement1);
            itemTemplateBase1.Elements.Add(templatedItemElement2);
            itemTemplateBase1.Elements.Add(templatedItemElement3);
            itemTemplateBase1.Name = "template1";
            itemTemplateBase1.Rows.Add(tableRowDefinition1);
            itemTemplateBase1.Rows.Add(tableRowDefinition2);
            tableSpan1.RowSpan = 2;
            itemTemplateBase1.Spans.Add(tableSpan1);
            this.chkLstDataProviderStatus.Templates.Add(itemTemplateBase1);
            // 
            // lblDataProviders
            // 
            this.lblDataProviders.AutoEllipsis = true;
            this.lblDataProviders.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblDataProviders.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDataProviders.Location = new System.Drawing.Point(0, 0);
            this.lblDataProviders.Margin = new System.Windows.Forms.Padding(5);
            this.lblDataProviders.Name = "lblDataProviders";
            this.lblDataProviders.Padding = new System.Windows.Forms.Padding(3, 10, 10, 10);
            this.lblDataProviders.Size = new System.Drawing.Size(1315, 36);
            this.lblDataProviders.TabIndex = 13;
            this.lblDataProviders.Text = "A default setup of data providers was set.  You can change this setup by enabling" +
    "/disabling any data providers. You can change the selection later on in the sett" +
    "ings window.";
            // 
            // tpFinish
            // 
            this.tpFinish.Controls.Add(this.labelControl3);
            this.tpFinish.Controls.Add(this.btnOK);
            this.tpFinish.Controls.Add(this.labelControl2);
            this.tpFinish.Controls.Add(this.hyperLinkEdit2);
            this.tpFinish.Controls.Add(this.labelControl1);
            this.tpFinish.Controls.Add(this.hyperLinkEdit1);
            this.tpFinish.Name = "tpFinish";
            this.tpFinish.Size = new System.Drawing.Size(1315, 334);
            this.tpFinish.Text = "Done";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.AutoEllipsis = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl3.Location = new System.Drawing.Point(0, 1);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Padding = new System.Windows.Forms.Padding(3, 10, 10, 10);
            this.labelControl3.Size = new System.Drawing.Size(1188, 36);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "You can visit the Github repositories for more information:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(1196, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(115, 34);
            this.btnOK.TabIndex = 8;
            this.btnOK.Tag = "2";
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.AcceptAndClose);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 77);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(238, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "For a complete list of data providers visit:";
            // 
            // hyperLinkEdit2
            // 
            this.hyperLinkEdit2.EditValue = "https://github.com/Analogy-LogViewer/Analogy";
            this.hyperLinkEdit2.Location = new System.Drawing.Point(334, 74);
            this.hyperLinkEdit2.Name = "hyperLinkEdit2";
            this.hyperLinkEdit2.Size = new System.Drawing.Size(774, 22);
            this.hyperLinkEdit2.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 50);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(227, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Primary Analogy Log Viewer repository:";
            // 
            // hyperLinkEdit1
            // 
            this.hyperLinkEdit1.EditValue = "https://github.com/Analogy-LogViewer/Analogy.LogViewer";
            this.hyperLinkEdit1.Location = new System.Drawing.Point(334, 47);
            this.hyperLinkEdit1.Name = "hyperLinkEdit1";
            this.hyperLinkEdit1.Size = new System.Drawing.Size(774, 22);
            this.hyperLinkEdit1.TabIndex = 0;
            // 
            // pnlBottom1
            // 
            this.pnlBottom1.Controls.Add(this.btnNext);
            this.pnlBottom1.Controls.Add(this.btnBack);
            this.pnlBottom1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom1.Location = new System.Drawing.Point(0, 504);
            this.pnlBottom1.Name = "pnlBottom1";
            this.pnlBottom1.Size = new System.Drawing.Size(1317, 50);
            this.pnlBottom1.TabIndex = 3;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(1197, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(115, 34);
            this.btnNext.TabIndex = 2;
            this.btnNext.Tag = "0";
            this.btnNext.Text = "Next";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(5, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(115, 34);
            this.btnBack.TabIndex = 8;
            this.btnBack.Tag = "2";
            this.btnBack.Text = "Back";
            // 
            // stepProgressBar1
            // 
            this.stepProgressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.stepProgressBar1.IndentBetweenItems = 31;
            this.stepProgressBar1.Items.Add(this.spbiWelcome);
            this.stepProgressBar1.Items.Add(this.spbiSettings);
            this.stepProgressBar1.Items.Add(this.spbiThemes);
            this.stepProgressBar1.Items.Add(this.spbiDataProviders);
            this.stepProgressBar1.Items.Add(this.spbiDone);
            this.stepProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.stepProgressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stepProgressBar1.Name = "stepProgressBar1";
            this.stepProgressBar1.Size = new System.Drawing.Size(1317, 140);
            this.stepProgressBar1.TabIndex = 2;
            // 
            // spbiWelcome
            // 
            this.spbiWelcome.ContentBlock1.ActiveStateImageOptions.Image = global::Analogy.Properties.Resources.Analogy_icon1;
            this.spbiWelcome.ContentBlock1.InactiveStateImageOptions.Image = global::Analogy.Properties.Resources.Analogy_icon1;
            this.spbiWelcome.ContentBlock2.Caption = "Welcome";
            this.spbiWelcome.Name = "spbiWelcome";
            this.spbiWelcome.Options.Indicator.ActiveStateImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("spbiWelcome.Options.Indicator.ActiveStateImageOptions.Image")));
            // 
            // spbiSettings
            // 
            this.spbiSettings.ContentBlock1.ActiveStateImageOptions.Image = global::Analogy.Properties.Resources.Technology_32x32;
            this.spbiSettings.ContentBlock1.InactiveStateImageOptions.Image = global::Analogy.Properties.Resources.Technology_32x32;
            this.spbiSettings.ContentBlock2.Caption = "Settings";
            this.spbiSettings.Name = "spbiSettings";
            this.spbiSettings.Options.Indicator.ActiveStateImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("spbiSettings.Options.Indicator.ActiveStateImageOptions.Image")));
            this.spbiSettings.Options.Indicator.AutoCropImage = DevExpress.Utils.DefaultBoolean.True;
            // 
            // spbiThemes
            // 
            this.spbiThemes.ContentBlock1.ActiveStateImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("spbiThemes.ContentBlock1.ActiveStateImageOptions.Image")));
            this.spbiThemes.ContentBlock1.InactiveStateImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("spbiThemes.ContentBlock1.InactiveStateImageOptions.Image")));
            this.spbiThemes.ContentBlock2.Caption = "Themes";
            this.spbiThemes.ContentBlock2.Description = "Set Initial Theme  and Skin";
            this.spbiThemes.Name = "spbiThemes";
            // 
            // spbiDataProviders
            // 
            this.spbiDataProviders.ContentBlock1.ActiveStateImageOptions.Image = global::Analogy.Properties.Resources.Analogy_Icon2;
            this.spbiDataProviders.ContentBlock1.InactiveStateImageOptions.Image = global::Analogy.Properties.Resources.Analogy_Icon2;
            this.spbiDataProviders.ContentBlock2.Caption = "Data Providers";
            this.spbiDataProviders.ContentBlock2.Description = "set initial selection";
            this.spbiDataProviders.Name = "spbiDataProviders";
            this.spbiDataProviders.Options.Indicator.ActiveStateImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("spbiDataProviders.Options.Indicator.ActiveStateImageOptions.Image")));
            // 
            // tpTheme
            // 
            this.tpTheme.Name = "tpTheme";
            this.tpTheme.Size = new System.Drawing.Size(1315, 334);
            this.tpTheme.Text = "Themes";
            // 
            // spbiDone
            // 
            this.spbiDone.ContentBlock1.ActiveStateImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("spbiDone.ContentBlock1.ActiveStateImageOptions.Image")));
            this.spbiDone.ContentBlock1.InactiveStateImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("spbiDone.ContentBlock1.InactiveStateImageOptions.Image")));
            this.spbiDone.ContentBlock2.Caption = "Done";
            this.spbiDone.Name = "spbiDone";
            // 
            // FirstTimeRunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 554);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.pnlBottom1);
            this.Controls.Add(this.stepProgressBar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FirstTimeRunForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analogy Log Viewer: First Run";
            this.Load += new System.EventHandler(this.FirstTimeRunForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tpWelcome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.tpSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).EndInit();
            this.tpDataProviders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkLstDataProviderStatus)).EndInit();
            this.tpFinish.ResumeLayout(false);
            this.tpFinish.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom1)).EndInit();
            this.pnlBottom1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stepProgressBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tpWelcome;
        private DevExpress.XtraTab.XtraTabPage tpDataProviders;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraTab.XtraTabPage tpSettings;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.PictureEdit pictureEdit3;
        private DevExpress.XtraTab.XtraTabPage tpFinish;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;
        private DevExpress.XtraEditors.LabelControl lblDataProviders;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl pnlBottom1;
        private DevExpress.XtraEditors.CheckedListBoxControl chkLstDataProviderStatus;
        private DevExpress.XtraEditors.StepProgressBar stepProgressBar1;
        private DevExpress.XtraEditors.StepProgressBarItem spbiWelcome;
        private DevExpress.XtraEditors.StepProgressBarItem spbiSettings;
        private DevExpress.XtraEditors.StepProgressBarItem spbiDataProviders;
        private DevExpress.XtraEditors.StepProgressBarItem spbiThemes;
        private DevExpress.XtraTab.XtraTabPage tpTheme;
        private DevExpress.XtraEditors.StepProgressBarItem spbiDone;
    }
}