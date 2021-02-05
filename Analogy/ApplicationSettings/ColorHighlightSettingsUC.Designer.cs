
namespace Analogy.ApplicationSettings
{
    partial class ColorHighlightSettingsUC
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
            this.gcHighlight = new DevExpress.XtraEditors.GroupControl();
            this.sbtnAddHighlight = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.cpeHighlightPreDefined = new DevExpress.XtraEditors.ColorPickEdit();
            this.teHighlightEquals = new DevExpress.XtraEditors.TextEdit();
            this.teHighlightContains = new DevExpress.XtraEditors.TextEdit();
            this.ceHighlightEquals = new DevExpress.XtraEditors.CheckEdit();
            this.ceHighlightContains = new DevExpress.XtraEditors.CheckEdit();
            this.lboxHighlightItems = new DevExpress.XtraEditors.ListBoxControl();
            this.sbtnDeleteHighlight = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcHighlight)).BeginInit();
            this.gcHighlight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpeHighlightPreDefined.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHighlightEquals.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHighlightContains.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceHighlightEquals.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceHighlightContains.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lboxHighlightItems)).BeginInit();
            this.SuspendLayout();
            // 
            // gcHighlight
            // 
            this.gcHighlight.Controls.Add(this.sbtnDeleteHighlight);
            this.gcHighlight.Controls.Add(this.lboxHighlightItems);
            this.gcHighlight.Controls.Add(this.ceHighlightEquals);
            this.gcHighlight.Controls.Add(this.ceHighlightContains);
            this.gcHighlight.Controls.Add(this.sbtnAddHighlight);
            this.gcHighlight.Controls.Add(this.labelControl9);
            this.gcHighlight.Controls.Add(this.cpeHighlightPreDefined);
            this.gcHighlight.Controls.Add(this.teHighlightEquals);
            this.gcHighlight.Controls.Add(this.teHighlightContains);
            this.gcHighlight.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcHighlight.Location = new System.Drawing.Point(0, 0);
            this.gcHighlight.Name = "gcHighlight";
            this.gcHighlight.Size = new System.Drawing.Size(762, 438);
            this.gcHighlight.TabIndex = 1;
            this.gcHighlight.Text = "Color Highlights";
            // 
            // sbtnAddHighlight
            // 
            this.sbtnAddHighlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnAddHighlight.Location = new System.Drawing.Point(633, 147);
            this.sbtnAddHighlight.Name = "sbtnAddHighlight";
            this.sbtnAddHighlight.Size = new System.Drawing.Size(110, 27);
            this.sbtnAddHighlight.TabIndex = 6;
            this.sbtnAddHighlight.Text = "Add";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(5, 109);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(74, 16);
            this.labelControl9.TabIndex = 5;
            this.labelControl9.Text = "Select Color:";
            // 
            // cpeHighlightPreDefined
            // 
            this.cpeHighlightPreDefined.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cpeHighlightPreDefined.EditValue = System.Drawing.Color.Empty;
            this.cpeHighlightPreDefined.Location = new System.Drawing.Point(194, 106);
            this.cpeHighlightPreDefined.Name = "cpeHighlightPreDefined";
            this.cpeHighlightPreDefined.Properties.AutomaticColor = System.Drawing.Color.Black;
            this.cpeHighlightPreDefined.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cpeHighlightPreDefined.Size = new System.Drawing.Size(549, 22);
            this.cpeHighlightPreDefined.TabIndex = 4;
            // 
            // teHighlightEquals
            // 
            this.teHighlightEquals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teHighlightEquals.Enabled = false;
            this.teHighlightEquals.Location = new System.Drawing.Point(194, 76);
            this.teHighlightEquals.Name = "teHighlightEquals";
            this.teHighlightEquals.Size = new System.Drawing.Size(549, 22);
            this.teHighlightEquals.TabIndex = 3;
            // 
            // teHighlightContains
            // 
            this.teHighlightContains.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teHighlightContains.Location = new System.Drawing.Point(194, 43);
            this.teHighlightContains.Name = "teHighlightContains";
            this.teHighlightContains.Size = new System.Drawing.Size(549, 22);
            this.teHighlightContains.TabIndex = 2;
            // 
            // ceHighlightEquals
            // 
            this.ceHighlightEquals.Location = new System.Drawing.Point(5, 77);
            this.ceHighlightEquals.Name = "ceHighlightEquals";
            this.ceHighlightEquals.Properties.Caption = "Message Text Equals:";
            this.ceHighlightEquals.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceHighlightEquals.Properties.RadioGroupIndex = 1;
            this.ceHighlightEquals.Size = new System.Drawing.Size(183, 20);
            this.ceHighlightEquals.TabIndex = 22;
            this.ceHighlightEquals.TabStop = false;
            // 
            // ceHighlightContains
            // 
            this.ceHighlightContains.EditValue = true;
            this.ceHighlightContains.Location = new System.Drawing.Point(5, 44);
            this.ceHighlightContains.Name = "ceHighlightContains";
            this.ceHighlightContains.Properties.Caption = "Message Text Contains:";
            this.ceHighlightContains.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceHighlightContains.Properties.RadioGroupIndex = 1;
            this.ceHighlightContains.Size = new System.Drawing.Size(183, 20);
            this.ceHighlightContains.TabIndex = 21;
            // 
            // lboxHighlightItems
            // 
            this.lboxHighlightItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lboxHighlightItems.Location = new System.Drawing.Point(5, 183);
            this.lboxHighlightItems.Name = "lboxHighlightItems";
            this.lboxHighlightItems.Size = new System.Drawing.Size(738, 210);
            this.lboxHighlightItems.TabIndex = 23;
            // 
            // sbtnDeleteHighlight
            // 
            this.sbtnDeleteHighlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnDeleteHighlight.Location = new System.Drawing.Point(633, 399);
            this.sbtnDeleteHighlight.Name = "sbtnDeleteHighlight";
            this.sbtnDeleteHighlight.Size = new System.Drawing.Size(110, 27);
            this.sbtnDeleteHighlight.TabIndex = 24;
            this.sbtnDeleteHighlight.Text = "Delete";
            // 
            // ColorHighlightSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcHighlight);
            this.Name = "ColorHighlightSettingsUC";
            this.Size = new System.Drawing.Size(762, 438);
            this.Load += new System.EventHandler(this.ColorHighlightSettingsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcHighlight)).EndInit();
            this.gcHighlight.ResumeLayout(false);
            this.gcHighlight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpeHighlightPreDefined.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHighlightEquals.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teHighlightContains.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceHighlightEquals.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceHighlightContains.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lboxHighlightItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcHighlight;
        private DevExpress.XtraEditors.SimpleButton sbtnAddHighlight;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.ColorPickEdit cpeHighlightPreDefined;
        private DevExpress.XtraEditors.TextEdit teHighlightEquals;
        private DevExpress.XtraEditors.TextEdit teHighlightContains;
        private DevExpress.XtraEditors.CheckEdit ceHighlightEquals;
        private DevExpress.XtraEditors.CheckEdit ceHighlightContains;
        private DevExpress.XtraEditors.ListBoxControl lboxHighlightItems;
        private DevExpress.XtraEditors.SimpleButton sbtnDeleteHighlight;
    }
}
