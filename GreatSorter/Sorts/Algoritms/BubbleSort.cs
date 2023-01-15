using System;

namespace GreatSorter
{
    public class BubbleSort<T> : SortAlgorithm<T>
        where T: IComparable
    {
        protected override SortableArray<T> Sort(SortableArray<T> array)
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