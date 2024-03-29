using System;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using GreatSorter;

namespace GreatSorter.Tests.Algorithms
{
    abstract class AbstractAlgorithmsTests
    {
        protected static int[] defaultUnsortedArray = 
            { 4, 1, int.MaxValue, 3, 2, 7, 16, int.MinValue, 9, -55, 14, 8 };

        protected int[] cloneDefaultUnsortedArray => (int[])defaultUnsortedArray.Clone();

        protected int[] GetRandomArray(int length, int min, int max)
        {
            var randNum = new Random();
            return Enumerable
                .Repeat(0, length)
                .Select(i => randNum.Next(min, max))
                .ToArray();
        }

        protected void CheckCorrectSorting(int[] unsortedArray, SortAlgorithm<int> sortAlgorithm)
        {
            var sortableArray = new SortableArray<int>(unsortedArray);

            var sortedArray = (int[])unsortedArray.Clone();
            Array.Sort(sortedArray);

            sortAlgorithm.Sort(unsortedArray);

            CollectionAssert.AreEqual(sortedArray, sortAlgorithm.Sort(unsortedArray).GetValues);
        }
    }
}