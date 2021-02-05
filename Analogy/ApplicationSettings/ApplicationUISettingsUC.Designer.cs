
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
            this.tsStartupRibbonMinimized = new DevExpress.XtraEditors.ToggleSwitch();
            this.tsRibbonCompactStyle = new DevExpress.XtraEditors.ToggleSwitch();
            this.peAnalogy = new DevExpress.XtraEditors.PictureEdit();
            this.tsRememberLastPositionAndState = new DevExpress.XtraEditors.ToggleSwitch();
            this.ceFontsDefault = new DevExpress.XtraEditors.CheckEdit();
            this.gcFonts = new DevExpress.XtraEditors.GroupControl();
            this.ceFontsNormal = new DevExpress.XtraEditors.CheckEdit();
            this.ceFontsVeryLarge = new DevExpress.XtraEditors.CheckEdit();
            this.ceFontsLarge = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ceContextMenuFontsVeryLarge = new DevExpress.XtraEditors.CheckEdit();
            this.ceContextMenuFontsLarge = new DevExpress.XtraEditors.CheckEdit();
            this.ceContextMenuFontsNormal = new DevExpress.XtraEditors.CheckEdit();
            this.ceContextMenuFontsDefault = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.ceIconLight = new DevExpress.XtraEditors.CheckEdit();
            this.ceIconDark = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUISettings)).BeginInit();
            this.gcUISettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsStartupRibbonMinimized.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsRibbonCompactStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peAnalogy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsRememberLastPositionAndState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFontsDefault.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFonts)).BeginInit();
            this.gcFonts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceFontsNormal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFontsVeryLarge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFontsLarge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceContextMenuFontsVeryLarge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceContextMenuFontsLarge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceContextMenuFontsNormal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceContextMenuFontsDefault.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceIconLight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIconDark.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcUISettings
            // 
            this.gcUISettings.Controls.Add(this.groupControl2);
            this.gcUISettings.Controls.Add(this.groupControl1);
            this.gcUISettings.Controls.Add(this.gcFonts);
            this.gcUISettings.Controls.Add(this.tsStartupRibbonMinimized);
            this.gcUISettings.Controls.Add(this.tsRibbonCompactStyle);
            this.gcUISettings.Controls.Add(this.tsRememberLastPositionAndState);
            this.gcUISettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcUISettings.Location = new System.Drawing.Point(0, 0);
            this.gcUISettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcUISettings.Name = "gcUISettings";
            this.gcUISettings.Size = new System.Drawing.Size(900, 456);
            this.gcUISettings.TabIndex = 10;
            this.gcUISettings.Text = "UI Settings";
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
            // peAnalogy
            // 
            this.peAnalogy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.peAnalogy.EditValue = global::Analogy.Properties.Resources.AnalogyDark;
            this.peAnalogy.Location = new System.Drawing.Point(779, 27);
            this.peAnalogy.Name = "peAnalogy";
            this.peAnalogy.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.peAnalogy.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.peAnalogy.Size = new System.Drawing.Size(91, 91);
            this.peAnalogy.TabIndex = 2;
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
            // ceFontsDefault
            // 
            this.ceFontsDefault.Location = new System.Drawing.Point(15, 38);
            this.ceFontsDefault.Name = "ceFontsDefault";
            this.ceFontsDefault.Properties.Caption = "Default";
            this.ceFontsDefault.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceFontsDefault.Properties.RadioGroupIndex = 1;
            this.ceFontsDefault.Size = new System.Drawing.Size(108, 20);
            this.ceFontsDefault.TabIndex = 19;
            // 
            // gcFonts
            // 
            this.gcFonts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcFonts.Controls.Add(this.ceFontsVeryLarge);
            this.gcFonts.Controls.Add(this.ceFontsLarge);
            this.gcFonts.Controls.Add(this.ceFontsNormal);
            this.gcFonts.Controls.Add(this.ceFontsDefault);
            this.gcFonts.Location = new System.Drawing.Point(13, 140);
            this.gcFonts.Name = "gcFonts";
            this.gcFonts.Size = new System.Drawing.Size(875, 84);
            this.gcFonts.TabIndex = 20;
            this.gcFonts.Text = "Fonts Size";
            // 
            // ceFontsNormal
            // 
            this.ceFontsNormal.Location = new System.Drawing.Point(172, 38);
            this.ceFontsNormal.Name = "ceFontsNormal";
            this.ceFontsNormal.Properties.Caption = "Normal";
            this.ceFontsNormal.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceFontsNormal.Properties.RadioGroupIndex = 1;
            this.ceFontsNormal.Size = new System.Drawing.Size(108, 20);
            this.ceFontsNormal.TabIndex = 20;
            this.ceFontsNormal.TabStop = false;
            // 
            // ceFontsVeryLarge
            // 
            this.ceFontsVeryLarge.Location = new System.Drawing.Point(486, 38);
            this.ceFontsVeryLarge.Name = "ceFontsVeryLarge";
            this.ceFontsVeryLarge.Properties.Caption = "Very Large";
            this.ceFontsVeryLarge.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceFontsVeryLarge.Properties.RadioGroupIndex = 1;
            this.ceFontsVeryLarge.Size = new System.Drawing.Size(108, 20);
            this.ceFontsVeryLarge.TabIndex = 22;
            this.ceFontsVeryLarge.TabStop = false;
            // 
            // ceFontsLarge
            // 
            this.ceFontsLarge.Location = new System.Drawing.Point(329, 38);
            this.ceFontsLarge.Name = "ceFontsLarge";
            this.ceFontsLarge.Properties.Caption = "Large";
            this.ceFontsLarge.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceFontsLarge.Properties.RadioGroupIndex = 1;
            this.ceFontsLarge.Size = new System.Drawing.Size(108, 20);
            this.ceFontsLarge.TabIndex = 21;
            this.ceFontsLarge.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.ceContextMenuFontsVeryLarge);
            this.groupControl1.Controls.Add(this.ceContextMenuFontsLarge);
            this.groupControl1.Controls.Add(this.ceContextMenuFontsNormal);
            this.groupControl1.Controls.Add(this.ceContextMenuFontsDefault);
            this.groupControl1.Location = new System.Drawing.Point(13, 228);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(875, 84);
            this.groupControl1.TabIndex = 21;
            this.groupControl1.Text = "Context Menus Font size:";
            // 
            // ceContextMenuFontsVeryLarge
            // 
            this.ceContextMenuFontsVeryLarge.Location = new System.Drawing.Point(486, 38);
            this.ceContextMenuFontsVeryLarge.Name = "ceContextMenuFontsVeryLarge";
            this.ceContextMenuFontsVeryLarge.Properties.Caption = "Very Large";
            this.ceContextMenuFontsVeryLarge.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceContextMenuFontsVeryLarge.Properties.RadioGroupIndex = 2;
            this.ceContextMenuFontsVeryLarge.Size = new System.Drawing.Size(108, 20);
            this.ceContextMenuFontsVeryLarge.TabIndex = 22;
            this.ceContextMenuFontsVeryLarge.TabStop = false;
            // 
            // ceContextMenuFontsLarge
            // 
            this.ceContextMenuFontsLarge.Location = new System.Drawing.Point(329, 38);
            this.ceContextMenuFontsLarge.Name = "ceContextMenuFontsLarge";
            this.ceContextMenuFontsLarge.Properties.Caption = "Large";
            this.ceContextMenuFontsLarge.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceContextMenuFontsLarge.Properties.RadioGroupIndex = 2;
            this.ceContextMenuFontsLarge.Size = new System.Drawing.Size(108, 20);
            this.ceContextMenuFontsLarge.TabIndex = 21;
            this.ceContextMenuFontsLarge.TabStop = false;
            // 
            // ceContextMenuFontsNormal
            // 
            this.ceContextMenuFontsNormal.Location = new System.Drawing.Point(172, 38);
            this.ceContextMenuFontsNormal.Name = "ceContextMenuFontsNormal";
            this.ceContextMenuFontsNormal.Properties.Caption = "Normal";
            this.ceContextMenuFontsNormal.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceContextMenuFontsNormal.Properties.RadioGroupIndex = 2;
            this.ceContextMenuFontsNormal.Size = new System.Drawing.Size(108, 20);
            this.ceContextMenuFontsNormal.TabIndex = 20;
            this.ceContextMenuFontsNormal.TabStop = false;
            // 
            // ceContextMenuFontsDefault
            // 
            this.ceContextMenuFontsDefault.Location = new System.Drawing.Point(15, 38);
            this.ceContextMenuFontsDefault.Name = "ceContextMenuFontsDefault";
            this.ceContextMenuFontsDefault.Properties.Caption = "Default";
            this.ceContextMenuFontsDefault.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceContextMenuFontsDefault.Properties.RadioGroupIndex = 2;
            this.ceContextMenuFontsDefault.Size = new System.Drawing.Size(108, 20);
            this.ceContextMenuFontsDefault.TabIndex = 19;
            this.ceContextMenuFontsDefault.TabStop = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.peAnalogy);
            this.groupControl2.Controls.Add(this.ceIconLight);
            this.groupControl2.Controls.Add(this.ceIconDark);
            this.groupControl2.Location = new System.Drawing.Point(13, 321);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(875, 123);
            this.groupControl2.TabIndex = 22;
            this.groupControl2.Text = "Context Menus Font size:";
            // 
            // ceIconLight
            // 
            this.ceIconLight.Location = new System.Drawing.Point(15, 80);
            this.ceIconLight.Name = "ceIconLight";
            this.ceIconLight.Properties.Caption = "Light Icon";
            this.ceIconLight.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceIconLight.Properties.RadioGroupIndex = 3;
            this.ceIconLight.Size = new System.Drawing.Size(108, 20);
            this.ceIconLight.TabIndex = 20;
            this.ceIconLight.TabStop = false;
            // 
            // ceIconDark
            // 
            this.ceIconDark.Location = new System.Drawing.Point(15, 45);
            this.ceIconDark.Name = "ceIconDark";
            this.ceIconDark.Properties.Caption = "Dark Icon";
            this.ceIconDark.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.ceIconDark.Properties.RadioGroupIndex = 3;
            this.ceIconDark.Size = new System.Drawing.Size(108, 20);
            this.ceIconDark.TabIndex = 19;
            this.ceIconDark.TabStop = false;
            // 
            // ApplicationUISettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.gcUISettings);
            this.Name = "ApplicationUISettingsUC";
            this.Size = new System.Drawing.Size(900, 668);
            this.Load += new System.EventHandler(this.ApplicationUISettingsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcUISettings)).EndInit();
            this.gcUISettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tsStartupRibbonMinimized.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsRibbonCompactStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peAnalogy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsRememberLastPositionAndState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFontsDefault.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFonts)).EndInit();
            this.gcFonts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceFontsNormal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFontsVeryLarge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFontsLarge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceContextMenuFontsVeryLarge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceContextMenuFontsLarge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceContextMenuFontsNormal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceContextMenuFontsDefault.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceIconLight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIconDark.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcUISettings;
        private DevExpress.XtraEditors.ToggleSwitch tsRibbonCompactStyle;
        private DevExpress.XtraEditors.PictureEdit peAnalogy;
        private DevExpress.XtraEditors.ToggleSwitch tsRememberLastPositionAndState;
        private DevExpress.XtraEditors.ToggleSwitch tsStartupRibbonMinimized;
        private DevExpress.XtraEditors.GroupControl gcFonts;
        private DevExpress.XtraEditors.CheckEdit ceFontsVeryLarge;
        private DevExpress.XtraEditors.CheckEdit ceFontsLarge;
        private DevExpress.XtraEditors.CheckEdit ceFontsNormal;
        private DevExpress.XtraEditors.CheckEdit ceFontsDefault;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit ceContextMenuFontsVeryLarge;
        private DevExpress.XtraEditors.CheckEdit ceContextMenuFontsLarge;
        private DevExpress.XtraEditors.CheckEdit ceContextMenuFontsNormal;
        private DevExpress.XtraEditors.CheckEdit ceContextMenuFontsDefault;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.CheckEdit ceIconLight;
        private DevExpress.XtraEditors.CheckEdit ceIconDark;
    }
}
