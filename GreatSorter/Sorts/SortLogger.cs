using System;
using System.Collections.Generic;
using System.Linq;

namespace GreatSorter
{
    public class SortLogger<T> : IObserver
        where T : IComparable
    {
        public int Count => logs.Count;

        private T[] start;
        public List<SwapIndexes> logs;

        public SortLogger(SortableArray<T> sortableArray)
        {
            start = sortableArray.GetValues.ToArray();
            sortableArray.RegisterObserver(this);
            logs = new List<SwapIndexes>();
        }

        public void Update(object sender, object eventData)
        {
            logs.Add((SwapIndexes)eventData);
        }

        private IEnumerable<T[]> CreateLog()
        {
            yield return start;

            var array = (T[])start.Clone();
            foreach (var e in logs)
            {
                (array[e.First], array[e.Second]) = (array[e.Second], array[e.First]);
                yield return array;
            }
        }

        public Queue<T[]> GetLog()
        {
            var result = new Queue<T[]>();

            foreach (var e in CreateLog())
            {
                result.Enqueue((T[])e.Clone());
            }

            return result;
        }

        public override string ToString()
        {
            var result = GetLog().Select(x => String.Join(", ", x));
            return String.Join("\n", result);
        }
    }
}