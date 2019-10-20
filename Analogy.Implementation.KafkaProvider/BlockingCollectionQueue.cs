using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Analogy.Implementation.KafkaProvider
{
    public class BlockingCollectionQueue<T>
    {
        private BlockingCollection<T> items = new BlockingCollection<T>(new ConcurrentQueue<T>());

        public void Enqueue(T item) => items.Add(item);
        public int Count => items.Count;

        public void CompleteAdding() => items.CompleteAdding();
        public IEnumerable<T> GetConsumingEnumerable(CancellationToken cancellationToken)
        {

            foreach (var item in items.GetConsumingEnumerable(cancellationToken))
            {
                yield return item;
            }

        }

    }
}
