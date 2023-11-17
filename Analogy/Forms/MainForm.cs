
using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.Common.Managers;
using Analogy.CommonControls.Managers;
using Analogy.CommonControls.Plotting;
using Analogy.DataProviders;
using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.Template.Managers;
using Analogy.Managers;
using Analogy.Properties;
using Analogy.UserControls;
using DevExpress.Utils;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotificationManager = Analogy.Managers.NotificationManager;

namespace Analogy.Forms
{
    public partial class MainForm : RibbonForm
    {
        private IFactoriesManager FactoriesManager { get; }
        private IExtensionsManager ExtensionsManager { get; }
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

        private List<Task<bool>> OnlineSources { get; } = new List<Task<bool>>();
        private int OpenedWindows { get; set; }
        private int filePooling;
        private bool disableOnlineDueToFileOpen;
        private bool preventExit;
        private IAnalogyUserSettings Settings => ServicesProvider.Instance.GetService<IAnalogyUserSettings>();
        private bool Initialized { get; set; }
        private BookmarkPersistManager BookmarkPersistManager { get; }
        private UpdateManager UpdateManager { get; }
        private FileProcessingManager FileProcessingManager { get; }
        private NotificationManager NotificationManager { get; }
        private IAnalogyFoldersAccess FoldersAccess { get; }
        private AnalogyOnDemandPlottingManager PlottingManager { get; }

