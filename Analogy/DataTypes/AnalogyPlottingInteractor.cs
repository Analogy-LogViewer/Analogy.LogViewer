using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Interfaces;
using Analogy.Managers;
using DevExpress.XtraEditors;

namespace Analogy.DataTypes
{
   public class AnalogyPlottingInteractor: IAnalogyPlottingInteractor
    {
        public SpinEdit WindowSpinEdit { get; set; }
        public void SetDefaultWindow(int numberOfPointsInWindow)
        {
            if (numberOfPointsInWindow <= 0)
            {
                AnalogyLogManager.Instance.LogError($"Invalid Set default windows: {numberOfPointsInWindow}","");
                return;
            }
            if (WindowSpinEdit.IsHandleCreated && !WindowSpinEdit.IsDisposed)
            {
                WindowSpinEdit.BeginInvoke(new MethodInvoker(() => { WindowSpinEdit.Value = numberOfPointsInWindow; }));
            }
        }
    }
}
