using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatSorter
{
    public class Sorter<T>
        where T: IComparable
    {
        SortableArray<T> Array { get; }
        public SortLog<T> Log;
        public ISortAlgoritm<T> Type;

        public Sorter(T[] array, ISortAlgoritm<T> typeSort)
        {
            Array = new SortableArray<T>(array);
            Log = new SortLog<T>((T[])array.Clone());
            Type = typeSort;

            Array.RegisterObserver(Log);
            Compile();
        }

        private void Compile()
        {
            Type.Sort(Array);
        }
    }
}
