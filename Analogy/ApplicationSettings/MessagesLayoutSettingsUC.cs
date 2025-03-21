﻿using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Managers;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Analogy.ApplicationSettings
{
    public partial class MessagesLayoutSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private IUserSettingsManager Settings { get; }
        private DataTable messageData;
        public MessagesLayoutSettingsUC(IAnalogyUserSettings settings)
        {
            this.Settings = settings;
            InitializeComponent();
            messageData = Analogy.CommonControls.Utils.DataTableConstructor();
        }

        private void MessagesLayoutSettingsUC_Load(object sender, EventArgs e)
        {
            cbOffsetType.Properties.Items.AddRange(Enum.GetValues(typeof(TimeOffsetType)));
            cbOffsetType.SelectedItem = Settings.TimeOffsetType;
            cbOffsetType.SelectedIndexChanged += (s, e) =>
            {
                Settings.TimeOffsetType = (TimeOffsetType)cbOffsetType.SelectedItem;
            };
            LoadSettings();
            SetupEventsHandlers();
            if (File.Exists(Settings.LogGridFileName))
            {
                gridControl.MainView.RestoreLayoutFromXml(Settings.LogGridFileName);
            }

            gridControl.DataSource = messageData.DefaultView;
            SetupExampleMessage("Test 1");
            SetupExampleMessage("Test 2");
        }

        private void LoadSettings()
        {
            gridColumnThread.FieldName = Common.CommonUtils.ColumnThreadId;
            gridColumnProcessID.FieldName = Common.CommonUtils.ColumnProcessId;
            gridColumnModule.FieldName = Common.CommonUtils.ColumnModule;

            logGrid.Columns["Date"].DisplayFormat.FormatType = FormatType.DateTime;
            logGrid.Columns["Date"].DisplayFormat.FormatString = Settings.DateTimePattern;
            teDateTimeFormat.Text = Settings.DateTimePattern;
            timeSpanEditOffset.EditValue = Settings.TimeOffset;
        }
        private void SetupExampleMessage(string text)
        {
            DataRow dtr = messageData.NewRow();
            dtr.BeginEdit();
            var date = DateTimeOffset.Now;
            dtr["Date"] = date;
            dtr["DateTimestamp"] = date.Ticks;
            dtr["Text"] = text;
            dtr["Source"] = "Analogy";
            dtr["Level"] = AnalogyLogLevel.Information;
            dtr["Class"] = AnalogyLogClass.General;
            dtr["Category"] = "None";
            dtr["User"] = "None";
            dtr["Module"] = "Analogy";
            dtr["ProcessID"] = Process.GetCurrentProcess().Id;
            dtr["ThreadID"] = Thread.CurrentThread.ManagedThreadId;
            dtr["DataProvider"] = string.Empty;
            dtr["MachineName"] = "None";
            dtr.EndEdit();
            messageData.Rows.Add(dtr);
            messageData.AcceptChanges();
        }

        private void SetupEventsHandlers()
        {
            timeSpanEditOffset.EditValueChanged += (s, e) =>
            {
                Settings.TimeOffset = (TimeSpan)timeSpanEditOffset.EditValue;
            };
            logGrid.MouseDown += (s, e) =>
            {
                GridHitInfo info = logGrid.CalcHitInfo(e.Location);
                if (info.InColumnPanel)
                {
                    teHeader.Tag = info.Column;
                    teHeader.Text = info.Column.Caption;
                }
            };
            gridControl.MainView.Layout += (s, e) =>
            {
                try
                {
                    if (!string.IsNullOrEmpty(Settings.LogGridFileName))
                    {
                        gridControl.MainView.SaveLayoutToXml(Settings.LogGridFileName);
                    }
                }
                catch (Exception ex)
                {
                    AnalogyLogManager.Instance.LogError(ex.Message, "");
                }
            };

            sbtnHeaderSet.Click += (s, e) =>
            {
                if (!string.IsNullOrEmpty(teHeader.Text) && teHeader.Tag is DevExpress.XtraGrid.Columns.GridColumn column)
                {
                    column.Caption = teHeader.Text;
                    SaveGridLayout();
                }
            };

            sbtnDateTimeFormat.Click += (s, e) =>
            {
                try
                {
                    //logGrid.Columns["Date"].DisplayFormat.FormatType = FormatType.DateTime;
                    //logGrid.Columns["Date"].DisplayFormat.FormatString = teDateTimeFormat.Text;
                    Settings.DateTimePattern = teDateTimeFormat.Text;
                }
                catch (Exception exception)
                {
                    XtraMessageBox.Show("Invalid format", "Invalid format");
                }
            };
        }

        private void SaveGridLayout()
        {
            try
            {
                gridControl.MainView.SaveLayoutToXml(Settings.LogGridFileName);
            }
            catch (Exception e)
            {
                ServicesProvider.Instance.GetService<ILogger>().LogError($"Error saving setting: {e.Message}", e, "Analogy");
                XtraMessageBox.Show(e.Message, $"Error Saving layout file: {e.Message}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}