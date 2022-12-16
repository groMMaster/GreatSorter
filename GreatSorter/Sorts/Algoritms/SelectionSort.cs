using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public class SelectionSort<T> : SortAlgorithm<T>
        where T : IComparable
    {
        public SelectionSort(T[] array) : base(array) { }

        public override void Sort()
        {
            Sort(0);
        }

        private void Sort(int currentIndex)
        {
            if (currentIndex == SortableArray.Length)
                return;
            var minIndex = SortableArray.GetIndexOfMin(currentIndex);
            if (minIndex != currentIndex)
            {
                SortableArray.Swap(minIndex, currentIndex);
            }

            Sort(++currentIndex);
        }
    }
}
