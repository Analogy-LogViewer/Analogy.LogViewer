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
            this.xtraTabPageWindowsEventLogs = new DevExpress.XtraTab.XtraTabPage();
            this.xtraUCWindowsEventLogs1 = new Analogy.XtraUCWindowsEventLogs();
            this.lblWindowsEventLogs = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPageIIS = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPageSerilog = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPageLog4Net = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPageJson = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPageXML = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.xtraTabPageWindowsEventLogs.SuspendLayout();
            this.xtraTabPageIIS.SuspendLayout();
            this.xtraTabPageSerilog.SuspendLayout();
            this.xtraTabPageLog4Net.SuspendLayout();
            this.xtraTabPageJson.SuspendLayout();
            this.xtraTabPageXML.SuspendLayout();
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
            this.tabControlMain.SelectedTabPage = this.xtraTabPageWindowsEventLogs;
            this.tabControlMain.Size = new System.Drawing.Size(904, 625);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageWindowsEventLogs,
            this.xtraTabPageIIS,
            this.xtraTabPageSerilog,
            this.xtraTabPageLog4Net,
            this.xtraTabPageJson,
            this.xtraTabPageXML,
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPageWindowsEventLogs
            // 
            this.xtraTabPageWindowsEventLogs.Controls.Add(this.xtraUCWindowsEventLogs1);
            this.xtraTabPageWindowsEventLogs.Controls.Add(this.lblWindowsEventLogs);
            this.xtraTabPageWindowsEventLogs.ImageOptions.Image = global::Analogy.Properties.Resources.OperatingSystem_32x32;
            this.xtraTabPageWindowsEventLogs.Name = "xtraTabPageWindowsEventLogs";
            this.xtraTabPageWindowsEventLogs.Size = new System.Drawing.Size(731, 618);
            this.xtraTabPageWindowsEventLogs.Text = "Windows Event logs";
            // 
            // xtraUCWindowsEventLogs1
            // 
            this.xtraUCWindowsEventLogs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraUCWindowsEventLogs1.Location = new System.Drawing.Point(0, 22);
            this.xtraUCWindowsEventLogs1.Name = "xtraUCWindowsEventLogs1";
            this.xtraUCWindowsEventLogs1.Size = new System.Drawing.Size(731, 596);
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
            // xtraTabPageIIS
            // 
            this.xtraTabPageIIS.Controls.Add(this.labelControl10);
            this.xtraTabPageIIS.ImageOptions.Image = global::Analogy.Properties.Resources.iis;
            this.xtraTabPageIIS.Name = "xtraTabPageIIS";
            this.xtraTabPageIIS.Size = new System.Drawing.Size(731, 617);
            this.xtraTabPageIIS.Text = "IIS Logs";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(21, 10);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(142, 16);
            this.labelControl10.TabIndex = 5;
            this.labelControl10.Text = "No special settings exists";
            // 
            // xtraTabPageSerilog
            // 
            this.xtraTabPageSerilog.Controls.Add(this.labelControl6);
            this.xtraTabPageSerilog.ImageOptions.Image = global::Analogy.Properties.Resources.serilog32x32;
            this.xtraTabPageSerilog.Name = "xtraTabPageSerilog";
            this.xtraTabPageSerilog.Size = new System.Drawing.Size(731, 617);
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
            this.xtraTabPageLog4Net.Size = new System.Drawing.Size(731, 617);
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
            this.xtraTabPageJson.ImageOptions.Image = global::Analogy.Properties.Resources.jsonfile32x32;
            this.xtraTabPageJson.Name = "xtraTabPageJson";
            this.xtraTabPageJson.Size = new System.Drawing.Size(731, 617);
            this.xtraTabPageJson.Text = "Json Parser";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(13, 10);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(78, 16);
            this.labelControl12.TabIndex = 14;
            this.labelControl12.Text = "Coming soon.";
            // 
            // xtraTabPageXML
            // 
            this.xtraTabPageXML.Controls.Add(this.labelControl13);
            this.xtraTabPageXML.ImageOptions.Image = global::Analogy.Properties.Resources.xml32x32;
            this.xtraTabPageXML.Name = "xtraTabPageXML";
            this.xtraTabPageXML.Size = new System.Drawing.Size(731, 617);
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
            // xtraTabPage1
            // 
            this.xtraTabPage1.ImageOptions.Image = global::Analogy.Properties.Resources.Mirada_Icon;
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.PageVisible = false;
            this.xtraTabPage1.Size = new System.Drawing.Size(731, 617);
            this.xtraTabPage1.Text = "Mirada logs Parser";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.ImageOptions.Image = global::Analogy.Properties.Resources.iqon;
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.PageVisible = false;
            this.xtraTabPage2.Size = new System.Drawing.Size(731, 617);
            this.xtraTabPage2.Text = "ICAP BU Logs";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.ImageOptions.Image = global::Analogy.Properties.Resources.kama;
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.PageVisible = false;
            this.xtraTabPage3.Size = new System.Drawing.Size(731, 617);
            this.xtraTabPage3.Text = "Kama Research";
            // 
            // UserSettingsDataProvidersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 625);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserSettingsDataProvidersForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Built-In Data Providers Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserSettingsDataProvidersForm_FormClosing);
            this.Load += new System.EventHandler(this.UserSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.xtraTabPageWindowsEventLogs.ResumeLayout(false);
            this.xtraTabPageWindowsEventLogs.PerformLayout();
            this.xtraTabPageIIS.ResumeLayout(false);
            this.xtraTabPageIIS.PerformLayout();
            this.xtraTabPageSerilog.ResumeLayout(false);
            this.xtraTabPageSerilog.PerformLayout();
            this.xtraTabPageLog4Net.ResumeLayout(false);
            this.xtraTabPageLog4Net.PerformLayout();
            this.xtraTabPageJson.ResumeLayout(false);
            this.xtraTabPageJson.PerformLayout();
            this.xtraTabPageXML.ResumeLayout(false);
            this.xtraTabPageXML.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tabControlMain;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageSerilog;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageLog4Net;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageJson;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageXML;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageWindowsEventLogs;
        private DevExpress.XtraEditors.LabelControl lblWindowsEventLogs;
        private XtraUCWindowsEventLogs xtraUCWindowsEventLogs1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageIIS;
        private DevExpress.XtraEditors.LabelControl labelControl10;
    }
}