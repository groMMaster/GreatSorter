using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatSorter
{
    public class SortableArray<T>
        where T : IComparable
    {
        private T[] values;
        public int Length => values.Length;

        private event EventHandler observers;

        public SortableArray(params T[] values)
        {
            this.values = values;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            values.Swap(firstIndex, secondIndex);
            NotifyObserver(new SwapIndexes(firstIndex, secondIndex));
        }

        public int IndexOfMin(int startIndex)
        {
            int result = startIndex;
            for (var i = startIndex; i < values.Length; ++i)
            {
                if (values[i].CompareTo(values[result]) < 0)
                {
                    result = i;
                }
            }

            return result;
        }

        public void RegisterObserver(IObserver observer)
        {
            observers += observer.Update;
        }

        public void NotifyObserver(EventArgs eventData)
        {
            observers?.Invoke(this, eventData);
        }

        public void RemoveObserver(SortLog<T> observer)
        {
            observers -= observer.Update;
        }

        public T this[int index]
        {
            get
            {
                return values[index];
            }
        }

        public override string ToString()
        {
            var strvalues = values.Select(x => x.ToString());
            return String.Join(" ", strvalues);
        }
    }

    public class SwapIndexes : EventArgs
    { 
        public int First { get; }
        public int Second { get; }

        public SwapIndexes(int first, int second)
        {
            First = first;
            Second = second;
        }
    }
}
