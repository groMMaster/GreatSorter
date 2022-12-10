using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatSorter.Tests.Algorithms
{
    internal class SelectionSortTests : AbstractAlgorithmsTests
    {
        [Test]
        public void SortDefaultUnsortedArray()
        {
            CheckCorrectSorting(defaultUnsortedArray, new SelectionSort<int>());
        }

        [Test]
        public void SortRandomUnsortedArray()
        {
            CheckCorrectSorting(GetRandomArray(10, -100, 100), new SelectionSort<int>());
        }

        [Test]
        public void NotChangeEmptyArray()
        {
            var sortableArray = new SortableArray<int>();
            Assert.AreEqual(Array.Empty<int>(), sortableArray.GetValues);
        }

        [Test]
        public void NotChangeArrayWithOneElement()
        {
            var sortableArray = new SortableArray<int>(0);
            Assert.AreEqual(new[] { 0 }, sortableArray.GetValues);
        }

        [Test]
        public void ThrowExceptionIfArrayIsNull()
        {
            Assert.Throws<NullReferenceException>(() => new SelectionSort<int>().Sort(null));
        }
    }
}