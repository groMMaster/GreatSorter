using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatSorter
{
    public class HandlerSort<T>
        where T : IComparable
    {
        public RealTimeSorter<T> Sorter { get; private set; }

        public void Start(T[] array, ISortAlgoritm<T> typeSort)
        {
            var sortableArray = new SortableArray<T>(array);
            var result = new RealTimeSorter<T>();
            sortableArray.RegisterObserver(result);
            typeSort.Sort(sortableArray);
        }
    }
}