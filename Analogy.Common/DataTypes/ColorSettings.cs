using Analogy.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Common.DataTypes
{
    [Serializable]
    public class ColorSettings
    {
        public bool EnableMessagesColors { get; set; }
        public Dictionary<AnalogyLogLevel, (Color BackgroundColor, Color TextColor)> LogLevelColors { get; set; }

        public (Color BackgroundColor, Color TextColor) HighlightColor { get; set; }
        public (Color BackgroundColor, Color TextColor) NewMessagesColor { get; set; }
        public bool EnableNewMessagesColor { get; set; }
        public bool OverrideLogLevelColor { get; set; }

        public ColorSettings()
        {
            EnableMessagesColors = true;
            HighlightColor = (Color.Aqua, Color.Black);
            NewMessagesColor = (Color.PaleTurquoise, Color.Black);
            var logLevelValues = Enum.GetValues(typeof(AnalogyLogLevel));
            LogLevelColors = new Dictionary<AnalogyLogLevel, (Color BackgroundColor, Color TextColor)>(logLevelValues.Length);

            foreach (AnalogyLogLevel level in logLevelValues)

            {
                switch (level)
                {
                    case AnalogyLogLevel.Unknown:
                        LogLevelColors.Add(level, (Color.White, Color.Black));
                        break;
                    case AnalogyLogLevel.None:
                        LogLevelColors.Add(level, (Color.LightGray, Color.Black));
                        break;
                    case AnalogyLogLevel.Trace:
                        LogLevelColors.Add(level, (Color.White, Color.Black));
                        break;
                    case AnalogyLogLevel.Verbose:
                        LogLevelColors.Add(level, (Color.White, Color.Black));
                        break;
                    case AnalogyLogLevel.Debug:
                        LogLevelColors.Add(level, (Color.White, Color.Black));
                        break;
                    case AnalogyLogLevel.Information:
                        LogLevelColors.Add(level, (Color.White, Color.Black));
                        break;
                    case AnalogyLogLevel.Warning:
                        LogLevelColors.Add(level, (Color.Yellow, Color.Black));
                        break;
                    case AnalogyLogLevel.Error:
                        LogLevelColors.Add(level, (Color.Pink, Color.Black));
                        break;
                    case AnalogyLogLevel.Critical:
                        LogLevelColors.Add(level, (Color.Red, Color.Black));
                        break;
                    case AnalogyLogLevel.Analogy:
                        LogLevelColors.Add(level, (Color.White, Color.Black));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (Color BackgroundColor, Color TextColor) GetColorForLogLevel(AnalogyLogLevel level) => LogLevelColors[level];

        public (Color BackgroundColor, Color TextColor) GetHighlightColor() => HighlightColor;
        public (Color BackgroundColor, Color TextColor) GetNewMessagesColor() => NewMessagesColor;

        public void SetColorForLogLevel(AnalogyLogLevel level, Color backgroundColor, Color textColor) => LogLevelColors[level] = (backgroundColor, textColor);
        public void SetHighlightColor(Color backgroundColor, Color textColor) => HighlightColor = (backgroundColor, textColor);
        public void SetNewMessagesColor(Color backgroundColor, Color textColor) => NewMessagesColor = (backgroundColor, textColor);
        public string AsJson() => JsonConvert.SerializeObject(this);
        public static ColorSettings FromJson(string fileName) => JsonConvert.DeserializeObject<ColorSettings>(fileName);
    }
}