        public MainForm(IFactoriesManager factoriesManager, IExtensionsManager extensionsManager,
            BookmarkPersistManager bookmarkPersistManager, UpdateManager updateManager,
            FileProcessingManager fileProcessingManager, NotificationManager notificationManager,
            IAnalogyFoldersAccess foldersAccess, AnalogyOnDemandPlottingManager plottingManager)
        {
            FactoriesManager = factoriesManager;
            ExtensionsManager = extensionsManager;
            BookmarkPersistManager = bookmarkPersistManager;
            UpdateManager = updateManager;
            FileProcessingManager = fileProcessingManager;
            NotificationManager = notificationManager;
            FoldersAccess = foldersAccess;
            PlottingManager = plottingManager;

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

                //Get the message (file name we sent from the other instance)
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

        private async void AnalogyMainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
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
            if (Settings.AnalogyPosition.RememberLastPosition || Settings.AnalogyPosition.WindowState != FormWindowState.Minimized)
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

            string framework = UpdateManager.CurrentFrameworkAttribute.FrameworkName;
            Text = $"Analogy Log Viewer {UpdateManager.CurrentVersion} ({framework})";
            Icon = Settings.GetIcon();
            notifyIconAnalogy.Visible = preventExit = Settings.MinimizedToTrayBar;
            await FactoriesManager.InitializeBuiltInFactories();
            string[] arguments = Environment.GetCommandLineArgs();
            disableOnlineDueToFileOpen = arguments.Length == 2;
            SetupEventHandlers();
            bbiFileCaching.Caption = "File caching is " + (Settings.EnableFileCaching ? "on" : "off");
            bbiFileCaching.Appearance.BackColor = Settings.EnableFileCaching ? Color.LightGreen : Color.Empty;
            ribbonControlMain.Minimized = Settings.StartupRibbonMinimized;
            switch (Settings.RibbonStyle)
            {
                case AnalogyCommandLayout.Classic:
                    ribbonControlMain.CommandLayout = CommandLayout.Classic;
                    break;
                case AnalogyCommandLayout.Simplified:
                    ribbonControlMain.CommandLayout = CommandLayout.Simplified;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            FactoryContainer analogy = FactoriesManager.GetBuiltInFactoryContainer(AnalogyBuiltInFactory.AnalogyGuid);
            if (analogy.FactorySetting.Status != DataProviderFactoryStatus.Disabled)
            {
                CreateDataSource(analogy, 0);
            }
            await FactoriesManager.AddExternalDataSources();
            PopulateGlobalTools();
            LoadStartupExtensions();
            RegisterForOnDemandPlots();

            //Create all other DataSources
            foreach (FactoryContainer fc in FactoriesManager.Factories
                .Where(factory => !FactoriesManager.IsBuiltInFactory(factory.Factory) &&
                                  factory.FactorySetting.Status != DataProviderFactoryStatus.Disabled
                                  //&& (factory.DataProvidersFactories.Any(d => d.DataProviders.Any()
                                  //|| factory.UserControlsFactories.Any()))
                                  ))
            {
                CreateDataSource(fc, 3);
            }
            //set Default page:
            Guid defaultPage = Settings.InitialSelectedDataProvider;
            if (Mapping.TryGetValue(defaultPage, out RibbonPage? value1))
            {
                ribbonControlMain.SelectedPage = value1;
            }

            if (OnlineSources.Any())
            {
                TmrAutoConnect.Start();
            }

            Initialized = true;
            //todo: fine handler for file
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
            if (Settings.RememberLastOpenedDataProvider && Mapping.TryGetValue(Settings.LastOpenedDataProvider, out RibbonPage? value))
            {
                ribbonControlMain.SelectPage(value);
            }
            ribbonControlMain.SelectedPageChanging += ribbonControlMain_SelectedPageChanging;
            if (AnalogyLogManager.Instance.HasErrorMessages || AnalogyLogManager.Instance.HasWarningMessages)
            {
                btnErrors.Visibility = BarItemVisibility.Always;
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

        private void PopulateGlobalTools()
        {
            var allFactories = FactoriesManager.Factories.ToList();
            allFactories.AddRange(FactoriesManager.BuiltInFactories);
            foreach (FactoryContainer fc in allFactories
                .Where(factory => factory.FactorySetting.Status != DataProviderFactoryStatus.Disabled
                                  && factory.CustomActionsFactories.Any()))
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

        private void SetupEventHandlers()
        {
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
            Settings.OnApplicationSkinNameChanged += (s, e) =>
            {
                UpdateUpdateButton();
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
            bsiFilePlotting.ItemClick += (s, e) =>
            {
                FilePlotterUC uc = new FilePlotterUC();
                var page = dockManager1.AddPanel(DockingStyle.Float);
                page.DockedAsTabbedDocument = true;
                page.Tag = uc;
                page.Controls.Add(uc);
                uc.Dock = DockStyle.Fill;
                page.Text = "File Plotting";
                dockManager1.ActivePanel = page;
            };
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

            Settings.OnRibbonControlStyleChanged += (s, e) =>
            {
                switch (e)
                {
                    case AnalogyCommandLayout.Classic:
                        ribbonControlMain.CommandLayout = CommandLayout.Classic;
                        break;
                    case AnalogyCommandLayout.Simplified:
                        ribbonControlMain.CommandLayout = CommandLayout.Simplified;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(e), e, null);
                }
            };
            bbtnReportIssueOrRequest.ItemClick += (_, __) =>
            {
                Utils.OpenLink("https://github.com/Analogy-LogViewer/Analogy.LogViewer/issues");
            };

            bbtnCombineOpenLogs.ItemClick += (s, e) =>
            {
                var items = dockManager1.Panels.Select(p => (p.Text, Utils.GetLogWindows<ILogWindow>(p))).Where(l => l.Item2 != null)
                    .ToList();
                var openLogs = new OpenWindows(items);
                openLogs.Show(this);
            };
            bbtnCheckUpdates.ItemClick += (s, e) => OpenUpdateWindow();
            bbtnCompactMemory.ItemClick += (_, __) => FileProcessingManager.Reset();
            bbtnCompactMemory.Visibility = BarItemVisibility.Never;
            notifyIconAnalogy.DoubleClick += (_, __) =>
            {
                if (Visible)
                {
                    Hide();
                }
                else
                {
                    Show();
                }
            };

            bbiBookmarks.ItemClick += (s, e) => OpenBookmarkLog();
        }

        private async Task OpenOfflineLogs(RibbonPage? ribbonPage, string[] filenames,
            IAnalogyOfflineDataProvider dataProvider,
            string? title = null)
        {
            OpenedWindows++;
            await FactoriesManager.InitializeIfNeeded(dataProvider);
            string fullTitle = $"{offlineTitle} #{OpenedWindows}{(title == null ? "" : $" ({title})")}";
            UserControl offlineUC = new LocalLogFilesUC(dataProvider, filenames, title: fullTitle);
            var page = dockManager1.AddPanel(DockingStyle.Float);
            page.DockedAsTabbedDocument = true;
            page.Tag = ribbonPage;
            page.Controls.Add(offlineUC);
            offlineUC.Dock = DockStyle.Fill;
            page.Text = fullTitle;
            dockManager1.ActivePanel = page;
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
                RibbonPage page = Mapping.TryGetValue(parser.FactoryID, out RibbonPage? value) ? value : null;
                await OpenOfflineLogs(page, files, parser.DataProvider);
            }
            else
            {
                if (supported.Any(d =>
                    d.DataProvider.Id == Settings.LastOpenedDataProvider ||
                    d.FactoryID == Settings.LastOpenedDataProvider
                    && d.DataProvider.CanOpenAllFiles(files)))
                {
                    supported = supported.Where(d =>
                        d.DataProvider.Id == Settings.LastOpenedDataProvider ||
                        d.FactoryID == Settings.LastOpenedDataProvider && d.DataProvider.CanOpenAllFiles(files)).ToList();
                }
                else
                {
                    supported = FactoriesManager.GetSupportedOfflineDataSources(files).Where(itm =>
                        !FactoriesManager.IsBuiltInFactory(itm.FactoryID)).ToList();
                }

                if (supported.Count == 1)
                {
                    var parser = supported.First();
                    RibbonPage page = Mapping.TryGetValue(parser.FactoryID, out RibbonPage? value) ? value : null;
                    await OpenOfflineLogs(page, files, parser.DataProvider);
                }
                else
                {
                    //try from file association:
                    var associations = Settings.GetDataProvidesForFilesAssociations(files);
                    if (associations.Any())
                    {
                        var parsers = FactoriesManager.GetAllOfflineDataSources(associations).ToList();
                        if (parsers.Count == 1 || parsers.Select(p => p.Id).Distinct().Count() == 1)
                        {
                            var parser = parsers.First();
                            var fc = FactoriesManager.GetFactoryContainer(parser.Id);
                            RibbonPage? page = null;
                            if (fc.Any())
                            {
                                Settings.LastOpenedDataProvider = fc.First().Factory.FactoryId;
                                page = Mapping.TryGetValue(fc.First().Factory.FactoryId, out RibbonPage? value)
                                    ? value
                                    : null;
                                if (page is not null)
                                {
                                    ribbonControlMain.SelectPage(page);
                                }
                            }
                            await OpenOfflineLogs(page, files, parser);
                        }
                        else
                        {
                            XtraMessageBox.Show($@"More than one data provider detected for this file.{Environment.NewLine}Please open it directly from the data provider menu", "Unable to open file",
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

        private void AddRecentFiles(RibbonPage ribbonPage, BarSubItem bar, IAnalogyOfflineDataProvider offlineAnalogy,
            string title, List<string> files)
        {
            if (files.Any())
            {
                foreach (string file in files)
                {
                    if (!File.Exists(file) || bar.ItemLinks.Any(br => br.Caption.Equals(file)))
                    {
                        continue;
                    }

                    BarButtonItem btn = new BarButtonItem();
                    btn.Caption = file;
                    btn.ItemClick += async (s, be) =>
                    {
                        await OpenOfflineLogs(ribbonPage, new[] { be.Item.Caption }, offlineAnalogy, title);
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
            ApplicationSettingsForm user = new ApplicationSettingsForm(Settings, FactoriesManager, FoldersAccess, UpdateManager);
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
            OpenedWindows++;
            var bookmarkLog = new BookmarkLog();
            var page = dockManager1.AddPanel(DockingStyle.Float);
            page.DockedAsTabbedDocument = true;
            page.Controls.Add(bookmarkLog);
            bookmarkLog.Dock = DockStyle.Fill;
            page.Text = $"Analogy Bookmarked logs #{OpenedWindows}";
            dockManager1.ActivePanel = page;
        }
        private void bBtnCompareLogs_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void CreateDataSource(FactoryContainer fc, int position)
        {
            if (fc.Factory.Title == null)
            {
                return;
            }

            RibbonPage ribbonPage = new RibbonPage(fc.Factory.Title);
            ribbonControlMain.Pages.Insert(position, ribbonPage);
            Mapping.Add(fc.Factory.FactoryId, ribbonPage);
            var ribbonPageImage = FactoriesManager.GetSmallImage(fc.Factory.FactoryId);
            if (ribbonPageImage != null)
            {
                ribbonPage.ImageOptions.Image = ribbonPageImage;
            }

            var dataSourceFactory = fc.DataProvidersFactories;

            foreach (var dataProvidersFactory in dataSourceFactory)
            {
                if (!string.IsNullOrEmpty(dataProvidersFactory.Title))
                {
                    CreateOnlineAndOfflineProviders(fc.Factory, dataProvidersFactory, ribbonPage);
                }
            }

            var actionFactories = fc.CustomActionsFactories;
            foreach (var actionFactory in actionFactories.Where(af
                => af.Actions.Any(a => a.Type == AnalogyCustomActionType.BelongsToProvider)))
            {
                if (string.IsNullOrEmpty(actionFactory.Title))
                {
                    continue;
                }

                RibbonPageGroup groupActionSource = new RibbonPageGroup(actionFactory.Title);
                groupActionSource.AllowTextClipping = false;
                ribbonPage.Groups.Add(groupActionSource);
                if (actionFactory.Actions == null)
                {
                    AnalogyLogManager.Instance.LogCritical($"null actions for {actionFactory.Title}:{actionFactory.FactoryId}", $"{actionFactory.Title}{actionFactory.FactoryId}");
                    continue;
                }
                foreach (IAnalogyCustomAction action in actionFactory.Actions.Where(a => a.Type == AnalogyCustomActionType.BelongsToProvider))
                {
                    BarButtonItem actionBtn = new BarButtonItem
                    {
                        Caption = action.Title,
                        RibbonStyle = RibbonItemStyles.All,
                    };
                    groupActionSource.ItemLinks.Add(actionBtn);
                    actionBtn.ImageOptions.Image = action.SmallImage ?? Resources.PageSetup_32x32;
                    actionBtn.ImageOptions.LargeImage = action.LargeImage ?? Resources.PageSetup_32x32;
                    actionBtn.ItemClick += (sender, e) => { action.Action(); };
                }
            }

            AddUserControls(ribbonPage, fc.UserControlsFactories);
            AddGraphPlotter(ribbonPage, fc.GraphPlotter);
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
            aboutBtn.ItemClick += (sender, e) => { new AboutDataSourceBox(fc.Factory, FactoriesManager).ShowDialog(this); };
            ribbonPage.Groups.Add(groupInfoSource);
        }
        private void AddFactorySettings(FactoryContainer fc, RibbonPage ribbonPage)
        {
            if (fc.FactorySetting.Status == DataProviderFactoryStatus.Disabled || !fc.DataProvidersSettings.Any())
            {
                return;
            }

            RibbonPageGroup groupSettings = new RibbonPageGroup("Settings") { Alignment = RibbonPageGroupAlignment.Far };

            foreach (var providerSetting in fc.DataProvidersSettings)
            {
                providerSetting.CreateUserControl(ServicesProvider.Instance.GetService<ILogger>());
                BarButtonItem settingsBtn = new BarButtonItem
                {
                    Caption = providerSetting.Title,
                    RibbonStyle = RibbonItemStyles.All,
                };
                groupSettings.ItemLinks.Add(settingsBtn);
                settingsBtn.ImageOptions.Image = providerSetting.SmallImage ?? Resources.Technology_16x16;
                settingsBtn.ImageOptions.LargeImage = providerSetting.LargeImage ?? Resources.Technology_32x32;
                XtraForm form = new DataProviderSettingsForm();
                //var imageSmall = FactoriesManager.GetSmallImage(providerSetting.Id);
                //if (imageSmall != null)
                //    form.Icon = imageSmall;
                form.Text = "Data Provider Settings: " + providerSetting.Title;
                form.Controls.Add(providerSetting.DataProviderSettings);
                providerSetting.DataProviderSettings.Dock = DockStyle.Fill;
                form.Closing += async (s, e) => { await providerSetting.SaveSettingsAsync(); };
                settingsBtn.ItemClick += (sender, e) => { form.ShowDialog(this); };
            }
            ribbonPage.Groups.Add(groupSettings);
        }
        private void CreateOnlineAndOfflineProviders(IAnalogyFactory factory, IAnalogyDataProvidersFactory dataSourceFactory, RibbonPage ribbonPage)
        {
            RibbonPageGroup ribbonPageGroup = new RibbonPageGroup($"Data Provider: {dataSourceFactory.Title}") { AllowTextClipping = false };
            ribbonPage.Groups.Add(ribbonPageGroup);

            if (Settings.CombineOnlineProviders)
            {
                AddCombinedRealTimeDataSources(ribbonPage, dataSourceFactory);
            }
            else
            {
                AddFlatRealTimeDataSources(ribbonPage, dataSourceFactory);
            }
            AddSingleDataSources(factory, ribbonPage, dataSourceFactory, ribbonPageGroup);
            AddOfflineDataSource(factory, ribbonPage, dataSourceFactory, ribbonPageGroup);
        }

        private void AddUserControls(RibbonPage ribbonPage, List<IAnalogyCustomUserControlsFactory> userControls)
        {
            if (userControls.Count == 0)
            {
                return;
            }

            foreach (var userControlFactory in userControls)
            {
                RibbonPageGroup ribbonPageGroup = new RibbonPageGroup(userControlFactory.Title)
                { AllowTextClipping = false };
                ribbonPage.Groups.Add(ribbonPageGroup);
                foreach (var userControl in userControlFactory.UserControls)
                {
                    BarButtonItem userControlBtn = new BarButtonItem();
                    ribbonPageGroup.ItemLinks.Add(userControlBtn);
                    userControlBtn.ImageOptions.Image = userControl.SmallImage ?? Resources.userControls16x16;
                    userControlBtn.ImageOptions.LargeImage = userControl.LargeImage ?? Resources.UserControls32x32;
                    userControlBtn.RibbonStyle = RibbonItemStyles.All;
                    userControlBtn.Caption = userControl.Title;
                    if (userControl.ToolTip != null)
                    {
                        SuperToolTip toolTip = new SuperToolTip();
                        // Create an object to initialize the SuperToolTip.
                        SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
                        args.Title.Text = userControl.ToolTip.Title;
                        args.Contents.Text = userControl.ToolTip.Content;
                        args.Contents.Image = userControl.ToolTip.SmallImage;
                        toolTip.Setup(args);
                        userControlBtn.SuperTip = toolTip;
                    }
                    async Task<bool> OpenUserControl()
                    {
                        userControlBtn.Enabled = false;
                        OpenedWindows++;
                        //plotterBtn.ImageOptions.Image = imageSmallOnline ?? Resources.Database_on;
                        var page = dockManager1.AddPanel(DockingStyle.Float);
                        await userControl.InitializeUserControl(page, ServicesProvider.Instance.GetService<ILogger>());
                        page.DockedAsTabbedDocument = true;
                        page.Tag = ribbonPage;
                        page.Controls.Add(userControl.UserControl);
                        ribbonControlMain.SelectedPage = ribbonPage;
                        userControl.UserControl.Dock = DockStyle.Fill;
                        page.Text = $"{userControl.Title} #{OpenedWindows}";
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
                    userControlBtn.ItemClick += async (s, be) => await OpenUserControl();
                }
            }
        }

        private void AddGraphPlotter(RibbonPage ribbonPage, List<IAnalogyPlotting> graphPlotters)
        {
            if (graphPlotters.Count == 0)
            {
                return;
            }
            RibbonPageGroup ribbonPageGroup = new RibbonPageGroup("Graph Plotter") { AllowTextClipping = false };
            ribbonPage.Groups.Add(ribbonPageGroup);

            foreach (var plot in graphPlotters)
            {
                BarButtonItem plotterBtn = new BarButtonItem();
                ribbonPageGroup.ItemLinks.Add(plotterBtn);
                plotterBtn.ImageOptions.Image = Resources.Line_16x16;
                plotterBtn.ImageOptions.LargeImage = Resources.Line_32x32;
                plotterBtn.RibbonStyle = RibbonItemStyles.All;
                plotterBtn.Caption = plot.Title;

                async Task<bool> OpenPlotter()
                {
                    plotterBtn.Enabled = false;
                    OpenedWindows++;
                    var plotInteractor = AnalogyPlottingManager.Instance.GetOrCreateInteractor(plot);
                    await plot.InitializePlotting(plotInteractor, ServicesProvider.Instance.GetService<ILogger>());
                    var plotterUC = new PlottingUC(plot, plotInteractor);
                    var page = dockManager1.AddPanel(DockingStyle.Float);
                    page.DockedAsTabbedDocument = true;
                    page.Tag = ribbonPage;
                    page.Controls.Add(plotterUC);
                    ribbonControlMain.SelectedPage = ribbonPage;
                    plotterUC.Dock = DockStyle.Fill;
                    page.Text = $"{plot.Title} #{OpenedWindows}";
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

                plotterBtn.ItemClick += async (s, be) => await OpenPlotter();
            }
        }

        private void AddFlatRealTimeDataSources(RibbonPage ribbonPage, IAnalogyDataProvidersFactory dataSourceFactory)
        {
            var realTimes = dataSourceFactory.DataProviders.Where(f => f is IAnalogyRealTimeDataProvider)
                .Cast<IAnalogyRealTimeDataProvider>().ToList();
            var serverSide = dataSourceFactory.DataProviders.Where(f => f is IAnalogyProviderSidePagingProvider)
                .Cast<IAnalogyProviderSidePagingProvider>().ToList();
            if (realTimes.Count == 0 && serverSide.Count == 0)
            {
                return;
            }

            string title = !string.IsNullOrEmpty(dataSourceFactory.Title)
                ? dataSourceFactory.Title
                : "real time Provider";
            RibbonPageGroup ribbonPageGroup = new RibbonPageGroup($"Real Time Providers: {title}");
            ribbonPageGroup.AllowTextClipping = false;
            ribbonPage.Groups.Insert(0, ribbonPageGroup);

            foreach (var realTime in realTimes)
            {
                BarButtonItem realTimeBtn = new BarButtonItem();
                ribbonPageGroup.ItemLinks.Add(realTimeBtn);
                realTimeBtn.ImageOptions.Image = realTime.ConnectedSmallImage ?? Resources.Database_on;
                realTimeBtn.ImageOptions.LargeImage = realTime.ConnectedLargeImage ?? Resources.Database_on;

                realTimeBtn.RibbonStyle = RibbonItemStyles.All;
                realTimeBtn.Caption = (!string.IsNullOrEmpty(realTime.OptionalTitle)
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
                        OpenedWindows++;
                        //realTimeBtn.ImageOptions.Image = realTime.DisconnectedSmallImage ?? Resources.Database_off;
                        //realTimeBtn.ImageOptions.LargeImage = realTime.DisconnectedLargeImage ?? Resources.Database_off;
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
                            // realTimeBtn.ImageOptions.Image = realTime.ConnectedSmallImage ?? Resources.Database_on;
                            // realTimeBtn.ImageOptions.LargeImage = realTime.ConnectedLargeImage ?? Resources.Database_on;
                        }

                        var page = dockManager1.AddPanel(DockingStyle.Float);
                        page.DockedAsTabbedDocument = true;
                        page.Tag = ribbonPage;
                        page.Controls.Add(onlineUC);
                        ribbonControlMain.SelectedPage = ribbonPage;
                        onlineUC.Dock = DockStyle.Fill;
                        page.Text = $"{onlineTitle} #{OpenedWindows} ({dataSourceFactory.Title})";
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

                realTimeBtn.ItemClick += async (s, be) => await OpenRealTime();
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
            AddServerSideDataSources(ribbonPage, dataSourceFactory, ribbonPageGroup);
        }

        private void AddCombinedRealTimeDataSources(RibbonPage ribbonPage, IAnalogyDataProvidersFactory dataSourceFactory)
        {
            var realTimes = dataSourceFactory.DataProviders.Where(f => f is IAnalogyRealTimeDataProvider)
                .Cast<IAnalogyRealTimeDataProvider>().ToList();
            var serverSide = dataSourceFactory.DataProviders.Where(f => f is IAnalogyProviderSidePagingProvider)
                .Cast<IAnalogyProviderSidePagingProvider>().ToList();
            if (realTimes.Count == 0 && serverSide.Count == 0)
            {
                return;
            }
            string title = !string.IsNullOrEmpty(dataSourceFactory.Title)
                ? dataSourceFactory.Title
                : "real time Provider";
            RibbonPageGroup group = new RibbonPageGroup($"Real Time Providers: {title}");
            group.AllowTextClipping = false;
            ribbonPage.Groups.Insert(0, group);
            if (realTimes.Count == 1)
            {
                AddSingleRealTimeDataSource(ribbonPage, realTimes.First(), dataSourceFactory.Title, group);
            }
            else
            {
                BarSubItem realTimeMenu = new BarSubItem();
                group.ItemLinks.Add(realTimeMenu);

                realTimeMenu.ImageOptions.Image = Resources.Database_on;
                realTimeMenu.RibbonStyle = RibbonItemStyles.All;
                realTimeMenu.Caption = "Real Time Logs";

                foreach (var realTime in realTimes)
                {
                    BarButtonItem realTimeBtn = new BarButtonItem();
                    realTimeMenu.ItemLinks.Add(realTimeBtn);
                    realTimeBtn.ImageOptions.Image = realTime.ConnectedSmallImage ?? Resources.Database_on;
                    realTimeBtn.ImageOptions.LargeImage = realTime.ConnectedLargeImage ?? Resources.Database_on;

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
                            OpenedWindows++;
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
                                //realTimeBtn.ImageOptions.Image = imageSmallOffline ?? Resources.Database_off;
                            }

                            var page = dockManager1.AddPanel(DockingStyle.Float);
                            page.DockedAsTabbedDocument = true;
                            page.Tag = ribbonPage;
                            page.Controls.Add(onlineUC);
                            ribbonControlMain.SelectedPage = ribbonPage;
                            onlineUC.Dock = DockStyle.Fill;
                            page.Text = $"{onlineTitle} #{OpenedWindows} ({dataSourceFactory.Title})";
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

                    realTimeBtn.ItemClick += async (s, be) => await OpenRealTime();
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
            AddServerSideDataSources(ribbonPage, dataSourceFactory, group);
        }

        private void AddSingleDataSources(IAnalogyFactory primaryFactory, RibbonPage ribbonPage, IAnalogyDataProvidersFactory dataSourceFactory, RibbonPageGroup group)
        {
            var singles = dataSourceFactory.DataProviders.Where(f => f is IAnalogySingleDataProvider ||
                                                                      f is IAnalogySingleFileDataProvider).ToList();

            foreach (var single in singles)
            {
                BarButtonItem singleBtn = new BarButtonItem();
                group.ItemLinks.Add(singleBtn);
                var imageLarge = FactoriesManager.GetLargeImage(single.Id);
                var imageSmall = FactoriesManager.GetSmallImage(single.Id);

                singleBtn.ImageOptions.LargeImage = imageLarge ?? Resources.Single32x32;
                singleBtn.ImageOptions.Image = imageSmall ?? Resources.Single16x16;
                singleBtn.RibbonStyle = RibbonItemStyles.All;
                singleBtn.Caption = !string.IsNullOrEmpty(single.OptionalTitle)
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

                singleBtn.ItemClick += async (sender, e) =>
                {
                    OpenedWindows++;
                    await FactoriesManager.InitializeIfNeeded(single);
                    CancellationTokenSource cts = new CancellationTokenSource();
                    LocalLogFilesUC offlineUC = new LocalLogFilesUC(single, cts);
                    var page = dockManager1.AddPanel(DockingStyle.Float);
                    page.DockedAsTabbedDocument = true;
                    page.Tag = ribbonPage;
                    page.Controls.Add(offlineUC);
                    offlineUC.Dock = DockStyle.Fill;
                    page.Text = $"{offlineTitle} #{OpenedWindows} ({single.OptionalTitle})";
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

        private void AddOfflineDataSource(IAnalogyFactory primaryFactory, RibbonPage ribbonPage, IAnalogyDataProvidersFactory factory, RibbonPageGroup group)
        {
            var offlineProviders = factory.DataProviders.Where(f => f is IAnalogyOfflineDataProvider)
                .Cast<IAnalogyOfflineDataProvider>().ToList();

            if (!offlineProviders.Any())
            {
                return;
            }

            if (offlineProviders.Count == 1)
            {
                var offlineAnalogy = offlineProviders.First();
                string optionalText = !string.IsNullOrEmpty(offlineAnalogy.OptionalTitle)
                    ? " for " + offlineAnalogy.OptionalTitle
                    : string.Empty;
                RibbonPageGroup groupOfflineFileTools = new RibbonPageGroup($"File Tools");
                groupOfflineFileTools.AllowTextClipping = false;
                ribbonPage.Groups.Add(groupOfflineFileTools);
                var tools = new BarSubItem();
                tools.Caption = "File Tools";
                tools.RibbonStyle = RibbonItemStyles.All;
                tools.ImageOptions.LargeImage = Resources.FileAction_32x32;
                groupOfflineFileTools.ItemLinks.Add(tools);
                AddSingleOfflineDataSource(primaryFactory, ribbonPage, offlineAnalogy, factory, group, tools);
            }
            else
            {
                AddMultiplesOfflineDataSource(primaryFactory, ribbonPage, offlineProviders, factory, group);
            }
        }
        private void AddMultiplesOfflineDataSource(IAnalogyFactory primaryFactory, RibbonPage ribbonPage,
            List<IAnalogyOfflineDataProvider> offlineProviders, IAnalogyDataProvidersFactory factory, RibbonPageGroup group)
        {
            Guid factoryId = factory.FactoryId;
            string factoryTitle = factory.Title;
            var containers = FactoriesManager.GetFactoryContainer(factoryId);
            IAnalogyImages? images = containers.Count == 1 ? containers.First().Images?.FirstOrDefault() : null;

            #region Actions
            async Task OpenOffline(string titleOfDataSource, IAnalogyOfflineDataProvider dataProvider, string initialFolder,
                string[] files = null)
            {
                OpenedWindows++;
                await FactoriesManager.InitializeIfNeeded(dataProvider);
                string fullTitle = $"{offlineTitle} #{OpenedWindows} ({titleOfDataSource})";
                UserControl offlineUC = new LocalLogFilesUC(dataProvider, files, initialFolder, title: fullTitle);
                var page = dockManager1.AddPanel(DockingStyle.Float);
                page.DockedAsTabbedDocument = true;
                page.Tag = ribbonPage;
                page.Controls.Add(offlineUC);
                offlineUC.Dock = DockStyle.Fill;
                page.Text = fullTitle;
                dockManager1.ActivePanel = page;
            }

            async Task OpenExternalDataSource(string titleOfDataSource, IAnalogyOfflineDataProvider analogy)
            {
                OpenedWindows++;
                await FactoriesManager.InitializeIfNeeded(analogy);
                var ClientServerUCLog = new ClientServerUCLog(analogy);
                var page = dockManager1.AddPanel(DockingStyle.Float);
                page.DockedAsTabbedDocument = true;
                page.Tag = ribbonPage;
                page.Controls.Add(ClientServerUCLog);
                ClientServerUCLog.Dock = DockStyle.Fill;
                page.Text = $"Client/Server logs #{OpenedWindows}. {titleOfDataSource}";
                dockManager1.ActivePanel = page;
            }

            async Task OpenFilePooling(string titleOfDataSource, IAnalogyOfflineDataProvider dataProvider,
                string initialFolder, string file, string initialFile)
            {
                OpenedWindows++;
                await FactoriesManager.InitializeIfNeeded(dataProvider);
                UserControl filepoolingUC = new FilePoolingUCLogs(Settings, FileProcessingManager, dataProvider, file, initialFile, initialFolder);
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
                page.Text = $"{filePoolingTitle} #{filePooling++} ({titleOfDataSource})";
                dockManager1.ActivePanel = page;

                dockManager1.ClosedPanel += OnXtcLogsOnControlRemoved;
            }

            #endregion
            //recent bar
            BarSubItem recentBar = new BarSubItem();
            recentBar.Caption = "Recent Files";
            recentBar.ImageOptions.Image = images?.GetSmallRecentFilesImage(factoryId) ?? Resources.RecentlyUse_16x16;
            recentBar.ImageOptions.LargeImage = images?.GetLargeRecentFilesImage(factoryId) ?? Resources.RecentlyUse_32x32;
            recentBar.RibbonStyle = RibbonItemStyles.All;

            //local folder
            BarSubItem folderBar = new BarSubItem();
            folderBar.Caption = "Open Folder";
            folderBar.ImageOptions.Image = images?.GetSmallOpenFolderImage(factoryId) ?? Resources.Open2_32x32;
            folderBar.ImageOptions.LargeImage = images?.GetLargeOpenFolderImage(factoryId) ?? Resources.Open2_32x32;
            folderBar.RibbonStyle = RibbonItemStyles.All;
            group.ItemLinks.Add(folderBar);

            foreach (var dataProvider in offlineProviders)
            {
                string? directory = (!string.IsNullOrEmpty(dataProvider.InitialFolderFullPath) &&
                                     Directory.Exists(dataProvider.InitialFolderFullPath))
                    ? dataProvider.InitialFolderFullPath
                    : Environment.CurrentDirectory;
                //add local folder button:
                BarButtonItem btn = new BarButtonItem { Caption = directory };
                btn.ItemClick += async (s, be) =>
                {
                    await OpenOffline(dataProvider.OptionalTitle, dataProvider, directory);
                };
                folderBar.AddItem(btn);
            }

            //add recent folders
            //recent bar
            BarSubItem recentFolders = new BarSubItem { Caption = "Recent Folders" };
            recentFolders.ImageOptions.Image = images?.GetSmallRecentFoldersImage(factoryId) ?? Resources.LoadFrom_16x16;
            recentFolders.ImageOptions.LargeImage = images?.GetLargeRecentFoldersImage(factoryId) ?? Resources.LoadFrom_32x32;
            recentFolders.RibbonStyle = RibbonItemStyles.All;
            group.ItemLinks.Add(recentFolders);
            foreach (var dataProvider in offlineProviders)
            {
                BarSubItem btnFolder = new BarSubItem { Caption = dataProvider.OptionalTitle };
                recentFolders.AddItem(btnFolder);
                foreach (var path in Settings.GetRecentFolders(dataProvider.Id))
                {  //add local folder button:
                    if (!string.IsNullOrEmpty(path.Path) && Directory.Exists(path.Path))
                    {
                        BarButtonItem btn = new BarButtonItem { Caption = path.Path };
                        btn.ItemClick += async (s, be) =>
                        {
                            await OpenOffline(dataProvider.OptionalTitle, dataProvider, path.Path);
                        };

                        btnFolder.AddItem(btn);
                    }
                }
            }

            //add Files open buttons
            if (offlineProviders.Any(i => !string.IsNullOrEmpty(i.FileOpenDialogFilters)))
            {
                if (Settings.CombineOfflineProviders)
                {
                    //add Open files entry
                    BarSubItem openFiles = new BarSubItem();
                    openFiles.Caption = "Open File";
                    group.ItemLinks.Insert(0, openFiles);
                    openFiles.ImageOptions.Image = Resources.Article_16x16;
                    openFiles.ImageOptions.LargeImage = Resources.Article_32x32;
                    openFiles.RibbonStyle = RibbonItemStyles.All;

                    foreach (var dataProvider in offlineProviders)
                    {
                        if (!string.IsNullOrEmpty(dataProvider.FileOpenDialogFilters))
                        {
                            BarButtonItem btnOpenFile = new BarButtonItem { Caption = $"{factoryTitle} ({dataProvider.OptionalTitle})" };
                            btnOpenFile.ItemClick += async (sender, e) =>
                            {
                                OpenFileDialog openFileDialog1 = new OpenFileDialog
                                {
                                    Filter = Utils.GetOpenFilter(dataProvider.FileOpenDialogFilters),
                                    Title = @"Open Files",
                                    Multiselect = true,
                                };
                                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    await OpenOffline(dataProvider.OptionalTitle, dataProvider,
                                        dataProvider.InitialFolderFullPath, openFileDialog1.FileNames);
                                    AddRecentFiles(ribbonPage, recentBar, dataProvider, dataProvider.OptionalTitle,
                                        openFileDialog1.FileNames.ToList());
                                }
                            };
                            openFiles.AddItem(btnOpenFile);
                        }
                        else
                        {
                            IAnalogyNotification notification = new AnalogyNotification(factoryId,
                                "Missing File Open Dialog Filter",
                                $"{factoryTitle} has offline data provider without File Open Dialog Filter.{Environment.NewLine}You can set a filter in the data provider settings or report this to the developer.{Environment.NewLine}Filter format example: 'log files (*.log)|*.log|clef files (*.clef)|*.clef'"
                                , AnalogyLogLevel.Error, primaryFactory.LargeImage, 5, null);
                            NotificationManager.RaiseNotification(notification, true);
                        }
                    }
                }
                else
                {
                    foreach (var dataProvider in offlineProviders)
                    {
                        if (!string.IsNullOrEmpty(dataProvider.FileOpenDialogFilters))
                        {
                            //add Open files entry
                            BarButtonItem btnOpenFile = new BarButtonItem();
                            btnOpenFile.Caption = !string.IsNullOrEmpty(dataProvider.OptionalTitle) ? $"{dataProvider.OptionalTitle}" : $"{factoryTitle})";
                            group.ItemLinks.Add(btnOpenFile);
                            btnOpenFile.ImageOptions.Image = Resources.Article_16x16;
                            btnOpenFile.ImageOptions.LargeImage = Resources.Article_32x32;
                            btnOpenFile.RibbonStyle = RibbonItemStyles.All;

                            btnOpenFile.ItemClick += async (sender, e) =>
                            {
                                OpenFileDialog openFileDialog1 = new OpenFileDialog
                                {
                                    Filter = Utils.GetOpenFilter(dataProvider.FileOpenDialogFilters),
                                    Title = @"Open Files",
                                    Multiselect = true,
                                };
                                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    await OpenOffline(dataProvider.OptionalTitle, dataProvider,
                                        dataProvider.InitialFolderFullPath, openFileDialog1.FileNames);
                                    AddRecentFiles(ribbonPage, recentBar, dataProvider, dataProvider.OptionalTitle,
                                        openFileDialog1.FileNames.ToList());
                                }
                            };
                        }
                        else
                        {
                            IAnalogyNotification notification = new AnalogyNotification(factoryId,
                                "Missing File Open Dialog Filter",
                                $"{factoryTitle} has offline data provider without File Open Dialog Filter.{Environment.NewLine}You can set a filter in the data provider settings or report this to the developer.{Environment.NewLine}Filter format example: 'log files (*.log)|*.log|clef files (*.clef)|*.clef'"
                                , AnalogyLogLevel.Error, primaryFactory.LargeImage, 5, null);
                            NotificationManager.RaiseNotification(notification, true);
                        }
                    }
                }

                //add Open Pooled file entry
                BarSubItem filePoolingBtn = new BarSubItem();
                string caption = "File Pooling (Monitoring)";
                filePoolingBtn.Caption = caption;
                filePoolingBtn.SuperTip =
                    Utils.GetSuperTip(caption, "Monitor file for changes in real time and reload the file automatically");
                group.ItemLinks.Insert(1, filePoolingBtn);
                filePoolingBtn.ImageOptions.Image = images?.GetSmallFilePoolingImage(factoryId) ?? Resources.FilePooling_16x16;
                filePoolingBtn.ImageOptions.LargeImage = images?.GetLargeFilePoolingImage(factoryId) ?? Resources.FilePooling_32x32;
                filePoolingBtn.RibbonStyle = RibbonItemStyles.All;

                foreach (var dataProvider in offlineProviders)
                {
                    BarButtonItem btnOpenFile = new BarButtonItem { Caption = $"{factoryTitle} ({dataProvider.OptionalTitle})" };
                    btnOpenFile.ItemClick += async (sender, e) =>
                    {
                        OpenFileDialog openFileDialog1 = new OpenFileDialog
                        {
                            Filter = dataProvider.FileOpenDialogFilters,
                            Title = @"Open File for pooling",
                            Multiselect = false,
                        };
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            EditFilePooling efp = new EditFilePooling(openFileDialog1.FileName);
                            efp.ShowDialog(this);
                            await OpenFilePooling(dataProvider.OptionalTitle, dataProvider,
                                dataProvider.InitialFolderFullPath, efp.Filter, openFileDialog1.FileName);
                            AddRecentFiles(ribbonPage, recentBar, dataProvider, dataProvider.OptionalTitle,
                                new List<string> { openFileDialog1.FileName });
                        }
                    };
                    filePoolingBtn.AddItem(btnOpenFile);
                }
            }

            //add recent
            group.ItemLinks.Insert(2, recentBar);
            foreach (var dataProvider in offlineProviders)
            {
                var recents = Settings.GetRecentFiles(dataProvider.Id)
                    .Select(itm => itm.FileName).ToList();
                AddRecentFiles(ribbonPage, recentBar, dataProvider, dataProvider.OptionalTitle, recents);
            }

            BarSubItem externalSources = new BarSubItem();
            externalSources.Caption = "Known Locations";
            externalSources.RibbonStyle = RibbonItemStyles.All;
            group.ItemLinks.Add(externalSources);
            externalSources.ImageOptions.Image = images?.GetSmallKnownLocationsImage(factoryId) ?? Resources.ServerMode_16x16;
            externalSources.ImageOptions.LargeImage = images?.GetLargeKnownLocationsImage(factoryId) ?? Resources.ServerMode_32x32;
            //add client/server  button:
            foreach (var dataProvider in offlineProviders)
            {
                BarButtonItem btnOpenLocation = new BarButtonItem { Caption = $"{factoryTitle} ({dataProvider.OptionalTitle})" };
                btnOpenLocation.ItemClick += async (sender, e) =>
                {
                    await OpenExternalDataSource(dataProvider.OptionalTitle, dataProvider);
                };
                externalSources.AddItem(btnOpenLocation);
            }

            //add tools

            RibbonPageGroup groupOfflineFileTools = new RibbonPageGroup($"File Tools");
            groupOfflineFileTools.AllowTextClipping = false;
            ribbonPage.Groups.Add(groupOfflineFileTools);

            var tools = new BarSubItem();
            tools.Caption = "File Tools";
            tools.RibbonStyle = RibbonItemStyles.All;
            tools.ImageOptions.LargeImage = Resources.FileAction_32x32;
            groupOfflineFileTools.ItemLinks.Add(tools);

            BarSubItem searchFiles = new BarSubItem();
            searchFiles.Caption = "Search in Files";
            tools.ItemLinks.Add(searchFiles);
            searchFiles.ImageOptions.Image = images?.GetSmallSearchImage(factoryId) ?? Resources.Lookup_Reference_32x32;
            searchFiles.ImageOptions.LargeImage = images?.GetLargeSearchImage(factoryId) ?? Resources.Lookup_Reference_32x32;
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
            tools.ItemLinks.Add(combineFiles);
            combineFiles.ImageOptions.Image = images?.GetSmallCombineLogsImage(factoryId) ?? Resources.Sutotal_32x32;
            combineFiles.ImageOptions.LargeImage = images?.GetLargeCombineLogsImage(factoryId) ?? Resources.Sutotal_32x32;
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
            tools.ItemLinks.Add(compareFiles);
            compareFiles.ImageOptions.Image = images?.GetSmallCompareLogsImage(factoryId) ?? Resources.TwoColumns;
            compareFiles.ImageOptions.LargeImage = images?.GetLargeCompareLogsImage(factoryId) ?? Resources.TwoColumns;
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

        private void AddSingleOfflineDataSource(IAnalogyFactory primaryFactory, RibbonPage ribbonPage, IAnalogyOfflineDataProvider offlineAnalogy,
            IAnalogyDataProvidersFactory factory, RibbonPageGroup group, BarSubItem groupOfflineFileTools)
        {
            Guid factoryId = factory.FactoryId;
            string title = factory.Title;
            #region actions
            async Task OpenOffline(string titleOfDataSource, string initialFolder, string[] files = null)
            {
                OpenedWindows++;
                await FactoriesManager.InitializeIfNeeded(offlineAnalogy);
                string fullTitle = $"{offlineTitle} #{OpenedWindows} ({titleOfDataSource})";
                UserControl offlineUC = new LocalLogFilesUC(offlineAnalogy, files, initialFolder, title: fullTitle);
                var page = dockManager1.AddPanel(DockingStyle.Float);
                page.DockedAsTabbedDocument = true;
                page.Tag = ribbonPage;
                page.Controls.Add(offlineUC);
                offlineUC.Dock = DockStyle.Fill;
                page.Text = fullTitle;
                dockManager1.ActivePanel = page;
            }

            async Task OpenExternalDataSource(string titleOfDataSource, IAnalogyOfflineDataProvider analogy)
            {
                OpenedWindows++;
                await FactoriesManager.InitializeIfNeeded(analogy);
                var ClientServerUCLog = new ClientServerUCLog(analogy);
                var page = dockManager1.AddPanel(DockingStyle.Float);
                page.DockedAsTabbedDocument = true;
                page.Tag = ribbonPage;
                page.Controls.Add(ClientServerUCLog);
                ClientServerUCLog.Dock = DockStyle.Fill;
                page.Text = $"Client/Server logs #{OpenedWindows}. {titleOfDataSource}";
                dockManager1.ActivePanel = page;
            }

            void OpenFilePooling(string titleOfDataSource, string initialFolder, string file, string initialFile)
            {
                OpenedWindows++;
                string fullTitle = $"{filePoolingTitle} #{filePooling++} ({titleOfDataSource})";
                UserControl filepoolingUC = new FilePoolingUCLogs(Settings, FileProcessingManager, offlineAnalogy, file, initialFile, initialFolder, title: fullTitle);
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
                page.Text = fullTitle;
                dockManager1.ActivePanel = page;
                dockManager1.ClosedPanel += OnXtcLogsOnControlRemoved;
            }
            #endregion
            var containers = FactoriesManager.GetFactoryContainer(offlineAnalogy.Id);
            IAnalogyImages? images = containers.Count == 1 ? containers.First().Images?.FirstOrDefault() : null;

            var preDefinedFolderExist = !string.IsNullOrEmpty(offlineAnalogy.InitialFolderFullPath) &&
                                        Directory.Exists(offlineAnalogy.InitialFolderFullPath);
            //add specific folder button:
            if (preDefinedFolderExist)
            {
                string specificDirectory = offlineAnalogy.InitialFolderFullPath!;
                BarButtonItem specificLocalFolder = new BarButtonItem();
                specificLocalFolder.Caption = "Open Pre-defined Folder";
                specificLocalFolder.RibbonStyle = RibbonItemStyles.All;
                group.ItemLinks.Add(specificLocalFolder);
                specificLocalFolder.ImageOptions.Image = images?.GetSmallOpenFolderImage(factoryId) ?? Resources.OpenFolder_16x16;
                specificLocalFolder.ImageOptions.LargeImage = images?.GetLargeOpenFolderImage(factoryId) ?? Resources.OpenFolder_32x32;
                specificLocalFolder.ItemClick += (sender, e) => { OpenOffline(title, specificDirectory); };
            }

            //add local folder button:
            BarButtonItem localfolder = new BarButtonItem();
            localfolder.Caption = "Open Folder Selection";
            localfolder.RibbonStyle = RibbonItemStyles.All;
            group.ItemLinks.Add(localfolder);
            localfolder.ImageOptions.Image = images?.GetSmallOpenFolderImage(factoryId) ?? Resources.OpenFolder_16x16;
            localfolder.ImageOptions.LargeImage = images?.GetLargeOpenFolderImage(factoryId) ?? Resources.OpenFolder_32x32;
            localfolder.ItemClick += async (sender, e) =>
            {
                using (var folderBrowserDialog = new XtraFolderBrowserDialog { ShowNewFolderButton = false })
                {
                    folderBrowserDialog.SelectedPath = preDefinedFolderExist ? offlineAnalogy.InitialFolderFullPath : Environment.CurrentDirectory;
                    DialogResult result = folderBrowserDialog.ShowDialog(); // Show the dialog.
                    if (result == DialogResult.OK) // Test result.
                    {
                        if (!string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
                        {
                            await OpenOffline(title, folderBrowserDialog.SelectedPath);
                        }
                    }
                }
            };

            //recent folder
            //recent bar
            BarSubItem recentFolders = new BarSubItem { Caption = "Recent Folders" };
            recentFolders.ImageOptions.Image = images?.GetSmallRecentFoldersImage(factoryId) ?? Resources.LoadFrom_16x16;
            recentFolders.ImageOptions.LargeImage = images?.GetLargeRecentFoldersImage(factoryId) ?? Resources.LoadFrom_32x32;
            recentFolders.RibbonStyle = RibbonItemStyles.All;
            group.ItemLinks.Add(recentFolders);
            foreach (var path in Settings.GetRecentFolders(offlineAnalogy.Id))
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
            recentBar.ImageOptions.Image = images?.GetSmallRecentFilesImage(factoryId) ?? Resources.RecentlyUse_16x16;
            recentBar.ImageOptions.LargeImage = images?.GetLargeRecentFilesImage(factoryId) ?? Resources.RecentlyUse_32x32;
            recentBar.RibbonStyle = RibbonItemStyles.Large | RibbonItemStyles.SmallWithText |
                                    RibbonItemStyles.SmallWithoutText;
            //add Files open buttons
            if (!string.IsNullOrEmpty(offlineAnalogy.FileOpenDialogFilters))
            {
                //add Open files entry
                BarButtonItem openFiles = new BarButtonItem();
                openFiles.Caption = "Open File";
                group.ItemLinks.Insert(0, openFiles);
                openFiles.ImageOptions.Image = offlineAnalogy.SmallImage ?? Resources.Article_16x16;
                openFiles.ImageOptions.LargeImage = offlineAnalogy.LargeImage ?? Resources.Article_32x32;
                openFiles.RibbonStyle = RibbonItemStyles.All;
                openFiles.ItemClick += (sender, e) =>
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog
                    {
                        Filter = Utils.GetOpenFilter(offlineAnalogy.FileOpenDialogFilters),
                        Title = @"Open Files",
                        Multiselect = true,
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
                string caption = "File Pooling (Monitoring)";
                filePoolingBtn.Caption = caption;
                filePoolingBtn.SuperTip =
                    Utils.GetSuperTip(caption, "Monitor file for changes in real time and reload the file automatically");
                group.ItemLinks.Insert(1, filePoolingBtn);
                filePoolingBtn.ImageOptions.Image = images?.GetSmallFilePoolingImage(factoryId) ?? Resources.FilePooling_16x16;
                filePoolingBtn.ImageOptions.LargeImage = images?.GetLargeFilePoolingImage(factoryId) ?? Resources.FilePooling_32x32;
                filePoolingBtn.RibbonStyle = RibbonItemStyles.All;
                filePoolingBtn.ItemClick += (sender, e) =>
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
                        OpenFilePooling(title, offlineAnalogy.InitialFolderFullPath, efp.Filter, openFileDialog1.FileName);
                        AddRecentFiles(ribbonPage, recentBar, offlineAnalogy, title,
                            new List<string> { openFileDialog1.FileName });
                    }
                };
            }
            else
            {
                IAnalogyNotification notification = new AnalogyNotification(factoryId,
                    "Missing File Open Dialog Filter",
                    $"{title} has offline data provider without File Open Dialog Filter.{Environment.NewLine}You can set a filter in the data provider settings or report this to the developer.{Environment.NewLine}Filter format example: 'log files (*.log)|*.log|clef files (*.clef)|*.clef'"
                    , AnalogyLogLevel.Error, primaryFactory.LargeImage, 5, null);
                NotificationManager.RaiseNotification(notification, true);
            }

            //add recent
            group.ItemLinks.Insert(2, recentBar);
            var recents = Settings.GetRecentFiles(offlineAnalogy.Id)
                .Select(itm => itm.FileName).ToList();
            AddRecentFiles(ribbonPage, recentBar, offlineAnalogy, title, recents);

            //add client/server  button:
            BarButtonItem externalSources = new BarButtonItem();
            externalSources.Caption = "Known Locations";
            externalSources.RibbonStyle = RibbonItemStyles.All;
            group.ItemLinks.Add(externalSources);
            externalSources.ImageOptions.Image = images?.GetSmallKnownLocationsImage(factoryId) ?? Resources.ServerMode_16x16;
            externalSources.ImageOptions.LargeImage = images?.GetLargeKnownLocationsImage(factoryId) ?? Resources.ServerMode_32x32;
            externalSources.ItemClick += async (sender, e) =>
            {
                await OpenExternalDataSource(title, offlineAnalogy);
            };

            //add tools
            BarButtonItem searchFiles = new BarButtonItem();
            searchFiles.Caption = "Search in Files";
            groupOfflineFileTools.ItemLinks.Add(searchFiles);
            searchFiles.ImageOptions.Image = images?.GetSmallSearchImage(offlineAnalogy.Id) ?? Resources.Lookup_Reference_32x32;
            searchFiles.ImageOptions.LargeImage = images?.GetLargeSearchImage(offlineAnalogy.Id) ?? Resources.Lookup_Reference_32x32;
            searchFiles.RibbonStyle = RibbonItemStyles.All;
            searchFiles.ItemClick += (sender, e) =>
            {
                var search = new SearchForm(offlineAnalogy);
                search.Show(this);
            };

            BarButtonItem combineFiles = new BarButtonItem();
            combineFiles.Caption = "Combine Files";
            groupOfflineFileTools.ItemLinks.Add(combineFiles);
            combineFiles.ImageOptions.Image = images?.GetSmallCombineLogsImage(offlineAnalogy.Id) ?? Resources.Sutotal_32x32;
            combineFiles.ImageOptions.LargeImage = images?.GetLargeCombineLogsImage(offlineAnalogy.Id) ?? Resources.Sutotal_32x32;
            combineFiles.RibbonStyle = RibbonItemStyles.All;
            combineFiles.ItemClick += (sender, e) =>
            {
                var combined = new FormCombineFiles(offlineAnalogy);
                combined.Show(this);
            };

            BarButtonItem compareFiles = new BarButtonItem();
            compareFiles.Caption = "Compare Files";
            groupOfflineFileTools.ItemLinks.Add(compareFiles);
            compareFiles.ImageOptions.Image = images?.GetSmallCompareLogsImage(offlineAnalogy.Id) ?? Resources.TwoColumns;
            compareFiles.ImageOptions.LargeImage = images?.GetLargeCompareLogsImage(offlineAnalogy.Id) ?? Resources.TwoColumns;
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
            var connectedLargeImage = realTime.ConnectedLargeImage;
            var connectedSmallImage = realTime.ConnectedSmallImage;
            realTimeBtn.ImageOptions.LargeImage = connectedLargeImage ?? Resources.Database_on;
            realTimeBtn.ImageOptions.Image = connectedLargeImage ?? Resources.Database_on;
            realTimeBtn.RibbonStyle = RibbonItemStyles.All;
            realTimeBtn.Caption = "Real Time Logs" + (!string.IsNullOrEmpty(realTime.OptionalTitle) ? $" - {realTime.OptionalTitle}" : string.Empty);

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
                    AnalogyLogManager.Instance.LogError("Error during call to canStartReceiving: " + e, nameof(OpenRealTime));
                }

                if (canStartReceiving) //connected
                {
                    OpenedWindows++;
                    var onlineUC = new OnlineUCLogs(realTime, FileProcessingManager);

                    void OnRealTimeOnMessageReady(object sender, AnalogyLogMessageArgs e) =>
                        onlineUC.AppendMessage(e.Message, Environment.MachineName);

                    void OnRealTimeOnOnManyMessagesReady(object sender, AnalogyLogMessagesArgs e) =>
                        onlineUC.AppendMessages(e.Messages, Environment.MachineName);

                    void OnRealTimeDisconnected(object sender, AnalogyDataSourceDisconnectedArgs e)
                    {
                        AnalogyLogMessage disconnected = new AnalogyLogMessage(
                            $"Source {title} Disconnected. Reason: {e.DisconnectedReason}",
                            AnalogyLogLevel.Analogy, AnalogyLogClass.General, title, "Analogy");
                        onlineUC.AppendMessage(disconnected, Environment.MachineName);
                        //realTimeBtn.ImageOptions.Image = disconnectedSmallImage ?? Resources.Database_off;
                        //realTimeBtn.ImageOptions.Image = disconnectedLargeImage ?? Resources.Database_off;
                    }

                    var page = dockManager1.AddPanel(DockingStyle.Float);
                    page.DockedAsTabbedDocument = true;
                    page.Tag = ribbonPage;
                    page.Controls.Add(onlineUC);
                    ribbonControlMain.SelectedPage = ribbonPage;
                    onlineUC.Dock = DockStyle.Fill;
                    page.Text = $"{onlineTitle} #{OpenedWindows} ({title})";
                    realTime.OnMessageReady += OnRealTimeOnMessageReady;
                    realTime.OnManyMessagesReady += OnRealTimeOnOnManyMessagesReady;
                    realTime.OnDisconnected += OnRealTimeDisconnected;
                    await realTime.StartReceiving();
                    dockManager1.ActivePanel = page;

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
                                AnalogyLogManager.Instance.LogError("Error during call to Stop receiving: " + e, nameof(OnXtcLogsOnControlRemoved));
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
        private void AddServerSideDataSources(RibbonPage ribbonPage, IAnalogyDataProvidersFactory dataSourceFactory, RibbonPageGroup group)
        {
            //var serverSides = dataSourceFactory.DataProviders.Where(f => f is IAnalogySingleDataProvider ||
            //                                                          f is IAnalogyProviderSidePagingProvider).ToList();

            //foreach (var single in serverSides)
            //{
            //    BarButtonItem singleBtn = new BarButtonItem();
            //    group.ItemLinks.Add(singleBtn);
            //    var imageLarge = FactoriesManager.GetLargeImage(single.Id);
            //    var imageSmall = FactoriesManager.GetSmallImage(single.Id);

            //    singleBtn.ImageOptions.LargeImage = imageLarge ?? Resources.ServerMode_32x32;
            //    singleBtn.ImageOptions.Image = imageSmall ?? Resources.ServerMode_16x16;
            //    singleBtn.RibbonStyle = RibbonItemStyles.All;
            //    singleBtn.Caption = !string.IsNullOrEmpty(single.OptionalTitle)
            //        ? $"{single.OptionalTitle}"
            //        : "Server Side Data Provider";
            //    if (single.ToolTip != null)
            //    {
            //        SuperToolTip toolTip = new SuperToolTip();
            //        // Create an object to initialize the SuperToolTip.
            //        SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
            //        args.Title.Text = single.ToolTip.Title;
            //        args.Contents.Text = single.ToolTip.Content;
            //        // args.Contents.Image = realTime.ToolTip.Image;
            //        toolTip.Setup(args);
            //        singleBtn.SuperTip = toolTip;
            //    }

            //    singleBtn.ItemClick += async (sender, e) =>
            //    {
            //        OpenedWindows++;
            //        await FactoriesManager.InitializeIfNeeded(single);
            //        ServerSideLogs serverSideUC = new ServerSideLogs(single);
            //        var page = dockManager1.AddPanel(DockingStyle.Float);
            //        page.DockedAsTabbedDocument = true;
            //        page.Tag = ribbonPage;
            //        page.Controls.Add(serverSideUC);
            //        serverSideUC.Dock = DockStyle.Fill;
            //        page.Text = $"{offlineTitle} #{OpenedWindows} ({single.OptionalTitle})";
            //        dockManager1.ActivePanel = page;
            //    };
            //}
        }
        private void xtcLogs_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (e.Page?.Tag == null)
            {
                return;
            }

            ribbonControlMain.SelectedPage = (RibbonPage)e.Page.Tag;
        }

        private async void TmrAutoConnect_Tick(object sender, EventArgs e)
        {
            TmrAutoConnect.Enabled = false;
            if (!OnlineSources.Any())
            {
                return;
            }

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
            bsiIdleMessage.Caption = Settings.IdleMode ? $"Idle mode is on. User idle: {Utils.IdleTime():hh\\:mm\\:ss}. Missed messages: {PagingManager.TotalMissedMessages}" : "Idle mode is off";

            tmrStatusUpdates.Start();
        }

        private void bbiFileCaching_ItemClick(object sender, ItemClickEventArgs e)
        {
            Settings.EnableFileCaching = !Settings.EnableFileCaching;
            bbiFileCaching.Caption = "File caching is " + (Settings.EnableFileCaching ? "on" : "off");
            bbiFileCaching.Appearance.BackColor = Settings.EnableFileCaching ? Color.LightGreen : Color.Empty;
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
                        string data = JsonConvert.SerializeObject(Settings);
                        File.WriteAllText(saveFileDialog.FileName, data);
                        XtraMessageBox.Show("settings saved", "Analogy",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exception)
                    {
                        AnalogyLogManager.Instance.LogError("Error during export settings: " + e, nameof(bBtnItemExportSettings_ItemClick));
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

                        ServicesProvider.Instance.GetService<IAnalogyUserSettings>().LoadSettings(newSettings);
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
                Settings.LastOpenedDataProvider = id;
            }
        }

        private void bbtnDebugLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            AnalogyLogManager.Instance.Show(this);
        }

        private void bbtnStar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Utils.OpenLink("https://github.com/Analogy-LogViewer/Analogy.LogViewer");
        }

        private void bbtnUpdates_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenUpdateWindow();
        }

        private void OpenUpdateWindow()
        {
            UpdateForm update = new UpdateForm(Settings, UpdateManager);
            update.Show(this);
        }

        private void bbtnDataProvidersUpdates_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenDataProvidersUpdateWindow();
        }

        private void bbiUserStatistics_ItemClick(object sender, ItemClickEventArgs e)
        {
            var user = new UserStatisticsForm(Settings);
            user.ShowDialog(this);
        }
        private void OpenDataProvidersUpdateWindow()
        {
            var update = new ComponentDownloadsForm(FactoriesManager, UpdateManager);
            update.Show(this);
        }

        private void bbiDownloadStatistics_ItemClick(object sender, ItemClickEventArgs e)
        {
            AnalogyAboutBox ab = new AnalogyAboutBox(2);
            ab.ShowDialog(this);
        }

        private void TabbedView1_DocumentDeactivated(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        {
            if (e.Document is { Control: DockPanel { Controls.Count: > 0 } pnl })
                if (pnl.Controls[0] is ControlContainer { Controls.Count: > 0 } cc)
                    if (cc.Controls[0] is IUserControlWithUCLogs logUc)
                    {
                        logUc.HideSecondaryWindow();
                    }
        }

        private void TabbedView1_DocumentActivated(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        {
            if (e.Document is { Control: DockPanel { Controls.Count: > 0 } pnl })
                if (pnl.Controls[0] is ControlContainer { Controls.Count: > 0 } cc)
                    if (cc.Controls[0] is IUserControlWithUCLogs logUc)
                    {
                        logUc.ShowSecondaryWindow();
                    }
        }
    }
}