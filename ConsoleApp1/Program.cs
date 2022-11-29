using System;
using System.Collections.Generic;
using GreatSorter;

namespace ConsoleApp1
{
    static class Program
    {
        static void Main(string[] args)
        {
            var a = new int[] { 3, 1, 2, 0};
            foreach (var e in new BubbleSort<int>().Sort(a))
            {
                Console.WriteLine(String.Join(' ', e));
            }
        }
    }
}
