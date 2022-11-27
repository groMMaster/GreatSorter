using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    internal static class Extension
    {
        public static void Swap<T>(this T[] array, int firstIndex, int secondIndex)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }

        public static int IndexOfMin<T>(this T[] array, int startIndex)
            where T: IComparable
        {
            int result = startIndex;
            for (var i = startIndex; i < array.Length; ++i)
            {
                if (array[i].CompareTo(array[result]) < 0)
                {
                    result = i;
                }
            }

            return result;
        }
    }
}
