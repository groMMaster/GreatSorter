using System;

namespace GreatSorter
{
    public class BubbleSort<T>
        where T : IComparable
    {
        public static T[] Sort(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i].CompareTo(array[j]) > 0)
                    {
                        array.Swap(i, j);
                    }
                }
            }

            return array;
        }
    }
}