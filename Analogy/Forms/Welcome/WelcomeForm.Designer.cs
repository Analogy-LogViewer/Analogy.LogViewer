namespace Analogy.Forms
{
    partial class WelcomeForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.aceGeneral = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceTheme = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceDataProviders = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceExtensions = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceGlobalTools = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(224, 39);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(1100, 600);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceGeneral,
            this.aceDataProviders,
            this.aceTheme,
            this.aceExtensions,
            this.aceGlobalTools});
            this.accordionControl1.Location = new System.Drawing.Point(0, 39);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.False;
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(224, 600);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // aceGeneral
            // 
            this.aceGeneral.ImageOptions.Image = global::Analogy.Properties.Resources.Analogy_icon1;
            this.aceGeneral.Name = "aceGeneral";
            this.aceGeneral.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceGeneral.Text = "General";
            this.aceGeneral.Click += new System.EventHandler(this.aceGeneral_Click);
            // 
            // aceTheme
            // 
            this.aceTheme.ImageOptions.Image = global::Analogy.Properties.Resources.changetheme_32x32;
            this.aceTheme.Name = "aceTheme";
            this.aceTheme.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceTheme.Text = "Theme";
            this.aceTheme.Click += new System.EventHandler(this.aceTheme_Click);
            // 
            // aceDataProviders
            // 
            this.aceDataProviders.ImageOptions.Image = global::Analogy.Properties.Resources.SelectDataMember_32x32;
            this.aceDataProviders.Name = "aceDataProviders";
            this.aceDataProviders.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDataProviders.Text = "Data Providers";
            this.aceDataProviders.Click += new System.EventHandler(this.aceDataProviders_Click);
            // 
            // aceExtensions
            // 
            this.aceExtensions.ImageOptions.Image = global::Analogy.Properties.Resources.extension32;
            this.aceExtensions.Name = "aceExtensions";
            this.aceExtensions.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceExtensions.Text = "Extensions";
            // 
            // aceGlobalTools
            // 
            this.aceGlobalTools.ImageOptions.Image = global::Analogy.Properties.Resources.IDE_32x32;
            this.aceGlobalTools.Name = "aceGlobalTools";
            this.aceGlobalTools.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceGlobalTools.Text = "Global Tools";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1324, 39);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 639);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WelcomeForm";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Analogy Log Viewer: Welcome";
            this.Load += new System.EventHandler(this.WelcomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceGeneral;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceTheme;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceGlobalTools;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDataProviders;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceExtensions;
    }
}