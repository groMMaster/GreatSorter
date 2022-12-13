using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public class SelectionSort<T> : ISortAlgorithm<T>
        where T : IComparable
    {
        public SortableArray<T> Sort(SortableArray<T> array)
        {
            return Sort(array, 0);
        }

        private SortableArray<T> Sort(SortableArray<T> array, int currentIndex)
        {
            if (currentIndex == array.Length)
                return array;
            var minIndex = array.GetIndexOfMin(currentIndex);
            if (minIndex != currentIndex)
            {
                array.Swap(minIndex, currentIndex);
            }

            return Sort(array, ++currentIndex);
        }
    }
}
