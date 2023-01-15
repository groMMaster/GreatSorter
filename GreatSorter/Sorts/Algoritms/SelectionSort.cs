using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public class SelectionSort<T>
        where T: IComparable
    {
<<<<<<< Updated upstream
        public static T[] Sort(T[] array)
        {
            return Sort(array, 0);
        }

        private static T[] Sort(T[] array, int currentIndex)
        {
            if (currentIndex == array.Length)
                return array;

            var minIndex = array.IndexOfMin(currentIndex);
            if (minIndex != currentIndex)
            {
                array.Swap(minIndex, currentIndex);
            }

            return Sort(array, ++currentIndex);
=======
        public override SortableArray<T> Sort(T[] array)
        {
            var sortable =new SortableArray<T>(array);
            Sort(sortable, 0);
            return sortable;
        }

        private void Sort(SortableArray<T> sortable, int currentIndex)
        {
            if (currentIndex == sortable.Length)
                return;
            var minIndex = sortable.GetIndexOfMin(currentIndex);
            if (minIndex != currentIndex)
            {
                sortable.Swap(minIndex, currentIndex);
            }

            Sort(sortable, ++currentIndex);
>>>>>>> Stashed changes
        }
    }
}
