
namespace Analogy.ApplicationSettings
{
    partial class DataProvidersSettingsUC
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
            DevExpress.XtraEditors.TableLayout.ItemTemplateBase itemTemplateBase1 = new DevExpress.XtraEditors.TableLayout.ItemTemplateBase();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement1 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement2 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement3 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan1 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            this.chkLstDataProviderStatus = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.tsRememberLastOpenedDataProvider = new DevExpress.XtraEditors.ToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.chkLstDataProviderStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsRememberLastOpenedDataProvider.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chkLstDataProviderStatus
            // 
            this.chkLstDataProviderStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLstDataProviderStatus.ItemHeight = 62;
            this.chkLstDataProviderStatus.Location = new System.Drawing.Point(0, 64);
            this.chkLstDataProviderStatus.Name = "chkLstDataProviderStatus";
            this.chkLstDataProviderStatus.Size = new System.Drawing.Size(734, 474);
            this.chkLstDataProviderStatus.TabIndex = 15;
            tableColumnDefinition1.Length.Value = 70D;
            tableColumnDefinition2.Length.Value = 660D;
            itemTemplateBase1.Columns.Add(tableColumnDefinition1);
            itemTemplateBase1.Columns.Add(tableColumnDefinition2);
            templatedItemElement1.FieldName = null;
            templatedItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement1.Text = "";
            templatedItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement2.Appearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            templatedItemElement2.Appearance.Normal.ForeColor = System.Drawing.Color.Blue;
            templatedItemElement2.Appearance.Normal.Options.UseFont = true;
            templatedItemElement2.Appearance.Normal.Options.UseForeColor = true;
            templatedItemElement2.ColumnIndex = 1;
            templatedItemElement2.FieldName = null;
            templatedItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement2.Text = "Name";
            templatedItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            templatedItemElement3.ColumnIndex = 1;
            templatedItemElement3.FieldName = null;
            templatedItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement3.RowIndex = 1;
            templatedItemElement3.Text = "description";
            templatedItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft;
            itemTemplateBase1.Elements.Add(templatedItemElement1);
            itemTemplateBase1.Elements.Add(templatedItemElement2);
            itemTemplateBase1.Elements.Add(templatedItemElement3);
            itemTemplateBase1.Name = "template1";
            itemTemplateBase1.Rows.Add(tableRowDefinition1);
            itemTemplateBase1.Rows.Add(tableRowDefinition2);
            tableSpan1.RowSpan = 2;
            itemTemplateBase1.Spans.Add(tableSpan1);
            this.chkLstDataProviderStatus.Templates.Add(itemTemplateBase1);
            // 
            // labelControl7
            // 
            this.labelControl7.AutoEllipsis = true;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl7.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl7.Location = new System.Drawing.Point(0, 28);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Padding = new System.Windows.Forms.Padding(3, 10, 10, 10);
            this.labelControl7.Size = new System.Drawing.Size(734, 36);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "Status (enable/ disabled) of data providers. Re-enabling  a provider will take af" +
    "fect after restarting of the application";
            // 
            // tsRememberLastOpenedDataProvider
            // 
            this.tsRememberLastOpenedDataProvider.Dock = System.Windows.Forms.DockStyle.Top;
            this.tsRememberLastOpenedDataProvider.Location = new System.Drawing.Point(0, 0);
            this.tsRememberLastOpenedDataProvider.Margin = new System.Windows.Forms.Padding(5);
            this.tsRememberLastOpenedDataProvider.Name = "tsRememberLastOpenedDataProvider";
            this.tsRememberLastOpenedDataProvider.Properties.OffText = "Don\'t remember last opened Data provider on startup";
            this.tsRememberLastOpenedDataProvider.Properties.OnText = "Remember last opened Data provider on startup and switch to it after restart";
            this.tsRememberLastOpenedDataProvider.Size = new System.Drawing.Size(734, 28);
            this.tsRememberLastOpenedDataProvider.TabIndex = 14;
            // 
            // DataProvidersSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.chkLstDataProviderStatus);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.tsRememberLastOpenedDataProvider);
            this.Name = "DataProvidersSettingsUC";
            this.Size = new System.Drawing.Size(734, 538);
            this.Load += new System.EventHandler(this.DataProvidersSettingsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkLstDataProviderStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsRememberLastOpenedDataProvider.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl chkLstDataProviderStatus;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ToggleSwitch tsRememberLastOpenedDataProvider;
    }
}
