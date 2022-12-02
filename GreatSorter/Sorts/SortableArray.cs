using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatSorter
{
    public class SortableArray<T> : ISubject
        where T : IComparable
    {
        public T[] Values { get; }
        public int Length => Values.Length;

        private List<IObserver> observers;

        public SortableArray(params T[] values)
        {
            Values = values;
            observers = new List<IObserver> { };
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var temp = Values[firstIndex];
            Values[firstIndex] = Values[secondIndex];
            Values[secondIndex] = temp;
            NotifyObserver(new int[] { firstIndex, secondIndex });
        }

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyObserver(int[] eventData)
        {
            foreach (var observer in observers)
            {
                observer.Update(eventData);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public override string ToString()
        {
            var strValues = Values.Select(x => x.ToString());
            return String.Join(" ", strValues);
        }
    }
}
