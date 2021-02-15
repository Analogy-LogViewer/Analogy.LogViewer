using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Analogy.DataProviders;
using Analogy.DataTypes;
using Analogy.Forms;
using Analogy.Managers;
using Analogy.Properties;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;

namespace Analogy
{
    public partial class FluentDesignMainForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FluentDesignMainForm()
        {
            InitializeComponent();
        }

        private void FluentDesignMainForm_Load(object sender, EventArgs e)
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
            CreateDataSources();

            //set Default page:
            Guid defaultPage = new Guid(settings.InitialSelectedDataProvider);
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
    }
}
