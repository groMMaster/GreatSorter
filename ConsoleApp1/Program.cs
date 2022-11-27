using System;
using GreatSorter;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new string[] { "c", "a", "b" };
            SelectionSort<string>.Sort(a);
            foreach (var e in a)
            {
                Console.WriteLine(e);
            }
        }
    }
}
