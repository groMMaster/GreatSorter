using GreatSorter.Sorts;
using System;
using System.Collections.Generic;
using System.Reflection;

interface ISortable<T>
    where T : IComparable
{
    void Sort(T[] array);
}

