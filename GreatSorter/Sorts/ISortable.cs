using GreatSorter.Sorts;
using System;
using System.Collections.Generic;
using System.Reflection;

interface ISortable<T>
    where T : IComparable
{
    //Action<T[]> ArrayChangedEventHandler<T>();
    void Sort(T[] array);
}

