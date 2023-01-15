using System;

namespace GreatSorter
{
    public class GnomeSort<T> : SortAlgorithm<T>
        where T: IComparable
    {
        public override SortableArray<T> Sort(T[] array)
        {
            var index = 1;
            var nextIndex = index + 1;
            var sortable = new SortableArray<T>(array);

            while (index < sortable.Length)
            {
                if (sortable[index - 1].CompareTo(sortable[index]) < 0)
                {
                    index = nextIndex;
                    nextIndex++;
                }
                else
                {
                    sortable.Swap(index - 1, index);
                    index--;
                    if (index == 0)
                    {
                        index = nextIndex++;
                    }
                }
            }

            return sortable;
        }
    }
}
