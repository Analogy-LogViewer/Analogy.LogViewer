﻿using System;
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
        public bool WasSet { get;private set; }
        public int WindowSize { get; set; }
        public SpinEdit WindowSpinEdit { get; set; }
        public AnalogyPlottingPointXAxisDataType XAxisDataType { get; private set; }

        public AnalogyPlottingInteractor()
        {
            XAxisDataType = AnalogyPlottingPointXAxisDataType.DateTime;
        }
        public void SetDefaultWindow(int numberOfPointsInWindow)
        {
            if (numberOfPointsInWindow <= 0)
            {
                AnalogyLogManager.Instance.LogError($"Invalid Set default windows: {numberOfPointsInWindow}","");
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