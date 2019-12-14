using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.DataSources;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.Managers;
using Analogy.Properties;
using Analogy.Tools;
using Analogy.Types;
using DevExpress.XtraEditors;
using Newtonsoft.Json;

namespace Analogy
{
    public partial class MainForm : RibbonForm
    {
        private string filePoolingTitle = "File Pooling";
        private string offlineTitle = "Offline log";
        private string onlineTitle = "Online log";
        private Dictionary<Guid, RibbonPage> Mapping = new Dictionary<Guid, RibbonPage>();

        private Dictionary<XtraTabPage, IAnalogyRealTimeDataProvider> onlineDataSourcesMapping =
            new Dictionary<XtraTabPage, IAnalogyRealTimeDataProvider>();

        private List<Task<bool>> OnlineSources = new List<Task<bool>>();
        private int offline;
        private int online;
        private int filePooling;
        private bool disableOnlineDueToFileOpen;
        private XtraTabPage currentContextPage;
        private UserSettingsManager settings => UserSettingsManager.UserSettings;
        private bool Initialized { get; set; }

        public MainForm()
        {
            InitializeComponent();
            AnalogyLogManager.Instance.OnNewError += (s, e) => btnErrors.Visibility = BarItemVisibility.Always;
        }


        private void AnalogyMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //todo: end onlines;
        }

        private async void AnalogyMainForm_Load(object sender, EventArgs e)
        {
            string[] arguments = Environment.GetCommandLineArgs();
            disableOnlineDueToFileOpen = arguments.Length == 2;
            if (DesignMode) return;

            bbiFileCaching.Caption = "File caching is " + (settings.EnableFileCaching ? "on" : "off");
            bbtnCloseCurrentTabPage.ItemClick += (object s, ItemClickEventArgs ea) => { CloseCurrentTabPage(); };
            bbtnCloseAllTabPage.ItemClick += (object s, ItemClickEventArgs ea) =>
            {
                var pages = xtcLogs.TabPages.ToList();
                foreach (var page in pages)
                {
                    if (onlineDataSourcesMapping.ContainsKey(page))
                    {
                        onlineDataSourcesMapping[page].StopReceiving();
                        onlineDataSourcesMapping.Remove(page);
                    }

                    xtcLogs.TabPages.Remove(page);

                }
            };
            bbtnCloseOtherTabPages.ItemClick += (object s, ItemClickEventArgs ea) =>
            {
                var pages = xtcLogs.TabPages.Where(p => p != currentContextPage).ToList();
                foreach (var page in pages)
                {
                    if (onlineDataSourcesMapping.ContainsKey(page))
                    {
                        onlineDataSourcesMapping[page].StopReceiving();
                        onlineDataSourcesMapping.Remove(page);
                    }

                    xtcLogs.TabPages.Remove(page);

                }

            };
            ribbonControlMain.Minimized = UserSettingsManager.UserSettings.StartupRibbonMinimized;


            CreateAnalogyBuiltinDataProviders();
            await FactoriesManager.Instance.AddExternalDataSources();

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
        }



