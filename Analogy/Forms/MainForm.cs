
using Analogy.DataProviders;
using Analogy.DataTypes;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.Factories;
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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.Forms
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
                var alertControl = new DevExpress.XtraBars.Alerter.AlertControl();

                var titleText = "Analogy Log Viewer";
                var contentText = "Still here... Double click the icon to restore";
                alertControl.AutoFormDelay = 3000;
                alertControl.AlertClick += (_, __) =>
                {
                    Show();
                    Focus();
                };
                alertControl.Show(this, titleText, contentText, settings.GetImage());
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
                CleanupManager.Instance.Clean();
            }
        }

        private async void AnalogyMainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }
            NotificationManager.Instance.OnNewNotification += (s, notification) =>
             {
                 AlertInfo info = new AlertInfo(notification.Title, notification.Message, notification.SmallImage);
                 AlertControl ac = new AlertControl(this.components)
                 {
                     AutoFormDelay = notification.DurationSeconds * 1000
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
            if (settings.AnalogyPosition.RememberLastPosition || settings.AnalogyPosition.WindowState != FormWindowState.Minimized)
            {
                WindowState = settings.AnalogyPosition.WindowState;
                if (WindowState != FormWindowState.Maximized)
                {
                    if (Screen.AllScreens.Any(s => s.WorkingArea.Contains(settings.AnalogyPosition.Location)))
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
            }

            string framework = UpdateManager.Instance.CurrentFrameworkAttribute.FrameworkName;
            Text = $"Analogy Log Viewer {UpdateManager.Instance.CurrentVersion} ({framework})";
            Icon = settings.GetIcon();
            notifyIconAnalogy.Visible = preventExit = settings.MinimizedToTrayBar;
            await FactoriesManager.Instance.InitializeBuiltInFactories();
            string[] arguments = Environment.GetCommandLineArgs();
            disableOnlineDueToFileOpen = arguments.Length == 2;
            SetupEventHandlers();
            bbiFileCaching.Caption = "File caching is " + (settings.EnableFileCaching ? "on" : "off");
            bbiFileCaching.Appearance.BackColor = settings.EnableFileCaching ? Color.LightGreen : Color.Empty;
            ribbonControlMain.Minimized = settings.StartupRibbonMinimized;

            ribbonControlMain.CommandLayout = settings.RibbonStyle;
            //CreateAnalogyBuiltinDataProviders
            FactoryContainer analogy = FactoriesManager.Instance.GetBuiltInFactoryContainer(AnalogyBuiltInFactory.AnalogyGuid);
            if (analogy.FactorySetting.Status != DataProviderFactoryStatus.Disabled)
            {
                CreateDataSource(analogy, 0);
            }
            await FactoriesManager.Instance.AddExternalDataSources();
            PopulateGlobalTools();
            LoadStartupExtensions();


            //Create all other DataSources
            foreach (FactoryContainer factory in FactoriesManager.Instance.Factories
                .Where(factory => !FactoriesManager.Instance.IsBuiltInFactory(factory.Factory) &&
                                  factory.FactorySetting.Status != DataProviderFactoryStatus.Disabled))
            {
                CreateDataSource(factory, 3);
            }
            //set Default page:
            Guid defaultPage = settings.InitialSelectedDataProvider;
            if (Mapping.ContainsKey(defaultPage))
            {
                ribbonControlMain.SelectedPage = Mapping[defaultPage];
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

            if (settings.ShowChangeLogAtStartUp)
            {
                var change = new ChangeLog();
                change.ShowDialog(this);
            }
            if (settings.RememberLastOpenedDataProvider && Mapping.ContainsKey(settings.LastOpenedDataProvider))
            {
                ribbonControlMain.SelectPage(Mapping[settings.LastOpenedDataProvider]);
            }
            ribbonControlMain.SelectedPageChanging += ribbonControlMain_SelectedPageChanging;
            if (AnalogyLogManager.Instance.HasErrorMessages || AnalogyLogManager.Instance.HasWarningMessages)
            {
                btnErrors.Visibility = BarItemVisibility.Always;
            }

            if (!AnalogyNonPersistSettings.Instance.UpdateAreDisabled)
            {
                var (_, release) = await UpdateManager.Instance.CheckVersion(false);
                if (release?.TagName != null && UpdateManager.Instance.NewestVersion != null)
                {
                    bbtnCheckUpdates.Caption = "Latest Version: " + UpdateManager.Instance.NewestVersion.ToString();
                    if (UpdateManager.Instance.NewVersionExist)
                    {
                        bbtnCheckUpdates.Appearance.BackColor = Color.GreenYellow;
                        bbtnCheckUpdates.Caption =
                            "New Version Available: " + UpdateManager.Instance.NewestVersion.ToString();

                    }
                }
            }
            else
            {
                AnalogyLogManager.Instance.LogWarning("Update is disabled", nameof(MainForm));
            }
            if (settings.ShowWhatIsNewAtStartup)
            {
                WhatsNewForm f = new WhatsNewForm();
                f.ShowDialog(this);
                settings.ShowWhatIsNewAtStartup = false;
            }

        }

        private void PopulateGlobalTools()
        {
            var allFactories = FactoriesManager.Instance.Factories.ToList();
            allFactories.AddRange(FactoriesManager.Instance.BuiltInFactories);
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

        private void SetupEventHandlers()
        {
            bbiPayPal.ItemClick += (s, e) =>
            {
                Utils.OpenLink("https://www.paypal.me/liorbanai");
            };
            bbiBinance.ItemClick += (s, e) =>
            {
                Utils.OpenLink("https://www.binance.com/en/register?ref=V8P114PE");
            };
            dockManager1.ClosingPanel += (s, e) =>
            {
                var workspace = Utils.GetLogWindows<IAnalogyWorkspace>(this);
                workspace?.SaveCurrentWorkspace();
            };
            bbtnSponsorOpenCollection.ItemClick +=
                (s, e) => Utils.OpenLink("https://opencollective.com/analogy-log-viewer");

            #region  main menu

            btnSettingsUpdate.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm("Updates");
                user.ShowDialog(this);
            };

            bbiSettingsExtensions.ItemClick += (s, e) =>
            {

                ApplicationSettingsForm user = new ApplicationSettingsForm("Extensions");
                user.ShowDialog(this);
            };

            btnSettingsDebugging.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm("Debugging");
                user.ShowDialog(this);
            };

            btnShortcuts.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm("Shortcuts");
                user.ShowDialog(this);
            };

            bbiDonation.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm("Donations");
                user.ShowDialog(this);
            };
            btnApplicationSettings.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm("Application Settings");
                user.ShowDialog(this);
            };
            btnApplicationUISettings.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm("Application UI Settings");
                user.ShowDialog(this);
            };
            btnFiltering.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm("Messages Filtering");
                user.ShowDialog(this);
            };
            btnMessageColumnsLayoutSettings.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm("Messages Layout");
                user.ShowDialog(this);
            };
            btnColorsSettings.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm("Color Settings");
                user.ShowDialog(this);
            };
            btnColorHighlightSettings.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm("Color Highlighting");
                user.ShowDialog(this);
            };
            btnPreDefinedQueries.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm("Predefined queries");
                user.ShowDialog(this);
            };
            btnPreDefinedQueries.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm("Donations");
                user.ShowDialog(this);
            };
            btnDataProvidersSettings.ItemClick += (s, e) =>
            {
                ApplicationSettingsForm user = new ApplicationSettingsForm("Data Provider Settings");
                user.ShowDialog(this);
            };
            #endregion

            settings.OnRibbonControlStyleChanged += (s, e) => ribbonControlMain.CommandLayout = e;
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
            bbtnCompactMemory.ItemClick += (_, __) => FileProcessingManager.Instance.Reset();
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
            bbtnWhatsNew.ItemClick += (_, __) =>
            {
                WhatsNewForm f = new WhatsNewForm();
                f.ShowDialog(this);
                settings.ShowWhatIsNewAtStartup = false;
            };
            bbtnFirstRun.ItemClick += (_, __) =>
            {
                FirstTimeRunForm f = new FirstTimeRunForm();
                f.ShowDialog(this);
            };

            bbiBookmarks.ItemClick += (s, e) => OpenBookmarkLog();

        }

        private void OpenOfflineLogs(RibbonPage ribbonPage, string[] filenames,
            IAnalogyOfflineDataProvider dataProvider,
            string? title = null)
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
            if (settings.StartupExtensions.Any())
            {
                var manager = ExtensionsManager.Instance;
                var extensions = manager.GetExtensions().ToList();
                foreach (Guid guid in settings.StartupExtensions)
                {
                    manager.RegisterExtension(extensions.SingleOrDefault(m => m.Id == guid));
                }

            }
        }
        private async Task OpenOfflineFileWithSpecificDataProvider(string[] files)
        {
            while (!Initialized)
            {
                await Task.Delay(250);
            }

            var supported = FactoriesManager.Instance.GetSupportedOfflineDataSources(files).ToList();
            if (supported.Count == 1)
            {
                var parser = supported.First();
                RibbonPage page = Mapping.ContainsKey(parser.FactoryID) ? Mapping[parser.FactoryID] : null;
                OpenOfflineLogs(page, files, parser.DataProvider);
            }
            else
            {

                if (supported.Any(d =>
                    d.DataProvider.Id == settings.LastOpenedDataProvider ||
                    d.FactoryID == settings.LastOpenedDataProvider
                    && d.DataProvider.CanOpenAllFiles(files)))
                {
                    supported = supported.Where(d =>
                        d.DataProvider.Id == settings.LastOpenedDataProvider ||
                        d.FactoryID == settings.LastOpenedDataProvider && d.DataProvider.CanOpenAllFiles(files)).ToList();

                }
                else
                {
                    supported = FactoriesManager.Instance.GetSupportedOfflineDataSources(files).Where(itm =>
                        !FactoriesManager.Instance.IsBuiltInFactory(itm.FactoryID)).ToList();
                }

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
                        {
                            OpenOfflineLogs(page, files, parser.First());
                        }
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



        private void AddRecentFiles(RibbonPage ribbonPage, BarSubItem bar, IAnalogyOfflineDataProvider offlineAnalogy,
            string title, List<string> files)
        {

            if (files.Any())
            {
                foreach (string file in files)
                {
                    if (!File.Exists(file))
                    {
                        continue;
                    }

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
            ApplicationSettingsForm user = new ApplicationSettingsForm();
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
                        RibbonStyle = RibbonItemStyles.All
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
            aboutBtn.ItemClick += (sender, e) => { new AboutDataSourceBox(fc.Factory).ShowDialog(this); };
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
                BarButtonItem settingsBtn = new BarButtonItem
                {
                    Caption = providerSetting.Title,
                    RibbonStyle = RibbonItemStyles.All
                };
                groupSettings.ItemLinks.Add(settingsBtn);
                settingsBtn.ImageOptions.Image = providerSetting.SmallImage ?? Resources.Technology_16x16;
                settingsBtn.ImageOptions.LargeImage = providerSetting.LargeImage ?? Resources.Technology_32x32;
                XtraForm form = new DataProviderSettingsForm();
                //var imageSmall = FactoriesManager.Instance.GetSmallImage(providerSetting.Id);
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

            AddFlatRealTimeDataSource(factory, ribbonPage, dataSourceFactory, ribbonPageGroup);
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
                        openedWindows++;
                        //plotterBtn.ImageOptions.Image = imageSmallOnline ?? Resources.Database_on;
                        var page = dockManager1.AddPanel(DockingStyle.Float);
                        await userControl.InitializeUserControl(page, AnalogyLogger.Instance);
                        page.DockedAsTabbedDocument = true;
                        page.Tag = ribbonPage;
                        page.Controls.Add(userControl.UserControl);
                        ribbonControlMain.SelectedPage = ribbonPage;
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
                    openedWindows++;
                    await plot.InitializePlottingAsync(AnalogyLogger.Instance);
                    //plotterBtn.ImageOptions.Image = imageSmallOnline ?? Resources.Database_on;
                    var plotterUC = new PlottingUC(plot);
                    var page = dockManager1.AddPanel(DockingStyle.Float);
                    page.DockedAsTabbedDocument = true;
                    page.Tag = ribbonPage;
                    page.Controls.Add(plotterUC);
                    ribbonControlMain.SelectedPage = ribbonPage;
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

                plotterBtn.ItemClick += async (s, be) => await OpenPlotter();

            }
        }

        private void AddFlatRealTimeDataSource(IAnalogyFactory primaryFactory, RibbonPage ribbonPage, IAnalogyDataProvidersFactory dataSourceFactory, RibbonPageGroup group)
        {
            var realTimes = dataSourceFactory.DataProviders.Where(f => f is IAnalogyRealTimeDataProvider)
                .Cast<IAnalogyRealTimeDataProvider>().ToList();
            if (realTimes.Count == 0)
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
                var imageSmallOffline = realTime.DisconnectedSmallImage;
                var imageSmallOnline = realTime.ConnectedSmallImage;
                BarButtonItem realTimeBtn = new BarButtonItem();
                ribbonPageGroup.ItemLinks.Add(realTimeBtn);
                realTimeBtn.ImageOptions.Image = imageSmallOffline ?? Resources.Database_off;
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
                                AnalogyLogLevel.Analogy, AnalogyLogClass.General,
                                dataSourceFactory.Title, "Analogy");
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
                        await realTime.StartReceiving();
                        onlineDataSourcesMapping.Add(page, realTime);

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
                if (settings.AutoStartDataProviders.Contains(realTime.Id)
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

        private void AddRealTimeDataSource(RibbonPage ribbonPage, IAnalogyDataProvidersFactory dataSourceFactory,
            RibbonPageGroup group)
        {
            var realTimes = dataSourceFactory.DataProviders.Where(f => f is IAnalogyRealTimeDataProvider)
                .Cast<IAnalogyRealTimeDataProvider>().ToList();
            if (realTimes.Count == 0)
            {
                return;
            }

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
                    var imageSmallOffline = realTime.DisconnectedSmallImage;
                    var imageSmallOnline = realTime.ConnectedSmallImage;
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
                            AnalogyLogManager.Instance.LogError("Error during call to canStartReceiving: " + e,
                                nameof(MainForm));
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
                                    AnalogyLogLevel.Analogy, AnalogyLogClass.General,
                                    dataSourceFactory.Title, "Analogy");
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
                            await realTime.StartReceiving();
                            onlineDataSourcesMapping.Add(page, realTime);

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
                    if (settings.AutoStartDataProviders.Contains(realTime.Id)
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

        private void AddSingleDataSources(IAnalogyFactory primaryFactory, RibbonPage ribbonPage, IAnalogyDataProvidersFactory dataSourceFactory, RibbonPageGroup group)
        {
            var singles = dataSourceFactory.DataProviders.Where(f => f is IAnalogySingleDataProvider ||
                                                                      f is IAnalogySingleFileDataProvider).ToList();

            foreach (var single in singles)
            {
                BarButtonItem singleBtn = new BarButtonItem();
                group.ItemLinks.Add(singleBtn);
                var imageLarge = FactoriesManager.Instance.GetLargeImage(single.Id);
                var imageSmall = FactoriesManager.Instance.GetSmallImage(single.Id);

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
                RibbonPageGroup groupOfflineFileTools = new RibbonPageGroup($"Tools{optionalText}");
                groupOfflineFileTools.AllowTextClipping = false;
                ribbonPage.Groups.Add(groupOfflineFileTools);
                AddSingleOfflineDataSource(primaryFactory, ribbonPage, offlineAnalogy, factory, group, groupOfflineFileTools);
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
            FactoryContainer container = FactoriesManager.Instance.GetFactoryContainer(factoryId);
            IAnalogyImages? images = container?.Images?.FirstOrDefault();



            #region Actions
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
                btn.ItemClick += (s, be) =>
                {
                    OpenOffline(dataProvider.OptionalTitle, dataProvider, directory);
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
                foreach (var path in settings.GetRecentFolders(dataProvider.Id))
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
                                Filter = Utils.GetOpenFilter(dataProvider.FileOpenDialogFilters),
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
                    else
                    {

                        IAnalogyNotification notification = new AnalogyNotification(factoryId,
                            "Missing File Open Dialog Filter",
                            $"{factoryTitle} has offline data provider without File Open Dialog Filter.{Environment.NewLine}You can set a filter in the data provider settings or report this to the developer.{Environment.NewLine}Filter format example: 'log files (*.log)|*.log|clef files (*.clef)|*.clef'"
                            , AnalogyLogLevel.Error, primaryFactory.LargeImage, 5, null);
                        NotificationManager.Instance.RaiseNotification(notification, true);
                    }
                }



                //add Open Pooled file entry
                BarSubItem filePoolingBtn = new BarSubItem();
                string caption="File Pooling (Monitoring)";
                filePoolingBtn.Caption = caption;
                filePoolingBtn.SuperTip =
                    Utils.GetSuperTip(caption, "Monitor file for changes in real time and reload the file automatically");
                group.ItemLinks.Add(filePoolingBtn);
                filePoolingBtn.ImageOptions.Image = images?.GetSmallFilePoolingImage(factoryId) ?? Resources.FilePooling_16x16;
                filePoolingBtn.ImageOptions.LargeImage = images?.GetLargeFilePoolingImage(factoryId) ?? Resources.FilePooling_32x32;
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
                var recents = settings.GetRecentFiles(dataProvider.Id)
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
            groupOfflineFileTools.ItemLinks.Add(combineFiles);
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
            groupOfflineFileTools.ItemLinks.Add(compareFiles);
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
            IAnalogyDataProvidersFactory factory, RibbonPageGroup group, RibbonPageGroup groupOfflineFileTools)
        {
            Guid factoryId = factory.FactoryId;
            string title = factory.Title;
            #region actions
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
                page.Text = $"{filePoolingTitle} #{filePooling++} ({titleOfDataSource})";
                dockManager1.ActivePanel = page;
                dockManager1.ClosedPanel += OnXtcLogsOnControlRemoved;
            }
            #endregion
            FactoryContainer container = FactoriesManager.Instance.GetFactoryContainer(offlineAnalogy.Id);
            IAnalogyImages? images = container?.Images?.FirstOrDefault();

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
            localfolder.ItemClick += (sender, e) =>
            {
#if NETCOREAPP3_1 || NET
                using (var folderBrowserDialog = new FolderBrowserDialog { ShowNewFolderButton = false })
                {
                    folderBrowserDialog.SelectedPath = preDefinedFolderExist ? offlineAnalogy.InitialFolderFullPath : Environment.CurrentDirectory;
                    DialogResult result = folderBrowserDialog.ShowDialog(); // Show the dialog.
                    if (result == DialogResult.OK) // Test result.
                    {
                        if (!string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
                        {
                            OpenOffline(title, folderBrowserDialog.SelectedPath);
                        }
                    }
                }
#else
                using (var dialog = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog())
                {
                    dialog.InitialDirectory = preDefinedFolderExist ? offlineAnalogy.InitialFolderFullPath : Environment.CurrentDirectory;
                    dialog.IsFolderPicker = true;
                    if (dialog.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
                    {
                        OpenOffline(title, dialog.FileName);
                    }
                }
#endif
            };

            //recent folder
            //recent bar
            BarSubItem recentFolders = new BarSubItem { Caption = "Recent Folders" };
            recentFolders.ImageOptions.Image = images?.GetSmallRecentFoldersImage(factoryId) ?? Resources.LoadFrom_16x16;
            recentFolders.ImageOptions.LargeImage = images?.GetLargeRecentFoldersImage(factoryId) ?? Resources.LoadFrom_32x32;
            recentFolders.RibbonStyle = RibbonItemStyles.All;
            group.ItemLinks.Add(recentFolders);
            foreach (var path in settings.GetRecentFolders(offlineAnalogy.Id))
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
                openFiles.Caption = "Open Files";
                group.ItemLinks.Add(openFiles);
                openFiles.ImageOptions.Image = offlineAnalogy.SmallImage ?? Resources.Article_16x16;
                openFiles.ImageOptions.LargeImage = offlineAnalogy.LargeImage ?? Resources.Article_32x32;
                openFiles.RibbonStyle = RibbonItemStyles.All;
                openFiles.ItemClick += (sender, e) =>
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog
                    {
                        Filter = Utils.GetOpenFilter(offlineAnalogy.FileOpenDialogFilters),
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
                string caption = "File Pooling (Monitoring)";
                filePoolingBtn.Caption = caption;
                filePoolingBtn.SuperTip =
                    Utils.GetSuperTip(caption, "Monitor file for changes in real time and reload the file automatically");
                group.ItemLinks.Add(filePoolingBtn);
                filePoolingBtn.ImageOptions.Image = images?.GetSmallFilePoolingImage(factoryId) ?? Resources.FilePooling_16x16;
                filePoolingBtn.ImageOptions.LargeImage = images?.GetLargeFilePoolingImage(factoryId) ?? Resources.FilePooling_32x32;
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
            else
            {

                IAnalogyNotification notification = new AnalogyNotification(factoryId,
                    "Missing File Open Dialog Filter",
                    $"{title} has offline data provider without File Open Dialog Filter.{Environment.NewLine}You can set a filter in the data provider settings or report this to the developer.{Environment.NewLine}Filter format example: 'log files (*.log)|*.log|clef files (*.clef)|*.clef'"
                    , AnalogyLogLevel.Error, primaryFactory.LargeImage, 5, null);
                NotificationManager.Instance.RaiseNotification(notification, true);
            }

            //add recent
            group.ItemLinks.Add(recentBar);
            var recents = settings.GetRecentFiles(offlineAnalogy.Id)
                .Select(itm => itm.FileName).ToList();
            AddRecentFiles(ribbonPage, recentBar, offlineAnalogy, title, recents);

            //add client/server  button:
            BarButtonItem externalSources = new BarButtonItem();
            externalSources.Caption = "Known Locations";
            externalSources.RibbonStyle = RibbonItemStyles.All;
            group.ItemLinks.Add(externalSources);
            externalSources.ImageOptions.Image = images?.GetSmallKnownLocationsImage(factoryId) ?? Resources.ServerMode_16x16;
            externalSources.ImageOptions.LargeImage = images?.GetLargeKnownLocationsImage(factoryId) ?? Resources.ServerMode_32x32;
            externalSources.ItemClick += (sender, e) => { OpenExternalDataSource(title, offlineAnalogy); };


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
            var disconnectedLargeImage = realTime.DisconnectedLargeImage;
            var disconnectedSmallImage = realTime.DisconnectedSmallImage;
            var connectedLargeImage = realTime.ConnectedLargeImage;
            var connectedSmallImage = realTime.ConnectedSmallImage;
            realTimeBtn.ImageOptions.LargeImage = disconnectedLargeImage ?? Resources.Database_off;
            realTimeBtn.ImageOptions.Image = disconnectedSmallImage ?? Resources.Database_off;
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
                    AnalogyLogManager.Instance.LogError("Error during call to canStartReceiving: " + e, nameof(OpenRealTime));
                }

                if (canStartReceiving) //connected
                {
                    openedWindows++;
                    realTimeBtn.ImageOptions.Image = connectedSmallImage ?? Resources.Database_on;
                    realTimeBtn.ImageOptions.LargeImage = connectedLargeImage ?? Resources.Database_on;
                    var onlineUC = new OnlineUCLogs(realTime);

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
                        realTimeBtn.ImageOptions.Image = disconnectedSmallImage ?? Resources.Database_off;
                        realTimeBtn.ImageOptions.Image = disconnectedLargeImage ?? Resources.Database_off;
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
                    await realTime.StartReceiving();
                    onlineDataSourcesMapping.Add(page, realTime);
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
            if (settings.AutoStartDataProviders.Contains(realTime.Id)
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
            bsiIdleMessage.Caption = settings.IdleMode ? $"Idle mode is on. User idle: {Utils.IdleTime():hh\\:mm\\:ss}. Missed messages: {PagingManager.TotalMissedMessages}" : "Idle mode is off";

            tmrStatusUpdates.Start();
        }


        private void bbiFileCaching_ItemClick(object sender, ItemClickEventArgs e)
        {
            settings.EnableFileCaching = !settings.EnableFileCaching;
            bbiFileCaching.Caption = "File caching is " + (settings.EnableFileCaching ? "on" : "off");
            bbiFileCaching.Appearance.BackColor = settings.EnableFileCaching ? Color.LightGreen : Color.Empty;
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
                settings.LastOpenedDataProvider = id;
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
            UpdateForm update = new UpdateForm();
            update.Show(this);
        }

        private void bbtnDataProvidersUpdates_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenDataProvidersUpdateWindow();
        }

        private void bbiUserStatistics_ItemClick(object sender, ItemClickEventArgs e)
        {
            var user = new UserStatisticsForm();
            user.ShowDialog(this);
        }
        private void OpenDataProvidersUpdateWindow()
        {
            var update = new ComponentDownloadsForm();
            update.Show(this);
        }

    }
}

