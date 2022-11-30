using System;
using GreatSorter;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new [] { '4', '9', '7', '6', '2', '3' };
            foreach (var e in StoogeSort<char>.Sort(a))
            {
                Console.WriteLine(e);
            }
        }
    }
}
