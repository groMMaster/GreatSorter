using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatSorter
{
    public class SortableArray<T>
        where T : IComparable
    {
        private T[] value;
        public int Length => value.Length;

        private event EventHandler observers;

        public SortableArray(params T[] value)
        {
            this.value = value;
        }

        public T[] GetValues()
        {
            return value;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            value.Swap(firstIndex, secondIndex);
            NotifyObserver(new ChangedArray<T>(value));
        }

        public int IndexOfMin(int startIndex)
        {
            int result = startIndex;
            for (var i = startIndex; i < value.Length; ++i)
            {
                if (value[i].CompareTo(value[result]) < 0)
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

        public void RemoveObserver(IObserver observer)
        {
            observers -= observer.Update;
        }

        public T this[int index]
        {
            get
            {
                return value[index];
            }
        }

        public override string ToString()
        {
            var strvalue = value.Select(x => x.ToString());
            return String.Join(" ", strvalue);
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