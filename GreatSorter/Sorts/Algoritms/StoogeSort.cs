using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace GreatSorter
{
    public class StoogeSort<T>
        where T : IComparable
    {
        public static IEnumerable<T[]> Sort(T[] array)
        {
            yield return array;
            foreach (var arr in Sort(array, 0, array.Length - 1))
            {
                yield return arr;
            }
        }

        private static IEnumerable<T[]> Sort(T[] array, int startIndex, int endIndex)
        {
            if (array[startIndex].CompareTo(array[endIndex]) > 0)
            {
                (array[startIndex], array[endIndex]) = (array[endIndex], array[startIndex]);
                yield return array;
            }

            if (endIndex - startIndex > 1)
            {
                var len = (endIndex - startIndex + 1) / 3;
                foreach (var elem in Sort(array, startIndex, endIndex - len))
                {
                    yield return elem;
                }

                foreach (var elem in Sort(array, startIndex + len, endIndex))
                {
                    yield return elem;
                }

                foreach (var elem in Sort(array, startIndex, endIndex - len))
                {
                    yield return elem;
                }
            }
           

        }
    }
}
