using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public class StoogeSort : ISortAlgoritm
    {
        public IEnumerable<T[]> Sort<T>(T[] array)
            where T : IComparable
        {
            return Sort(array, 0, array.Length - 1);
        }

        private IEnumerable<T[]> Sort<T>(T[] array, int startIndex, int endIndex)
            where T : IComparable
        {
            if (array[startIndex].CompareTo(array[endIndex]) > 0)
            {
                array.Swap(startIndex, endIndex);
                yield return array;
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
