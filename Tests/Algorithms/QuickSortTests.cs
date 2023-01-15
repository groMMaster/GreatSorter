using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatSorter.Tests.Algorithms
{
    internal class QuickSortTests : AbstractAlgorithmsTests
    {
        [Test]
        public void SortDefaultUnsortedArray()
        {
            CheckCorrectSorting(defaultUnsortedArray, new QuickSort<int>());
        }

        [Test]
        public void SortRandomUnsortedArray()
        {

            var rndArray = GetRandomArray(10, -100, 100);
            var cloneRndArray = (int[])rndArray.Clone();
            CheckCorrectSorting(rndArray, new QuickSort<int>());
        }

        [Test]
        public void ThrowExceptionIfArrayIsNull()
        {
            Assert.Throws<NullReferenceException>(() => new QuickSort<int>().Sort(null));
        }
    }
}
