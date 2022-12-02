using System;
using System.Collections.Generic;
using System.Linq;
using GreatSorter;
using GreatSorter.Sorts;

namespace ConsoleApp1
{
    static class Program
    {
        static void Main(string[] args)
        {
            var a = new [] { '3', '2', '1', '0'};

            var b = new SortHandler<char>(a, new BubbleSort<char>(),
                x => Console.WriteLine(x));

            b.Sort();
        }
    }
}
