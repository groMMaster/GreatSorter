using System;

namespace GreatSorter
{
    public class StoogeSort<T> : SortAlgorithm<T>
        where T : IComparable
    {
        protected override SortableArray<T> Sort(SortableArray<T> array)
        {
            Sort(array, 0, array.Length - 1);
            return array;
        }

        private void Sort(SortableArray<T> array, int startIndex, int endIndex)
        {
            if (array[startIndex].CompareTo(array[endIndex]) > 0)
            {
                array.Swap(startIndex, endIndex);
            }

            if (endIndex - startIndex > 1)
            {
                var len = (endIndex - startIndex + 1) / 3;
                Sort(array, startIndex, endIndex - len);
                Sort(array, startIndex + len, endIndex);
                Sort(array, startIndex, endIndex - len);
            }
        }
    }
}
