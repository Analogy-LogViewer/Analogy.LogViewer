using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Interfaces;
using Analogy.Managers;
using DevExpress.XtraEditors;

namespace Analogy.ApplicationSettings
{
    public partial class ColorSettingsUC : DevExpress.XtraEditors.XtraUserControl
    {
        private UserSettingsManager Settings { get; } = UserSettingsManager.UserSettings;

        public ColorSettingsUC()
        {
            InitializeComponent();
        }

        private void ColorSettingsUC_Load(object sender, EventArgs e)
        {
            LoadSettings();
            LoadColorsSettings();
            SetupEventsHandlers();
        }
        private void LoadSettings()
        {
        }
        private void SetupEventsHandlers()
        {
            tsEnableColors.IsOnChanged += (s, e) => Settings.ColorSettings.EnableMessagesColors = tsEnableColors.IsOn;
            ceOverrideLogLevelColor.CheckedChanged+=(s,e)=> Settings.ColorSettings.OverrideLogLevelColor = ceOverrideLogLevelColor.Checked;

            sBtnExportColors.Click += (s, e) =>
            {
                UpdateColors();
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Analogy Color Settings (*.json)|*.json";
                saveFileDialog.Title = @"Export Analogy Color settings";

                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {

                    try
                    {
                        File.WriteAllText(saveFileDialog.FileName, Settings.ColorSettings.AsJson());
                        XtraMessageBox.Show("File Saved", @"Export settings", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        AnalogyLogManager.Instance.LogError("Error during save to file: " + e,"");
                        XtraMessageBox.Show("Error Export: " + ex.Message, @"Error Saving file", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                }
            };

            sBtnImportColors.Click += (s, e) =>
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Analogy Color Settings (*.json)|*.json";
                openFileDialog1.Title = @"Import NLog settings";
                openFileDialog1.Multiselect = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var json = File.ReadAllText(openFileDialog1.FileName);
                        ColorSettings color = ColorSettings.FromJson(json);
                        Settings.ColorSettings = color;
                        LoadColorsSettings();
                        XtraMessageBox.Show("File Imported. Save settings if desired", @"Import settings",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        AnalogyLogManager.Instance.LogError("Error during import data: " + e, "");
                        XtraMessageBox.Show("Error Import: " + ex.Message, @"Error Import file", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            };

            ceNewMessagesColor.CheckedChanged += (s, e) =>
              {
                  cpeNewMessagesColor.Enabled = ceNewMessagesColor.Checked;
                  Settings.ColorSettings.EnableNewMessagesColor = ceNewMessagesColor.Checked;
              };
            cpeLogLevelUnknown.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelUnknownText.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelDisabled.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelDisabledText.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelTrace.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelTraceText.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelVerbose.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelVerboseText.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelDebug.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelDebugText.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelInformation.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelInformationText.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelWarning.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelWarningText.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelError.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelErrorText.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelCritical.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelCriticalText.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelAnalogyInformation.ColorChanged += (s, e) => UpdateColors();
            cpeLogLevelAnalogyInformationText.ColorChanged += (s, e) => UpdateColors();
            cpeHighlightColor.ColorChanged += (s, e) => UpdateColors();
            cpeHighlightColorText.ColorChanged += (s, e) => UpdateColors();
            cpeNewMessagesColor.ColorChanged += (s, e) => UpdateColors();
            cpeNewMessagesColorText.ColorChanged += (s, e) => UpdateColors();

        }

        private void UpdateColors()
        {
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Unknown, cpeLogLevelUnknown.Color, cpeLogLevelUnknownText.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.None, cpeLogLevelDisabled.Color, cpeLogLevelDisabledText.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Trace, cpeLogLevelTrace.Color, cpeLogLevelTraceText.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Verbose, cpeLogLevelVerbose.Color, cpeLogLevelVerboseText.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Debug, cpeLogLevelDebug.Color, cpeLogLevelDebugText.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Information, cpeLogLevelInformation.Color, cpeLogLevelInformationText.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Warning, cpeLogLevelWarning.Color, cpeLogLevelWarningText.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Error, cpeLogLevelError.Color, cpeLogLevelErrorText.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Critical, cpeLogLevelCritical.Color, cpeLogLevelCriticalText.Color);
            Settings.ColorSettings.SetColorForLogLevel(AnalogyLogLevel.Analogy, cpeLogLevelAnalogyInformation.Color, cpeLogLevelAnalogyInformationText.Color);
            Settings.ColorSettings.SetHighlightColor(cpeHighlightColor.Color, cpeHighlightColorText.Color);
            Settings.ColorSettings.SetNewMessagesColor(cpeNewMessagesColor.Color, cpeNewMessagesColorText.Color);
            Settings.ColorSettings.EnableMessagesColors = true;
            tsEnableColors.IsOn = true;
        }
        private void LoadColorsSettings()
        {
            tsEnableColors.IsOn = Settings.ColorSettings.EnableMessagesColors;
            cpeLogLevelUnknown.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Unknown).BackgroundColor;
            cpeLogLevelDisabled.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.None).BackgroundColor;
            cpeLogLevelTrace.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Trace).BackgroundColor;
            cpeLogLevelVerbose.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Verbose).BackgroundColor;
            cpeLogLevelDebug.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Debug).BackgroundColor;
            cpeLogLevelInformation.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Information).BackgroundColor;
            cpeLogLevelWarning.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Warning).BackgroundColor;
            cpeLogLevelError.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Error).BackgroundColor;
            cpeLogLevelCritical.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Critical).BackgroundColor;
            cpeLogLevelAnalogyInformation.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Analogy).BackgroundColor;
            cpeHighlightColor.Color = Settings.ColorSettings.GetHighlightColor().BackgroundColor;
            cpeNewMessagesColor.Color = Settings.ColorSettings.GetNewMessagesColor().BackgroundColor;

            cpeLogLevelUnknownText.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Unknown).TextColor;
            cpeLogLevelDisabledText.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.None).TextColor;
            cpeLogLevelTraceText.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Trace).TextColor;
            cpeLogLevelVerboseText.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Verbose).TextColor;
            cpeLogLevelDebugText.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Debug).TextColor;
            cpeLogLevelInformationText.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Information).TextColor;
            cpeLogLevelWarningText.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Warning).TextColor;
            cpeLogLevelErrorText.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Error).TextColor;
            cpeLogLevelCriticalText.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Critical).TextColor;
            cpeLogLevelAnalogyInformationText.Color = Settings.ColorSettings.GetColorForLogLevel(AnalogyLogLevel.Analogy).TextColor;
            cpeHighlightColorText.Color = Settings.ColorSettings.GetHighlightColor().TextColor;
            cpeNewMessagesColorText.Color = Settings.ColorSettings.GetNewMessagesColor().TextColor;
            ceNewMessagesColor.Checked = Settings.ColorSettings.EnableNewMessagesColor;
            ceOverrideLogLevelColor.Checked = Settings.ColorSettings.OverrideLogLevelColor;

            lblLogLevelUnknown.BackColor = cpeLogLevelUnknown.Color;
            lblLogLevelDisabled.BackColor = cpeLogLevelDisabled.Color;
            lblLogLevelTrace.BackColor = cpeLogLevelTrace.Color;
            lblLogLevelVerbose.BackColor = cpeLogLevelVerbose.Color;
            lblLogLevelDebug.BackColor = cpeLogLevelDebug.Color;
            lblLogLevelEvent.BackColor = cpeLogLevelInformation.Color;
            lblLogLevelWarning.BackColor = cpeLogLevelWarning.Color;
            lblLogLevelError.BackColor = cpeLogLevelError.Color;
            lblLogLevelCritical.BackColor = cpeLogLevelCritical.Color;
            lblLogLevelAnalogyInformation.BackColor = cpeLogLevelAnalogyInformation.Color;
            lblHighlightColor.BackColor = cpeHighlightColor.Color;
            ceNewMessagesColor.BackColor = cpeNewMessagesColor.Color;
            lblLogLevelUnknown.ForeColor = cpeLogLevelUnknownText.Color;
            lblLogLevelDisabled.ForeColor = cpeLogLevelDisabledText.Color;
            lblLogLevelTrace.ForeColor = cpeLogLevelTraceText.Color;
            lblLogLevelVerbose.ForeColor = cpeLogLevelVerboseText.Color;
            lblLogLevelDebug.ForeColor = cpeLogLevelDebugText.Color;
            lblLogLevelEvent.ForeColor = cpeLogLevelInformationText.Color;
            lblLogLevelWarning.ForeColor = cpeLogLevelWarningText.Color;
            lblLogLevelError.ForeColor = cpeLogLevelErrorText.Color;
            lblLogLevelCritical.ForeColor = cpeLogLevelCriticalText.Color;
            lblLogLevelAnalogyInformation.ForeColor = cpeLogLevelAnalogyInformationText.Color;
            lblHighlightColor.ForeColor = cpeHighlightColorText.Color;
            ceNewMessagesColor.ForeColor = cpeNewMessagesColorText.Color;

        }

    }
}
