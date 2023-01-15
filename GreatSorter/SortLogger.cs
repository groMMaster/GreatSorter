using System;
using System.Collections.Generic;
using System.Linq;

namespace GreatSorter
{
    public class SortLogger<T> : IObserver
    {
        public int Count => logs.Count;

        private T[] start;
        public List<SwapIndexes> logs;
        public T[] curArrayState;
        private int currentLogIndex;

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

        public T[] GetNext()
        {
            if (currentLogIndex > logs.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            if (currentLogIndex == 0)
            {
                curArrayState = (T[])start.Clone();
            }

            var curLog = logs[currentLogIndex];
            (curArrayState[curLog.First], curArrayState[curLog.Second]) = (curArrayState[curLog.Second], curArrayState[curLog.First]);
            currentLogIndex++;

            return curArrayState;
        }

        public List<T[]> GetAllArrayStates()
        {
            var result = new List<T[]>();

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