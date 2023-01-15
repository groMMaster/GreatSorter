using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatSorter.Tests
{
    internal class SortableArrayTests
    {
        private SortableArray<int> sortableArray;

        [SetUp]
        public void SetUp()
        {
            sortableArray = new SortableArray<int>(1, 2, 3);
        }

        [TestCase(0, 1, new []{2, 1, 3})]
        [TestCase(2, 1, new[] { 1, 3, 2 })]
        [TestCase(0, 2, new[] { 3, 2, 1 })]
        public void SwapCorrectIndexes(int firstIndex, int secondIndex, int[] expectedResult)
        {
            sortableArray.Swap(firstIndex, secondIndex);
            Assert.AreEqual(expectedResult, sortableArray.GetValues);
        }

        [TestCase(0, 1, new[] { 2, 1, 3 })]
        [TestCase(2, 1, new[] { 1, 3, 2 })]
        [TestCase(0, 2, new[] { 3, 2, 1 })]
        public void SameResultIfArgumentsSwapPosition(int firstIndex, int secondIndex, int[] expectedResult)
        {
            var secondSortableArray = new SortableArray<int>(sortableArray.GetValues.ToArray());

            sortableArray.Swap(firstIndex, secondIndex);
            secondSortableArray.Swap(secondIndex, firstIndex);

            Assert.AreEqual(expectedResult, sortableArray.GetValues);
            Assert.AreEqual(secondSortableArray.GetValues, sortableArray.GetValues);
        }

        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        [TestCase(0, 3)]
        [TestCase(3, 0)]
        [TestCase(-1, 3)]
        [TestCase(3, -1)]
        public void ThrowExceptionWhenIndexesOutOfRangeInSwap(int firstIndex, int secondIndex)
        {
            Assert.Throws<IndexOutOfRangeException>(() => sortableArray.Swap(firstIndex, secondIndex));
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        public void GetIndexOfMinWithCorrectStartIndex(int startIndex, int expectedIndex)
        {
            Assert.AreEqual(expectedIndex, sortableArray.GetIndexOfMin(startIndex));
        }

        [Test]
        public void GetIndexOfMinWithoutStartIndex()
        {
            Assert.AreEqual(0, sortableArray.GetIndexOfMin());
        }

        [TestCase(-1)]
        [TestCase(3)]
        public void ThrowExceptionWhenIndexesOutOfRangeInMinIndex(int startIndex)
        {
            Assert.Throws<IndexOutOfRangeException>(() => sortableArray.GetIndexOfMin(startIndex));
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
    }
}