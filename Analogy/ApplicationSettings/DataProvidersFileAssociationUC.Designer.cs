
namespace Analogy.ApplicationSettings
{
    partial class DataProvidersFileAssociationUC
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
            this.cbDataProviderFactoryAssociation = new DevExpress.XtraEditors.LookUpEdit();
            this.txtbDataProviderAssociation = new DevExpress.XtraEditors.TextEdit();
            this.btnSetFileAssociation = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cbFileProviderAssociation = new DevExpress.XtraEditors.LookUpEdit();
            this.lblFileProvider = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cbDataProviderFactoryAssociation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDataProviderAssociation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFileProviderAssociation.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDataProviderFactoryAssociation
            // 
            this.cbDataProviderFactoryAssociation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDataProviderFactoryAssociation.Location = new System.Drawing.Point(21, 8);
            this.cbDataProviderFactoryAssociation.Name = "cbDataProviderFactoryAssociation";
            this.cbDataProviderFactoryAssociation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDataProviderFactoryAssociation.Size = new System.Drawing.Size(760, 22);
            this.cbDataProviderFactoryAssociation.TabIndex = 12;
            // 
            // txtbDataProviderAssociation
            // 
            this.txtbDataProviderAssociation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbDataProviderAssociation.Location = new System.Drawing.Point(325, 76);
            this.txtbDataProviderAssociation.Name = "txtbDataProviderAssociation";
            this.txtbDataProviderAssociation.Size = new System.Drawing.Size(456, 22);
            this.txtbDataProviderAssociation.TabIndex = 11;
            // 
            // btnSetFileAssociation
            // 
            this.btnSetFileAssociation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetFileAssociation.Location = new System.Drawing.Point(798, 75);
            this.btnSetFileAssociation.Name = "btnSetFileAssociation";
            this.btnSetFileAssociation.Size = new System.Drawing.Size(47, 23);
            this.btnSetFileAssociation.TabIndex = 10;
            this.btnSetFileAssociation.Text = "set";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(21, 79);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(282, 16);
            this.labelControl8.TabIndex = 9;
            this.labelControl8.Text = "File Types (use , as seperator. e.g: *.nlog,*.txt):";
            // 
            // cbFileProviderAssociation
            // 
            this.cbFileProviderAssociation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFileProviderAssociation.Location = new System.Drawing.Point(151, 36);
            this.cbFileProviderAssociation.Name = "cbFileProviderAssociation";
            this.cbFileProviderAssociation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbFileProviderAssociation.Size = new System.Drawing.Size(630, 22);
            this.cbFileProviderAssociation.TabIndex = 13;
            // 
            // lblFileProvider
            // 
            this.lblFileProvider.Location = new System.Drawing.Point(21, 39);
            this.lblFileProvider.Name = "lblFileProvider";
            this.lblFileProvider.Size = new System.Drawing.Size(124, 16);
            this.lblFileProvider.TabIndex = 14;
            this.lblFileProvider.Text = "Specific File Provider:";
            // 
            // DataProvidersFileAssociationUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.lblFileProvider);
            this.Controls.Add(this.cbFileProviderAssociation);
            this.Controls.Add(this.cbDataProviderFactoryAssociation);
            this.Controls.Add(this.txtbDataProviderAssociation);
            this.Controls.Add(this.btnSetFileAssociation);
            this.Controls.Add(this.labelControl8);
            this.Name = "DataProvidersFileAssociationUC";
            this.Size = new System.Drawing.Size(856, 463);
            this.Load += new System.EventHandler(this.DataProvidersFileAssociationUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbDataProviderFactoryAssociation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDataProviderAssociation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbFileProviderAssociation.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cbDataProviderFactoryAssociation;
        private DevExpress.XtraEditors.TextEdit txtbDataProviderAssociation;
        private DevExpress.XtraEditors.SimpleButton btnSetFileAssociation;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LookUpEdit cbFileProviderAssociation;
        private DevExpress.XtraEditors.LabelControl lblFileProvider;
    }
}
