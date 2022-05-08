using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Interfaces.DataTypes;

namespace Analogy.DataTypes
{
    public class ObservableCollectionEx<T> : ObservableCollection<T>
    {
        public bool _suppressNotification = false;
        private ReaderWriterLockSlim _sync;
        public ObservableCollectionEx(        ReaderWriterLockSlim sync):base()
        {
            _sync = sync;
        }
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_suppressNotification)
            {
                try
                {
                    _sync.EnterWriteLock();
                    base.OnCollectionChanged(e);
                }
                finally
                {
                    _sync.ExitWriteLock();

                }

            }
        }
        public void AddRange(IEnumerable<T> list)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            _suppressNotification = true;

            foreach (T item in list)
            {
                Add(item);
            }

            _suppressNotification = false;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void RaiseChanged(List<AnalogyPlottingPointData> newData)
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}