using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    internal static class Extension
    {
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

        public static string ToString(this int[] array)
        {
            return String.Join(" ", array);
        }
    }
}
