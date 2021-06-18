using Analogy.DataProviders;
using Analogy.DataTypes;
using Analogy.Forms;
using Analogy.Interfaces;
using Analogy.Managers;
using Analogy.Properties;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy
{
    public partial class FluentDesignMainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
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

        public FluentDesignMainForm()
        {
            InitializeComponent();
            EnableAcrylicAccent = false;
        }

        private async void FluentDesignMainForm_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            activeProvider = settings.RememberLastOpenedDataProvider
                ? settings.LastOpenedDataProvider
                : UserSettingsManager.UserSettings.InitialSelectedDataProvider;

            if (settings.AnalogyPosition.RememberLastPosition ||
                settings.AnalogyPosition.WindowState != FormWindowState.Minimized)
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


            //todo:

            //CreateAnalogyBuiltinDataProviders
            FactoryContainer analogy = FactoriesManager.Instance.GetBuiltInFactoryContainer(AnalogyBuiltInFactory.AnalogyGuid);
            CreateDataSource(analogy);


            await FactoriesManager.Instance.AddExternalDataSources();
            PopulateGlobalTools();
            //LoadStartupExtensions();

            //Create all other DataSources
            foreach (FactoryContainer factory in FactoriesManager.Instance.Factories
                .Where(factory => !FactoriesManager.Instance.IsBuiltInFactory(factory.Factory)))
            {
                CreateDataSource(factory);
            }

            if (OnlineSources.Any())
            {
                TmrAutoConnect.Start();
            }

            Initialized = true;
            //todo: fine handler for file
            if (arguments.Length == 2)
            {
                //todo
                string[] fileNames = { arguments[1] };
                // await OpenOfflineFileWithSpecificDataProvider(fileNames);
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

            //todo:fix below
            if (settings.RememberLastOpenedDataProvider && Mapping.ContainsKey(settings.LastOpenedDataProvider))
            {
                //ribbonControlMain.SelectPage(Mapping[settings.LastOpenedDataProvider]);
            }

            if (AnalogyLogManager.Instance.HasErrorMessages || AnalogyLogManager.Instance.HasWarningMessages)
            {
                bbtnErrors.Visibility = BarItemVisibility.Always;
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

        private void SetupEventHandlers()
        {
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
            btnSettings.ItemClick += (s, e) =>
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
            bbtnItemHelp.ItemClick += (s, e) =>
            {
                AnalogyAboutBox ab = new AnalogyAboutBox();
                ab.ShowDialog(this);
            };
            bbiUserSettingsStatistics.ItemClick += (s, e) =>
            {
                var user = new UserStatisticsForm();
                user.ShowDialog(this);
            };
            bbtnUpdates.ItemClick += (s, e) => OpenUpdateWindow();
            bbtnDataProvidersUpdates.ItemClick += (s, e) =>
            {
                var update = new ComponentDownloadsForm();
                update.Show(this);
            };
            bbtnDebugLog.ItemClick += (s, e) => AnalogyLogManager.Instance.Show(this);
            bbtnItemChangeLog.ItemClick += (s, e) =>
            {
                var change = new ChangeLog();
                change.ShowDialog(this);
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

            tmrStatusUpdates.Tick += (s, e) =>
            {
                tmrStatusUpdates.Stop();
                bbtnMemoryUsage.Caption = Process.GetCurrentProcess().PrivateMemorySize64 / 1024 / 1024 + " [MB]";
                bbtnIdleMessage.Caption = settings.IdleMode
                    ? $"Idle mode is on. User idle: {Utils.IdleTime():hh\\:mm\\:ss}. Missed messages: {PagingManager.TotalMissedMessages}"
                    : "Idle mode is off";
                tmrStatusUpdates.Start();
            };
            AnalogyLogManager.Instance.OnNewError += (s, e) => bbtnErrors.Visibility = BarItemVisibility.Always;

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
                settings.EnableFileCaching = !settings.EnableFileCaching;
                bbiFileCaching.Caption = "File caching is " + (settings.EnableFileCaching ? "on" : "off");
                bbiFileCaching.Appearance.BackColor = settings.EnableFileCaching ? Color.LightGreen : Color.Empty;

            };
        }

        private void OpenUpdateWindow()
        {
            UpdateForm update = new UpdateForm();
            update.Show(this);
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

        private void CreateDataSource(FactoryContainer fc)
        {
            if (fc.Factory.Title == null)
            {
                return;
            }



            BarCheckItem bci = new BarCheckItem(barManager1, fc.Factory.FactoryId == activeProvider);
            bci.Manager = barManager1;
            bci.CheckBoxVisibility = CheckBoxVisibility.BeforeText;
            bci.Caption = fc.Factory.Title;
            bci.Enabled = fc.FactorySetting.Status != DataProviderFactoryStatus.Disabled;
            bci.Glyph = fc.Factory.SmallImage;
            bci.ItemClick += (s, e) =>
            {
                bci.Checked = true;
                LoadFactory(fc);
            };
            bsiDataProviders.AddItem(bci);

        }

        private void LoadFactory(FactoryContainer fc)
        {
            if (activeProvider == fc.Factory.FactoryId)
            {
                return;
            }
            //        RibbonPage ribbonPage = new RibbonPage(fc.Factory.Title);
            //    ribbonControlMain.Pages.Insert(position, ribbonPage);
            //    Mapping.Add(fc.Factory.FactoryId, ribbonPage);
            //    var ribbonPageImage = FactoriesManager.Instance.GetSmallImage(fc.Factory.FactoryId);
            //    if (ribbonPageImage != null)
            //    {
            //        ribbonPage.ImageOptions.Image = ribbonPageImage;
            //    }

            //    AddGraphPlotter(ribbonPage, fc.GraphPlotter);
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

            //    AddFactorySettings(fc, ribbonPage);
            //    AddAbout(fc, ribbonPage);

        }

        private void fluentDesignFormControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
