using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter.Sorts
{
    

    public abstract class AbstractSortAlgorithm<T> : ISortable<T>
        where T : IComparable
    {
        public abstract event Action<T[]> ArrayChangesNotify;
        public abstract void Sort(T[] array);
    }
}
