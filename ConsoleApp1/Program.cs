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
            var a = new int[] { 3, 2, 5, 0};
            var sorter = new HandlerSort<int>(a, new StoogeSort<int>());
            Console.WriteLine(sorter.Log.ToString());
        }
    }
}
