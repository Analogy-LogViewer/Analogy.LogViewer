namespace Analogy
{
    partial class ExtensionsUC
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
            this.label1 = new System.Windows.Forms.Label();
            this.chklItems = new System.Windows.Forms.CheckedListBox();
            this.rtxtbMessages = new System.Windows.Forms.RichTextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblExtension = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.sBtnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(11, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(891, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "The following extensions were detected. Please select which extensions to load";
            // 
            // chklItems
            // 
            this.chklItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chklItems.CheckOnClick = true;
            this.chklItems.FormattingEnabled = true;
            this.chklItems.Location = new System.Drawing.Point(15, 33);
            this.chklItems.Margin = new System.Windows.Forms.Padding(6);
            this.chklItems.Name = "chklItems";
            this.chklItems.Size = new System.Drawing.Size(375, 304);
            this.chklItems.TabIndex = 5;
            this.chklItems.SelectedIndexChanged += new System.EventHandler(this.chklItems_SelectedIndexChanged);
            // 
            // rtxtbMessages
            // 
            this.rtxtbMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtbMessages.Location = new System.Drawing.Point(11, 357);
            this.rtxtbMessages.Name = "rtxtbMessages";
            this.rtxtbMessages.Size = new System.Drawing.Size(894, 106);
            this.rtxtbMessages.TabIndex = 9;
            this.rtxtbMessages.Text = "";
            // 
            // lblAuthor
            // 
            this.lblAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAuthor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAuthor.Location = new System.Drawing.Point(399, 303);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(510, 31);
            this.lblAuthor.TabIndex = 10;
            this.lblAuthor.Text = "Author:";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDescription.Location = new System.Drawing.Point(399, 68);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(510, 176);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.Text = "Description:";
            // 
            // lblExtension
            // 
            this.lblExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExtension.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblExtension.Location = new System.Drawing.Point(399, 33);
            this.lblExtension.Name = "lblExtension";
            this.lblExtension.Size = new System.Drawing.Size(510, 31);
            this.lblExtension.TabIndex = 12;
            this.lblExtension.Text = "Name:";
            // 
            // lblType
            // 
            this.lblType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblType.Location = new System.Drawing.Point(399, 265);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(510, 31);
            this.lblType.TabIndex = 13;
            this.lblType.Text = "Type:";
            // 
            // sBtnLoad
            // 
            this.sBtnLoad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sBtnLoad.Location = new System.Drawing.Point(320, 475);
            this.sBtnLoad.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.sBtnLoad.Name = "sBtnLoad";
            this.sBtnLoad.Size = new System.Drawing.Size(133, 31);
            this.sBtnLoad.TabIndex = 17;
            this.sBtnLoad.Text = "Load Selected";
            this.sBtnLoad.Click += new System.EventHandler(this.sBtnLoad_Click);
            // 
            // ExtensionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sBtnLoad);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblExtension);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.rtxtbMessages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chklItems);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ExtensionsUC";
            this.Size = new System.Drawing.Size(929, 508);
            this.Load += new System.EventHandler(this.ExtensionsUC_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chklItems;
        private System.Windows.Forms.RichTextBox rtxtbMessages;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblExtension;
        private System.Windows.Forms.Label lblType;
        private DevExpress.XtraEditors.SimpleButton sBtnLoad;
    }
}
