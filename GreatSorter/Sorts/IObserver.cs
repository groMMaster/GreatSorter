using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatSorter
{
    public interface IObserver
    {
        void HandleEvent(object sender, object eventData);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void NotifyObserver(object eventData);
        void RemoveObserver(IObserver observer);
    }

    public class SortableArray<T> : ISubject
        where T: IComparable
    {
        public T[] Values { get; }

        public SortableArray(params T[] values)
        {
            Values = values;
        }

        public void RegisterObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void NotifyObserver(object eventData)
        {
            throw new NotImplementedException();
        }

        public void RemoveObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var strValues = Values.Select(x => x.ToString());
            return String.Join(" ", strValues);
        }
    }
}
