using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatSorter
{
    public class RealTimeSorter<T> : IObserver
    {
        public void Update(object sender, object eventData)
        {
            var newArr = ((ChangedArray<T>)eventData).Value;
            Console.WriteLine(newArr.ToString<T>());
        }
    }
}
