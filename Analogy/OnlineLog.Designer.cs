using DevExpress.XtraGrid.Views.Grid;

namespace Philips.Analogy
{
    partial class OnlineUCLogs
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
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnlineUCLogs));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imageListBottom = new System.Windows.Forms.ImageList(this.components);
            this.tsPrimary = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.spltMain = new System.Windows.Forms.SplitContainer();
            this.listBoxClearHistory = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnClearHistory = new System.Windows.Forms.ToolStripButton();
            this.tsbtnHide = new System.Windows.Forms.ToolStripButton();
            this.ucLogs1 = new Philips.Analogy.UCLogs();
            this.tsPrimary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).BeginInit();
            this.spltMain.Panel1.SuspendLayout();
            this.spltMain.Panel2.SuspendLayout();
            this.spltMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Error_16x16.png");
            this.imageList.Images.SetKeyName(1, "Warning_16x16.png");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "folder32x32.gif");
            this.imageList.Images.SetKeyName(4, "Error_32x32.png");
            this.imageList.Images.SetKeyName(5, "Warning_32x32.png");
            // 
            // imageListBottom
            // 
            this.imageListBottom.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBottom.ImageStream")));
            this.imageListBottom.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListBottom.Images.SetKeyName(0, "Info_16x16.png");
            this.imageListBottom.Images.SetKeyName(1, "RichEditBookmark_16x16.png");
            this.imageListBottom.Images.SetKeyName(2, "RichEditBookmark_32x32.png");
            // 
            // tsPrimary
            // 
            this.tsPrimary.AutoSize = false;
            this.tsPrimary.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsPrimary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1});
            this.tsPrimary.Location = new System.Drawing.Point(0, 0);
            this.tsPrimary.Name = "tsPrimary";
            this.tsPrimary.Size = new System.Drawing.Size(1387, 46);
            this.tsPrimary.TabIndex = 6;
            this.tsPrimary.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // spltMain
            // 
            this.spltMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltMain.Location = new System.Drawing.Point(0, 0);
            this.spltMain.Name = "spltMain";
            // 
            // spltMain.Panel1
            // 
            this.spltMain.Panel1.Controls.Add(this.listBoxClearHistory);
            this.spltMain.Panel1.Controls.Add(this.toolStrip1);
            // 
            // spltMain.Panel2
            // 
            this.spltMain.Panel2.Controls.Add(this.ucLogs1);
            this.spltMain.Size = new System.Drawing.Size(1387, 700);
            this.spltMain.SplitterDistance = 159;
            this.spltMain.TabIndex = 7;
            // 
            // listBoxClearHistory
            // 
            this.listBoxClearHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxClearHistory.FormattingEnabled = true;
            this.listBoxClearHistory.ItemHeight = 16;
            this.listBoxClearHistory.Location = new System.Drawing.Point(0, 46);
            this.listBoxClearHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxClearHistory.Name = "listBoxClearHistory";
            this.listBoxClearHistory.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxClearHistory.Size = new System.Drawing.Size(159, 654);
            this.listBoxClearHistory.TabIndex = 15;
            this.listBoxClearHistory.SelectedIndexChanged += new System.EventHandler(this.listBoxClearHistory_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnClearHistory,
            this.tsbtnHide});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(159, 46);
            this.toolStrip1.TabIndex = 7;
            // 
            // tsBtnClearHistory
            // 
            this.tsBtnClearHistory.Image = global::Philips.Analogy.Properties.Resources.Clear_32x32;
            this.tsBtnClearHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnClearHistory.Name = "tsBtnClearHistory";
            this.tsBtnClearHistory.Size = new System.Drawing.Size(71, 43);
            this.tsBtnClearHistory.Text = "Clear";
            this.tsBtnClearHistory.Click += new System.EventHandler(this.tsBtnClearHistory_Click);
            // 
            // tsbtnHide
            // 
            this.tsbtnHide.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnHide.CheckOnClick = true;
            this.tsbtnHide.Image = global::Philips.Analogy.Properties.Resources.First_32x32;
            this.tsbtnHide.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHide.Name = "tsbtnHide";
            this.tsbtnHide.Size = new System.Drawing.Size(69, 28);
            this.tsbtnHide.Text = "Hide";
            this.tsbtnHide.Click += new System.EventHandler(this.tsbtnHide_Click);
            // 
            // ucLogs1
            // 
            this.ucLogs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucLogs1.Location = new System.Drawing.Point(0, 0);
            this.ucLogs1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucLogs1.Name = "ucLogs1";
            this.ucLogs1.OnlineMode = false;
            this.ucLogs1.Size = new System.Drawing.Size(1224, 700);
            this.ucLogs1.TabIndex = 0;
            // 
            // OnlineUCLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spltMain);
            this.Controls.Add(this.tsPrimary);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OnlineUCLogs";
            this.Size = new System.Drawing.Size(1387, 700);
            this.Load += new System.EventHandler(this.OnlineUCLogs_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.AnalogyUCLogs_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.AnalogyUCLogs_DragEnter);
            this.tsPrimary.ResumeLayout(false);
            this.tsPrimary.PerformLayout();
            this.spltMain.Panel1.ResumeLayout(false);
            this.spltMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).EndInit();
            this.spltMain.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStrip tsPrimary;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ImageList imageListBottom;
        private UCLogs ucLogs1;
        private System.Windows.Forms.SplitContainer spltMain;
        protected System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnClearHistory;
        private System.Windows.Forms.ToolStripButton tsbtnHide;
        private System.Windows.Forms.ListBox listBoxClearHistory;
    }
}
