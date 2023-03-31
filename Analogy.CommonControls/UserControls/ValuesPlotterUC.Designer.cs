using DevExpress.XtraEditors;

namespace Analogy.CommonControls.UserControls
{
    partial class ValuesPlotterUC
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
            this.PnlToolbar = new System.Windows.Forms.Panel();
            this.CmbColumns = new System.Windows.Forms.ComboBox();
            this.BtnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.BtnRefreshColumns = new DevExpress.XtraEditors.SimpleButton();
            this.LblSelect = new System.Windows.Forms.Label();
            this.LstPlotted = new ListBoxControl();
            this.LblPlotted = new System.Windows.Forms.Label();
            this.BtnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.PnlPlot = new System.Windows.Forms.Panel();
            this.PnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlToolbar
            // 
            this.PnlToolbar.Controls.Add(this.BtnDelete);
            this.PnlToolbar.Controls.Add(this.LblPlotted);
            this.PnlToolbar.Controls.Add(this.LstPlotted);
            this.PnlToolbar.Controls.Add(this.LblSelect);
            this.PnlToolbar.Controls.Add(this.BtnRefreshColumns);
            this.PnlToolbar.Controls.Add(this.BtnAdd);
            this.PnlToolbar.Controls.Add(this.CmbColumns);
            this.PnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.PnlToolbar.Name = "PnlToolbar";
            this.PnlToolbar.Size = new System.Drawing.Size(1163, 100);
            this.PnlToolbar.TabIndex = 0;
            // 
            // CmbColumns
            // 
            this.CmbColumns.FormattingEnabled = true;
            this.CmbColumns.Location = new System.Drawing.Point(89, 13);
            this.CmbColumns.Name = "CmbColumns";
            this.CmbColumns.Size = new System.Drawing.Size(232, 21);
            this.CmbColumns.TabIndex = 0;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(327, 11);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnRefreshColumns
            // 
            this.BtnRefreshColumns.Location = new System.Drawing.Point(438, 11);
            this.BtnRefreshColumns.Name = "BtnRefreshColumns";
            this.BtnRefreshColumns.Size = new System.Drawing.Size(75, 23);
            this.BtnRefreshColumns.TabIndex = 2;
            this.BtnRefreshColumns.Text = "Refresh list";
            this.BtnRefreshColumns.Click += new System.EventHandler(this.BtnRefreshColumns_Click);
            // 
            // LblSelect
            // 
            this.LblSelect.AutoSize = true;
            this.LblSelect.Location = new System.Drawing.Point(9, 16);
            this.LblSelect.Name = "LblSelect";
            this.LblSelect.Size = new System.Drawing.Size(74, 13);
            this.LblSelect.TabIndex = 3;
            this.LblSelect.Text = "Select column";
            // 
            // LstPlotted
            // 
            this.LstPlotted.Location = new System.Drawing.Point(629, 13);
            this.LstPlotted.Name = "LstPlotted";
            this.LstPlotted.Size = new System.Drawing.Size(363, 69);
            this.LstPlotted.TabIndex = 4;
            // 
            // LblPlotted
            // 
            this.LblPlotted.AutoSize = true;
            this.LblPlotted.Location = new System.Drawing.Point(583, 16);
            this.LblPlotted.Name = "LblPlotted";
            this.LblPlotted.Size = new System.Drawing.Size(40, 13);
            this.LblPlotted.TabIndex = 5;
            this.LblPlotted.Text = "Plotted";
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(998, 11);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 6;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // PnlPlot
            // 
            this.PnlPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlPlot.Location = new System.Drawing.Point(0, 100);
            this.PnlPlot.Name = "PnlPlot";
            this.PnlPlot.Size = new System.Drawing.Size(1163, 367);
            this.PnlPlot.TabIndex = 1;
            // 
            // ValuesPlotterUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.PnlPlot);
            this.Controls.Add(this.PnlToolbar);
            this.Name = "ValuesPlotterUC";
            this.Size = new System.Drawing.Size(1163, 467);
            this.PnlToolbar.ResumeLayout(false);
            this.PnlToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlToolbar;
        private System.Windows.Forms.Label LblSelect;
        private DevExpress.XtraEditors.SimpleButton BtnRefreshColumns;
        private DevExpress.XtraEditors.SimpleButton BtnAdd;
        private System.Windows.Forms.ComboBox  CmbColumns;
        private System.Windows.Forms.Label LblPlotted;
        private ListBoxControl LstPlotted;
        private DevExpress.XtraEditors.SimpleButton BtnDelete;
        private System.Windows.Forms.Panel PnlPlot;
    }
}
