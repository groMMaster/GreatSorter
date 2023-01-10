using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatSorter.Tests.Algorithms
{
    internal class BubbleSortTests : AbstractAlgorithmsTests
    {
        [Test]
        public void SortDefaultUnsortedArray()
        {
            CheckCorrectSorting(defaultUnsortedArray, new BubbleSort<int>(cloneDefaultUnsortedArray));
        }

        [Test]
        public void SortRandomUnsortedArray()
        {

            var rndArray = GetRandomArray(10, -100, 100);
            var cloneRndArray = (int[])rndArray.Clone();
            CheckCorrectSorting(rndArray, new BubbleSort<int>(cloneRndArray));
        }

        [Test]
        public void ThrowExceptionIfArrayIsNull()
        {
            Assert.Throws<NullReferenceException>(() => new BubbleSort<int>(null).Sort());
        }
    }
}
