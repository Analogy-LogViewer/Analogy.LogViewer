
namespace Analogy.ApplicationSettings
{
    partial class ApplicationUISettingsUC
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
            this.gcUISettings = new DevExpress.XtraEditors.GroupControl();
            this.tsRibbonCompactStyle = new DevExpress.XtraEditors.ToggleSwitch();
            this.pcMenuFont = new DevExpress.XtraEditors.PanelControl();
            this.rbMenuFontSizeDefault = new System.Windows.Forms.RadioButton();
            this.rbMenuFontSizeNormal = new System.Windows.Forms.RadioButton();
            this.rbMenuFontSizeLarge = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.rbMenuFontSizeVeryLarge = new System.Windows.Forms.RadioButton();
            this.pcUiFont = new DevExpress.XtraEditors.PanelControl();
            this.rbFontSizeDefault = new System.Windows.Forms.RadioButton();
            this.rbFontSizeVeryLarge = new System.Windows.Forms.RadioButton();
            this.rbFontSizeNormal = new System.Windows.Forms.RadioButton();
            this.rbFontSizeLarge = new System.Windows.Forms.RadioButton();
            this.lblUlFontSize = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.peAnalogy = new DevExpress.XtraEditors.PictureEdit();
            this.rbtnLightIconColor = new System.Windows.Forms.RadioButton();
            this.rbtnDarkIconColor = new System.Windows.Forms.RadioButton();
            this.tsRememberLastPositionAndState = new DevExpress.XtraEditors.ToggleSwitch();
            this.tsStartupRibbonMinimized = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.gcUISettings)).BeginInit();
            this.gcUISettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsRibbonCompactStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcMenuFont)).BeginInit();
            this.pcMenuFont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcUiFont)).BeginInit();
            this.pcUiFont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peAnalogy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsRememberLastPositionAndState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsStartupRibbonMinimized.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcUISettings
            // 
            this.gcUISettings.Controls.Add(this.tsStartupRibbonMinimized);
            this.gcUISettings.Controls.Add(this.tsRibbonCompactStyle);
            this.gcUISettings.Controls.Add(this.pcMenuFont);
            this.gcUISettings.Controls.Add(this.pcUiFont);
            this.gcUISettings.Controls.Add(this.panelControl1);
            this.gcUISettings.Controls.Add(this.tsRememberLastPositionAndState);
            this.gcUISettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcUISettings.Location = new System.Drawing.Point(0, 0);
            this.gcUISettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcUISettings.Name = "gcUISettings";
            this.gcUISettings.Size = new System.Drawing.Size(900, 407);
            this.gcUISettings.TabIndex = 10;
            this.gcUISettings.Text = "UI Settings";
            // 
            // tsRibbonCompactStyle
            // 
            this.tsRibbonCompactStyle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsRibbonCompactStyle.Location = new System.Drawing.Point(13, 32);
            this.tsRibbonCompactStyle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsRibbonCompactStyle.Name = "tsRibbonCompactStyle";
            this.tsRibbonCompactStyle.Properties.OffText = "Standard size for ribbon buttons";
            this.tsRibbonCompactStyle.Properties.OnText = "Compact size for ribbon buttons";
            this.tsRibbonCompactStyle.Size = new System.Drawing.Size(875, 28);
            this.tsRibbonCompactStyle.TabIndex = 17;
            // 
            // pcMenuFont
            // 
            this.pcMenuFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcMenuFont.Controls.Add(this.rbMenuFontSizeDefault);
            this.pcMenuFont.Controls.Add(this.rbMenuFontSizeNormal);
            this.pcMenuFont.Controls.Add(this.rbMenuFontSizeLarge);
            this.pcMenuFont.Controls.Add(this.label6);
            this.pcMenuFont.Controls.Add(this.rbMenuFontSizeVeryLarge);
            this.pcMenuFont.Location = new System.Drawing.Point(11, 214);
            this.pcMenuFont.Name = "pcMenuFont";
            this.pcMenuFont.Size = new System.Drawing.Size(877, 84);
            this.pcMenuFont.TabIndex = 16;
            // 
            // rbMenuFontSizeDefault
            // 
            this.rbMenuFontSizeDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbMenuFontSizeDefault.AutoSize = true;
            this.rbMenuFontSizeDefault.Checked = true;
            this.rbMenuFontSizeDefault.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbMenuFontSizeDefault.Location = new System.Drawing.Point(323, 21);
            this.rbMenuFontSizeDefault.Name = "rbMenuFontSizeDefault";
            this.rbMenuFontSizeDefault.Size = new System.Drawing.Size(96, 32);
            this.rbMenuFontSizeDefault.TabIndex = 15;
            this.rbMenuFontSizeDefault.TabStop = true;
            this.rbMenuFontSizeDefault.Text = "Default";
            this.rbMenuFontSizeDefault.UseVisualStyleBackColor = true;
            // 
            // rbMenuFontSizeNormal
            // 
            this.rbMenuFontSizeNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbMenuFontSizeNormal.AutoSize = true;
            this.rbMenuFontSizeNormal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbMenuFontSizeNormal.Location = new System.Drawing.Point(458, 25);
            this.rbMenuFontSizeNormal.Name = "rbMenuFontSizeNormal";
            this.rbMenuFontSizeNormal.Size = new System.Drawing.Size(88, 27);
            this.rbMenuFontSizeNormal.TabIndex = 12;
            this.rbMenuFontSizeNormal.Text = "Normal";
            this.rbMenuFontSizeNormal.UseVisualStyleBackColor = true;
            // 
            // rbMenuFontSizeLarge
            // 
            this.rbMenuFontSizeLarge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbMenuFontSizeLarge.AutoSize = true;
            this.rbMenuFontSizeLarge.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.rbMenuFontSizeLarge.Location = new System.Drawing.Point(576, 18);
            this.rbMenuFontSizeLarge.Name = "rbMenuFontSizeLarge";
            this.rbMenuFontSizeLarge.Size = new System.Drawing.Size(94, 36);
            this.rbMenuFontSizeLarge.TabIndex = 13;
            this.rbMenuFontSizeLarge.Text = "Large";
            this.rbMenuFontSizeLarge.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Menu contexts Font size:";
            // 
            // rbMenuFontSizeVeryLarge
            // 
            this.rbMenuFontSizeVeryLarge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbMenuFontSizeVeryLarge.AutoSize = true;
            this.rbMenuFontSizeVeryLarge.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.rbMenuFontSizeVeryLarge.Location = new System.Drawing.Point(692, 18);
            this.rbMenuFontSizeVeryLarge.Name = "rbMenuFontSizeVeryLarge";
            this.rbMenuFontSizeVeryLarge.Size = new System.Drawing.Size(162, 41);
            this.rbMenuFontSizeVeryLarge.TabIndex = 14;
            this.rbMenuFontSizeVeryLarge.Text = "Very Large";
            this.rbMenuFontSizeVeryLarge.UseVisualStyleBackColor = true;
            // 
            // pcUiFont
            // 
            this.pcUiFont.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcUiFont.Controls.Add(this.rbFontSizeDefault);
            this.pcUiFont.Controls.Add(this.rbFontSizeVeryLarge);
            this.pcUiFont.Controls.Add(this.rbFontSizeNormal);
            this.pcUiFont.Controls.Add(this.rbFontSizeLarge);
            this.pcUiFont.Controls.Add(this.lblUlFontSize);
            this.pcUiFont.Location = new System.Drawing.Point(11, 127);
            this.pcUiFont.Name = "pcUiFont";
            this.pcUiFont.Size = new System.Drawing.Size(877, 84);
            this.pcUiFont.TabIndex = 15;
            // 
            // rbFontSizeDefault
            // 
            this.rbFontSizeDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbFontSizeDefault.AutoSize = true;
            this.rbFontSizeDefault.Checked = true;
            this.rbFontSizeDefault.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.rbFontSizeDefault.Location = new System.Drawing.Point(347, 31);
            this.rbFontSizeDefault.Name = "rbFontSizeDefault";
            this.rbFontSizeDefault.Size = new System.Drawing.Size(72, 21);
            this.rbFontSizeDefault.TabIndex = 11;
            this.rbFontSizeDefault.TabStop = true;
            this.rbFontSizeDefault.Text = "Default";
            this.rbFontSizeDefault.UseVisualStyleBackColor = true;
            // 
            // rbFontSizeVeryLarge
            // 
            this.rbFontSizeVeryLarge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbFontSizeVeryLarge.AutoSize = true;
            this.rbFontSizeVeryLarge.Font = new System.Drawing.Font("Tahoma", 14F);
            this.rbFontSizeVeryLarge.Location = new System.Drawing.Point(704, 26);
            this.rbFontSizeVeryLarge.Name = "rbFontSizeVeryLarge";
            this.rbFontSizeVeryLarge.Size = new System.Drawing.Size(150, 33);
            this.rbFontSizeVeryLarge.TabIndex = 10;
            this.rbFontSizeVeryLarge.Text = "Very Large";
            this.rbFontSizeVeryLarge.UseVisualStyleBackColor = true;
            // 
            // rbFontSizeNormal
            // 
            this.rbFontSizeNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbFontSizeNormal.AutoSize = true;
            this.rbFontSizeNormal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.rbFontSizeNormal.Location = new System.Drawing.Point(458, 30);
            this.rbFontSizeNormal.Name = "rbFontSizeNormal";
            this.rbFontSizeNormal.Size = new System.Drawing.Size(84, 25);
            this.rbFontSizeNormal.TabIndex = 8;
            this.rbFontSizeNormal.Text = "Normal";
            this.rbFontSizeNormal.UseVisualStyleBackColor = true;
            // 
            // rbFontSizeLarge
            // 
            this.rbFontSizeLarge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbFontSizeLarge.AutoSize = true;
            this.rbFontSizeLarge.Font = new System.Drawing.Font("Tahoma", 12F);
            this.rbFontSizeLarge.Location = new System.Drawing.Point(576, 29);
            this.rbFontSizeLarge.Name = "rbFontSizeLarge";
            this.rbFontSizeLarge.Size = new System.Drawing.Size(81, 28);
            this.rbFontSizeLarge.TabIndex = 9;
            this.rbFontSizeLarge.Text = "Large";
            this.rbFontSizeLarge.UseVisualStyleBackColor = true;
            // 
            // lblUlFontSize
            // 
            this.lblUlFontSize.AutoSize = true;
            this.lblUlFontSize.Location = new System.Drawing.Point(9, 36);
            this.lblUlFontSize.Name = "lblUlFontSize";
            this.lblUlFontSize.Size = new System.Drawing.Size(66, 17);
            this.lblUlFontSize.TabIndex = 6;
            this.lblUlFontSize.Text = "Font size:";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.peAnalogy);
            this.panelControl1.Controls.Add(this.rbtnLightIconColor);
            this.panelControl1.Controls.Add(this.rbtnDarkIconColor);
            this.panelControl1.Location = new System.Drawing.Point(11, 301);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(873, 101);
            this.panelControl1.TabIndex = 7;
            // 
            // peAnalogy
            // 
            this.peAnalogy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.peAnalogy.EditValue = global::Analogy.Properties.Resources.AnalogyDark;
            this.peAnalogy.Location = new System.Drawing.Point(776, 5);
            this.peAnalogy.Name = "peAnalogy";
            this.peAnalogy.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.peAnalogy.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.peAnalogy.Size = new System.Drawing.Size(91, 91);
            this.peAnalogy.TabIndex = 2;
            // 
            // rbtnLightIconColor
            // 
            this.rbtnLightIconColor.AutoSize = true;
            this.rbtnLightIconColor.Location = new System.Drawing.Point(5, 56);
            this.rbtnLightIconColor.Name = "rbtnLightIconColor";
            this.rbtnLightIconColor.Size = new System.Drawing.Size(88, 21);
            this.rbtnLightIconColor.TabIndex = 1;
            this.rbtnLightIconColor.Text = "Light icon";
            this.rbtnLightIconColor.UseVisualStyleBackColor = true;
            // 
            // rbtnDarkIconColor
            // 
            this.rbtnDarkIconColor.AutoSize = true;
            this.rbtnDarkIconColor.Checked = true;
            this.rbtnDarkIconColor.Location = new System.Drawing.Point(5, 17);
            this.rbtnDarkIconColor.Name = "rbtnDarkIconColor";
            this.rbtnDarkIconColor.Size = new System.Drawing.Size(87, 21);
            this.rbtnDarkIconColor.TabIndex = 1;
            this.rbtnDarkIconColor.TabStop = true;
            this.rbtnDarkIconColor.Text = "Dark icon";
            this.rbtnDarkIconColor.UseVisualStyleBackColor = true;
            // 
            // tsRememberLastPositionAndState
            // 
            this.tsRememberLastPositionAndState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsRememberLastPositionAndState.Location = new System.Drawing.Point(11, 64);
            this.tsRememberLastPositionAndState.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsRememberLastPositionAndState.Name = "tsRememberLastPositionAndState";
            this.tsRememberLastPositionAndState.Properties.OffText = "Don\'t remember last position and state of the application";
            this.tsRememberLastPositionAndState.Properties.OnText = "Remember last position and state of the application (size, Location and form\'s st" +
    "ate)";
            this.tsRememberLastPositionAndState.Size = new System.Drawing.Size(877, 28);
            this.tsRememberLastPositionAndState.TabIndex = 5;
            // 
            // tsStartupRibbonMinimized
            // 
            this.tsStartupRibbonMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsStartupRibbonMinimized.EditValue = true;
            this.tsStartupRibbonMinimized.Location = new System.Drawing.Point(13, 96);
            this.tsStartupRibbonMinimized.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tsStartupRibbonMinimized.Name = "tsStartupRibbonMinimized";
            this.tsStartupRibbonMinimized.Properties.OffText = "Show Ribbon";
            this.tsStartupRibbonMinimized.Properties.OnText = "Ribbon is minimized as default";
            this.tsStartupRibbonMinimized.Size = new System.Drawing.Size(756, 28);
            this.tsStartupRibbonMinimized.TabIndex = 18;
            // 
            // ApplicationUISettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcUISettings);
            this.Name = "ApplicationUISettingsUC";
            this.Size = new System.Drawing.Size(900, 668);
            this.Load += new System.EventHandler(this.ApplicationUISettingsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcUISettings)).EndInit();
            this.gcUISettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tsRibbonCompactStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcMenuFont)).EndInit();
            this.pcMenuFont.ResumeLayout(false);
            this.pcMenuFont.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcUiFont)).EndInit();
            this.pcUiFont.ResumeLayout(false);
            this.pcUiFont.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peAnalogy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsRememberLastPositionAndState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsStartupRibbonMinimized.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcUISettings;
        private DevExpress.XtraEditors.ToggleSwitch tsRibbonCompactStyle;
        private DevExpress.XtraEditors.PanelControl pcMenuFont;
        private System.Windows.Forms.RadioButton rbMenuFontSizeDefault;
        private System.Windows.Forms.RadioButton rbMenuFontSizeNormal;
        private System.Windows.Forms.RadioButton rbMenuFontSizeLarge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbMenuFontSizeVeryLarge;
        private DevExpress.XtraEditors.PanelControl pcUiFont;
        private System.Windows.Forms.RadioButton rbFontSizeDefault;
        private System.Windows.Forms.RadioButton rbFontSizeVeryLarge;
        private System.Windows.Forms.RadioButton rbFontSizeNormal;
        private System.Windows.Forms.RadioButton rbFontSizeLarge;
        private System.Windows.Forms.Label lblUlFontSize;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit peAnalogy;
        private System.Windows.Forms.RadioButton rbtnLightIconColor;
        private System.Windows.Forms.RadioButton rbtnDarkIconColor;
        private DevExpress.XtraEditors.ToggleSwitch tsRememberLastPositionAndState;
        private DevExpress.XtraEditors.ToggleSwitch tsStartupRibbonMinimized;
    }
}
