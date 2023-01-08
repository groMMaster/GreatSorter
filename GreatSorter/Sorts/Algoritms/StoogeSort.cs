using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public class StoogeSort<T> : SortAlgorithm<T>
        where T : IComparable
    {
        public StoogeSort(T[] array) : base(array) { }

        public override void Sort()
        {
            Sort(0, SortableArray.Length - 1);
        }

        private void Sort(int startIndex, int endIndex)
        {
            if (SortableArray[startIndex].CompareTo(SortableArray[endIndex]) > 0)
            {
                SortableArray.Swap(startIndex, endIndex);
            }

            if (endIndex - startIndex > 1)
            {
                var len = (endIndex - startIndex + 1) / 3;
                Sort(startIndex, endIndex - len);
                Sort(startIndex + len, endIndex);
                Sort(startIndex, endIndex - len);
            }
        }
    }
}
