using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void NotifyObserver(int[] eventData);
        void RemoveObserver(IObserver observer);
    }
}
