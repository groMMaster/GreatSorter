using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GreatSorter
{
    public class SortableArray<T>
        where T : IComparable
    {
        private T[] values;

        public ReadOnlyCollection<T> GetValues => Array.AsReadOnly(values);
        public int Length => values.Length;

        private event EventHandler observers;

        public SortableArray(params T[] values)
        {
            this.values = values;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (!IsIndexInRange(firstIndex) || !IsIndexInRange(secondIndex))
                throw new IndexOutOfRangeException();

            (values[firstIndex], values[secondIndex]) = (values[secondIndex], values[firstIndex]);
            NotifyObserver(new ChangedArray<T>(values));
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

        public T this[int index]
        {
            get
            {
                return values[index];
            }
        }

        public override string ToString()
        {
            var strValue = values.Select(x => x.ToString());
            return string.Join(" ", strValue);
        }
    }

    public class ChangedArray<T> : EventArgs
    {
        public T[] Value;

        public ChangedArray(T[] value)
        {
            Value = value;
        }
    }
}