using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.CommonControls.DataTypes;
using Analogy.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Analogy.Extensions
{
    public partial class LogsMessageGroupingExtensionUC : XtraUserControl
    {
        private IUserSettingsManager Settings { get; }
        public IAnalogyDataProvider DataProvider { get; set; }
        public IAnalogyOfflineDataProvider? FileDataProvider { get; set; }
        private Dictionary<string, List<AnalogyLogMessage>> groupingByChars;
        public ManualResetEvent columnAdderSync = new ManualResetEvent(false);

        public List<AnalogyLogMessage> Messages
        {
            get
            {
                return new List<AnalogyLogMessage>();
            }
        }
        public LogsMessageGroupingExtensionUC(IAnalogyUserSettings settings)
        {
            Settings = settings;
            InitializeComponent();
        }
        private void LogsMessageGroupingExtensionUC_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            LoadUISettings();
            SetupEventsHandlers();
        }
        private void SetupEventsHandlers()
        {
            dockManager1.StartDocking += (s, e) =>
            {
                if (e.Panel.DockedAsTabbedDocument)
                {
                    var sz = e.Panel.Size;
                    BeginInvoke(new Action(() =>
                    {
                        e.Panel.FloatSize = sz;

                        //adjust the new panel size taking the header height into account:
                        e.Panel.FloatSize = new Size(e.Panel.FloatSize.Width, 2 * e.Panel.FloatSize.Height - e.Panel.ControlContainer.Height);
                    }));
                }
                else
                {
                    e.Panel.FloatSize = e.Panel.Size;
                }
            };
            gridViewGrouping2.RowStyle += LogGridView_RowStyle;
        }
        private void LoadUISettings()
        {
            gridViewGrouping2.Columns["Date"].DisplayFormat.FormatType = FormatType.DateTime;
            gridViewGrouping2.Columns["Date"].DisplayFormat.FormatString = Settings.DateTimePattern;
        }
        private void LogGridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (!Settings.ColorSettings.EnableMessagesColors || !(sender is GridView view) || e.RowHandle < 0)
            {
                return;
            }

            IAnalogyLogMessage message = (AnalogyLogMessage)view.GetRowCellValue(e.RowHandle, view.Columns[Common.CommonUtils.AnalogyMessageColumn]);
            if (message == null)
            {
                return;
            }

            var (backgroundColorLevel, textColorLevel) = Settings.ColorSettings.GetColorForLogLevel(message.Level);
            e.Appearance.BackColor = backgroundColorLevel;
            e.Appearance.ForeColor = textColorLevel;

            string text = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Text"]);
            foreach (PreDefineHighlight preDefineHighlight in Settings.PreDefinedQueries.Highlights)
            {
                if (FilterCriteriaObject.Match(text, preDefineHighlight.Text,
                    preDefineHighlight.PreDefinedQueryType))
                {
                    e.Appearance.BackColor = preDefineHighlight.Color;
                }
            }

            if (DataProvider.UseCustomColors)
            {
                IAnalogyLogMessage m =
                    (AnalogyLogMessage)view.GetRowCellValue(e.RowHandle, view.Columns[Common.CommonUtils.AnalogyMessageColumn]);
                if (m == null)
                {
                    return;
                }

                var colors = DataProvider.GetColorForMessage(m);
                if (colors.BackgroundColor != Color.Empty)
                {
                    e.Appearance.BackColor = colors.BackgroundColor;
                }

                if (colors.ForegroundColor != Color.Empty)
                {
                    e.Appearance.ForeColor = colors.ForegroundColor;
                }
            }
        }
        private void txtbGroupByChars_EditValueChanged(object sender, EventArgs e)
        {
            rbGroupByText.Checked = true;
        }

        private void sBtnLength_Click(object sender, EventArgs e)
        {
            ApplyGrouping();
        }

        private void nudGroupBychars_ValueChanged(object sender, EventArgs e)
        {
            rbGroupByTextLength.Checked = true;
        }

        private void sBtnGroup_Click(object sender, EventArgs e)
        {
            ApplyGrouping();
        }

        private void ApplyGrouping()
        {
            if (rbGroupByTextLength.Checked)
            {
                gCtrlGrouping.DataSource = null;
                List<IGrouping<string, AnalogyLogMessage>> grouped = Messages
                    .GroupBy(s => s.Text.Substring(0, Math.Min(s.Text.Length, (int)nudGroupBychars.Value)))
                    .OrderByDescending(i => i.Count()).ToList();
                groupingByChars = grouped.ToDictionary(g => g.Key, g => g.ToList());
                gCtrlGrouping.DataSource = groupingByChars.Keys;
            }
            else // group by text
            {
                gCtrlGrouping.DataSource = null;
                List<IGrouping<string, AnalogyLogMessage>> grouped = Messages.Where(m => m.Text.Contains(txtbGroupByChars.Text, StringComparison.CurrentCultureIgnoreCase))
                    .GroupBy(s => s.Text)
                    .OrderByDescending(i => i.Count()).ToList();
                groupingByChars = grouped.ToDictionary(g => g.Key, g => g.ToList());
                gCtrlGrouping.DataSource = groupingByChars.Keys;
            }
        }

        private void gridViewGrouping_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                return;
            }

            var grouped = CommonControls.Utils.DataTableConstructor();
            string key =
                (string)gridViewGrouping.GetRowCellValue(e.FocusedRowHandle, gridViewGrouping.Columns.First());
            var messages = groupingByChars[key];
            foreach (var message in messages)
            {
                AddExtraColumnsIfNeededToTable(grouped, gridViewGrouping2, message);
                DataRow dtr = CommonControls.Utils.CreateRow(grouped, message, "", Settings.TimeOffsetType, Settings.TimeOffset);
                grouped.Rows.Add(dtr);
            }

            grouped.AcceptChanges();
            gridControlMessageGrouping.DataSource = grouped;
        }
        private void AddExtraColumnsIfNeededToTable(DataTable table, GridView view, AnalogyLogMessage message)
        {
            if (message.AdditionalProperties != null && message.AdditionalProperties.Any() &&
                Settings.CheckAdditionalInformation)
            {
                foreach (KeyValuePair<string, string> info in message.AdditionalProperties)
                {
                    if (!table.Columns.Contains(info.Key))
                    {
                        if (!InvokeRequired)
                        {
                            if (!view.Columns.Select(g => g.FieldName).Contains(info.Key))
                            {
                                var grid = new GridColumn() { Caption = info.Key, FieldName = info.Key, Name = info.Key, Visible = true };
                                grid.OptionsColumn.ReadOnly = true;
                                view.Columns.Add(grid);
                                DataColumn dt = new DataColumn(info.Key);
                                dt.ReadOnly = true;
                                table.Columns.Add(dt);
                            }
                        }
                        else
                        {
                            BeginInvoke(new MethodInvoker(() =>
                            {
                                if (!view.Columns.Select(g => g.FieldName).Contains(info.Key))
                                {
                                    var grid = new GridColumn() { Caption = info.Key, FieldName = info.Key, Name = info.Key, Visible = true };
                                    grid.OptionsColumn.ReadOnly = true;
                                    view.Columns.Add(grid);
                                    table.Columns.Add(info.Key);
                                }
                                columnAdderSync.Set();
                            }));
                            columnAdderSync.WaitOne();
                            columnAdderSync.Reset();
                        }
                    }
                }
            }
        }
    }
}