namespace Analogy
{
    partial class UserSettingsDataProvidersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSettingsDataProvidersForm));
            this.tabControlMain = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageNLog = new DevExpress.XtraTab.XtraTabPage();
            this.btnExportNLogSettings = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportNLogSettings = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.textEditNLogExtension = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.spltNlogParser = new DevExpress.XtraEditors.SplitContainerControl();
            this.lstBAnalogyColumnsNlog = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.sBtnMoveUpNlog = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnMoveDownNlog = new DevExpress.XtraEditors.SimpleButton();
            this.lstBoxItemsNlog = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.sBtnSaveNlogMapping = new DevExpress.XtraEditors.SimpleButton();
            this.txtNLogSeperator = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtNLogLayout = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.sbtnNLogCheckLayout = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageSerilog = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPageLog4Net = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPageJson = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.spltJSonParser = new DevExpress.XtraEditors.SplitContainerControl();
            this.listBoxControlAnalogyJson = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.sBtnMoveUpJson = new DevExpress.XtraEditors.SimpleButton();
            this.sBtnMoveDownJson = new DevExpress.XtraEditors.SimpleButton();
            this.listBoxControlJson = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textEditJsonFile = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sBtnLoadXMLFile = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPageXML = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPageWindowsEventLogs = new DevExpress.XtraTab.XtraTabPage();
            this.xtraUCWindowsEventLogs1 = new Analogy.XtraUCWindowsEventLogs();
            this.lblWindowsEventLogs = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.xtraTabPageNLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNLogExtension.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltNlogParser)).BeginInit();
            this.spltNlogParser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstBAnalogyColumnsNlog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxItemsNlog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNLogSeperator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNLogLayout.Properties)).BeginInit();
            this.xtraTabPageSerilog.SuspendLayout();
            this.xtraTabPageLog4Net.SuspendLayout();
            this.xtraTabPageJson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltJSonParser)).BeginInit();
            this.spltJSonParser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlAnalogyJson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlJson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditJsonFile.Properties)).BeginInit();
            this.xtraTabPageXML.SuspendLayout();
            this.xtraTabPageWindowsEventLogs.SuspendLayout();
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
            this.tabControlMain.SelectedTabPage = this.xtraTabPageNLog;
            this.tabControlMain.Size = new System.Drawing.Size(945, 569);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageNLog,
            this.xtraTabPageSerilog,
            this.xtraTabPageLog4Net,
            this.xtraTabPageJson,
            this.xtraTabPageXML,
            this.xtraTabPageWindowsEventLogs});
            // 
            // xtraTabPageNLog
            // 
            this.xtraTabPageNLog.Controls.Add(this.btnExportNLogSettings);
            this.xtraTabPageNLog.Controls.Add(this.btnImportNLogSettings);
            this.xtraTabPageNLog.Controls.Add(this.labelControl5);
            this.xtraTabPageNLog.Controls.Add(this.textEditNLogExtension);
            this.xtraTabPageNLog.Controls.Add(this.labelControl4);
            this.xtraTabPageNLog.Controls.Add(this.spltNlogParser);
            this.xtraTabPageNLog.Controls.Add(this.sBtnSaveNlogMapping);
            this.xtraTabPageNLog.Controls.Add(this.txtNLogSeperator);
            this.xtraTabPageNLog.Controls.Add(this.labelControl8);
            this.xtraTabPageNLog.Controls.Add(this.txtNLogLayout);
            this.xtraTabPageNLog.Controls.Add(this.labelControl7);
            this.xtraTabPageNLog.Controls.Add(this.sbtnNLogCheckLayout);
            this.xtraTabPageNLog.ImageOptions.Image = global::Analogy.Properties.Resources.nlog;
            this.xtraTabPageNLog.Name = "xtraTabPageNLog";
            this.xtraTabPageNLog.Size = new System.Drawing.Size(772, 562);
            this.xtraTabPageNLog.Text = "NLog Parser";
            // 
            // btnExportNLogSettings
            // 
            this.btnExportNLogSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportNLogSettings.Location = new System.Drawing.Point(538, 520);
            this.btnExportNLogSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportNLogSettings.Name = "btnExportNLogSettings";
            this.btnExportNLogSettings.Size = new System.Drawing.Size(111, 37);
            this.btnExportNLogSettings.TabIndex = 14;
            this.btnExportNLogSettings.Text = "Export Settings";
            this.btnExportNLogSettings.Click += new System.EventHandler(this.btnExportNLogSettings_Click);
            // 
            // btnImportNLogSettings
            // 
            this.btnImportNLogSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportNLogSettings.Location = new System.Drawing.Point(658, 53);
            this.btnImportNLogSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImportNLogSettings.Name = "btnImportNLogSettings";
            this.btnImportNLogSettings.Size = new System.Drawing.Size(111, 37);
            this.btnImportNLogSettings.TabIndex = 13;
            this.btnImportNLogSettings.Text = "Import settings";
            this.btnImportNLogSettings.Click += new System.EventHandler(this.btnImportNLogSettings_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(145, 95);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(217, 16);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Use ; as seperator (e.g: *.nlog;*.log)";
            // 
            // textEditNLogExtension
            // 
            this.textEditNLogExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditNLogExtension.EditValue = "*.nlog";
            this.textEditNLogExtension.Location = new System.Drawing.Point(145, 68);
            this.textEditNLogExtension.Name = "textEditNLogExtension";
            this.textEditNLogExtension.Size = new System.Drawing.Size(503, 22);
            this.textEditNLogExtension.TabIndex = 11;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(3, 71);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(110, 16);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "NLog File Extension";
            // 
            // spltNlogParser
            // 
            this.spltNlogParser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spltNlogParser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.spltNlogParser.Location = new System.Drawing.Point(13, 146);
            this.spltNlogParser.Name = "spltNlogParser";
            this.spltNlogParser.Panel1.Controls.Add(this.lstBAnalogyColumnsNlog);
            this.spltNlogParser.Panel1.Controls.Add(this.labelControl9);
            this.spltNlogParser.Panel1.Controls.Add(this.splitContainerControl2);
            this.spltNlogParser.Panel1.Text = "Panel1";
            this.spltNlogParser.Panel2.Controls.Add(this.lstBoxItemsNlog);
            this.spltNlogParser.Panel2.Controls.Add(this.labelControl10);
            this.spltNlogParser.Panel2.Text = "Panel2";
            this.spltNlogParser.Size = new System.Drawing.Size(744, 369);
            this.spltNlogParser.SplitterPosition = 191;
            this.spltNlogParser.TabIndex = 9;
            // 
            // lstBAnalogyColumnsNlog
            // 
            this.lstBAnalogyColumnsNlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBAnalogyColumnsNlog.Items.AddRange(new object[] {
            "Date",
            "Text",
            "Source",
            "Module",
            "MethodName",
            "FileName",
            "User",
            "LineNumber",
            "ProcessID",
            "Thread",
            "Level",
            "Class",
            "Category",
            "ID",
            "__ignore__",
            "__ignore__",
            "__ignore__",
            "__ignore__",
            "__ignore__",
            "__ignore__",
            "__ignore__"});
            this.lstBAnalogyColumnsNlog.Location = new System.Drawing.Point(44, 16);
            this.lstBAnalogyColumnsNlog.Name = "lstBAnalogyColumnsNlog";
            this.lstBAnalogyColumnsNlog.Size = new System.Drawing.Size(147, 349);
            this.lstBAnalogyColumnsNlog.TabIndex = 0;
            this.lstBAnalogyColumnsNlog.SelectedIndexChanged += new System.EventHandler(this.LstBAnalogyColumns_SelectedIndexChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl9.Location = new System.Drawing.Point(44, 0);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(128, 16);
            this.labelControl9.TabIndex = 7;
            this.labelControl9.Text = "Log message Columns";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.sBtnMoveUpNlog);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.sBtnMoveDownNlog);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(44, 365);
            this.splitContainerControl2.SplitterPosition = 184;
            this.splitContainerControl2.TabIndex = 1;
            // 
            // sBtnMoveUpNlog
            // 
            this.sBtnMoveUpNlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sBtnMoveUpNlog.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sBtnMoveUpNlog.ImageOptions.Image")));
            this.sBtnMoveUpNlog.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.sBtnMoveUpNlog.Location = new System.Drawing.Point(0, 0);
            this.sBtnMoveUpNlog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnMoveUpNlog.Name = "sBtnMoveUpNlog";
            this.sBtnMoveUpNlog.Size = new System.Drawing.Size(44, 184);
            this.sBtnMoveUpNlog.TabIndex = 2;
            this.sBtnMoveUpNlog.Text = "Up";
            this.sBtnMoveUpNlog.Click += new System.EventHandler(this.SBtnMoveUp_Click);
            // 
            // sBtnMoveDownNlog
            // 
            this.sBtnMoveDownNlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sBtnMoveDownNlog.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sBtnMoveDownNlog.ImageOptions.Image")));
            this.sBtnMoveDownNlog.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomLeft;
            this.sBtnMoveDownNlog.Location = new System.Drawing.Point(0, 0);
            this.sBtnMoveDownNlog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnMoveDownNlog.Name = "sBtnMoveDownNlog";
            this.sBtnMoveDownNlog.Size = new System.Drawing.Size(44, 175);
            this.sBtnMoveDownNlog.TabIndex = 3;
            this.sBtnMoveDownNlog.Text = "Down";
            this.sBtnMoveDownNlog.Click += new System.EventHandler(this.SBtnMoveDown_Click);
            // 
            // lstBoxItemsNlog
            // 
            this.lstBoxItemsNlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxItemsNlog.Location = new System.Drawing.Point(0, 16);
            this.lstBoxItemsNlog.Name = "lstBoxItemsNlog";
            this.lstBoxItemsNlog.Size = new System.Drawing.Size(543, 349);
            this.lstBoxItemsNlog.TabIndex = 2;
            // 
            // labelControl10
            // 
            this.labelControl10.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl10.Location = new System.Drawing.Point(0, 0);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(94, 16);
            this.labelControl10.TabIndex = 8;
            this.labelControl10.Text = "Parsed columns.";
            // 
            // sBtnSaveNlogMapping
            // 
            this.sBtnSaveNlogMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sBtnSaveNlogMapping.Location = new System.Drawing.Point(655, 520);
            this.sBtnSaveNlogMapping.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnSaveNlogMapping.Name = "sBtnSaveNlogMapping";
            this.sBtnSaveNlogMapping.Size = new System.Drawing.Size(111, 37);
            this.sBtnSaveNlogMapping.TabIndex = 8;
            this.sBtnSaveNlogMapping.Text = "Save Mapping";
            this.sBtnSaveNlogMapping.Click += new System.EventHandler(this.SBtnSaveNlogMapping_Click);
            // 
            // txtNLogSeperator
            // 
            this.txtNLogSeperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNLogSeperator.EditValue = "|";
            this.txtNLogSeperator.Location = new System.Drawing.Point(145, 39);
            this.txtNLogSeperator.Name = "txtNLogSeperator";
            this.txtNLogSeperator.Size = new System.Drawing.Size(503, 22);
            this.txtNLogSeperator.TabIndex = 7;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(3, 42);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(120, 16);
            this.labelControl8.TabIndex = 6;
            this.labelControl8.Text = "Seperator character:";
            // 
            // txtNLogLayout
            // 
            this.txtNLogLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNLogLayout.Location = new System.Drawing.Point(145, 11);
            this.txtNLogLayout.Name = "txtNLogLayout";
            this.txtNLogLayout.Size = new System.Drawing.Size(503, 22);
            this.txtNLogLayout.TabIndex = 5;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(3, 14);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(104, 16);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "NLog Layout/Row:";
            // 
            // sbtnNLogCheckLayout
            // 
            this.sbtnNLogCheckLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnNLogCheckLayout.Location = new System.Drawing.Point(658, 3);
            this.sbtnNLogCheckLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sbtnNLogCheckLayout.Name = "sbtnNLogCheckLayout";
            this.sbtnNLogCheckLayout.Size = new System.Drawing.Size(111, 37);
            this.sbtnNLogCheckLayout.TabIndex = 1;
            this.sbtnNLogCheckLayout.Text = "Load layout";
            this.sbtnNLogCheckLayout.Click += new System.EventHandler(this.btnNlogCheckLayout_Click);
            // 
            // xtraTabPageSerilog
            // 
            this.xtraTabPageSerilog.Controls.Add(this.labelControl6);
            this.xtraTabPageSerilog.ImageOptions.Image = global::Analogy.Properties.Resources.serilog32x32;
            this.xtraTabPageSerilog.Name = "xtraTabPageSerilog";
            this.xtraTabPageSerilog.Size = new System.Drawing.Size(772, 562);
            this.xtraTabPageSerilog.Text = "Serilog parser";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(10, 10);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(78, 16);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Coming soon.";
            // 
            // xtraTabPageLog4Net
            // 
            this.xtraTabPageLog4Net.Controls.Add(this.labelControl11);
            this.xtraTabPageLog4Net.ImageOptions.Image = global::Analogy.Properties.Resources.log4net32x32;
            this.xtraTabPageLog4Net.Name = "xtraTabPageLog4Net";
            this.xtraTabPageLog4Net.Size = new System.Drawing.Size(772, 562);
            this.xtraTabPageLog4Net.Text = "Log4Net Parser";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(10, 10);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(78, 16);
            this.labelControl11.TabIndex = 14;
            this.labelControl11.Text = "Coming soon.";
            // 
            // xtraTabPageJson
            // 
            this.xtraTabPageJson.Controls.Add(this.labelControl12);
            this.xtraTabPageJson.Controls.Add(this.spltJSonParser);
            this.xtraTabPageJson.Controls.Add(this.textEditJsonFile);
            this.xtraTabPageJson.Controls.Add(this.labelControl1);
            this.xtraTabPageJson.Controls.Add(this.sBtnLoadXMLFile);
            this.xtraTabPageJson.ImageOptions.Image = global::Analogy.Properties.Resources.jsonfile32x32;
            this.xtraTabPageJson.Name = "xtraTabPageJson";
            this.xtraTabPageJson.Size = new System.Drawing.Size(772, 562);
            this.xtraTabPageJson.Text = "Json Parser";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(10, 10);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(78, 16);
            this.labelControl12.TabIndex = 14;
            this.labelControl12.Text = "Coming soon.";
            // 
            // spltJSonParser
            // 
            this.spltJSonParser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spltJSonParser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.spltJSonParser.Location = new System.Drawing.Point(14, 69);
            this.spltJSonParser.Name = "spltJSonParser";
            this.spltJSonParser.Panel1.Controls.Add(this.listBoxControlAnalogyJson);
            this.spltJSonParser.Panel1.Controls.Add(this.labelControl2);
            this.spltJSonParser.Panel1.Controls.Add(this.splitContainerControl3);
            this.spltJSonParser.Panel1.Text = "Panel1";
            this.spltJSonParser.Panel2.Controls.Add(this.listBoxControlJson);
            this.spltJSonParser.Panel2.Controls.Add(this.labelControl3);
            this.spltJSonParser.Panel2.Text = "Panel2";
            this.spltJSonParser.Size = new System.Drawing.Size(771, 429);
            this.spltJSonParser.SplitterPosition = 175;
            this.spltJSonParser.TabIndex = 10;
            this.spltJSonParser.Visible = false;
            // 
            // listBoxControlAnalogyJson
            // 
            this.listBoxControlAnalogyJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxControlAnalogyJson.Items.AddRange(new object[] {
            "Date",
            "Text",
            "Source",
            "Module",
            "MethodName",
            "FileName",
            "User",
            "LineNumber",
            "ProcessID",
            "Thread",
            "Level",
            "Class",
            "Category",
            "ID"});
            this.listBoxControlAnalogyJson.Location = new System.Drawing.Point(44, 16);
            this.listBoxControlAnalogyJson.Name = "listBoxControlAnalogyJson";
            this.listBoxControlAnalogyJson.Size = new System.Drawing.Size(131, 409);
            this.listBoxControlAnalogyJson.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(44, 0);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(122, 16);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Log message Column";
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainerControl3.Horizontal = false;
            this.splitContainerControl3.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.Controls.Add(this.sBtnMoveUpJson);
            this.splitContainerControl3.Panel1.Text = "Panel1";
            this.splitContainerControl3.Panel2.Controls.Add(this.sBtnMoveDownJson);
            this.splitContainerControl3.Panel2.Text = "Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(44, 425);
            this.splitContainerControl3.SplitterPosition = 184;
            this.splitContainerControl3.TabIndex = 1;
            // 
            // sBtnMoveUpJson
            // 
            this.sBtnMoveUpJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sBtnMoveUpJson.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sBtnMoveUpJson.ImageOptions.Image")));
            this.sBtnMoveUpJson.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.sBtnMoveUpJson.Location = new System.Drawing.Point(0, 0);
            this.sBtnMoveUpJson.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnMoveUpJson.Name = "sBtnMoveUpJson";
            this.sBtnMoveUpJson.Size = new System.Drawing.Size(44, 184);
            this.sBtnMoveUpJson.TabIndex = 2;
            this.sBtnMoveUpJson.Text = "Up";
            // 
            // sBtnMoveDownJson
            // 
            this.sBtnMoveDownJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sBtnMoveDownJson.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("sBtnMoveDownJson.ImageOptions.Image")));
            this.sBtnMoveDownJson.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomLeft;
            this.sBtnMoveDownJson.Location = new System.Drawing.Point(0, 0);
            this.sBtnMoveDownJson.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnMoveDownJson.Name = "sBtnMoveDownJson";
            this.sBtnMoveDownJson.Size = new System.Drawing.Size(44, 235);
            this.sBtnMoveDownJson.TabIndex = 3;
            this.sBtnMoveDownJson.Text = "Down";
            // 
            // listBoxControlJson
            // 
            this.listBoxControlJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxControlJson.Location = new System.Drawing.Point(0, 16);
            this.listBoxControlJson.Name = "listBoxControlJson";
            this.listBoxControlJson.Size = new System.Drawing.Size(586, 409);
            this.listBoxControlJson.TabIndex = 2;
            this.listBoxControlJson.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl3.Location = new System.Drawing.Point(0, 0);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(94, 16);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Parsed columns.";
            // 
            // textEditJsonFile
            // 
            this.textEditJsonFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textEditJsonFile.Location = new System.Drawing.Point(85, 11);
            this.textEditJsonFile.Name = "textEditJsonFile";
            this.textEditJsonFile.Size = new System.Drawing.Size(630, 22);
            this.textEditJsonFile.TabIndex = 8;
            this.textEditJsonFile.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 14);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 16);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Json File:";
            this.labelControl1.Visible = false;
            // 
            // sBtnLoadXMLFile
            // 
            this.sBtnLoadXMLFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sBtnLoadXMLFile.Location = new System.Drawing.Point(721, 10);
            this.sBtnLoadXMLFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sBtnLoadXMLFile.Name = "sBtnLoadXMLFile";
            this.sBtnLoadXMLFile.Size = new System.Drawing.Size(73, 23);
            this.sBtnLoadXMLFile.TabIndex = 6;
            this.sBtnLoadXMLFile.Text = "...";
            this.sBtnLoadXMLFile.Visible = false;
            this.sBtnLoadXMLFile.Click += new System.EventHandler(this.SBtnLoadXMLFile_Click);
            // 
            // xtraTabPageXML
            // 
            this.xtraTabPageXML.Controls.Add(this.labelControl13);
            this.xtraTabPageXML.ImageOptions.Image = global::Analogy.Properties.Resources.xml32x32;
            this.xtraTabPageXML.Name = "xtraTabPageXML";
            this.xtraTabPageXML.Size = new System.Drawing.Size(772, 562);
            this.xtraTabPageXML.Text = "XML Parser";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(10, 10);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(78, 16);
            this.labelControl13.TabIndex = 14;
            this.labelControl13.Text = "Coming soon.";
            // 
            // xtraTabPageWindowsEventLogs
            // 
            this.xtraTabPageWindowsEventLogs.Controls.Add(this.xtraUCWindowsEventLogs1);
            this.xtraTabPageWindowsEventLogs.Controls.Add(this.lblWindowsEventLogs);
            this.xtraTabPageWindowsEventLogs.ImageOptions.Image = global::Analogy.Properties.Resources.OperatingSystem_32x32;
            this.xtraTabPageWindowsEventLogs.Name = "xtraTabPageWindowsEventLogs";
            this.xtraTabPageWindowsEventLogs.Size = new System.Drawing.Size(772, 562);
            this.xtraTabPageWindowsEventLogs.Text = "Windows Event logs";
            // 
            // xtraUCWindowsEventLogs1
            // 
            this.xtraUCWindowsEventLogs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraUCWindowsEventLogs1.Location = new System.Drawing.Point(0, 22);
            this.xtraUCWindowsEventLogs1.Name = "xtraUCWindowsEventLogs1";
            this.xtraUCWindowsEventLogs1.Size = new System.Drawing.Size(772, 540);
            this.xtraUCWindowsEventLogs1.TabIndex = 0;
            // 
            // lblWindowsEventLogs
            // 
            this.lblWindowsEventLogs.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWindowsEventLogs.Location = new System.Drawing.Point(0, 0);
            this.lblWindowsEventLogs.Name = "lblWindowsEventLogs";
            this.lblWindowsEventLogs.Padding = new System.Windows.Forms.Padding(3);
            this.lblWindowsEventLogs.Size = new System.Drawing.Size(233, 22);
            this.lblWindowsEventLogs.TabIndex = 1;
            this.lblWindowsEventLogs.Text = "Windows Event logs: real time settings:";
            // 
            // UserSettingsDataProvidersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 569);
            this.Controls.Add(this.tabControlMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserSettingsDataProvidersForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Built-In Data Providers Settings";
            this.Load += new System.EventHandler(this.UserSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.xtraTabPageNLog.ResumeLayout(false);
            this.xtraTabPageNLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNLogExtension.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltNlogParser)).EndInit();
            this.spltNlogParser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstBAnalogyColumnsNlog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxItemsNlog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNLogSeperator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNLogLayout.Properties)).EndInit();
            this.xtraTabPageSerilog.ResumeLayout(false);
            this.xtraTabPageSerilog.PerformLayout();
            this.xtraTabPageLog4Net.ResumeLayout(false);
            this.xtraTabPageLog4Net.PerformLayout();
            this.xtraTabPageJson.ResumeLayout(false);
            this.xtraTabPageJson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltJSonParser)).EndInit();
            this.spltJSonParser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlAnalogyJson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControlJson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditJsonFile.Properties)).EndInit();
            this.xtraTabPageXML.ResumeLayout(false);
            this.xtraTabPageXML.PerformLayout();
            this.xtraTabPageWindowsEventLogs.ResumeLayout(false);
            this.xtraTabPageWindowsEventLogs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabControlMain;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageNLog;
        private DevExpress.XtraEditors.TextEdit txtNLogSeperator;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtNLogLayout;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton sbtnNLogCheckLayout;
        private DevExpress.XtraEditors.SplitContainerControl spltNlogParser;
        private DevExpress.XtraEditors.SimpleButton sBtnSaveNlogMapping;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.ListBoxControl lstBAnalogyColumnsNlog;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SimpleButton sBtnMoveUpNlog;
        private DevExpress.XtraEditors.SimpleButton sBtnMoveDownNlog;
        private DevExpress.XtraEditors.ListBoxControl lstBoxItemsNlog;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageSerilog;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageLog4Net;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageJson;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageXML;
        private DevExpress.XtraEditors.TextEdit textEditJsonFile;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton sBtnLoadXMLFile;
        private DevExpress.XtraEditors.SplitContainerControl spltJSonParser;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlAnalogyJson;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private DevExpress.XtraEditors.SimpleButton sBtnMoveUpJson;
        private DevExpress.XtraEditors.SimpleButton sBtnMoveDownJson;
        private DevExpress.XtraEditors.ListBoxControl listBoxControlJson;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEditNLogExtension;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageWindowsEventLogs;
        private DevExpress.XtraEditors.LabelControl lblWindowsEventLogs;
        private XtraUCWindowsEventLogs xtraUCWindowsEventLogs1;
        private DevExpress.XtraEditors.SimpleButton btnExportNLogSettings;
        private DevExpress.XtraEditors.SimpleButton btnImportNLogSettings;
    }
}