using System;
using System.Collections.Generic;
using System.Text;

namespace GreatSorter
{
    public class GnomeSort<T> : SortAlgorithm<T>
        where T: IComparable
    {
        public GnomeSort(T[] array) : base(array) { }

        public override void Sort()
        {
            var index = 1;
            var nextIndex = index + 1;

            while (index < SortableArray.Length)
            {
                if (SortableArray[index - 1].CompareTo(SortableArray[index]) < 0)
                {
                    index = nextIndex;
                    nextIndex++;
                }
                else
                {
                    SortableArray.Swap(index - 1, index);
                    index--;
                    if (index == 0)
                    {
                        index = nextIndex++;
                    }
                }
            }
        }
    }
}
