using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public class QuickSort<T> : SortAlgorithm<T>
        where T: IComparable
    {
        public override SortableArray<T> Sort(T[] array)
        {
            var sortable = new SortableArray<T>(array);
            return Sort(sortable, 0, array.Length - 1);
        }

        public SortableArray<T> Sort(SortableArray<T> sortable, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return sortable;
            }

            var pivotIndex = Partition(sortable, minIndex, maxIndex);
            Sort(sortable, minIndex, pivotIndex - 1);
            Sort(sortable, pivotIndex + 1, maxIndex);

            return sortable;
        }

        private int Partition(SortableArray<T> array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i].CompareTo(array[maxIndex]) < 0)
                {
                    pivot++;
                    array.Swap(pivot, i);
                }
            }

            pivot++;
            array.Swap(pivot, maxIndex);
            return pivot;
        }
    }
}
