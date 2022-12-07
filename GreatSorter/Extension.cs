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
        public static string ToString(this int[] array)
        {
            return String.Join(" ", array);
        }
    }
}
