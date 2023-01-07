using System;
using System.Collections.Generic;

namespace GreatSorter
{
    public class BubbleSort<T> : SortAlgorithm<T>
        where T: IComparable
    {
        public BubbleSort(T[] array) : base(array) { }

        public override void Sort()
        {
            for (int i = 0; i < SortableArray.Length; i++)
            {
                for (int j = i + 1; j < SortableArray.Length; j++)
                {
                    if (SortableArray[i].CompareTo(SortableArray[j]) > 0)
                    {
                        SortableArray.Swap(i, j);
                    }
                }
            }
        }
    }
}