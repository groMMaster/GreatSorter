using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter.Sorts
{
    public abstract class AbstractSortAlgorithm<T> : ISortable<T>
        where T : IComparable
    {
        public delegate void ArrayChangesHandler(T[] array);

        public abstract event ArrayChangesHandler Notify;
        public abstract void Sort(T[] array);
    }
}
