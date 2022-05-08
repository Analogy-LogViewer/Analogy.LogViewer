using Analogy.Interfaces.DataTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;


namespace Analogy.DataTypes
{
    public class PlottingGraphData
    {
        public int DataWindow { get; set; }
        public ObservableCollectionEx<AnalogyPlottingPointData> ViewportData { get; }
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
            ViewportData = new ObservableCollectionEx<AnalogyPlottingPointData>(sync);
            rawData = new List<AnalogyPlottingPointData>();
            RefreshDataTimer = new Timer(RefreshDataTimerTick, null, Timeout.Infinite, (long)RefreshIntervalSeconds * 1000);
        }

        private void RefreshDataTimerTick(object sender)
        {
            var changed = false;
            List<AnalogyPlottingPointData> newData = new List<AnalogyPlottingPointData>();
            try
            {
                sync.EnterWriteLock();
                ViewportData._suppressNotification = true;
                for (int i = Math.Max(lastRawDataIndex, rawData.Count - DataWindow); i < rawData.Count; i++)
                {
                    newData.Add(rawData[i]);
                    ViewportData.Add(rawData[i]);
                    changed = true;
                }
                lastRawDataIndex = rawData.Count;
                while (ViewportData.Count > DataWindow)
                {
                    ViewportData.RemoveAt(0);
                }

            }
            finally
            {
                ViewportData._suppressNotification = false;
                if (changed)
                {
                    ViewportData.RaiseChanged(newData);
                }
                sync.ExitWriteLock();
       
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
        public void AddDataPoints(List<AnalogyPlottingPointData> data)
        {
            try
            {
                sync.EnterWriteLock();
                rawData.AddRange(data);
            }
            finally
            {
                sync.ExitWriteLock();

            }
        }

        public void SetIntervalValue(float seconds)
        {
            RefreshIntervalSeconds = seconds;
            RefreshDataTimer.Change((long)(RefreshIntervalSeconds * 1000), (long)(RefreshIntervalSeconds * 1000));
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

        public void Start()
        {
            RefreshDataTimer.Change(0, (long)(RefreshIntervalSeconds * 1000));
        }

        public void SetWindowValue(int windowValue)
        {
            DataWindow = windowValue;
        }
    }
}