        private void CreateAnalogyBuiltinDataProviders()
        {
            IAnalogyFactory analogy = FactoriesManager.Instance.Get(AnalogyBuiltInFactory.AnalogyGuid);
            if (settings.GetFactorySetting(analogy.FactoryID).Status != DataProviderFactoryStatus.Disabled)
                CreateDataSource(analogy, 0);
            ribbonControlMain.SelectedPage = ribbonControlMain.Pages.First();
            IAnalogyFactory eventLogDataFactory = FactoriesManager.Instance.Get(EventLogDataFactory.ID);
            if (settings.GetFactorySetting(eventLogDataFactory.FactoryID).Status == DataProviderFactoryStatus.Disabled)
                return;
            //CreateEventLogsGroup
            RibbonPage ribbonPage = new RibbonPage(eventLogDataFactory.Title);
            EventLogDataProvider elds = eventLogDataFactory.DataProviders.Items.First() as EventLogDataProvider;
            ribbonControlMain.Pages.Insert(2, ribbonPage);
            RibbonPageGroup group = new RibbonPageGroup(eventLogDataFactory.DataProviders.Title);
            ribbonPage.Groups.Add(group);


            BarButtonItem evtxRealTime = new BarButtonItem();
            evtxRealTime.Caption = "Real Time Windows Event Logs";
            evtxRealTime.RibbonStyle = RibbonItemStyles.All;
            evtxRealTime.ImageOptions.Image = Resources.OperatingSystem_16x16;
            evtxRealTime.ImageOptions.LargeImage = Resources.OperatingSystem_32x32;
            evtxRealTime.ItemClick += (s, be) =>
            {
                UserControl windowsEventlog = new WindowsEventLog();
                XtraTabPage page = new XtraTabPage();
                page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                page.Controls.Add(windowsEventlog);
                windowsEventlog.Dock = DockStyle.Fill;
                page.Text = $"Windows Log";
                xtcLogs.TabPages.Add(page);
                xtcLogs.SelectedTabPage = page;
            };
            group.ItemLinks.Add(evtxRealTime);

            BarButtonItem evtxFile = new BarButtonItem();
            evtxFile.Caption = "Open Event log file (*.Evtx)";
            evtxFile.RibbonStyle = RibbonItemStyles.All;
            evtxFile.ImageOptions.Image = Resources.OperatingSystem_16x16;
            evtxFile.ImageOptions.LargeImage = Resources.OperatingSystem_32x32;
            evtxFile.ItemClick += (s, be) =>
            {

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Windows Event log files (*.evtx)|*.evtx";
                openFileDialog1.Title = @"Open Files";
                openFileDialog1.Multiselect = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    OpenOfflineLogs(ribbonPage, openFileDialog1.FileNames, elds, "Windows Event log");
                    AddRecentWindowsEventLogFiles(openFileDialog1.FileNames.ToList());
                }
            };
            group.ItemLinks.Add(evtxFile);

            BarButtonItem systemLog = new BarButtonItem();
            systemLog.Caption = $"Open {Environment.MachineName} System Log file";
            systemLog.RibbonStyle = RibbonItemStyles.All;
            systemLog.ImageOptions.Image = Resources.OperatingSystem_16x16;
            systemLog.ImageOptions.LargeImage = Resources.OperatingSystem_32x32;
            systemLog.ItemClick += (s, be) =>
            {
                string file = Path.Combine(Environment.ExpandEnvironmentVariables("%SystemRoot%"), "System32", "Winevt",
                    "Logs", "System.evtx");
                if (File.Exists(file))
                {
                    OpenOfflineLogs(ribbonPage, new[] { file }, elds, "Windows Event log");
                    AddRecentWindowsEventLogFiles(new List<string>() { file });
                }
            };
            group.ItemLinks.Add(systemLog);

            BarButtonItem appLog = new BarButtonItem();
            appLog.Caption = $"Open {Environment.MachineName} Application Log file";
            appLog.RibbonStyle = RibbonItemStyles.All;
            appLog.ImageOptions.Image = Resources.OperatingSystem_16x16;
            appLog.ImageOptions.LargeImage = Resources.OperatingSystem_32x32;
            appLog.ItemClick += (s, be) =>
            {
                string file = Path.Combine(Environment.ExpandEnvironmentVariables("%SystemRoot%"), "System32", "Winevt",
                    "Logs", "Application.evtx");
                if (File.Exists(file))
                {
                    OpenOfflineLogs(ribbonPage, new[] { file }, elds, "Windows Event log");
                    AddRecentWindowsEventLogFiles(new List<string>() { file });
                }
            };
            group.ItemLinks.Add(appLog);

