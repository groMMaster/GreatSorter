using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatSorter
{
    public abstract class SortAlgorithm<T>
        where T : IComparable
    {
        public string Name { get; protected set; }
        public SortableArray<T> SortableArray { get; private set; }

        public SortAlgorithm(T[] array)
        {
            SortableArray = new SortableArray<T>(array);
        }

        public abstract void Sort();

        public override string ToString() { return Name; }
    }
}