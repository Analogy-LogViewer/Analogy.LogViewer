using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.Common.Managers;
using Analogy.CommonControls.Managers;
using Analogy.CommonControls.Plotting;
using Analogy.DataProviders;
using Analogy.DataTypes;
using Analogy.Forms;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.Factories;
using Analogy.Managers;
using Analogy.Properties;
using Analogy.UserControls;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy
{
    public partial class FluentDesignMainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private IFactoriesManager FactoriesManager { get; }
        private IExtensionsManager ExtensionsManager { get; }
        private IAnalogyUserSettings Settings => ServicesProvider.Instance.GetService<IAnalogyUserSettings>();

        #region pinvoke

        const int WM_COPYDATA = 0x004A;

        [DllImport("user32", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(IntPtr Hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        #endregion

        private string filePoolingTitle = "File Pooling";
        private string offlineTitle = "Offline log";
        private string onlineTitle = "Online log";
        private Guid activeProvider;
        private int openedWindows;
        private int filePooling;
        private bool disableOnlineDueToFileOpen;
        private bool PreventExit { get; set; }
        private bool Initialized { get; set; }
        private BookmarkPersistManager BookmarkPersistManager { get; }
        private UpdateManager UpdateManager { get; }
        private FileProcessingManager FileProcessingManager { get; }
        private List<Task<bool>> OnlineSources { get; } = new List<Task<bool>>();
        private NotificationManager NotificationManager { get; }
        private IAnalogyFoldersAccess FoldersAccess { get; }
        private AnalogyOnDemandPlottingManager PlottingManager { get; }

        public FluentDesignMainForm(IFactoriesManager factoriesManager, IExtensionsManager extensionsManager,
            BookmarkPersistManager bookmarkPersistManager, UpdateManager updateManager, FileProcessingManager fileProcessingManager,
            NotificationManager notificationManager, IAnalogyFoldersAccess foldersAccess, AnalogyOnDemandPlottingManager plottingManager)
        {
            FactoriesManager = factoriesManager;
            ExtensionsManager = extensionsManager;
            BookmarkPersistManager = bookmarkPersistManager;
            UpdateManager = updateManager;
            FileProcessingManager = fileProcessingManager;
            NotificationManager = notificationManager;
            FoldersAccess = foldersAccess;
            InitializeComponent();
            EnableAcrylicAccent = false;
            PlottingManager = plottingManager;
        }

        private async void FluentDesignMainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            RegisterForNotifications();
            SetWindowSizeAndPosition();
            string framework = UpdateManager.CurrentFrameworkAttribute.FrameworkName;
            Text = $"Analogy Log Viewer {UpdateManager.CurrentVersion} ({framework})";
            Icon = Settings.GetIcon();
            notifyIconAnalogy.Visible = PreventExit = Settings.MinimizedToTrayBar;
            string[] arguments = Environment.GetCommandLineArgs();
            disableOnlineDueToFileOpen = arguments.Length == 2;
            bbiFileCaching.Caption = "File caching is " + (Settings.EnableFileCaching ? "on" : "off");
            bbiFileCaching.Appearance.BackColor = Settings.EnableFileCaching ? Color.LightGreen : Color.Empty;
            SetupEventHandlers();
            await FactoriesManager.InitializeBuiltInFactories();

            //CreateAnalogyBuiltinDataProviders
            FactoryContainer analogy =
                FactoriesManager.GetBuiltInFactoryContainer(AnalogyBuiltInFactory.AnalogyGuid);
            CreateDataSourceMenuItem(analogy);
            await FactoriesManager.AddExternalDataSources();
            PopulateGlobalTools();
            LoadStartupExtensions();
            RegisterForOnDemandPlots();

            //Create all other DataSources
            foreach (FactoryContainer fc in FactoriesManager.Factories
                         .Where(factory => !FactoriesManager.IsBuiltInFactory(factory.Factory) &&
                                           factory.FactorySetting.Status != DataProviderFactoryStatus.Disabled

                                            //&& factory.DataProvidersFactories.Any(d => d.DataProviders.Any())
                                            ))
            {
                CreateDataSourceMenuItem(fc);
            }

            if (OnlineSources.Any())
            {
                TmrAutoConnect.Start();
            }

            Initialized = true;
            if (arguments.Length == 2)
            {
                string[] fileNames = { arguments[1] };
                await OpenOfflineFileWithSpecificDataProvider(fileNames);
            }
            else
            {
                TmrAutoConnect.Enabled = true;
            }

            if (Settings.ShowChangeLogAtStartUp)
            {
                var change = new ChangeLog();
                change.ShowDialog(this);
            }

            var current = (Settings.RememberLastOpenedDataProvider && Settings.LastOpenedDataProvider != default)
                ? Settings.LastOpenedDataProvider
                : Settings.InitialSelectedDataProvider;
            LoadFactoryInAccordion(current);

            if (AnalogyLogManager.Instance.HasErrorMessages)
            {
                bbtnErrors.Visibility = BarItemVisibility.Always;
            }

            if (!AnalogyNonPersistSettings.Instance.UpdateAreDisabled)
            {
                var (_, release) = await UpdateManager.CheckVersion(false);
                if (release?.TagName != null && UpdateManager.NewestVersion != null)
                {
                    UpdateUpdateButton();
                }
            }
            else
            {
                AnalogyLogManager.Instance.LogWarning("Update is disabled", nameof(MainForm));
            }

            if (Settings.ShowWhatIsNewAtStartup)
            {
                //settings.ShowWhatIsNewAtStartup = false;
            }
        }

        private void RegisterForNotifications()
        {
            NotificationManager.OnNewNotification += (s, notification) =>
            {
                AlertInfo info = new AlertInfo(notification.Title, notification.Message, notification.SmallImage);
                AlertControl ac = new AlertControl(this.components)
                {
                    AutoFormDelay = notification.DurationSeconds * 1000,
                };
                ac.AutoHeight = true;
                if (notification.ActionOnClick != null)
                {
                    AlertButton btn1 = new AlertButton(Resources.Delete_16x16);
                    btn1.Hint = "OK";
                    btn1.Name = "NotificationActionButton";
                    ac.Buttons.Add(btn1);
                    ac.ButtonClick += (sender, arg) =>
                    {
                        if (arg.ButtonName == btn1.Name)
                        {
                            try
                            {
                                notification.ActionOnClick?.Invoke();
                            }
                            catch (Exception exception)
                            {
                                XtraMessageBox.Show($"Error during notification action: {exception}", "Error",
                                    MessageBoxButtons.OK);
                            }
                        }
                    };
                }
                ac.Show(this.ParentForm, info);
            };
        }

        private void SetWindowSizeAndPosition()
        {
            if (Settings.AnalogyPosition.RememberLastPosition ||
                Settings.AnalogyPosition.WindowState != FormWindowState.Minimized)
            {
                WindowState = Settings.AnalogyPosition.WindowState;
                if (WindowState != FormWindowState.Maximized)
                {
                    if (Screen.AllScreens.Any(s => s.WorkingArea.Contains(Settings.AnalogyPosition.Location)))
                    {
                        Location = Settings.AnalogyPosition.Location;
                        Size = Settings.AnalogyPosition.Size;
                    }
                    else
                    {
                        ServicesProvider.Instance.GetService<ILogger>().LogError("",
                            $"Last location {Settings.AnalogyPosition.Location} is not inside any screen");
                    }
                }
            }
        }
        private void RegisterForOnDemandPlots()
        {
            PlottingManager.OnShowPlot += (s, e) =>
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    if (!e.userControl.Visible)
                    {
                        var page = dockManager1.AddPanel(DockingStyle.Float);
                        page.DockedAsTabbedDocument = e.startupType == AnalogyOnDemandPlottingStartupType.TabbedWindow;
                        page.Controls.Add(e.userControl);
                        e.userControl.Show();
                        e.userControl.Dock = DockStyle.Fill;
                        page.Text = $"Plot: {e.userControl.Title}";
                        dockManager1.ActivePanel = page;
                        page.ClosingPanel += (_, __) =>
                        {
                            PlottingManager.OnHidePlot += Instance_OnHidePlot;
                        };
                        void Instance_OnHidePlot(object sender, OnDemandPlottingUC uc)
                        {
                            if (uc == e.userControl)
                            {
                                dockManager1.RemovePanel(page);
                                uc.Hide();
                            }
                        }
                        PlottingManager.OnHidePlot += Instance_OnHidePlot;
                    }
                }));
            };
        }
        private void LoadStartupExtensions()
        {
            if (Settings.StartupExtensions.Any())
            {
                var extensions = ExtensionsManager.GetExtensions().ToList();
                foreach (Guid guid in Settings.StartupExtensions)
                {
                    ExtensionsManager.RegisterExtension(extensions.SingleOrDefault(m => m.Id == guid));
                }
            }
        }

        private async Task OpenOfflineFileWithSpecificDataProvider(string[] files)
        {
            while (!Initialized)
            {
                await Task.Delay(250);
            }

            var supported = FactoriesManager.GetSupportedOfflineDataSources(files).ToList();
            if (supported.Count == 1)
            {
                var parser = supported.First();
                LoadFactoryInAccordion(parser.FactoryID);
                await OpenOfflineLogs(files, parser.DataProvider);
            }
            else
            {
                if (supported.Any(d =>
                    d.DataProvider.Id == Settings.LastOpenedDataProvider ||
                    (d.FactoryID == Settings.LastOpenedDataProvider
                    && d.DataProvider.CanOpenAllFiles(files))))
                {
                    supported = supported.Where(d =>
                        d.DataProvider.Id == Settings.LastOpenedDataProvider ||
                        (d.FactoryID == Settings.LastOpenedDataProvider && d.DataProvider.CanOpenAllFiles(files))).ToList();
                }
                else
                {
                    supported = FactoriesManager.GetSupportedOfflineDataSources(files).Where(itm =>
                        !FactoriesManager.IsBuiltInFactory(itm.FactoryID)).ToList();
                }

                if (supported.Count == 1)
                {
                    var parser = supported.First();
                    LoadFactoryInAccordion(parser.FactoryID);
                    await OpenOfflineLogs(files, parser.DataProvider);
                }
                else
                {
                    //try  from file association:
                    var associations = Settings.GetDataProvidesForFilesAssociations(files);
                    if (associations.Any())
                    {
                        var parsers = FactoriesManager.GetAllOfflineDataSources(associations).ToList();
                        if (parsers.Count == 1 || parsers.Select(p => p.Id).Distinct().Count() == 1)
                        {
                            LoadFactoryInAccordion(parsers.First().Id);
                            await OpenOfflineLogs(files, parsers.First());
                        }
                        else
                        {
                            XtraMessageBox.Show($@"More than one data provider detected for this file{Environment.NewLine}Please open it directly from the data provider menu", "Unable to open file",
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

        private async Task OpenOfflineLogs(string[] fileNames, IAnalogyOfflineDataProvider dataProvider,
            string? title = null)
        {
            openedWindows++;
            await FactoriesManager.InitializeIfNeeded(dataProvider);
            string fullTitle = $"{offlineTitle} #{openedWindows}{(title == null ? "" : $" ({title})")}";
            UserControl offlineUC = new LocalLogFilesUC(dataProvider, fileNames, title: fullTitle);
            var page = dockManager1.AddPanel(DockingStyle.Float);
            page.DockedAsTabbedDocument = true;
            page.Controls.Add(offlineUC);
            offlineUC.Dock = DockStyle.Fill;
            page.Text = fullTitle;
            dockManager1.ActivePanel = page;
        }
        private void SetupEventHandlers()
        {
            Settings.OnApplicationSkinNameChanged += (s, e) =>
            {
                UpdateUpdateButton();
            };
            bbiWelcomeForm.ItemClick += (s, e) =>
            {
                WelcomeForm wf = new WelcomeForm(Settings, FactoriesManager, FoldersAccess, UpdateManager);
                wf.ShowDialog(this);
            };
            bbtnItemGithubHistory.ItemClick += (s, e) =>
            {
                GitHubHistoryForm g = new GitHubHistoryForm();
                g.ShowDialog(this);
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

            #region  main menu

            btnSettingsUpdate.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.UpdatesSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };

            bbiSettingsExtensions.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ExtensionsSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };

            btnSettingsDebugging.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.DebuggingSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };

            btnShortcuts.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ShortcutsSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };

            bbiDonation.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.DonationsSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };
            bbiAdvancedMode.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.AdvancedModeSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };
            btnApplicationSettings.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ApplicationGeneralSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };
            btnApplicationUISettings.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ApplicationUISettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };
            btnFiltering.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.MessagesFilteringSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };
            btnMessageColumnsLayoutSettings.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.MessagesLayoutSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };
            btnColorsSettings.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ColorSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };
            btnColorHighlightSettings.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ColorHighlighting, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };
            btnPreDefinedQueries.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.PredefinedQueriesSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };
            btnDataProvidersSettings.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.DataProvidersSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };
            bbiRealTimeProviders.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.RealTimeDataProvidersSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };
            bbiFileAssociations.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.FilesAssociationSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };
            bbiAdditionalLocations.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm(ApplicationSettingsSelectionType.ExternalLocationsSettings, Settings, FactoriesManager, FoldersAccess, UpdateManager);
                user.ShowDialog(this);
            };
            #endregion

            bbiKofi.ItemClick += (s, e) =>
            {
                Utils.OpenLink("https://ko-fi.com/liorbanai");
            };
            bbiGitHubSponsor.ItemClick += (s, e) =>
            {
                Utils.OpenLink("https://github.com/sponsors/LiorBanai/");
            };
            bbiPayPal.ItemClick += (s, e) =>
            {
                Utils.OpenLink("https://www.paypal.com/donate/?business=MCP57TBRAAVXA&no_recurring=0&item_name=Support+Open+source+Projects+%28Analogy+Log+Viewer%2C+HDF5-CSHARP%2C+etc%29&currency_code=USD");
            };
            bbiBinance.ItemClick += (s, e) =>
            {
                Utils.OpenLink("https://www.binance.com/en/register?ref=V8P114PE");
            };

            dockManager1.ClosingPanel += (s, e) =>
            {
                Control control = e.Panel.ActiveControl;
                if (control != null)
                {
                    control.Dispose();
                }
                var workspace = Utils.GetLogWindows<IAnalogyWorkspace>(this);
                workspace?.SaveCurrentWorkspace();
            };
            bbtnSponsorOpenCollection.ItemClick +=
                (s, e) => Utils.OpenLink("https://opencollective.com/analogy-log-viewer");
            bbtnItemHelp.ItemClick += (s, e) =>
            {
                AnalogyAboutBox ab = new AnalogyAboutBox();
                ab.ShowDialog(this);
            };
            bbiUserSettingsStatistics.ItemClick += (s, e) =>
            {
                var user = new UserStatisticsForm(Settings);
                user.ShowDialog(this);
            };
            bbtnUpdates.ItemClick += (s, e) => OpenUpdateWindow();
            bbtnDataProvidersUpdates.ItemClick += (s, e) =>
            {
                var update = new ComponentDownloadsForm(FactoriesManager, UpdateManager);
                update.Show(this);
            };
            bbtnDebugLog.ItemClick += (s, e) => AnalogyLogManager.Instance.Show(this);
            bbtnItemChangeLog.ItemClick += (s, e) =>
            {
                var change = new ChangeLog();
                change.ShowDialog(this);
            };

            tmrStatusUpdates.Tick += (s, e) =>
            {
                tmrStatusUpdates.Stop();
                bbtnMemoryUsage.Caption = Process.GetCurrentProcess().PrivateMemorySize64 / 1024 / 1024 + " [MB]";
                bbtnIdleMessage.Caption = Settings.IdleMode
                    ? $"Idle mode is on. User idle: {Utils.IdleTime():hh\\:mm\\:ss}. Missed messages: {PagingManager.TotalMissedMessages}"
                    : "Idle mode is off";
                tmrStatusUpdates.Start();
            };
            AnalogyLogManager.Instance.OnNewError += (s, e) => bbtnErrors.Visibility = BarItemVisibility.Always;

            NotificationManager.OnNewNotification += (s, notification) =>
            {
                AlertInfo info = new AlertInfo(notification.Title, notification.Message, notification.SmallImage);
                AlertControl ac = new AlertControl(this.components)
                {
                    AutoFormDelay = notification.DurationSeconds * 1000,
                };
                ac.AutoHeight = true;
                if (notification.ActionOnClick != null)
                {
                    AlertButton btn1 = new AlertButton(Resources.Delete_16x16);
                    btn1.Hint = "OK";
                    btn1.Name = "NotificationActionButton";
                    ac.Buttons.Add(btn1);
                    ac.ButtonClick += (sender, arg) =>
                    {
                        if (arg.ButtonName == btn1.Name)
                        {
                            try
                            {
                                notification.ActionOnClick?.Invoke();
                            }
                            catch (Exception exception)
                            {
                                XtraMessageBox.Show($"Error during notification action: {exception}", "Error",
                                    MessageBoxButtons.OK);
                            }
                        }
                    };
                }

                ac.Show(this.ParentForm, info);
            };
            bbtnErrors.ItemClick += (s, e) => { AnalogyLogManager.Instance.Show(this); };
            bbtnStar.ItemClick += (s, e) =>
            {
                Utils.OpenLink("https://github.com/Analogy-LogViewer/Analogy.LogViewer");
            };
            bbtnReportIssueOrRequest.ItemClick += (_, __) =>
            {
                Utils.OpenLink("https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues");
            };
            bbtnCheckUpdates.ItemClick += (s, e) => OpenUpdateWindow();

            bbiFileCaching.ItemClick += (s, e) =>
            {
                Settings.EnableFileCaching = !Settings.EnableFileCaching;
                bbiFileCaching.Caption = "File caching is " + (Settings.EnableFileCaching ? "on" : "off");
                bbiFileCaching.Appearance.BackColor = Settings.EnableFileCaching ? Color.LightGreen : Color.Empty;
            };
        }

        private void OpenUpdateWindow()
        {
            UpdateForm update = new UpdateForm(Settings, UpdateManager);
            update.Show(this);
        }
        private void UpdateUpdateButton()
        {
            bbtnCheckUpdates.Caption = "Latest Version: " + UpdateManager.NewestVersion.ToString();
            if (UpdateManager.NewVersionExist)
            {
                bbtnCheckUpdates.Appearance.BackColor = Color.GreenYellow;
                if (DevExpress.Utils.Frames.FrameHelper.IsDarkSkin(Settings.ApplicationSkinName))
                {
                    bbtnCheckUpdates.Appearance.ForeColor = Color.DarkBlue;
                }
                bbtnCheckUpdates.Caption = "New Version Available: " + UpdateManager.NewestVersion.ToString();
            }
        }
        private void PopulateGlobalTools()
        {
            var allFactories = FactoriesManager.Factories.ToList();
            allFactories.AddRange(FactoriesManager.BuiltInFactories);
            foreach (FactoryContainer fc in allFactories
                .Where(factory => factory.FactorySetting.Status != DataProviderFactoryStatus.Disabled))
            {
                var actionFactories = fc.CustomActionsFactories;
                foreach (var actionFactory in actionFactories)
                {
                    foreach (IAnalogyCustomAction action in actionFactory.Actions)
                    {
                        if (action.Type != AnalogyCustomActionType.Global)
                        {
                            continue;
                        }

                        BarButtonItem actionBtn = new BarButtonItem();
                        bsiGlobalTools.ItemLinks.Add(actionBtn);
                        actionBtn.ImageOptions.Image = action.SmallImage ?? Resources.globalTools16x16;
                        actionBtn.ImageOptions.LargeImage = action.LargeImage ?? Resources.globalTools32x32;
                        actionBtn.RibbonStyle = RibbonItemStyles.All;
                        actionBtn.Caption = string.IsNullOrEmpty(action.Title) ? "Tool" : action.Title;
                        actionBtn.ItemClick += (sender, e) => { action.Action(); };
                    }
                }
            }
        }

        private void CreateDataSourceMenuItem(FactoryContainer fc)
        {
            if (fc.Factory.Title == null)
            {
                return;
            }

            BarCheckItem bci = new BarCheckItem(barManager1, fc.Factory.FactoryId == activeProvider);
            bci.CheckStyle = BarCheckStyles.Radio;
            bci.GroupIndex = 1;
            bci.CheckBoxVisibility = CheckBoxVisibility.BeforeText;

            //bci.Caption = fc.Factory.Title;
            bci.Enabled = fc.FactorySetting.Status != DataProviderFactoryStatus.Disabled;
            bci.ItemClick += (s, e) =>
            {
                bci.Checked = true;
                LoadFactoryInAccordion(fc.Factory.FactoryId);
            };
            bsiDataProviders.AddItem(bci);
        }

        private void LoadFactoryInAccordion(Guid factoryId)
        {
            if (activeProvider == factoryId)
            {
                return;
            }
            accordionControl.BeginUpdate();
            accordionControl.Clear();
            var containers = FactoriesManager.GetFactoryContainer(factoryId);
            var fc = containers.Count == 1 ? containers.First() : FactoriesManager.GetBuiltInFactoryContainer(factoryId);
            activeProvider = fc.Factory.FactoryId;
            Settings.LastOpenedDataProvider = activeProvider;

            LoadDataProvidersInAccordion(fc);

            //var ribbonPageImage = FactoriesManager.GetSmallImage(fc.Factory.FactoryId);
            //if (ribbonPageImage != null)
            //{
            //    group.ImageOptions.Image = ribbonPageImage;
            //}

            //    var dataSourceFactory = fc.DataProvidersFactories;

            //    foreach (var dataProvidersFactory in dataSourceFactory)
            //    {
            //        if (!string.IsNullOrEmpty(dataProvidersFactory.Title))
            //        {
            //            CreateDataSourceRibbonGroup(fc.Factory, dataProvidersFactory, ribbonPage);
            //        }
            //    }

            //    var actionFactories = fc.CustomActionsFactories;
            //    foreach (var actionFactory in actionFactories.Where(af
            //        => af.Actions.Any(a => a.Type == AnalogyCustomActionType.BelongsToProvider)))
            //    {

            //        if (string.IsNullOrEmpty(actionFactory.Title))
            //        {
            //            continue;
            //        }

            //        RibbonPageGroup groupActionSource = new RibbonPageGroup(actionFactory.Title);
            //        groupActionSource.AllowTextClipping = false;
            //        ribbonPage.Groups.Add(groupActionSource);
            //        if (actionFactory.Actions == null)
            //        {
            //            AnalogyLogManager.Instance.LogCritical($"null actions for {actionFactory.Title}:{actionFactory.FactoryId}", $"{actionFactory.Title}{actionFactory.FactoryId}");
            //            continue;
            //        }
            //        foreach (IAnalogyCustomAction action in actionFactory.Actions.Where(a => a.Type == AnalogyCustomActionType.BelongsToProvider))
            //        {
            //            BarButtonItem actionBtn = new BarButtonItem
            //            {
            //                Caption = action.Title,
            //                RibbonStyle = RibbonItemStyles.All
            //            };
            //            groupActionSource.ItemLinks.Add(actionBtn);
            //            actionBtn.ImageOptions.Image = action.SmallImage ?? Resources.PageSetup_32x32;
            //            actionBtn.ImageOptions.LargeImage = action.LargeImage ?? Resources.PageSetup_32x32;
            //            actionBtn.ItemClick += (sender, e) => { action.Action(); };
            //        }
            //    }
            AddUserControls(fc, fc.UserControlsFactories);
            AddGraphPlotter(fc, fc.GraphPlotter);
            AddFactorySettings(fc);
            AddAbout(fc);
            accordionControl.EndUpdate();
        }
        private void AddAbout(FactoryContainer fc)
        {
            AccordionControlElement acRootGroupHome = new AccordionControlElement();
            accordionControl.Elements.Add(acRootGroupHome);
            acRootGroupHome.Expanded = true;
            acRootGroupHome.ImageOptions.Image = Resources.About_16x16;
            acRootGroupHome.Text = "Data Source Information";

            AccordionControlElement aboutBtn = new AccordionControlElement();
            acRootGroupHome.Elements.Add(aboutBtn);
            aboutBtn.Style = ElementStyle.Item;
            aboutBtn.ImageOptions.Image = Resources.About_16x16;
            aboutBtn.Text = "About";
            aboutBtn.Click += (sender, e) => { new AboutDataSourceBox(fc.Factory, FactoriesManager).ShowDialog(this); };
        }
        private void AddFactorySettings(FactoryContainer fc)
        {
            if (fc.FactorySetting.Status == DataProviderFactoryStatus.Disabled || !fc.DataProvidersSettings.Any())
            {
                return;
            }

            AccordionControlElement acRootGroupHome = new AccordionControlElement();
            accordionControl.Elements.Add(acRootGroupHome);
            acRootGroupHome.Expanded = true;
            acRootGroupHome.ImageOptions.Image = Resources.Technology_16x16;
            acRootGroupHome.Text = "Settings";

            foreach (var providerSetting in fc.DataProvidersSettings)
            {
                providerSetting.CreateUserControl(ServicesProvider.Instance.GetService<ILogger>());
                AccordionControlElement settingsBtn = new AccordionControlElement();
                acRootGroupHome.Elements.Add(settingsBtn);
                settingsBtn.Style = ElementStyle.Item;
                settingsBtn.ImageOptions.Image = providerSetting.SmallImage ?? Resources.Technology_16x16;
                settingsBtn.Text = providerSetting.Title;

                XtraForm form = new DataProviderSettingsForm();
                form.Text = "Data Provider Settings: " + providerSetting.Title;
                form.Controls.Add(providerSetting.DataProviderSettings);
                providerSetting.DataProviderSettings.Dock = DockStyle.Fill;
                form.Closing += async (s, e) => { await providerSetting.SaveSettingsAsync(); };
                settingsBtn.Click += (sender, e) => { form.ShowDialog(this); };
            }
        }

        private void LoadDataProvidersInAccordion(FactoryContainer fc)
        {
            var dataSourceFactory = fc.DataProvidersFactories;

            foreach (var dataProvidersFactory in dataSourceFactory)
            {
                if (!string.IsNullOrEmpty(dataProvidersFactory.Title))
                {
                    AddFlatRealTimeDataSource(fc, dataProvidersFactory);
                    AddSingleDataSources(fc, dataProvidersFactory);
                    AddOfflineDataSource(fc, dataProvidersFactory);
                }
            }
        }
        private void AddOfflineDataSource(FactoryContainer fc, IAnalogyDataProvidersFactory factory)
        {
            var offlineProviders = factory.DataProviders.Where(f => f is IAnalogyOfflineDataProvider)
                .Cast<IAnalogyOfflineDataProvider>().ToList();

            if (!offlineProviders.Any())
            {
                return;
            }

            AccordionControlElement acRootGroupHome = new AccordionControlElement();
            accordionControl.Elements.Add(acRootGroupHome);
            acRootGroupHome.Expanded = true;
            acRootGroupHome.ImageOptions.ImageUri.Uri = "Home;Office2013";
            acRootGroupHome.Text = $"Offline Data Provider: {factory.Title}";

            for (var i = 0; i < offlineProviders.Count; i++)
            {
                var offlineAnalogy = offlineProviders[i];
                string optionalText = !string.IsNullOrEmpty(offlineAnalogy.OptionalTitle)
                    ? " for " + offlineAnalogy.OptionalTitle
                    : string.Empty;

                Guid factoryId = factory.FactoryId;
                string title = factory.Title;

                #region actions

                async Task OpenOffline(string titleOfDataSource, string initialFolder, string[] files = null)
                {
                    openedWindows++;
                    await FactoriesManager.InitializeIfNeeded(offlineAnalogy);
                    string fullTitle = $"{offlineTitle} #{openedWindows} ({titleOfDataSource})";
                    UserControl offlineUC = new LocalLogFilesUC(offlineAnalogy, files, initialFolder, title: fullTitle);
                    var page = dockManager1.AddPanel(DockingStyle.Float);
                    page.DockedAsTabbedDocument = true;
                    page.Controls.Add(offlineUC);
                    offlineUC.Dock = DockStyle.Fill;
                    page.Text = fullTitle;
                    dockManager1.ActivePanel = page;
                }

                void OpenExternalDataSource(string titleOfDataSource, IAnalogyOfflineDataProvider analogy)
                {
                    openedWindows++;
                    var ClientServerUCLog = new ClientServerUCLog(analogy);
                    var page = dockManager1.AddPanel(DockingStyle.Float);
                    page.DockedAsTabbedDocument = true;
                    page.Controls.Add(ClientServerUCLog);
                    ClientServerUCLog.Dock = DockStyle.Fill;
                    page.Text = $"Client/Server logs #{openedWindows}. {titleOfDataSource}";
                    dockManager1.ActivePanel = page;
                }

                async Task OpenFilePooling(string titleOfDataSource, string initialFolder, string file, string initialFile)
                {
                    openedWindows++;
                    await FactoriesManager.InitializeIfNeeded(offlineAnalogy);
                    UserControl filepoolingUC = new FilePoolingUCLogs(Settings, FileProcessingManager, offlineAnalogy, file, initialFile, initialFolder);
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
                                AnalogyLogManager.Instance.LogError("Error during dispose: " + e,
                                    nameof(OnXtcLogsOnControlRemoved));
                            }
                            finally
                            {
                                dockManager1.ClosedPanel -= OnXtcLogsOnControlRemoved;
                            }
                        }
                    }

                    page.Controls.Add(filepoolingUC);
                    filepoolingUC.Dock = DockStyle.Fill;
                    page.Text = $"{filePoolingTitle} #{filePooling++} ({titleOfDataSource})";
                    dockManager1.ActivePanel = page;
                    dockManager1.ClosedPanel += OnXtcLogsOnControlRemoved;
                }

                #endregion

                var containers = FactoriesManager.GetFactoryContainer(offlineAnalogy.Id);
                IAnalogyImages? images = containers.Count == 1 ? containers.First()?.Images?.FirstOrDefault() : null;

                var preDefinedFolderExist = !string.IsNullOrEmpty(offlineAnalogy.InitialFolderFullPath) &&
                                            Directory.Exists(offlineAnalogy.InitialFolderFullPath);

                //add specific folder button:
                if (preDefinedFolderExist)
                {
                    string specificDirectory = offlineAnalogy.InitialFolderFullPath!;

                    AccordionControlElement specificLocalFolder = new AccordionControlElement();
                    acRootGroupHome.Elements.Add(specificLocalFolder);
                    specificLocalFolder.Style = ElementStyle.Item;
                    specificLocalFolder.Text = "Open Pre-defined Folder";
                    specificLocalFolder.ImageOptions.Image = images?.GetLargeOpenFolderImage(factoryId) ?? Resources.OpenFolder_32x32;
                    specificLocalFolder.Click += async (sender, e) =>
                    {
                        await OpenOffline(title, specificDirectory);
                    };
                }

                AccordionControlElement recentFolders = new AccordionControlElement { Text = "Recent Folders" };

                //add local folder button:
                AccordionControlElement localfolder = new AccordionControlElement();
                acRootGroupHome.Elements.Add(localfolder);
                localfolder.Style = ElementStyle.Item;
                localfolder.Text = "Open Folder Selection";
                localfolder.ImageOptions.Image = images?.GetLargeOpenFolderImage(factoryId) ?? Resources.OpenFolder_32x32;
                localfolder.Click += async (sender, e) =>
                {
                    using (var folderBrowserDialog = new XtraFolderBrowserDialog { ShowNewFolderButton = false })
                    {
                        folderBrowserDialog.SelectedPath = preDefinedFolderExist
                            ? offlineAnalogy.InitialFolderFullPath
                            : Environment.CurrentDirectory;
                        DialogResult result = folderBrowserDialog.ShowDialog(); // Show the dialog.
                        if (result == DialogResult.OK) // Test result.
                        {
                            if (!string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
                            {
                                await OpenOffline(title, folderBrowserDialog.SelectedPath);
                                AddRecentFolder(recentFolders, offlineAnalogy, title, folderBrowserDialog.SelectedPath);
                            }
                        }
                    }
                };

                recentFolders.ImageOptions.Image = images?.GetLargeRecentFoldersImage(factoryId) ?? Resources.LoadFrom_32x32;
                foreach (var path in Settings.GetRecentFolders(offlineAnalogy.Id))
                {
                    //add local folder button:
                    if (!string.IsNullOrEmpty(path.Path) && Directory.Exists(path.Path))
                    {
                        AccordionControlElement btn = new AccordionControlElement();
                        recentFolders.Elements.Add(btn);
                        btn.Style = ElementStyle.Item;
                        btn.Text = Path.GetFileName(path.Path);
                        SuperToolTip toolTip = new SuperToolTip();
                        SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
                        args.Title.Text = Path.GetFileName(path.Path);
                        args.Contents.Text = path.Path;

                        // args.Contents.Image = realTime.ToolTip.Image;
                        toolTip.Setup(args);
                        btn.SuperTip = toolTip;
                        btn.Click += async (s, be) =>
                        {
                            await OpenOffline(offlineAnalogy.OptionalTitle, path.Path);
                        };
                    }
                }

                //recent bar
                AccordionControlElement recentfiles = new AccordionControlElement();
                recentfiles.Text = "Recent Files";
                recentfiles.ImageOptions.Image = images?.GetLargeRecentFilesImage(factoryId) ?? Resources.RecentlyUse_32x32;

                //add Files open buttons

                if (!string.IsNullOrEmpty(offlineAnalogy.FileOpenDialogFilters))
                {//add Open files entry
                    AccordionControlElement openFiles = new AccordionControlElement { Text = "Open Files" };
                    acRootGroupHome.Elements.Add(openFiles);
                    openFiles.Style = ElementStyle.Item;
                    openFiles.ImageOptions.Image = offlineAnalogy.LargeImage ?? Resources.Article_32x32;
                    openFiles.Click += async (sender, e) =>
                    {
                        OpenFileDialog openFileDialog1 = new OpenFileDialog
                        {
                            Filter = Utils.GetOpenFilter(offlineAnalogy.FileOpenDialogFilters),
                            Title = @"Open Files",
                            Multiselect = true,
                        };
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            await OpenOffline(title, offlineAnalogy.InitialFolderFullPath, openFileDialog1.FileNames);
                            AddRecentFiles(recentfiles, offlineAnalogy, title, openFileDialog1.FileNames.ToList());
                        }
                    };

                    //add Open pooling file entry
                    AccordionControlElement filePoolingBtn = new AccordionControlElement();
                    acRootGroupHome.Elements.Add(filePoolingBtn);
                    filePoolingBtn.Style = ElementStyle.Item;
                    string caption = "File Pooling (Monitoring)";
                    filePoolingBtn.Text = caption;
                    filePoolingBtn.SuperTip = Utils.GetSuperTip(caption, "Monitor file for changes in real time and reload the file automatically");
                    filePoolingBtn.ImageOptions.Image =
                        images?.GetLargeFilePoolingImage(factoryId) ?? Resources.FilePooling_32x32;
                    filePoolingBtn.Click += async (sender, e) =>
                    {
                        OpenFileDialog openFileDialog1 = new OpenFileDialog
                        {
                            Filter = offlineAnalogy.FileOpenDialogFilters,
                            Title = @"Open File for pooling",
                            Multiselect = false,
                        };
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            EditFilePooling efp = new EditFilePooling(openFileDialog1.FileName);
                            efp.ShowDialog(this);
                            await OpenFilePooling(title, offlineAnalogy.InitialFolderFullPath, efp.Filter, openFileDialog1.FileName);
                            AddRecentFiles(recentfiles, offlineAnalogy, title,
                                new List<string> { openFileDialog1.FileName });
                        }
                    };
                }
                else
                {
                    IAnalogyNotification notification = new AnalogyNotification(factoryId,
                        "Missing File Open Dialog Filter",
                        $"{title} has offline data provider without File Open Dialog Filter.{Environment.NewLine}You can set a filter in the data provider settings or report this to the developer.{Environment.NewLine}Filter format example: 'log files (*.log)|*.log|clef files (*.clef)|*.clef'",
                        AnalogyLogLevel.Error, offlineAnalogy.LargeImage, 5, null);
                    NotificationManager.RaiseNotification(notification, true);
                }

                //add recent
                var recents = Settings.GetRecentFiles(offlineAnalogy.Id)
                    .Select(itm => itm.FileName).ToList();
                AddRecentFiles(recentfiles, offlineAnalogy, title, recents);

                acRootGroupHome.Elements.Add(recentFolders);
                acRootGroupHome.Elements.Add(recentfiles);

                //add client/server  button:
                AccordionControlElement externalSources = new AccordionControlElement();
                acRootGroupHome.Elements.Add(externalSources);
                externalSources.Style = ElementStyle.Item;
                externalSources.Text = "Known Locations";
                externalSources.ImageOptions.Image = images?.GetLargeKnownLocationsImage(factoryId) ?? Resources.ServerMode_32x32;
                externalSources.Click += (sender, e) => { OpenExternalDataSource(title, offlineAnalogy); };

                //add tools
                AccordionControlElement acRootGroupTool = new AccordionControlElement();
                accordionControl.Elements.Add(acRootGroupTool);
                acRootGroupTool.Expanded = true;
                acRootGroupTool.ImageOptions.ImageUri.Uri = "Home;Office2013";
                acRootGroupTool.Text = $"Tools: {factory.Title}";

                AccordionControlElement searchFiles = new AccordionControlElement();
                acRootGroupTool.Elements.Add(searchFiles);
                searchFiles.Style = ElementStyle.Item;
                searchFiles.Text = "Search in Files";
                searchFiles.ImageOptions.Image =
                    images?.GetLargeSearchImage(offlineAnalogy.Id) ?? Resources.Lookup_Reference_32x32;

                searchFiles.Click += (sender, e) =>
                {
                    var search = new SearchForm(offlineAnalogy);
                    search.Show(this);
                };

                AccordionControlElement combineFiles = new AccordionControlElement();
                acRootGroupTool.Elements.Add(combineFiles);
                combineFiles.Style = ElementStyle.Item;

                combineFiles.Text = "Combine Files";
                combineFiles.ImageOptions.Image =
                    images?.GetLargeCombineLogsImage(offlineAnalogy.Id) ?? Resources.Sutotal_32x32;
                combineFiles.Click += (sender, e) =>
                {
                    var combined = new FormCombineFiles(offlineAnalogy);
                    combined.Show(this);
                };

                AccordionControlElement compareFiles = new AccordionControlElement();
                acRootGroupTool.Elements.Add(compareFiles);
                compareFiles.Style = ElementStyle.Item;

                compareFiles.Text = "Compare Files";
                compareFiles.ImageOptions.Image = images?.GetLargeCompareLogsImage(offlineAnalogy.Id) ?? Resources.TwoColumns;
                compareFiles.Click += (sender, e) =>
                {
                    FileComparerForm compare = new FileComparerForm(offlineAnalogy);
                    compare.ShowDialog(this);
                };
            }
        }

        private void AddRecentFolder(AccordionControlElement recentElement, IAnalogyOfflineDataProvider offlineAnalogy, string title, string recentPath)
        {
            AccordionControlElement btn = new AccordionControlElement();
            recentElement.Elements.Add(btn);
            btn.Style = ElementStyle.Item;
            btn.Text = Path.GetFileName(recentPath);

            SuperToolTip toolTip = new SuperToolTip();

            // Create an object to initialize the SuperToolTip.
            SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
            args.Title.Text = Path.GetFileName(recentPath);
            args.Contents.Text = recentPath;

            // args.Contents.Image = realTime.ToolTip.Image;
            toolTip.Setup(args);
            btn.SuperTip = toolTip;
            btn.Click += (s, be) =>
            {
                openedWindows++;
                string fullTitle = $"{offlineTitle} #{openedWindows} ({title})";
                UserControl offlineUC = new LocalLogFilesUC(offlineAnalogy, null, recentPath, title: fullTitle);
                var page = dockManager1.AddPanel(DockingStyle.Float);
                page.DockedAsTabbedDocument = true;
                page.Controls.Add(offlineUC);
                offlineUC.Dock = DockStyle.Fill;
                page.Text = fullTitle;
                dockManager1.ActivePanel = page;
            };
        }
        private void AddRecentFiles(AccordionControlElement recentElement, IAnalogyOfflineDataProvider offlineAnalogy, string title, List<string> recentFiles)
        {
            if (recentFiles.Any())
            {
                foreach (string file in recentFiles)
                {
                    if (!File.Exists(file) || recentElement.Elements.Any(e => e.Text.Equals(Path.GetFileName(file))))
                    {
                        continue;
                    }

                    AccordionControlElement btn = new AccordionControlElement();
                    recentElement.Elements.Add(btn);
                    btn.Style = ElementStyle.Item;
                    btn.Text = Path.GetFileName(file);

                    SuperToolTip toolTip = new SuperToolTip();
                    SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
                    args.Title.Text = Path.GetFileName(file);
                    args.Contents.Text = file;

                    // args.Contents.Image = realTime.ToolTip.Image;
                    toolTip.Setup(args);
                    btn.SuperTip = toolTip;
                    btn.Click += async (s, be) =>
                    {
                        await OpenOfflineLogs(new[] { file }, offlineAnalogy, title);
                    };
                }
            }
        }

        private void AddFlatRealTimeDataSource(FactoryContainer fc, IAnalogyDataProvidersFactory dataSourceFactory)
        {
            var realTimes = dataSourceFactory.DataProviders.Where(f => f is IAnalogyRealTimeDataProvider)
                .Cast<IAnalogyRealTimeDataProvider>().ToList();
            if (realTimes.Count == 0)
            {
                return;
            }

            string title = dataSourceFactory.Title;
            AccordionControlElement acRootGroupHome = new AccordionControlElement();
            accordionControl.Elements.Add(acRootGroupHome);
            acRootGroupHome.Expanded = true;
            acRootGroupHome.ImageOptions.ImageUri.Uri = "Home;Office2013";
            acRootGroupHome.Text = $"Real Time Providers: {title}";

            foreach (var realTime in realTimes)
            {
                AccordionControlElement realTimeBtn = new AccordionControlElement();
                acRootGroupHome.Elements.Add(realTimeBtn);
                realTimeBtn.Style = ElementStyle.Item;
                realTimeBtn.ImageOptions.Image = realTime.ConnectedLargeImage ?? Resources.Database_on;
                realTimeBtn.Text = (!string.IsNullOrEmpty(realTime.OptionalTitle)
                    ? $"{realTime.OptionalTitle}"
                    : "real time provider");
                if (realTime.ToolTip != null)
                {
                    SuperToolTip toolTip = new SuperToolTip();

                    // Create an object to initialize the SuperToolTip.
                    SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
                    args.Title.Text = realTime.ToolTip.Title;
                    args.Contents.Text = realTime.ToolTip.Content;

                    // args.Contents.Image = realTime.ToolTip.Image;
                    toolTip.Setup(args);
                    realTimeBtn.SuperTip = toolTip;
                }
                async Task<bool> OpenRealTime()
                {
                    realTimeBtn.Enabled = false;
                    bool canStartReceiving = false;
                    try
                    {
                        await FactoriesManager.InitializeIfNeeded(realTime);
                        canStartReceiving = await realTime.CanStartReceiving();
                    }
                    catch (Exception e)
                    {
                        AnalogyLogManager.Instance.LogError("Error during call to canStartReceiving: " + e,
                            nameof(MainForm));
                    }

                    if (canStartReceiving) //connected
                    {
                        openedWindows++;
                        var onlineUC = new OnlineUCLogs(realTime, FileProcessingManager);

                        void OnRealTimeOnMessageReady(object sender, AnalogyLogMessageArgs e) =>
                            onlineUC.AppendMessage(e.Message, Environment.MachineName);

                        void OnRealTimeOnOnManyMessagesReady(object sender, AnalogyLogMessagesArgs e) =>
                            onlineUC.AppendMessages(e.Messages, Environment.MachineName);

                        void OnRealTimeDisconnected(object sender, AnalogyDataSourceDisconnectedArgs e)
                        {
                            AnalogyLogMessage disconnected = new AnalogyLogMessage(
                                $"Source {dataSourceFactory.Title} Disconnected. Reason: {e.DisconnectedReason}",
                                AnalogyLogLevel.Analogy, AnalogyLogClass.General,
                                dataSourceFactory.Title, "Analogy");
                            onlineUC.AppendMessage(disconnected, Environment.MachineName);

                            //realTimeBtn.ImageOptions.Image = imageLargeOffline ?? Resources.Database_off;
                        }

                        var page = dockManager1.AddPanel(DockingStyle.Float);
                        page.DockedAsTabbedDocument = true;
                        page.Controls.Add(onlineUC);
                        onlineUC.Dock = DockStyle.Fill;
                        page.Text = $"{onlineTitle} #{openedWindows} ({dataSourceFactory.Title})";
                        dockManager1.ActivePanel = page;
                        realTime.OnMessageReady += OnRealTimeOnMessageReady;
                        realTime.OnManyMessagesReady += OnRealTimeOnOnManyMessagesReady;
                        realTime.OnDisconnected += OnRealTimeDisconnected;
                        await realTime.StartReceiving();

                        async void OnXtcLogsOnControlRemoved(object sender, DockPanelEventArgs arg)
                        {
                            if (arg.Panel == page)
                            {
                                try
                                {
                                    onlineUC.Enable = false;
                                    await realTime.StopReceiving();
                                    realTime.OnMessageReady -= OnRealTimeOnMessageReady;
                                    realTime.OnManyMessagesReady -= OnRealTimeOnOnManyMessagesReady;
                                    realTime.OnDisconnected -= OnRealTimeDisconnected;

                                    //page.Controls.Remove(onlineUC);
                                }
                                catch (Exception e)
                                {
                                    AnalogyLogManager.Instance.LogError(
                                        "Error during call to Stop receiving: " + e,
                                        nameof(OnXtcLogsOnControlRemoved));
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

                realTimeBtn.Click += async (s, be) => await OpenRealTime();
                if (Settings.AutoStartDataProviders.Contains(realTime.Id)
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

        private void AddSingleDataSources(FactoryContainer fc, IAnalogyDataProvidersFactory dataSourceFactory)
        {
            var singles = dataSourceFactory.DataProviders.Where(f => f is IAnalogySingleDataProvider ||
                                                                      f is IAnalogySingleFileDataProvider).ToList();
            if (singles.Count == 0)
            {
                return;
            }

            string title = dataSourceFactory.Title;
            AccordionControlElement acRootGroupHome = new AccordionControlElement();
            accordionControl.Elements.Add(acRootGroupHome);
            acRootGroupHome.Expanded = true;
            acRootGroupHome.ImageOptions.ImageUri.Uri = "Home;Office2013";
            acRootGroupHome.Text = $"Single Data Source: {title}";

            foreach (var single in singles)
            {
                AccordionControlElement singleBtn = new AccordionControlElement();
                acRootGroupHome.Elements.Add(singleBtn);
                singleBtn.Style = ElementStyle.Item;
                var imageLarge = FactoriesManager.GetLargeImage(single.Id);
                singleBtn.ImageOptions.Image = imageLarge ?? Resources.Single32x32;
                singleBtn.Text = !string.IsNullOrEmpty(single.OptionalTitle)
                    ? $"{single.OptionalTitle}"
                    : "Single Data Provider";
                if (single.ToolTip != null)
                {
                    SuperToolTip toolTip = new SuperToolTip();

                    // Create an object to initialize the SuperToolTip.
                    SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
                    args.Title.Text = single.ToolTip.Title;
                    args.Contents.Text = single.ToolTip.Content;

                    // args.Contents.Image = realTime.ToolTip.Image;
                    toolTip.Setup(args);
                    singleBtn.SuperTip = toolTip;
                }
                openedWindows++;
                singleBtn.Click += async (sender, e) =>
                {
                    await FactoriesManager.InitializeIfNeeded(single);
                    CancellationTokenSource cts = new CancellationTokenSource();
                    LocalLogFilesUC offlineUC = new LocalLogFilesUC(single, cts);
                    var page = dockManager1.AddPanel(DockingStyle.Float);
                    page.DockedAsTabbedDocument = true;
                    page.Controls.Add(offlineUC);
                    offlineUC.Dock = DockStyle.Fill;
                    page.Text = $"{offlineTitle} #{openedWindows} ({single.OptionalTitle})";
                    dockManager1.ActivePanel = page;
                    if (single is IAnalogySingleFileDataProvider fileProvider)
                    {
                        await fileProvider.Process(cts.Token, offlineUC.Handler);
                    }

                    if (single is IAnalogySingleDataProvider singleProvider)
                    {
                        await singleProvider.Execute(cts.Token, offlineUC.Handler);
                    }
                };
            }
        }

        private void AddUserControls(FactoryContainer fc, List<IAnalogyCustomUserControlsFactory> userControls)
        {
            if (userControls.Count == 0)
            {
                return;
            }

            string title = fc.Factory.Title;
            AccordionControlElement acRootGroupHome = new AccordionControlElement();
            accordionControl.Elements.Add(acRootGroupHome);
            acRootGroupHome.Expanded = true;
            acRootGroupHome.ImageOptions.ImageUri.Uri = "Home;Office2013";
            acRootGroupHome.Text = $"User Controls: {title}";

            foreach (var userControlFactory in userControls)
            {
                AccordionControlElement acRootUserControl = new AccordionControlElement();
                acRootGroupHome.Elements.Add(acRootUserControl);
                acRootUserControl.Expanded = true;
                acRootUserControl.ImageOptions.ImageUri.Uri = "Home;Office2013";
                acRootUserControl.Text = userControlFactory.Title;

                foreach (var userControl in userControlFactory.UserControls)
                {
                    AccordionControlElement userControlBtn = new AccordionControlElement();
                    acRootUserControl.Elements.Add(userControlBtn);
                    userControlBtn.Style = ElementStyle.Item;
                    userControlBtn.ImageOptions.Image = userControl.LargeImage ?? Resources.UserControls32x32;
                    userControlBtn.Text = userControl.Title;
                    if (userControl.ToolTip != null)
                    {
                        SuperToolTip toolTip = new SuperToolTip();

                        // Create an object to initialize the SuperToolTip.
                        SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
                        args.Title.Text = userControl.ToolTip.Title;
                        args.Contents.Text = userControl.ToolTip.Content;
                        args.Contents.Image = userControl.ToolTip.LargeImage;
                        toolTip.Setup(args);
                        userControlBtn.SuperTip = toolTip;
                    }
                    async Task<bool> OpenUserControl()
                    {
                        userControlBtn.Enabled = false;
                        openedWindows++;

                        //plotterBtn.ImageOptions.Image = imageSmallOnline ?? Resources.Database_on;
                        var page = dockManager1.AddPanel(DockingStyle.Float);
                        await userControl.InitializeUserControl(page, ServicesProvider.Instance.GetService<ILogger>());
                        page.DockedAsTabbedDocument = true;
                        page.Controls.Add(userControl.UserControl);
                        userControl.UserControl.Dock = DockStyle.Fill;
                        page.Text = $"{userControl.Title} #{openedWindows}";
                        dockManager1.ActivePanel = page;
                        async void OnXtcLogsOnControlRemoved(object sender, DockPanelEventArgs arg)
                        {
                            if (arg.Panel == page)
                            {
                                try
                                {
                                    await userControl.UserControlRemoved();
                                }
                                catch (Exception e)
                                {
                                    AnalogyLogManager.Instance.LogError(
                                        "Error during call to remove user control: " + e,
                                        nameof(OnXtcLogsOnControlRemoved));
                                }
                                finally
                                {
                                    dockManager1.ClosedPanel -= OnXtcLogsOnControlRemoved;
                                }
                            }
                        }

                        dockManager1.ClosedPanel += OnXtcLogsOnControlRemoved;
                        userControlBtn.Enabled = true;
                        return true;
                    }
                    userControlBtn.Click += async (s, be) => await OpenUserControl();
                }
            }
        }
        private void AddGraphPlotter(FactoryContainer fc, List<IAnalogyPlotting> graphPlotters)
        {
            if (graphPlotters == null || graphPlotters.Count == 0)
            {
                return;
            }

            string title = fc.Factory.Title;
            AccordionControlElement acRootGroupHome = new AccordionControlElement();
            accordionControl.Elements.Add(acRootGroupHome);
            acRootGroupHome.Expanded = true;
            acRootGroupHome.ImageOptions.Image = Resources.Line_32x32;
            acRootGroupHome.Text = $"Graph Plotter: {title}";

            foreach (var plot in graphPlotters)
            {
                AccordionControlElement plotterBtn = new AccordionControlElement();
                acRootGroupHome.Elements.Add(plotterBtn);
                plotterBtn.Style = ElementStyle.Item;
                plotterBtn.ImageOptions.Image = Resources.Line_32x32;
                plotterBtn.Text = plot.Title;

                async Task<bool> OpenPlotter()
                {
                    plotterBtn.Enabled = false;
                    openedWindows++;
                    var plotInteractor = AnalogyPlottingManager.Instance.GetOrCreateInteractor(plot);
                    await plot.InitializePlotting(plotInteractor, ServicesProvider.Instance.GetService<ILogger>());
                    var plotterUC = new PlottingUC(plot, plotInteractor);
                    var page = dockManager1.AddPanel(DockingStyle.Float);
                    page.DockedAsTabbedDocument = true;
                    page.Controls.Add(plotterUC);
                    plotterUC.Dock = DockStyle.Fill;
                    page.Text = $"{plot.Title} #{openedWindows}";
                    dockManager1.ActivePanel = page;
                    plotterUC.Start();
                    await plot.StartPlotting();

                    async void OnXtcLogsOnControlRemoved(object sender, DockPanelEventArgs arg)
                    {
                        if (arg.Panel == page)
                        {
                            try
                            {
                                await plot.StopPlotting();
                                plotterUC.Stop();

                                //page.Controls.Remove(onlineUC);
                            }
                            catch (Exception e)
                            {
                                AnalogyLogManager.Instance.LogError(
                                    "Error during call to Stop plotting: " + e,
                                    nameof(OnXtcLogsOnControlRemoved));
                            }
                            finally
                            {
                                dockManager1.ClosedPanel -= OnXtcLogsOnControlRemoved;
                            }
                        }
                    }

                    dockManager1.ClosedPanel += OnXtcLogsOnControlRemoved;
                    plotterBtn.Enabled = true;
                    return true;
                }

                plotterBtn.Click += async (s, be) => await OpenPlotter();
            }
        }
        private void FluentDesignMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PreventExit && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                var alertControl = new DevExpress.XtraBars.Alerter.AlertControl();
                var titleText = "Analogy Log Viewer";
                var contentText = "Still here... Double click the icon to restore";
                alertControl.AutoFormDelay = 3000;
                alertControl.AlertClick += (_, __) =>
                {
                    Show();
                    Focus();
                };
                alertControl.Show(this, titleText, contentText, Settings.GetImage());
            }
            else
            {
                Settings.AnalogyPosition.Location = Location;
                Settings.AnalogyPosition.Size = Size;
                Settings.AnalogyPosition.WindowState = WindowState;
                Settings.UpdateRunningTime();
                Settings.Save(UpdateManager.CurrentVersion.ToString(4));
                CleanupManager.Instance.Clean(AnalogyLogManager.Instance);
                AnalogyLogManager.Instance.SaveFile();
                BookmarkPersistManager.SaveFile();
                FactoriesManager.ShutDownAllFactories();
            }
        }

        private void bbiDownloadStatistics_ItemClick(object sender, ItemClickEventArgs e)
        {
            AnalogyAboutBox ab = new AnalogyAboutBox(2);
            ab.ShowDialog(this);
        }
    }
}