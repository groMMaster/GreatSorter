using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatSorter
{
    public class SortHandler<T>
        where T : IComparable
    {
        public SortableArray<T> SortableArray { get; private set; }

        public SortHandler(T[] array)
        {
            SortableArray = new SortableArray<T>(array);
        }

        public void Start(ISortAlgorithm<T> typeSort)
        {
            typeSort.Sort(SortableArray);
        }
    }
}