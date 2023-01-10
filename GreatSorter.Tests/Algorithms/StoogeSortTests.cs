using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatSorter.Tests.Algorithms
{
    internal class StoogeSortTests : AbstractAlgorithmsTests
    {
        [Test]
        public void SortDefaultUnsortedArray()
        {
            CheckCorrectSorting(defaultUnsortedArray, new StoogeSort<int>(cloneDefaultUnsortedArray));
        }

        [Test]
        public void SortRandomUnsortedArray()
        {

            var rndArray = GetRandomArray(10, -100, 100);
            var cloneRndArray = (int[])rndArray.Clone();
            CheckCorrectSorting(rndArray, new StoogeSort<int>(cloneRndArray));
        }

        [Test]
        public void ThrowExceptionIfArrayIsNull()
        {
            Assert.Throws<NullReferenceException>(() => new StoogeSort<int>(null).Sort());
        }
    }
}