            BarButtonItem secLog = new BarButtonItem();
            secLog.Caption = $"Open {Environment.MachineName} Security Log file";
            secLog.RibbonStyle = RibbonItemStyles.All;
            secLog.ImageOptions.Image = Resources.OperatingSystem_16x16;
            secLog.ImageOptions.LargeImage = Resources.OperatingSystem_32x32;
            secLog.ItemClick += (s, be) =>
            {
                string file = Path.Combine(Environment.ExpandEnvironmentVariables("%SystemRoot%"), "System32", "Winevt",
                    "Logs", "Security.evtx");
                if (File.Exists(file))
                {
                    OpenOfflineLogs(ribbonPage, new[] { file }, elds, "Windows Event log");
                    AddRecentWindowsEventLogFiles(new List<string>() { file });
                }
            };
            group.ItemLinks.Add(secLog);
            BarButtonItem btnFolder = new BarButtonItem();
            btnFolder.Caption = $"Local Machine logs - {Environment.MachineName}";
            btnFolder.RibbonStyle = RibbonItemStyles.All;
            btnFolder.ImageOptions.Image = Resources.OperatingSystem_16x16;
            btnFolder.ImageOptions.LargeImage = Resources.OperatingSystem_32x32;
            btnFolder.ItemClick += (s, be) =>
            {
                OfflineUCLogs offlineUC = new OfflineUCLogs(new EventLogDataProvider());
                offlineUC.SelectedPath = Path.Combine(Environment.ExpandEnvironmentVariables("%SystemRoot%"),
                    "System32", "Winevt", "Logs");
                XtraTabPage page = new XtraTabPage();
                page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                page.Tag = ribbonPage;
                page.Controls.Add(offlineUC);
                offlineUC.Dock = DockStyle.Fill;
                page.Text = $"Local Machine logs";
                xtcLogs.TabPages.Add(page);
                xtcLogs.SelectedTabPage = page;
            };
            group.ItemLinks.Add(btnFolder);
            CreateEventLogsMenu(ribbonPage);
        }

        private void CreateEventLogsMenu(RibbonPage ribbonPage)
        {
            EventLogDataProvider elds = new EventLogDataProvider();
            BarButtonItem evtxRealTime = new BarButtonItem();
            evtxRealTime.Caption = "Real Time Windows Event Logs";
            evtxRealTime.ItemClick += (s, be) =>
            {
                UserControl windowsEventlog = new WindowsEventLog();
                XtraTabPage page = new XtraTabPage();
                page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                page.Tag = ribbonPage;
                page.Controls.Add(windowsEventlog);
                windowsEventlog.Dock = DockStyle.Fill;
                page.Text = $"Windows Log";
                xtcLogs.TabPages.Add(page);
                xtcLogs.SelectedTabPage = page;
            };
            bsiWindowsEventLogs.AddItem(evtxRealTime);

            BarButtonItem evtxFile = new BarButtonItem();
            evtxFile.Caption = "Open Event log file (*.Evtx)";
            evtxFile.ItemClick += (s, be) =>
            {

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Windows Event log files (*.evtx)|*.evtx";
                openFileDialog1.Title = @"Open Files";
                openFileDialog1.Multiselect = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    OpenOfflineLogs(ribbonPage, openFileDialog1.FileNames, elds, "Windows Event log");
                    AddRecentWindowsEventLogFiles(openFileDialog1.FileNames.ToList());
                }
            };
            bsiWindowsEventLogs.AddItem(evtxFile);

            BarButtonItem systemLog = new BarButtonItem();
            systemLog.Caption = $"Open {Environment.MachineName} System Log file";
            systemLog.ItemClick += (s, be) =>
            {
                string file = Path.Combine(Environment.ExpandEnvironmentVariables("%SystemRoot%"), "System32", "Winevt",
                    "Logs", "System.evtx");
                if (File.Exists(file))
                {
                    OpenOfflineLogs(ribbonPage, new[] { file }, elds, "Windows Event log");
                    AddRecentWindowsEventLogFiles(new List<string>() { file });
                }
            };
            bsiWindowsEventLogs.AddItem(systemLog);

            BarButtonItem appLog = new BarButtonItem();
            appLog.Caption = $"Open {Environment.MachineName} Application Log file";
            appLog.ItemClick += (s, be) =>
            {
                string file = Path.Combine(Environment.ExpandEnvironmentVariables("%SystemRoot%"), "System32", "Winevt",
                    "Logs", "Application.evtx");
                if (File.Exists(file))
                {
                    OpenOfflineLogs(ribbonPage, new[] { file }, elds, "Windows Event log");
                    AddRecentWindowsEventLogFiles(new List<string>() { file });
                }
            };
            bsiWindowsEventLogs.AddItem(appLog);

            BarButtonItem secLog = new BarButtonItem();
            secLog.Caption = $"Open {Environment.MachineName} Security Log file";
            secLog.ItemClick += (s, be) =>
            {
                string file = Path.Combine(Environment.ExpandEnvironmentVariables("%SystemRoot%"), "System32", "Winevt",
                    "Logs", "Security.evtx");
                if (File.Exists(file))
                {
                    OpenOfflineLogs(ribbonPage, new[] { file }, elds, "Windows Event log");
                    AddRecentWindowsEventLogFiles(new List<string>() { file });
                }
            };
            bsiWindowsEventLogs.AddItem(secLog);
            BarButtonItem btnFolder = new BarButtonItem();
            btnFolder.Caption = $"Local Machine logs - {Environment.MachineName}";
            btnFolder.ItemClick += (s, be) =>
            {
                OfflineUCLogs offlineUC = new OfflineUCLogs(new EventLogDataProvider());
                offlineUC.SelectedPath = Path.Combine(Environment.ExpandEnvironmentVariables("%SystemRoot%"),
                    "System32", "Winevt", "Logs");
                XtraTabPage page = new XtraTabPage();
                page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                page.Controls.Add(offlineUC);
                offlineUC.Dock = DockStyle.Fill;
                page.Text = $"Local Machine logs";
                xtcLogs.TabPages.Add(page);
                xtcLogs.SelectedTabPage = page;
            };
            bsiWindowsEventLogs.AddItem(btnFolder);
        }

        private void OpenOfflineLogs(RibbonPage ribbonPage, string[] filenames,
            IAnalogyOfflineDataProvider dataProvider,
            string title = null)
        {
            offline++;
            UserControl offlineUC = new OfflineUCLogs(dataProvider, filenames);
            XtraTabPage page = new XtraTabPage();
            page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            page.Tag = ribbonPage;
            page.Controls.Add(offlineUC);
            offlineUC.Dock = DockStyle.Fill;
            page.Text = $"{offlineTitle} #{offline}{(title == null ? "" : $" ({title})")}";
            xtcLogs.TabPages.Add(page);
            xtcLogs.SelectedTabPage = page;
        }

        private async Task OpenOfflineFileWithSpecificDataProvider(string[] files)
        {
            while (!Initialized)
                await Task.Delay(250);
            var supported = FactoriesManager.Instance.GetSupportedOfflineDataSources(files).ToList();
            if (supported.Count == 1)
            {
                var parser = supported.First();
                RibbonPage page = (Mapping.ContainsKey(parser.FactoryID)) ? Mapping[parser.FactoryID] : null;
                OpenOfflineLogs(page, files, parser.DataProvider);
            }
            else
            {
                supported = FactoriesManager.Instance.GetSupportedOfflineDataSources(files).Where(itm =>
                    !FactoriesManager.Instance.IsBuiltInFactory(itm.FactoryID)).ToList();
                if (supported.Count == 1)
                {
                    var parser = supported.First();
                    RibbonPage page = (Mapping.ContainsKey(parser.FactoryID)) ? Mapping[parser.FactoryID] : null;
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
                            .GetSupportedOfflineDataSourcesFromFactory(factory.FactoryGuid, files).ToList();
                        RibbonPage page = (Mapping.ContainsKey(factory.FactoryGuid)) ? Mapping[factory.FactoryGuid] : null;
                        if (parser.Count == 1)
                            OpenOfflineLogs(page, files, parser.First());
                        else
                        {
                            XtraMessageBox.Show(
                                $@"More than one data provider detected for this file for {factory.FactoryName}." + Environment.NewLine +
                                "Please open it directly from the data provider menu", "Unable to open file",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }

                    }
                    else

                        XtraMessageBox.Show(
                            "Zero or more than one data provider detected for this file." + Environment.NewLine +
                            "Please open it directly from the data provider menu", "Unable to open file",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }

            }
        }

        private void AnalogyMainForm_DragDrop(object sender, DragEventArgs e)
        {
            // Handle FileDrop data.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Assign the file names to a string array, in 
                // case the user has selected multiple files.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                OpenOfflineFileWithSpecificDataProvider(files);
            }
        }

        private void AnalogyMainForm_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;


        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AnalogyAboutBox ab = new AnalogyAboutBox();
            ab.ShowDialog(this);
        }


        private void tsBtnMail_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start($"mailto:liorbanai@gmail.com?Subject=Analogy App");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error opening mail client", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

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

        private void xtcLogs_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            xtcLogs.TabPages.Remove(arg.Page as XtraTabPage);

        }

        private void AddRecentWindowsEventLogFiles(List<string> files)
        {
            //if (files.Any())
            //{
            //    foreach (string file in files)
            //    {
            //        if (!File.Exists(file)) continue;
            //        BarButtonItem btn = new BarButtonItem();
            //        btn.Caption = file;
            //        btn.ItemClick += (s, be) =>
            //        {
            //            OpenOfflineLogs(new[] { be.Item.Caption });
            //        };
            //        bsiRecent.AddItem(btn);
            //    }
            //}
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

        private void AnalogyMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.UpdateRunningTime();
            settings.Save();
            BookmarkPersistManager.Instance.SaveFile();
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
            offline++;
            var bookmarkLog = new BookmarkLog();
            XtraTabPage page = new XtraTabPage();
            page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            page.Controls.Add(bookmarkLog);
            bookmarkLog.Dock = DockStyle.Fill;
            page.Text = $"Analogy Bookmarked logs #{offline}";
            xtcLogs.TabPages.Add(page);
            xtcLogs.SelectedTabPage = page;
        }

        private void bBtnStatisticsFiltering_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm(0);
            user.ShowDialog(this);
        }

        private void bBtnPreDefinedQueries_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm(1);
            user.ShowDialog(this);
        }

        private void bBtnStatisticsLookAndFeel_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm(2);
            user.ShowDialog(this);
        }

        private void bBtnStatisticsUserStatistics_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm(3);
            user.ShowDialog(this);
        }

        private void bBtnExtensionSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsForm user = new UserSettingsForm(4);
            user.ShowDialog(this);
        }

        private void bBtnCompareLogs_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void bBtnWindowsEventLogs_ItemClick(object sender, ItemClickEventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.Filter = "Windows Event log files (*.evtx)|*.evtx";
            //openFileDialog1.Title = @"Open Files";
            //openFileDialog1.Multiselect = true;
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    OpenOfflineLogs(openFileDialog1.FileNames);
            //    AddRecentFiles(openFileDialog1.FileNames.ToList());
            //}

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


        private void bBtnOnlineEventLogs_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserControl offlineUC = new WindowsEventLog();
            XtraTabPage page = new XtraTabPage();
            page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            page.Controls.Add(offlineUC);
            offlineUC.Dock = DockStyle.Fill;
            page.Text = $"Windows Log";
            xtcLogs.TabPages.Add(page);
            xtcLogs.SelectedTabPage = page;

        }

        private void CreateDataSources()
        {
            foreach (IAnalogyFactory factory in FactoriesManager.Instance.GetFactories()
                .Where(factory => !FactoriesManager.Instance.IsBuiltInFactory(factory) &&
                                  settings.GetFactorySetting(factory.FactoryID).Status != DataProviderFactoryStatus.Disabled))
            {
                CreateDataSource(factory, 3);
            }

        }

        private void CreateDataSource(IAnalogyFactory factory, int position)
        {
            if (factory.Title == null) return;

            RibbonPage ribbonPage = new RibbonPage(factory.Title);
            ribbonControlMain.Pages.Insert(position, ribbonPage);
            Mapping.Add(factory.FactoryID, ribbonPage);

            //todo:move logic to factory manager
            var dataSourceFactory = factory.DataProviders;
            if (dataSourceFactory?.Items != null && dataSourceFactory.Items.Any() &&
                !string.IsNullOrEmpty(dataSourceFactory.Title))
            {
                CreateDataSourceRibbonGroup(dataSourceFactory, ribbonPage);
            }

            var actionFactory = factory.Actions;
            if (actionFactory?.Items != null && actionFactory.Items.Any() && !string.IsNullOrEmpty(actionFactory.Title))
            {
                RibbonPageGroup groupActionSource = new RibbonPageGroup(actionFactory.Title);
                groupActionSource.AllowTextClipping = false;
                ribbonPage.Groups.Add(groupActionSource);
                foreach (IAnalogyCustomAction action in actionFactory.Items)
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

            RibbonPageGroup groupInfoSource = new RibbonPageGroup("About");
            groupInfoSource.Alignment = RibbonPageGroupAlignment.Far;
            BarButtonItem aboutBtn = new BarButtonItem();
            aboutBtn.Caption = "Data Source Information";
            aboutBtn.RibbonStyle = RibbonItemStyles.All;
            groupInfoSource.ItemLinks.Add(aboutBtn);
            aboutBtn.ImageOptions.Image = Resources.About_16x16;
            aboutBtn.ImageOptions.LargeImage = Resources.About_32x32;
            aboutBtn.ItemClick += (sender, e) => { new AboutDataSourceBox(factory).ShowDialog(this); };
            ribbonPage.Groups.Add(groupInfoSource);
        }

        private void CreateDataSourceRibbonGroup(IAnalogyDataProvidersFactory dataSourceFactory, RibbonPage ribbonPage)
        {
            RibbonPageGroup ribbonPageGroup = new RibbonPageGroup(dataSourceFactory.Title);
            ribbonPageGroup.AllowTextClipping = false;
            ribbonPage.Groups.Add(ribbonPageGroup);

            AddRealTimeDataSource(ribbonPage, dataSourceFactory, ribbonPageGroup);
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
            var realtimes = dataSourceFactory.Items.Where(f => f is IAnalogyRealTimeDataProvider)
                .Cast<IAnalogyRealTimeDataProvider>().ToList();
            if (realtimes.Count == 0) return;
            if (realtimes.Count == 1)
            {
                AddSingleRealTimeDataSource(ribbonPage, realtimes.First(), dataSourceFactory.Title, group);
            }
            else
            {
                BarSubItem realTimeMenu = new BarSubItem();
                group.ItemLinks.Add(realTimeMenu);
                realTimeMenu.ImageOptions.Image = Resources.Database_off;
                realTimeMenu.RibbonStyle = RibbonItemStyles.All;
                realTimeMenu.Caption = "Real Time Logs";


                foreach (var realTime in realtimes)
                {


                    BarButtonItem realTimeBtn = new BarButtonItem();
                    realTimeMenu.ItemLinks.Add(realTimeBtn);
                    realTimeBtn.ImageOptions.Image = Resources.Database_off;
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
                            AnalogyLogManager.Instance.LogError("Error during call to canStartReceiving: " + e);
                        }

                        if (canStartReceiving) //connected
                        {
                            online++;
                            realTimeBtn.ImageOptions.Image = Resources.Database_on;
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
                                realTimeBtn.ImageOptions.Image = Resources.Database_off;
                            }

                            XtraTabPage page = new XtraTabPage();
                            page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                            page.Tag = ribbonPage;
                            page.Controls.Add(onlineUC);
                            ribbonControlMain.SelectedPage = ribbonPage;
                            onlineUC.Dock = DockStyle.Fill;
                            page.Text = $"{onlineTitle} #{online} ({dataSourceFactory.Title})";
                            xtcLogs.TabPages.Add(page);
                            realTime.OnMessageReady += OnRealTimeOnMessageReady;
                            realTime.OnManyMessagesReady += OnRealTimeOnOnManyMessagesReady;
                            realTime.OnDisconnected += OnRealTimeDisconnected;
                            realTime.StartReceiving();
                            onlineDataSourcesMapping.Add(page, realTime);
                            xtcLogs.SelectedTabPage = page;

                            void OnXtcLogsOnControlRemoved(object sender, ControlEventArgs arg)
                            {
                                if (arg.Control == page)
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
                                            "Error during call to Stop receiving: " + e);
                                    }
                                    finally
                                    {
                                        xtcLogs.ControlRemoved -= OnXtcLogsOnControlRemoved;
                                    }
                                }
                            }

                            xtcLogs.ControlRemoved += OnXtcLogsOnControlRemoved;
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

                    /// 
                }
            }
        }

        private void AddOfflineDataSource(RibbonPage ribbonPage, IAnalogyDataProvidersFactory factory, RibbonPageGroup group)
        {

            var offlineProviders = factory.Items.Where(f => f is IAnalogyOfflineDataProvider)
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
                offline++;
                UserControl offlineUC = new OfflineUCLogs(dataProvider, files, initialFolder);
                XtraTabPage page = new XtraTabPage();
                page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                page.Tag = ribbonPage;
                page.Controls.Add(offlineUC);
                offlineUC.Dock = DockStyle.Fill;
                page.Text = $"{offlineTitle} #{offline} ({titleOfDataSource})";
                xtcLogs.TabPages.Add(page);
                xtcLogs.SelectedTabPage = page;
            }

            void OpenExternalDataSource(string titleOfDataSource, IAnalogyOfflineDataProvider analogy)
            {
                offline++;
                var ClientServerUCLog = new ClientServerUCLog(analogy);
                XtraTabPage page = new XtraTabPage();
                page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                page.Tag = ribbonPage;
                page.Controls.Add(ClientServerUCLog);
                ClientServerUCLog.Dock = DockStyle.Fill;
                page.Text = $"Client/Server logs #{offline}. {titleOfDataSource}";
                xtcLogs.TabPages.Add(page);
                xtcLogs.SelectedTabPage = page;
            }

            void OpenFilePooling(string titleOfDataSource, IAnalogyOfflineDataProvider dataProvider,
                string initialFolder, string file)
            {

                offline++;
                UserControl filepoolingUC = new FilePoolingUCLogs(dataProvider, file, initialFolder);
                XtraTabPage page = new XtraTabPage();

                void OnXtcLogsOnControlRemoved(object sender, ControlEventArgs arg)
                {
                    if (arg.Control == page)
                    {
                        try
                        {
                            filepoolingUC.Dispose();
                        }
                        catch (Exception e)
                        {
                            AnalogyLogManager.Instance.LogError("Error during dispose: " + e);
                        }
                        finally
                        {
                            xtcLogs.ControlRemoved -= OnXtcLogsOnControlRemoved;
                        }
                    }
                }

                page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                page.Tag = ribbonPage;
                page.Controls.Add(filepoolingUC);
                filepoolingUC.Dock = DockStyle.Fill;
                page.Text = $"{filePoolingTitle} #{filePooling} ({titleOfDataSource})";
                xtcLogs.TabPages.Add(page);
                xtcLogs.SelectedTabPage = page;
                xtcLogs.ControlRemoved += OnXtcLogsOnControlRemoved;
            }


            //recent bar
            BarSubItem recentBar = new BarSubItem();
            recentBar.Caption = "Recently Used Files";
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
                var recents = UserSettingsManager.UserSettings.RecentFiles.Where(itm => itm.ID == dataProvider.ID)
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
                offline++;
                UserControl offlineUC = new OfflineUCLogs(offlineAnalogy, files, initialFolder);
                XtraTabPage page = new XtraTabPage();
                page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                page.Tag = ribbonPage;
                page.Controls.Add(offlineUC);
                offlineUC.Dock = DockStyle.Fill;
                page.Text = $"{offlineTitle} #{offline} ({titleOfDataSource})";
                xtcLogs.TabPages.Add(page);
                xtcLogs.SelectedTabPage = page;
            }

            void OpenExternalDataSource(string titleOfDataSource, IAnalogyOfflineDataProvider analogy)
            {
                offline++;
                var ClientServerUCLog = new ClientServerUCLog(analogy);
                XtraTabPage page = new XtraTabPage();
                page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                page.Tag = ribbonPage;
                page.Controls.Add(ClientServerUCLog);
                ClientServerUCLog.Dock = DockStyle.Fill;
                page.Text = $"Client/Server logs #{offline}. {titleOfDataSource}";
                xtcLogs.TabPages.Add(page);
                xtcLogs.SelectedTabPage = page;
            }

            void OpenFilePooling(string titleOfDataSource, string initialFolder, string file)
            {

                offline++;
                UserControl filepoolingUC = new FilePoolingUCLogs(offlineAnalogy, file, initialFolder);
                XtraTabPage page = new XtraTabPage();

                void OnXtcLogsOnControlRemoved(object sender, ControlEventArgs arg)
                {
                    if (arg.Control == page)
                    {
                        try
                        {
                            filepoolingUC.Dispose();
                        }
                        catch (Exception e)
                        {
                            AnalogyLogManager.Instance.LogError("Error during dispose: " + e);
                        }
                        finally
                        {
                            xtcLogs.ControlRemoved -= OnXtcLogsOnControlRemoved;
                        }
                    }
                }

                page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                page.Tag = ribbonPage;
                page.Controls.Add(filepoolingUC);
                filepoolingUC.Dock = DockStyle.Fill;
                page.Text = $"{filePoolingTitle} #{filePooling} ({titleOfDataSource})";
                xtcLogs.TabPages.Add(page);
                xtcLogs.SelectedTabPage = page;
                xtcLogs.ControlRemoved += OnXtcLogsOnControlRemoved;
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

            //recent bar
            BarSubItem recentBar = new BarSubItem();
            recentBar.Caption = "Recently Used Files";
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
            var recents = UserSettingsManager.UserSettings.RecentFiles.Where(itm => itm.ID == offlineAnalogy.ID)
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
            realTimeBtn.ImageOptions.Image = Resources.Database_off;
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
                    AnalogyLogManager.Instance.LogError("Error during call to canStartReceiving: " + e);
                }

                if (canStartReceiving) //connected
                {
                    online++;
                    realTimeBtn.ImageOptions.Image = Resources.Database_on;
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
                        realTimeBtn.ImageOptions.Image = Resources.Database_off;
                    }

                    XtraTabPage page = new XtraTabPage();
                    page.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    page.Tag = ribbonPage;
                    page.Controls.Add(onlineUC);
                    ribbonControlMain.SelectedPage = ribbonPage;
                    onlineUC.Dock = DockStyle.Fill;
                    page.Text = $"{onlineTitle} #{online} ({title})";
                    xtcLogs.TabPages.Add(page);
                    realTime.OnMessageReady += OnRealTimeOnMessageReady;
                    realTime.OnManyMessagesReady += OnRealTimeOnOnManyMessagesReady;
                    realTime.OnDisconnected += OnRealTimeDisconnected;
                    realTime.StartReceiving();
                    onlineDataSourcesMapping.Add(page, realTime);
                    xtcLogs.SelectedTabPage = page;

                    void OnXtcLogsOnControlRemoved(object sender, ControlEventArgs arg)
                    {
                        if (arg.Control == page)
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
                                AnalogyLogManager.Instance.LogError("Error during call to Stop receiving: " + e);
                            }
                            finally
                            {
                                xtcLogs.ControlRemoved -= OnXtcLogsOnControlRemoved;
                            }
                        }
                    }

                    xtcLogs.ControlRemoved += OnXtcLogsOnControlRemoved;
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



        private void XtcLogs_MouseUp(object sender, MouseEventArgs e)
        {
            //disable for now  until the devexpress issue is resolved
            if (e.Button == MouseButtons.Right)
            {
                XtraTabControl tabCtrl = sender as XtraTabControl;
                Point pt = MousePosition;
                XtraTabHitInfo info = tabCtrl.CalcHitInfo(tabCtrl.PointToClient(pt));
                if (info.HitTest == XtraTabHitTest.PageHeader)
                {
                    currentContextPage = info.Page;
                    popupMenuTabPages.ShowPopup(pt);
                }
            }
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


        private void CloseCurrentTabPage()
        {
            if (currentContextPage != null)
            {
                if (onlineDataSourcesMapping.ContainsKey(currentContextPage))
                {
                    onlineDataSourcesMapping[currentContextPage].StopReceiving();
                    onlineDataSourcesMapping.Remove(currentContextPage);
                }

                xtcLogs.TabPages.Remove(currentContextPage);
                currentContextPage = null;


            }
        }

        private void bbiFileCaching_ItemClick(object sender, ItemClickEventArgs e)
        {
            settings.EnableFileCaching = !settings.EnableFileCaching;
            bbiFileCaching.Caption = "File caching is " + (settings.EnableFileCaching ? "on" : "off");
        }

        private void bBtnDataProviderSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsDataProvidersForm user = new UserSettingsDataProvidersForm();
            user.ShowDialog(this);
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
                        AnalogyLogManager.Instance.LogError("Error during export settings: " + e);
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
    }
}

