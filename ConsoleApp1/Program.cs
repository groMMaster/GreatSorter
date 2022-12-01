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
            var a = new [] { '3', '2', '1', '0'};

            var b = new StoogeSort<char>();
            void DisplayMessage(char[] message) => Console.WriteLine(message);

            b.Notify += DisplayMessage;

            b.Sort(a);

        }
    }
}
