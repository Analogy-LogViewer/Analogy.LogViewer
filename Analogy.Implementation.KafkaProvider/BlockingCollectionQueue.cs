using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Analogy.Implementation.KafkaProvider
{
    public class BlockingCollectionQueue<T>
    {
        private readonly BlockingCollection<T> _items = new BlockingCollection<T>(new ConcurrentQueue<T>());

        public void Enqueue(T item) => _items.Add(item);
        public int Count => _items.Count;

        public void CompleteAdding() => _items.CompleteAdding();
        public IEnumerable<T> GetConsumingEnumerable(CancellationToken cancellationToken)
        {

            foreach (var item in _items.GetConsumingEnumerable(cancellationToken))
            {
                yield return item;
            }

        }

    }
}
