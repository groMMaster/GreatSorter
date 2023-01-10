using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GreatSorter
{
    public static class RandomExtensions
    {
        public static int[] CreateArray(this Random random, int lenght)
        {
            var array = Enumerable.Range(1, lenght).ToArray();
            return array.OrderBy(x => random.Next()).ToArray();
        }
    }
}
