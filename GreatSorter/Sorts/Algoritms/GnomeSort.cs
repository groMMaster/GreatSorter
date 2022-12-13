using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public class GnomeSort<T> : ISortAlgorithm<T>
        where T: IComparable
    {
        public SortableArray<T> Sort(SortableArray<T> array)
        {
            var index = 1;
            var nextIndex = index + 1;

            while (index < array.Length)
            {
                if (array[index - 1].CompareTo(array[index]) < 0)
                {
                    index = nextIndex;
                    nextIndex++;
                }
                else
                {
                    array.Swap(index - 1, index);
                    index--;
                    if (index == 0)
                    {
                        index = nextIndex++;
                    }
                }
            }

            return array;
        }

    }
}
