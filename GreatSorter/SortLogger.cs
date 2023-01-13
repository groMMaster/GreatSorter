using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace GreatSorter
{
    public class SortLogger<T> : IObserver
    {
        private T[] start;
        private List<SwapIndexes> logs;

        public SortLogger(T[] start)
        {
            this.start = start;
            logs = new List<SwapIndexes>();
        }

        public void Update(object sender, object eventData)
        {
            logs.Add((SwapIndexes)eventData);
        }

        public IEnumerable<T[]> GetLogs()
        {
            yield return start;

            var array = (T[])start.Clone();
            foreach (var e in logs)
            {
                (array[e.First], array[e.Second]) = (array[e.Second], array[e.First]);
                yield return array;
            }
        }

        public List<T[]> GetAllArrayStates()
        {
            var result = new List<T[]>();

            //var array = (T[])start.Clone();
            foreach (var log in GetLogs())
            {
                result.Add((T[])log.Clone());
            }

            return result;
        }

        public override string ToString()
        {
            var result = GetLogs().Select(x => String.Join(", ", x));
            return String.Join("\n", result);
        }
    }
}