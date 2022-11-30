using System;
using GreatSorter;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new [] { '2', '4', '5', '3', '1'};
            foreach (var e in StoogeSort<char>.Sort(a))
            {
                Console.WriteLine(e);
            }
        }
    }
}
