using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    internal static class Extension
    {

        public static string ToString(this int[] array)
        {
            return String.Join(" ", array);
        }
    }
}
