using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public class SelectionSort<T>
        where T: IComparable
    {
        public static IEnumerable<T[]> Sort(T[] array)
        {
            yield return array;
            for (int i = 0; i < array.Length - 1; i++)
            {
                var smallestVal = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[smallestVal]) < 0)
                    {
                        smallestVal = j;
                    }
                }

                (array[smallestVal], array[i]) = (array[i], array[smallestVal]);

                yield return array;
            }
            
        }
    }
}
