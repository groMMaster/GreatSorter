using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatSorter
{
    public class SortLog<T> : IObserver
    {
        private T[] start;
        private List<int[]> log;

        public SortLog(T[] start)
        {
            this.start = start;
            log = new List<int[]> { };
        }

        public void Update(int[] eventData)
        {
            log.Add(eventData);
        }

        public IEnumerable<T[]> GetLog()
        {
            yield return start;

            var array = (T[])start.Clone();
            foreach (var indexes in log)
            {
                Swap(array, indexes[0], indexes[1]);
                yield return array;
            }
        }

        private void Swap(T[] array, int firstIndex, int secondIndex)
        {
            var temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }

        public override string ToString()
        {
            var result = GetLog().Select(x => String.Join(", ", x));
            return String.Join("\n", result);
        }
    }
}
