using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Interfaces;
using Analogy.Managers;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Analogy.ApplicationSettings
{
    public partial class MessagesLayoutSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;
        private DataTable messageData;
        public MessagesLayoutSettingsUC()
        {
            InitializeComponent();
            messageData = Utils.DataTableConstructor();
        }

        private void MessagesLayoutSettingsUC_Load(object sender, EventArgs e)
        {
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
            logGrid.Columns["Date"].DisplayFormat.FormatType = FormatType.DateTime;
            logGrid.Columns["Date"].DisplayFormat.FormatString = Settings.DateTimePattern;
            teDateTimeFormat.Text = Settings.DateTimePattern;
            timeSpanEditOffset.EditValue = Settings.TimeOffset;
        }
        private void SetupExampleMessage(string text)
        {
            DataRow dtr = messageData.NewRow();
            dtr.BeginEdit();
            dtr["Date"] = DateTime.Now;
            dtr["Text"] = text;
            dtr["Source"] = "Analogy";
            dtr["Level"] = AnalogyLogLevel.Information.ToString();
            dtr["Class"] = AnalogyLogClass.General.ToString();
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
                logGrid.Columns["Date"].DisplayFormat.FormatType = FormatType.DateTime;
                logGrid.Columns["Date"].DisplayFormat.FormatString = teDateTimeFormat.Text;
                Settings.DateTimePattern = teDateTimeFormat.Text;
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
                AnalogyLogger.Instance.LogException($"Error saving setting: {e.Message}", e, "Analogy");
                XtraMessageBox.Show(e.Message, $"Error Saving layout file: {e.Message}", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }
}
