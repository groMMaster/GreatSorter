using GreatSorter.Sorts;
using System;
using System.Collections.Generic;

namespace GreatSorter
{
    public class BubbleSort<T> : AbstractSortAlgorithm<T>
        where T : IComparable
        
    {
<<<<<<< Updated upstream
        public override event Action<T[]> ArrayChangesNotify;

        public override void Sort(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i].CompareTo(array[j]) > 0)
                    {
                        array.Swap(i, j);
                        ArrayChangesNotify.Invoke(array);
=======
        public override SortableArray<T> Sort(T[] array)
        {
            var sortable = new SortableArray<T>(array);

            for (int i = 0; i < sortable.Length; i++)
            {
                for (int j = i + 1; j < sortable.Length; j++)
                {
                    if (sortable[i].CompareTo(sortable[j]) > 0)
                    {
                        sortable.Swap(i, j);
>>>>>>> Stashed changes
                    }
                }
            }

            return sortable;
        }
    }
}