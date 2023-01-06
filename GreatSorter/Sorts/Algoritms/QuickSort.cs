using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public class QuickSort<T> : SortAlgorithm<T>
        where T: IComparable
    {
        public QuickSort(T[] array) : base(array)
        {
            Name = "Quick Sort";
        }

        public override void Sort()
        {
            Sort(0, SortableArray.Length - 1);
        }

        public SortableArray<T> Sort(int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return SortableArray;
            }

            var pivotIndex = Partition(SortableArray, minIndex, maxIndex);
            Sort(minIndex, pivotIndex - 1);
            Sort(pivotIndex + 1, maxIndex);

            return SortableArray;
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
