using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.CommonControls.DataTypes
{
    public class AnalogyPlottingInteractor : IAnalogyPlottingInteractor
    {
        public bool WasSet { get; private set; }
        public int WindowSize { get; set; }
        public SpinEdit WindowSpinEdit { get; set; }
        public AnalogyPlottingPointXAxisDataType XAxisDataType { get; private set; }

        public AnalogyPlottingInteractor()
        {
            XAxisDataType = AnalogyPlottingPointXAxisDataType.DateTime;
        }

        public AnalogyPlottingInteractor(AnalogyPlottingPointXAxisDataType xAxisDataType, int windowSize)
        {
            XAxisDataType = xAxisDataType;
            WindowSize = windowSize;
        }
        public void SetDefaultWindow(int numberOfPointsInWindow)
        {
            if (numberOfPointsInWindow <= 0)
            {
                return;
            }

            WindowSize = numberOfPointsInWindow;
            WasSet = true;
            if (WindowSpinEdit.IsHandleCreated && !WindowSpinEdit.IsDisposed)
            {
                WindowSpinEdit.BeginInvoke(new MethodInvoker(() => { WindowSpinEdit.Value = numberOfPointsInWindow; }));
            }
        }

        public void SetXAxisType(AnalogyPlottingPointXAxisDataType xAxisDataType)
        {
            XAxisDataType = xAxisDataType;
        }
    }
}