using Analogy.DataSources;
using Analogy.Forms;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.Managers;
using Analogy.Properties;
using Analogy.Tools;
using Analogy.Types;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Analogy
{
    public partial class MainForm : RibbonForm
    {

        const int WM_COPYDATA = 0x004A;

        [DllImport("user32", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr Hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private string filePoolingTitle = "File Pooling";
        private string offlineTitle = "Offline log";
        private string onlineTitle = "Online log";
        private Dictionary<Guid, RibbonPage> Mapping = new Dictionary<Guid, RibbonPage>();

        private Dictionary<DockPanel, IAnalogyRealTimeDataProvider> onlineDataSourcesMapping =
            new Dictionary<DockPanel, IAnalogyRealTimeDataProvider>();

        private List<Task<bool>> OnlineSources = new List<Task<bool>>();
        private int openedWindows;
        private int filePooling;
        private bool disableOnlineDueToFileOpen;
        private DockPanel currentContextPage;
        private bool preventExit = false;
        private UserSettingsManager settings => UserSettingsManager.UserSettings;
        private bool Initialized { get; set; }

        public MainForm()
        {
            InitializeComponent();
            AnalogyLogManager.Instance.OnNewError += (s, e) => btnErrors.Visibility = BarItemVisibility.Always;
            // Handling the QueryControl event that will populate all automatically generated Documents
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_COPYDATA)
            {
                //Reconstruct copy data structure
                NativeMethods.COPYDATASTRUCT _dataStruct = Marshal.PtrToStructure<NativeMethods.COPYDATASTRUCT>(m.LParam);

                //Get the messag (file name we sent from the other instance)
                string filename = Marshal.PtrToStringUni(_dataStruct.lpData, _dataStruct.cbData / 2);

                string[] fileNames = { filename };
                _ = OpenOfflineFileWithSpecificDataProvider(fileNames);
                Process currentProcess = Process.GetCurrentProcess();
                IntPtr hWnd = currentProcess.MainWindowHandle;
                if (hWnd != IntPtr.Zero)
                {
                    SetForegroundWindow(hWnd);
                }
            }

            base.WndProc(ref m);
        }
        private void AnalogyMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //todo: end onlines;
        }

        private void AnalogyMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (preventExit && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                var popupNotifier = new NotificationWindow.PopupNotifier
                {
                    TitleText = "Analogy Log Viewer",
                    ContentText = "Still here... Double click the icon to restore",
                    IsRightToLeft = false,
                    Image = Properties.Resources.Analogy_Icon2

                };
                popupNotifier.Popup();
            }
            else
            {
                settings.AnalogyPosition.Location = Location;
                settings.AnalogyPosition.Size = Size;
                settings.AnalogyPosition.WindowState = WindowState;
                settings.UpdateRunningTime();
                settings.Save();
                AnalogyLogManager.Instance.SaveFile();
                BookmarkPersistManager.Instance.SaveFile();
            }
        }

        private async void AnalogyMainForm_Load(object sender, EventArgs e)
        {
            if (settings.AnalogyPosition.RememberLastPosition)
            {
                WindowState = settings.AnalogyPosition.WindowState;
                if (WindowState != FormWindowState.Maximized &&
                    Screen.AllScreens.Any(s => s.WorkingArea.Contains(settings.AnalogyPosition.Location)))
                {
                    Location = settings.AnalogyPosition.Location;
                    Size = settings.AnalogyPosition.Size;
                }
                else
                {
                    AnalogyLogger.Instance.LogError("",
                        $"Last location {settings.AnalogyPosition.Location} is not inside any screen");
                }
            }

            Text = $"Analogy Log Viewer ({UpdateManager.Instance.CurrentVersion})";
            Icon = settings.GetIcon();
            notifyIconAnalogy.Visible = preventExit = settings.MinimizedToTrayBar;
            var logger = AnalogyLogManager.Instance.Init();
            var factories = FactoriesManager.Instance.InitializeBuiltInFactories();
            await Task.WhenAll(logger, factories);
            string[] arguments = Environment.GetCommandLineArgs();
            disableOnlineDueToFileOpen = arguments.Length == 2;
            SetupEventHandlers();
            if (DesignMode) return;

            bbiFileCaching.Caption = "File caching is " + (settings.EnableFileCaching ? "on" : "off");
            ribbonControlMain.Minimized = UserSettingsManager.UserSettings.StartupRibbonMinimized;

            //CreateAnalogyBuiltinDataProviders
            FactoryContainer analogy = FactoriesManager.Instance.GetBuiltInFactoryContainer(AnalogyBuiltInFactory.AnalogyGuid);
            if (analogy.FactorySetting.Status != DataProviderFactoryStatus.Disabled)
            {
                CreateDataSource(analogy, 0);
            }
            await FactoriesManager.Instance.AddExternalDataSources();
            LoadStartupExtensions();
            CreateDataSources();

            //set Default page:
            Guid defaultPage = new Guid(UserSettingsManager.UserSettings.InitialSelectedDataProvider);
            if (Mapping.ContainsKey(defaultPage))
            {
                ribbonControlMain.SelectedPage = Mapping[defaultPage];
            }

            if (OnlineSources.Any())
                TmrAutoConnect.Start();

            Initialized = true;
            //todo: fine handler for file
            if (arguments.Length == 2)
            {
                string[] fileNames = { arguments[1] };
                await OpenOfflineFileWithSpecificDataProvider(fileNames);
            }
            else
                TmrAutoConnect.Enabled = true;

            if (UserSettingsManager.UserSettings.ShowChangeLogAtStartUp)
            {
                var change = new ChangeLog();
                change.ShowDialog(this);
            }
            if (UserSettingsManager.UserSettings.RememberLastOpenedDataProvider && Mapping.ContainsKey(UserSettingsManager.UserSettings.LastOpenedDataProvider))
            {
                ribbonControlMain.SelectPage(Mapping[UserSettingsManager.UserSettings.LastOpenedDataProvider]);
            }
            ribbonControlMain.SelectedPageChanging += ribbonControlMain_SelectedPageChanging;
            if (AnalogyLogManager.Instance.HasErrorMessages || AnalogyLogManager.Instance.HasWarningMessages)
                btnErrors.Visibility = BarItemVisibility.Always;
            var (_, release) = await UpdateManager.Instance.CheckVersion(false);
            if (release?.TagName != null)
            {
                bbtnCheckUpdates.Caption = "Latest Version: " + UpdateManager.Instance.LastVersionChecked.TagName;
            }
        }

        private void SetupEventHandlers()
        {
            ILogWindow GetLogWindows(Control mainControl)
            {
                while (true)
                {
                    if (mainControl is ILogWindow logWindow) return logWindow;
                    if (mainControl is SplitContainer split)
                    {
                        var log1 = GetLogWindows(split.Panel1);
                        if (log1 != null) return log1;
                        mainControl = split.Panel2;
                        continue;
                    }

                    for (int i = 0; i < mainControl.Controls.Count; i++)
                    {
                        var control = mainControl.Controls[i];
                        if (control is ILogWindow logWindow2) return logWindow2;
                        if (GetLogWindows(control) is ILogWindow log)
                            return log;
                    }

                    return null;
                }
            }

            bbtnReportIssueOrRequest.ItemClick += (_, __) =>
            {
                OpenLink("https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues");
            };

            bbtnCombineOpenLogs.ItemClick += (s, e) =>
            {
                var items = dockManager1.Panels.Select(p => (p.Text, GetLogWindows(p))).Where(l => l.Item2 != null)
                    .ToList();
                var openLogs = new OpenWindows(items);
                openLogs.Show(this);
            };
            bbtnCheckUpdates.ItemClick += (s, e) => OpenUpdateWindow();
            bbtnCompactMemory.ItemClick += (_, __) => FileProcessingManager.Instance.Reset();
            notifyIconAnalogy.DoubleClick += (_, __) =>
            {
                if (Visible)
                    Hide();
                else
                    Show();
            };
        }

        private void OpenOfflineLogs(RibbonPage ribbonPage, string[] filenames,
            IAnalogyOfflineDataProvider dataProvider,
            string title = null)
        {
            openedWindows++;
            UserControl offlineUC = new LocalLogFilesUC(dataProvider, filenames);
            var page = dockManager1.AddPanel(DockingStyle.Float);
            page.DockedAsTabbedDocument = true;
            page.Tag = ribbonPage;
            page.Controls.Add(offlineUC);
            offlineUC.Dock = DockStyle.Fill;
            page.Text = $"{offlineTitle} #{openedWindows}{(title == null ? "" : $" ({title})")}";
            dockManager1.ActivePanel = page;
        }
        private void LoadStartupExtensions()
        {
            if (settings.LoadExtensionsOnStartup && settings.StartupExtensions.Any())
            {
                var manager = ExtensionsManager.Instance;
                var extensions = manager.GetExtensions().ToList();
                foreach (Guid guid in settings.StartupExtensions)
                {
                    manager.RegisterExtension(extensions.SingleOrDefault(m => m.ID == guid));
                }

            }
        }
        private async Task OpenOfflineFileWithSpecificDataProvider(string[] files)
        {
            while (!Initialized)
                await Task.Delay(250);

            var supported = FactoriesManager.Instance.GetSupportedOfflineDataSources(files).ToList();
            if (supported.Count == 1)
            {
                var parser = supported.First();
                RibbonPage page = Mapping.ContainsKey(parser.FactoryID) ? Mapping[parser.FactoryID] : null;
                OpenOfflineLogs(page, files, parser.DataProvider);
            }
            else
            {

                if (supported.Any(d => d.DataProvider.ID == UserSettingsManager.UserSettings.LastOpenedDataProvider))
                {
                    var parser = supported.First(d =>
                        d.DataProvider.ID == UserSettingsManager.UserSettings.LastOpenedDataProvider);
                }
                supported = FactoriesManager.Instance.GetSupportedOfflineDataSources(files).Where(itm =>
                    !FactoriesManager.Instance.IsBuiltInFactory(itm.FactoryID)).ToList();
                if (supported.Count == 1)
                {
                    var parser = supported.First();
                    RibbonPage page = Mapping.ContainsKey(parser.FactoryID) ? Mapping[parser.FactoryID] : null;
                    OpenOfflineLogs(page, files, parser.DataProvider);
                }
                else
                {
                    //try  from file association:
                    var supportedAssociation = settings.GetFactoriesThatHasFileAssociation(files).ToList();
                    if (supportedAssociation.Count == 1)
                    {
                        var factory = supportedAssociation.First();
                        var parser = FactoriesManager.Instance
                            .GetSupportedOfflineDataSourcesFromFactory(factory.FactoryId, files).ToList();
                        RibbonPage page = (Mapping.ContainsKey(factory.FactoryId))
                            ? Mapping[factory.FactoryId]
                            : null;
                        if (parser.Count == 1)
                            OpenOfflineLogs(page, files, parser.First());
                        else
                        {
                            XtraMessageBox.Show(
                                $@"More than one data provider detected for this file for {factory.FactoryName}." +
                                Environment.NewLine +
                                "Please open it directly from the data provider menu", "Unable to open file",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        string msg = "Zero or more than one data provider detected for this file." + Environment.NewLine +
                                     "Please open it directly from the data provider menu or add default association under:" + Environment.NewLine +
                                     "Settings -> Data providers settings -> Default File Associations";
                        XtraMessageBox.Show(msg, "Unable to open file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private async void AnalogyMainForm_DragDrop(object sender, DragEventArgs e)
        {
            // Handle FileDrop data.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Assign the file names to a string array, in 
                // case the user has selected multiple files.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                await OpenOfflineFileWithSpecificDataProvider(files);
            }
        }

        private void AnalogyMainForm_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;


        private void OpenProcessForm()
        {
            var p = new ProcessNameAndID();
            p.Show(this);
        }

        private void bItemProcess_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenProcessForm();
        }

        private void bbiExtensions_ItemClick(object sender, ItemClickEventArgs e)
        {
            var ex = new ExtensionsForm();
            ex.ShowDialog(this);
        }

        private void AddRecentFiles(RibbonPage ribbonPage, BarSubItem bar, IAnalogyOfflineDataProvider offlineAnalogy,
            string title, List<string> files)
        {

            if (files.Any())
            {
                foreach (string file in files)
                {
                    if (!File.Exists(file)) continue;
                    BarButtonItem btn = new BarButtonItem();
                    btn.Caption = file;
                    btn.ItemClick += (s, be) =>
                    {
                        OpenOfflineLogs(ribbonPage, new[] { be.Item.Caption }, offlineAnalogy, title);
                    };
                    bar.AddItem(btn);
                }
            }
        }



        private void bbtnItemChangeLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            var change = new ChangeLog();
            change.ShowDialog(this);
        }

        private void bbtnItemHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            AnalogyAboutBox ab = new AnalogyAboutBox();
            ab.ShowDialog(this);
        }

        private void bbtnItemSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm();
            user.ShowDialog(this);
        }

        private void bbtnItemExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            preventExit = false;
            Close();
            Application.Exit();
        }

        private void bBtnClientServer_ItemClick(object sender, ItemClickEventArgs e)
        {

        }


        private void bBtnBookmarked_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenBookmarkLog();
        }

        private void OpenBookmarkLog()
        {
            openedWindows++;
            var bookmarkLog = new BookmarkLog();
            var page = dockManager1.AddPanel(DockingStyle.Float);
            page.DockedAsTabbedDocument = true;
            page.Controls.Add(bookmarkLog);
            bookmarkLog.Dock = DockStyle.Fill;
            page.Text = $"Analogy Bookmarked logs #{openedWindows}";
            dockManager1.ActivePanel = page;
        }

        private void bbtnSettingsApplication_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm(0);
            user.ShowDialog(this);
        }
        private void bBtnStatisticsFiltering_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm(1);
            user.ShowDialog(this);
        }

        private void bBtnPreDefinedQueries_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm(2);
            user.ShowDialog(this);
        }

        private void bBtnStatisticsLookAndFeel_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm(3);
            user.ShowDialog(this);
        }

        private void bBtnExtensionSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm(4);
            user.ShowDialog(this);
        }

        private void bBtnShortcuts_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm(5);
            user.ShowDialog(this);
        }

        private void bBtnMRUSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm(6);
            user.ShowDialog(this);
        }
        private void btnUserSettingsResourceUsage_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm(7);
            user.ShowDialog(this);
        }

        private void btnSettingsStartupDataSources_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm(8);
            user.ShowDialog(this);
        }

        private void bBtnStatisticsUserStatistics_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm(9);
            user.ShowDialog(this);
        }
        private void bBtnDataProviderSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsDataProvidersForm user = new UserSettingsDataProvidersForm();
            user.ShowDialog(this);
        }
        private void bBtnCompareLogs_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void CreateDataSources()
        {
            foreach (FactoryContainer factory in FactoriesManager.Instance.Factories
                .Where(factory => !FactoriesManager.Instance.IsBuiltInFactory(factory.Factory) &&
                                  factory.FactorySetting.Status != DataProviderFactoryStatus.Disabled))
            {
                CreateDataSource(factory, 3);
            }

        }

        private void CreateDataSource(FactoryContainer fc, int position)
        {
            if (fc.Factory.Title == null) return;

            RibbonPage ribbonPage = new RibbonPage(fc.Factory.Title);
            ribbonControlMain.Pages.Insert(position, ribbonPage);
            Mapping.Add(fc.Factory.FactoryId, ribbonPage);
            var ribbonPageImage = FactoriesManager.Instance.GetSmallImage(fc.Factory.FactoryId);
            if (ribbonPageImage != null)
            {
                ribbonPage.ImageOptions.Image = ribbonPageImage;
            }
            var dataSourceFactory = fc.DataProvidersFactories;
            foreach (var dataProvidersFactory in dataSourceFactory)
            {
                if (!string.IsNullOrEmpty(dataProvidersFactory.Title))
                {
                    CreateDataSourceRibbonGroup(dataProvidersFactory, ribbonPage);
                }
            }

            var actionFactories = fc.CustomActionsFactories;
            foreach (var actionFactory in actionFactories)
            {
                if (string.IsNullOrEmpty(actionFactory.Title)) continue;
                RibbonPageGroup groupActionSource = new RibbonPageGroup(actionFactory.Title);
                groupActionSource.AllowTextClipping = false;
                ribbonPage.Groups.Add(groupActionSource);
                if (actionFactory.Actions == null)
                {
                    AnalogyLogManager.Instance.LogCritical($"null actions for {actionFactory.Title}:{actionFactory.FactoryId}", $"{actionFactory.Title}{actionFactory.FactoryId}");
                    continue;
                }
                foreach (IAnalogyCustomAction action in actionFactory.Actions)
                {
                    BarButtonItem actionBtn = new BarButtonItem();
                    actionBtn.Caption = action.Title;
                    actionBtn.RibbonStyle = RibbonItemStyles.All;
                    groupActionSource.ItemLinks.Add(actionBtn);
                    actionBtn.ImageOptions.Image = Resources.PageSetup_32x32;
                    actionBtn.ImageOptions.LargeImage = Resources.PageSetup_32x32;
                    actionBtn.ItemClick += (sender, e) => { action.Action(); };
                }
            }

            AddFactorySettings(fc, ribbonPage);
            AddAbout(fc, ribbonPage);
        }

        private void AddAbout(FactoryContainer fc, RibbonPage ribbonPage)
        {
            RibbonPageGroup groupInfoSource = new RibbonPageGroup("About");
            groupInfoSource.Alignment = RibbonPageGroupAlignment.Far;
            BarButtonItem aboutBtn = new BarButtonItem();
            aboutBtn.Caption = "Data Source Information";
            aboutBtn.RibbonStyle = RibbonItemStyles.All;
            groupInfoSource.ItemLinks.Add(aboutBtn);
            aboutBtn.ImageOptions.Image = Resources.About_16x16;
            aboutBtn.ImageOptions.LargeImage = Resources.About_32x32;
            aboutBtn.ItemClick += (sender, e) => { new AboutDataSourceBox(fc.Factory).ShowDialog(this); };
            ribbonPage.Groups.Add(groupInfoSource);
        }
        private void AddFactorySettings(FactoryContainer fc, RibbonPage ribbonPage)
        {
            if (fc.FactorySetting.Status == DataProviderFactoryStatus.Disabled)
                return;
            RibbonPageGroup groupSettings = new RibbonPageGroup("Settings") { Alignment = RibbonPageGroupAlignment.Far };

            foreach (var providerSetting in fc.DataProvidersSettings)
            {
                BarButtonItem settingsBtn = new BarButtonItem
                {
                    Caption = providerSetting.Title,
                    RibbonStyle = RibbonItemStyles.All
                };
                groupSettings.ItemLinks.Add(settingsBtn);
                settingsBtn.ImageOptions.Image = providerSetting.SmallImage ?? Resources.Technology_16x16;
                settingsBtn.ImageOptions.LargeImage = providerSetting.LargeImage ?? Resources.Technology_32x32;
                XtraForm form = new XtraForm();
                form.Text = "Data Provider Settings: " + providerSetting.Title;
                form.Controls.Add(providerSetting.DataProviderSettings);
                providerSetting.DataProviderSettings.Dock = DockStyle.Fill;
                form.WindowState = FormWindowState.Maximized;
                form.Closing += async (s, e) => { await providerSetting.SaveSettingsAsync(); };
                settingsBtn.ItemClick += (sender, e) => { form.ShowDialog(this); };
            }
            ribbonPage.Groups.Add(groupSettings);
        }
        private void CreateDataSourceRibbonGroup(IAnalogyDataProvidersFactory dataSourceFactory, RibbonPage ribbonPage)
        {
            RibbonPageGroup ribbonPageGroup = new RibbonPageGroup(dataSourceFactory.Title);
            ribbonPageGroup.AllowTextClipping = false;
            ribbonPage.Groups.Add(ribbonPageGroup);

            AddRealTimeDataSource(ribbonPage, dataSourceFactory, ribbonPageGroup);
            AddSingleDataSources(ribbonPage, dataSourceFactory, ribbonPageGroup);
            AddOfflineDataSource(ribbonPage, dataSourceFactory, ribbonPageGroup);


            //add bookmark
            BarButtonItem bookmarkBtn = new BarButtonItem();
            bookmarkBtn.Caption = "Bookmarks";
            bookmarkBtn.RibbonStyle = RibbonItemStyles.All;
            ribbonPageGroup.ItemLinks.Add(bookmarkBtn);
            bookmarkBtn.ImageOptions.Image = Resources.RichEditBookmark_16x16;
            bookmarkBtn.ImageOptions.LargeImage = Resources.RichEditBookmark_32x32;
            bookmarkBtn.ItemClick += (sender, e) => { OpenBookmarkLog(); };
        }

        private void AddRealTimeDataSource(RibbonPage ribbonPage, IAnalogyDataProvidersFactory dataSourceFactory, RibbonPageGroup group)
        {
            var realTimes = dataSourceFactory.DataProviders.Where(f => f is IAnalogyRealTimeDataProvider)
                .Cast<IAnalogyRealTimeDataProvider>().ToList();
            if (realTimes.Count == 0) return;
            if (realTimes.Count == 1)
            {
                AddSingleRealTimeDataSource(ribbonPage, realTimes.First(), dataSourceFactory.Title, group);
            }
            else
            {
                BarSubItem realTimeMenu = new BarSubItem();
                group.ItemLinks.Add(realTimeMenu);

                realTimeMenu.ImageOptions.Image = Resources.Database_off;
                realTimeMenu.RibbonStyle = RibbonItemStyles.All;
                realTimeMenu.Caption = "Real Time Logs";


                foreach (var realTime in realTimes)
                {
                    //var imageLargeOffline = FactoriesManager.Instance.GetOnlineDisconnectedLargeImage(realTime.ID);
                    var imageSmallOffline = FactoriesManager.Instance.GetOnlineDisconnectedSmallImage(realTime.ID);
                    //var imageLargeOnline = FactoriesManager.Instance.GetOnlineConnectedLargeImage(realTime.ID);
                    var imageSmallOnline = FactoriesManager.Instance.GetOnlineConnectedLargeImage(realTime.ID);
                    BarButtonItem realTimeBtn = new BarButtonItem();
                    realTimeMenu.ItemLinks.Add(realTimeBtn);
                    realTimeBtn.ImageOptions.Image = imageSmallOffline ?? Resources.Database_off;
                    realTimeBtn.RibbonStyle = RibbonItemStyles.All;
                    realTimeBtn.Caption = "Real Time Logs" + (!string.IsNullOrEmpty(realTime.OptionalTitle)
                                              ? $" - {realTime.OptionalTitle}"
                                              : string.Empty);

                    async Task<bool> OpenRealTime()
                    {
                        realTimeBtn.Enabled = false;
                        bool canStartReceiving = false;
                        try
                        {
                            canStartReceiving = await realTime.CanStartReceiving();
                        }
                        catch (Exception e)
                        {
                            AnalogyLogManager.Instance.LogError("Error during call to canStartReceiving: " + e, nameof(MainForm));
                        }

                        if (canStartReceiving) //connected
                        {
                            openedWindows++;
                            realTimeBtn.ImageOptions.Image = imageSmallOnline ?? Resources.Database_on;
                            var onlineUC = new OnlineUCLogs(realTime);

                            void OnRealTimeOnMessageReady(object sender, AnalogyLogMessageArgs e) =>
                                onlineUC.AppendMessage(e.Message, Environment.MachineName);

                            void OnRealTimeOnOnManyMessagesReady(object sender, AnalogyLogMessagesArgs e) =>
                                onlineUC.AppendMessages(e.Messages, Environment.MachineName);

                            void OnRealTimeDisconnected(object sender, AnalogyDataSourceDisconnectedArgs e)
                            {
                                AnalogyLogMessage disconnected = new AnalogyLogMessage(
                                    $"Source {dataSourceFactory.Title} Disconnected. Reason: {e.DisconnectedReason}",
                                    AnalogyLogLevel.AnalogyInformation, AnalogyLogClass.General, dataSourceFactory.Title, "Analogy");
                                onlineUC.AppendMessage(disconnected, Environment.MachineName);
                                realTimeBtn.ImageOptions.Image = imageSmallOffline ?? Resources.Database_off;
                            }

                            var page = dockManager1.AddPanel(DockingStyle.Float);
                            page.DockedAsTabbedDocument = true;
                            page.Tag = ribbonPage;
                            page.Controls.Add(onlineUC);
                            ribbonControlMain.SelectedPage = ribbonPage;
                            onlineUC.Dock = DockStyle.Fill;
                            page.Text = $"{onlineTitle} #{openedWindows} ({dataSourceFactory.Title})";
                            dockManager1.ActivePanel = page;
                            realTime.OnMessageReady += OnRealTimeOnMessageReady;
                            realTime.OnManyMessagesReady += OnRealTimeOnOnManyMessagesReady;
                            realTime.OnDisconnected += OnRealTimeDisconnected;
                            realTime.StartReceiving();
                            onlineDataSourcesMapping.Add(page, realTime);
                            void OnXtcLogsOnControlRemoved(object sender, DockPanelEventArgs arg)
                            {
                                if (arg.Panel == page)
                                {
                                    try
                                    {
                                        onlineUC.Enable = false;
                                        realTime.StopReceiving();
                                        realTime.OnMessageReady -= OnRealTimeOnMessageReady;
                                        realTime.OnManyMessagesReady -= OnRealTimeOnOnManyMessagesReady;
                                        realTime.OnDisconnected -= OnRealTimeDisconnected;
                                        //page.Controls.Remove(onlineUC);
                                    }
                                    catch (Exception e)
                                    {
                                        AnalogyLogManager.Instance.LogError(
                                            "Error during call to Stop receiving: " + e, nameof(OnXtcLogsOnControlRemoved));
                                    }
                                    finally
                                    {
                                        dockManager1.ClosedPanel -= OnXtcLogsOnControlRemoved;
                                    }
                                }
                            }

                            dockManager1.ClosedPanel += OnXtcLogsOnControlRemoved;
                            realTimeBtn.Enabled = true;
                            return true;
                        }

                        realTimeBtn.Enabled = true;
                        return false;
                    }

                    realTimeBtn.ItemClick += async (s, be) => await OpenRealTime();
                    if (settings.AutoStartDataProviders.Contains(realTime.ID)
                        && !disableOnlineDueToFileOpen)
                    {
                        async Task<bool> AutoOpenRealTime()
                        {
                            while (!await OpenRealTime())
                            {
                                await Task.Delay(1000);
                            }

                            return true;
                        }

                        OnlineSources.Add(AutoOpenRealTime());

                    }

                }
            }
        }

        private void AddSingleDataSources(RibbonPage ribbonPage, IAnalogyDataProvidersFactory dataSourceFactory,
            RibbonPageGroup group)
        {
            var singles = dataSourceFactory.DataProviders.Where(f => f is IAnalogySingleDataProvider ||
                                                                      f is IAnalogySingleFileDataProvider).ToList();

            foreach (var single in singles)
            {
                BarButtonItem singleBtn = new BarButtonItem();
                group.ItemLinks.Add(singleBtn);
                var imageLarge = FactoriesManager.Instance.GetLargeImage(single.ID);
                var imageSmall = FactoriesManager.Instance.GetSmallImage(single.ID);

                singleBtn.ImageOptions.LargeImage = imageLarge ?? Resources.Single32x32;
                singleBtn.ImageOptions.Image = imageSmall ?? Resources.Single16x16;
                singleBtn.RibbonStyle = RibbonItemStyles.All;
                singleBtn.Caption = "Single provider" + (!string.IsNullOrEmpty(single.OptionalTitle)
                    ? $" - {single.OptionalTitle}"
                    : string.Empty);

                openedWindows++;
                singleBtn.ItemClick += (sender, e) =>
                {
                    CancellationTokenSource cts = new CancellationTokenSource();
                    LocalLogFilesUC offlineUC = new LocalLogFilesUC(single, cts);
                    var page = dockManager1.AddPanel(DockingStyle.Float);
                    page.DockedAsTabbedDocument = true;
                    page.Tag = ribbonPage;
                    page.Controls.Add(offlineUC);
                    offlineUC.Dock = DockStyle.Fill;
                    page.Text = $"{offlineTitle} #{openedWindows} ({single.OptionalTitle})";
                    dockManager1.ActivePanel = page;
                    if (single is IAnalogySingleFileDataProvider fileProvider)
                    {
                        fileProvider.Process(cts.Token, offlineUC.Handler);
                    }

                    if (single is IAnalogySingleDataProvider singleProvider)
                    {
                        singleProvider.Execute(cts.Token, offlineUC.Handler);
                    }

                };
            }
        }


        private void AddOfflineDataSource(RibbonPage ribbonPage, IAnalogyDataProvidersFactory factory, RibbonPageGroup group)
        {

            var offlineProviders = factory.DataProviders.Where(f => f is IAnalogyOfflineDataProvider)
                .Cast<IAnalogyOfflineDataProvider>().ToList();

            if (!offlineProviders.Any()) return;
            if (offlineProviders.Count == 1)
            {
                var offlineAnalogy = offlineProviders.First();
                string optionalText = !string.IsNullOrEmpty(offlineAnalogy.OptionalTitle)
                    ? " for" + offlineAnalogy.OptionalTitle
                    : string.Empty;
                RibbonPageGroup groupOfflineFileTools = new RibbonPageGroup($"Tools{optionalText}");
                groupOfflineFileTools.AllowTextClipping = false;
                ribbonPage.Groups.Add(groupOfflineFileTools);
                AddSingleOfflineDataSource(ribbonPage, offlineAnalogy, factory.Title, group, groupOfflineFileTools);
            }
            else
            {
                AddMultiplesOfflineDataSource(ribbonPage, offlineProviders, factory.Title, group);
            }

        }

        private void AddMultiplesOfflineDataSource(RibbonPage ribbonPage,
            List<IAnalogyOfflineDataProvider> offlineProviders, string factoryTitle, RibbonPageGroup group)
        {
            void OpenOffline(string titleOfDataSource, IAnalogyOfflineDataProvider dataProvider, string initialFolder,
                string[] files = null)
            {
                openedWindows++;
                UserControl offlineUC = new LocalLogFilesUC(dataProvider, files, initialFolder);
                var page = dockManager1.AddPanel(DockingStyle.Float);
                page.DockedAsTabbedDocument = true;
                page.Tag = ribbonPage;
                page.Controls.Add(offlineUC);
                offlineUC.Dock = DockStyle.Fill;
                page.Text = $"{offlineTitle} #{openedWindows} ({titleOfDataSource})";
                dockManager1.ActivePanel = page;
            }

            void OpenExternalDataSource(string titleOfDataSource, IAnalogyOfflineDataProvider analogy)
            {
                openedWindows++;
                var ClientServerUCLog = new ClientServerUCLog(analogy);
                var page = dockManager1.AddPanel(DockingStyle.Float);
                page.DockedAsTabbedDocument = true;
                page.Tag = ribbonPage;
                page.Controls.Add(ClientServerUCLog);
                ClientServerUCLog.Dock = DockStyle.Fill;
                page.Text = $"Client/Server logs #{openedWindows}. {titleOfDataSource}";
                dockManager1.ActivePanel = page;
            }

            void OpenFilePooling(string titleOfDataSource, IAnalogyOfflineDataProvider dataProvider,
                string initialFolder, string file)
            {

                openedWindows++;
                UserControl filepoolingUC = new FilePoolingUCLogs(dataProvider, file, initialFolder);
                var page = dockManager1.AddPanel(DockingStyle.Float);
                page.DockedAsTabbedDocument = true;

                void OnXtcLogsOnControlRemoved(object sender, DockPanelEventArgs arg)
                {
                    if (arg.Panel == page)
                    {
                        try
                        {
                            filepoolingUC.Dispose();
                        }
                        catch (Exception e)
                        {
                            AnalogyLogManager.Instance.LogError("Error during dispose: " + e, nameof(OnXtcLogsOnControlRemoved));
                        }
                        finally
                        {
                            dockManager1.ClosedPanel -= OnXtcLogsOnControlRemoved;
                        }
                    }
                }

                page.Tag = ribbonPage;
                page.Controls.Add(filepoolingUC);
                filepoolingUC.Dock = DockStyle.Fill;
                page.Text = $"{filePoolingTitle} #{filePooling} ({titleOfDataSource})";
                dockManager1.ActivePanel = page;


                dockManager1.ClosedPanel += OnXtcLogsOnControlRemoved;
            }


            //recent bar
            BarSubItem recentBar = new BarSubItem();
            recentBar.Caption = "Recent Files";
            recentBar.ImageOptions.Image = Resources.RecentlyUse_16x16;
            recentBar.ImageOptions.LargeImage = Resources.RecentlyUse_32x32;
            recentBar.RibbonStyle = RibbonItemStyles.All;

            //local folder
            if (offlineProviders.Any(i => !string.IsNullOrEmpty(i.InitialFolderFullPath) &&
                                          Directory.Exists(i.InitialFolderFullPath)))
            {
                BarSubItem folderBar = new BarSubItem();
                folderBar.Caption = "Open Folder";
                folderBar.ImageOptions.Image = Resources.Open2_32x32;
                folderBar.ImageOptions.LargeImage = Resources.Open2_32x32;
                folderBar.RibbonStyle = RibbonItemStyles.All;
                group.ItemLinks.Add(folderBar);

                foreach (var dataProvider in offlineProviders)
                {

                    //add local folder button:
                    if (!string.IsNullOrEmpty(dataProvider.InitialFolderFullPath) &&
                        Directory.Exists(dataProvider.InitialFolderFullPath))
                    {
                        BarButtonItem btn = new BarButtonItem { Caption = dataProvider.InitialFolderFullPath };
                        btn.ItemClick += (s, be) =>
                        {
                            OpenOffline(dataProvider.OptionalTitle, dataProvider,
                                dataProvider.InitialFolderFullPath);
                        };

                        folderBar.AddItem(btn);
                    }
                }
            }

            //add recent folders
            //recent bar
            BarSubItem recentFolders = new BarSubItem { Caption = "Recent Folders" };
            recentFolders.ImageOptions.Image = Resources.LoadFrom_16x16;
            recentFolders.ImageOptions.LargeImage = Resources.LoadFrom_32x32;
            recentFolders.RibbonStyle = RibbonItemStyles.All;
            group.ItemLinks.Add(recentFolders);
            foreach (var dataProvider in offlineProviders)
            {
                BarSubItem btnFolder = new BarSubItem { Caption = dataProvider.OptionalTitle };
                recentFolders.AddItem(btnFolder);
                foreach (var path in settings.GetRecentFolders(dataProvider.ID))
                {  //add local folder button:
                    if (!string.IsNullOrEmpty(path.Path) && Directory.Exists(path.Path))
                    {
                        BarButtonItem btn = new BarButtonItem { Caption = path.Path };
                        btn.ItemClick += (s, be) =>
                        {
                            OpenOffline(dataProvider.OptionalTitle, dataProvider, path.Path);
                        };

                        btnFolder.AddItem(btn);
                    }
                }
            }


            //add Files open buttons
            if (offlineProviders.Any(i => !string.IsNullOrEmpty(i.FileOpenDialogFilters)))
            {
                //add Open files entry
                BarSubItem openFiles = new BarSubItem();
                openFiles.Caption = "Open Files";
                group.ItemLinks.Add(openFiles);
                openFiles.ImageOptions.Image = Resources.Article_16x16;
                openFiles.ImageOptions.LargeImage = Resources.Article_32x32;
                openFiles.RibbonStyle = RibbonItemStyles.All;

                foreach (var dataProvider in offlineProviders)
                {

                    if (!string.IsNullOrEmpty(dataProvider.FileOpenDialogFilters))
                    {
                        BarButtonItem btnOpenFile = new BarButtonItem { Caption = $"{factoryTitle} ({dataProvider.OptionalTitle})" };
                        btnOpenFile.ItemClick += (sender, e) =>
                        {
                            OpenFileDialog openFileDialog1 = new OpenFileDialog
                            {
                                Filter = dataProvider.FileOpenDialogFilters,
                                Title = @"Open Files",
                                Multiselect = true
                            };
                            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                OpenOffline(dataProvider.OptionalTitle, dataProvider,
                                    dataProvider.InitialFolderFullPath, openFileDialog1.FileNames);
                                AddRecentFiles(ribbonPage, recentBar, dataProvider, dataProvider.OptionalTitle,
                                    openFileDialog1.FileNames.ToList());
                            }
                        };
                        openFiles.AddItem(btnOpenFile);
                    }
                }



                //add Open Pooled file entry
                BarSubItem filePoolingBtn = new BarSubItem();
                filePoolingBtn.Caption = "File Pooling";
                group.ItemLinks.Add(filePoolingBtn);
                filePoolingBtn.ImageOptions.Image = Resources.FilePooling_16x16;
                filePoolingBtn.ImageOptions.LargeImage = Resources.FilePooling_32x32;
                filePoolingBtn.RibbonStyle = RibbonItemStyles.All;

                foreach (var dataProvider in offlineProviders)
                {


                    BarButtonItem btnOpenFile = new BarButtonItem { Caption = $"{factoryTitle} ({dataProvider.OptionalTitle})" };
                    btnOpenFile.ItemClick += (sender, e) =>
                    {
                        OpenFileDialog openFileDialog1 = new OpenFileDialog
                        {
                            Filter = dataProvider.FileOpenDialogFilters,
                            Title = @"Open File for pooling",
                            Multiselect = false
                        };
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            OpenFilePooling(dataProvider.OptionalTitle, dataProvider,
                                dataProvider.InitialFolderFullPath, openFileDialog1.FileName);
                            AddRecentFiles(ribbonPage, recentBar, dataProvider, dataProvider.OptionalTitle,
                                new List<string> { openFileDialog1.FileName });
                        }
                    };
                    filePoolingBtn.AddItem(btnOpenFile);
                }
            }


            //add recent
            group.ItemLinks.Add(recentBar);
            foreach (var dataProvider in offlineProviders)
            {
                var recents = UserSettingsManager.UserSettings.GetRecentFiles(dataProvider.ID)
                    .Select(itm => itm.FileName).ToList();
                AddRecentFiles(ribbonPage, recentBar, dataProvider, dataProvider.OptionalTitle, recents);
            }

            BarSubItem externalSources = new BarSubItem();
            externalSources.Caption = "Known Locations";
            externalSources.RibbonStyle = RibbonItemStyles.All;
            group.ItemLinks.Add(externalSources);
            externalSources.ImageOptions.Image = Resources.ServerMode_16x16;
            externalSources.ImageOptions.LargeImage = Resources.ServerMode_32x32;
            //add client/server  button:
            foreach (var dataProvider in offlineProviders)
            {
                BarButtonItem btnOpenLocation = new BarButtonItem { Caption = $"{factoryTitle} ({dataProvider.OptionalTitle})" };
                btnOpenLocation.ItemClick += (sender, e) =>
                {
                    OpenExternalDataSource(dataProvider.OptionalTitle, dataProvider);
                };
                externalSources.AddItem(btnOpenLocation);
            }


            //add tools

            RibbonPageGroup groupOfflineFileTools = new RibbonPageGroup($"Tools for {factoryTitle}");
            groupOfflineFileTools.AllowTextClipping = false;
            ribbonPage.Groups.Add(groupOfflineFileTools);


            BarSubItem searchFiles = new BarSubItem();
            searchFiles.Caption = "Search in Files";
            groupOfflineFileTools.ItemLinks.Add(searchFiles);
            searchFiles.ImageOptions.Image = Resources.Lookup_Reference_32x32;
            searchFiles.ImageOptions.LargeImage = Resources.Lookup_Reference_32x32;
            searchFiles.RibbonStyle = RibbonItemStyles.All;

            foreach (var dataProvider in offlineProviders)
            {
                BarButtonItem btnSearchin = new BarButtonItem { Caption = $" search in: {factoryTitle} ({dataProvider.OptionalTitle})" };
                btnSearchin.ItemClick += (sender, e) =>
                {
                    var search = new SearchForm(dataProvider);
                    search.Show(this);
                };
                searchFiles.AddItem(btnSearchin);
            }


            BarSubItem combineFiles = new BarSubItem();
            combineFiles.Caption = "Combine Files";
            groupOfflineFileTools.ItemLinks.Add(combineFiles);
            combineFiles.ImageOptions.Image = Resources.Sutotal_32x32;
            combineFiles.ImageOptions.LargeImage = Resources.Sutotal_32x32;
            combineFiles.RibbonStyle = RibbonItemStyles.All;

            foreach (var dataProvider in offlineProviders)
            {
                BarButtonItem btnCombine = new BarButtonItem { Caption = $"Combine files for: {factoryTitle} ({dataProvider.OptionalTitle})" };
                btnCombine.ItemClick += (sender, e) =>
                {
                    var combined = new FormCombineFiles(dataProvider);
                    combined.Show(this);
                };
                combineFiles.AddItem(btnCombine);
            }



            BarSubItem compareFiles = new BarSubItem();
            compareFiles.Caption = "Compare Files";
            groupOfflineFileTools.ItemLinks.Add(compareFiles);
            compareFiles.ImageOptions.Image = Resources.TwoColumns;
            compareFiles.ImageOptions.LargeImage = Resources.TwoColumns;
            compareFiles.RibbonStyle = RibbonItemStyles.All;

            foreach (var dataProvider in offlineProviders)
            {
                BarButtonItem btnCombine = new BarButtonItem { Caption = $"Compare files for: {factoryTitle} ({dataProvider.OptionalTitle})" };
                btnCombine.ItemClick += (sender, e) =>
                {
                    FileComparerForm compare = new FileComparerForm(dataProvider);
                    compare.ShowDialog(this);
                };
                compareFiles.AddItem(btnCombine);
            }
        }

        private void AddSingleOfflineDataSource(RibbonPage ribbonPage, IAnalogyOfflineDataProvider offlineAnalogy,
           string title, RibbonPageGroup group, RibbonPageGroup groupOfflineFileTools)
        {

            void OpenOffline(string titleOfDataSource, string initialFolder, string[] files = null)
            {
                openedWindows++;
                UserControl offlineUC = new LocalLogFilesUC(offlineAnalogy, files, initialFolder);
                var page = dockManager1.AddPanel(DockingStyle.Float);
                page.DockedAsTabbedDocument = true;
                page.Tag = ribbonPage;
                page.Controls.Add(offlineUC);
                offlineUC.Dock = DockStyle.Fill;
                page.Text = $"{offlineTitle} #{openedWindows} ({titleOfDataSource})";
                dockManager1.ActivePanel = page;
            }

            void OpenExternalDataSource(string titleOfDataSource, IAnalogyOfflineDataProvider analogy)
            {
                openedWindows++;
                var ClientServerUCLog = new ClientServerUCLog(analogy);
                var page = dockManager1.AddPanel(DockingStyle.Float);
                page.DockedAsTabbedDocument = true;
                page.Tag = ribbonPage;
                page.Controls.Add(ClientServerUCLog);
                ClientServerUCLog.Dock = DockStyle.Fill;
                page.Text = $"Client/Server logs #{openedWindows}. {titleOfDataSource}";
                dockManager1.ActivePanel = page;


            }

            void OpenFilePooling(string titleOfDataSource, string initialFolder, string file)
            {

                openedWindows++;
                UserControl filepoolingUC = new FilePoolingUCLogs(offlineAnalogy, file, initialFolder);
                var page = dockManager1.AddPanel(DockingStyle.Float);
                page.DockedAsTabbedDocument = true;

                void OnXtcLogsOnControlRemoved(object sender, DockPanelEventArgs arg)
                {
                    if (arg.Panel == page)
                    {
                        try
                        {
                            filepoolingUC.Dispose();
                        }
                        catch (Exception e)
                        {
                            AnalogyLogManager.Instance.LogError("Error during dispose: " + e, nameof(OnXtcLogsOnControlRemoved));
                        }
                        finally
                        {
                            dockManager1.ClosedPanel -= OnXtcLogsOnControlRemoved;
                        }
                    }
                }

                page.Tag = ribbonPage;
                page.Controls.Add(filepoolingUC);
                filepoolingUC.Dock = DockStyle.Fill;
                page.Text = $"{filePoolingTitle} #{filePooling} ({titleOfDataSource})";
                dockManager1.ActivePanel = page;
                dockManager1.ClosedPanel += OnXtcLogsOnControlRemoved;
            }

            //add local folder button:
            if (!string.IsNullOrEmpty(offlineAnalogy.InitialFolderFullPath) &&
                Directory.Exists(offlineAnalogy.InitialFolderFullPath))
            {
                BarButtonItem localfolder = new BarButtonItem();
                localfolder.Caption = "Open Folder";
                localfolder.RibbonStyle = RibbonItemStyles.All;
                group.ItemLinks.Add(localfolder);
                localfolder.ImageOptions.Image = Resources.Open2_32x32;
                localfolder.ItemClick += (sender, e) => { OpenOffline(title, offlineAnalogy.InitialFolderFullPath); };
            }

            //recent folder
            //recent bar
            BarSubItem recentFolders = new BarSubItem { Caption = "Recent Folders" };
            recentFolders.ImageOptions.Image = Resources.LoadFrom_16x16;
            recentFolders.ImageOptions.LargeImage = Resources.LoadFrom_32x32;
            recentFolders.RibbonStyle = RibbonItemStyles.All;
            group.ItemLinks.Add(recentFolders);
            foreach (var path in settings.GetRecentFolders(offlineAnalogy.ID))
            {  //add local folder button:
                if (!string.IsNullOrEmpty(path.Path) && Directory.Exists(path.Path))
                {
                    BarButtonItem btn = new BarButtonItem { Caption = path.Path };
                    btn.ItemClick += (s, be) =>
                    {
                        OpenOffline(offlineAnalogy.OptionalTitle, path.Path);
                    };

                    recentFolders.AddItem(btn);
                }
            }






            //recent bar
            BarSubItem recentBar = new BarSubItem();
            recentBar.Caption = "Recent Files";
            recentBar.ImageOptions.Image = Resources.RecentlyUse_16x16;
            recentBar.ImageOptions.LargeImage = Resources.RecentlyUse_32x32;
            recentBar.RibbonStyle = RibbonItemStyles.Large | RibbonItemStyles.SmallWithText |
                                    RibbonItemStyles.SmallWithoutText;
            //add Files open buttons
            if (!string.IsNullOrEmpty(offlineAnalogy.FileOpenDialogFilters))
            {
                //add Open files entry
                BarButtonItem openFiles = new BarButtonItem();
                openFiles.Caption = "Open Files";
                group.ItemLinks.Add(openFiles);
                openFiles.ImageOptions.Image = Resources.Article_16x16;
                openFiles.ImageOptions.LargeImage = Resources.Article_32x32;
                openFiles.RibbonStyle = RibbonItemStyles.All;
                openFiles.ItemClick += (sender, e) =>
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog
                    {
                        Filter = offlineAnalogy.FileOpenDialogFilters,
                        Title = @"Open Files",
                        Multiselect = true
                    };
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        OpenOffline(title, offlineAnalogy.InitialFolderFullPath, openFileDialog1.FileNames);
                        AddRecentFiles(ribbonPage, recentBar, offlineAnalogy, title,
                            openFileDialog1.FileNames.ToList());
                    }
                };

                //add Open Pooled file entry
                BarButtonItem filePoolingBtn = new BarButtonItem();
                filePoolingBtn.Caption = "File Pooling";
                group.ItemLinks.Add(filePoolingBtn);
                filePoolingBtn.ImageOptions.Image = Resources.FilePooling_16x16;
                filePoolingBtn.ImageOptions.LargeImage = Resources.FilePooling_32x32;
                filePoolingBtn.RibbonStyle = RibbonItemStyles.All;
                filePoolingBtn.ItemClick += (sender, e) =>
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog
                    {
                        Filter = offlineAnalogy.FileOpenDialogFilters,
                        Title = @"Open File for pooling",
                        Multiselect = false
                    };
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        OpenFilePooling(title, offlineAnalogy.InitialFolderFullPath, openFileDialog1.FileName);
                        AddRecentFiles(ribbonPage, recentBar, offlineAnalogy, title,
                            new List<string> { openFileDialog1.FileName });
                    }

                };
            }

            //add recent
            group.ItemLinks.Add(recentBar);
            var recents = UserSettingsManager.UserSettings.GetRecentFiles(offlineAnalogy.ID)
                .Select(itm => itm.FileName).ToList();
            AddRecentFiles(ribbonPage, recentBar, offlineAnalogy, title, recents);

            //add client/server  button:
            BarButtonItem externalSources = new BarButtonItem();
            externalSources.Caption = "Known Locations";
            externalSources.RibbonStyle = RibbonItemStyles.All;
            group.ItemLinks.Add(externalSources);
            externalSources.ImageOptions.Image = Resources.ServerMode_16x16;
            externalSources.ImageOptions.LargeImage = Resources.ServerMode_32x32;
            externalSources.ItemClick += (sender, e) => { OpenExternalDataSource(title, offlineAnalogy); };


            //add tools
            BarButtonItem searchFiles = new BarButtonItem();
            searchFiles.Caption = "Search in Files";
            groupOfflineFileTools.ItemLinks.Add(searchFiles);
            searchFiles.ImageOptions.Image = Resources.Lookup_Reference_32x32;
            searchFiles.ImageOptions.LargeImage = Resources.Lookup_Reference_32x32;
            searchFiles.RibbonStyle = RibbonItemStyles.All;
            searchFiles.ItemClick += (sender, e) =>
            {
                var search = new SearchForm(offlineAnalogy);
                search.Show(this);
            };

            BarButtonItem combineFiles = new BarButtonItem();
            combineFiles.Caption = "Combine Files";
            groupOfflineFileTools.ItemLinks.Add(combineFiles);
            combineFiles.ImageOptions.Image = Resources.Sutotal_32x32;
            combineFiles.ImageOptions.LargeImage = Resources.Sutotal_32x32;
            combineFiles.RibbonStyle = RibbonItemStyles.All;
            combineFiles.ItemClick += (sender, e) =>
            {
                var combined = new FormCombineFiles(offlineAnalogy);
                combined.Show(this);
            };


            BarButtonItem compareFiles = new BarButtonItem();
            compareFiles.Caption = "Compare Files";
            groupOfflineFileTools.ItemLinks.Add(compareFiles);
            compareFiles.ImageOptions.Image = Resources.TwoColumns;
            compareFiles.ImageOptions.LargeImage = Resources.TwoColumns;
            compareFiles.RibbonStyle = RibbonItemStyles.All;
            compareFiles.ItemClick += (sender, e) =>
            {
                FileComparerForm compare = new FileComparerForm(offlineAnalogy);
                compare.ShowDialog(this);
            };
        }


        private void AddSingleRealTimeDataSource(RibbonPage ribbonPage, IAnalogyRealTimeDataProvider realTime, string title,
         RibbonPageGroup group)
        {
            BarButtonItem realTimeBtn = new BarButtonItem();
            group.ItemLinks.Add(realTimeBtn);
            var imageLargeOffline = FactoriesManager.Instance.GetOnlineDisconnectedLargeImage(realTime.ID);
            var imageSmallOffline = FactoriesManager.Instance.GetOnlineDisconnectedSmallImage(realTime.ID);
            var imageLargeOnline = FactoriesManager.Instance.GetOnlineConnectedLargeImage(realTime.ID);
            var imageSmallOnline = FactoriesManager.Instance.GetOnlineConnectedSmallImage(realTime.ID);
            realTimeBtn.ImageOptions.LargeImage = imageLargeOffline ?? Resources.Database_off;
            realTimeBtn.ImageOptions.Image = imageSmallOffline ?? Resources.Database_off;
            realTimeBtn.RibbonStyle = RibbonItemStyles.All;
            realTimeBtn.Caption = "Real Time Logs" + (!string.IsNullOrEmpty(realTime.OptionalTitle) ? $" - {realTime.OptionalTitle}" : string.Empty);

            async Task<bool> OpenRealTime()
            {
                realTimeBtn.Enabled = false;
                bool canStartReceiving = false;
                try
                {
                    canStartReceiving = await realTime.CanStartReceiving();
                }
                catch (Exception e)
                {
                    AnalogyLogManager.Instance.LogError("Error during call to canStartReceiving: " + e, nameof(AddSingleRealTimeDataSource));
                }

                if (canStartReceiving) //connected
                {
                    openedWindows++;
                    realTimeBtn.ImageOptions.Image = imageSmallOnline ?? Resources.Database_on;
                    realTimeBtn.ImageOptions.LargeImage = imageLargeOnline ?? Resources.Database_on;
                    var onlineUC = new OnlineUCLogs(realTime);

                    void OnRealTimeOnMessageReady(object sender, AnalogyLogMessageArgs e) =>
                        onlineUC.AppendMessage(e.Message, Environment.MachineName);

                    void OnRealTimeOnOnManyMessagesReady(object sender, AnalogyLogMessagesArgs e) =>
                        onlineUC.AppendMessages(e.Messages, Environment.MachineName);

                    void OnRealTimeDisconnected(object sender, AnalogyDataSourceDisconnectedArgs e)
                    {
                        AnalogyLogMessage disconnected = new AnalogyLogMessage(
                            $"Source {title} Disconnected. Reason: {e.DisconnectedReason}",
                            AnalogyLogLevel.AnalogyInformation, AnalogyLogClass.General, title, "Analogy");
                        onlineUC.AppendMessage(disconnected, Environment.MachineName);
                        realTimeBtn.ImageOptions.Image = imageSmallOffline ?? Resources.Database_off;
                        realTimeBtn.ImageOptions.Image = imageLargeOffline ?? Resources.Database_off;
                    }

                    var page = dockManager1.AddPanel(DockingStyle.Float);
                    page.DockedAsTabbedDocument = true;
                    page.Tag = ribbonPage;
                    page.Controls.Add(onlineUC);
                    ribbonControlMain.SelectedPage = ribbonPage;
                    onlineUC.Dock = DockStyle.Fill;
                    page.Text = $"{onlineTitle} #{openedWindows} ({title})";
                    realTime.OnMessageReady += OnRealTimeOnMessageReady;
                    realTime.OnManyMessagesReady += OnRealTimeOnOnManyMessagesReady;
                    realTime.OnDisconnected += OnRealTimeDisconnected;
                    realTime.StartReceiving();
                    onlineDataSourcesMapping.Add(page, realTime);
                    dockManager1.ActivePanel = page;

                    void OnXtcLogsOnControlRemoved(object sender, DockPanelEventArgs arg)
                    {
                        if (arg.Panel == page)
                        {
                            try
                            {
                                onlineUC.Enable = false;
                                realTime.StopReceiving();
                                realTime.OnMessageReady -= OnRealTimeOnMessageReady;
                                realTime.OnManyMessagesReady -= OnRealTimeOnOnManyMessagesReady;
                                realTime.OnDisconnected -= OnRealTimeDisconnected;
                                //page.Controls.Remove(onlineUC);
                            }
                            catch (Exception e)
                            {
                                AnalogyLogManager.Instance.LogError("Error during call to Stop receiving: " + e, nameof(AddSingleRealTimeDataSource));
                            }
                            finally
                            {
                                dockManager1.ClosedPanel -= OnXtcLogsOnControlRemoved;
                            }
                        }
                    }

                    dockManager1.ClosedPanel += OnXtcLogsOnControlRemoved;
                    realTimeBtn.Enabled = true;
                    return true;
                }

                realTimeBtn.Enabled = true;
                return false;
            }

            realTimeBtn.ItemClick += async (s, be) => await OpenRealTime();
            if (settings.AutoStartDataProviders.Contains(realTime.ID)
            && !disableOnlineDueToFileOpen)
            {
                async Task<bool> AutoOpenRealTime()
                {
                    while (!await OpenRealTime())
                    {
                        await Task.Delay(1000);
                    }

                    return true;
                }

                OnlineSources.Add(AutoOpenRealTime());

            }

        }
        private void xtcLogs_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (e.Page?.Tag == null)
                return;
            ribbonControlMain.SelectedPage = (RibbonPage)e.Page.Tag;
        }

        private async void TmrAutoConnect_Tick(object sender, EventArgs e)
        {
            TmrAutoConnect.Enabled = false;
            if (!OnlineSources.Any())
                return;
            var onlines = OnlineSources.ToList();
            foreach (var onlineSource in onlines)
            {
                if (await onlineSource)
                {
                    OnlineSources.Remove(onlineSource);
                }
            }

            TmrAutoConnect.Enabled = true;
        }


        private void TmrStatusUpdates_Tick(object sender, EventArgs e)
        {
            tmrStatusUpdates.Stop();
            bsiMemoryUsage.Caption = Process.GetCurrentProcess().PrivateMemorySize64 / 1024 / 1024 + " [MB]";
            if (settings.IdleMode)
            {
                bsiIdleMessage.Caption =
                    $"Idle mode is on. User idle: {Utils.IdleTime():hh\\:mm\\:ss}. Missed messages: {PagingManager.TotalMissedMessages}";
            }
            else
                bsiIdleMessage.Caption = "Idle mode is off";

            tmrStatusUpdates.Start();
        }


        private void bbiFileCaching_ItemClick(object sender, ItemClickEventArgs e)
        {
            settings.EnableFileCaching = !settings.EnableFileCaching;
            bbiFileCaching.Caption = "File caching is " + (settings.EnableFileCaching ? "on" : "off");
        }



        private void bBtnItemExportSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Json Settings|*.json";
                saveFileDialog.Title = "Export settings";
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        string data = JsonConvert.SerializeObject(settings);
                        File.WriteAllText(saveFileDialog.FileName, data);
                        XtraMessageBox.Show("settings saved", "Analogy",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exception)
                    {
                        AnalogyLogManager.Instance.LogError("Error during export settings: " + e, nameof(bBtnExtensionSettings_ItemClick));
                        XtraMessageBox.Show("Error exporting settings: " + exception.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void bBtnItemImportSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Json Settings|*.json";
                openFileDialog1.Title = @"Import Settings";
                openFileDialog1.Multiselect = false;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (XtraMessageBox.Show("Are you sure you want to override existing settings?", "Analogy",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string data = File.ReadAllText(openFileDialog1.FileName);
                        UserSettingsManager newSettings = JsonConvert.DeserializeObject<UserSettingsManager>(data);

                        UserSettingsManager.UserSettings = newSettings;
                    }
                }

            }
        }

        private void btnErrors_ItemClick(object sender, ItemClickEventArgs e)
        {
            AnalogyLogManager.Instance.Show(this);
        }

        private void ribbonControlMain_SelectedPageChanging(object sender, RibbonPageChangingEventArgs e)
        {
            if (Mapping.ContainsValue(e.Page))
            {
                Guid id = Mapping.Single(kv => kv.Value == e.Page).Key;
                UserSettingsManager.UserSettings.LastOpenedDataProvider = id;
            }
        }

        private void bbtnDebugLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            AnalogyLogManager.Instance.Show(this);
        }

        private void bbtnStar_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenLink("https://github.com/Analogy-LogViewer/Analogy.LogViewer");
        }
        private void OpenLink(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception exception)
            {
                AnalogyLogger.Instance.LogException(exception, "", $"Error: {exception.Message}");
            }
        }
        private void bbtnUpdates_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenUpdateWindow();
        }

        private void OpenUpdateWindow()
        {
            UpdateForm update = new UpdateForm();
            update.Show(this);
        }


    }
}

