using System;
using System.Collections.Generic;

namespace GreatSorter
{
    public class BubbleSort<T>
        where T : IComparable
    {
        public static IEnumerable<T[]> Sort(T[] array)
        {
            yield return array;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                        yield return array;
                    }
                }

            }
        }
    }
}