using System;

namespace GreatSorter
{
    public class SelectionSort<T> : SortAlgorithm<T>
        where T : IComparable
    {
        protected override SortableArray<T> Sort(SortableArray<T> array)
        {
            Sort(array, 0);
            return array;
        }

        private void Sort(SortableArray<T> array, int currentIndex)
        {
            if (currentIndex == array.Length)
                return;
            var minIndex = array.GetIndexOfMin(currentIndex);
            if (minIndex != currentIndex)
            {
                array.Swap(minIndex, currentIndex);
            }

            Sort(array, ++currentIndex);
        }
    }
}
