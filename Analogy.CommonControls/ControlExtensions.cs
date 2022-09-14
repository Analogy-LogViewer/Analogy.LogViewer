using System;
using System.Windows.Forms;

namespace Analogy.CommonControls
{
    public static class ControlExtensions
    {
        public static T InvokeIfRequired<T>(this T source, Action<T> action) where T : Control
        {
            try
            {
                if (!source.InvokeRequired)
                {
                    action(source);
                }
                else
                {
                    source.Invoke(new Action(() => action(source)));
                }
            }
            catch (Exception ex)
            {
                //ignore
            }
            return source;
        }
    }
}
