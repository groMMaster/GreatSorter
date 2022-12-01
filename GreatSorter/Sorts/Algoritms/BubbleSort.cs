using GreatSorter.Sorts;
using System;
using System.Collections.Generic;

namespace GreatSorter
{
    public class BubbleSort<T> : AbstractSortAlgorithm<T>
        where T : IComparable
        
    {
        public override event ArrayChangesHandler Notify;

        public override void Sort(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i].CompareTo(array[j]) > 0)
                    {
                        array.Swap(i, j);
                        Notify.Invoke(array);
                    }
                }
            }
        }
    }
}