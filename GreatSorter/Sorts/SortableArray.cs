using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatSorter
{
    public class SortableArray<T>
        where T : IComparable
    {
        public T[] Values { get; }
        public int Length => Values.Length;

        private event EventHandler observers;

        public SortableArray(params T[] values)
        {
            Values = values;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var temp = Values[firstIndex];
            Values[firstIndex] = Values[secondIndex];
            Values[secondIndex] = temp;
            NotifyObserver(new SwapIndexes(firstIndex, secondIndex));
        }

        public void RegisterObserver(SortLog<T> observer)
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

        public override string ToString()
        {
            var strValues = Values.Select(x => x.ToString());
            return String.Join(" ", strValues);
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
