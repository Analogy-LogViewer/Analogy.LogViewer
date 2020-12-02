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
        public int DataWindow { get; set; }
        public ObservableCollection<AnalogyPlottingPointData> ViewportData { get; }
        private List<AnalogyPlottingPointData> rawData;
        private ReaderWriterLockSlim sync;
        private float RefreshIntervalSeconds { get; set; }
        private Timer RefreshDataTimer;
        private int lastRawDataIndex = 0;
        public PlottingGraphData(float refreshIntervalSeconds, int dataWindow)
        {
            DataWindow = dataWindow;
            RefreshIntervalSeconds = refreshIntervalSeconds;
            sync = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
            ViewportData = new ObservableCollection<AnalogyPlottingPointData>();
            rawData = new List<AnalogyPlottingPointData>();
            RefreshDataTimer = new Timer();
            RefreshDataTimer.Interval = (int)(RefreshIntervalSeconds * 1000);
            RefreshDataTimer.Tick += RefreshDataTimerTick;
        }

        private void RefreshDataTimerTick(object sender, EventArgs e)
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

        public void SetIntervalValue(float seconds) => RefreshDataTimer.Interval = (int)(seconds * 1000);
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

        public void Start()
        {
            RefreshDataTimer.Enabled = true;
        }

        public void SetWindowValue(int windowValue)
        {
            DataWindow = windowValue;
        }
    }
}
