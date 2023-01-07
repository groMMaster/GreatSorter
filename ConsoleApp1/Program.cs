using System;
using System.Collections.Generic;
using System.Linq;
using GreatSorter;

namespace ConsoleApp1
{
    static class Program
    {
        public static void Main(string[] args)
        {
            var d = new Dictionary<int, Dictionary<string, int>>();
            var e1 = new Dictionary<string, int>();
            var e2 = new Dictionary<string, int>();

            e1.Add("a", 3);
            e1.Add("b", 4);

            e2.Add("c", 5);
            e2.Add("d", 6);
            d.Add(1, e1);
            d.Add(2, e2);

            var keys = d[1].Keys;
            foreach (var key in keys)
            {
                Console.Write(key);
            }
            Console.WriteLine();
            foreach (var key in keys)
            {
                Console.WriteLine(d[1][key]);
            }
        }
    }
}
