
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
            this.cbDataProviderAssociation = new DevExpress.XtraEditors.LookUpEdit();
            this.txtbDataProviderAssociation = new DevExpress.XtraEditors.TextEdit();
            this.btnSetFileAssociation = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cbDataProviderAssociation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDataProviderAssociation.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDataProviderAssociation
            // 
            this.cbDataProviderAssociation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDataProviderAssociation.Location = new System.Drawing.Point(21, 8);
            this.cbDataProviderAssociation.Name = "cbDataProviderAssociation";
            this.cbDataProviderAssociation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDataProviderAssociation.Size = new System.Drawing.Size(760, 22);
            this.cbDataProviderAssociation.TabIndex = 12;
            // 
            // txtbDataProviderAssociation
            // 
            this.txtbDataProviderAssociation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbDataProviderAssociation.Location = new System.Drawing.Point(325, 50);
            this.txtbDataProviderAssociation.Name = "txtbDataProviderAssociation";
            this.txtbDataProviderAssociation.Size = new System.Drawing.Size(456, 22);
            this.txtbDataProviderAssociation.TabIndex = 11;
            // 
            // btnSetFileAssociation
            // 
            this.btnSetFileAssociation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetFileAssociation.Location = new System.Drawing.Point(798, 49);
            this.btnSetFileAssociation.Name = "btnSetFileAssociation";
            this.btnSetFileAssociation.Size = new System.Drawing.Size(47, 23);
            this.btnSetFileAssociation.TabIndex = 10;
            this.btnSetFileAssociation.Text = "set";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(21, 53);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(282, 16);
            this.labelControl8.TabIndex = 9;
            this.labelControl8.Text = "File Types (use , as seperator. e.g: *.nlog,*.txt):";
            // 
            // DataProvidersFileAssociationUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.cbDataProviderAssociation);
            this.Controls.Add(this.txtbDataProviderAssociation);
            this.Controls.Add(this.btnSetFileAssociation);
            this.Controls.Add(this.labelControl8);
            this.Name = "DataProvidersFileAssociationUC";
            this.Size = new System.Drawing.Size(856, 134);
            this.Load += new System.EventHandler(this.DataProvidersFileAssociationUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbDataProviderAssociation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbDataProviderAssociation.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cbDataProviderAssociation;
        private DevExpress.XtraEditors.TextEdit txtbDataProviderAssociation;
        private DevExpress.XtraEditors.SimpleButton btnSetFileAssociation;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}
