﻿using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.Common.Managers;
using Analogy.CommonControls.DataTypes;
using Analogy.CommonControls.Forms;
using Analogy.CommonControls.Interfaces;
using Analogy.CommonControls.LogLoaders;
using Analogy.CommonControls.Managers;
using Analogy.CommonControls.Properties;
using Analogy.CommonControls.Tools;
using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.UserControls;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using DevExpress.Data.Mask;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using Markdig;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.CommonControls.UserControls
{
    public partial class LogMessagesUC : XtraUserControl, ILogMessageCreatedHandler, ILogWindow, IAnalogyWorkspace, ILogRawSQL
    {
        #region ILogRawSQL Interface
        public event EventHandler<string> OnRawSQLFilterChanged;

        bool ILogRawSQL.ApplyRawSQLFilter(string filter) => ApplyRawSQLFilter(filter);

        bool ILogRawSQL.IsRawSQLModeEnabled => Settings.AdvancedModeRawSQLFilterEnabled;

        bool ILogRawSQL.EnableRawSQLMode()
        {
            var visible = ChangeRawSQLMode(true);
            return visible;
        }

        bool ILogRawSQL.DisableRawSQLMode()
        {
            var visible = ChangeRawSQLMode(false);
            return !visible;
        }

        private bool ChangeRawSQLMode(bool enable)
        {
            Settings.AdvancedModeRawSQLFilterEnabled = enable;
            bool visible = Settings.AdvancedMode && Settings.AdvancedModeRawSQLFilterEnabled;
            this.InvokeIfRequired(_ =>
            {
                xtpSQLraw.PageVisible = visible;
            });
            return visible;
        }
        #endregion
        #region Events
        public event EventHandler<string>? OnSetRawSQLFilter;
        public event EventHandler<bool> CollapseFileAndFolderPanel;
        #endregion
        #region properties
        private DateTimeSelectionUC DateTimePicker { get; set; }
        private JsonColumnChooserUC JsonColumnChooser { get; set; }
        public string CurrentLogLayoutFileName { get; } = "AnalogyLogsCurrentLayout.xml";
        public string CurrentLogLayoutName { get; } = "Active Layout";
        public bool ForceNoFileCaching { get; set; }
        public bool DoNotAddToRecentHistory { get; set; }
        private PagingManager PagingManager { get; set; }
        private FileProcessor FileProcessor { get; set; }
        public ManualResetEvent columnAdderSync = new(false);
        public List<(string Field, string Caption)> CurrentColumnsFields { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; } = new();
        public event EventHandler<AnalogyClearedHistoryEventArgs> OnHistoryCleared;
        public event EventHandler<(string, AnalogyLogMessage)> OnFocusedRowChanged;
        private string OldTextInclude = string.Empty;
        private string OldTextExclude = string.Empty;
        public int fileLoadingCount;
        private List<FilterCriteriaUIOption> IncludeFilterCriteriaUIOptions { get; set; }
        private List<FilterCriteriaUIOption> ExcludeFilterCriteriaUIOptions { get; set; }
        private bool FullModeEnabled { get; set; }
        private bool LoadingInProgress => fileLoadingCount > 0;
        private IUserSettingsManager Settings { get; set; }
        private IExtensionsManager ExtensionManager { get; set; }
        private IEnumerable<IAnalogyExtensionInPlace> InPlaceRegisteredExtensions { get; set; }
        private IEnumerable<IAnalogyExtensionUserControl> UserControlRegisteredExtensions { get; set; }
        private List<int> HighlightRows { get; set; } = new();
        private List<string> _excludeMostCommon = new();
        public const string DataGridDateColumnName = "Date";
        private bool _realtimeUpdate = true;
        private ReaderWriterLockSlim lockExternalWindowsObject = new(LockRecursionPolicy.NoRecursion);

        private ReaderWriterLockSlim lockSlim;
        private DataTable _messageData;
        private IProgress<AnalogyProgressReport> ProgressReporter { get; set; }
        private IProgress<AnalogyFileReadProgress> DataProviderProgressReporter { get; set; }
        private readonly List<XtraFormLogGrid> _externalWindows = new();
        private ILogger Logger { get; set; }
        private List<XtraFormLogGrid> ExternalWindows
        {
            get
            {
                lockExternalWindowsObject.EnterReadLock();
                var items = _externalWindows.ToList();
                lockExternalWindowsObject.ExitReadLock();
                return items;
            }
        }
        public List<IAnalogyLogMessage> Messages
        {
            get
            {
                var filterDatatable = GetFilteredDataTable();
                return filterDatatable.Rows.OfType<DataRow>().Select(r => (IAnalogyLogMessage)r[Common.CommonUtils.AnalogyMessageColumn]).ToList();
            }
        }
        private int ExternalWindowsCount;
        private AnalogyLogMessage? SelectedMassage { get; set; }
        private readonly FilterCriteriaObject _filterCriteria = new();
        private AutoCompleteStringCollection autoCompleteInclude = new();
        private AutoCompleteStringCollection autoCompleteExclude = new();

        private List<string> LoadedFiles { get; set; }
        private bool NewDataExist { get; set; }
        private DateTimeOffset reloadDateTime = DateTimeOffset.MaxValue;
        private bool hasAnyInPlaceExtensions;
        private bool hasAnyUserControlExtensions;
        private DateTimeOffset diffStartTime = DateTimeOffset.MinValue;
        private CancellationTokenSource filterTokenSource;
        private CancellationToken filterToken;
        private int PageNumber => PagingManager.CurrentPageNumber;
        private int TotalPages => PagingManager.TotalPages;
        public IAnalogyDataProvider DataProvider { get; set; }
        public IAnalogyOfflineDataProvider? FileDataProvider { get; set; }
        private IAnalogyOfflineDataProvider AnalogyOfflineDataProvider { get; } = new AnalogyOfflineDataProvider();
        private Dictionary<string, int> counts;
        public GridView LogGrid
        {
            get => logGrid;
            set => logGrid = value;
        }

        private bool _realTimeMode;
        public bool RealTimeMode
        {
            set
            {
                _realtimeUpdate = value;
                btsAutoScrollToBottom.Checked = _realtimeUpdate;
            }
        }
        private bool _serverSideMode;
        public bool ServerSideModeEnabled
        {
            set
            {
                _serverSideMode = value;
                xtpServerSide.PageVisible = _serverSideMode;
            }
        }
        private LogLevelSelectionType LogLevelSelectionType => Settings.LogLevelSelection;
        public string? Title { get; set; }

        #endregion

        #region fields
        private bool useSpecificColumnForJson;
        private string jsonColumnForInlineJsonViewer;
        private DataVisualizerForm frmDataVisualizer;
        private MarkdownPipeline pipeline;
        #endregion fields

        private JsonTreeUC JsonTreeView { get; set; }
        private IFactoriesManager FactoriesManager { get; set; }
        private FileProcessingManager FileProcessingManager { get; } = ServicesProvider.Instance.GetService<FileProcessingManager>();
        public LogMessagesUC()
        {
            InitializeComponent();
            DateTimePicker = new DateTimeSelectionUC();
            JsonColumnChooser = new JsonColumnChooserUC();
            if (DesignMode)
            {
                return;
            }
            pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            Id = Guid.NewGuid();
            SetupDependencies();

            PopupControlContainer datePopup = new();
            datePopup.Manager = this.barManager1;
            datePopup.Controls.Add(DateTimePicker);
            datePopup.Size = DateTimePicker.Size;
            ddbGoTo.DropDownControl = datePopup;

            PopupControlContainer jsonColumnChooserPopup = new();
            jsonColumnChooserPopup.Manager = this.barManager1;
            jsonColumnChooserPopup.Controls.Add(JsonColumnChooser);
            jsonColumnChooserPopup.Size = JsonColumnChooser.Size;
            bbiJsonColumn.DropDownControl = jsonColumnChooserPopup;

            ProgressReporter = new Progress<AnalogyProgressReport>((value) =>
            {
                if (value.Processed == value.Total)
                {
                    bprogressBar.Visibility = BarItemVisibility.Never;
                    bprogressBar.Caption = "";
                    return;
                }
                bprogressBar.Caption = $"{value.Processed}/{value.Total}";
            });

            DataProviderProgressReporter = new Progress<AnalogyFileReadProgress>((value) =>
            {
                if (!Settings.ShowProcessedCounter)
                {
                    return;
                }
                if (value.ProgressType == AnalogyFileReadProgressType.Percentage)
                {
                    bsiProgress.Caption = Math.Round((double)value.TotalProcessed / value.TotalProcessed, 2) * 100 + "%";
                }
                else
                {
                    bsiProgress.Caption = $"{value.TotalProcessed}/{value.TotalEntries}";
                }
            });

            JsonTreeView = new JsonTreeUC();
            spltcMessages.Panel2.Controls.Add(JsonTreeView);
            JsonTreeView.Dock = DockStyle.Fill;
            spltcMessages.PanelVisibility = SplitPanelVisibility.Panel1;
            WorkspaceManager.SetSerializationEnabled(gridControl, false);
            WorkspaceManager.SetSerializationEnabled(spltcMessages, false);
            counts = new Dictionary<string, int>();
            foreach (string value in Utils.LogLevels)
            {
                counts.Add(value, 0);
            }

            filterTokenSource = new CancellationTokenSource();
            filterToken = filterTokenSource.Token;
            FileProcessor = new FileProcessor(Settings, this, FileProcessingManager, Logger);
            FileProcessor.OnFileReadingFinished += (s, e) =>
            {
                Interlocked.Decrement(ref fileLoadingCount);
            };

            var excludedColumns = new List<GridColumn>()
            {
                gridColumnDate,
                gridColumnTimeDiff,
                gridColumnText,
                gridColumnSource,
                gridColumnLevel,
                gridColumnModule,
                gridColumnObject,
            };
            CurrentColumnsFields =
                logGrid.Columns.Except(excludedColumns).Select(c => (c.FieldName, c.Caption)).ToList();

            deNewerThanFilter.DateTime = DateTime.Now;
            deOlderThanFilter.DateTime = DateTime.Now;
            IncludeFilterCriteriaUIOptions = CurrentColumnsFields.Select(c => new FilterCriteriaUIOption(c.Caption, c.Field, false)).ToList();
            ExcludeFilterCriteriaUIOptions = CurrentColumnsFields.Select(c => new FilterCriteriaUIOption(c.Caption, c.Field, false)).ToList();
            clbInclude.DisplayMember = nameof(FilterCriteriaUIOption.DisplayMember);
            clbInclude.ValueMember = nameof(FilterCriteriaUIOption.ValueMember);
            clbInclude.CheckMember = nameof(FilterCriteriaUIOption.CheckMember);
            clbInclude.DataSource = IncludeFilterCriteriaUIOptions;
            clbExclude.DisplayMember = nameof(FilterCriteriaUIOption.DisplayMember);
            clbExclude.ValueMember = nameof(FilterCriteriaUIOption.ValueMember);
            clbExclude.CheckMember = nameof(FilterCriteriaUIOption.CheckMember);
            clbExclude.DataSource = ExcludeFilterCriteriaUIOptions;
            _filterCriteria.IncludeFilterCriteriaUIOptions = IncludeFilterCriteriaUIOptions;
            _filterCriteria.ExcludeFilterCriteriaUIOptions = ExcludeFilterCriteriaUIOptions;
        }

        private void SetupDependencies()
        {
            Settings = ServicesProvider.Instance.GetService<IUserSettingsManager>();
            ExtensionManager = ServicesProvider.Instance.GetService<IExtensionsManager>();
            FactoriesManager = ServicesProvider.Instance.GetService<IFactoriesManager>();
            Logger = ServicesProvider.Instance.CreateLogger(nameof(LogMessagesUC));
            PagingManager = new PagingManager(this, Settings);
            lockSlim = PagingManager.lockSlim;
            _messageData = PagingManager.CurrentPage();
        }
        private async void LogMessagesUC_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            foreach (IRawSQLInteractor rawSqlInteractor in FactoriesManager.RawSQLManipulators)
            {
                try
                {
                    rawSqlInteractor.SetRawSQLHandler(this);
                }
                catch (Exception exception)
                {
                    Logger?.LogError(exception, $"Error setting raw sql handler for {rawSqlInteractor.GetType()}: {exception.Message}", exception);
                }
            }
            wsLogs.CaptureWorkspace("Default");

            LoadUISettings();
            var defaultsColumns = logGrid.Columns.Select(c => (c.FieldName, c.Caption));
            if (!string.IsNullOrEmpty(Settings.LogsLayoutFileName) && File.Exists(Settings.LogsLayoutFileName))
            {
                string name = Path.GetFileNameWithoutExtension(Settings.LogsLayoutFileName);
                wsLogs.LoadWorkspace(name, Settings.LogsLayoutFileName);
                wsLogs.ApplyWorkspace(name);
            }
            LoadWorkspace(CurrentLogLayoutFileName);
            foreach ((string fieldName, string caption) in defaultsColumns)
            {
                var column = logGrid.Columns.ColumnByFieldName(fieldName);
                if (column != null)
                {
                    column.Caption = caption;
                }
            }

            LoadReplacementHeaders();
            HideColumns();

            if (!string.IsNullOrEmpty(Settings.LogsLayoutFileName) && File.Exists(Settings.LogsLayoutFileName))
            {
                string name = Path.GetFileNameWithoutExtension(Settings.LogsLayoutFileName);
                wsLogs.LoadWorkspace(name, Settings.LogsLayoutFileName);
                wsLogs.ApplyWorkspace(name);
            }
            LoadWorkspace(CurrentLogLayoutFileName);

            await LoadExtensions();
            dockPanelTree.Visibility = hasAnyUserControlExtensions ? DockVisibility.Visible : DockVisibility.Hidden;
            SetupEventsHandlers();

            gridControl.DataSource = _messageData.DefaultView;
            if (Settings.SaveSearchFilters)
            {
                if (Settings.IncludeText == txtbInclude.Properties.NullText)
                {
                    Settings.IncludeText = string.Empty;
                }
                if (Settings.ExcludeText == txtbExclude.Properties.NullText)
                {
                    Settings.ExcludeText = string.Empty;
                }
                if (Settings.SourceText == txtbSource.Properties.NullText)
                {
                    Settings.SourceText = string.Empty;
                }
                if (Settings.ModuleText == txtbModule.Properties.NullText)
                {
                    Settings.ModuleText = string.Empty;
                }
                string? includeText = string.IsNullOrEmpty(Settings.IncludeText) || Settings.IncludeText == txtbInclude.Properties.NullText ? null : Settings.IncludeText;
                SetTextIfDifferent(txtbInclude, includeText);
                string? excludeText = string.IsNullOrEmpty(Settings.ExcludeText) || Settings.ExcludeText == txtbExclude.Properties.NullText ? null : Settings.ExcludeText;
                SetTextIfDifferent(txtbExclude, excludeText);
                string? source = string.IsNullOrEmpty(Settings.SourceText) || Settings.SourceText == txtbSource.Properties.NullText ? null : Settings.SourceText;
                SetTextIfDifferent(txtbSource, source);
                string? module = string.IsNullOrEmpty(Settings.ModuleText) || Settings.ModuleText == txtbModule.Properties.NullText ? null : Settings.ModuleText;
                SetTextIfDifferent(txtbModule, module);

                if (!string.IsNullOrEmpty(includeText) || !string.IsNullOrEmpty(excludeText) ||
                    !string.IsNullOrEmpty(source) || !string.IsNullOrEmpty(module))
                {
                    AlertButton btn1 = new(Resources.Delete_16x16);
                    btn1.Hint = "Clear Filtering";
                    btn1.Name = "buttonClearFiltering";
                    alertControl1.Buttons.Add(btn1);
                    alertControl1.ButtonClick += (s, arg) =>
                    {
                        if (arg.ButtonName == btn1.Name)
                        {
                            string? text = null;
                            SetTextIfDifferent(txtbInclude, text);
                            SetTextIfDifferent(txtbExclude, text);
                            SetTextIfDifferent(txtbSource, text);
                            SetTextIfDifferent(txtbModule, text);
                            ceIncludeText.Checked = ceExcludeText.Checked =
                                ceModulesProcess.Checked = ceSources.Checked = false;
                        }
                    };
                    AlertInfo info = new("Filtering", "old search filters are used. You can clear those with the x button");
                    alertControl1.Show(this.ParentForm, info);
                }
            }
            documentManager1.BeginUpdate();
            documentManager1.View.ActivateDocument(dockPanelLogs);
            documentManager1.EndUpdate();
            LogGrid.ClearSorting();
            LogGrid.Columns[DataGridDateColumnName].SortOrder = Settings.DefaultDescendOrder ? ColumnSortOrder.Descending : ColumnSortOrder.Ascending;
        }

        private void SetTextIfDifferent(TextEdit control, string? text)
        {
            if (!control.Text.Equals(text))
            {
                control.Text = text;
            }
        }
        private void HideColumns()
        {
            //first restore all
            foreach (GridColumn gridColumn in logGrid.Columns)
            {
                gridColumn.Visible = !gridColumn.FieldName.Equals(Common.CommonUtils.AnalogyMessageColumn);
            }

            if (DataProvider.HideAdditionalColumns() != null)
            {
                foreach (string columnFieldName in DataProvider.HideAdditionalColumns())
                {
                    var column = logGrid.Columns.ColumnByFieldName(columnFieldName);
                    if (column != null)
                    {
                        column.Visible = false;
                    }
                }
            }
            if (DataProvider.HideExistingColumns() != null)
            {
                foreach (AnalogyLogMessagePropertyName columnFieldName in DataProvider.HideExistingColumns())
                {
                    var column = logGrid.Columns.ColumnByFieldName(columnFieldName.ToString());
                    if (column != null)
                    {
                        column.Visible = false;
                    }
                }
            }
        }

        public void LoadWorkspace(string fileName)
        {
            if (File.Exists(fileName))
            {
                wsLogs.LoadWorkspace(fileName, fileName);
                wsLogs.ApplyWorkspace(fileName);
            }
        }
        private void rgSearchMode_SelectedIndexChanged(object s, EventArgs e)
        {
            Settings.BuiltInSearchPanelMode = ceFilterPanelSearch.CheckState == CheckState.Checked ? BuiltInSearchPanelMode.Search : BuiltInSearchPanelMode.Filter;
            logGrid.OptionsFind.Behavior = Settings.BuiltInSearchPanelMode == BuiltInSearchPanelMode.Search
                ? FindPanelBehavior.Search
                : FindPanelBehavior.Filter;
        }
        private async Task PopulateDataFromServer()
        {
            string text = (string)txtbInclude.EditValue ?? "";
            List<string> includeTexts = new() { text };

            if (text.Contains('|'))
            {
                var split = text.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList(); includeTexts = split.Select(itm => itm.Trim()).ToList();
            }

            if (text.Contains("&") || text.Contains('+'))
            {
                var split = text.Split(new[] { '&', '+' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                includeTexts = split.Select(itm => itm.Trim()).ToList();
            }

            FilterCriteria filter = new(includeTexts);
            ClearLogs(true);
            await (DataProvider as IAnalogyProviderSidePagingProvider).FetchMessages(0, 10, filter, CancellationToken.None, this);
        }

        private void SetupEventsHandlers()
        {
            bbiCollapseFolderPanel.ItemClick += (sBtnLastPage, e) =>
            {
                Settings.CollapseFolderAndFilesPanel = !Settings.CollapseFolderAndFilesPanel;
                CollapseFileAndFolderPanel?.Invoke(this, Settings.CollapseFolderAndFilesPanel);
            };
            sbtnServerSide.Click += async (s, e) =>
            {
                sbtnServerSide.Enabled = false;
                await PopulateDataFromServer();
                sbtnServerSide.Enabled = true;
            };
            bbiExportToSimpleList.ItemClick += (s, e) =>
            {
                var messages = GetMessages();
                var text = string.Join(Environment.NewLine,
                    messages.Select(m => $"Date:{m.Date} ---- Level:{m.Level} ---- {m.Text}"));
                using SaveFileDialog saveFileDialog = new();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(saveFileDialog.FileName, text);
                        XtraMessageBox.Show($"Log saved to: {saveFileDialog.FileName}");
                    }
                    catch (Exception exception)
                    {
                        XtraMessageBox.Show($"Error: {exception.Message}");
                    }
                }
            };
            LogGrid.ColumnFilterChanged += (s, e) =>
            {
                FilterResults();
            };
            ceSearchEverywhere.CheckedChanged += async (s, e) =>
            {
                _filterCriteria.SearchEverywhere = ceSearchEverywhere.Checked;
                await FilterHasChanged();
            };
            ddbGoTo.ArrowButtonClick += (s, e) =>
            {
                var times = GetMessages().Select(m => m.Date).Distinct().ToList();
                DateTimePicker.SetTimes(times);
            };
            ddbGoTo.Click += (s, e) =>
            {
                var times = GetMessages().Select(m => m.Date).Distinct().ToList();
                DateTimePicker.SetTimes(times);
            };
            DateTimePicker.SelectionChanged += (s, e) =>
            {
                var location = LocateDateRowByValue(0, e);
                if (location >= 0)
                {
                    LogGrid.FocusedRowHandle = location;
                }
            };
            Settings.OnInlineJsonViewerChanged += (s, showJson) =>
            {
                spltcMessages.PanelVisibility = showJson ? SplitPanelVisibility.Both : SplitPanelVisibility.Panel1;
            };

            bbiJsonColumn.ItemClick += (s, e) =>
            {
                var times = logGrid.Columns.Select(c => c.FieldName).ToList();
                JsonColumnChooser.SetNames(times);
            };
            JsonColumnChooser.SelectionChanged += (s, e) =>
            {
                jsonColumnForInlineJsonViewer = e;
                useSpecificColumnForJson = !string.IsNullOrEmpty(e);
            };

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

            //sbtnUndockPerProcess.Click += (s, e) =>
            //{
            //    UndockViewPerProcess();
            //};
            meMessageDetails.Properties.BeforeShowMenu += (s, e) =>
            {
                string caption = "Show Selection In Json Viewer";
                if (!e.Menu.Items.ToList().Exists(i => i.Caption.Equals(caption)))
                {
                    DXMenuItem item = new(caption);
                    item.Click += (_, __) =>
                    {
                        var json = meMessageDetails.SelectedText;
                        JsonViewerForm j = new(json, Settings);
                        j.Show(this);
                    };
                    e.Menu.Items.Add(item);
                }
            };
            logGrid.ShownEditor += GridView_ShownEditor;
            logGrid.ShowingEditor += (s, e) => e.Cancel = true;// prevent editing
            gridControl.Click += (s, e) =>
            {
                if (btsAutoScrollToBottom.Checked)
                {
                    btsAutoScrollToBottom.Checked = false;
                }
            };
            chkbHighlight.CheckedChanged += async (s, e) => await FilterHasChanged();

            #region buttons

            bbtnCancel.ItemClick += (s, e) =>
            {
                CancellationTokenSource.Cancel(false);
                Interlocked.Exchange(ref fileLoadingCount, 0);
                CancellationTokenSource = new CancellationTokenSource();
                bbtnCancel.Visibility = BarItemVisibility.Never;
            };

            bbtnRawMessageViewer.ItemClick += (s, e) =>
            {
                if (bbtnRawMessageViewer.Tag is AnalogyLogMessage m)
                {
                    switch (m.RawTextType)
                    {
                        case AnalogyRowTextType.None:
                        case AnalogyRowTextType.Unknown:
                        case AnalogyRowTextType.PlainText:
                        case AnalogyRowTextType.RichText:
                        case AnalogyRowTextType.XML:
                        case AnalogyRowTextType.HTML:
                        case AnalogyRowTextType.Markdown:
                            FormMessageDetails details = new(m, Messages, "", Settings);
                            details.Show();
                            break;
                        case AnalogyRowTextType.JSON:
                            var viewer = new JsonViewerForm(m, Settings);
                            viewer.Show();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            };
            bbiGoToActiveMessage.ItemClick += (s, e) =>
            {
                if (SelectedMassage != null)
                {
                    GoToPrimaryGridMessage(SelectedMassage);
                }
            };
            bbiGoToMessage.ItemClick += (s, e) =>
            {
                if (recMessageDetails.Tag is AnalogyLogMessage m1)
                {
                    GoToPrimaryGridMessage(m1);
                }
                else if (meMessageDetails.Tag is AnalogyLogMessage m2)
                {
                    GoToPrimaryGridMessage(m2);
                }
            };
            bbiIncludeColumnHeaderFilter.ItemClick += (s, e) =>
           {
               if (bbiIncludeColumnHeaderFilter.Tag is ViewColumnFilterInfo filter)
               {
                   logGrid.ActiveFilter.Add(filter);
               }
           };
            bbiIncludeMessage.ItemClick += tsmiInclude_Click;
            bbiIncludeSource.ItemClick += (s, e) =>
            {
                (AnalogyLogMessage message, _) = GetMessageFromSelectedFocusedRowInGrid();
                if (!string.IsNullOrEmpty(message?.Source))
                {
                    txtbSource.Text = txtbSource.Text == txtbSource.Properties.NullText ? message.Source : txtbSource.Text + "," + message.Source;
                }
            };
            bbiIncludeModule.ItemClick += (s, e) =>
            {
                (AnalogyLogMessage message, _) = GetMessageFromSelectedFocusedRowInGrid();
                if (!string.IsNullOrEmpty(message?.Module))
                {
                    txtbModule.Text = txtbModule.Text == txtbModule.Properties.NullText ? message.Module : txtbModule.Text + "," + message.Module;
                }
            };
            bbiJsonViewer.ItemClick += (s, e) =>
            {
                (AnalogyLogMessage message, _) = GetMessageFromSelectedFocusedRowInGrid();
                if (message != null)
                {
                    JsonViewerForm j = new(message, Settings);
                    j.Show(this);
                }
            };
            bbiDiffTime.ItemClick += tsmiTimeDiff_Click;
            bbiIncreaseFontSize.ItemClick += tsmiIncreaseFont_Click;
            bbiDecreaseFontSize.ItemClick += tsmiDecreaseFont_Click;
            bbiSaveLayout.ItemClick += tsmiSaveLayout_Click;
            bbiExcludeModule.ItemClick += tsmiExcludeModule_Click;
            bbiExcludeSource.ItemClick += tsmiExcludeSource_Click;
            bbiExcludeMessage.ItemClick += tsmiExclude_Click;
            bbiAddNoteToMessage.ItemClick += tsmiAddCommentToMessage_Click;
            bbiCopyAllMessages.ItemClick += tsmiCopyMessages_Click;
            bbiCopyMessage.ItemClick += tsmiCopy_Click;
            bbiDatetiemFilterTo.ItemClick += tsmiDateFilterOlder_Click;
            bbiDatetiemFilterFrom.ItemClick += tsmiDateFilterNewer_Click;
            btsiInlineJsonViewer.CheckedChanged += (s, e) =>
            {
                Settings.InlineJsonViewer = btsiInlineJsonViewer.Checked;
                bbiJsonColumn.Visibility = Settings.InlineJsonViewer ? BarItemVisibility.Always : BarItemVisibility.Never;
            };

            sbtnToggleSearchFilter.Click += (_, __) =>
            {
                Settings.IsBuiltInSearchPanelVisible = !Settings.IsBuiltInSearchPanelVisible;
                logGrid.OptionsFind.AlwaysVisible = Settings.IsBuiltInSearchPanelVisible;
            };
            bBtnFullGrid.ItemClick += (s, e) =>
            {
                FullModeEnabled = !FullModeEnabled;
                dockPanelFiltering.Visible = !FullModeEnabled;
            };
            bBtnShare.ItemClick += (s, e) =>
            {
                AnalogyOTAForm share = new(GetFilteredDataTable(), new List<IFactoryContainer>(0), Settings);
                share.Show(this);
            };
            bbtnReload.ItemClick += async (s, e) =>
            {
                reloadDateTime = FileProcessor.lastNewestMessage;
                await LoadFilesAsync(LoadedFiles, true, true);
            };

            #endregion
            #region textboxes
            txtbInclude.Enter += (s, e) => txtbInclude.SelectAll();
            txtbInclude.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var added = Settings.AddNewSearchesEntryToLists(txtbInclude.Text, true);
                    if (added)
                    {
                        autoCompleteInclude.Add(txtbInclude.Text);
                    }
                }
            };
            txtbInclude.EditValueChanged += EditValueChanged;
            txtbExclude.EditValueChanged += EditValueChanged;
            txtbSource.EditValueChanged += EditValueChanged;
            txtbModule.EditValueChanged += EditValueChanged;
            txtbInclude.TextChanged += async (s, e) =>
            {
                if (OldTextInclude.Equals(txtbInclude.Text) ||
                    txtbInclude.Text.Equals(txtbInclude.Properties.NullText))
                {
                    return;
                }
                Settings.IncludeText = txtbInclude.Text;

                //Settings.IncludeText = Settings.SaveSearchFilters && txtbInclude.EditValue != null ? txtbInclude.EditValue.ToString() : string.Empty;
                //Settings.ExcludeText = Settings.SaveSearchFilters && txtbExclude.EditValue != null ? txtbExclude.EditValue.ToString() : string.Empty;

                OldTextInclude = txtbInclude.Text;
                if (string.IsNullOrEmpty(txtbInclude.Text))
                {
                    ceIncludeText.Checked = false;
                    txtbInclude.EditValue = null;
                    return;
                }

                chkbHighlight.Checked = false;
                ceIncludeText.Checked = true;
                await FilterHasChanged();
            };
            txtbExclude.Enter += (s, e) => txtbExclude.SelectAll();
            txtbExclude.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var added = Settings.AddNewSearchesEntryToLists(txtbExclude.Text, false);
                    if (added)
                    {
                        autoCompleteExclude.Add(txtbExclude.Text);
                    }
                }
            };
            txtbExclude.TextChanged += async (s, e) =>
            {
                if (OldTextExclude.Equals(txtbExclude.Text) ||
                    txtbExclude.Text.Equals(txtbExclude.Properties.NullText))
                {
                    return;
                }

                Settings.ExcludeText = txtbExclude.Text;
                OldTextExclude = txtbExclude.Text;
                if (string.IsNullOrEmpty(txtbExclude.Text))
                {
                    ceExcludeText.Checked = false;
                    txtbExclude.EditValue = null;
                    return;
                }

                ceExcludeText.Checked = true;
                await FilterHasChanged();
            };
            txtbSource.TextChanged += async (s, e) =>
            {
                if (string.IsNullOrEmpty(txtbSource.Text) ||
                    txtbSource.Text.Equals(txtbSource.Properties.NullText))
                {
                    ceSources.Checked = false;
                    txtbSource.EditValue = null;
                }
                else
                {
                    if (!ceSources.Checked)
                    {
                        ceSources.Checked = true;
                    }
                }

                await FilterHasChanged();
                Settings.SourceText = txtbSource.Text;
            };
            txtbModule.TextChanged += async (s, e) =>
            {
                if (string.IsNullOrEmpty(txtbModule.Text) ||
                    txtbModule.Text.Equals(txtbModule.Properties.NullText))
                {
                    ceModulesProcess.Checked = false;
                    txtbModule.EditValue = null;
                }
                else
                {
                    if (!ceModulesProcess.Checked)
                    {
                        ceModulesProcess.Checked = true;
                    }
                }

                await FilterHasChanged();
                Settings.ModuleText = txtbModule.Text;
            };
            #endregion
            #region log grid
            LogGrid.RowCountChanged += (s, arg) =>
            {
                if (Settings.AutoScrollToLastMessage && !IsDisposed)
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        if (Settings.DefaultDescendOrder)
                        {
                            LogGrid.MoveFirst();
                            LogGrid.MakeRowVisible(LogGrid.FocusedRowHandle);
                        }
                        else
                        {
                            LogGrid.MoveLast();
                            LogGrid.MakeRowVisible(LogGrid.FocusedRowHandle);
                        }
                    }));
                }
            };
            gridControl.KeyUp += (s, e) =>
            {
                Keys excludeModifier = e.KeyCode & ~Keys.Control & ~Keys.Shift & ~Keys.Alt;
                switch (excludeModifier)
                {
                    case Keys.Oemplus:
                    case Keys.Add:
                        btswitchMessageDetails.Checked = true;
                        Settings.ShowMessageDetails = btswitchMessageDetails.Checked;
                        break;
                    case Keys.OemMinus:
                    case Keys.Subtract:
                        btswitchMessageDetails.Checked = false;
                        Settings.ShowMessageDetails = btswitchMessageDetails.Checked;
                        break;
                }
            };
            gridControl.MainView.Layout += MainView_Layout;
            logGrid.RowStyle += LogGridView_RowStyle;
            logGrid.MouseDown += LogGrid_MouseDown;
            logGrid.MouseUp += LogGrid_MouseUp;
            logGrid.KeyUp += (sender, e) =>
            {
                if (sender is GridView view)
                {
                    int row = view.FocusedRowHandle;
                    if (row < 0)
                    {
                        return;
                    }
                    SelectedMassage = (AnalogyLogMessage)LogGrid.GetRowCellValue(row, Common.CommonUtils.AnalogyMessageColumn);
                }
            };
            LogGridPopupMenu.BeforePopup += (_, __) => UpdatePopupTexts();
            logGrid.CustomSummaryCalculate += LogGrid_CustomSummaryCalculate;
            logGrid.CustomDrawRowIndicator += LogGrid_CustomDrawRowIndicator;
            logGrid.SelectionChanged += LogGridView_SelectionChanged;
            logGrid.FocusedRowChanged += logGrid_FocusedRowChanged;
            logGrid.ColumnPositionChanged += LogGrid_ColumnPositionChanged;
            #endregion
            ceFilterPanelFilter.CheckStateChanged += rgSearchMode_SelectedIndexChanged;
            ceFilterPanelSearch.CheckStateChanged += rgSearchMode_SelectedIndexChanged;
            clbInclude.ItemCheck += async (_, _) => await FilterHasChanged();
            clbExclude.ItemCheck += async (_, _) => await FilterHasChanged();
            deNewerThanFilter.EditValueChanged += async (s, e) =>
            {
                ceNewerThanFilter.Checked = true;
                await FilterHasChanged();
            };
            deNewerThanFilter.Properties.EditValueChanged += async (s, e) =>
            {
                ceNewerThanFilter.Checked = true;
                await FilterHasChanged();
            };

            deOlderThanFilter.EditValueChanged += async (s, e) =>
            {
                ceOlderThanFilter.Checked = true;
                await FilterHasChanged();
            };

            deOlderThanFilter.Properties.EditValueChanged += async (s, e) =>
            {
                ceOlderThanFilter.Checked = true;
                await FilterHasChanged();
            };

            ceOlderThanFilter.CheckedChanged += async (s, e) => await FilterHasChanged();
            ceNewerThanFilter.CheckedChanged += async (s, e) => await FilterHasChanged();
            ceModulesProcess.Click += async (s, e) => await FilterHasChanged();
            ceSources.Click += async (s, e) => await FilterHasChanged();
            ceIncludeText.CheckedChanged += async (s, e) =>
            {
                Settings.IncludeText = ceIncludeText.Checked ? txtbInclude.Text : "";
                if (!ceIncludeText.Checked && !ceExcludeText.Checked)
                {
                    gridColumnText.FilterInfo = null;
                }

                await FilterHasChanged();
            };
            ceExcludeText.CheckedChanged += async (s, e) =>
            {
                Settings.ExcludeText = ceExcludeText.Checked ? txtbExclude.Text : "";

                if (!ceIncludeText.Checked && !ceExcludeText.Checked)
                {
                    gridColumnText.FilterInfo = null;
                }

                await FilterHasChanged();
            };
            logGrid.EndSorting += (s, e) =>
            {
                var sortOrder = gridColumnDate.SortOrder;
                Settings.DefaultDescendOrder = sortOrder == ColumnSortOrder.Descending;
            };
            PagingManager.OnPageChanged += (s, arg) =>
            {
                if (IsDisposed)
                {
                    return;
                }

                BeginInvoke(new MethodInvoker(() =>
                    lblPageNumber.Text = $"Page {PageNumber} / {arg.AnalogyPage.PageNumber}"));
            };

            ceLogLevelAnd.CheckedChanged += async (s, e) => await FilterHasChanged();
            ceLogLevelOr.CheckedChanged += async (s, e) => await FilterHasChanged();

            wsLogs.WorkspaceSaved += (s, e) =>
            {
                Settings.SetLogsLayoutFileName(e.Workspace.Path);

                // Settings.UseCustomLogsLayout = true;
            };
            wsLogs.AfterApplyWorkspace += (s, e) =>
            {
                if (e is WorkspaceEventArgs ws)
                {
                    if (string.IsNullOrEmpty(ws.Workspace.Path))
                    {
                        //Settings.UseCustomLogsLayout = false;
                    }
                    else if (File.Exists(ws.Workspace.Path))
                    {
                        // Settings.UseCustomLogsLayout = true;
                        Settings.SetLogsLayoutFileName(ws.Workspace.Path);
                    }
                }
            };
            btsViewAsHTML.CheckedChanged += (s, e) =>
            {
                Settings.ViewDetailedMessageWithHTML = btsViewAsHTML.Checked;
                SetupMessageDetailPanel();
            };

            sbtnRawFilter.Click += (s, e) =>
            {
                sbtnRawFilter.Image = ApplyRawSQLFilter(meRawSQL.Text) ? Resources.Apply_16x16 : Resources.Delete_16x16;
            };
            #region Time Offsets

            bciTimeOffset.ItemClick += (s, e) =>
            {
                Settings.TimeOffsetType = TimeOffsetType.None;
                RefreshTimeOffset();
            };
            bciTimeOffsetPredefined.ItemClick += (s, e) =>
            {
                Settings.TimeOffsetType = TimeOffsetType.Predefined;
                RefreshTimeOffset();
            };
            bciTimeOffsetUTCToLocal.ItemClick += (s, e) =>
            {
                Settings.TimeOffsetType = TimeOffsetType.UtcToLocalTime;
                RefreshTimeOffset();
            };
            bciTimeOffsetLocalToUTC.ItemClick += (s, e) =>
            {
                Settings.TimeOffsetType = TimeOffsetType.LocalTimeToUtc;
                RefreshTimeOffset();
            };

            #endregion
        }

        private void LogGrid_ColumnPositionChanged(object? sender, EventArgs e)
        {
            UpdateSearchColumn();
        }

        private void UpdateSearchColumn()
        {
            bool GetNumericalValue(GridColumn column)
            {
                return Type.GetTypeCode(column.ColumnType) switch
                {
                    TypeCode.Byte or TypeCode.SByte or TypeCode.UInt16 or TypeCode.UInt32 or TypeCode.UInt64
                        or TypeCode.Int16 or TypeCode.Int32 or TypeCode.Int64 or TypeCode.Decimal or TypeCode.Double
                        or TypeCode.Single => true,
                    _ => false,
                };
            }
            _filterCriteria.Columns = logGrid.Columns.Where(c => c.Visible)
                .Except(new List<GridColumn>()
                {
                    gridColumnDate, gridColumnTimeDiff, gridColumnObject, gridColumnRawText,
                })
                .Select(c => (c.FieldName, GetNumericalValue(c)))
                .ToList();
        }
        private void GridView_ShownEditor(object sender, System.EventArgs e)
        {
            var view = sender as GridView;
            if ((view.IsFilterRow(view.FocusedRowHandle) && view.FocusedColumn.FieldName == gridColumnProcessID.FieldName) || view.FocusedColumn.FieldName == gridColumnThread.FieldName)
            {
                ((TextEdit)view.ActiveEditor).Properties.MaskSettings.Configure<MaskSettings.Numeric>(settings =>
                {
                    settings.MaskExpression = "d";
                    settings.ValueAfterDelete = NumericMaskManager.ValueAfterDelete.Null;
                });
            }
        }
        private void RefreshTimeOffset()
        {
            PagingManager.UpdateOffsets();
        }

        private void EditValueChanged(object sender, EventArgs e)
        {
            //if (sender is BaseEdit edit && e is ChangingEventArgs change && change.NewValue == string.Empty)
            //{
            //    edit.EditValue = null;
            //}
        }

        private void MainView_Layout(object sender, EventArgs e)
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
                Logger.LogError(ex.Message, nameof(MainView_Layout));
            }
        }

        private void LogGrid_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            if (e.Item is GridSummaryItem item && item.FieldName.Equals(gridColumnLevel.FieldName))
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    foreach (var key in Utils.LogLevels)
                    {
                        counts[key] = 0;
                    }
                }
                else if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    if (e.FieldValue is not null)
                    {
                        var key = (string)e.FieldValue;
                        if (counts.ContainsKey(key))
                        {
                            counts[(string)e.FieldValue] += 1;
                        }
                        else
                        {
                            var level = AnalogyLogMessage.ParseLogLevelFromString(key).ToString();
                            if (counts.ContainsKey(level))
                            {
                                counts[level] += 1;
                            }
                        }
                    }
                }

                else if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    bstaticTotalMessages.Caption =
                        $"Total messages:{counts.Values.Sum()}. Errors:{counts["Error"]}. Warnings:{counts["Warning"]}. Critical:{counts["Critical"]}.";
                }
            }
        }

        private void LogGrid_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right && sender is GridView view)
                {
                    GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
                    if (hitInfo.InRow && hitInfo.RowHandle >= 0 && !(hitInfo.Column == view.FocusedColumn && hitInfo.RowHandle == view.FocusedRowHandle))
                    {
                        UpdatePopupTexts();
                        var value = view.GetRowCellValue(hitInfo.RowHandle, hitInfo.Column.FieldName);
                        if (value != null)
                        {
                            ViewColumnFilterInfo viewFilterInfo = new(view.Columns[hitInfo.Column.FieldName],
                                new ColumnFilterInfo($"[{hitInfo.Column.FieldName}] = '{value}'", ""));
                            string val = new(value.ToString().Take(100).ToArray());
                            bbiIncludeColumnHeaderFilter.Caption = $"Set '{val}' as column header filter for column '{hitInfo.Column.Caption}'";
                            bbiIncludeColumnHeaderFilter.Tag = viewFilterInfo;
                            bbiIncludeColumnHeaderFilter.Visibility = BarItemVisibility.Always;
                        }
                        else
                        {
                            bbiIncludeColumnHeaderFilter.Tag = null;
                            bbiIncludeColumnHeaderFilter.Visibility = BarItemVisibility.Never;
                        }
                    }
                }
            }
            catch
            {
                //to nothing for now.
            }
        }

        private void UpdatePopupTexts()
        {
            (AnalogyLogMessage message, _) = GetMessageFromSelectedFocusedRowInGrid();
            if (message != null)
            {
                var module = new string(message.Module.Take(100).ToArray());
                var source = new string(message.Source.Take(100).ToArray());
                bbiIncludeModule.Caption = $"Include Process/Module: Append '{module}' to filter";
                bbiIncludeSource.Caption = $"Include Source: Append '{source}' to filter";
                bbiExcludeModule.Caption = $"Exclude Process/Module: Append '{module}' to filter";
                bbiExcludeSource.Caption = $"Exclude Source: Append '{source}' to filter";
                bbiDatetiemFilterFrom.Caption = $"Show all messages after {Utils.GetOffsetTime(message.Date, Settings.TimeOffsetType, Settings.TimeOffset)}";
                bbiDatetiemFilterTo.Caption = $"Show all messages Before {Utils.GetOffsetTime(message.Date, Settings.TimeOffsetType, Settings.TimeOffset)}";
                bbiDatetiemFilterFrom.Visibility = BarItemVisibility.Always;
                bbiDatetiemFilterTo.Visibility = BarItemVisibility.Always;
            }
            else
            {
                bbiDatetiemFilterFrom.Visibility = BarItemVisibility.Never;
                bbiDatetiemFilterTo.Visibility = BarItemVisibility.Never;
            }
        }

        private void LogGrid_MouseUp(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = logGrid.CalcHitInfo(e.Location);
            if (e.Button == MouseButtons.Right && !hitInfo.InColumnPanel)
            {
                LogGridPopupMenu.ShowPopup(Cursor.Position);
            }
        }
        private void LoadReplacementHeaders()
        {
            if (DataProvider?.GetReplacementHeaders() == null)
            {
                return;
            }

            try
            {
                foreach ((string fieldName, string replacementHeader) in DataProvider.GetReplacementHeaders())
                {
                    var column = logGrid.Columns.FirstOrDefault((col) => col.FieldName == fieldName);
                    if (column != null)
                    {
                        column.Caption = replacementHeader;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error loading replacement header: {ex.Message}");
            }
        }

        public void SetFileDataSource(IAnalogyDataProvider? dataProvider, IAnalogyOfflineDataProvider? fileDataProvider)
        {
            DataProvider = dataProvider;
            FileDataProvider = fileDataProvider;
            SetSaveButtonsVisibility(FileDataProvider != null);
            if (dataProvider is IAnalogyRealTimeDataProvider)
            {
                RealTimeMode = true;
                bsiProgress.Visibility = BarItemVisibility.Never;
            }
            else
            {
                RealTimeMode = false;
                bsiProgress.Visibility = BarItemVisibility.Always;
            }
            ServerSideModeEnabled = (dataProvider is IAnalogyProviderSidePagingProvider);
            bBtnImport.Visibility = BarItemVisibility.Always;
            bBtnImport.Enabled = FileDataProvider != null;
        }

        public void SetSaveButtonsVisibility(bool on)
        {
            if (on)
            {
                //disable specific saving
                bBtnSaveLog.Visibility = BarItemVisibility.Always;
                bBtnSaveEntireLog.Visibility = BarItemVisibility.Always;
                bBtnSaveCurrentSelectionCustomFormat.Visibility = BarItemVisibility.Always;
            }
            else
            {
                bBtnSaveLog.Visibility = BarItemVisibility.Never;
                bBtnSaveEntireLog.Visibility = BarItemVisibility.Never;
                bBtnSaveCurrentSelectionCustomFormat.Visibility = BarItemVisibility.Never;
            }
        }

        public void ProcessCmdKeyFromParent(Keys keyData)
        {
            KeyEventArgs e = new(keyData);
            if (e.Control && e.KeyCode == Keys.D)
            {
                btswitchMessageDetails.Checked = !btswitchMessageDetails.Checked;
                Settings.ShowMessageDetails = btswitchMessageDetails.Checked;
                return;
            }
            if (e.Control && e.KeyCode == Keys.R)
            {
                btswitchRefreshLog.Checked = !btswitchRefreshLog.Checked;
                return;
            }
            if (e.Control && e.KeyCode == Keys.F)
            {
                ceFilterPanelFilter.CheckStateChanged -= rgSearchMode_SelectedIndexChanged;
                ceFilterPanelSearch.CheckStateChanged -= rgSearchMode_SelectedIndexChanged;
                ToggleSearch();
                ceFilterPanelSearch.CheckState = CheckState.Checked;
                ceFilterPanelFilter.CheckStateChanged += rgSearchMode_SelectedIndexChanged;
                ceFilterPanelSearch.CheckStateChanged += rgSearchMode_SelectedIndexChanged;
            }
            if (e.Alt && e.KeyCode == Keys.F)
            {
                ceFilterPanelFilter.CheckStateChanged -= rgSearchMode_SelectedIndexChanged;
                ceFilterPanelSearch.CheckStateChanged -= rgSearchMode_SelectedIndexChanged;
                ToggleFilter();
                ceFilterPanelFilter.CheckState = CheckState.Checked;
                ceFilterPanelFilter.CheckStateChanged += rgSearchMode_SelectedIndexChanged;
                ceFilterPanelSearch.CheckStateChanged += rgSearchMode_SelectedIndexChanged;
            }

            if ((e.Alt && e.KeyCode == Keys.E) || (e.Alt && e.KeyCode == Keys.W))
            {
                if (e.KeyCode == Keys.W)
                {
                    chkLstLogLevel.Items[AnalogyLogLevel.Warning.ToString()].CheckState = chkLstLogLevel.Items[AnalogyLogLevel.Warning.ToString()].CheckState == CheckState.Checked
                        ? CheckState.Unchecked
                        : CheckState.Checked;
                }
                else
                {
                    switch (LogLevelSelectionType)
                    {
                        case LogLevelSelectionType.Single:
                            chkLstLogLevel.Items["Error + Critical"].CheckState = chkLstLogLevel.Items["Error + Critical"].CheckState == CheckState.Checked
                                ? CheckState.Unchecked
                                : CheckState.Checked;
                            break;
                        case LogLevelSelectionType.Multiple:
                            chkLstLogLevel.Items["Error"].CheckState = chkLstLogLevel.Items["Error"].CheckState == CheckState.Checked
                                ? CheckState.Unchecked
                                : CheckState.Checked;
                            chkLstLogLevel.Items["Critical"].CheckState = chkLstLogLevel.Items["Critical"].CheckState == CheckState.Checked
                                ? CheckState.Unchecked
                                : CheckState.Checked;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs e = new(keyData);
            if (e.Control && e.KeyCode == Keys.D)
            {
                btswitchMessageDetails.Checked = !btswitchMessageDetails.Checked;
                Settings.ShowMessageDetails = btswitchMessageDetails.Checked;
                return true;
            }
            if (e.Control && e.KeyCode == Keys.R)
            {
                btswitchRefreshLog.Checked = !btswitchRefreshLog.Checked;
                return true;
            }

            if (e.Control && e.KeyCode == Keys.F)
            {
                ceFilterPanelFilter.CheckStateChanged -= rgSearchMode_SelectedIndexChanged;
                ceFilterPanelSearch.CheckStateChanged -= rgSearchMode_SelectedIndexChanged;
                ToggleSearch();
                ceFilterPanelSearch.CheckState = CheckState.Checked;
                ceFilterPanelFilter.CheckStateChanged += rgSearchMode_SelectedIndexChanged;
                ceFilterPanelSearch.CheckStateChanged += rgSearchMode_SelectedIndexChanged;
                return true;
            }
            if (e.Alt && e.KeyCode == Keys.F)
            {
                ceFilterPanelFilter.CheckStateChanged -= rgSearchMode_SelectedIndexChanged;
                ceFilterPanelSearch.CheckStateChanged -= rgSearchMode_SelectedIndexChanged;
                ToggleFilter();
                ceFilterPanelFilter.CheckState = CheckState.Checked;
                ceFilterPanelFilter.CheckStateChanged += rgSearchMode_SelectedIndexChanged;
                ceFilterPanelSearch.CheckStateChanged += rgSearchMode_SelectedIndexChanged;
                return true;
            }

            if ((e.Alt && e.KeyCode == Keys.E) || (e.Alt && e.KeyCode == Keys.W))
            {
                if (e.KeyCode == Keys.W)
                {
                    chkLstLogLevel.Items[AnalogyLogLevel.Warning.ToString()].CheckState = chkLstLogLevel.Items[AnalogyLogLevel.Warning.ToString()].CheckState == CheckState.Checked
                        ? CheckState.Unchecked
                        : CheckState.Checked;
                }
                else
                {
                    switch (LogLevelSelectionType)
                    {
                        case LogLevelSelectionType.Single:
                            chkLstLogLevel.Items["Error + Critical"].CheckState = chkLstLogLevel.Items["Error + Critical"].CheckState == CheckState.Checked
                                ? CheckState.Unchecked
                                : CheckState.Checked;
                            break;
                        case LogLevelSelectionType.Multiple:
                            chkLstLogLevel.Items["Error"].CheckState = chkLstLogLevel.Items["Error"].CheckState == CheckState.Checked
                                ? CheckState.Unchecked
                                : CheckState.Checked;
                            chkLstLogLevel.Items["Critical"].CheckState = chkLstLogLevel.Items["Critical"].CheckState == CheckState.Checked
                                ? CheckState.Unchecked
                                : CheckState.Checked;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ToggleSearch()
        {
            if (Settings.BuiltInSearchPanelMode == BuiltInSearchPanelMode.Search)
            {
                Settings.IsBuiltInSearchPanelVisible = !Settings.IsBuiltInSearchPanelVisible;
            }
            else
            {
                Settings.BuiltInSearchPanelMode = BuiltInSearchPanelMode.Search;
                Settings.IsBuiltInSearchPanelVisible = true;
                logGrid.OptionsFind.Behavior = FindPanelBehavior.Search;
            }
            logGrid.OptionsFind.AlwaysVisible = Settings.IsBuiltInSearchPanelVisible;
        }
        private void ToggleFilter()
        {
            if (Settings.BuiltInSearchPanelMode == BuiltInSearchPanelMode.Filter)
            {
                Settings.IsBuiltInSearchPanelVisible = !Settings.IsBuiltInSearchPanelVisible;
            }
            else
            {
                Settings.BuiltInSearchPanelMode = BuiltInSearchPanelMode.Filter;
                Settings.IsBuiltInSearchPanelVisible = true;
                logGrid.OptionsFind.Behavior = FindPanelBehavior.Filter;
            }
            logGrid.OptionsFind.AlwaysVisible = Settings.IsBuiltInSearchPanelVisible;
        }
        private void LoadUISettings()
        {
            gridColumnThread.FieldName = Common.CommonUtils.ColumnThreadId;
            gridColumnProcessID.FieldName = Common.CommonUtils.ColumnProcessId;
            gridColumnModule.FieldName = Common.CommonUtils.ColumnModule;
            gridColumnRawText.FieldName = Common.CommonUtils.ColumnRawText;
            gridColumnObject.Caption = Common.CommonUtils.AnalogyMessageColumn;
            gridColumnObject.Name = Common.CommonUtils.AnalogyMessageColumn;
            gridColumnObject.FieldName = Common.CommonUtils.AnalogyMessageColumn;
            bsiProgress.Caption = string.Empty;
            bsiProgress.Visibility = Settings.ShowProcessedCounter ? BarItemVisibility.Always : BarItemVisibility.Never;
            switch (Settings.TimeOffsetType)
            {
                case TimeOffsetType.None:
                    bciTimeOffset.Checked = true;
                    break;
                case TimeOffsetType.Predefined:
                    bciTimeOffsetPredefined.Checked = true;
                    break;
                case TimeOffsetType.UtcToLocalTime:
                    bciTimeOffsetUTCToLocal.Checked = true;
                    break;
                case TimeOffsetType.LocalTimeToUtc:
                    bciTimeOffsetLocalToUTC.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            gridControl.ForceInitialize();
            SetupMessageDetailPanel();
            btsViewAsHTML.Checked = Settings.ViewDetailedMessageWithHTML;
            if (File.Exists(Settings.LogGridFileName))
            {
                gridControl.MainView.RestoreLayoutFromXml(Settings.LogGridFileName);
            }
            Utils.SetLogLevel(chkLstLogLevel);
            tmrNewData.Interval = (int)(Settings.RealTimeRefreshInterval * 1000);

            //todo: restore
            //pnlExtraFilters.Visible =  _serverSideMode;
            pnlExtraFilters.Visible = Settings is { AdvancedMode: true, AdvancedModeAdditionalFilteringColumnsEnabled: true };
            xtpSQLraw.PageVisible = Settings is { AdvancedMode: true, AdvancedModeRawSQLFilterEnabled: true };
            bBtnShare.Enabled = false;

            logGrid.OptionsSelection.MultiSelect = true;
            logGrid.OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;

            logGrid.OptionsFind.AlwaysVisible = Settings.IsBuiltInSearchPanelVisible;
            ceFilterPanelSearch.CheckState = Settings.BuiltInSearchPanelMode == BuiltInSearchPanelMode.Search ? CheckState.Checked : CheckState.Unchecked;
            ceFilterPanelFilter.CheckState = Settings.BuiltInSearchPanelMode == BuiltInSearchPanelMode.Filter ? CheckState.Checked : CheckState.Unchecked;

            logGrid.OptionsFind.Behavior = Settings.BuiltInSearchPanelMode == BuiltInSearchPanelMode.Search
                ? FindPanelBehavior.Search
                : FindPanelBehavior.Filter;
            gridColumnDate.SortOrder = Settings.DefaultDescendOrder ? ColumnSortOrder.Descending : ColumnSortOrder.Ascending;
            if (txtbInclude.MaskBox is not null)
            {
                txtbInclude.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtbInclude.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtbInclude.MaskBox.AutoCompleteCustomSource = autoCompleteInclude;
            }

            if (Settings.RememberLastSearches)
            {
                autoCompleteInclude.AddRange(Settings.LastSearchesInclude.ToArray());
                autoCompleteExclude.AddRange(Settings.LastSearchesExclude.ToArray());
            }

            if (txtbExclude.MaskBox is not null)
            {
                txtbExclude.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtbExclude.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtbExclude.MaskBox.AutoCompleteCustomSource = autoCompleteExclude;
            }

            btswitchRefreshLog.Checked = true;
            LogGrid.BestFitColumns();
            btswitchMessageDetails.Checked = Settings.ShowMessageDetails;
            dockPanelMessageInfo.Visibility = Settings.ShowMessageDetails ? DockVisibility.Visible : DockVisibility.Hidden;
            if (Settings.StartupErrorLogLevel)
            {
                chkLstLogLevel.Items[1].CheckState = CheckState.Checked;
            }

            LogGrid.Appearance.Row.Font = new Font(LogGrid.Appearance.Row.Font.Name, Settings.FontSettings.GridFontSize);
            btsAutoScrollToBottom.Checked = Settings.AutoScrollToLastMessage;

            logGrid.Columns["Date"].DisplayFormat.FormatType = FormatType.DateTime;
            logGrid.Columns["Date"].DisplayFormat.FormatString = Settings.DateTimePattern;

            btsiInlineJsonViewer.Checked = Settings.InlineJsonViewer;
            bbiJsonColumn.Visibility = Settings.InlineJsonViewer ? BarItemVisibility.Always : BarItemVisibility.Never;
            spltcMessages.PanelVisibility = Settings.InlineJsonViewer ? SplitPanelVisibility.Both : SplitPanelVisibility.Panel1;
            UpdateSearchColumn();
        }

        private void SetupMessageDetailPanel()
        {
            scMessageDetails.PanelVisibility = !Settings.ViewDetailedMessageWithHTML
                ? SplitPanelVisibility.Panel1
                : SplitPanelVisibility.Panel2;
        }
        private async Task LoadExtensions()
        {
            var extensions = ExtensionManager.RegisteredExtensions.Where(e => e.TargetComponentId == DataProvider.Id)
                .ToList();
            hasAnyInPlaceExtensions = extensions.Any(e => e is IAnalogyExtensionInPlace);
            hasAnyUserControlExtensions = extensions.Any(e => e is IAnalogyExtensionUserControl);
            InPlaceRegisteredExtensions = extensions.Where(e => e is IAnalogyExtensionInPlace).Cast<IAnalogyExtensionInPlace>();
            UserControlRegisteredExtensions = extensions.Where(e => e is IAnalogyExtensionUserControl).Cast<IAnalogyExtensionUserControl>();
            foreach (IAnalogyExtensionInPlace extension in InPlaceRegisteredExtensions)
            {
                var columns = extension.GetColumnsInfo();
                foreach (AnalogyColumnInfo column in columns)
                {
                    var gridColumn = new GridColumn();
                    gridColumn.Caption = column.ColumnCaption;
                    gridColumn.FieldName = column.ColumnName;
                    gridColumn.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;
                    gridColumn.VisibleIndex = ExtensionManager.GetIndexForExtension(extension);
                    gridColumn.OptionsColumn.ReadOnly = true;
                    LogGrid.Columns.Add(gridColumn);
                    gridColumn.Visible = true;
                }
            }
            foreach (IAnalogyExtensionUserControl extension in UserControlRegisteredExtensions)
            {
                DockPanel? pnl = dockManager1.Panels.FirstOrDefault(i => i.ID == extension.Id);
                if (pnl == null)
                {
                    pnl = dockPanelTree;
                    pnl.Text = extension.Title;
                    pnl.ID = extension.Id;
                }
                if (Title != null && pnl.ParentPanel != null)
                {
                    pnl.ParentPanel.Text = Title;
                }

                pnl.ControlContainer.Controls.Add(extension.CreateUserControl(Id, Logger));
                pnl.SizeChanged += ExtensionPanel_SizeChanged;
                await extension.InitializeUserControl(this, Id, Logger);
            }
        }

        private void ExtensionPanel_SizeChanged(object? sender, EventArgs e)
        {
            if (sender is DockPanel { Controls.Count: > 0 } pnl)
            {
                pnl.Controls[0].Size = pnl.Size;
            }
        }

        private void UCLogs_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;

        private async void UCLogs_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            await LoadFilesAsync(files.ToList(), false);
        }

        #region UI events

        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            (AnalogyLogMessage m, _) = GetMessageFromSelectedFocusedRowInGrid();
            if (m != null)
            {
                Clipboard.SetText(m.Text);
            }
        }

        private void tsmiEmail_Click(object sender, EventArgs e)
        {
            (AnalogyLogMessage message, _) = GetMessageFromSelectedFocusedRowInGrid();
            if (message == null)
            {
                return;
            }

            try
            {
                Process.Start($"mailto:?Subject=Analogy message&Body={message.Text}");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, @"Error opening mail client", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            Clipboard.SetText(message.Text);
        }

        private async Task FilterHasChanged()
        {
            async Task RefreshData(CancellationToken token)
            {
                await Task.Delay(500);
                if (token.IsCancellationRequested)
                {
                    return;
                }

                FilterResults();
            }

            filterTokenSource.Cancel();
            filterTokenSource.Dispose();
            filterTokenSource = new CancellationTokenSource();
            filterToken = filterTokenSource.Token;
            await RefreshData(filterToken);
        }

        private async void tsmiExclude_Click(object sender, EventArgs e)
        {
            (AnalogyLogMessage message, _) = GetMessageFromSelectedFocusedRowInGrid();
            if (message == null)
            {
                return;
            }

            var ef = new AnalogyExcludeMessage(message);
            ef.Text = "Exclude";
            if (ef.ShowDialog(this) == DialogResult.OK)
            {
                string exclude = ef.MessageText;

                txtbExclude.Text = txtbExclude.Text == txtbExclude.Properties.NullText ? exclude : txtbExclude.Text + "|" + exclude;
                ceExcludeText.Checked = true;
                await FilterHasChanged();
            }
        }

        private async void tsmiInclude_Click(object sender, EventArgs e)
        {
            (AnalogyLogMessage message, _) = GetMessageFromSelectedFocusedRowInGrid();
            if (message == null)
            {
                return;
            }

            var ef = new AnalogyExcludeMessage(message);
            ef.Text = "Include";
            if (ef.ShowDialog(this) == DialogResult.OK)
            {
                string include = ef.MessageText;

                var text = txtbInclude.Text == txtbInclude.Properties.NullText ? include : txtbInclude.Text + "|" + include;
                SetTextIfDifferent(txtbInclude, text);
                ceIncludeText.Checked = true;
                await FilterHasChanged();
            }
        }

        /// <summary>
        /// Called when column filter button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridViewShowFilterPopupListBox(object sender, FilterPopupListBoxEventArgs e)
        {
            if (e.Column.FieldName != DataGridDateColumnName)
            {
                return;
            }

            e.ComboBox.Items.Clear();

            int index = 0;

            #region Create and add custom filter criteria to select the records which refer to the current date.

            // ALL
            ColumnFilterInfo fInfo = new();
            e.ComboBox.Items.Insert(index++, new FilterItem(Utils.DateFilterNone, fInfo));

            // Today
            fInfo = new ColumnFilterInfo(GetFilterString(DataGridDateColumnName, DateRangeFilter.Today),
                GetFilterDisplayText(DateRangeFilter.Today));
            e.ComboBox.Items.Insert(index++, new FilterItem(Utils.DateFilterToday, fInfo));

            // Last 2 days
            fInfo = new ColumnFilterInfo(GetFilterString(DataGridDateColumnName, DateRangeFilter.Last2Days),
                GetFilterDisplayText(DateRangeFilter.Last2Days));
            e.ComboBox.Items.Insert(index++, new FilterItem(Utils.DateFilterLast2Days, fInfo));

            // Last 3 days
            fInfo = new ColumnFilterInfo(GetFilterString(DataGridDateColumnName, DateRangeFilter.Last3Days),
                GetFilterDisplayText(DateRangeFilter.Last3Days));
            e.ComboBox.Items.Insert(index++, new FilterItem(Utils.DateFilterLast3Days, fInfo));

            // Last week
            fInfo = new ColumnFilterInfo(GetFilterString(DataGridDateColumnName, DateRangeFilter.LastWeek),
                GetFilterDisplayText(DateRangeFilter.LastWeek));
            e.ComboBox.Items.Insert(index++, new FilterItem(Utils.DateFilterLastWeek, fInfo));

            // Last 2 weeks
            fInfo = new ColumnFilterInfo(GetFilterString(DataGridDateColumnName, DateRangeFilter.Last2Weeks),
                GetFilterDisplayText(DateRangeFilter.Last2Weeks));
            e.ComboBox.Items.Insert(index++, new FilterItem(Utils.DateFilterLast2Weeks, fInfo));

            // Last month.
            fInfo = new ColumnFilterInfo(GetFilterString(DataGridDateColumnName, DateRangeFilter.LastMonth),
                GetFilterDisplayText(DateRangeFilter.LastMonth));
            e.ComboBox.Items.Insert(index, new FilterItem(Utils.DateFilterLastMonth, fInfo));

            #endregion Create and add custom filter criteria to select the records which refer to the current date.
        }

        #endregion

        #region Messages logic

        internal DataTable GetFilteredDataTable()
        {
            // Create a data view by applying the grid view row filter
            try
            {
                lockSlim.EnterReadLock();
                string filter = _messageData.DefaultView.RowFilter;
                if (LogGrid.ActiveFilterEnabled && !string.IsNullOrEmpty(LogGrid.ActiveFilterString))
                {
                    CriteriaOperator op = LogGrid.ActiveFilterCriteria; //filterControl1.FilterCriteria
                    string filterString = CriteriaToWhereClauseHelper.GetDataSetWhere(op);
                    filter = string.IsNullOrEmpty(filter) ? filterString : $"{filter} and {filterString}";
                }

                return new DataView(_messageData, filter, null, DataViewRowState.CurrentRows).ToTable();
            }
            finally
            {
                lockSlim.ExitReadLock();
            }
        }

        public List<IAnalogyLogMessage> GetMessages() => PagingManager.GetAllMessages();
        public Guid Id { get; }

        private string GetFilterDisplayText(DateRangeFilter filterType)
        {
            string displayText = string.Empty;
            switch (filterType)
            {
                case DateRangeFilter.None:
                    displayText = Utils.DateFilterNone;
                    break;
                case DateRangeFilter.Today:
                    displayText = Utils.DateFilterToday;
                    break;
                case DateRangeFilter.Last2Days:
                    displayText = Utils.DateFilterLast2Days;
                    break;
                case DateRangeFilter.Last3Days:
                    displayText = Utils.DateFilterLast3Days;
                    break;
                case DateRangeFilter.LastWeek:
                    displayText = Utils.DateFilterLastWeek;
                    break;
                case DateRangeFilter.Last2Weeks:
                    displayText = Utils.DateFilterLast2Weeks;
                    break;
                case DateRangeFilter.LastMonth:
                    displayText = Utils.DateFilterLastMonth;
                    break;
            }

            return displayText;
        }

        /// <summary>
        /// Get the filter string for Quick filter
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="filterType"></param>
        /// <returns></returns>
        private string GetFilterString(string columnName, DateRangeFilter filterType)
        {
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today;

            switch (filterType)
            {
                // The filter expression for the TODAY item.
                case DateRangeFilter.Today:
                    startDate = DateTime.Today;
                    endDate = startDate.AddDays(1);
                    break;

                // The filter expression for the last 2 days item.
                case DateRangeFilter.Last2Days:
                    endDate = DateTime.Today.AddDays(1);
                    startDate = DateTime.Today.AddDays(-1);
                    break;

                // The filter expression for the last 3 days item.
                case DateRangeFilter.Last3Days:
                    endDate = DateTime.Today.AddDays(1);
                    startDate = DateTime.Today.AddDays(-2);
                    break;

                // The filter expression for the last week item.
                case DateRangeFilter.LastWeek:
                    endDate = DateTime.Today.AddDays(1);
                    startDate = DateTime.Today.AddDays(-7);
                    break;

                // The filter expression for the last 2 weeks item.
                case DateRangeFilter.Last2Weeks:
                    endDate = DateTime.Today.AddDays(1);
                    startDate = DateTime.Today.AddDays(-14);
                    break;

                // The filter expression for the last month item.
                case DateRangeFilter.LastMonth:
                    endDate = DateTime.Today.AddDays(1);
                    startDate = DateTime.Today.AddMonths(-1);
                    break;
            }

            string startDateStr = "#" + startDate.ToString("g", CultureInfo.CreateSpecificCulture("en-US")) + "#";
            string endDateStr = "#" + endDate.ToString("g", CultureInfo.CreateSpecificCulture("en-US")) + "#";
            var filter = "([" + columnName + "] >= " + startDateStr + " AND [" + columnName + "] < " + endDateStr + ")";
            return filter;
        }

        #endregion

        public void AppendMessage(IAnalogyLogMessage message, string dataSource)
        {
            if (message.Level == AnalogyLogLevel.None)
            {
                return; //ignore those messages
            }

            if (Settings.IdleMode && Utils.IdleTime().TotalMinutes > Settings.IdleTimeMinutes)
            {
                PagingManager.IncrementTotalMissedMessages();
                return;
            }

            if (frmDataVisualizer != null)
            {
                frmDataVisualizer.AppendMessage(message, dataSource);
            }

            if (ExternalWindowsCount > 0)
            {
                foreach (XtraFormLogGrid grid in ExternalWindows)
                {
                    grid.AppendMessage(message, dataSource);
                }
            }

            DataRow dtr = PagingManager.AppendMessage(message, dataSource);
            try
            {
                lockSlim.EnterWriteLock();
                if (diffStartTime > DateTimeOffset.MinValue)
                {
                    dtr["TimeDiff"] = Utils.GetOffsetTime(message.Date, Settings.TimeOffsetType, Settings.TimeOffset).Subtract(diffStartTime).ToString();
                }
            }
            finally
            {
                lockSlim.ExitWriteLock();
            }

            if (message.AdditionalProperties != null && message.AdditionalProperties.Any() &&
                Settings.CheckAdditionalInformation)
            {
                AddExtraColumnsToLogGrid(logGrid, message);
            }

            try
            {
                lockSlim.EnterWriteLock();
                if (hasAnyInPlaceExtensions)
                {
                    foreach (IAnalogyExtensionInPlace extension in InPlaceRegisteredExtensions)
                    {
                        var columns = extension.GetColumnsInfo();
                        foreach (AnalogyColumnInfo column in columns)
                        {
                            if (dtr.Table.Columns.Contains(column.ColumnName))
                            {
                                dtr.BeginEdit();
                                dtr[column.ColumnName] = extension.GetValueForCellColumn(message, column.ColumnName);
                                dtr.EndEdit();
                            }
                        }
                    }
                }

                if (hasAnyUserControlExtensions)
                {
                    foreach (IAnalogyExtensionUserControl extension in UserControlRegisteredExtensions)
                    {
                        if (IsHandleCreated)
                        {
                            BeginInvoke(new MethodInvoker(() => extension.NewMessage(message, Id)));
                        }
                    }
                }
            }
            finally
            {
                lockSlim.ExitWriteLock();
            }

            if (PagingManager.IsCurrentPageInView(_messageData))
            {
                NewDataExist = true;
            }
        }

        private void AddExtraColumnsToLogGrid(GridView gridView, IAnalogyLogMessage message)
        {
            if (message.AdditionalProperties != null && message.AdditionalProperties.Any() &&
                Settings.CheckAdditionalInformation)
            {
                var newFieldCreated = false;
                foreach (KeyValuePair<string, string> info in message.AdditionalProperties)
                {
                    if (!CurrentColumnsFields.Exists(c => c.Field == info.Key))
                    {
                        newFieldCreated = true;
                        if (InvokeRequired)
                        {
                            BeginInvoke(new MethodInvoker(() =>
                            {
                                if (!gridView.Columns.Select(g => g.FieldName).Contains(info.Key))
                                {
                                    var grid = new GridColumn() { Caption = info.Key, FieldName = info.Key, Name = info.Key, Visible = true };
                                    grid.OptionsColumn.ReadOnly = true;
                                    gridView.Columns.Add(grid);
                                    CurrentColumnsFields.Add((info.Key, info.Key));
                                    IncludeFilterCriteriaUIOptions.Add(new FilterCriteriaUIOption(info.Key, info.Key, false));
                                    ExcludeFilterCriteriaUIOptions.Add(new FilterCriteriaUIOption(info.Key, info.Key, false));
                                }
                                columnAdderSync.Set();
                            }));
                            columnAdderSync.WaitOne();
                            columnAdderSync.Reset();
                        }
                        else
                        {
                            if (!gridView.Columns.Select(g => g.FieldName).Contains(info.Key))
                            {
                                var grid = new GridColumn() { Caption = info.Key, FieldName = info.Key, Name = info.Key, Visible = true };
                                grid.OptionsColumn.ReadOnly = true;
                                gridView.Columns.Add(grid);
                                CurrentColumnsFields.Add((info.Key, info.Key));
                                IncludeFilterCriteriaUIOptions.Add(new FilterCriteriaUIOption(info.Key, info.Key, false));
                                ExcludeFilterCriteriaUIOptions.Add(new FilterCriteriaUIOption(info.Key, info.Key, false));
                            }
                        }
                    }

                    if (newFieldCreated)
                    {
                        UpdateSearchColumn();
                    }
                }
            }
        }

        public void AppendMessages(List<IAnalogyLogMessage> messages, string dataSource)
        {
            if (Settings.IdleMode && Utils.IdleTime().TotalMinutes > Settings.IdleTimeMinutes)
            {
                PagingManager.IncrementTotalMissedMessages();
                return;
            }

            //lockSlim.EnterWriteLock();
            if (ExternalWindowsCount > 0)
            {
                foreach (XtraFormLogGrid grid in ExternalWindows)
                {
                    grid.AppendMessages(messages, dataSource);
                }
            }

            if (frmDataVisualizer != null)
            {
                frmDataVisualizer.AppendMessages(messages, dataSource);
            }

            foreach (var (dtr, message) in PagingManager.AppendMessages(messages, dataSource))
            {
                if (diffStartTime > DateTimeOffset.MinValue)
                {
                    dtr["TimeDiff"] = Utils.GetOffsetTime(message.Date, Settings.TimeOffsetType, Settings.TimeOffset).Subtract(diffStartTime).ToString();
                }

                if (hasAnyInPlaceExtensions)
                {
                    foreach (IAnalogyExtensionInPlace extension in InPlaceRegisteredExtensions)
                    {
                        var columns = extension.GetColumnsInfo();
                        foreach (AnalogyColumnInfo column in columns)
                        {
                            dtr[column.ColumnName] = extension.GetValueForCellColumn(message, column.ColumnName);
                        }
                    }
                }

                if (message.AdditionalProperties != null && message.AdditionalProperties.Any() &&
                    Settings.CheckAdditionalInformation)
                {
                    AddExtraColumnsToLogGrid(logGrid, message);
                }

                dtr.EndEdit();
            }

            //lockSlim.ExitWriteLock();
            if (PagingManager.IsCurrentPageInView(_messageData))
            {
                NewDataExist = true;
            }

            if (hasAnyUserControlExtensions)
            {
                foreach (var extension in UserControlRegisteredExtensions)
                {
                    BeginInvoke(new MethodInvoker(() => extension.NewMessages(messages, Id)));
                }
            }
        }

        private void AcceptChanges(bool forceRefresh)
        {
            if (!IsHandleCreated)
            {
                return;
            }

            if (_realtimeUpdate || forceRefresh)

            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    lockSlim.EnterWriteLock();
                    try
                    {
                        //LogGrid.BeginDataUpdate();
                        _messageData.AcceptChanges();

                        //LogGrid.EndDataUpdate();
                    }
                    finally
                    {
                        lockSlim.ExitWriteLock();
                    }
                }));
            }
        }

        private void UpdatePage(DataTable page)
        {
            _messageData = page;
            lockSlim.EnterWriteLock();
            try
            {
                gridControl.DataSource = _messageData.DefaultView;

                //NewDataExist = true;
                //FilterHasChanged = true;
                lblPageNumber.Text = TotalPages > 1 ? $"Page {PageNumber} / {TotalPages}" : $"Page {PageNumber}";
                NewDataExist = true;
                FilterResults();
            }
            finally
            {
                lockSlim.ExitWriteLock();
            }
        }

        public void FilterResults(string module)
        {
            if (IsDisposed)
            {
                return;
            }

            txtbModule.Text = module;
            FilterResults();
        }

        private void FilterResults()
        {
            string include = txtbInclude.EditValue == null ? string.Empty : txtbInclude.EditValue.ToString().Trim();
            string exclude = txtbExclude.EditValue == null ? string.Empty : txtbExclude.EditValue.ToString().Trim();
            if (!autoCompleteInclude.Contains(include))
            {
                autoCompleteInclude.Add(include);
            }

            if (!autoCompleteExclude.Contains(exclude))
            {
                autoCompleteExclude.Add(exclude);
            }

            Settings.AddNewSearchesEntryToLists(include, true);
            Settings.AddNewSearchesEntryToLists(exclude, false);
            _filterCriteria.StartTime = ceNewerThanFilter.Checked ? deNewerThanFilter.DateTime : DateTime.MinValue;
            _filterCriteria.EndTime = ceOlderThanFilter.Checked ? deOlderThanFilter.DateTime : DateTime.MaxValue;
            _filterCriteria.TextInclude = ceIncludeText.Checked ? include : string.Empty;
            _filterCriteria.TextExclude = ceExcludeText.Checked ? exclude + string.Join("|", _excludeMostCommon) : string.Empty;

            _filterCriteria.Levels = null;
            switch (LogLevelSelectionType)
            {
                case LogLevelSelectionType.Single:
                    if (chkLstLogLevel.Items[0].CheckState == CheckState.Checked)
                    {
                        if (Settings.HideUnknownLogLevel)
                        {
                            _filterCriteria.Levels =
                            [
                                AnalogyLogLevel.Trace,
                            ];
                        }
                        else
                        {
                            _filterCriteria.Levels =
                            [
                                AnalogyLogLevel.Trace,
                                AnalogyLogLevel.Unknown
                            ];
                        }
                    }

                    if (chkLstLogLevel.Items[1].CheckState == CheckState.Checked)
                    {
                        if (Settings.HideUnknownLogLevel)
                        {
                            _filterCriteria.Levels =
                            [
                                AnalogyLogLevel.Error, AnalogyLogLevel.Critical,
                            ];
                        }
                        else
                        {
                            _filterCriteria.Levels =
                            [
                                AnalogyLogLevel.Error, AnalogyLogLevel.Critical,
                                AnalogyLogLevel.Unknown
                            ];
                        }
                    }
                    else if (chkLstLogLevel.Items[2].CheckState == CheckState.Checked)
                    {
                        if (Settings.HideUnknownLogLevel)
                        {
                            _filterCriteria.Levels =
                            [
                                AnalogyLogLevel.Warning,
                            ];
                        }
                        else
                        {
                            _filterCriteria.Levels =
                            [
                                AnalogyLogLevel.Warning,
                                AnalogyLogLevel.Unknown
                            ];
                        }
                    }
                    else if (chkLstLogLevel.Items[3].CheckState == CheckState.Checked)
                    {
                        if (Settings.HideUnknownLogLevel)
                        {
                            _filterCriteria.Levels =
                            [
                                AnalogyLogLevel.Debug,
                            ];
                        }
                        else
                        {
                            _filterCriteria.Levels =
                            [
                                AnalogyLogLevel.Debug,
                                AnalogyLogLevel.Unknown
                            ];
                        }
                    }
                    else if (chkLstLogLevel.Items[4].CheckState == CheckState.Checked)
                    {
                        if (Settings.HideUnknownLogLevel)
                        {
                            _filterCriteria.Levels =
                            [
                                AnalogyLogLevel.Verbose,
                            ];
                        }
                        else
                        {
                            _filterCriteria.Levels =
                            [
                                AnalogyLogLevel.Verbose,
                                AnalogyLogLevel.Unknown
                            ];
                        }
                    }

                    break;
                case LogLevelSelectionType.Multiple:
                    _filterCriteria.Levels = chkLstLogLevel.CheckedItems.Cast<CheckedListBoxItem>()
                        .Select(level => (AnalogyLogLevel)Enum.Parse(typeof(AnalogyLogLevel), (string)level.Value))
                        .ToArray();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (ceSources.Checked && txtbSource.EditValue != null)
            {
                var items = txtbSource.EditValue.ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(v => v.Trim()).ToList();
                var includeItems = items.Where(i => !i.StartsWith("-"));
                var excludeItems = items.Where(i => i.StartsWith("-") && i.Length > 1)
                    .Select(i => i.Substring(1, i.Length - 1));

                _filterCriteria.Sources = includeItems.Select(val => val.Trim()).ToArray();
                _filterCriteria.ExcludedSources = excludeItems.Select(val => val.Trim()).ToArray();
            }
            else
            {
                _filterCriteria.Sources = null;
                _filterCriteria.ExcludedSources = null;
            }

            Settings.SourceText = Settings.SaveSearchFilters && txtbSource.EditValue != null ? txtbSource.EditValue.ToString() : string.Empty;

            if (ceModulesProcess.Checked && txtbModule.EditValue != null)
            {
                var items = txtbModule.EditValue.ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(v => v.Trim()).ToList();
                var includeItems = items.Where(i => !i.StartsWith("-"));
                var excludeItems = items.Where(i => i.StartsWith("-") && i.Length > 1)
                    .Select(i => i.Substring(1, i.Length - 1));

                _filterCriteria.Modules = includeItems.Select(val => val.Trim()).ToArray();
                _filterCriteria.ExcludedModules = excludeItems.Select(val => val.Trim()).ToArray();
            }
            else
            {
                _filterCriteria.Modules = null;
                _filterCriteria.ExcludedModules = null;
            }

            Settings.ModuleText = Settings.SaveSearchFilters && txtbModule.EditValue != null ? txtbModule.EditValue.ToString().Trim() : string.Empty;
            string filter = _filterCriteria.GetSqlExpression(ceLogLevelOr.Checked);
            lockSlim.EnterWriteLock();
            if (LogGrid.ActiveFilterEnabled && !string.IsNullOrEmpty(LogGrid.ActiveFilterString))
            {
                CriteriaOperator op = LogGrid.ActiveFilterCriteria;
                string filterString = CriteriaToWhereClauseHelper.GetDataSetWhere(op);
                filter = $"{filter} and {filterString}";
            }

            try
            {
                meRawSQL.Text = filter;
                OnSetRawSQLFilter?.Invoke(this, filter);
                _messageData.DefaultView.RowFilter = filter;
                if (Settings is { AutoScrollToLastMessage: false, TrackActiveMessage: true })
                {
                    var location = LocateByValue(0, gridColumnObject, SelectedMassage);
                    if (location >= 0)
                    {
                        LogGrid.FocusedRowHandle = location;
                    }
                }
            }
            finally
            {
                lockSlim.ExitWriteLock();
            }
        }

        public bool ApplyRawSQLFilter(string filter)
        {
            try
            {
                lockSlim.EnterWriteLock();
                _messageData.DefaultView.RowFilter = filter;

                if (!Settings.AutoScrollToLastMessage && Settings.TrackActiveMessage)
                {
                    var location = LocateByValue(0, gridColumnObject, SelectedMassage);
                    if (location >= 0)
                    {
                        LogGrid.FocusedRowHandle = location;
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                lockSlim.ExitWriteLock();
                OnRawSQLFilterChanged?.Invoke(this, filter);
            }
        }

        public int LocateByValue(int startRowHandle, GridColumn column, object? val)
        {
            if (!LogGrid.DataController.IsReady || val == null)
            {
                return int.MinValue;
            }

            startRowHandle = Math.Max(0, startRowHandle);
            if (LogGrid.IsServerMode)
            {
                if (startRowHandle != 0)
                {
                    throw new ArgumentException("Argument must be '0' in server mode.", nameof(startRowHandle));
                }
            }

            try
            {
                if (LogGrid.IsServerMode)
                {
                    return LogGrid.DataController.FindRowByValue(column.FieldName, val, null);
                }

                for (int rowHandle = startRowHandle;
                    rowHandle < LogGrid.DataController.VisibleListSourceRowCount;
                    ++rowHandle)
                {
                    object rowCellValue = LogGrid.GetRowCellValue(rowHandle, column.Caption);
                    if (Equals(val, rowCellValue))
                    {
                        return rowHandle;
                    }
                }
            }
            catch
            {
                //do nothing
            }

            return int.MinValue;
        }
        public int LocateDateRowByValue(int startRowHandle, DateTime val)
        {
            if (!LogGrid.DataController.IsReady || val == null)
            {
                return int.MinValue;
            }

            startRowHandle = Math.Max(0, startRowHandle);
            if (LogGrid.IsServerMode)
            {
                if (startRowHandle != 0)
                {
                    throw new ArgumentException("Argument must be '0' in server mode.", nameof(startRowHandle));
                }
            }

            try
            {
                if (LogGrid.IsServerMode)
                {
                    return LogGrid.DataController.FindRowByValue(gridColumnDate.FieldName, val, null);
                }

                for (int rowHandle = startRowHandle;
                     rowHandle < LogGrid.DataController.VisibleListSourceRowCount;
                     ++rowHandle)
                {
                    object rowCellValue = LogGrid.GetRowCellValue(rowHandle, gridColumnDate.Caption);
                    if (val.Equals(rowCellValue))
                    {
                        return rowHandle;
                    }
                }
            }
            catch
            {
                //do nothing
            }

            return int.MinValue;
        }
        public async Task LoadFilesAsync(List<string> fileNames, bool clearLogBeforeLoading,
            bool isReloadSoForceNoCaching = false)
        {
            LoadedFiles = fileNames;
            bbtnReload.Visibility = BarItemVisibility.Always;
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = CancellationTokenSource.Token;
            if (clearLogBeforeLoading)
            {
                ClearLogs(false);
            }

            bbtnCancel.Visibility = BarItemVisibility.Always;
            fileLoadingCount = fileNames.Count;
            bprogressBar.Visibility = BarItemVisibility.Always;
            int processed = 0;
            foreach (string filename in fileNames)
            {
                if (!File.Exists(filename))
                {
                    AnalogyLogMessage m = new($"File {filename} does not exist",
                        AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None");
                    AppendMessage(m, "Analogy");
                    continue;
                }

                Text = @"File: " + filename;
                await FileProcessor.Process(FileDataProvider, filename, token, isReloadSoForceNoCaching);
                processed++;
                ProgressReporter.Report(new AnalogyProgressReport("Processed", processed, fileNames.Count, filename));
                if (token.IsCancellationRequested)
                {
                    bprogressBar.Visibility = BarItemVisibility.Never;
                    break;
                }
            }

            bbtnCancel.Visibility = BarItemVisibility.Never;
        }

        private void ClearLogs(bool raiseEvent)
        {
            lockSlim.EnterWriteLock();

            if (raiseEvent)
            {
                OnHistoryCleared?.Invoke(this, new AnalogyClearedHistoryEventArgs(PagingManager.GetAllMessages()));
            }

            PagingManager.ClearLogs();
            UpdatePage(PagingManager.FirstPage());
            AcceptChanges(true);
            recMessageDetails.Text = string.Empty;
            recMessageDetails.HtmlText = string.Empty;
            meMessageDetails.Text = string.Empty;
            lockSlim.ExitWriteLock();
        }

        private void LoadTextBoxes(AnalogyLogMessage m)
        {
            meMessageDetails.InvokeIfRequired((_) =>
            {
                if (!meMessageDetails.Visible)
                {
                    return;
                }
                switch (m.RawTextType)
                {
                    case AnalogyRowTextType.None:
                    case AnalogyRowTextType.Unknown:
                    case AnalogyRowTextType.PlainText:
                    case AnalogyRowTextType.RichText:
                    case AnalogyRowTextType.XML:
                    case AnalogyRowTextType.HTML:
                    case AnalogyRowTextType.Markdown:
                        bbtnRawMessageViewer.Visibility = string.IsNullOrEmpty(m.RawText) ? BarItemVisibility.Never : BarItemVisibility.Always;
                        bbtnRawMessageViewer.Caption = "View Raw Data";
                        break;
                    case AnalogyRowTextType.JSON:
                        bbtnRawMessageViewer.Visibility = BarItemVisibility.Always;
                        bbtnRawMessageViewer.Caption = "View in Json Visualizer";
                        bbtnRawMessageViewer.ImageOptions.Image = Resources.json16x16;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                bbtnRawMessageViewer.Tag = m;
                recMessageDetails.Tag = m;
                recMessageDetails.Text = Utils.ProcessLinuxMessage(m.Text, Settings.SupportLinuxFormatting);
                meMessageDetails.Tag = m;
                meMessageDetails.Text = Utils.ProcessLinuxMessage(m.Text, Settings.SupportLinuxFormatting);
                recMessageDetails.HtmlText = Markdown.ToHtml(m.Text, pipeline);
            });
        }

        #region Log grid Event Handlers

        private void logGrid_Click(object sender, EventArgs e)
        {
            if (!(e is DXMouseEventArgs args))
            {
                return;
            }

            GridHitInfo hi = LogGrid.CalcHitInfo(new Point(args.X, args.Y));

            if (hi.RowHandle < 0)
            {
                return;
            }

            int[] selRows = LogGrid.GetSelectedRows();

            if (selRows == null || selRows.Length != 1)
            {
                return;
            }

            int rownum = selRows.First();
            SelectedMassage = (AnalogyLogMessage)LogGrid.GetRowCellValue(rownum, Common.CommonUtils.AnalogyMessageColumn);
            LoadTextBoxes(SelectedMassage);
            if (hasAnyInPlaceExtensions)
            {
                var rowHandle = hi.RowHandle;
                var column = hi.Column;
                if (column == null)
                {
                    return;
                }

                foreach (var extension in InPlaceRegisteredExtensions)
                {
                    var columns = extension.GetColumnsInfo();
                    foreach (AnalogyColumnInfo exColumn in columns)
                    {
                        if (column.FieldName.Equals(exColumn.ColumnName) &&
                            column.Caption.Equals(exColumn.ColumnCaption))
                        {
                            var cellValue = LogGrid.GetRowCellValue(rowHandle, exColumn.ColumnName);
                            AnalogyCellClickedEventArgs argsForEx = new(exColumn.ColumnName, cellValue, SelectedMassage);
                            extension.CellClicked(sender, argsForEx);
                        }
                    }
                }
            }
        }
        private void LogGrid_DoubleClick(object sender, EventArgs e)
        {
            if (!(e is DXMouseEventArgs args))
            {
                return;
            }
            GridHitInfo hi = LogGrid.CalcHitInfo(new Point(args.X, args.Y));

            if (hi.RowHandle < 0)
            {
                return;
            }
            string dataSource = (string)LogGrid.GetRowCellValue(hi.RowHandle, "DataProvider") ?? string.Empty;
            AnalogyLogMessage? message = LogGrid.GetRowCellValue(hi.RowHandle, Common.CommonUtils.AnalogyMessageColumn) as AnalogyLogMessage;
            if (message == null)
            {
                return;
            }

            FormMessageDetails details = new(message, Messages, dataSource, Settings);
            DataProvider.MessageOpened(message);
            details.Show();

            //CreateBookmark();
        }

        private void LogGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (AnalogyLogMessage message, _) = GetMessageFromSelectedFocusedRowInGrid();
            if (message == null)
            {
                return;
            }

            LoadTextBoxes(message);
        }

        private void LogGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                (AnalogyLogMessage? message, string dataSource) = GetMessageFromSelectedFocusedRowInGrid();
                if (message == null)
                {
                    return;
                }

                FormMessageDetails details = new(message, Messages, dataSource, Settings);
                DataProvider.MessageOpened(message);
                details.Show();
            }
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

            if (!Settings.ColorSettings.OverrideLogLevelColor && Settings.ColorSettings.EnableNewMessagesColor &&
                message.Date > reloadDateTime)
            {
                e.Appearance.BackColor = Settings.ColorSettings.NewMessagesColor.BackgroundColor;
                e.Appearance.ForeColor = Settings.ColorSettings.NewMessagesColor.TextColor;
            }

            var (backgroundColorLevel, textColorLevel) = Settings.ColorSettings.GetColorForLogLevel(message.Level);
            e.Appearance.BackColor = backgroundColorLevel;
            e.Appearance.ForeColor = textColorLevel;

            if (Settings.ColorSettings.OverrideLogLevelColor && Settings.ColorSettings.EnableNewMessagesColor &&
                message.Date > reloadDateTime)
            {
                var (backgroundColor, textColor) = Settings.ColorSettings.NewMessagesColor;
                e.Appearance.BackColor = backgroundColor;
                e.Appearance.ForeColor = textColor;
            }
            string text = view.GetRowCellDisplayText(e.RowHandle, view.Columns["Text"]);
            foreach (PreDefineHighlight preDefineHighlight in Settings.PreDefinedQueries.Highlights)
            {
                if (FilterCriteriaObject.Match(text, preDefineHighlight.Text,
                    preDefineHighlight.PreDefinedQueryType))
                {
                    e.Appearance.BackColor = preDefineHighlight.Color;
                }
            }

            if (DataProvider != null && DataProvider.UseCustomColors)
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

            if (chkbHighlight.Checked &&
                FilterCriteriaObject.Match(text, txtbHighlight.Text, PreDefinedQueryType.Contains))
            {
                var (backgroundColorHighlight, textColorHighlight) = Settings.ColorSettings.GetHighlightColor();
                e.Appearance.BackColor = backgroundColorHighlight;
                e.Appearance.ForeColor = textColorHighlight;
            }
        }

        private void LogGrid_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!(e.RowHandle >= 0) || !e.Info.IsRowIndicator || !(sender is GridView view))
            {
                return;
            }

            AnalogyLogMessage msg = (AnalogyLogMessage)view.GetRowCellValue(e.RowHandle, Common.CommonUtils.AnalogyMessageColumn);
            if (msg == null)
            {
                return;
            }

            Image img = imageList.Images[7];
            switch (msg.Level)
            {
                case AnalogyLogLevel.Critical:
                case AnalogyLogLevel.Error:
                    img = imageList.Images[0];
                    break;
                case AnalogyLogLevel.Warning:
                    img = imageList.Images[1];
                    break;
                case AnalogyLogLevel.Trace:
                case AnalogyLogLevel.Information:
                    img = imageList.Images[7];
                    break;
                case AnalogyLogLevel.Verbose:
                    img = imageList.Images[2];
                    break;
                case AnalogyLogLevel.Debug:
                    img = imageList.Images[6];
                    break;
                case AnalogyLogLevel.None:
                    break;
                case AnalogyLogLevel.Analogy:
                    img = imageList.Images[8];
                    break;
                case AnalogyLogLevel.Unknown:
                    img = imageList.Images[9];
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Rectangle r = e.Bounds;
            int x = r.X + (r.Width - imageList.ImageSize.Width) / 2;
            int y = r.Y + (r.Height - imageList.ImageSize.Height) / 2;
            e.Cache.DrawImage(img, x, y);
            e.Handled = true;
        }

        /// <summary>
        /// Set custom column display text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogGridViewCustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.GroupRowHandle == BaseListSourceDataController.FilterRow &&
                e.Column.FieldName == DataGridDateColumnName)
            {
                e.DisplayText = e.Column.FilterInfo.DisplayText;
            }
        }

        #endregion

        private void tmrNewData_Tick(object sender, EventArgs e)
        {
            if (NewDataExist)
            {
                NewDataExist = false;
                AcceptChanges(false);
            }
        }
        private void AddExtraColumnsIfNeededToTable(DataTable table, GridView view, IAnalogyLogMessage message)
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
                                DataColumn dt = new(info.Key);
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
        private void GoToPrimaryGridMessage(AnalogyLogMessage m)
        {
            btsAutoScrollToBottom.Checked = false;
            GoToMessage(m);
        }

        private void GoToMessage(AnalogyLogMessage logMessage)
        {
            try
            {
                var location = LocateByValue(0, gridColumnObject, logMessage);
                if (location >= 0)
                {
                    logGrid.FocusedRowHandle = location;
                    logGrid.MakeRowVisible(location);
                }
                else
                {
                    XtraMessageBox.Show("Cannot go to message", "Message not found", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Cannot go to message", "Message not found", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void txtbHighlight_KeyUp(object sender, KeyEventArgs e)
        {
            chkbHighlight.Checked = !string.IsNullOrEmpty(txtbHighlight.Text);
            HighlightRows.Clear();
            await FilterHasChanged();
        }

        private void tsmiExcludeSource_Click(object sender, EventArgs e)
        {
            (AnalogyLogMessage message, _) = GetMessageFromSelectedFocusedRowInGrid();
            if (!string.IsNullOrEmpty(message?.Source))
            {
                txtbSource.Text = txtbSource.Text == txtbSource.Properties.NullText ? "-" + message.Source : txtbSource.Text + ", -" + message.Source;
            }
        }

        private void tsmiExcludeModule_Click(object sender, EventArgs e)
        {
            (AnalogyLogMessage message, _) = GetMessageFromSelectedFocusedRowInGrid();
            if (!string.IsNullOrEmpty(message?.Module))
            {
                txtbModule.Text = txtbModule.Text == txtbModule.Properties.NullText ? "-" + message.Module : txtbModule.Text + ",-" + message.Module;
            }
        }

        private void tsmiTimeDiff_Click(object sender, EventArgs e)
        {
            (AnalogyLogMessage message, _) = GetMessageFromSelectedFocusedRowInGrid();
            if (message != null)
            {
                diffStartTime = Utils.GetOffsetTime(message.Date, Settings.TimeOffsetType, Settings.TimeOffset);
                UpdateTimes();
            }

            void UpdateTimes()
            {
                gridColumnTimeDiff.Visible = true;
                gridColumnTimeDiff.VisibleIndex = 2;

                lockSlim.EnterWriteLock();
                _messageData.BeginLoadData();
                foreach (DataRow row in _messageData.Rows)
                {
                    row.BeginEdit();
                    AnalogyLogMessage message = (AnalogyLogMessage)row[Common.CommonUtils.AnalogyMessageColumn];
                    row["TimeDiff"] = Utils.GetOffsetTime(message.Date, Settings.TimeOffsetType, Settings.TimeOffset).Subtract(diffStartTime).ToString();
                    row.EndEdit();
                }

                _messageData.EndLoadData();
                AcceptChanges(true);
                gridControl.RefreshDataSource();
                lockSlim.ExitWriteLock();
            }
        }

        private void btswitchExpand_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            Settings.ShowMessageDetails = btswitchMessageDetails.Checked;
            dockPanelMessageInfo.Visibility = btswitchMessageDetails.Checked ? DockVisibility.Visible : DockVisibility.Hidden;
        }

        private void btswitchRefreshLog_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            _realtimeUpdate = btswitchRefreshLog.Checked;
            AcceptChanges(false);

            //btswitchRefreshLog.Caption = _realtimeUpdate ? "Refresh log:" : "Paused:";
        }

        private void bBtnSaveLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            var messages = Messages;
            SaveMessagesToLog(FileDataProvider, messages);
        }

        private async void SaveMessagesToLog(IAnalogyOfflineDataProvider fileHandler, List<IAnalogyLogMessage> messages)
        {
            if (fileHandler != null && fileHandler.CanSaveToLogFile)
            {
                SaveFileDialog saveFileDialog = new();
                saveFileDialog.Filter = fileHandler.FileSaveDialogFilters;

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        await fileHandler.SaveAsync(messages, saveFileDialog.FileName);
                    }
                    catch (Exception e)
                    {
                        XtraMessageBox.Show(e.Message, @"Error Saving file", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (XtraMessageBox.Show(
                    "Current Data Source does not support Save Operation" + Environment.NewLine +
                    "Do you want to Save in Analogy Json Format?", @"Save not Supported", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    SaveMessagesToLog(AnalogyOfflineDataProvider, messages);
                }
                else
                {
                    XtraMessageBox.Show("Operation Aborted", @"Save file", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private async void bBtnImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FileDataProvider != null)
            {
                OpenFileDialog openFileDialog1 = new()
                {
                    Filter = Utils.GetOpenFilter(FileDataProvider.FileOpenDialogFilters, Settings.EnableCompressedArchives),
                    Title = @"Import file to current view",
                    Multiselect = false,
                };
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        await LoadFilesAsync(new List<string> { openFileDialog1.FileName }, false);
                    }
                    catch (Exception exception)
                    {
                        XtraMessageBox.Show(exception.Message, @"Error Opening file", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void bBtnClearLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClearLogs(true);
        }

        private async void sBtnMostCommon_Click(object sender, EventArgs e)
        {
            List<string> items;

            lockSlim.EnterReadLock();
            items = Messages.Select(r => r.Text).ToList();
            lockSlim.ExitReadLock();

            AnalogyExclude ef = new(items, _excludeMostCommon, Settings.GetIcon());
            if (ef.ShowDialog(this) == DialogResult.OK)
            {
                _excludeMostCommon = AnalogyExclude.GlobalExclusion;
                ceExcludeText.Checked = true;
                await FilterHasChanged();
            }
        }

        private async void chkLstLogLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            await FilterHasChanged();
        }

        private async void chkLstLogLevel_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            await FilterHasChanged();
        }

        private void bBtnCopyButtom_ItemClick(object sender, ItemClickEventArgs e)
        {
            Clipboard.SetText(recMessageDetails.Text);
        }

        private void bBtnButtomExpand_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
        private void barToggleSwitchItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            dockPanelFiltering.Visible = !btSwitchExpandButtomMessage.Checked;
        }

        private void tsmiSaveLayout_Click(object sender, EventArgs e)
        {
            SaveGridLayout();
        }

        private void SaveGridLayout()
        {
            try
            {
                gridControl.MainView.SaveLayoutToXml(Settings.LogGridFileName);
            }
            catch (Exception e)
            {
                Logger.LogError($"Error saving setting: {e.Message}", e, "Analogy");
                XtraMessageBox.Show(e.Message, $"Error Saving layout file: {e.Message}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void HideRefreshAndScrolling()
        {
            btswitchRefreshLog.Visibility = BarItemVisibility.Never;
            btsAutoScrollToBottom.Visibility = BarItemVisibility.Never;
        }

        public void RemoveMessage(IAnalogyLogMessage msgMessage)
        {
            var row = _messageData.AsEnumerable().SingleOrDefault(r => r[Common.CommonUtils.AnalogyMessageColumn].Equals(msgMessage));
            if (row != null)
            {
                _messageData.Rows.Remove(row);
            }
        }

        private (AnalogyLogMessage? Message, string DataProvider) GetMessageFromSelectedFocusedRowInGrid()
        {
            var row = LogGrid.GetFocusedRow();
            if (row == null)
            {
                return (null, string.Empty);
            }

            string dataSource = (string)LogGrid.GetFocusedRowCellValue("DataProvider");
            AnalogyLogMessage message = (AnalogyLogMessage)LogGrid.GetFocusedRowCellValue(Common.CommonUtils.AnalogyMessageColumn);
            if (message.Module == null)
            {
                message.Module = string.Empty;
            }

            if (message.Source == null)
            {
                message.Source = string.Empty;
            }

            if (message.Text == null)
            {
                message.Text = string.Empty;
            }

            return (message, dataSource);
        }
        private List<IAnalogyLogMessage> GetMessagesFromSelectedRowInGrid(out string dataProvider)
        {
            dataProvider = string.Empty;
            var selectedRowHandles = logGrid.GetSelectedRows();
            List<IAnalogyLogMessage> messages = new();
            for (int i = 0; i < selectedRowHandles.Length; i++)
            {
                if (selectedRowHandles[i] >= 0)
                {
                    dataProvider = (string)LogGrid.GetRowCellValue(selectedRowHandles[i], "DataProvider");
                    AnalogyLogMessage message = (AnalogyLogMessage)LogGrid.GetRowCellValue(selectedRowHandles[i], Common.CommonUtils.AnalogyMessageColumn);
                    messages.Add(message);
                }
            }

            return messages;
        }

        private void tsmiCopyMessages_Click(object sender, EventArgs e)
        {
            var messages = Messages;
            string all = string.Join(Environment.NewLine, messages.Select(m => $"{m.Date.ToString()}: {m.Text}"));
            Clipboard.SetText(all);
        }
        private void btsAutoScrollToBottom_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            Settings.AutoScrollToLastMessage = btsAutoScrollToBottom.Checked;
        }

        private void sbtnPageFirst_Click(object sender, EventArgs e)
        {
            UpdatePage(PagingManager.FirstPage());
        }

        private void sbtnPagePrevious_Click(object sender, EventArgs e)
        {
            UpdatePage(PagingManager.PrevPage().Data);
        }

        private void sBtnPageNext_Click(object sender, EventArgs e)
        {
            if (PageNumber == TotalPages)
            {
                return;
            }

            UpdatePage(PagingManager.NextPage().Data);
        }

        private void sBtnLastPage_Click(object sender, EventArgs e)
        {
            UpdatePage(PagingManager.LastPage());
        }

        private void bBtnExportExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            var count = LogGrid.RowCount;

            SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = "Excel file XLSX (*.xlsx)|*.xlsx|Excel file XLS (*.XLS)|*.xls";

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (saveFileDialog.FilterIndex == 1)
                {
                    if (count > 1048576)
                    {
                        XtraMessageBox.Show($"XLSX files are limited to 1,048,576 rows (and 16,384 columns). You have {count} rows", "Export Aborted");
                    }
                    else
                    {
                        LogGrid.ExportToXlsx(saveFileDialog.FileName);
                        OpenFolder(saveFileDialog.FileName);
                    }
                }
                if (saveFileDialog.FilterIndex == 2)
                {
                    if (count > 65536)
                    {
                        XtraMessageBox.Show($"XLS files are limited to 65,536 rows (and 256 columns). You have {count} rows", "Export Aborted");
                    }
                    else
                    {
                        LogGrid.ExportToXls(saveFileDialog.FileName);
                        OpenFolder(saveFileDialog.FileName);
                    }
                }
            }
        }

        private void bBtnExportCSV_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = "Comma Separated File (*.csv)|*.csv";

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                LogGrid.ExportToCsv(saveFileDialog.FileName);
                OpenFolder(saveFileDialog.FileName);
            }
        }

        private void bBtnExportHtml_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = "HTML File (*.html)|*.html";

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                HtmlExportOptions op = new();
                op.ExportMode = HtmlExportMode.SingleFile;
                LogGrid.ExportToHtml(saveFileDialog.FileName, op);
                OpenFolder(saveFileDialog.FileName);
            }
        }
        private void OpenFolder(string filename)
        {
            try
            {
                Process.Start("explorer.exe", "/select, \"" + filename + "\"");
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message, @"Error Opening file location", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void bBtnUndockView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var msg = Messages;
            if (!msg.Any())
            {
                return;
            }

            var source = GetFilteredDataTable().Rows[0]?["DataProvider"]?.ToString();
            if (source == null)
            {
                return;
            }

            XtraFormLogGrid grid = new(Settings, msg, source, DataProvider, FileDataProvider);
            lockExternalWindowsObject.EnterWriteLock();
            _externalWindows.Add(grid);
            Interlocked.Increment(ref ExternalWindowsCount);
            lockExternalWindowsObject.ExitWriteLock();
            grid.FormClosing += (s, arg) =>
            {
                lockExternalWindowsObject.EnterWriteLock();
                Interlocked.Decrement(ref ExternalWindowsCount);
                _externalWindows.Remove(grid);
                lockExternalWindowsObject.ExitWriteLock();
            };
            grid.Show(this);
        }

        private void bBtnSaveEntireLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            var messages = PagingManager.GetAllMessages();
            SaveMessagesToLog(FileDataProvider, messages);
        }

        private async void logGrid_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            int row = e.FocusedRowHandle;

            if (row < 0)
            {
                return;
            }

            var focusedMassage = (AnalogyLogMessage)LogGrid.GetRowCellValue(e.FocusedRowHandle, Common.CommonUtils.AnalogyMessageColumn);
            DataProvider.MessageSelected(focusedMassage);
            LoadTextBoxes(focusedMassage);
            if (Settings.InlineJsonViewer)
            {
                if (useSpecificColumnForJson)
                {
                    var specific = LogGrid.GetRowCellValue(e.FocusedRowHandle, jsonColumnForInlineJsonViewer).ToString();
                    await JsonTreeView.ShowJson(specific);
                }
                else if (focusedMassage.RawTextType == AnalogyRowTextType.JSON)
                {
                    await JsonTreeView.ShowJson(focusedMassage.RawText);
                }
            }

            string dataProvider = (string)LogGrid.GetRowCellValue(e.FocusedRowHandle, "DataProvider");
            if (!LoadingInProgress && !string.IsNullOrEmpty(dataProvider))
            {
                OnFocusedRowChanged?.Invoke(this, (dataProvider, SelectedMassage));
            }
        }

        private void tsmiIncreaseFont_Click(object sender, EventArgs e)
        {
            var fontSize = Settings.FontSettings.GridFontSize = LogGrid.Appearance.Row.Font.Size + 2;
            LogGrid.Appearance.Row.Font = new Font(LogGrid.Appearance.Row.Font.Name, fontSize);
            SaveGridLayout();
        }

        private void tsmiDecreaseFont_Click(object sender, EventArgs e)
        {
            if (LogGrid.Appearance.Row.Font.Size < 5)
            {
                return;
            }

            {
                var fontSize = Settings.FontSettings.GridFontSize = LogGrid.Appearance.Row.Font.Size - 2;
                LogGrid.Appearance.Row.Font = new Font(LogGrid.Appearance.Row.Font.Name, fontSize);
                SaveGridLayout();
            }
        }

        private void bBtnDataVisualizer_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDataVisualizer = new DataVisualizerForm(Settings, () => Messages, Logger);
            frmDataVisualizer.Show(this);
        }

        private void bbiScreenshot_ItemClick(object sender, ItemClickEventArgs e)
        {
            Bitmap image = takeComponentScreenShot(gridControl);
            Clipboard.SetImage(image);
            MessageBox.Show("Screenshot of messages was copied to clipboard.", "Image was taken", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private static Bitmap takeComponentScreenShot(Control control)
        {
            // find absolute position of the control in the screen.
            Control ctrl = control;
            Rectangle rect = new(Point.Empty, ctrl.Size);
            do
            {
                rect.Offset(ctrl.Location);
                ctrl = ctrl.Parent;
            }
            while (ctrl != null);

            Bitmap bmp = new(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);

            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

            return bmp;
        }

        private void BbtnSaveViewAgnostic_ItemClick(object sender, ItemClickEventArgs e)
        {
            var messages = Messages;
            SaveMessagesToLog(AnalogyOfflineDataProvider, messages);
        }

        private void BarButtonItemSaveEntireInAnalogy_ItemClick(object sender, ItemClickEventArgs e)
        {
            var messages = PagingManager.GetAllMessages();
            SaveMessagesToLog(AnalogyOfflineDataProvider, messages);
        }

        private void bBtnUndockViewPerProcess_ItemClick(object sender, ItemClickEventArgs e)
        {
            UndockViewPerProcess();
        }

        private void UndockViewPerProcess()
        {
            var msg = Messages;
            if (!msg.Any())
            {
                return;
            }

            var source = GetFilteredDataTable().Rows[0]?["DataProvider"]?.ToString();
            if (source == null)
            {
                return;
            }

            var processes = msg.Select(m => m.Module).Distinct().ToList();
            foreach (string process in processes)
            {
                XtraFormLogGrid grid = new(Settings, msg, source, DataProvider, FileDataProvider, process);
                lockExternalWindowsObject.EnterWriteLock();
                _externalWindows.Add(grid);
                Interlocked.Increment(ref ExternalWindowsCount);
                lockExternalWindowsObject.ExitWriteLock();
                grid.FormClosing += (s, arg) =>
                {
                    lockExternalWindowsObject.EnterWriteLock();
                    Interlocked.Decrement(ref ExternalWindowsCount);
                    _externalWindows.Remove(grid);
                    lockExternalWindowsObject.ExitWriteLock();
                };
                grid.Show(this);
            }
        }

        private void sbtnTextInclude_Click(object sender, EventArgs e)
        {
            SetTextIfDifferent(txtbInclude, "");
        }

        private void sbtnTextExclude_Click(object sender, EventArgs e)
        {
            SetTextIfDifferent(txtbExclude, "");
        }

        private void sbtnIncludeSources_Click(object sender, EventArgs e)
        {
            SetTextIfDifferent(txtbSource, "");
        }

        private void sbtnIncludeModules_Click(object sender, EventArgs e)
        {
            SetTextIfDifferent(txtbModule, "");
        }

        private void tsmiDateFilterNewer_Click(object sender, EventArgs e)
        {
            (AnalogyLogMessage message, _) = GetMessageFromSelectedFocusedRowInGrid();
            if (message != null)
            {
                //todo: fix this as dateedit
                deNewerThanFilter.DateTime = Utils.GetDateTime(Utils.GetOffsetTime(message.Date, Settings.TimeOffsetType, Settings.TimeOffset));
                ceNewerThanFilter.Checked = true;
            }
        }

        public void SetHighlightSettings(Action openSettingForm)
        {
            this.sbtnMoreHighlight.Click += (s, e) =>
            {
                openSettingForm.Invoke();
            };
            this.sbtnMoreHighlight.Visible = true;
        }
        private void tsmiDateFilterOlder_Click(object sender, EventArgs e)
        {
            (AnalogyLogMessage message, _) = GetMessageFromSelectedFocusedRowInGrid();
            if (message != null)
            {
                //todo: fix this as dateedit
                deOlderThanFilter.DateTime = Utils.GetDateTime(Utils.GetOffsetTime(message.Date, Settings.TimeOffsetType, Settings.TimeOffset));
                ceOlderThanFilter.Checked = true;
            }
        }

        private void sbtnMoreHighlight_Click(object sender, EventArgs e)
        {
        }

        private void sbtnPreDefinedFilters_Click(object sender, EventArgs e)
        {
            if (!Settings.PreDefinedQueries.Filters.Any())
            {
                return;
            }

            filtersPopupMenu.ItemLinks.Clear();
            foreach (PreDefineFilter filter in Settings.PreDefinedQueries.Filters)
            {
                BarButtonItem item = new(barManager1, filter.ToString());
                item.ItemClick += (s, arg) =>
                {
                    SetTextIfDifferent(txtbInclude, filter.IncludeText);
                    SetTextIfDifferent(txtbExclude, filter.ExcludeText);
                    SetTextIfDifferent(txtbSource, filter.Sources);
                    SetTextIfDifferent(txtbModule, filter.Modules);
                };
                item.SuperTip = Utils.GetSuperTip(filter.Name, filter.NiceText());
                filtersPopupMenu.ItemLinks.Add(item);
            }
            filtersPopupMenu.ShowPopup(Cursor.Position);
        }

        public void EnableFileReload(string fileName)
        {
            LoadedFiles = new List<string>() { fileName };
            bbtnReload.Visibility = BarItemVisibility.Always;
        }

        public void SetReloadColorDate(DateTimeOffset value) => reloadDateTime = value;

        private void bBtnSaveCurrentSelectionCustomFormat_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveMessagesToLog(FileDataProvider, GetMessagesFromSelectedRowInGrid(out _));
        }

        private void bBtnSaveCurrentSelectionAnalogyFormat_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveMessagesToLog(AnalogyOfflineDataProvider, GetMessagesFromSelectedRowInGrid(out _));
        }

        private void bBtnUndockSelection_ItemClick(object sender, ItemClickEventArgs e)
        {
            var msg = GetMessagesFromSelectedRowInGrid(out var source);
            if (!msg.Any() || source == null)
            {
                return;
            }

            XtraFormLogGrid grid = new(Settings, msg, source, DataProvider, FileDataProvider);
            lockExternalWindowsObject.EnterWriteLock();
            _externalWindows.Add(grid);
            Interlocked.Increment(ref ExternalWindowsCount);
            lockExternalWindowsObject.ExitWriteLock();
            grid.FormClosing += (s, arg) =>
            {
                lockExternalWindowsObject.EnterWriteLock();
                Interlocked.Decrement(ref ExternalWindowsCount);
                _externalWindows.Remove(grid);
                lockExternalWindowsObject.ExitWriteLock();
            };
            grid.Show(this);
        }

        private void tsmiAddCommentToMessage_Click(object sender, EventArgs e)
        {
            var msg = GetMessageFromSelectedFocusedRowInGrid();
            if (msg.Message != null)
            {
                var addNoteForm = new AnalogyAddCommentsToMessage(msg.Message, Settings);
                addNoteForm.Show(this);
            }
        }

        private void txtbInclude_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsDisposed)
            {
                return;
            }

            xtcFilters.SelectedTabPage = xtpFiltersIncludes;
        }

        private void txtbExclude_EditValueChanged(object sender, EventArgs e)
        {
            if (IsDisposed)
            {
                return;
            }

            xtcFilters.SelectedTabPage = xtpFiltersExclude;
        }

        public void SaveCurrentWorkspace()
        {
            try
            {
                wsLogs.CaptureWorkspace(CurrentLogLayoutName);
                wsLogs.SaveWorkspace(CurrentLogLayoutName, CurrentLogLayoutFileName, true);
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message, nameof(SaveCurrentWorkspace));
            }
        }

        public async Task LoadFileInSeparateWindow(string filename)
        {
            if (!File.Exists(filename))
            {
                AnalogyLogMessage m = new($"File {filename} does not exist",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None");
                AppendMessage(m, "Analogy");
                return;
            }

            XtraFormLogGrid logGridForm = new(Settings, FileDataProvider, AnalogyOfflineDataProvider);
            logGridForm.Show(this);
            var processor = new FileProcessor(Settings, logGridForm.LogWindow, FileProcessingManager, Logger);
            await processor.Process(FileDataProvider, filename, new CancellationToken(), true);
        }

        public void ReportFileReadProgress(AnalogyFileReadProgress progress)
        {
            DataProviderProgressReporter.Report(progress);
        }

        public void ShowSecondaryWindow()
        {
            foreach (DockPanel dockPanel in dockManager1.Panels.Where(i => i.Dock == DockingStyle.Float).ToList())
            {
                dockPanel.Visibility = DockVisibility.Visible;
            }
        }

        public void HideSecondaryWindow()
        {
            foreach (DockPanel dockPanel in dockManager1.Panels.Where(i => i.Dock == DockingStyle.Float).ToList())
            {
                dockPanel.Visibility = DockVisibility.Hidden;
            }
        }
        public void ApplyCollapseFileAndFolderSettings()
        {
            CollapseFileAndFolderPanel?.Invoke(this, Settings.CollapseFolderAndFilesPanel);
        }
    }
}