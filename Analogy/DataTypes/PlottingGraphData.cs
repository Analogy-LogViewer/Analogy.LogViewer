using Analogy.Interfaces.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace Analogy.DataTypes
{
    public class PlottingGraphData
    {
        public int DataWindow { get; }
        public ObservableCollection<AnalogyPlottingPointData> ViewportData { get; }
        private List<AnalogyPlottingPointData> rawData;
        private ReaderWriterLockSlim sync;
        private int refreshIntervalMilliseconds = 1000;
        private Timer RefreshData;
        private int lastRawDataIndex = 0;
        public PlottingGraphData(int refreshIntervalMilliseconds, int dataWindow)
        {
            DataWindow = dataWindow;
            this.refreshIntervalMilliseconds = refreshIntervalMilliseconds;
            sync = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
            ViewportData = new ObservableCollection<AnalogyPlottingPointData>();
            rawData = new List<AnalogyPlottingPointData>();
            RefreshData = new Timer();
            RefreshData.Interval = refreshIntervalMilliseconds;
            RefreshData.Tick += RefreshData_Tick;
        }

        private void RefreshData_Tick(object sender, System.EventArgs e)
        {
            try
            {
                sync.EnterReadLock();
                for (int i = Math.Max(lastRawDataIndex, rawData.Count - DataWindow); i < rawData.Count; i++)
                {
                    ViewportData.Add(rawData[i]);
                }
                lastRawDataIndex = rawData.Count;
                while (ViewportData.Count > DataWindow)
                {
                    ViewportData.RemoveAt(0);
                }

            }
            finally
            {
                sync.ExitReadLock();

            }

        }

        public void AddDataPoint(AnalogyPlottingPointData data)
        {
            try
            {
                sync.EnterWriteLock();
                rawData.Add(data);
            }
            finally
            {
                sync.ExitWriteLock();

            }
        }

        public void Clear()
        {
            try
            {
                sync.EnterWriteLock();
                rawData.Clear();
                lastRawDataIndex = 0;
            }
            finally
            {
                sync.ExitWriteLock();

            }
        }

    }
}
