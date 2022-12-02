using System;

namespace GreatSorter.Sorts
{
    public class SortHandler<T>
        where T: IComparable
    {
        private T[] Array { get; }
        private AbstractSortAlgorithm<T> algorithm;
        private bool isStartFirst = true;

        public SortHandler(T[] array,
            AbstractSortAlgorithm<T> algorithm,
            Action<T[]> arrayChangedEvent)
        {
            Array = array;
            this.algorithm = algorithm;
            algorithm.ArrayChangesNotify += arrayChangedEvent;
        }

        public void Sort()
        {
            if (isStartFirst)
            {
                algorithm.Sort(Array);
            }
        }
    }
}
