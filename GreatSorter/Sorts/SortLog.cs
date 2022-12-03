using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatSorter
{
    public class SortLog<T>
    {
        private T[] start;
        private List<SwapIndexes> log;

        public SortLog(T[] start)
        {
            this.start = start;
            log = new List<SwapIndexes> { };
        }

        public void Update(object sender, object eventData)
        {
            log.Add((SwapIndexes)eventData);
        }

        public IEnumerable<T[]> GetLog()
        {
            yield return start;

            var array = (T[])start.Clone();
            foreach (var e in log)
            {
                Swap(array, e.First, e.Second);
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
