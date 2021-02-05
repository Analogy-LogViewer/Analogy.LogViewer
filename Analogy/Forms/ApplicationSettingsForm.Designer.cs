
namespace Analogy.Forms
{
    partial class ApplicationSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationSettingsForm));
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.applicationGeneralSettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Extensions = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.MessagesLayout = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.colorSettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.shortcuts = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.MessagesColorHighlighting = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.predefinedQueries = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.messagesFiltering = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.updates = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.debugging = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.DataProviders = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.ApplicationUISettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement2,
            this.accordionControlElement1,
            this.DataProviders,
            this.predefinedQueries,
            this.shortcuts,
            this.Extensions,
            this.updates,
            this.debugging});
            this.accordionControl1.Location = new System.Drawing.Point(0, 30);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 636);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // applicationGeneralSettings
            // 
            this.applicationGeneralSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement1.ImageOptions.Image")));
            this.applicationGeneralSettings.Name = "applicationGeneralSettings";
            this.applicationGeneralSettings.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.applicationGeneralSettings.Text = "General Settings";
            this.applicationGeneralSettings.Click += new System.EventHandler(this.applicationSettings_Click);
            // 
            // Extensions
            // 
            this.Extensions.ImageOptions.Image = global::Analogy.Properties.Resources.extension32;
            this.Extensions.Name = "Extensions";
            this.Extensions.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Extensions.Text = "Extensions";
            this.Extensions.Click += new System.EventHandler(this.Extensions_Click);
            // 
            // MessagesLayout
            // 
            this.MessagesLayout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement3.ImageOptions.Image")));
            this.MessagesLayout.Name = "MessagesLayout";
            this.MessagesLayout.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.MessagesLayout.Text = "Columns Layout";
            this.MessagesLayout.Click += new System.EventHandler(this.MessagesLayout_Click);
            // 
            // colorSettings
            // 
            this.colorSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement4.ImageOptions.Image")));
            this.colorSettings.Name = "colorSettings";
            this.colorSettings.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.colorSettings.Text = "Colors Settings";
            this.colorSettings.Click += new System.EventHandler(this.colorSettings_Click);
            // 
            // shortcuts
            // 
            this.shortcuts.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement5.ImageOptions.Image")));
            this.shortcuts.Name = "shortcuts";
            this.shortcuts.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.shortcuts.Text = "Shortcuts";
            this.shortcuts.Click += new System.EventHandler(this.shortcuts_Click);
            // 
            // MessagesColorHighlighting
            // 
            this.MessagesColorHighlighting.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement7.ImageOptions.Image")));
            this.MessagesColorHighlighting.Name = "MessagesColorHighlighting";
            this.MessagesColorHighlighting.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.MessagesColorHighlighting.Text = "Color Highlighting";
            this.MessagesColorHighlighting.Click += new System.EventHandler(this.MessagesColorHighlighting_Click);
            // 
            // predefinedQueries
            // 
            this.predefinedQueries.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement8.ImageOptions.Image")));
            this.predefinedQueries.Name = "predefinedQueries";
            this.predefinedQueries.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.predefinedQueries.Text = "Predefined queries";
            this.predefinedQueries.Click += new System.EventHandler(this.predefinedQueries_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1023, 30);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.messagesFiltering,
            this.MessagesLayout,
            this.colorSettings,
            this.MessagesColorHighlighting});
            this.accordionControlElement1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement1.ImageOptions.Image1")));
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Messages Settings";
            // 
            // messagesFiltering
            // 
            this.messagesFiltering.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("messagesFiltering.ImageOptions.Image")));
            this.messagesFiltering.Name = "messagesFiltering";
            this.messagesFiltering.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.messagesFiltering.Text = "Filtering and Interactions";
            this.messagesFiltering.Click += new System.EventHandler(this.messagesFiltering_Click);
            // 
            // updates
            // 
            this.updates.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("updates.ImageOptions.Image")));
            this.updates.Name = "updates";
            this.updates.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.updates.Text = "Updates";
            this.updates.Click += new System.EventHandler(this.updates_Click);
            // 
            // debugging
            // 
            this.debugging.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement3.ImageOptions.Image1")));
            this.debugging.Name = "debugging";
            this.debugging.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.debugging.Text = "Debugging";
            this.debugging.Click += new System.EventHandler(this.debugging_Click);
            // 
            // DataProviders
            // 
            this.DataProviders.Expanded = true;
            this.DataProviders.ImageOptions.Image = global::Analogy.Properties.Resources.Analogy_Icon2;
            this.DataProviders.Name = "DataProviders";
            this.DataProviders.Text = "Data Providers";
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.applicationGeneralSettings,
            this.ApplicationUISettings});
            this.accordionControlElement2.Expanded = true;
            this.accordionControlElement2.ImageOptions.Image = global::Analogy.Properties.Resources.Analogy_image_32x32;
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Text = "Application Settings";
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(260, 30);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(763, 636);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // ApplicationUISettings
            // 
            this.ApplicationUISettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ApplicationUISettings.ImageOptions.Image")));
            this.ApplicationUISettings.Name = "ApplicationUISettings";
            this.ApplicationUISettings.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ApplicationUISettings.Text = "UI Settings";
            this.ApplicationUISettings.Click += new System.EventHandler(this.applicationUISettings_Click);
            // 
            // ApplicationSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 666);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "ApplicationSettingsForm";
            this.NavigationControl = this.accordionControl1;
            this.Text = "ApplicationSettingsForm";
            this.Load += new System.EventHandler(this.ApplicationSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement applicationGeneralSettings;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Extensions;
        private DevExpress.XtraBars.Navigation.AccordionControlElement MessagesLayout;
        private DevExpress.XtraBars.Navigation.AccordionControlElement colorSettings;
        private DevExpress.XtraBars.Navigation.AccordionControlElement shortcuts;
        private DevExpress.XtraBars.Navigation.AccordionControlElement MessagesColorHighlighting;
        private DevExpress.XtraBars.Navigation.AccordionControlElement predefinedQueries;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement messagesFiltering;
        private DevExpress.XtraBars.Navigation.AccordionControlElement updates;
        private DevExpress.XtraBars.Navigation.AccordionControlElement debugging;
        private DevExpress.XtraBars.Navigation.AccordionControlElement DataProviders;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ApplicationUISettings;
    }
}