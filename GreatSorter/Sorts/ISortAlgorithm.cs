using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public interface ISortAlgorithm<T>
        where T: IComparable
    {
        SortableArray<T> Sort(SortableArray<T> array);
    }
}
