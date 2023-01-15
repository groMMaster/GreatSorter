using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GreatSorter
{
    public class SortableArray<T>
        where T : IComparable
    {
        private T[] values;
        public SortLogger<T> Logger { get; private set; }

        public ReadOnlyCollection<T> GetValues => Array.AsReadOnly(values);
        public int Length => values.Length;

        private event EventHandler observers;

        public SortableArray(params T[] values)
        {
            if (values == null) throw new NullReferenceException();
            this.values = values;
            Logger = new SortLogger<T>(this);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (!IsIndexInRange(firstIndex) || !IsIndexInRange(secondIndex))
                throw new IndexOutOfRangeException();

            (values[firstIndex], values[secondIndex]) = (values[secondIndex], values[firstIndex]);
            NotifyObserver(new SwapIndexes(firstIndex, secondIndex));
        }

        public int GetIndexOfMin(int startIndex = 0)
        {
            if (!IsIndexInRange(startIndex))
                throw new IndexOutOfRangeException();

            var result = startIndex;
            for (var i = startIndex; i < values.Length; ++i)
            {
                if (values[i].CompareTo(values[result]) < 0)
                {
                    result = i;
                }
            }

            return result;
        }
        private bool IsIndexInRange(int index)
        {
            return index >= 0 && index <= values.Length - 1;
        }

        public void RegisterObserver(IObserver observer)
        {
            observers += observer.Update;
        }

        public void NotifyObserver(EventArgs eventData)
        {
            observers?.Invoke(this, eventData);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers -= observer.Update;
        }

        public T this[int index] => values[index];

        public override string ToString()
        {
            var strValue = values.Select(x => x.ToString());
            return string.Join(" ", strValue);
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