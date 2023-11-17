using Analogy.Common.DataTypes;
using Analogy.Common.Interfaces;
using Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.Common
{
    public static class CommonUtils
    {
        public static string ColumnThreadId => nameof(AnalogyLogMessage.ThreadId);
        public static string ColumnProcessId => nameof(AnalogyLogMessage.ProcessId);
        public static string ColumnModule => nameof(AnalogyLogMessage.Module);
        public static string ColumnRawText => nameof(AnalogyLogMessage.RawText);
        public static string AnalogyMessageColumn { get; } = Guid.NewGuid().ToString();
        public static List<string> LogLevels { get; } = Enum.GetValues(typeof(AnalogyLogLevel)).Cast<AnalogyLogLevel>().Select(e => e.ToString()).ToList();


        public static void RepositionIfNeeded(Form form, Guid id, IUserSettingsManager settings)
        {
            if (settings.TryGetWindowPosition(id,out var position))
            {
                if (position!.RememberLastPosition || position.WindowState != FormWindowState.Minimized)
                {
                    form.WindowState = position.WindowState;
                    if (form.WindowState != FormWindowState.Maximized)
                    {
                        if (Screen.AllScreens.Any(s => s.WorkingArea.Contains(position.Location)))
                        {
                            form.Location = position.Location;
                            form.Size = position.Size;
                        }
                    }
                }
            }
        }

        public static AnalogyPositionState CreatePosition(Form form)
        {
            AnalogyPositionState position = new AnalogyPositionState(form.WindowState, form.Location, form.Size);
            return position;
        }
    }
}