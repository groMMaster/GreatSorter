using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;

namespace GreatSorter
{
    public class RndArray
    {
        public static int[] Get(int lenght)
        {
            var array = Enumerable.Range(1, lenght).ToArray();
            Random random = new Random();
            return array.OrderBy(x => random.Next()).ToArray();
        }
    }
}
