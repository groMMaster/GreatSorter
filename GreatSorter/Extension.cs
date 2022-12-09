using System;
using System.Linq;
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
        public static string ToString<T>(this T[] array)
        {
            return String.Join(" ", array);
        }
    }
}
