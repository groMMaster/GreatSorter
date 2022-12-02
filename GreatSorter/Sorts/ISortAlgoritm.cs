using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public interface ISortAlgoritm<T>
        where T: IComparable
    {
        SortableArray<T> Sort(SortableArray<T> array);
    }
}
