using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;

namespace GreatSorter.Tests
{
    internal class SortHandlerTests
    {
        private SortHandler<int> sortHandlers;
        private ISortAlgorithm<int> sortAlgorithm;

        [SetUp]
        public void SetUp()
        {
            sortAlgorithm = A.Fake<ISortAlgorithm<int>>();
            sortHandlers = new SortHandler<int>();
        }

        [Test]
        public void StartCallsSortAlgorithm()
        {
            sortHandlers.Start(new int[] { }, sortAlgorithm);
            A.CallTo(() => sortAlgorithm.Sort(A<SortableArray<int>>.Ignored))
                .MustHaveHappened(1, Times.Exactly);
        }

    }
}
