using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public class SelectionSort<T>
        where T: IComparable
    {
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
        }
    }
}
