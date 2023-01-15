using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatSorter.Tests.Algorithms
{
    internal class GnomeSortTests : AbstractAlgorithmsTests
    {
        [Test]
        public void SortDefaultUnsortedArray()
        {
            CheckCorrectSorting(defaultUnsortedArray, new GnomeSort<int>());
        }

        [Test]
        public void SortRandomUnsortedArray()
        {

            var rndArray = GetRandomArray(10, -100, 100);
            CheckCorrectSorting(rndArray, new GnomeSort<int>());
        }

        [Test]
        public void ThrowExceptionIfArrayIsNull()
        {
            Assert.Throws<NullReferenceException>(() => new BubbleSort<int>().Sort(null));
        }
    }
}
