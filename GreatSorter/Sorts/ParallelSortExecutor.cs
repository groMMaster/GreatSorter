using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreatSorter
{
    public static class ParallelSortExecutor<T> where T : IComparable
    {
        public static async Task Execute(SortAlgorithm<T> firstSortAlgorithm, SortAlgorithm<T> secondSortAlgorithm)
        {
            var firstSortTask = Task.Run(() => firstSortAlgorithm.Sort());
            var secondSortTask = Task.Run(() => secondSortAlgorithm.Sort());

            await firstSortTask;
            await secondSortTask;
        }
    }
}
