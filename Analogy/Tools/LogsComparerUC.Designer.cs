namespace Analogy.Tools
{
    partial class LogsComparerUC
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
            this.rtboxRight = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtboxLeft = new System.Windows.Forms.RichTextBox();
            this.panelControlLeft = new DevExpress.XtraEditors.PanelControl();
            this.lblFileLeft = new System.Windows.Forms.Label();
            this.sBtnLeft = new DevExpress.XtraEditors.SimpleButton();
            this.panelControlRight = new DevExpress.XtraEditors.PanelControl();
            this.lblFileRight = new System.Windows.Forms.Label();
            this.simpleButtonRight = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLeft)).BeginInit();
            this.panelControlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlRight)).BeginInit();
            this.panelControlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtboxRight
            // 
            this.rtboxRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtboxRight.Location = new System.Drawing.Point(0, 26);
            this.rtboxRight.Name = "rtboxRight";
            this.rtboxRight.Size = new System.Drawing.Size(420, 453);
            this.rtboxRight.TabIndex = 3;
            this.rtboxRight.Text = "";
            this.rtboxRight.WordWrap = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtboxLeft);
            this.splitContainer1.Panel1.Controls.Add(this.panelControlLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtboxRight);
            this.splitContainer1.Panel2.Controls.Add(this.panelControlRight);
            this.splitContainer1.Size = new System.Drawing.Size(821, 479);
            this.splitContainer1.SplitterDistance = 397;
            this.splitContainer1.TabIndex = 1;
            // 
            // rtboxLeft
            // 
            this.rtboxLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtboxLeft.Location = new System.Drawing.Point(0, 26);
            this.rtboxLeft.Name = "rtboxLeft";
            this.rtboxLeft.Size = new System.Drawing.Size(397, 453);
            this.rtboxLeft.TabIndex = 0;
            this.rtboxLeft.Text = "";
            this.rtboxLeft.WordWrap = false;
            // 
            // panelControlLeft
            // 
            this.panelControlLeft.Controls.Add(this.lblFileLeft);
            this.panelControlLeft.Controls.Add(this.sBtnLeft);
            this.panelControlLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlLeft.Location = new System.Drawing.Point(0, 0);
            this.panelControlLeft.Name = "panelControlLeft";
            this.panelControlLeft.Size = new System.Drawing.Size(397, 26);
            this.panelControlLeft.TabIndex = 3;
            // 
            // lblFileLeft
            // 
            this.lblFileLeft.AutoEllipsis = true;
            this.lblFileLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFileLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileLeft.Location = new System.Drawing.Point(2, 2);
            this.lblFileLeft.Name = "lblFileLeft";
            this.lblFileLeft.Size = new System.Drawing.Size(336, 22);
            this.lblFileLeft.TabIndex = 1;
            // 
            // sBtnLeft
            // 
            this.sBtnLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.sBtnLeft.Location = new System.Drawing.Point(338, 2);
            this.sBtnLeft.Name = "sBtnLeft";
            this.sBtnLeft.Size = new System.Drawing.Size(57, 22);
            this.sBtnLeft.TabIndex = 2;
            this.sBtnLeft.Text = "..";
            this.sBtnLeft.Click += new System.EventHandler(this.sBtnLeft_Click);
            // 
            // panelControlRight
            // 
            this.panelControlRight.Controls.Add(this.lblFileRight);
            this.panelControlRight.Controls.Add(this.simpleButtonRight);
            this.panelControlRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlRight.Location = new System.Drawing.Point(0, 0);
            this.panelControlRight.Name = "panelControlRight";
            this.panelControlRight.Size = new System.Drawing.Size(420, 26);
            this.panelControlRight.TabIndex = 4;
            // 
            // lblFileRight
            // 
            this.lblFileRight.AutoEllipsis = true;
            this.lblFileRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFileRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFileRight.Location = new System.Drawing.Point(2, 2);
            this.lblFileRight.Name = "lblFileRight";
            this.lblFileRight.Size = new System.Drawing.Size(359, 22);
            this.lblFileRight.TabIndex = 2;
            // 
            // simpleButtonRight
            // 
            this.simpleButtonRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonRight.Location = new System.Drawing.Point(361, 2);
            this.simpleButtonRight.Name = "simpleButtonRight";
            this.simpleButtonRight.Size = new System.Drawing.Size(57, 22);
            this.simpleButtonRight.TabIndex = 3;
            this.simpleButtonRight.Text = "..";
            this.simpleButtonRight.Click += new System.EventHandler(this.simpleButtonRight_Click);
            // 
            // LogsComparerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "LogsComparerUC";
            this.Size = new System.Drawing.Size(821, 479);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlLeft)).EndInit();
            this.panelControlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlRight)).EndInit();
            this.panelControlRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtboxRight;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtboxLeft;
        private System.Windows.Forms.Label lblFileLeft;
        private System.Windows.Forms.Label lblFileRight;
        private DevExpress.XtraEditors.PanelControl panelControlLeft;
        private DevExpress.XtraEditors.SimpleButton sBtnLeft;
        private DevExpress.XtraEditors.PanelControl panelControlRight;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRight;
    }
}
