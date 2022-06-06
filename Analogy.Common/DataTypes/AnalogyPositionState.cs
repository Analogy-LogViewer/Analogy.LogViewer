using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.Common.DataTypes
{
    [Serializable]
    public class AnalogyPositionState
    {
        public FormWindowState WindowState { get; set; }
        public Point Location { get; set; }
        public Size Size { get; set; }
        public bool RememberLastPosition { get; set; }

        public AnalogyPositionState()
        {
            WindowState = FormWindowState.Maximized;
            RememberLastPosition = true;
        }

        public AnalogyPositionState(FormWindowState formWindowState, Point location, Size size)
        {
            WindowState = formWindowState;
            Location = location;
            Size = size;
        }

    }
}
