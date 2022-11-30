using System;
using System.Collections.Generic;
using System.Linq;
using GreatSorter;

namespace ConsoleApp1
{
    static class Program
    {
        static void Main(string[] args)
        {
            var a = new int[] { 3, 2, 1, 0};
            var b = new SortableArray<int>(a);
            Console.WriteLine(b);
            var sort = new Sorter<int>(a, new StoogeSort());
            var log = sort.GetLog();
            foreach (var e in log)
            {
                Console.WriteLine(String.Join(' ', e));
            }
        }
    }
}
