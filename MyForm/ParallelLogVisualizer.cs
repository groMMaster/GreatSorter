using GreatSorter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForm
{
    public static class ParallelLogVisualizer<T> where T : IComparable
    {
        public static async Task Execute(SortLogger<int> firstSortLogger, Visualizer firstVisualizer, SortLogger<int> secondSortLogger, Visualizer secondVisualizer)
        {
            var firstSortTask = Task.Run(() => VisualizeLogger(firstSortLogger, firstVisualizer));
            var secondSortTask = Task.Run(() => VisualizeLogger(secondSortLogger, secondVisualizer));

            await firstSortTask;
            await secondSortTask;
        }

        private static async Task VisualizeLogger(SortLogger<int> sortLogger, Visualizer visualizer)
        {
            foreach (var log in sortLogger.GetLogs())
            {
                visualizer.Drawing(log);
                //Thread.Sleep(10);
                await Task.Delay(10);
            }
        }
    }
}
