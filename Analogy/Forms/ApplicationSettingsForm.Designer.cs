
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationSettingsForm));
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.applicationGeneralSettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ApplicationUISettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.messagesFiltering = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.MessagesLayout = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.colorSettings = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.MessagesColorHighlighting = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.predefinedQueries = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.DataProviderList = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.realDataProviderElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.FileExtensionsElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.DataProviderExternal = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.shortcuts = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Extensions = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.updates = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.debugging = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Donations = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceAdvancedMode = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.bbtnReset = new DevExpress.XtraBars.BarButtonItem();
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.applicationGeneralSettings,
            this.ApplicationUISettings,
            this.messagesFiltering,
            this.MessagesLayout,
            this.colorSettings,
            this.MessagesColorHighlighting,
            this.predefinedQueries,
            this.DataProviderList,
            this.realDataProviderElement,
            this.FileExtensionsElement,
            this.DataProviderExternal,
            this.shortcuts,
            this.Extensions,
            this.updates,
            this.debugging,
            this.Donations,
            this.aceAdvancedMode});
            this.accordionControl1.Location = new System.Drawing.Point(0, 31);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(279, 742);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // applicationGeneralSettings
            // 
            this.applicationGeneralSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("applicationGeneralSettings.ImageOptions.Image")));
            this.applicationGeneralSettings.Name = "applicationGeneralSettings";
            this.applicationGeneralSettings.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.applicationGeneralSettings.Text = "General Settings";
            this.applicationGeneralSettings.Click += new System.EventHandler(this.applicationSettings_Click);
            // 
            // ApplicationUISettings
            // 
            this.ApplicationUISettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ApplicationUISettings.ImageOptions.Image")));
            this.ApplicationUISettings.Name = "ApplicationUISettings";
            this.ApplicationUISettings.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ApplicationUISettings.Text = "UI Settings and Themes";
            this.ApplicationUISettings.Click += new System.EventHandler(this.applicationUISettings_Click);
            // 
            // messagesFiltering
            // 
            this.messagesFiltering.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("messagesFiltering.ImageOptions.Image")));
            this.messagesFiltering.Name = "messagesFiltering";
            this.messagesFiltering.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.messagesFiltering.Text = "Filtering and Interactions";
            this.messagesFiltering.Click += new System.EventHandler(this.messagesFiltering_Click);
            // 
            // MessagesLayout
            // 
            this.MessagesLayout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MessagesLayout.ImageOptions.Image")));
            this.MessagesLayout.Name = "MessagesLayout";
            this.MessagesLayout.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.MessagesLayout.Text = "Columns Layout";
            this.MessagesLayout.Click += new System.EventHandler(this.MessagesLayout_Click);
            // 
            // colorSettings
            // 
            this.colorSettings.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("colorSettings.ImageOptions.Image")));
            this.colorSettings.Name = "colorSettings";
            this.colorSettings.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.colorSettings.Text = "Colors Settings";
            this.colorSettings.Click += new System.EventHandler(this.colorSettings_Click);
            // 
            // MessagesColorHighlighting
            // 
            this.MessagesColorHighlighting.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MessagesColorHighlighting.ImageOptions.Image")));
            this.MessagesColorHighlighting.Name = "MessagesColorHighlighting";
            this.MessagesColorHighlighting.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.MessagesColorHighlighting.Text = "Color Highlighting";
            this.MessagesColorHighlighting.Click += new System.EventHandler(this.MessagesColorHighlighting_Click);
            // 
            // predefinedQueries
            // 
            this.predefinedQueries.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("predefinedQueries.ImageOptions.Image")));
            this.predefinedQueries.Name = "predefinedQueries";
            this.predefinedQueries.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.predefinedQueries.Text = "Predefined queries";
            this.predefinedQueries.Click += new System.EventHandler(this.predefinedQueries_Click);
            // 
            // DataProviderList
            // 
            this.DataProviderList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("DataProviderList.ImageOptions.Image")));
            this.DataProviderList.Name = "DataProviderList";
            this.DataProviderList.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.DataProviderList.Text = "List Of Providers";
            this.DataProviderList.Click += new System.EventHandler(this.DataProviderList_Click);
            // 
            // realDataProviderElement
            // 
            this.realDataProviderElement.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("realDataProviderElement.ImageOptions.Image")));
            this.realDataProviderElement.Name = "realDataProviderElement";
            this.realDataProviderElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.realDataProviderElement.Text = "Real Time Data Providers";
            this.realDataProviderElement.Click += new System.EventHandler(this.accordionControlElement4_Click);
            // 
            // FileExtensionsElement
            // 
            this.FileExtensionsElement.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("FileExtensionsElement.ImageOptions.Image")));
            this.FileExtensionsElement.Name = "FileExtensionsElement";
            this.FileExtensionsElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.FileExtensionsElement.Text = "Default File Associations";
            this.FileExtensionsElement.Click += new System.EventHandler(this.accordionControlElement5_Click);
            // 
            // DataProviderExternal
            // 
            this.DataProviderExternal.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("DataProviderExternal.ImageOptions.Image")));
            this.DataProviderExternal.Name = "DataProviderExternal";
            this.DataProviderExternal.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.DataProviderExternal.Text = "Additional Locations";
            this.DataProviderExternal.Click += new System.EventHandler(this.DataProviderExternal_Click);
            // 
            // shortcuts
            // 
            this.shortcuts.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("shortcuts.ImageOptions.Image")));
            this.shortcuts.Name = "shortcuts";
            this.shortcuts.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.shortcuts.Text = "Shortcuts";
            this.shortcuts.Click += new System.EventHandler(this.shortcuts_Click);
            // 
            // Extensions
            // 
            this.Extensions.ImageOptions.Image = global::Analogy.Properties.Resources.extension32;
            this.Extensions.Name = "Extensions";
            this.Extensions.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Extensions.Text = "Extensions";
            this.Extensions.Click += new System.EventHandler(this.Extensions_Click);
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
            this.debugging.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("debugging.ImageOptions.Image")));
            this.debugging.Name = "debugging";
            this.debugging.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.debugging.Text = "Debugging";
            this.debugging.Click += new System.EventHandler(this.debugging_Click);
            // 
            // Donations
            // 
            this.Donations.ImageOptions.Image = global::Analogy.Properties.Resources.heart32x32;
            this.Donations.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.Donations.Name = "Donations";
            this.Donations.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Donations.Text = "Support";
            this.Donations.Click += new System.EventHandler(this.Donations_Click);
            // 
            // aceAdvancedMode
            // 
            this.aceAdvancedMode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("aceAdvancedMode.ImageOptions.Image")));
            this.aceAdvancedMode.Name = "aceAdvancedMode";
            this.aceAdvancedMode.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceAdvancedMode.Text = "Advanced Features";
            this.aceAdvancedMode.Click += new System.EventHandler(this.aceAdvancedMode_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbtnReset});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1027, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.bbtnReset);
            // 
            // bbtnReset
            // 
            this.bbtnReset.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bbtnReset.Caption = "Reset Settings";
            this.bbtnReset.Id = 0;
            this.bbtnReset.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnReset.ImageOptions.Image")));
            this.bbtnReset.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbtnReset.ImageOptions.LargeImage")));
            this.bbtnReset.Name = "bbtnReset";
            this.bbtnReset.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbtnReset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnReset_ItemClick);
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(279, 31);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(748, 742);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // ApplicationSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 773);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ApplicationSettingsForm";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Application Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ApplicationSettingsForm_FormClosing);
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
        private DevExpress.XtraBars.Navigation.AccordionControlElement messagesFiltering;
        private DevExpress.XtraBars.Navigation.AccordionControlElement updates;
        private DevExpress.XtraBars.Navigation.AccordionControlElement debugging;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ApplicationUISettings;
        private DevExpress.XtraBars.Navigation.AccordionControlElement DataProviderList;
        private DevExpress.XtraBars.Navigation.AccordionControlElement realDataProviderElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement FileExtensionsElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement DataProviderExternal;
        private DevExpress.XtraBars.BarButtonItem bbtnReset;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Donations;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceAdvancedMode;
    }
}