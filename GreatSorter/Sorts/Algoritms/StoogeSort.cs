using GreatSorter.Sorts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public class StoogeSort<T>
        where T : IComparable
    {
<<<<<<< Updated upstream
        public void Sort(T[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private void Sort(T[] array, int startIndex, int endIndex)
        {
            if (array[startIndex].CompareTo(array[endIndex]) > 0)
            {
                array.Swap(startIndex, endIndex);
                //Notify.Invoke(array);
=======
        public override SortableArray<T> Sort(T[] array)
        {
            var sortable = new SortableArray<T>(array);
            Sort(sortable, 0, sortable.Length - 1);
            return sortable;
        }

        private void Sort(SortableArray<T> sortable, int startIndex, int endIndex)
        {
            if (sortable[startIndex].CompareTo(sortable[endIndex]) > 0)
            {
                sortable.Swap(startIndex, endIndex);
>>>>>>> Stashed changes
            }

            if (endIndex - startIndex > 1)
            {
                var len = (endIndex - startIndex + 1) / 3;
<<<<<<< Updated upstream
                Sort(array, startIndex, endIndex - len);
                Sort(array, startIndex + len, endIndex);
                Sort(array, startIndex, endIndex - len);
=======
                Sort(sortable, startIndex, endIndex - len);
                Sort(sortable, startIndex + len, endIndex);
                Sort(sortable, startIndex, endIndex - len);
>>>>>>> Stashed changes
            }
        }
    }
}
