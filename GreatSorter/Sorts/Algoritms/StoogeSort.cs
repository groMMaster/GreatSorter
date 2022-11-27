using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public class StoogeSort<T>
        where T : IComparable
    {
        public static T[] Sort(T[] array)
        {
            return Sort(array, 0, array.Length - 1);
        }

        private static T[] Sort(T[] array, int startIndex, int endIndex)
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

            return array;
        }
    }
}
