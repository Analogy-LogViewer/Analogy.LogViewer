namespace Analogy.CommonControls.UserControls
{
    partial class JsonColumnChooserUC
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
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.sbtnOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEdit1.Location = new System.Drawing.Point(268, 2);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.DisplayFormat.FormatString = "yyyy.MM.dd HH:mm:ss.ff";
            this.comboBoxEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.comboBoxEdit1.Properties.PopupDisplayFormat.FormatString = "yyyy.MM.dd HH:mm:ss.ff";
            this.comboBoxEdit1.Properties.PopupDisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.comboBoxEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit1.Size = new System.Drawing.Size(288, 22);
            this.comboBoxEdit1.TabIndex = 6;
            // 
            // sbtnOK
            // 
            this.sbtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnOK.Location = new System.Drawing.Point(562, 3);
            this.sbtnOK.Name = "sbtnOK";
            this.sbtnOK.Size = new System.Drawing.Size(49, 21);
            this.sbtnOK.TabIndex = 5;
            this.sbtnOK.Text = "OK";
            this.sbtnOK.Click += new System.EventHandler(this.sbtnOK_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(217, 16);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Choose column to load the Json from:";
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnCancel.Location = new System.Drawing.Point(562, 30);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(49, 21);
            this.sbtnCancel.TabIndex = 7;
            this.sbtnCancel.Text = "Cancel";
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // JsonColumnChooserUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.comboBoxEdit1);
            this.Controls.Add(this.sbtnOK);
            this.Controls.Add(this.labelControl1);
            this.Name = "JsonColumnChooserUC";
            this.Size = new System.Drawing.Size(624, 64);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.SimpleButton sbtnOK;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton sbtnCancel;
    }
}
