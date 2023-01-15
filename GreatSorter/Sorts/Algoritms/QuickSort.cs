using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public class QuickSort<T> : SortAlgorithm<T>
        where T: IComparable
    {
        protected override SortableArray<T> Sort(SortableArray<T> array)
        {
            Sort(array, 0, array.Length - 1);
            return array;
        }

        public SortableArray<T> Sort(SortableArray<T> array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            Sort(array, minIndex, pivotIndex - 1);
            Sort(array, pivotIndex + 1, maxIndex);

            return array;
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
